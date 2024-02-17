using Microsoft.EntityFrameworkCore;
using Project.Model;

namespace Project.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetById(Guid EmpId);
        Task<Employee> UpdateAsync(Employee employee);
        Task<Employee> DeleteAsync(Guid EmpId);
    }
}
