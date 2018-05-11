using System;
using Home.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Home.DataCrawler.Data
{
	public class ValueContext : DbContext
	{
		public ValueContext(DbContextOptions<ValueContext> builder)
			: base(builder) { }

		public DbSet<Value> Values { get; set; }
		public DbSet<MeasurePoint> MeasurePoints { get; set; }
	}
}
