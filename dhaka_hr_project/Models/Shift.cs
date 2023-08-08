using System.ComponentModel.DataAnnotations;

namespace dhaka_hr_project.Models
{
    public class Shift
    {
        [Key]
        [StringLength(40)]
        public string ShiftId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(50)]
        public string? ShiftName { get; set; }
        [Required]
        public DateTime ShiftIn { get; set; }
        [Required]
        public DateTime ShiftOut { get; set; }
        [Required]
        public DateTime ShiftLate { get; set; }

        [Required]
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
