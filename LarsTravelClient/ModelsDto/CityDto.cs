using LarsTravel.Models;
using System.Collections.Generic;

namespace LarsTravelClient.ModelsDto
{
    public class CityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Pictures { get; set; }
        public List<Tour> Tours { get; set; }
    }
}
