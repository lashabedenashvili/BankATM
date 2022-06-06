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
        private readonly IInput _input;
        public InputSignIn(IInput input)
        {
           _input=input;
        }

        public string InputCardNumber()
        {
            return _input.input();
        }
        public string InputName()
        {
            return _input.input();
        }
        public string InputWithdrawPassword()
        {
            return _input.input();
        }
    }
}
