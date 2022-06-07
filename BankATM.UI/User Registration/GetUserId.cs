using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public class GetUserId : IGetUserId
    {
        private readonly string _personalNumber;
        private readonly IContext _context;

        public GetUserId(string personalNumber, IContext context)
        {
            _personalNumber = personalNumber;
            _context = context;
        }

        public int GetuserId()
        {           

          return _context.User
                .Where(n => n.PersonalNumber == _personalNumber)
                .Select(n => n.ID)
                .FirstOrDefault();

            
        }
    }
}
