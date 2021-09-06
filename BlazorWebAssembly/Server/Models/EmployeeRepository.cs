using BlazorWebAssembly.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace BlazorWebAssembly.Server.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDepartmentRepository departmentRepository;

        public EmployeeRepository(ApplicationDbContext dbContext, IDepartmentRepository departmentRepository)
        {
            this.dbContext = dbContext;
            this.departmentRepository = departmentRepository;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            if (employee.DepartmentId == 0)
            {
                //dbContext.Entry(employee.Department).State = EntityState.Unchanged;
                throw new Exception("Employee DepartmentId cannot be ZERO");
            }
            else
            {
                Department department = await departmentRepository.GetDepartment(employee.DepartmentId);
                if (department == null)
                {
                    throw new Exception($"Invalid employee departmentId = {employee.DepartmentId}");
                }
                employee.Department = department;
            }

            var result = await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteEmployee(int employeeid)
        {
            var result = await dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeid);
            if (result != null)
            {
                dbContext.Employees.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await dbContext.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await dbContext.Employees.Include(i => i.Department).FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<EmployeeDataResult> GetEmployees(int skip = 0, int take = 5, string orderBy = "EmployeeId")
        {
            EmployeeDataResult result = new EmployeeDataResult
            {
                Employees = dbContext.Employees.OrderBy(orderBy).Skip(skip).Take(take),
                Count = await dbContext.Employees.CountAsync()
            };

            return result;
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = dbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(g => g.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.Gender = employee.Gender;
                result.DateOfBirth = employee.DateOfBirth;
                if (employee.DepartmentId != 0)
                {
                    result.DepartmentId = employee.DepartmentId;
                }
                else if (employee.Department != null)
                {
                    result.DepartmentId = employee.Department.DepartmentId;
                }
                result.PhotoPath = employee.PhotoPath;

                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
