using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM.Print
{
    public class PrintWithdraw : Iprint<PrintWithdraw>
    {
        public void Print()
        {
            Console.WriteLine("\n Withdraw >>> 1 <<< ");
        }
    }
}
