using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankATM.Data;

namespace BankATM.UI.User_Registration
{
    public class AddUserDataBase : IAddUserDataBase
    {
        private readonly string _Name;
        private readonly string _Surname;
        private readonly string _PersonalNumber;
        readonly Ierrors error;

        public AddUserDataBase(string Name, string SurName, string PersonalNubmer, Ierrors error)
        {
            _Name = Name;
            _Surname = SurName;
            _PersonalNumber = PersonalNubmer;
            this.error = error;
        }


        public int AddUserDatabase()
        {
            Context context = new Context();          

            var AddUser = new User
            {
                
                Name = _Name,
                Surname = _Surname,
                PersonalNumber = _PersonalNumber
            };
            context.Add(AddUser);
           return context.SaveChanges();
        }

        public void Message(int result)        {
            
            if (result== 1)
            {
                
                Console.WriteLine(error.Message = "Register is Successful !");
            }
            else Console.WriteLine(error.Message = "Register is Filed!");

        }



    }

}
