using System;
using System.ComponentModel.DataAnnotations;

namespace Home.Domain.Entities
{
	public class MeasurePoint
    {
        [Key]
        public string Guid { get; set; }

        public string ChannelId { get; set; }
        public string PointName { get; set; }
        public double PointValue { get; set; }
        public DateTimeOffset? Create { get; set; }
    }
}
