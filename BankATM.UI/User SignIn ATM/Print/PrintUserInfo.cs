using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM.Print
{
    public class PrintUserInfo:Pprint
    {
        private readonly IContext _context;
        private readonly ISignInId<CheckUserSignIn> _userId;
        

        public PrintUserInfo(IContext context, ISignInId<CheckUserSignIn> userId)
        {
            _context = context;
            _userId = userId;
           
        }

        public void Print()
        {
            var PrintUserFull = _context.User.Where(n => n.ID == _userId.GetDbId()).ToList();

            foreach (var item in PrintUserFull)
            {
               Print(("\n"+item.Name));
               Print((item.Surname));
                
            }
        }


    }
}
