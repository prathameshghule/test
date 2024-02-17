using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Model;
using Project.Repository.Interface;

namespace Project.Repository.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ProjectDbContext dbContext;
        public EmployeeRepository(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee); 
            await dbContext.SaveChangesAsync();

            return employee;

        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }
        public async Task<Employee?> GetById(Guid EmpId)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == EmpId);
        }

        public async Task<Employee?> UpdateAsync(Employee employee)
        {

            var existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == employee.EmpId);
            if (existingEmployee != null)
            {
                dbContext.Entry(existingEmployee).CurrentValues.SetValues(employee);
                await dbContext.SaveChangesAsync();
                return employee;
            }
            return null;
        }
        public async Task<Employee?> DeleteAsync(Guid EmpId)
        {
            var existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == EmpId);
            if (existingEmployee is null)
            {
                return null;
            }
            dbContext.Employees.Remove(existingEmployee);
            await dbContext.SaveChangesAsync();
            return existingEmployee;
        }
    }
}
