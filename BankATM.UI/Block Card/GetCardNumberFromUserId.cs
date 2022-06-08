using BankATM.UI.User_SignIn_ATM;
using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.Block_Card
{

    public class GetCardNumberFromUserId:Pprint
    {
        private readonly IGetId<GetUserIdFromPersonalNumber> _userId;
        private readonly IContext _context;

        public GetCardNumberFromUserId(IGetId<GetUserIdFromPersonalNumber> userId, IContext context)
        {
            _userId = userId;
            _context = context;
        }

        public List<string> CardNumbers()
        {
            var UserId=_userId.GetDbId();
            return _context
                .Card
                .Where(n=>n.UserId == UserId)
                .Select(n=>n.CardNumber).ToList();
        }

        public void PrintCardNumbers()
        {
            var CardNumber=CardNumbers();
            if (CardNumber.Count > 0)
            {
                foreach (var card in CardNumber)
                {
                    Print($"Block Card Number:{card}");
                }
            }
            else Print("There is no blocked card");
        }
    }

    
}
