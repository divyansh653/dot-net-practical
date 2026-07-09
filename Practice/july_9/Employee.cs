using System;

class Employee
{
    private string empName;
    private double salary;

    public string EmpName
    {
        get { return empName; }
        set { empName = value; }
    }

    public double Salary
    {
        get { return salary; }
        set
        {
            if (value >= 100)
                salary = value;
        }
    }
}