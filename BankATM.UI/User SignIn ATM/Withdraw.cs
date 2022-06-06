using BankATM.Data;
using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class Withdraw
    {
        private readonly decimal Amount;
        private readonly ISignInID<UserCardId> CardId;
        private readonly ISignInID<UserBillId> BillId;
        private readonly Iprint<PrintUserBalance> PrintUser;
        public Withdraw(decimal amount, ISignInID<UserCardId> cardId, ISignInID<UserBillId> billId, Iprint<PrintUserBalance> print)
        {
            Amount = amount;
            CardId = cardId;
            BillId = billId;
            this.PrintUser = print;
        }

        private decimal Balance()
        {
            Context context = new Context();
           var AmountAccount = context
                .Bill
                .Where(n => n.CardId == CardId.Id())
                .Select(n => n.Balance).FirstOrDefault();

            return AmountAccount;
        }
        private bool CheckAmountAccount()
        {
            var balance=Balance();


            if (Amount<= balance)
            {
                return true;
            }
            return false;


        }
        private void TransactionsLog()
        {
            var billId = BillId.Id();
            Context context = new Context();
            var Transactionlog = new Transactions
            {
                WithdrawAmount = Amount,
                WithdrowTime = DateTime.Now,
                BillId = billId,
            };
            context.Add(Transactionlog);
            context.SaveChanges();
        }
        private void UpdateBalance()
        {
           var balance= Balance();
            var finalresult = balance - Amount;
            Context context = new Context();
            var UpdateDataBase = context.Bill.Where(n => n.CardId == CardId.Id()).FirstOrDefault();
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
                PrintUser.Print();
            }
            else 
            { 
                Console.WriteLine("You Havenot Enought Money");
                PrintUser.Print();
            }




        }
    }
}
