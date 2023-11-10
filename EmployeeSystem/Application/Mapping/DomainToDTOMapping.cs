using AutoMapper;
using EmployeeSystem.Domain.DTOs;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Employee, EmployeeDTO>().
                ForMember(dest => dest.Name, m => m.MapFrom(orig => orig.name));
        }
    }
}
