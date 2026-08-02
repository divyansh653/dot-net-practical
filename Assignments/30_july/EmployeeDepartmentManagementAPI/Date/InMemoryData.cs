using EmployeeDepartmentManagementAPI.Models;

namespace EmployeeDepartmentManagementAPI.Data
{
    public static class InMemoryData
    {
        public static List<Department> Departments =
            new List<Department>()
            {
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "HR",
                    DepartmentCode = "HR01",
                    Status = "Active"
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "IT",
                    DepartmentCode = "IT01",
                    Status = "Active"
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Finance",
                    DepartmentCode = "FIN01",
                    Status = "Inactive"
                }
            };

        public static List<Employee> Employees =
            new List<Employee>()
            {
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Divyansh",
                    LastName = "Mate",
                    Email = "divyansh@gmail.com",
                    MobileNumber = "9876543210",
                    DateOfBirth = new DateTime(2007, 1, 1),
                    Gender = "Male",
                    Salary = 30000,
                    DateOfJoining = new DateTime(2026, 1, 1),
                    DepartmentId = 2,
                    Designation = "Software Developer",
                    EmploymentStatus = "Active"
                }
            };
    }
}