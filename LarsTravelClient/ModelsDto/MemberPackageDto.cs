using LarsTravel.Models;
using System.Collections.Generic;

namespace LarsTravelClient.ModelsDto
{
    public class MemberPackageDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TicketDetail> TicketDetails { get; set; }
    }
}
