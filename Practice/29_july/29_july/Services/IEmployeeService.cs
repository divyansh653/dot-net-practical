using _29_july.Models;

namespace _29_july.Services
{
    public interface IEmployeeService
    {
        List<Employee> getEmployees();

        Employee? getEmployee(int deptid);

        Employee? getEmployeeName(string Name);

        Employee addEmployee(Employee employee);
    }
}