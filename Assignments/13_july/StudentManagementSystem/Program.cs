using System;

class Program
{
    static void Main(string[] args)
    {
        StudentManagement sm = new StudentManagement();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine(" STUDENT MANAGEMENT SYSTEM");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Student Management");
            Console.WriteLine("2. Course Management");
            Console.WriteLine("3. Register Course");
            Console.WriteLine("4. View Student Details");
            Console.WriteLine("5. Exit");
            Console.Write("Enter Choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                // --------------------------
                // Student Management Menu
                // --------------------------
                case 1:
                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine("----- STUDENT MANAGEMENT -----");
                        Console.WriteLine("1. Register Student");
                        Console.WriteLine("2. View All Students");
                        Console.WriteLine("3. Search Student");
                        Console.WriteLine("4. Back");
                        Console.Write("Enter Choice: ");

                        int studentChoice = Convert.ToInt32(Console.ReadLine());

                        switch (studentChoice)
                        {
                            case 1:
                                sm.RegisterStudent();
                                break;

                            case 2:
                                sm.ViewStudents();
                                break;

                            case 3:
                                sm.SearchStudent();
                                break;

                            case 4:
                                goto MainMenu;

                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }

                        Console.WriteLine("\nPress Enter...");
                        Console.ReadLine();
                    }

                // --------------------------
                // Course Management Menu
                // --------------------------
                case 2:
                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine("----- COURSE MANAGEMENT -----");
                        Console.WriteLine("1. Add Course");
                        Console.WriteLine("2. View Courses");
                        Console.WriteLine("3. Back");
                        Console.Write("Enter Choice: ");

                        int courseChoice = Convert.ToInt32(Console.ReadLine());

                        switch (courseChoice)
                        {
                            case 1:
                                sm.AddCourse();
                                break;

                            case 2:
                                sm.ViewCourses();
                                break;

                            case 3:
                                goto MainMenu;

                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }

                        Console.WriteLine("\nPress Enter...");
                        Console.ReadLine();
                    }

                // --------------------------
                // Register Course
                // --------------------------
                case 3:
                    sm.RegisterCourse();
                    Console.WriteLine("\nPress Enter...");
                    Console.ReadLine();
                    break;

                // --------------------------
                // View Student Details
                // --------------------------
                case 4:
                    sm.DisplayStudentDetails();
                    Console.WriteLine("\nPress Enter...");
                    Console.ReadLine();
                    break;

                // --------------------------
                // Exit
                // --------------------------
                case 5:
                    Console.WriteLine("Thank You!");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    Console.ReadLine();
                    break;
            }

        MainMenu:
            continue;
        }
    }
}