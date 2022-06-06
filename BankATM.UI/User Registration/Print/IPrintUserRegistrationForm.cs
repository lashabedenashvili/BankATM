using BankATM.UI.User_Registration.Print;

namespace BankATM.UI.User_Registration
{
    public interface IPrintUserRegistrationForm: IprintCardNumber,IprintPassWord, IprintBalanceBill
    {
        void PrintName();
        void PrintPersonalNumber();
        void PrintSurname();
    }
}