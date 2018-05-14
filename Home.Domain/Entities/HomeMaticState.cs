using System;
using System.ComponentModel.DataAnnotations;

namespace Home.Domain.Entities
{
	public class HomeMaticState
	{
		public HomeMaticState() { }

		[Key]
		public Guid Pk { get; set; }

		public string Name { get; set; }
        public string DeviceId { get; set; }
        public int ChannelId { get; set; }
        public bool State { get; set; }
		public DateTimeOffset? LastEdit { get; set; }
	}
}
