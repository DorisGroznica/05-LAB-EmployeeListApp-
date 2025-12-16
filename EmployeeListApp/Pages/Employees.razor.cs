using EmployeeListApp.Data;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeListApp.Pages
{
    public partial class Employees
    {

        string id;
        string fullname;
        string department;
        decimal salary;

        private enum MODE { None, Add, EditDelete };
        MODE mode = MODE.None;

        List<Employee> employees;
        protected override async Task OnInitializedAsync()
        {
            await Load();
        }
        protected async Task Load()
        {
            employees = await employeesService.GetEmployeesAsync();
        }


        protected void Add()
        {
            ClearFields();
            mode = MODE.Add;
        }

        protected void ClearFields()
        {
            id = string.Empty;
            fullname = string.Empty;
            department = string.Empty;
            salary = 0;
        }


        protected async Task Insert()
        {
            Employee e = new Employee()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = fullname,
                Department = department,
                Salary = salary
            };
            await employeesService.InsertEmployeeAsync(e);
            ClearFields();
            await Load();
            mode = MODE.None;
        }
    }
}