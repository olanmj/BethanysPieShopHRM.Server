﻿using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Components
{
    public class AddEmployeeDialogBase : ComponentBase
    {
        public EmployeeModel Employee { get; set; } = new EmployeeModel { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }
        public bool ShowDialog { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Employee = new EmployeeModel { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
        }

        protected async Task HandleValidSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            await CloseEventCallback.InvokeAsync(true);
            ShowDialog = false;
            StateHasChanged();
        }
    }
}

