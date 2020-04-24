using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Models
{
    public interface IBenefitRepository
    {
        IEnumerable<BenefitModel> GetForEmployee(int employeeId);
        void UpdateForEmployee(int employeeId, IEnumerable<BenefitModel> model);
    }
}
