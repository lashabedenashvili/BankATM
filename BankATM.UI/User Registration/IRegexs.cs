using System.Text.RegularExpressions;

namespace BankATM.UI.User_Registration
{
    public interface IRegexs
    {
        Regex regex(string numberCheck);
    }
}