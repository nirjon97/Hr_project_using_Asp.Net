using dhaka_hr_project.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dhaka_hr_project.Models
{
	public class Department
	{
		[Key]
		public string DeptId { get; set; } = Guid.NewGuid().ToString();
		[Required]
		[StringLength(150)]
        [DisplayName("Department Name")]
        public string? DeptName { get; set; }
		[Required]
		public string? CompanyId { get; set; }
		public Company? Company { get; set; }
	}
}
