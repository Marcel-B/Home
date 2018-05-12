using System;
using System.Collections.Generic;
using Home.Domain.Entities;

namespace Home.Worker
{
    public class DataCruncher
    {
		public IList<MeasurePoint> Points { get; set; }
        public DataCruncher()
        {
        }
    }
}
