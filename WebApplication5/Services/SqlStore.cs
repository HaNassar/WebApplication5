using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;
using System.Data.SqlClient;

namespace WebApplication5.Services
{
    public class SqlStore : IStore
    {
        private readonly string connectionString;
        public SqlStore()
        {
            this.connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanna\Documents\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30";
        }
        public SubmissionResponse SaveEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("insert into employee(Id , Name , CountryId) Values(@Id,@Name,@CountryId)", connection))
                {
                    cmd.Parameters.AddWithValue("@Id", employee.ID);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@CountryId", employee.CountryId);
                    connection.Open();
                    cmd.ExecuteNonQuery();   //ExecuteNonQuerry when excuting without return value
                    return new SubmissionResponse{Success = true};


                }

            }
        }
    }
}
