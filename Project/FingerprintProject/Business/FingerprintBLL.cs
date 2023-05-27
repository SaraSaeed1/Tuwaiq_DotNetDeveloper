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
        public List<Fingerprint> GetAllEmployee()
        {
            return new FingerprintDAL().GetAllFingerprint();
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
