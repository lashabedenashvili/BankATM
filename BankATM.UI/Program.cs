using BankATM.UI.User_Registration;
using BankATM.UI.User_SignIn_ATM;
using BankATM.UI.User_SignIn_ATM.Print;
using System;
using System.Linq;

namespace BankATM.UI
{
    public class Program
    {
        static void Main(string[] args)
        {

            int go = 0;
            do
            {    // Main Many
                var print = new PrintRegistrationsButtons();
                var PrintUserRegistration = new PrintUserRegistrationForm();


                print.PrintButtons();
                print.PrintRegistrations();
                print.PrintSignIn();
                print.PrintBlockCard();

                string InputRegistration = Console.ReadLine();
                if (InputRegistration == "1")
                {   // Registration
                    var InputUser = new Input();
                    var Input = new InputUser(InputUser);
                    PrintUserRegistration.PrintName();
                    var Name = Input.InputName();
                    PrintUserRegistration.PrintSurname();
                    var SurName = Input.InputSurname();
                    PrintUserRegistration.PrintPersonalNumber();
                    var PersonalNumber = Input.InputPersonalNumber();
                    var error = new Errors();
                    var AddUserBase = new AddUserDataBase(Name, SurName, PersonalNumber, error);
                    var ResultMessegeUser = AddUserBase.AddUserDatabase();
                    PrintUserRegistration.PrintCardNumber();
                    var CardNumber = Input.InputCardNumber();
                    PrintUserRegistration.PrintPassWord();
                    var PassWord = Input.InputPassWord();
                    PrintUserRegistration.BillNumber();
                    var BillNumber = Input.BillNumber();
                    PrintUserRegistration.Balance();
                    var Balance = Input.Balance();
                    // Add Card & Balance
                    var UserId = new GetUserId(PersonalNumber);
                    var errors = new Errors();
                    var addCardDataBase = new AddCardDataBase(CardNumber, PassWord, PersonalNumber, UserId, errors);
                    var ResultMessegeCard = addCardDataBase.AddCardDatabase();
                    var context = new Context();
                    var CardId = new UserCardId(context, CardNumber, PassWord);
                    var AddBalanceBillDatabase = new AddBalanceDataBase(CardId, BillNumber, Balance);
                    AddBalanceBillDatabase.AddBalanceBillNumber();
                    // Added User & Card Result
                    AddUserBase.Message(ResultMessegeUser);
                    addCardDataBase.Message(ResultMessegeCard);
                    print.PrintMainMany();
                    print.PrintLoggOutSystem();
                    string ChooseNextStage = Console.ReadLine();
                    // Main Many or Log Out
                    if (ChooseNextStage == "1") { go = 1; }
                    else if (ChooseNextStage == "2") return;
                }
                if (InputRegistration == "2")
                {
                    //int SignInGo = 0;
                    //do
                    //{  // Sign In
                    var PrintUserInfo = new PrintUserRegistrationForm();
                    var InputSignIn = new Input();
                    var Input = new InputUser(InputSignIn);
                    PrintUserInfo.PrintCardNumber();
                    var InputCardNumber = Input.InputCardNumber();
                    PrintUserInfo.PrintPassWord();
                    var InputPassword = Input.InputPassWord();
                    var Context = new Context();
                    var Checkuser = new CheckUserSignIn(InputCardNumber, InputPassword, Context);
                    var UserId = Checkuser.GetDbId();
                    //    if (CheckUser == 0) { SignInGo = 1; }
                    //} while (SignInGo == 1);
                    //var context = new Context();
                    var UserIId=new CheckUserSignIn(InputCardNumber, InputPassword, Context);
                    var LogTime = new UserLogTime(UserIId);
                    LogTime.LogIn();
                    var PrintUserDetail = new PrintUserInfo(Context, Checkuser);
                    var CardId = new UserCardId(Context, InputCardNumber, InputPassword);
                    var PrintBalance = new PrintUserBalance(Context, CardId);
                    PrintUserDetail.Print();
                    PrintBalance.Print();
                    var PrintWithdraw = new PrintWithdraw();
                    var PrintChangePassWord = new PassWordChange();
                    PrintWithdraw.Print();
                    PrintChangePassWord.Print();
                    var InputWithdrawPassword = new InputSignIn(InputSignIn);
                    var WithdrawPassword = InputWithdrawPassword.InputWithdrawPassword();
                    if (WithdrawPassword == "1")
                    {
                        Console.WriteLine("Enter money");
                        decimal money = decimal.Parse(Console.ReadLine());
                        var CardIdd=new UserCardId(Context, InputCardNumber, InputPassword);
                        var BillId = new UserBillId(CardIdd);
                        var Withdraw = new Withdraw(money, CardId, BillId, PrintBalance);
                        Withdraw.WithDraw();
                        
                    }
                    // var InsertWithdrawOrPassWord=















                }
            } while (go == 1);



            Console.ReadKey();
        }

    }














}

