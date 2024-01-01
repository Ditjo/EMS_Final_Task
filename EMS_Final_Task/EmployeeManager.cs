using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Final_Task
{
    public interface IEmployeeManager
    {
        public void AddEmployee(Employee employee);
        public Task<Employee> GetEmployeeById(int id);
        public Task<List<Employee>> GetEmployees();
    }
    public class EmployeeManager : IEmployeeManager
    {
        string connectionString = "Data Source=.;Initial Catalog=EMS_Final_Task;Integrated Security=True";
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connect = new(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("Usp_AddEmployee", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = employee.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = employee.LastName;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = employee.DateOfBirth;
                cmd.Parameters.Add("@Salary", SqlDbType.Decimal).Value = employee.Salary;

                cmd.ExecuteNonQuery();
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = new();
            using (SqlConnection connect = new(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("Usp_GetEmployeeById", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Employee_Id", SqlDbType.Int).Value = id;

                using (var reader = cmd.ExecuteReader())
                {
                    while (await reader.ReadAsync())
                    {
                        employee = new(
                            reader.GetInt32("Employee_Id"),
                            reader.GetString("FirstName"),
                            reader.GetString("LastName"),
                            reader.GetDateTime("DateOfBirth"),
                            reader.GetDecimal("Salary")
                        );
                    }
                }
            }
            return employee;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> list = new();
            using (SqlConnection connect = new(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new("Usp_GetEmployees", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader =  cmd.ExecuteReader())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new Employee(
                            reader.GetInt32("Employee_Id"),
                            reader.GetString("FirstName"),
                            reader.GetString("LastName"),
                            reader.GetDateTime("DateOfBirth"),
                            reader.GetDecimal("Salary")
                            )
                        );

                    }
                }
            }
            return list;
        }
    }
}
