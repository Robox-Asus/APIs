using APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace APIs.Data
{
    public class HRPayrollDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Payroll> Payrolls => Set<Payroll>();
        public DbSet<Attendance> Attendances => Set<Attendance>();
        public DbSet<Leave> Leaves => Set<Leave>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
        }

    }
}
