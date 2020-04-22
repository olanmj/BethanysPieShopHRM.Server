using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Pages
{
    public class EmployeeEditBase : ComponentBase
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        [Inject]
        public ICountryDataService CountryDataService { get; set; }
        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        public string CountryId = string.Empty;
        public string JobCategoryId = string.Empty;

        public string StatusClass = string.Empty;

        public string Message { get; private set; }
        public bool Saved { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Saved = false;
           // Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();
            
            int.TryParse(EmployeeId, out var employeeId);
            if (employeeId == 0)  // No Id, new employee being created
            {
                // Add default 
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now };
            } else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }
            CountryId = Employee.CountryId.ToString();
            JobCategoryId = Employee.JobCategoryId.ToString();
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);
            StatusClass = "alert-success";
            Message = "Employee successfully deleted";
            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }

        protected async Task HandleValidSubmit()
        {
            Employee.CountryId = int.Parse(CountryId);
            Employee.JobCategoryId = int.Parse(JobCategoryId);
            if (Employee.EmployeeId == 0) //new
            {
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }
    }
}
