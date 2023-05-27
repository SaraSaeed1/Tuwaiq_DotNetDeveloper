using FingerprintProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintProject.Business
{
    public class CRUD : BaseRepository
    {
        public static readonly CRUD Instance = new CRUD();

        public void creteEmployee(string name,int categoryee)
        {
            var connection = GetConnection();
            connection.Open();
            var cmd = new SqlCommand("INSERT INTO [User] ([Name],[CategoryId]) VALUES (@Name,@CategoryId)", connection);
            cmd.Parameters.Add(new SqlParameter("Name", name));
            cmd.Parameters.Add(new SqlParameter("CategoryId", categoryee));
            //cmd.ExecuteNonQuery();
            cmd.ExecuteReader();
        }
    }
}