using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class UserBillId : IGetId<UserBillId>
    {

        private readonly IGetId<UserCardId> _cardId;
        private readonly IContext _context;

        public UserBillId(IGetId<UserCardId> cardId, IContext context)
        {

            _cardId = cardId;
            _context = context;
        }

        public int? GetDbId()
        {           
            return _context
                .Bill
                .Where(n => n.CardId == _cardId.GetDbId())
                .Select(n => n.Id)
                .FirstOrDefault();

        }
    }
}
