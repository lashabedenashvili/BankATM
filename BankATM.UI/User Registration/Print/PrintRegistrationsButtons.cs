using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public class PrintRegistrationsButtons:IPrintRegistrationsButtons
    {
       

        public void PrintButtons()
        {
            Console.WriteLine(("\nPlease Press Propriate Button\n"));
        }

        public void PrintRegistrations()
        {
            Console.WriteLine("Registration >>>> 1 <<<<");
        }

        public void PrintSignIn()
        {
            Console.WriteLine(("Sign In      >>>> 2 <<<<"));
        }

        public void PrintBlockCard()
        {
            Console.WriteLine("Block Card   >>>> 3 <<<<");
        }

        public void PrintLoggOutSystem()
        {
            Console.WriteLine("Loggin Out    >>>> 4 <<<<");
        }

        public void PrintMainMany()
        {
            Console.WriteLine("Main Many     >>>> 1 <<<<");
        }
    }
}
