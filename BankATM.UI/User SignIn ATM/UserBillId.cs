using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class UserBillId : ISignInID<UserBillId>
    {
        
        private readonly ISignInID<UserCardId> cardId;

        public UserBillId( ISignInID<UserCardId> userId)
        {
          
            cardId =userId;
        }

        public int Id()
        {
            Context con = new Context();
            var BillId= con.Bill.Where(n=>n.CardId== cardId.Id())
                .Select(n=>n.Id).FirstOrDefault();
            return BillId;
        }
    }
}
