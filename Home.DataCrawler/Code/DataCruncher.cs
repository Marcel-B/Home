using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Home.DataCrawler.Data;
using Home.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Home.DataCrawler.Code
{



    public class DataCruncher
    {
        Dictionary<string, Guid> map = new Dictionary<string, Guid>();

        public const string WandThermostat = "OEQ1668708:1";
        public const string SteckdoseTv = "OEQ0571647:1";
        public const string Bewegungsmelder = "NEQ1297587:1";
        public const string DeckenlampeSchalter = "OEQ0182339:1";
        public const string AlarmSchalter = "NEQ0889879:2";
        public const string FensterBadHinten = "OEQ0222798:1";
        public const string FensterSchlafzimmerRechts = "OEQ0707446:1";
        public const string FensterSchlafzimmerLinks = "OEQ0707415:1";
        public const string FensterWohnzimmerLinks = "OEQ0707467:1";
        public const string FensterWohnzimmerRechts = "OEQ0707434:1";
        public const string FensterTerrasseLinks = "OEQ0226938:1";
        public const string FensterTerrasseRechts = "OEQ0222677:1";
        public const string FensterKinderzimmerLinks = "OEQ0707459:1";
        public const string FensterKinderzimmerRechts = "OEQ0707418:1";


        private HashSet<string> h = new HashSet<string>{
            WandThermostat, // WandThermostat
			Bewegungsmelder, // BRIGHTNESS
			SteckdoseTv, // STATE SteckdoseTv
            FensterBadHinten, // Fenster BadHinten
            FensterSchlafzimmerRechts, // Fenster RechtsSchlafzimmer
		    FensterSchlafzimmerLinks, // Fenster LinksSchlafzimmer
		    FensterWohnzimmerLinks, // Fenster links Wohnzimmer
			FensterWohnzimmerRechts, // Fenster Rechts Wohnzimmer
            FensterTerrasseRechts, // TerrasseRechts
            FensterTerrasseLinks, // TerrasseLinks
			FensterKinderzimmerLinks, // Fenster Kinderzimmer Links
			FensterKinderzimmerRechts, // Fenster Kinderzimmer Rechts
            "NEQ1774153:4", // BadHinten Temperatur
            "NEQ1778676:4", // HeizungWohnen
			"NEQ0863777:1", // Zäher Keller
			DeckenlampeSchalter, // Deckenlampe
			AlarmSchalter, // Alarmknopf
			"HU-Philips hue:1", // Hue Bridge
			"000AD709A5963B:2" // Alarmanlange Mitteilung
        };
        private HashSet<string> n = new HashSet<string>{
            "TEMPERATURE",
            "BRIGHTNESS",
            "HUMIDITY",
            "STATE",
            "POWER",
            "ACTUAL_TEMPERATURE",
        };
        private ILogger<DataCruncher> _logger;
        private readonly IServiceProvider _service;

        private IList<MeasurePoint> Points { get; }

        public DataCruncher(IServiceProvider service, ILogger<DataCruncher> logger)
        {
            _logger = logger;
            _service = service;
            Points = new List<MeasurePoint>();
        }

        public async void SetData(MeasurePoint measurePoint)
        {
            var id = measurePoint.ChannelId.Split(':')[0];
            var db = _service.GetService<ValueContext>();

            // Richtige Entität suchen
            var tt = db.MeasurePoints.SingleOrDefault(x => x.ChannelId.Equals(id));
            if(tt == null) return;
            //_logger.LogInformation($"{Points.Count} {measurePoint.ChannelId}|{measurePoint.PointName} = {measurePoint.PointValue}");
            if (h.Contains(measurePoint.ChannelId) && n.Contains(measurePoint.PointName))
            {
                Points.Add(measurePoint);
                _logger.LogInformation($"{measurePoint.Guid} ({measurePoint.PointName} | {measurePoint.ChannelId} value {measurePoint.PointValue})added to List");
                if (Points.Count >= 5)
                {
                    var newList = Points.ToList();
                    Points.Clear();
                    _logger.LogInformation($"Points Count = {Points.Count}");
                    _logger.LogInformation($"NewPts Count = {newList.Count}");
                    await Task.Run(() =>
                    {
                        UploadData(newList);
                        UpdateData(newList);
                    });
                }
            }
        }
        public async void UpdateData(IList<MeasurePoint> points)
        {
            var db = _service.GetService<ValueContext>();
            foreach (var point in points)
            {
                var id = point.ChannelId.Split(':')[0];
                var v = db.HomeMaticStates.SingleOrDefault(x => x.DeviceId.Equals(id));
                if (v == null) continue;
                v.State = (int)point.PointValue == 1;
                v.LastEdit = DateTimeOffset.Now;
            }
            await db.SaveChangesAsync().ConfigureAwait(false);
        }
            
        public async void UploadData(IList<MeasurePoint> data)
        {
            try
            {
                var db = _service.GetService<ValueContext>();
                //foreach (var obj in data)
                //{
                //	db.MeasurePoints.Add(obj);
                //	_logger.LogInformation(obj.ChannelId);
                //}
                await db.MeasurePoints.AddRangeAsync(data);
                //var o = db.HomeMaticStates.FirstOrDefault(p => p.Name.Equals(data.Fo))
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
