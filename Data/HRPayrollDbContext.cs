using APIs.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIs.Data
{
    public class HRPayrollDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Payroll> Payrolls => Set<Payroll>();
        public DbSet<Attendance> Attendances => Set<Attendance>();
        public DbSet<Leave> Leaves => Set<Leave>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // this need to add when adding Asp.Net.Identity
            modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
        }

    }
}
