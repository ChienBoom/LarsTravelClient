using LarsTravel.Models;

namespace LarsTravelClient.ModelsDto
{
    public class EvaluateDto
    {
        public int NumberOfEvaluate { get; set; }
        public float MediumStar { get; set; }
        public Comment Comment { get; set; }
        public Tour Tour { get; set; }
    }
}
