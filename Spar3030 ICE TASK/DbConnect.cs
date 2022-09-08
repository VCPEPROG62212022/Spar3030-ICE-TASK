using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Linq;

namespace Spar3030_ICE_TASK
{
    internal class DbConnect:Connections
    {
        public readonly string connectionString = "Server=tcp:classdb.database.windows.net,1433;Initial Catalog=Student;Persist Security Info=False;User ID=adminadmin;Password=@Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public bool AddOrder(int[] Item, bool[] Packed)
        {
            throw new NotImplementedException();
        }

        public void AddUser(string Name, string Surname, string Address, 
            string Email, string PhoneNumber, string PasswordNULL)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "insert into Users values(@Name,@Surname" +
                        ",@Address,@Email,@PhoneNumber,@Password) ;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Name", Name);
                        command.Parameters.AddWithValue("Surname", Surname);
                        command.Parameters.AddWithValue("Address", Address);
                        command.Parameters.AddWithValue("Email", Email);
                        command.Parameters.AddWithValue("PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("Password", PasswordNULL);
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public bool CheckLogin(string Email, string Password)
        {
            int ID =0;
            try
            {
               using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT UserID FROM users where Email = @Email " +
                        "AND Password=@Password;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Email", Email);
                        command.Parameters.AddWithValue("Password", Password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ID= reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            if (ID ==0)
            {
                return false;
            }else
            {
                return true;
            }
        }

        public string[] GetCat()
        {
            throw new NotImplementedException();
        }

        public string[] GetOrderNo()
        {
            throw new NotImplementedException();
        }

        public string[] GetOrderStatus()
        {
            throw new NotImplementedException();
        }

        public Product[] GetProducts(string Cat)
        {
            throw new NotImplementedException();
        }
    }
}
