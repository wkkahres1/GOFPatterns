using System;
using System.Collections.Generic;

/// <summary>
/// This code demonstrates the composite pattern for an application where 
/// any employee can see their own performance record. The supervisor can 
/// see their own and their subordinate’s performance record
/// </summary>
namespace Composite_WK
{
    //'IComponent' interface
    public interface IEmployee
    {
        int EmployeeID { get; set; }
        string Name { get; set; }
        int Rating { get; set; }
        void PerformanceSummary();
    }
    //'Leaf' class - will be leaf node in tree structure
    public class Employee : IEmployee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public void PerformanceSummary()
        {
            Console.WriteLine("\nPerformance summary of employee: " +
                              $"{Name} is {Rating} out of 5");
        }
    }
    //'Composite' class - will be branch node in tree structure
    public class Supervisor : IEmployee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public List<IEmployee> ListSubordinates = new List<IEmployee>();

        public void PerformanceSummary()
        {
            Console.WriteLine("\nPerformance summary of supervisor: " +
                              $"{Name} is {Rating} out of 5");
        }

        public void AddSubordinate(IEmployee employee)
        {
            ListSubordinates.Add(employee);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee Ricky = new Employee { EmployeeID = 1, Name = "Ricky", Rating = 3 };
            Employee Mike = new Employee { EmployeeID = 2, Name = "Mike", Rating = 4 };
            Employee Maryann = new Employee { EmployeeID = 3, Name = "Maryann", Rating = 5 };
            Employee Ginger = new Employee { EmployeeID = 4, Name = "Ginger", Rating = 3 };
            Employee Olive = new Employee { EmployeeID = 5, Name = "Olive", Rating = 4 };
            Employee Candy = new Employee { EmployeeID = 6, Name = "Candy", Rating = 5 };
            Supervisor Walter = new Supervisor { EmployeeID = 7, Name = "Walter", Rating = 5 };
            Supervisor Marida = new Supervisor { EmployeeID = 8, Name = "Marida", Rating = 5 };

            Walter.AddSubordinate(Ricky);
            Walter.AddSubordinate(Mike);
            Walter.AddSubordinate(Maryann);

            Marida.AddSubordinate(Ginger);
            Marida.AddSubordinate(Olive);
            Marida.AddSubordinate(Candy);

            Console.WriteLine("\n---Employee can see their performance " +
                             "Summary ------");

            Ricky.PerformanceSummary();

            Console.WriteLine("\n--Supervisor can also see their " +
                             "subordinates performance summary ----");

            Walter.PerformanceSummary();

            Console.WriteLine("\nSubordinate Performance Record: ");
            foreach (Employee employee in Walter.ListSubordinates)
            {
                    employee.PerformanceSummary();
            }
        }
    }
}