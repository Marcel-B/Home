using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Home.Domain.Entities;

namespace Home.Worker
{
	public class DataCruncher
	{
		private HashSet<string> h = new HashSet<string>{
				"OEQ1668708:1", // WandThermostat
                "NEQ1297587:1", // BRIGHTNESS
                "OEQ0571647:1", // STATE SteckdoseTv
                "OEQ0222798:1", // Fenster BadHinten
                "OEQ0707446:1", // Fenster RechtsSchlafzimmer
                "OEQ0222677:1", // TerrasseRechts
                "OEQ0226938:1", // TerrasseLinks
                "NEQ1774153:4", // BadHinten Temperatur
                "NEQ1778676:4", // HeizungWohnen
            };
		private HashSet<string> n = new HashSet<string>{
				"TEMPERATURE",
				"BRIGHTNESS",
				"HUMIDITY",
				"STATE",
				"ACTUAL_TEMPERATURE",
			};
		private readonly IServiceProvider _service;

		private IList<MeasurePoint> Points { get; }

		public DataCruncher(IServiceProvider service)
		{
			_service = service;
			Points = new List<MeasurePoint>();
		}

		public async void SetData(MeasurePoint measurePoint)
		{
			Console.WriteLine($"{Points.Count} {measurePoint.ChannelId}|{measurePoint.PointName} = {measurePoint.PointValue}");

			if (h.Contains(measurePoint.ChannelId) && n.Contains(measurePoint.PointName))
			{
				Points.Add(measurePoint);
				Console.WriteLine($"{measurePoint.Guid} added to List");
				if (Points.Count > 10)
				{
					var newList = Points.ToList();
					Points.Clear();
					Console.WriteLine($"Points Count = {Points.Count}");
					Console.WriteLine($"NewPts Count = {newList.Count}");
					await Task.Run(() =>
					{
						UploadData(newList);
					});
				}
			}

		}

		public void UploadData(IList<MeasurePoint> data)
		{

	
		}
	}
}
