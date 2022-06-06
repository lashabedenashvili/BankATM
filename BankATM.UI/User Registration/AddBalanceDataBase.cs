using BankATM.Data;
using BankATM.UI.User_SignIn_ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_Registration
{
    public class AddBalanceDataBase
    {
        private readonly ISignInID<UserCardId> CardId;
        private readonly string BillNumber;
        private readonly Decimal Balance;


        public AddBalanceDataBase(ISignInID<UserCardId> cardId, string billNumber, decimal balance)
        {
            CardId = cardId;
            BillNumber = billNumber;
            Balance = balance;

        }

        public int AddBalanceBillNumber()
        {
            var addc = new Bill
            {
                BillNumber = BillNumber,
                Balance = Balance,
                CardId = CardId.Id(),

            };
            var context = new Context();
            context.Add(addc);
            return context.SaveChanges();


        }
    }
}
