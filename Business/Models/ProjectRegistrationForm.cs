namespace Business.Models
{
    public class ProjectRegistrationForm
    {
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; } = null!;
        public string ProjectLeader { get; set; } = null!;
        public string Service { get; set; } = null!;
        public int Price { get; set; }
    }
}
