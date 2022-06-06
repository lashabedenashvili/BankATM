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
        private readonly ISignInId<UserCardId> _cardId;
        private readonly ISignInId<UserBillId> _billId;
        private readonly Iprint<PrintUserBalance> _printUser;
        
        public Withdraw(decimal amount, ISignInId<UserCardId> cardId, ISignInId<UserBillId> billId, Iprint<PrintUserBalance> print, IContext context)
        {
            _amount = amount;
            _cardId = cardId;
            _billId = billId;
            _printUser = print;
            _context = context;
            
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
            Context context = new Context();
            
            var Transactionlog = new Transactions
            {
                WithdrawAmount = _amount,
                WithdrowTime = DateTime.Now,
                BillId =(int) billId,
            };
            //context.Add(Transactionlog);
            _context.Transactions.Add(Transactionlog);
            _context.SaveChanges();
        }
        private void UpdateBalance()
        {
           var balance= Balance();
            var finalresult = balance - _amount;
            Context context = new Context();
            var UpdateDataBase = context
                .Bill
                .Where(n => n.CardId == _cardId.GetDbId())
                .FirstOrDefault();
            UpdateDataBase.Balance = finalresult;
            context.SaveChanges();
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
