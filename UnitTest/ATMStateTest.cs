/******************************************************************************
* Filename    = ATMStateTest.cs
*
* Author      = Sreelaxme
* 
* Product     = ATM
* 
* Project     = UnitTest
*
* Description =  Unit tests for the ATM state machine.
*****************************************************************************/
using ATMStateMachine;
namespace UnitTest
{
    /// <summary>
    /// Unit tests for the ATM state machine.
    /// </summary>
    [TestClass]
    public class ATMStateTest
    {
        /// <summary>
        /// Test a simple ATM transaction scenario.
        /// </summary>
        [TestMethod]
        public void SimpleTest()
        {

            var initialBalances = new Dictionary<string , int>
            {
                { "1234", 2500 },
                { "2345", 3500 },
                // Add more accounts as needed
            };

            var atm = new ATMContext( initialBalances );

            atm.InsertCard();
            atm.EnterPIN( "1234" );
            atm.WithDrawCash(500);
           
            Assert.AreEqual(2000, atm.CheckBalance(), "Couldn't check balance");

            atm.RemoveCard();

            
        }

        /// <summary>
        /// Test attempting to withdraw cash before entering the correct PIN.
        /// </summary>
        [TestMethod]
        public void WithdrawBeforePIN()
        {
            var initialBalances = new Dictionary<string , int>
            {
                { "1234", 2500 },
                { "2345", 3500 },
                // Add more accounts as needed
            };

            var atm = new ATMContext( initialBalances );


            atm.InsertCard();

            // Test withdrawing cash
            Assert.IsFalse(atm.WithDrawCash(500), "Failed to withdraw cash with incorrect PIN.");

            



        }

        /// <summary>
        /// Test attempting to withdraw more cash than the account balance.
        /// </summary>
        [TestMethod]
        public void InsufficientBalance()
        {
            var initialBalances = new Dictionary<string , int>
            {
                { "1234", 2500 },
                { "2345", 3500 },
                // Add more accounts as needed
            };

            var atm = new ATMContext( initialBalances );

            atm.InsertCard();
            atm.EnterPIN( "1234" );

            // Test withdrawing cash
            Assert.IsFalse(atm.WithDrawCash(5000), "Failed to withdraw cash ");

            
            
        }

        /// <summary>
        /// Test entering an incorrect PIN.
        /// </summary>
        [TestMethod]
        public void IncorrectPIN()
        {
            var initialBalances = new Dictionary<string , int>
            {
                { "1234", 2500 },
                { "2345", 3500 },
                // Add more accounts as needed
            };

            var atm = new ATMContext( initialBalances );


            atm.InsertCard();
            
            // Test entering a PIN
            Assert.IsFalse(atm.EnterPIN("123"), "Entered incorrect PIN.");

 
        }
        /// <summary>
        /// Test performing going to the state again.
        /// </summary>
        [TestMethod]
        public void SameState()
        {
            var initialBalances = new Dictionary<string , int>
            {
                { "1234", 2500 },
                { "2345", 3500 },
                // Add more accounts as needed
            };

            var atm = new ATMContext( initialBalances );

            atm.InsertCard();
           
           
            // Test inserting a card
            Assert.IsFalse(atm.InsertCard(), "Failed to insert card.");

           

        }

        /// <summary>
        /// Test multiple cash withdrawals within the same PIN-entered state.
        /// </summary>
        [TestMethod]
        public void MultipleWithdrawal()
        {
            var initialBalances = new Dictionary<string , int>
            {
                { "1234", 2500 },
                { "2345", 3500 },
                // Add more accounts as needed
            };

            var atm = new ATMContext( initialBalances );

            atm.InsertCard();
            atm.EnterPIN( "1234" );
            atm.WithDrawCash( 1000 );
            
            // Test withdrawing cash
            Assert.IsFalse( atm.WithDrawCash( 1500 ) , "Failed to withdraw cash2 " );
            
        }
    }
}
