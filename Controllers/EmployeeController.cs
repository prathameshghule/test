using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Dto;
using Project.Model;
using Project.Repository.Interface;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
      public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository=employeeRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequestDto request)
        {
            var employee = new Employee
            {
                Name = request.Name,
                Email = request.Email,
                MobileNumber = request.MobileNumber,
                Gender = request.Gender,
                Address = request.Address,
                Qualification = request.Qualification,
                Designation = request.Designation,
               
            };
            await employeeRepository.CreateAsync(employee);

            var response = new EmployeeDto
            {
                EmpId = employee.EmpId,
                Name = employee.Name,
                Email = employee.Email,
                MobileNumber = employee.MobileNumber,
                Gender = employee.Gender,
                Address = employee.Address,
                Qualification = employee.Qualification,
                Designation = employee.Designation ,
                
            };
            return Ok(response);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employees = await employeeRepository.GetAllAsync();

           
            var response = new List<EmployeeDto>();
            foreach (var employee in employees)
            {
                response.Add(new EmployeeDto
                {
                    EmpId = employee.EmpId,
                    Name = employee.Name,
                    Email = employee.Email,
                    MobileNumber = employee.MobileNumber,
                    Gender = employee.Gender,
                    Address = employee.Address,
                    Qualification = employee.Qualification,
                    Designation = employee.Designation,
                });
            }
            return Ok(response);

        }
        [HttpGet]
        [Route("{EmpId:Guid}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid EmpId)
        {
            var existingEmployee= await employeeRepository.GetById(EmpId);
            if (existingEmployee is null)
            {
                return NotFound();
            }

            var response = new EmployeeDto
            {

                EmpId = existingEmployee.EmpId,
                Name = existingEmployee.Name,
                Email = existingEmployee.Email,
                MobileNumber = existingEmployee.MobileNumber,
                Gender = existingEmployee.Gender,
                Address = existingEmployee.Address,
                Qualification = existingEmployee.Qualification,
                Designation = existingEmployee.Designation,

            };
            return Ok(response);
        }


        [HttpPut]
        [Route("{EmpId:Guid}")]
        public async Task<IActionResult> EditEmployee([FromRoute] Guid EmpId, EmployeeDto request)
        {
            var employee = new Employee
            {
                EmpId = EmpId,
                Name = request.Name,
                Email = request.Email,
                MobileNumber = request.MobileNumber,
                Gender = request.Gender,
                Address = request.Address,
                Qualification = request.Qualification,
                Designation = request.Designation,
            };

            employee = await employeeRepository.UpdateAsync(employee);

            if (employee == null)
            {
                return NotFound();
            }
            var response = new EmployeeDto
            {

                EmpId = employee.EmpId,
                Name = employee.Name,
                Email = employee.Email,
                MobileNumber = employee.MobileNumber,
                Gender = employee.Gender,
                Address = employee.Address,
                Qualification = employee.Qualification,
                Designation = employee.Designation,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{EmpId:Guid}")]

        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid EmpId)
        {
            var Employee = await employeeRepository.DeleteAsync(EmpId);
            if (Employee is null)
            {
                return NotFound();
            }
            var response = new EmployeeDto
            {
                EmpId = Employee.EmpId,
                Name = Employee.Name,
                Email = Employee.Email,
                MobileNumber = Employee.MobileNumber,
                Gender = Employee.Gender,
                Address = Employee.Address,
                Qualification = Employee.Qualification,
                Designation = Employee.Designation,
            };
            return Ok(response);

        }

    }
}
