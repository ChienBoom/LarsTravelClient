using LarsTravel.Models;
using System.Collections.Generic;
using System;

namespace LarsTravelClient.ModelsDto
{
    public class UserDto: Account
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
