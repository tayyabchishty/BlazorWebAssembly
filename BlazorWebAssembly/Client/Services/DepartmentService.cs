using BlazorWebAssembly.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Client.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<Department> GetDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Department>>("/api/department");
        }
    }
}
