using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public  class CardNumberUnique:Pprint
    {
        public bool CardNumbUnique(IContext context,string cardNumber)
        {
            
               var CardNumb= context
                .Card
                .Where(n=>n.CardNumber== cardNumber)
                .FirstOrDefault();

            if (CardNumb == null)
            {
                return true;
            }
            else return false;
        }

        public void PrintWrongCardNumber(IContext context, string cardNumber)
        {
            if (CardNumbUnique(context, cardNumber))
            {
                return;
            }
            else
            {
                Print("This Card Number Is Alredy Exist!");
            }
        }

        public bool CardNumberNumbersCheck(IRegexs regexs, string cardNumber)
        {
            string numbCheck = @"[0-9]+$";

            if (cardNumber.Length != 5)
            {
                Print("cardNumber Must Be Contains 5 Numbers!");
                return false;
            }

            if (regexs.regex(numbCheck).IsMatch(cardNumber))
            {
                return true;
            }
            else
            {
                Print("cardNumber Must Be Contains Only Numbers!");
                return false;
            }

        }

    }
}
