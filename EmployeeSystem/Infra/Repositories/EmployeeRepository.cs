using EmployeeSystem.Domain.DTOs;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra;
using EmployeeSystem.Infra.Repositories.Contracts;
using Microsoft.AspNetCore.Connections;

namespace EmployeeSystem.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeSystemDbContext _dbContext;
        public EmployeeRepository(EmployeeSystemDbContext employeeSystemDbContext)
        {
            _dbContext = employeeSystemDbContext;
        }
        public void Add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            if (pageNumber < 1 || pageQuantity < 1)
                return _dbContext.Employees.Select(employee => new EmployeeDTO
                {
                    Id = employee.id,
                    Name = employee.name,
                    Photo = employee.photo
                }).ToList();
            return _dbContext.Employees.Skip((pageNumber - 1) * pageQuantity).Take(pageQuantity).Select(employee => new EmployeeDTO
            {
                Id = employee.id,
                Name = employee.name,
                Photo = employee.photo
            }).ToList();
        }

        public Employee? Get(int id)
        {
            return _dbContext.Employees.Find(id);
        }
    }
}
