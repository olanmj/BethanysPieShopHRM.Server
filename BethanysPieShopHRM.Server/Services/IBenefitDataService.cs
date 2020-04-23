using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{
    public interface IBenefitDataService
    {
        Task<IEnumerable<BenefitModel>> GetForEmployee(EmployeeModel employee);
        Task UpdateForEmployee(EmployeeModel employee, IEnumerable<BenefitModel> benefits);
    }
}
