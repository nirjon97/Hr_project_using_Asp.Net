using Microsoft.EntityFrameworkCore;
using dhaka_hr_project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dhaka_hr_project.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		    public DbSet<Company> Companies { get; set; }
		    public DbSet<Department> Departments { get; set; }   
        	public DbSet<Designation> Designations { get; set; }
            public DbSet<Shift> Shifts { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Attendance> Attendances { get; set; }
            public DbSet<AttendanceSummary> AttendanceSummarys { get; set; }
            public DbSet<Salary> Salarys { get; set; }
        

      


    }

}
