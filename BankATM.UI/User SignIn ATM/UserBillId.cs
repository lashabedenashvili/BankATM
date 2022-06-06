using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class UserBillId : ISignInId<UserBillId>
    {
        
        private readonly ISignInId<UserCardId> _cardId;

        public UserBillId( ISignInId<UserCardId> cardId)
        {
          
            _cardId = cardId;
        }

        public int? GetDbId()
        {
            Context con = new Context();
            var BillId= con.Bill.Where(n=>n.CardId== _cardId.GetDbId())
                .Select(n=>n.Id).FirstOrDefault();
            return BillId;
        }
    }
}
