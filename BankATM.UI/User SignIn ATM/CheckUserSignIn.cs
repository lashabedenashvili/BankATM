using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class CheckUserSignIn :ISignInID<CheckUserSignIn>
    {
        private readonly string CardNumber;
        private readonly string Password;
        readonly IContext context;

        public CheckUserSignIn(string cardNumber, string password, IContext context)
        {
            this.CardNumber = cardNumber;
            this.Password = password;
            this.context = context;
        }

        public int Id()
        {
            var ChekUser = context
                .Card
                .Where(n => n.CardNumber == CardNumber & n.Password == Password)
                .Select(n => n.UserId).FirstOrDefault();
            return ChekUser;
        }
    }
}
