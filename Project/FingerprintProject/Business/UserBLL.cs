using FingerprintProject.DataAccess;
using FingerprintProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintProject.Business
{
    public class UserBLL
    {
        public List<User> GetAllUser()
        {
            return new UserDAL().GetAllUser();
        }
        public User GetUser(int _id)
        {
            return new UserDAL().GetUser(_id);
        }

        public void CreateUser(string name, int category){
            new UserDAL().CreateUser(name,category);
        }
        public void updateUser(int _id, string name){
            new UserDAL().UpdateUaer(_id, name);
        }
    }

}
