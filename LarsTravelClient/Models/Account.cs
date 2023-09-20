using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsTravel.Models
{
	public class Account
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
