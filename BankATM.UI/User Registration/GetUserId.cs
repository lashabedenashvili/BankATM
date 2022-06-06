using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public class GetUserId : IGetUserId
    {
        private readonly string PersonalNumber;

        public GetUserId(string personalNumber)
        {
            PersonalNumber = personalNumber;
        }

        public int GetuserId()
        {
            Context context = new Context();

            var UserId = context.User
                .Where(n => n.PersonalNumber == PersonalNumber)
                .Select(n => n.ID).FirstOrDefault();

            return UserId;
        }
    }
}
