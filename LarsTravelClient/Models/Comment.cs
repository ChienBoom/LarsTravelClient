using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	public class Comment
	{
		public long Id { get; set;}
		public string Content { get; set;}
		public DateTime DateOfComment { get; set;}
		public long UserId { get; set;}
		public User User { get; set;}
		public long EvaluateId { get; set;}
		public Evaluate Evaluate { get; set;}
	}
}
