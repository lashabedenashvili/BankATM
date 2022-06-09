using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public class CheckLetters : Pprint
    {
        
        public bool Checkletter(IRegexs regexs, string letters)
        {
            string letter = @"[a-zA-Z]+$";
          

            if (letters.Length > 30)
            {
                Print("Text Only Contains  30 Caharaters");
                return false;
            }

            if (regexs.regex(letter).IsMatch(letters))
            {
                return true;
            }
            else
            {
                Print("Text Must Be Contains Only Letters!");
                return false;
            }

        }
    }
}
