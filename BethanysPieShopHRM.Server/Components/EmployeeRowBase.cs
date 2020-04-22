using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Components
{
    public class EmployeeRowBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }
    }
}
