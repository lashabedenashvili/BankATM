using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public class PassWordNumberCheck:Pprint
    {
        private readonly IRegexs _regex;

        public PassWordNumberCheck(IRegexs regex)
        {
            _regex = regex;
        }

        public bool PassWordnumberCheck(string PIN)
        {
            string numbCheck = @"[0-9]+$";
            if (PIN.Length != 4)
            {
                Print("PIN Must Be Contains 4 Numbers!");    
                return false;
            }

            if (_regex.regex(numbCheck).IsMatch(PIN))
            {
                return true;
            }
            else
            {
                Print("PIN Must Be Contains Only Numbers!");
                return false;
            }
        }
    }
}
