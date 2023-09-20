using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LarsTravel.Models
{
	public class MemberPackage
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<TicketDetail> TicketDetails { get; set; }
	}
}
