using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	public class Hotel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Description { get; set; }
		public List<TicketDetail> TicketDetails { get; set; }
	}
}
