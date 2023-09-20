using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsTravel.Models
{
	public class City
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Pictures { get; set; }
		public List<Tour> Tours { get; set; }
	}
}
