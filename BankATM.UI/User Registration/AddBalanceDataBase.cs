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
        private readonly IGetId<UserCardId> _cardId;
        private readonly string _billNumber;
        private readonly Decimal _balance;
        private readonly IContext _context;


        public AddBalanceDataBase(IGetId<UserCardId> cardId, string billNumber, decimal balance, IContext context)
        {
            _cardId = cardId;
            _billNumber = billNumber;
            _balance = balance;
            _context = context;
        }

        public int AddBalanceBillNumber()
        {
            var addc = new Bill
            {
                BillNumber = _billNumber,
                Balance = _balance,
                CardId = (int)_cardId.GetDbId(),

            };

                   _context.Bill.Add(addc);
            return _context.saveChanges();


        }
    }
}
