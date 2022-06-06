using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public class PrintUserRegistrationForm : IPrintUserRegistrationForm
    {

        public void PrintName()
        {
            Console.WriteLine("Enter Name: ");
        }
        public void PrintSurname()
        {
            Console.WriteLine("Enter Surname: ");
        }
        public void PrintPersonalNumber()
        {
            Console.WriteLine("Enter PersonalNumber: ");
        }

        public void PrintCardNumber()
        {
            Console.WriteLine("Enter Card Number: ");
        }

        public void PrintPassWord()
        {
            Console.WriteLine("Enter PassWord");
        }

        public void Balance()
        {
            Console.WriteLine("Enter Balance: ");
        }

        public void BillNumber()
        {
            Console.WriteLine("Enter Bill Number: ");
        }
    }

}
