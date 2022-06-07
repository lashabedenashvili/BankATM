using BankATM.Data;
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
       private readonly IUserCardId _userCardId;       

        public BlockCards(IUserCardId userCardId )
        {
            _userCardId = userCardId;
            
        }



        public void AddBlockCard(IContext context)
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
            Print($"Your Card {cardNumber} is blocked! ");
        }
    }
}
