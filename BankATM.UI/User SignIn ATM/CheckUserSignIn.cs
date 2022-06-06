using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class CheckUserSignIn :ISignInId<CheckUserSignIn>
    {
        private readonly string _cardNumber;
        private readonly string _password;
        readonly IContext _context;

        public CheckUserSignIn(string cardNumber, string password, IContext context)
        {
           _cardNumber = cardNumber;
           _password = password;
           _context = context;
        }

        public int? GetDbId()
        {
         return _context
                .Card
                .Where(n => n.CardNumber == _cardNumber & n.Password == _password)
                .Select(n => n.UserId)
                .FirstOrDefault();
        }
    }
}
