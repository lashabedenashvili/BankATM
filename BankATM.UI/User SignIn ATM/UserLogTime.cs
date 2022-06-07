using BankATM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public class UserLogTime
    {
        private readonly CheckUserSignIn _userId;
        private readonly IContext _context;

        public UserLogTime(CheckUserSignIn userId, IContext context)
        {
            _userId = userId;
            _context = context;
        }

        public void LogIn()
        {
            var userId = _userId.GetDbId();

            var Log = new LogTime
            {
                UserId = (int)userId,
                Login = DateTime.Now,
                MyProperty = null,
            };
            _context.LogTime.Add(Log);
            _context.saveChanges();


        }
        public void LogOut()
        {
            var userId = _userId.GetDbId();
            var LogOut = _context
                .LogTime
                .Where(n => n.MyProperty == null)
                .FirstOrDefault();

            LogOut.MyProperty = DateTime.Now;
            _context.LogTime.Add(LogOut);
            _context.saveChanges();
        }



    }


}
