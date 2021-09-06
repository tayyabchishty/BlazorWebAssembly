using BlazorWebAssembly.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Server.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext dbcontext;

        public DepartmentRepository(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            return await dbcontext.Departments.FirstOrDefaultAsync(e => e.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await dbcontext.Departments.ToListAsync();
        }
    }
}
