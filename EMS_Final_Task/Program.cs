
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace EMS_Final_Task.Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunProgram();
            Environment.Exit(0);
        }
        public async static void RunProgram()
        {
            EmployeeManager manager = new();
            View view = new View();
            Employee employee;
            bool exit = true;   
            while (exit)
            {
                view.Menu();

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        employee = new();

                        view.AddFirstName();
                        employee.FirstName = Console.ReadLine();
                        view.AddLastName();
                        employee.LastName = Console.ReadLine();
                        view.AddDateOfBirth();
                        employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                        view.AddSalary();
                        employee.Salary = Convert.ToDecimal(Console.ReadLine());

                        manager.AddEmployee(employee);
                        break;

                    case ConsoleKey.D2:
                        view.GetEmployeeById();
                        int Id = Convert.ToInt32(Console.ReadLine());
                        //view.ShowEmployee(manager.GetEmployeeById(Id))
                        employee = await manager.GetEmployeeById(Id);
                        view.ShowEmployee(employee);
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D3:
                        List<Employee> list = await manager.GetEmployees();
                        view.ShowAllEmployees(list);
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D0:
                        exit = false;
                        break;
                    default:
                        break;

                }
            }
        }
    }
}
