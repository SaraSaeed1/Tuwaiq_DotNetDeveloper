using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Operation
    {
        private string num1;
        private string num2;
        private string operation;
        public int result;
        public Boolean output = false;

        public string getNum1()
        {return num1;}
        public void setNum1(string num1)
        {this.num1= num1;}
        public string getOperation()
        {return operation;}
        public void setOperation(string operation)
        {this.operation = operation;}
        public string getNum2()
        {return num2; }
        public void setNum2(string num2)
        {this.num2 = num2;}


        public void performOperation()
        {

            //get number 1 and convert to integar 
            Console.WriteLine("enter number 1/  ");
            setNum1(Console.ReadLine());
            var num1 = Convert.ToInt32(getNum1());

            //get operation from user 
            Console.WriteLine("enter operation/  ");
            setOperation(Console.ReadLine());

            //get number 2 and convert to integar 
            Console.WriteLine("enter number 2/  ");
            setNum2(Console.ReadLine());
            var num2 = Convert.ToInt32(getNum2());




            //operation
            if (getOperation().Equals("*"))
            {
                result = num1 * num2;
                output = true;
            }
            else if(getOperation().Equals("/"))
            {
                result = num1 / num2;
                output = true;
            }
            else if (getOperation().Equals("+"))
            {
                result = num1 + num2;
                output = true;
            }
            else if (getOperation().Equals("-"))
            {
                result = num1 - num2;
            }
            else
            {
                Console.WriteLine("###### operation not valid #######");
                //Console.WriteLine("###### try agein? press y #######");
                Console.Read();
            }

        }

        public void getResult()
        {
            Console.WriteLine(getNum1() + " " + getOperation() + " " + getNum2() + " = " + result);
            Console.Read();
        }

    }
}
