using _29_july.Services;
using _29_july.Models;

namespace _29_july.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee
            {
                Id = 101,
                Name = "Divyansh",
                PhoneN = 9876543210,
                Email = "divyansh@gmail.com",
                DeptId = 1
            },
            new Employee
            {
                Id = 102,
                Name = "Rahul",
                PhoneN = 9876543211,
                Email = "rahul@gmail.com",
                DeptId = 2

            },  new Employee
            {
                Id = 103,
                Name = "Divya",
                PhoneN = 9776533532,
                Email = "divya@gmail.com",
                DeptId = 3

            },  new Employee
            {
                Id = 104,
                Name = "Aditya",
                PhoneN = 8676543210,
                Email = "aditya@gmail.com",
                DeptId = 4
            }
        };

        public List<Employee> getEmployees()
        {
            return employees;
        }

        public Employee? getEmployee(int deptid)
        {
            return employees.FirstOrDefault(e => e.DeptId == deptid);
        }

        public Employee? getEmployeeName(string Name)
        {
            return employees.FirstOrDefault(e => e.Name == Name);
        }

        public Employee addEmployee(Employee employee)
        {
            employees.Add(employee);
            return employee;
        }
    }
}