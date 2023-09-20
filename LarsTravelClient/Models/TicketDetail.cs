using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	public class TicketDetail
	{
		public long Id { get; set; }
		public DateTime StartDay { get; set; }
		public DateTime EndDay { get; set; }
		public Decimal Price { get; set; }
		public string Description { get; set; }
		public Ticket Ticket { get; set; }
		public long MemberPackageId { get; set; }
		public MemberPackage MemberPackage { get; set; }
		public long HotelId { get; set; }
		public Hotel Hotel { get; set; }
	}
}
