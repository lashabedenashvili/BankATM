using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM.Print
{
    public class PrintUserBalance:Pprint,IPrintUserBalance
    {
        private readonly IContext _context;
        private readonly IGetId<UserCardId> _cardId;
        



        public PrintUserBalance(IContext context, IGetId<UserCardId> cardId)
        {
            _context = context;
            _cardId = cardId;
            
        }

        public void Print()
        {
            var PrintBalance = _context
                .Bill
                .Where(n => n.CardId == _cardId.GetDbId()).ToList();

            foreach (var print in PrintBalance)
            {
               Print(("\nBill Number: " + print.BillNumber + "\nBalance: $" + print.Balance + "\n"));
            }

        }
    }
}
