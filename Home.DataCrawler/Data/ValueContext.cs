using System;
using Home.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Home.DataCrawler.Data
{
	public class ValueContext : DbContext
	{
		public ValueContext(DbContextOptions<ValueContext> builder)
			: base(builder) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<HomeMaticState>().HasData(
				new HomeMaticState { Pk = Guid.Parse("af39e5b0-28c3-4968-b6bd-cbaf6076a0a3"), Name = "SteckdoseTv", DeviceId = "OEQ0571647", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("18cc2f3b-1d49-4cc4-8473-3ec2639ba352"), Name = "Alarmanlage", DeviceId = "NEQ0889879", ChannelId = 2, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("56adf1bb-cc83-431c-bc29-b14b22fe441a"), Name = "Deckenlampe", DeviceId = "OEQ0182339", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("09ac2db5-b118-4627-beb2-28c4be698232"), Name = "Fenster Bad hinten", DeviceId = "OEQ0222798", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("ede699f5-19e8-47e5-a2d4-7128d0ed20f6"), Name = "Fenster Kinderzimmer rechts", DeviceId = "OEQ0707418", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("c731424d-cbef-4533-994e-b3fe10028afa"), Name = "Fenster Kinderzimmer links", DeviceId = "OEQ0707459", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("0e56ebec-47ff-4382-8861-d3f18f660669"), Name = "Fenster Wohnzimmer rechts", DeviceId = "OEQ0707434", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("93b6618a-fd6d-4238-8e22-c43ccf8aef55"), Name = "Fenster Wohnzimmer links", DeviceId = "OEQ0707467", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("20b62533-23f2-4bfb-95d4-da3f780367bf"), Name = "Fenster Terrasse rechts", DeviceId = "OEQ0222677", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("8de0c218-1a5c-4ac4-b19a-34c2c26445af"), Name = "Fenster Terrasse links", DeviceId = "OEQ0226938", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("676229a9-5bf7-49a8-8a8b-62b937c3312e"), Name = "Fenster Schlafzimmer rechts", DeviceId = "OEQ0707446", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false },
				new HomeMaticState { Pk = Guid.Parse("77ac877f-6d5b-4e1a-8c78-df07332f09e9"), Name = "Fenster Schlafzimmer links", DeviceId = "OEQ0707415", ChannelId = 1, LastEdit = DateTimeOffset.Now, State = false }
			);
		}

		public DbSet<Value> Values { get; set; }
		public DbSet<MeasurePoint> MeasurePoints { get; set; }
		public DbSet<HomeMaticState> HomeMaticStates { get; set; }
	}
}
