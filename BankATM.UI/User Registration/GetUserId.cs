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

        public GetUserId(string personalNumber)
        {
            _personalNumber = personalNumber;
        }

        public int GetuserId()
        {
            Context context = new Context();

          return context.User
                .Where(n => n.PersonalNumber == _personalNumber)
                .Select(n => n.ID)
                .FirstOrDefault();

            
        }
    }
}
