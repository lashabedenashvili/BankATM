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
        private readonly string CardNumber;
        private readonly string PassWord;
        private readonly string PersonalNumber;
        private readonly IGetUserId UserrId;
        private readonly Ierrors errors;
        

        public AddCardDataBase(string _Cardnumb, string _Password, string _PersonalNumber, IGetUserId userrId, Ierrors errors)
        {
            CardNumber = _Cardnumb;
            PassWord = _Password;
            PersonalNumber = _PersonalNumber;
            UserrId= userrId;
            this.errors = errors;
        }
        public int AddCardDatabase()
        {
            Context context = new Context();
            
            var AddCard = new Card
            {
                UserId = UserrId.GetuserId(),
                CardNumber = CardNumber,
                Password = PassWord,
            };
            context.Add(AddCard);
            return context.SaveChanges();
        }

        public void Message(int result)
        {
            

            if (result == 1)
            {
                Console.WriteLine(errors.Message = "Card Added Successfully");
            }
            else Console.WriteLine(errors.Message = "Adding Card failed");
        }
    }
}
