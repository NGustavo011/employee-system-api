using EmployeeSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeSystem.Infra.Map
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.id);
            builder.Property(employee => employee.name).IsRequired().HasMaxLength(255);
            builder.Property(employee => employee.age).IsRequired();
            builder.Property(employee => employee.photo);
        }
    }
}
