using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM.UI.User_SignIn_ATM
{
    public interface IGetId<T> where T : class
    {
        int? GetDbId();
    }
}
