using BankATM.UI.User_Registration.Print;

namespace BankATM.UI.User_Registration
{
    public interface IPrintRegistrationsButtons: IPrintBlockCard, IPrintSignIn, IprintRegistration
    {
        
        void PrintButtons();
        void PrintLoggOutSystem();
        void PrintMainMany();
        
        
        


    }
}