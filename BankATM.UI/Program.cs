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



            // Main Many
            var print = new PrintRegistrationsButtons();
            var PrintUserRegistration = new PrintUserRegistrationForm();

            string wrongNumberMain = "1";
            while (wrongNumberMain == "1")
            {
                print.PrintButtons();
                print.PrintRegistrations();
                print.PrintSignIn();
                print.PrintBlockCard();

                string InputRegistration = Console.ReadLine();

                // Registration
                if (InputRegistration == "1")
                {

                    // Letters Check
                    string letterName = "1";
                    while (letterName == "1")
                    {
                        var InputUser = new Input();
                        var Input = new InputUser(InputUser);
                        PrintUserRegistration.PrintName();
                        var Name = Input.InputName();
                        var checkLetter = new CheckLetters();
                        var regg = new Regexs();
                        var checkNameLetters = checkLetter.Checkletter(regg, Name);
                        if (checkNameLetters == false)
                        {
                            letterName = "1";
                            continue;
                        }
                        string letterSurname = "1";
                        while (letterSurname == "1")
                        {
                            PrintUserRegistration.PrintSurname();
                            var SurName = Input.InputSurname();

                            var checkSurnameLetters = checkLetter.Checkletter(regg, SurName);

                            if (checkSurnameLetters == false)
                            {
                                letterSurname = "1";
                                continue;
                            }
                            //Personal Number Check
                            string personalNumberUnique = "1";
                            while (personalNumberUnique == "1")
                            {
                                var ccontex = new Context();
                                PrintUserRegistration.PrintPersonalNumber();
                                var PersonalNumber = Input.InputPersonalNumber();
                                var ssss = new PersonalNumberUnique();
                                var PersNumb = ssss.PersonalNumberUniq(ccontex, PersonalNumber);
                                ssss.PrintPersonalNumberUnique(ccontex, PersonalNumber);
                                var reg = new Regexs();
                                var pesNumbCheck = ssss.PersonalNumbersCheck(reg, PersonalNumber);
                                if (PersNumb == false)
                                {
                                    personalNumberUnique = "1";
                                    continue;
                                }
                                else if (pesNumbCheck == false)
                                {
                                    personalNumberUnique = "1";
                                    continue;
                                }
                                var error = new Errors();
                                var AddUserBase = new AddUserDataBase(Name, SurName, PersonalNumber, error, ccontex);
                                var ResultMessegeUser = AddUserBase.AddUserDatabase();
                                PrintUserRegistration.PrintCardNumber();


                                // Card Number Unique Check
                                string cardNumbUniq = "1";
                                while (cardNumbUniq == "1")
                                {
                                    var CardNumber = Input.InputCardNumber();
                                    var CheckCardNumb = new CardNumberUnique();
                                    var Card = CheckCardNumb.CardNumbUnique(ccontex, CardNumber);
                                    CheckCardNumb.PrintWrongCardNumber(ccontex, CardNumber);
                                    var checkCard = CheckCardNumb.CardNumberNumbersCheck(reg, CardNumber);

                                    if (Card == false)
                                    {
                                        cardNumbUniq = "1";
                                        continue;
                                    }
                                    else if (checkCard == false)
                                    {
                                        cardNumbUniq = "1";
                                        continue;
                                    }


                                    // chek password
                                    string PassWordCheck = "1";
                                    while (PassWordCheck == "1")
                                    {
                                        PrintUserRegistration.PrintPassWord();
                                        var PassWord = Input.InputPassWord();
                                        var checkPassword = new PassWordNumberCheck(reg);
                                        var pass = checkPassword.PassWordnumberCheck(PassWord);
                                        if (pass == false)
                                        {
                                            PassWordCheck = "1";
                                            continue;
                                        }
                                        // Check Bill Numb
                                        string billNumb = "1";
                                        while (billNumb == "1")
                                        {
                                            PrintUserRegistration.BillNumber();
                                            var BillNumber = Input.BillNumber();
                                            var billcheck = new BillNumbCheck();
                                            var bill = billcheck.BillNumberCheck(reg, BillNumber);
                                            if (bill == false)
                                            {
                                                billNumb = "1";
                                                continue;

                                            }
                                            //check Balance
                                            string balanceNumbCheck = "1";
                                            while (balanceNumbCheck == "1")
                                            {
                                                PrintUserRegistration.Balance();
                                                var Balance = Input.Balance();
                                                var balanceCheck = new BalanceCheck();
                                                var checkBalance = balanceCheck.BalanceChecks(reg, Balance);
                                                if (checkBalance == false)
                                                {
                                                    balanceNumbCheck = "1";
                                                    continue;
                                                }

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
                                                //Added User & Card Result
                                                AddUserBase.Message(ResultMessegeUser);
                                                addCardDataBase.Message(ResultMessegeCard);
                                                print.PrintMainMany();
                                                print.PrintLoggOutSystem();
                                                string ChooseNextStage = Console.ReadLine();
                                                // Main Many or Log Out
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //Sign In
                if (InputRegistration == "2")
                {
                    string cardNumbcheck = "1";
                    while (cardNumbcheck == "1")
                    {
                        var PrintUserInfo = new PrintUserRegistrationForm();
                        var InputSignIn = new Input();
                        var Input = new InputUser(InputSignIn);
                        PrintUserInfo.PrintCardNumber();
                        var InputCardNumber = Input.InputCardNumber();
                        var cardNumChek = new CardNumberUnique();
                        var rreg = new Regexs();
                        var cardNumb = cardNumChek.CardNumberNumbersCheck(rreg, InputCardNumber);
                        if (cardNumb == false)
                        {
                            cardNumbcheck = "1";
                            continue;
                        }
                        // Password Numb Check
                        string passNumbChek = "1";
                        int WrongPasscount = 0;
                        while (passNumbChek == "1")
                        {

                            PrintUserInfo.PrintPassWord();
                            var InputPassword = Input.InputPassWord();
                            var PassCheck = new PassWordNumberCheck(rreg);
                            var pass = PassCheck.PassWordnumberCheck(InputPassword);
                            if (pass == false)
                            {
                                passNumbChek = "1";
                                WrongPasscount++;

                                //block Card
                                if (WrongPasscount == 3)
                                {
                                    var blockCard = new BlockCards();
                                    var ccontex = new Context();
                                    blockCard.AddBlockCard(ccontex, InputCardNumber);
                                    blockCard.PrintBlockCard(InputCardNumber);
                                    return;
                                }
                                continue;
                            }
                            var Context = new Context();
                            var Checkuser = new CheckUserSignIn(InputCardNumber, InputPassword, Context);
                            var UserId = Checkuser.GetDbId();
                            if(UserId == 0)
                            {
                                Console.WriteLine("Wrong PassWord Or Card Number Please Try Again");

                                continue;
                            }
                            ////////////////////////////////////////////////////////////////////////////////
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
                                // Balance Numb Check
                                string balanNumbCheck = "1";
                                while (balanNumbCheck == "1")
                                {
                                    Console.WriteLine("Enter money");
                                    decimal money = decimal.Parse(Console.ReadLine());
                                    var balanceNumbCheck = new BalanceCheck();
                                    var bal = balanceNumbCheck.BalanceChecks(rreg, money);
                                    if (bal == false)
                                    {
                                        balanNumbCheck = "1";
                                        continue;
                                    }
                                    var CardIdd = new UserCardId(Context, InputCardNumber, InputPassword);
                                    var context = new Context();
                                    var BillId = new UserBillId(CardIdd, context);
                                    var Withdraw = new Withdraw(money, CardId, BillId, context, PrintBalance);
                                    Withdraw.WithDraw();
                                }

                            }
                            // Change Password Numb Check
                            else if (WithdrawPassword == "2")
                            {
                                //Old Pass Check
                                string oldPassChange = "1";
                                while (oldPassChange == "1")
                                {
                                    var PassWordChangeContex = new Context();
                                    var PasswordChangeInput = new Input();
                                    var userId = new CheckUserSignIn(InputCardNumber, InputPassword, PassWordChangeContex);
                                    var PassWordChange = new PassWordChangee(userId, InputCardNumber, InputPassword, PassWordChangeContex, PasswordChangeInput);
                                    PassWordChange.PrintOldPassword();
                                    var inputPass = PassWordChange.InputOldPassword();
                                    var passNumbCheck = new PassWordNumberCheck(rreg);
                                    var passs = passNumbCheck.PassWordnumberCheck(inputPass);
                                    if (passs == false)
                                    {
                                        oldPassChange = "1";
                                        continue;

                                    }
                                    // New Pass Check
                                    string newPassCheck = "1";
                                    while (newPassCheck == "1")
                                    {
                                        PassWordChange.PrintNewPassWord();
                                        var newPassword = PassWordChange.InputNewPassword();
                                        var newPass = passNumbCheck.PassWordnumberCheck(newPassword);
                                        if (newPass == false)
                                        {
                                            newPassCheck = "1";
                                            continue;
                                        }
                                        PassWordChange.UpdateNewPassWord(newPassword);
                                    }
                                }

                            }

                        }

                    }

                }
                else if (InputRegistration == "3")
                {
                    //Card Number Check
                    string cardNumbcheck = "1";
                    while (cardNumbcheck == "1")
                    {
                        var CardNumber = new BlockCards();
                        CardNumber.PrintCardNumber();
                        var cardNumberInput = new Input();
                        var inputCardNumber = CardNumber.InputCardNumber(cardNumberInput);
                        var cardNumbcheckFunction = new CardNumberUnique();
                        var regg = new Regexs();
                        var cardNumbfunction = cardNumbcheckFunction.CardNumberNumbersCheck(regg, inputCardNumber);
                        if (cardNumbfunction == false)
                        {
                            cardNumbcheck = "1";
                            continue;
                        }
                        CardNumber.PrintBlockCard(inputCardNumber);
                        Context ccon = new Context();
                        var UserId = new GetUserIdFromCardNumber(ccon, inputCardNumber);
                        CardNumber.PrintBlockUserInfo(ccon, UserId);
                    }

                }
                else
                {
                    var PrintWrongNumber = new Pprint();
                    PrintWrongNumber.Print("Wrong Number");
                    wrongNumberMain = "1";
                }


            }

            Console.ReadKey();
        }

    }














}

