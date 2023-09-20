using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	public class Ticket
	{
		public long Id { get; set; }
		public DateTime BookingDate { get; set; }
		public string Description { get; set; }
		public long TicketDetailId { get; set; }
		public TicketDetail TicketDetail { get; set; }
		public long TourId { get; set; }
		public Tour Tour { get; set; }
		public long UserId { get; set; }
		public User User { get; set; }	
	}
}
