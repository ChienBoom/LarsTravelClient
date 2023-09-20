using LarsTravel.Models;
using System;

namespace LarsTravelClient.ModelsDto
{
    public class TicketDto
    {
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
