using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Xml.Linq;

namespace Spar3030_ICE_TASK
{
    internal class DbConnect : Connections
    {
        private static int UserID;
        public readonly string connectionString = "Server=tcp:classdb.database.windows.net,1433;Initial Catalog=spar;Persist Security Info=False;User ID=adminadmin;Password=@Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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
            int ID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT UserID FROM Users where Email = @Email " +
                        "AND Password=@Password;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Email", Email);
                        command.Parameters.AddWithValue("Password", Password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ID = reader.GetInt32(0);
                                UserID = ID;
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
                Console.WriteLine(e.ToString());
            }
            if (ID == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string[] GetCat()
        {
            String[] strings = new string[6];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SELECT DISTINCT - is to select the unique values in that column
                String sql = "SELECT DISTINCT ProductType FROM Product";
                SqlCommand cmd = new SqlCommand(sql, connection);

                SqlDataReader reader;
                try
                {
                    int x = 0;
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //string productsDetails = reader.GetString("ProductType");
                        strings[x] = reader["ProductType"].ToString();
                        x++;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error happened in the cmd " + e.ToString());
                }
                return strings;
            }
        }

        public string[] GetOrderNo()
        {
            throw new NotImplementedException();
        }

        public string[] GetOrderStatus()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts(string Cat)
        {
            List<Product> ArrProducts = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String sql = "SELECT * FROM Product WHERE ProductType ='" + Cat
                    + "'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader;
                try
                {
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    int x = 0;
                    while (reader.Read())
                    {//ProductName, ProductPrice
                        Product p = new Product();
                        p.ProductID = Convert.ToInt32(reader["ProductID"].ToString());
                        p.ProductPrice = Convert.ToDouble(reader["ProductPrice"].ToString());
                        p.ProductName = reader["ProductName"].ToString();
                        p.ProductType = reader["ProductType"].ToString();
                        ArrProducts.Add(p);
                        x++;

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error on adding products");
                }


            }
            return ArrProducts;
        }
    }
}

