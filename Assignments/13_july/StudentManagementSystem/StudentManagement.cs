using System;
using System.Collections.Generic;
using System.Linq;

public class StudentManagement
{
    // List to store students
    List<Student> students = new List<Student>();

    // List to store courses
    List<Course> courses = new List<Course>();

    // ==========================
    // Register Student
    // ==========================
    public void RegisterStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        Console.WriteLine("Student Type");
        Console.WriteLine("1. Regular");
        Console.WriteLine("2. Scholarship");
        Console.WriteLine("3. Part-Time");
        Console.Write("Enter Choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        Student student;

        if (choice == 1)
            student = new RegularStudent();
        else if (choice == 2)
            student = new ScholarshipStudent();
        else
            student = new PartTimeStudent();

        student.StudentId = id;
        student.StudentName = name;
        student.Department = dept;

        students.Add(student);

        Console.WriteLine("Student Registered Successfully.");
    }

    // ==========================
    // View Students
    // ==========================
    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No Students Found.");
            return;
        }

        foreach (Student s in students)
        {
            s.DisplayDetails();
        }
    }

    // ==========================
    // Search Student
    // ==========================
    public void SearchStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Student student = students.Find(s => s.StudentId == id);

        if (student != null)
        {
            student.DisplayDetails();
        }
        else
        {
            Console.WriteLine("Student Not Found.");
        }
    }

    // ==========================
    // Add Course
    // ==========================
    public void AddCourse()
    {
        Course course = new Course();

        Console.Write("Enter Course ID: ");
        course.CourseId = Console.ReadLine();

        Console.Write("Enter Course Name: ");
        course.CourseName = Console.ReadLine();

        Console.Write("Enter Credits: ");
        course.Credits = Convert.ToInt32(Console.ReadLine());

        courses.Add(course);

        Console.WriteLine("Course Added Successfully.");
    }

    // ==========================
    // Display Courses
    // ==========================
    public void ViewCourses()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("No Courses Available.");
            return;
        }

        foreach (Course c in courses)
        {
            c.DisplayCourse();
        }
    }

    // ==========================
    // Register Course
    // ==========================
    public void RegisterCourse()
    {
        Console.Write("Enter Student ID: ");
        int studentId = Convert.ToInt32(Console.ReadLine());

        Student student = students.Find(s => s.StudentId == studentId);

        if (student == null)
        {
            Console.WriteLine("Student Not Found.");
            return;
        }

        Console.Write("Enter Course ID: ");
        string courseId = Console.ReadLine();

        Course course = courses.Find(c => c.CourseId == courseId);

        if (course == null)
        {
            Console.WriteLine("Course Not Found.");
            return;
        }

        // Prevent Duplicate Course Registration
        if (student.EnrolledCourses.Any(c => c.CourseId == courseId))
        {
            Console.WriteLine("Course Already Registered.");
            return;
        }

        // Maximum 5 Courses
        if (student.EnrolledCourses.Count >= 5)
        {
            Console.WriteLine("Maximum Course Limit Reached.");
            return;
        }

        student.EnrolledCourses.Add(course);

        Console.WriteLine("Course Registered Successfully.");
    }

    // ==========================
    // Display Student Details
    // ==========================
    public void DisplayStudentDetails()
    {
        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Student student = students.Find(s => s.StudentId == id);

        if (student == null)
        {
            Console.WriteLine("Student Not Found.");
            return;
        }

        student.DisplayDetails();

        Console.WriteLine("\nEnrolled Courses");

        int totalCredits = 0;

        foreach (Course c in student.EnrolledCourses)
        {
            Console.WriteLine(c.CourseName + " (" + c.Credits + " Credits)");
            totalCredits += c.Credits;
        }

        Console.WriteLine("---------------------------");
        Console.WriteLine("Total Credits : " + totalCredits);
        Console.WriteLine("Total Fee     : " + student.CalculateFee());
    }
}