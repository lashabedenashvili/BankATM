using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public class Regexs : IRegexs
    {       
        public Regex regex(string numberCheck)
        {
            Regex regex = new Regex(numberCheck);
            return regex;
        }

        
    }
}
