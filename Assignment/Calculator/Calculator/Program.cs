using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation Cal = new Operation();
            Cal.performOperation();
            Cal.getResult();
        }
    }
}
