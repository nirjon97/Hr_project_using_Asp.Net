using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace dhaka_hr_project.Models
{
	public class Company
	{
		[Key]
		public string ComId { get; set; } = Guid.NewGuid().ToString();

		[Required]
		[StringLength(200)]
		[DisplayName("Company Name")]
		public string? ComName { get; set; }
		[Required]
		public double Basic { get; set; }
		[Required]
		[DisplayName("House Rent")]
		public double HRent { get; set; }
		[Required]
		public double Medical { get; set; }
		public bool IsInactive { get; set; } = true;
	}
}
