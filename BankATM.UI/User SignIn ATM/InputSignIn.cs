using BankATM.UI.User_Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class InputSignIn
    {
        private readonly Iinput input;
        public InputSignIn(Iinput input)
        {
            this.input=input;
        }

        public string InputCardNumber()
        {
            return input.input();
        }
        public string InputName()
        {
            return input.input();
        }
        public string InputWithdrawPassword()
        {
            return input.input();
        }
    }
}
