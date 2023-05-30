using FingerprintProject.DataAccess;
using FingerprintProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintProject.Business
{
    public class FingerprintBLL
    {
        public void GetAllEmployee()
        {
            var employeeLogin=  new FingerprintDAL().GetAllFingerprint();
            Console.WriteLine("\n--------------------------------------------         Employee LogIn      --------------------------------------------");
            employeeLogin.ForEach(item =>
            {
                var employeeInfo = new UserBLL().GetUser(item.UserId);
                string log = item.IsLoggedIn == 1 ? "Yes " : "No";
                if (item.IsLoggedIn == 1)
                {
                    Console.WriteLine("Name:" + employeeInfo.Name + "  |  Logged in  :" + log + "  |  Login Time:" + item.LoginTime + "  |  Logout Time:" + item.LogoutTime + "  |  Total Time:" + item.Totalhours);
                }
            });
        }
        public Fingerprint GetEmployee(int _id)
        {
            return new FingerprintDAL().GetFingerprint(_id);
        }
        public void login(int _id){
            new FingerprintDAL().login(_id);
        }
        public void logout(int _id){
            new FingerprintDAL().loguot(_id);
        }
    }
}
