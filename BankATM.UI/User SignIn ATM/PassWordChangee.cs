using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class PassWordChangee : Pprint
    {




        private readonly ISignInId<CheckUserSignIn> _userId;
        private readonly string _cardNumber;
        private readonly string _passWord;
        private readonly IContext _context;
        private readonly IInput _input;


        public PassWordChangee(ISignInId<CheckUserSignIn> userId, string cardNumber, string passWord, IContext context, IInput input)
        {

            _userId = userId;
            _cardNumber = cardNumber;
            _passWord = passWord;
            _context = context;
            _input = input;
        }

        public void PrintOldPassword()
        {
            Print("Enter Old PassWord:");
        }
        public void PrintNewPassWord()
        {
            Print("Enter New PassWord");
        }
        public string InputOldPassword()
        {
            return _input.input();
        }
        public string InputNewPassword()
        {
            return _input.input();
        }


        public bool CheckOldPassWord()
        {
            var checkPassword = _context
                 .Card
                 .Where(n => n.CardNumber == _cardNumber && n.Password == _passWord)
                 .FirstOrDefault();
            if (checkPassword == null) return false;
            else return true;

        }

        public void UpdateNewPassWord(string newPassword)
        {
            if (CheckOldPassWord())
            {
                var userId = _userId.GetDbId();
                var UpdatePassword = _context
                    .Card
                    .Where(n => n.UserId == userId && n.CardNumber == _cardNumber)
                    .FirstOrDefault();

                UpdatePassword.Password = newPassword;                
                _context.saveChanges();
                Print("PassWord Change Succsesfule");
            }
            else
            {
                Print("Wrong PassWord !!!");
            }
        }


    }
}
