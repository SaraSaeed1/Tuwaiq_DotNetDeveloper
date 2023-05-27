using FingerprintProject.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintProject.DataAccess
{
    public class UserDAL
    {
        public string connectionString;

        public UserDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Fingerprint"].ConnectionString;
        }
        public List<User> GetAllUser()
        {
            List<User> UsersList = new List<User>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT [Id], [Name], [CategoryId] FROM [User]";

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsersList.Add(new User
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            Name = rdr[1].ToString(),
                            CategoryId = Convert.ToInt32(rdr[2])
                        });
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return UsersList;
        }

        public User GetUser(int _id)
        {
            User user = new User();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [User] where Id =" + _id;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        user.Id = Convert.ToInt32(rdr[0]);
                        user.Name = rdr[1].ToString();
                        user.CategoryId = Convert.ToInt32(rdr[2]);
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return user;
        }

        public void CreateUser(string name,int categoryee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [User] ([Name],[CategoryId]) VALUES (@Name,@CategoryId)";
                    cmd.Parameters.Add(new SqlParameter("Name", name));
                    cmd.Parameters.Add(new SqlParameter("CategoryId", categoryee));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            Console.WriteLine("User has been added");
        }

        public void UpdateUaer(int _id, string name){
            var user = GetUser(_id);
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE [User] SET [Name]= @Name  WHERE Id ="+user.Id;
                    cmd.Parameters.Add(new SqlParameter("Name", name));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            Console.WriteLine("User edit");
        }
    }
}
