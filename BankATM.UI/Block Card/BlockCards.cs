using BankATM.Data;
using BankATM.UI.Block_Card;
using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class BlockCards:Pprint
    {     



        public void AddBlockCard(IContext context, IUserCardId _userCardId)
        {
            var cardId = _userCardId.GetDbId();
            var AddBlockCard = new BlockCard
            {
                CardId = (int)cardId,
            };
            context.BlockCard.Add(AddBlockCard);
            context.saveChanges();
        }
        
        public void PrintBlockCard(string cardNumber)
        {
            Print("Your Card is blocked! ");
            Print($"Card Number : {cardNumber} ");
        }

        public void PrintCardNumber()
        {
            Print("Enter Personal Number");
        }
        public string InputCardNumber(IInput input)
        {
            return input.input();
        }
        public void PrintBlockUserInfo(IContext context, IGetId<GetUserIdFromCardNumber> userId)
        {
            var PrintUserInfo=context
                .User
                .Where(n => n.ID == userId.GetDbId())
                .ToList();
            foreach (var User in PrintUserInfo)
            {
                Print("Name :"+User.Name);
                Print("Surname: "+User.Surname);
            }
        }

    }
}
