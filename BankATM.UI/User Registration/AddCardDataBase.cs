using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankATM.Data;

namespace BankATM.UI.User_Registration
{
    public class AddCardDataBase : IAddCardDataBase
    {
        private readonly string _cardNumber;
        private readonly string _passWord;
        private readonly string _personalNumber;
        private readonly IGetUserId _userrId;
        private readonly IErrors _errors;
        

        public AddCardDataBase(string cardnumb, string password, string personalNumber, IGetUserId userrId, IErrors errors)
        {
            _cardNumber = cardnumb;
            _passWord = password;
            _personalNumber = personalNumber;
            _userrId= userrId;
            _errors = errors;
        }
        public int AddCardDatabase()
        {
            Context context = new Context();
            
            var AddCard = new Card
            {
                UserId = _userrId.GetuserId(),
                CardNumber = _cardNumber,
                Password = _passWord,
            };
            context.Add(AddCard);
            return context.SaveChanges();
        }

        public void Message(int result)
        {
            

            if (result == 1)
            {
                Console.WriteLine(_errors.Message = "Card Added Successfully");
            }
            else Console.WriteLine(_errors.Message = "Adding Card failed");
        }
    }
}
