using System;
using System.ComponentModel.DataAnnotations;

namespace Home.Domain.Entities
{
	public class Value
	{
		public Value() { }

		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTimeOffset? Created { get; set; }
	}
}
