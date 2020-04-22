using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services 
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;

        public EmployeeDataService(HttpClient httpCLient)
        {
            _httpClient = httpCLient;
        }
        public async Task<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            var employeeJson =
                new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/employee", employeeJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<EmployeeModel>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }


        public async Task DeleteEmployee(int employeeId)
        {
            await _httpClient.DeleteAsync($"api/employee/{employeeId}");
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllEmployees()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<EmployeeModel>>
                (await _httpClient.GetStreamAsync($"api/employee"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<EmployeeModel> GetEmployeeDetails(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<EmployeeModel>
                (await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task UpdateEmployee(EmployeeModel employee)
        {
            var employeeJson =  new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/employee", employeeJson);
        }
    }
}
