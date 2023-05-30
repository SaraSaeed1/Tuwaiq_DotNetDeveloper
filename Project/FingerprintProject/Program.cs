using FingerprintProject.Business;
using FingerprintProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintProject
{
    public class choices
    {
        public int start()
        {
            Console.WriteLine("\nEnter the number from the list");
            Console.WriteLine("1-Admin");
            Console.WriteLine("2-Employee");
            int input = int.Parse(Console.ReadLine());
            return input;
        }
        public void helloUser(User user,string message)
        {
            Console.WriteLine("\n#########   Hello " + user.Name + "   ###########");
            Console.WriteLine("------------"+ message+ "--------------\n");//This message shows the user whether he is logged in or not
        }
        public int adminMenu()
        {
            Console.WriteLine("\n -------Choices from the list-------");
            Console.WriteLine("1-Login");
            Console.WriteLine("2-List of User");
            Console.WriteLine("3-List of Login employee");
            Console.WriteLine("4-Create User");
            Console.WriteLine("5-logout \n");
            int input = int.Parse(Console.ReadLine());
            return input;
        }
        public int employeeMenu()
        {
            Console.WriteLine("\n ---------------------Choices from the list---------------------");
            Console.WriteLine("1-login");
            Console.WriteLine("2-Profile");
            Console.WriteLine("3-Update informaion");
            Console.WriteLine("4-logout \n");
            int input = int.Parse(Console.ReadLine());
            return input;
        }

        public int login()
        {
            Console.WriteLine("\n ---------Enter your id---------------");
            var id = int.Parse(Console.ReadLine());
            return id;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            choices choice = new choices();
            string answer;

            Console.WriteLine("##########################################################################");
            Console.WriteLine("                             Fingerprint                                  ");
            Console.WriteLine("##########################################################################");

            do
            {
                //var category = choice.start();
                switch (choice.start())//admin or employee?
                {
                    case 1:
                        var id = choice.login(); //take the id for user
                        var user = new UserBLL().GetUser(id); //get user by id
                        if (user.CategoryId==1) //If the user is an admin, he can go to the admin menu, if he is not an admin, he can go to the main menu
                        {
                            var finger = new FingerprintBLL().GetEmployee(user.Id); //to view for user is he logged in or not
                            string message = finger.IsLoggedIn == 1 ? "Logged in" : "You are logged out";
                            choice.helloUser(user, message);
                            var adminInput = choice.adminMenu();
                            var loopContinue = true;
                            while(loopContinue){
                                switch (adminInput)
                                {
                                    case 1://login
                                        new FingerprintBLL().login(user.Id);
                                        loopContinue = true;
                                        break;
                                    case 2://List of Employee
                                        Console.WriteLine("-------------------------List of Employee------------------------ \n");
                                        new UserBLL().GetAllUser();
                                        Console.WriteLine("------------------------------------------------------------------ \n");
                                        loopContinue = true;
                                        break;
                                    case 3://List of Login Employee
                                        new FingerprintBLL().GetAllEmployee();
                                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------- \n");
                                        loopContinue = true;
                                        break;
                                    case 4://Create User
                                    Console.WriteLine("-------------------------------------------------");
                                        Console.WriteLine("Enter Name:");
                                        var name = Console.ReadLine();
                                        Console.WriteLine("Enter Category 1 for admin and 2 for employee");
                                        var categoryId = Convert.ToInt32(Console.ReadLine());
                                        new UserBLL().CreateUser(name,categoryId);
                                        loopContinue = true;
                                        break;
                                    case 5://logout
                                        new FingerprintBLL().logout(user.Id);
                                        loopContinue = false;
                                        break;
                                    default:
                                        loopContinue = true;
                                        Console.WriteLine("\n Please enter the valid choice");
                                        break;
                                }
                                if(loopContinue){
                                    adminInput = choice.adminMenu();
                                }
                            }
                        }
                        else{
                            Console.WriteLine("You're not admin please try again");
                        }
                        break;
                    case 2:
                        var idemployee = choice.login();
                        var employeeinfo = new UserBLL().GetUser(idemployee);
                        var fingerE = new FingerprintBLL().GetEmployee(employeeinfo.Id);
                        string messageE = fingerE.IsLoggedIn == 1 ? "Logged in" : "You aren't logged in";
                        choice.helloUser(employeeinfo, messageE);
                        var employeeInput = choice.employeeMenu();
                        var loopEContinue = true;
                        while(loopEContinue){
                            switch (employeeInput)
                            {
                                case 1://lpgin
                                    new FingerprintBLL().login(employeeinfo.Id);
                                    loopEContinue = true;
                                    break;
                                case 2://profile
                                    Console.WriteLine("-------------------------------------------------");
                                    string categoryName = employeeinfo.CategoryId == 1 ? "Admin " : "Employee";
                                    Console.WriteLine("Name |" + employeeinfo.Name + "   Category  | " + categoryName);
                                    Console.WriteLine("------------------------------------------------- \n \n");
                                    loopEContinue = true;
                                    break;
                                case 3://Update informaion
                                    Console.WriteLine("--------------------------- Ubdate information --------------------------/n");
                                    Console.WriteLine("Enter Name:");
                                    var name = Console.ReadLine();
                                    new UserBLL().updateUser(employeeinfo.Id,name);
                                    loopEContinue = true;
                                    break;
                                case 4://logout
                                    new FingerprintBLL().logout(employeeinfo.Id);
                                    loopEContinue = false;
                                    break;
                                default:
                                    loopEContinue = true;
                                    Console.WriteLine("\n Please enter the valid choice");
                                    break;
                            }
                            if(loopEContinue){
                                employeeInput = choice.employeeMenu();
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("\nPlease enter the valid choice");
                        break;
                }
                Console.WriteLine("\nDo you want to continue? y/n");
                answer = Console.ReadLine();
            } while (answer != "n" || answer != "N");

            Console.Read();

        }
    }
}
