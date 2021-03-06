using BankATM.Data;
using BankATM.UI.User_SignIn_ATM.Print;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class Withdraw

    {
        private readonly IContext _context;
        private readonly decimal _amount;
        private readonly IGetId<UserCardId> _cardId;
        private readonly IGetId<UserBillId> _billId;
        private readonly IPrintUserBalance _printUser;

        public Withdraw(decimal amount, IGetId<UserCardId> cardId, IGetId<UserBillId> billId, IContext context, IPrintUserBalance printUser)
        {
            _amount = amount;
            _cardId = cardId;
            _billId = billId;

            _context = context;
            _printUser = printUser;
        }

        private decimal Balance()
        {
            
        return  _context
                .Bill
                .Where(n => n.CardId == _cardId
                .GetDbId())
                .Select(n => n.Balance)
                .FirstOrDefault();

            
        }
        private bool CheckAmountAccount()
        {
            var balance=Balance();


            if (_amount<= balance)
            {
                return true;
            }
            return false;


        }
        private void TransactionsLog()
        {
            var billId = _billId.GetDbId();           
            
            var Transactionlog = new Transactions
            {
                WithdrawAmount = _amount,
                WithdrowTime = DateTime.Now,
                BillId =(int) billId,
            };
            
            _context.Transactions.Add(Transactionlog);
            _context.saveChanges();
        }
        private void UpdateBalance()
        {
           var balance= Balance();
            var finalresult = balance - _amount;            
            var UpdateDataBase =_context
                .Bill
                .Where(n => n.CardId == _cardId.GetDbId())
                .FirstOrDefault();
            UpdateDataBase.Balance = finalresult;
            _context.saveChanges();
        }
        
       

        public void WithDraw()
        {
            var Checkbalance = CheckAmountAccount();
            if (Checkbalance)
            {
                UpdateBalance();
                TransactionsLog();
                _printUser.Print();
            }
            else 
            { 
                Console.WriteLine("You Havenot Enought Money");
                _printUser.Print();
            }




        }
    }
}
