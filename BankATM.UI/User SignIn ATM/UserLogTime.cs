using BankATM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public  class UserLogTime
    {
        private readonly CheckUserSignIn UserId;

        public UserLogTime(CheckUserSignIn userId)
        {
            UserId = userId;
        }

        public void LogIn()
        {
            var userId=UserId.Id();
            Context context=new Context();
            var Log = new LogTime
            {
                UserId = userId,
                Login = DateTime.Now,
                MyProperty = null,
            };
            context.Add(Log);
            context.SaveChanges();

           
        }
        public void LogOut()
        {
            var userId = UserId.Id();
            Context context = new Context();
            var LogOut =context.LogTime.Where(n=>n.MyProperty == null).FirstOrDefault();
            LogOut.MyProperty = DateTime.Now;
            context.Add(LogOut);
            context.SaveChanges();
        }



    }


}
