using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<EmployeeModel>> GetAllEmployees();
        Task<EmployeeModel> GetEmployeeDetails(int employeeId);
        Task<EmployeeModel> AddEmployee(EmployeeModel employee);
        Task UpdateEmployee(EmployeeModel employee);
        Task DeleteEmployee(int employeeId);
    }
}
