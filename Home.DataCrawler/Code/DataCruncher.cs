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
		private HashSet<string> h = new HashSet<string>{
			"OEQ1668708:1", // WandThermostat
            "NEQ1297587:1", // BRIGHTNESS
            "OEQ0571647:1", // STATE SteckdoseTv
            "OEQ0222798:1", // Fenster BadHinten
            "OEQ0707446:1", // Fenster RechtsSchlafzimmer
		    "OEQ0707415:1", // Fenster LinksSchlafzimmer
		    "OEQ0707467:1", // Fenster links Wohnzimmer
			"OEQ0707434:1", // Fenster Rechts Wohnzimmer
            "OEQ0222677:1", // TerrasseRechts
            "OEQ0226938:1", // TerrasseLinks
			"OEQ0707459:1", // Fenster Kinderzimmer Links
			"OEQ0707418:1", // Fenster Kinderzimmer Rechts
            "NEQ1774153:4", // BadHinten Temperatur
            "NEQ1778676:4", // HeizungWohnen
			"NEQ0863777:1", // Zäher Keller
			"OEQ0182339:1", // Deckenlampe
			"NEQ0889879:2", // Alarmknopf
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
			_logger.LogInformation($"{Points.Count} {measurePoint.ChannelId}|{measurePoint.PointName} = {measurePoint.PointValue}");
			if (h.Contains(measurePoint.ChannelId) && n.Contains(measurePoint.PointName))
			{
				Points.Add(measurePoint);
				_logger.LogInformation($"{measurePoint.Guid} ({measurePoint.PointName} | {measurePoint.ChannelId} value {measurePoint.PointValue})added to List");
				if (Points.Count >= 10)
				{
					var newList = Points.ToList();
					Points.Clear();
					_logger.LogInformation($"Points Count = {Points.Count}");
					_logger.LogInformation($"NewPts Count = {newList.Count}");
					await Task.Run(() =>
					{
						UploadData(newList);
					});
				}
			}
		}

		public async void UploadData(IList<MeasurePoint> data)
		{
			try
			{
				var db = _service.GetService<ValueContext>();
				foreach (var obj in data)
				{
					db.MeasurePoints.Add(obj);
					Console.WriteLine(obj.ChannelId);
				}
				await db.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex);
				//Console.WriteLine(ex.Message);
			}
		}
	}
}
