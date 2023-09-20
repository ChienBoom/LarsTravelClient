using LarsTravel.Models;
using System;

namespace LarsTravelClient.ModelsDto
{
    public class CommentDto
    {
        public string Content { get; set; }
        public DateTime DateOfComment { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long EvaluateId { get; set; }
        public Evaluate Evaluate { get; set; }
    }
}
