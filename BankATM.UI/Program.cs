using BankATM.UI.Block_Card;
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
                    var ccontex = new Context();
                    var AddUserBase = new AddUserDataBase(Name, SurName, PersonalNumber, error, ccontex);
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
                    var cont = new Context();
                    var UserId = new GetUserId(PersonalNumber, cont);
                    var errors = new Errors();
                    var con = new Context();
                    var addCardDataBase = new AddCardDataBase(CardNumber, PassWord, PersonalNumber, UserId, errors, con);
                    var ResultMessegeCard = addCardDataBase.AddCardDatabase();
                    var context = new Context();
                    var CardId = new UserCardId(context, CardNumber, PassWord);
                    var conte = new Context();
                    var AddBalanceBillDatabase = new AddBalanceDataBase(CardId, BillNumber, Balance, conte);
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
                    var UserIId = new CheckUserSignIn(InputCardNumber, InputPassword, Context);
                    var LogTime = new UserLogTime(UserIId, Context);
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
                        var CardIdd = new UserCardId(Context, InputCardNumber, InputPassword);
                        var context = new Context();
                        var BillId = new UserBillId(CardIdd, context);
                        Context xon = new Context();
                        var Withdraw = new Withdraw(money, CardId, BillId, xon, PrintBalance);
                        Withdraw.WithDraw();


                    }
                    else if (WithdrawPassword == "2")
                    {
                        var PassWordChangeContex = new Context();
                        var PasswordChangeInput = new Input();
                        var userId = new CheckUserSignIn(InputCardNumber, InputPassword, PassWordChangeContex);
                        var PassWordChange = new PassWordChangee(userId, InputCardNumber, InputPassword, PassWordChangeContex, PasswordChangeInput);
                        PassWordChange.PrintOldPassword();
                        PassWordChange.InputOldPassword();
                        PassWordChange.PrintNewPassWord();
                        var newPassword = PassWordChange.InputNewPassword();
                        PassWordChange.UpdateNewPassWord(newPassword);


                    }

                    // var InsertWithdrawOrPassWord=

                }
                else if (InputRegistration == "3")
                {
                    var CardNumber = new BlockCards();
                    CardNumber.PrintCardNumber();
                    var cardNumberInput = new Input();
                    var inputCardNumber = CardNumber.InputCardNumber(cardNumberInput);
                    CardNumber.PrintBlockCard(inputCardNumber);
                    Context ccon = new Context();
                    var UserId = new GetUserIdFromCardNumber(ccon, inputCardNumber);
                    CardNumber.PrintBlockUserInfo(ccon, UserId);

                    }
            } while (go == 1);



            Console.ReadKey();
        }

    }














}

