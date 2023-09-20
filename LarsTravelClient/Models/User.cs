using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	public class User: Account
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Sex { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public List<Comment> Comments { get; set; }
		public List<Ticket> Tickets { get; set; }
	}
}
