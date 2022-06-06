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
        private readonly string _name;
        private readonly string _surname;
        private readonly string _personalNumber;
        readonly IErrors _error;

        public AddUserDataBase(string Name, string SurName, string PersonalNubmer, IErrors error)
        {
            _name = Name;
            _surname = SurName;
            _personalNumber = PersonalNubmer;
            _error = error;
        }


        public int AddUserDatabase()
        {
            Context context = new Context();          

            var AddUser = new User
            {
                
                Name = _name,
                Surname = _surname,
                PersonalNumber = _personalNumber
            };
            context.Add(AddUser);
           return context.SaveChanges();
        }

        public void Message(int result)        {
            
            if (result== 1)
            {
                
                Console.WriteLine(_error.Message = "Register is Successful !");
            }
            else Console.WriteLine(_error.Message = "Register is Filed!");

        }



    }

}
