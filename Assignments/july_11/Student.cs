using System;
using System.Collections.Generic;

public abstract class Student
{
    // Properties
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string Department { get; set; }

    // List to store enrolled courses
    public List<Course> EnrolledCourses { get; set; } = new List<Course>();

    // Display Student Information
    public virtual void DisplayDetails()
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Student ID   : " + StudentId);
        Console.WriteLine("Student Name : " + StudentName);
        Console.WriteLine("Department   : " + Department);
    }

    // Calculate Fee (Abstract Method)
    public abstract double CalculateFee();
}