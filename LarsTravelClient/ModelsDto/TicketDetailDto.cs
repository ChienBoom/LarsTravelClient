using LarsTravel.Models;
using System;

namespace LarsTravelClient.ModelsDto
{
    public class TicketDetailDto
    {
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
