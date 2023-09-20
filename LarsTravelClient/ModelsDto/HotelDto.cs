using LarsTravel.Models;
using System.Collections.Generic;

namespace LarsTravelClient.ModelsDto
{
    public class HotelDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public List<TicketDetail> TicketDetails { get; set; }
    }
}
