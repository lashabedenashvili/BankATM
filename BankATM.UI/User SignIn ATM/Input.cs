using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class Input : IInput
    {
        public string input()
        {
            return Console.ReadLine();
            
        }
    }
}
