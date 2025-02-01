using EmployeeManagement.Data;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories;

public class EmployeeRespository:IEmployeeRepository
{
    private readonly AppDbContext _context;
    
    public EmployeeRespository(AppDbContext context)
    {
        
    }
    public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Employee> GetEmployeeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeAsync(int id)
    {
        throw new NotImplementedException();
    }
}