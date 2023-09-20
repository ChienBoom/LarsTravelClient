using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	public class Evaluate
	{
		public long Id { get; set; }
		public int NumberOfEvaluate { get; set; }
		public float MediumStar { get; set; }
		public Comment Comment { get; set; }
		public Tour Tour { get; set; }
	}
}
