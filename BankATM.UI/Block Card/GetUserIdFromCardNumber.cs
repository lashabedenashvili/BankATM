using BankATM.UI.User_SignIn_ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.Block_Card
{
    public class GetUserIdFromCardNumber : IGetId<GetUserIdFromCardNumber>
    {
        private readonly IContext _context;
        private readonly string _cardNumber;

        public GetUserIdFromCardNumber(IContext context, string cardNumber)
        {
            _context = context;
            _cardNumber = cardNumber;
        }

        public int? GetDbId()
        {
            return _context
                .Card
                .Where(n => n.CardNumber == _cardNumber)
                .Select(n => n.UserId)
                .FirstOrDefault();
        }
    }
}
