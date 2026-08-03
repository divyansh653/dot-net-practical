using System;

public class Course
{
    public string CourseId { get; set; }
    public string CourseName { get; set; }
    public int Credits { get; set; }

    public void DisplayCourse()
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Course ID   : " + CourseId);
        Console.WriteLine("Course Name : " + CourseName);
        Console.WriteLine("Credits     : " + Credits);
    }
}