using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintProject.Entity
{
    public class Fingerprint
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int IsLoggedIn { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
        public int Totalhours { get; set; }
    }
}
