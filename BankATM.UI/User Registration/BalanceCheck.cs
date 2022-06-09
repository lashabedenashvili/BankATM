using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{

    public class BalanceCheck:Pprint
    {
        public bool BalanceChecks(IRegexs regexs, decimal Balance)
        {
            string numbCheck = @"[0-9]+$";

            string balance=Balance.ToString();

            if (balance.Length > 5)
            {
                Print("Balance Must Be Contains Numbers  MAX 99 999!");
                return false;
            }

            if (regexs.regex(numbCheck).IsMatch(balance))
            {
                return true;
            }
            else
            {
                Print("Balance Must Be Contains Only Numbers!");
                return false;
            }

        }

    }
}
