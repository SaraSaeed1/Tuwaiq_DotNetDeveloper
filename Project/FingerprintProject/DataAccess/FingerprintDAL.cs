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
    public class FingerprintDAL
    {
        public string connectionString;

        public FingerprintDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Fingerprint"].ConnectionString;
        }
        public List<Fingerprint> GetAllFingerprint()
        {
            List<Fingerprint> UsersList = new List<Fingerprint>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT [Id],[UserId],[IsLoggedIn],[LoginTime],[LogoutTime],[Totalhours] FROM [FingerPrint]";

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsersList.Add(new Fingerprint
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            UserId = Convert.ToInt32(rdr[1]),
                            IsLoggedIn = Convert.ToInt32(rdr[2]),
                            LoginTime = rdr[3].ToString(),
                            LogoutTime = rdr[4].ToString(),
                            Totalhours = Convert.ToInt32(rdr[5])
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
        public Fingerprint GetFingerprint(int _id)
        {
            Fingerprint user = new Fingerprint();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [FingerPrint] where Id =" + _id;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        user.Id = Convert.ToInt32(rdr[0]);
                        user.UserId = Convert.ToInt32(rdr[1]);
                        user.IsLoggedIn = Convert.ToInt32(rdr[2]);
                        user.LoginTime = rdr[3].ToString();
                        user.LogoutTime = rdr[4].ToString();
                        user.Totalhours = Convert.ToInt32(rdr[5]);
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return user;
        }

        public void login(int _id){
            new UserDAL().GetUser(_id);
            using (SqlConnection con = new SqlConnection(connectionString))
            {            
                SqlCommand cmd = new SqlCommand();
                var loginTime = DateTime.Now;//1900-01-01 00:00:00.000
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [FingerPrint] where UserId =" + _id;
                con.Open(); 
                SqlDataReader rdr = cmd.ExecuteReader();
                if(rdr.HasRows){
                    rdr.Close(); // <- too easy to forget
                cmd.CommandText ="UPDATE FingerPrint SET IsLoggedIn=" + 1 + ",LoginTime='"+ loginTime+"',LogoutTime= ''"+ " WHERE UserId ="  + _id ;

                }else{
                    rdr.Close();
                    cmd.CommandText = "INSERT INTO FingerPrint(UserId,IsLoggedIn, LoginTime, LogoutTime,Totalhours) VALUES (" + _id + "," + 1 + ",'" + loginTime + "','',0)";
                }
                cmd.ExecuteReader();
            }
        }

        public void loguot(int _id)
        {
            new UserDAL().GetUser(_id);
            using (SqlConnection con = new SqlConnection(connectionString))
            {            
                SqlCommand cmd = new SqlCommand();
                var logoutTime = DateTime.Now;
                var loginTime = DateTime.Now;
                var totalhours = "Totalhours= DATEDIFF (HOUR, LoginTime, LogoutTime)";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [FingerPrint] where UserId =" + _id;
                con.Open(); 
                SqlDataReader rdr = cmd.ExecuteReader();
                if(rdr.HasRows){
                    rdr.Close(); // <- too easy to forget
                    cmd.CommandText ="UPDATE FingerPrint SET IsLoggedIn=" + 0 + ",LogoutTime='"+ logoutTime +"'WHERE UserId ="  + _id ;
                    rdr= cmd.ExecuteReader();
                    rdr.Close();
                }
                else
                {
                    cmd.CommandText = "INSERT INTO FingerPrint(UserId,IsLoggedIn, LoginTime, LogoutTime,Totalhours) VALUES (" + _id + "," + 0 + ",'" + loginTime + "','"+logoutTime+"',0)";
                    rdr= cmd.ExecuteReader();
                    rdr.Close();
                }
                    cmd.CommandText = "UPDATE FingerPrint SET " + totalhours ;
                    cmd.ExecuteReader();
                Console.WriteLine("##################    logout    ###################");
            }
        }
    }
}