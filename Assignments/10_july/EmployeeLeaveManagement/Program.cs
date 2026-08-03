using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Task 1 : Create Employee List
   
        List<Employee> employees = new List<Employee>();

        PermanentEmployee emp1 = new PermanentEmployee
        {
            EmployeeId = 101,
            Name = "Divyansh",
            Department = "HR"
        };
        emp1.SetLeaveBalance();

        ContractEmployee emp2 = new ContractEmployee
        {
            EmployeeId = 102,
            Name = "Saloni",
            Department = "IT"
        };
        emp2.SetLeaveBalance();

        PermanentEmployee emp3 = new PermanentEmployee
        {
            EmployeeId = 103,
            Name = "Aditya",
            Department = "Sales"
        };
        emp3.SetLeaveBalance();

        ContractEmployee emp4 = new ContractEmployee
        {
            EmployeeId = 104,
            Name = "Kartik",
            Department = "Finance"
        };
        emp4.SetLeaveBalance();

        employees.Add(emp1);
        employees.Add(emp2);
        employees.Add(emp3);
        employees.Add(emp4);

        // Task 2 : Display Employees
       
        Console.WriteLine("\nALL EMPLOYEES\n");

        foreach (Employee emp in employees)
        {
            emp.DisplayDetails();
        }

        // Task 3 : Create Leave List
        
        List<LeaveRequest> leaveRequests = new List<LeaveRequest>();

        leaveRequests.Add(new LeaveRequest
        {
            LeaveId = 1,
            EmployeeId = 101,
            NumberOfDays = 2,
            Reason = "Fever"
        });

        leaveRequests.Add(new LeaveRequest
        {
            LeaveId = 2,
            EmployeeId = 103,
            NumberOfDays = 5,
            Reason = "Vacation"
        });

        leaveRequests.Add(new LeaveRequest
        {
            LeaveId = 3,
            EmployeeId = 104,
            NumberOfDays = 1,
            Reason = "Personal Work"
        });

        // Task 4 : Display Leave Requests
        
        Console.WriteLine("\nLEAVE REQUESTS\n");

        foreach (LeaveRequest leave in leaveRequests)
        {
            leave.DisplayLeave();
        }

        // Task 5 : Display Permanent Employees
    
        Console.WriteLine("\nPERMANENT EMPLOYEES\n");

        foreach (Employee emp in employees)
        {
            if (emp is PermanentEmployee)
            {
                emp.DisplayDetails();
            }
        }

        // Task 6 : Find Employee ID 103
        
        Console.WriteLine("\nSEARCH EMPLOYEE (ID = 103)\n");

        foreach (Employee emp in employees)
        {
            if (emp.EmployeeId == 103)
            {
                emp.DisplayDetails();
            }
        }

        // Task 7 : Total Employees
        
        Console.WriteLine("Total Employees : " + employees.Count);

        // Task 8 : Total Leave Requests

        Console.WriteLine("Total Leave Requests : " + leaveRequests.Count);
    }
}