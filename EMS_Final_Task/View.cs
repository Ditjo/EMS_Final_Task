using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Final_Task
{
    public class View
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to EMS");
            Console.WriteLine("Pick an option:");
            Console.WriteLine();
            Console.WriteLine("[1] Add New Employee");
            Console.WriteLine("[2] View Specific Employee Details");
            Console.WriteLine("[3] View All Employees");
            Console.WriteLine("[0] Quit Program");
        }
        //---------------------AddEmployee------------------------
        public void AddFirstName()
        {
            Console.Clear();
            Console.WriteLine("Please Input the Following Data:");
            Console.Write("Firstname: ");
        }
        public void AddLastName()
        {
            Console.Write("LastName: ");
        }
        public void AddDateOfBirth()
        {
            Console.Write("Date Of Birth (YYYY-MM-DD): ");
        }
        public void AddSalary()
        {
            Console.Write("Monthly Salary: ");
        }

        //----------------------GetEmployeeById--------------------------
        public void GetEmployeeById()
        {
            Console.Clear();
            Console.Write("Please Enter Id for Employee: ");
        }

        public void ShowEmployee(Employee employee)
        {
            Console.WriteLine($"ID:            {employee.Id}");
            Console.WriteLine($"Firstname:     {employee.FirstName}");
            Console.WriteLine($"Lastname:      {employee.LastName}");
            Console.WriteLine($"Age:           {employee.GetAge()}");
            Console.WriteLine($"Yearly Salary: {employee.CalculateSalary()} kr.");
        }

        //------------------------GetEmployees------------------------

        public void ShowAllEmployees(List<Employee> list)
        {
            Console.Clear();
            foreach (var employee in list)
            {
                Console.WriteLine($"ID: {employee.Id} Name: {employee.GetFullName()}");
            }
        }
    }
}
