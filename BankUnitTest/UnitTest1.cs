namespace BankUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public BankAccount testAccount { get; set; }
        public decimal InitialBalance { get; set; }

        public UnitTest1()
        {
            InitialBalance = 500;
            testAccount = new BankAccount();
            testAccount.balance = InitialBalance;
        }

        [TestMethod]
        public void AccountWithdraw_SubstractFromBalance()
        {
            // Arrange
            decimal withdrawAmount = 200.75M;
            decimal assertedBalance = InitialBalance - withdrawAmount;

            // Act
            testAccount.Withdraw(withdrawAmount);

            // Assert
            Assert.AreEqual(assertedBalance, testAccount.balance);
        }

        [TestMethod]
        public void AccountWithdraw_ThrowsExceptionWhenArgumentGreaterThanBalance()
        {
            // Arrange
            decimal withdrawAmount = 700;
            decimal assertedBalance = InitialBalance - withdrawAmount;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                testAccount.Withdraw(withdrawAmount);
            });            
        }

        // deposit method tests
        // the ending balance should equal the current balance plus the deposit
        // throw an exception on a negative/0 deposit amount

        [TestMethod]
        public void AccountDeposit_AddsToBalance()
        {
            // arrange
            decimal depositAmount = 125.32M;
            decimal assertedBalance = depositAmount + InitialBalance;

            // act
            testAccount.Deposit(depositAmount);

            // assert
            Assert.AreEqual(assertedBalance, testAccount.balance);
        }

        [TestMethod]
        public void AccountDeposit_ThrowsExceptionOnZeroOrNegativeAmount()
        {
            // arrange
            decimal firstDepositAmount = 0;
            decimal secondDepositAmount = -123;

            // act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                testAccount.Deposit(firstDepositAmount);
            });
            Assert.ThrowsException<ArgumentException>(() =>
            {
                testAccount.Deposit(secondDepositAmount);
            });
        }
    }
}