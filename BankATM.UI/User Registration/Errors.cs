using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    internal class Errors:Ierrors
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
    }
}
