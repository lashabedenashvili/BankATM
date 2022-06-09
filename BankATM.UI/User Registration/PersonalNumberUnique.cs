using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public  class PersonalNumberUnique:Pprint
    {
        public bool PersonalNumberUniq(IContext context, string personalNumber)
        {
            

            var persNumber = context
             .User
             .Where(n => n.PersonalNumber == personalNumber)
             .FirstOrDefault();

            if (persNumber == null)
            {
                return true;
            }
            else return false;
        }

        public void PrintPersonalNumberUnique(IContext context, string personalNumber)
        {
            if (PersonalNumberUniq(context, personalNumber))
            {
                return;
            }
            else
            {
                Print("This Perosnal Number Is Alredy Exist!");
            }
        }

        public bool PersonalNumbersCheck(IRegexs regexs, string personalNumber)
        {
            string numbCheck = @"[0-9]+$";

            if (personalNumber.Length !=5)
                {
                    Print("PersonalNumber Must Be Contains 5 Numbers!");
                    return false;
                }

                if (regexs.regex(numbCheck).IsMatch(personalNumber))
                {
                    return true;
                }
                else
                {
                    Print("PersonalNumber Must Be Contains Only Numbers!");
                    return false;
                }
            
        }
    }
}
