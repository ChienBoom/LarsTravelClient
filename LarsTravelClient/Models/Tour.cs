using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	public class Tour
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Description { get; set; }
		public string Pictures { get; set; }
		public long CityId { get; set; }
		public City City { get; set; }
		public long EvaluateId { get; set; }
		public Evaluate Evaluate { get; set; }
		public List<Ticket> Tickets { get; set; }
	}
}
