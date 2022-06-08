using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class UserCardId : IGetId<UserCardId>, IUserCardId
    {
        private readonly IContext _context;
        private readonly string _cardNumber;
        private readonly string _passWord;

        public UserCardId(IContext context, string cardNumber, string passWord)
        {
            _context = context;
            _cardNumber = cardNumber;
            _passWord = passWord;
        }

        public int? GetDbId()
        {
            return _context
                   .Card
                   .Where(n => n.CardNumber == _cardNumber & n.Password == _passWord)
                   .Select(n => n.Id)
                   .FirstOrDefault();

        }
    }
}
