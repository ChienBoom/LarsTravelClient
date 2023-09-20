using LarsTravel.Models;
using System.Collections.Generic;

namespace LarsTravelClient.ModelsDto
{
    public class TourDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Pictures { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
        public long EvaluateId { get; set; }
        public Evaluate Evaluate { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
