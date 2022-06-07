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
        private readonly IErrors _error;
        private readonly IContext _context;

        public AddUserDataBase(string Name, string SurName, string PersonalNubmer, IErrors error, IContext context)
        {
            _name = Name;
            _surname = SurName;
            _personalNumber = PersonalNubmer;
            _error = error;
            _context = context;
        }


        public int AddUserDatabase()
        {                  

            var AddUser = new User
            {
                
                Name = _name,
                Surname = _surname,
                PersonalNumber = _personalNumber
            };
                  _context.User.Add(AddUser);
           return _context.saveChanges();
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
