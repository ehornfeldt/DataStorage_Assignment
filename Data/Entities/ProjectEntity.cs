using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public int CustomerId { get; set; }
        //public CustomerEntity Customer { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string ProjectLeader { get; set; } = null!;

        public string Service { get; set; } = null!;

        public int Price { get; set; }

    }
}
