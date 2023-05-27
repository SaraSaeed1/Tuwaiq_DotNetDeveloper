using FingerprintProject.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintProject
{
    public class BaseRepository
    {
        private readonly string connectString;
        protected BaseRepository()
        {
            connectString = ConfigurationManager.ConnectionStrings["Fingerprint"].ConnectionString;
        }
        protected SqlConnection GetConnection()
        {
            var Conection = new SqlConnection(connectString);
            return Conection;
        }

        public List<User> ReadUsersEntity(SqlDataReader rdr)
        {
            var listUsers = new List<User>();
            while (rdr.Read())
            {
                var user = new User();
                user.Id = Convert.ToInt32(rdr[0]);
                user.Name = rdr[1].ToString();
                user.CategoryId = Convert.ToInt32(rdr[2]);
                listUsers.Add(user);
            }
            return listUsers;
        }
        public List<Fingerprint> ReadFingerPrintEntity(SqlDataReader rdr)
        {
            var listUsers = new List<Fingerprint>();
            while (rdr.Read())
            {
                var user = new Fingerprint();
                user.Id = Convert.ToInt32(rdr[0]);
                user.UserId = Convert.ToInt32(rdr[1]);
                user.IsLoggedIn = Convert.ToInt32(rdr[2]);
                user.LoginTime = rdr[3].ToString();
                user.LogoutTime = rdr[4].ToString();
                user.Totalhours = Convert.ToInt32(rdr[2]);
                listUsers.Add(user);
            }
            return listUsers;
        }

        public User GetUserFromEntity(SqlDataReader rdr)
        {
            var user = new User();
            if (rdr.Read())
            {
                user.Id = Convert.ToInt32(rdr[0]);
                user.Name = rdr[1].ToString();
                user.CategoryId = Convert.ToInt32(rdr[2]);
            }
            return user;
        }
    }
}