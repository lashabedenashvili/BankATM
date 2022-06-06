using BankATM.UI.User_SignIn_ATM;
using Xunit;


namespace BankATM.Tests
{
    public  class CalculatorTest
    {    [Fact]
        public void Add_SimpleValueShouldCalculate()
        {
            //Arange
            int expected = 15;
            //Act
            var Calc=new Calculator();
            var result=Calc.add(7, 8);

            Assert.Equal(expected, result);
            
        }

    }
}
