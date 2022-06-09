using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public class BillNumbCheck:Pprint
    {
        public bool BillNumberCheck(IRegexs regexs, string billNumb)
        {

            string numbCheck = @"[0-9]+$";

            if (billNumb.Length != 5)
            {
                Print("bill Number Must Be Contains 5 Numbers!");
                return false;
            }

            if (regexs.regex(numbCheck).IsMatch(billNumb))
            {
                return true;
            }
            else
            {
                Print("bill Number Must Be Contains Only Numbers!");
                return false;
            }

        }
    }
}
