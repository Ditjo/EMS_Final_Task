using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Final_Task
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }

        public Employee()
        {

        }
        public Employee(int id, string firstName, string lastName, DateTime dateOfBirth, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Salary = salary;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        public int GetAge()
        {
            return (int)((DateTime.Now - DateOfBirth).TotalDays/365.242199);
        }
        public decimal CalculateSalary()
        {
            return Salary * 12;
        }
    }
}
