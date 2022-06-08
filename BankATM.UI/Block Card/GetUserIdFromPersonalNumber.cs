using BankATM.UI.User_SignIn_ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.Block_Card
{
    public class GetUserIdFromPersonalNumber : IGetId<GetUserIdFromPersonalNumber>
    {
        private readonly IContext _context;
        private readonly string _personalNumber;
        public GetUserIdFromPersonalNumber(IContext context, string personalNumber)
        {
            _context = context;
            _personalNumber = personalNumber;
        }

        public int? GetDbId()
        {
           return _context
                .User
                .Where(n=>n.PersonalNumber == _personalNumber)
                .Select(n=>n.ID).FirstOrDefault();
        }
    }
}
