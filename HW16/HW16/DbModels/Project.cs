using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW16.DbModels
{
    public class Project
    {
        public Project()
        {
            StartedDate = DateTime.Now;
        }
        public int ProjectId { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [Required]
        public int ClientId { get; set; }

        public DateTime StartedDate { get; set; }
    }
}
