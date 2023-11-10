using EmployeeSystem.Domain.DTOs;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);
        Employee? Get(int id);
    }
}
