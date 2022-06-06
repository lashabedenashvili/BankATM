using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM.Print
{
    public class PrintUserBalance : Iprint<PrintUserBalance>
    {
        private readonly IContext context;
        private readonly ISignInId<UserCardId> CardId;

        public PrintUserBalance(IContext context, ISignInId<UserCardId> cardId)
        {
            this.context = context;
            CardId = cardId;
        }

        public void Print()
        {
            Context cont=new Context();
            var PrintBalance= cont
                .Bill
                .Where(n=>n.CardId== CardId.GetDbId()).ToList();

            foreach (var print in PrintBalance)
            {
                Console.Write("CardNumber: "+print.BillNumber+ "\nBalance: $"+print.Balance);
            }
            
        }
    }
}
