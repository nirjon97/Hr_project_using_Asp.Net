using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dhaka_hr_project.Models
{
    public class Designation
    {
        [Key]
        public string DesigId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(150)]
        [DisplayName("Designation Name")]
        public string? DesigName { get; set; }
        [Required]
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
