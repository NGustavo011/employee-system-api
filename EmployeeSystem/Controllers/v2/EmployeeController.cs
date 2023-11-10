using AutoMapper;
using EmployeeSystem.Application.View;
using EmployeeSystem.Domain.DTOs;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Employee> Add([FromForm] EmployeeView employeeView)
        {
            string filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);

            Employee employee = new Employee(employeeView.Name, employeeView.Age, filePath);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public ActionResult DownloadPhoto(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            byte[] dataBytes = System.IO.File.ReadAllBytes(employee.photo);
            return File(dataBytes, "image/png");
        }

        [HttpGet]
        public ActionResult<List<EmployeeDTO>> Get(int pageNumber, int pageQuantity)
        {
            _logger.LogInformation("Retornando employees");
            List<EmployeeDTO> employees = _employeeRepository.Get(pageNumber, pageQuantity);
            return Ok(new List<EmployeeDTO>());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<EmployeeDTO> Search(int id)
        {
            Employee employees = _employeeRepository.Get(id)!;
            EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(employees);
            return Ok(employeeDTO);
        }
    }
}
