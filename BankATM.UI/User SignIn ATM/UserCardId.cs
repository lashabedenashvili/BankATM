using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class UserCardId :ISignInID<UserCardId>
    {
        private readonly IContext Context;
        private readonly string cardNumber;
        private readonly string PassWord;

        public UserCardId(IContext context, string cardNumber, string passWord)
        {
            Context = context;
            this.cardNumber = cardNumber;
            PassWord = passWord;
        }

        public int Id()
        {
            var CardId = Context
                 .Card
                 .Where(n => n.CardNumber == cardNumber & n.Password == PassWord)
                 .Select(n => n.Id).FirstOrDefault();
            return CardId;
        }
    }
}
