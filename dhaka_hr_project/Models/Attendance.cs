using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace dhaka_hr_project.Models
{
    public class Attendance
    {
        [Key]
        public string AttId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [DisplayName("Date")]
        public DateTime dtDate { get; set; } = DateTime.Now;
        [Required]
        [StringLength(50)]
        public string? AttStatus { get; set; }
        [Required]
        public DateTime InTime { get; set; }
        [Required]
        public DateTime OutTime { get; set; }
        [Required]
        [DisplayName("Company")]
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
        [Required]
        [DisplayName("Employee")]
        public string? EmpId { get; set; }
        public Employee? Emp { get; set; }

    }
}
