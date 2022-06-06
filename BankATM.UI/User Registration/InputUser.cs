using BankATM.UI.User_SignIn_ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    
    public class InputUser 
    {
        private readonly Input input;

        public InputUser(Input input)
        {
            this.input = input;
        }

        public string InputName()
        {
            return input.input();
        }
        public string InputSurname()
        {
            return input.input();
        }
        public string InputPersonalNumber()
        {
            return input.input();

        }

        public string InputCardNumber()
        {
            return input.input(); ;
        }

        public string InputPassWord()
        {
            return input.input();
        }

        public decimal Balance()
        {
            decimal Balance =decimal.Parse( Console.ReadLine());
            return Balance;
        }

        public string BillNumber()
        {
            return input.input();
        }
    }
}
