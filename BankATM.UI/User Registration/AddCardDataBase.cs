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
        private readonly IContext _context;


        public AddCardDataBase(string cardnumb, string password, string personalNumber, IGetUserId userrId, IErrors errors, IContext context)
        {
            _cardNumber = cardnumb;
            _passWord = password;
            _personalNumber = personalNumber;
            _userrId = userrId;
            _errors = errors;
            _context = context;
        }
        public int AddCardDatabase()
        {


            var AddCard = new Card
            {
                UserId = _userrId.GetuserId(),
                CardNumber = _cardNumber,
                Password = _passWord,
            };
                   _context.Card.Add(AddCard);
            return _context.saveChanges();
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
