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
        private readonly ISignInId<UserCardId> _cardId;
        private readonly string _billNumber;
        private readonly Decimal _balance;


        public AddBalanceDataBase(ISignInId<UserCardId> cardId, string billNumber, decimal balance)
        {
            _cardId = cardId;
            _billNumber = billNumber;
            _balance = balance;

        }

        public int AddBalanceBillNumber()
        {
            var addc = new Bill
            {
                BillNumber = _billNumber,
                Balance = _balance,
                CardId =(int) _cardId.GetDbId(),

            };
            var context = new Context();
            context.Add(addc);
            return context.SaveChanges();


        }
    }
}
