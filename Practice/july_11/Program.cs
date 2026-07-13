using System;
using System.Collections.Generic;




        Genericseg<int> n = new Genericseg<int>();
        n.Print(100);

        Genericseg<string> n1 = new Genericseg<string>();
        n1.Print("Mamta");

        Genericseg<double> n2 = new Genericseg<double>();
        n2.Print(100.25);

    // Declare a string in all caps
        string empName = "DIVYANSH";
        // Call custom extension method ProperCase() to convert "RAHUL" -> "Rahul"
        Console.WriteLine(empName.ProperCase()); //Rahul

        // Declare a string in all lowercase
        string empName1 = "mamta";
        // Call custom extension method ProperCase() to convert "mamta" -> "Mamta"
        Console.WriteLine(empName1.ProperCase()); //Mamta

        // Create a generic List that will only hold Employee objects
        List<Employee> employees = new List<Employee>();
        // Create a generic List that will only hold Manager objects
        List<Manager> managers = new List<Manager>();




class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();
        List<Manager> managers = new List<Manager>();

        while (true)
        {
            Console.WriteLine("welcome to Emp System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Manager");
            Console.WriteLine("3. view Employee");
            Console.WriteLine("4. view manager");
            Console.WriteLine("5. Search Employee by id");
            Console.WriteLine("6. Exit");

            Console.WriteLine("ENTER CHOICE 1-6");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Id: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        if (IdExists(employees, managers, id))
                        {
                            Console.WriteLine("Employee id already exists");
                            break;
                        }

                        Console.Write("enter name: ");
                        string name = Console.ReadLine()!;
                        Console.Write("enter salary: ");
                        double salary = Convert.ToDouble(Console.ReadLine());

                        Employee employee = new Employee(id, name, salary);
                        employees.Add(employee);
                        Console.WriteLine("employee added successfully");
                        break;

                    case 2:
                        Console.Write("Enter Manager Id: ");
                        int mid = Convert.ToInt32(Console.ReadLine());

                        if (IdExists(employees, managers, mid))
                        {
                            Console.WriteLine("Manager id already exists");
                            break;
                        }

                        Console.Write("Enter Name: ");
                        string mname = Console.ReadLine()!;

                        Console.Write("Enter Salary: ");
                        double msalary = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Department: ");
                        string mdept = Console.ReadLine()!;

                        Console.Write("Enter Bonus: ");
                        double mbonus = Convert.ToDouble(Console.ReadLine());

                        Manager manager = new Manager(mid, mname, msalary, mdept, mbonus);
                        managers.Add(manager);
                        Console.WriteLine("Manager added successfully.");
                        break;

                    case 3:
                        if (employees.Count == 0)
                        {
                            Console.WriteLine("No Employees in System.");
                        }
                        else
                        {
                            foreach (Employee emp in employees)
                            {
                                emp.Display();
                            }
                        }
                        break;

                    case 4:
                        if (managers.Count == 0)
                        {
                            Console.WriteLine("No managers in System.");
                        }
                        else
                        {
                            foreach (Manager m in managers)
                            {
                                m.DisplayManager();
                            }
                        }
                        break;

                    case 5:
                        Console.Write("Enter Id to search: ");
                        int searchId = Convert.ToInt32(Console.ReadLine());

                        bool found = false;

                        foreach (Employee emp in employees)
                        {
                            if (emp.Id == searchId)
                            {
                                emp.Display();
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            foreach (Manager m in managers)
                            {
                                if (m.Id == searchId)
                                {
                                    m.DisplayManager();
                                    found = true;
                                    break;
                                }
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Thank You!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice, please select 1-6.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("please enter number only ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    static bool IdExists(List<Employee> employees, List<Manager> managers, int id)
    {
        foreach (Employee emp in employees)
        {
            if (emp.Id == id) return true;
        }
        foreach (Manager m in managers)
        {
            if (m.Id == id) return true;
        }
        return false;
    }
}