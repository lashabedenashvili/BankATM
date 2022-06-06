using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM.Print
{
    public class PrintUserInfo:Iprint<PrintUserInfo>
    {
        private readonly IContext context;
        private readonly ISignInID<CheckUserSignIn> UserId;

        public PrintUserInfo(IContext context, ISignInID<CheckUserSignIn> userId)
        {
            this.context = context;
            UserId = userId;
        }
         
        public void Print()
        {
            var PrintUserFull = context.User.Where(n => n.ID == UserId.Id()).ToList();

            foreach (var item in PrintUserFull)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Surname);
                
            }
        }


    }
}
