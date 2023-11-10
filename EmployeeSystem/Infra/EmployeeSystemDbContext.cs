using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmployeeSystem.Infra
{
    public class EmployeeSystemDbContext : DbContext
    {
        public EmployeeSystemDbContext(DbContextOptions<EmployeeSystemDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
