using System;


namespace BankATM.UI.User_SignIn_ATM.Print
{
    public class Pprint : IPprint
    {
        public void Print(string name)
        {
            Console.WriteLine(name);
        }

       
    }
}
