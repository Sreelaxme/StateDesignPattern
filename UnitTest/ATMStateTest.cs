using System;
using ATMStateMachine;
namespace UnitTest
{
    [TestClass]
    public class ATMStateTest
    {
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


            // Test inserting a card
            Assert.IsTrue(atm.InsertCard(), "Failed to insert card.");

            // Test entering a PIN
            Assert.IsTrue(atm.EnterPIN("1234") ,"Entered incorrect PIN.");

            // Test checking the balance
            Assert.AreEqual(2500, atm.CheckBalance(), "Balance check failed.");

            // Test withdrawing cash
            Assert.IsTrue(atm.WithDrawCash(500), "Failed to withdraw cash ");

            // Test checking the updated balance
            Assert.AreEqual(2000, atm.CheckBalance(), "Couldn't check balance");

            // Test removing the card
            Assert.IsTrue(atm.RemoveCard(), "Removal card not successful");

            
        }
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


            // Test inserting a card
            Assert.IsTrue(atm.InsertCard(), "Failed to insert card.");

            // Test withdrawing cash
            Assert.IsFalse(atm.WithDrawCash(500), "Failed to withdraw cash with incorrect PIN.");

            //Entering PIN and trying again
            Assert.IsTrue(atm.EnterPIN("1234"), "Wrong PIN ");

            //Now trying to withdraw cash
            Assert.IsTrue(atm.WithDrawCash(500), "Failed to withdraw cash with incorrect PIN.");



        }
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

            // Test inserting a card
            Assert.IsTrue(atm.InsertCard(), "Failed to insert card.");

            // Test entering a PIN
            Assert.IsTrue(atm.EnterPIN("1234"), "Entered incorrect PIN.");

            // Test withdrawing cash
            Assert.IsFalse(atm.WithDrawCash(5000), "Failed to withdraw cash ");

            
            
        }
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


            // Test inserting a card
            Assert.IsTrue(atm.InsertCard(), "Failed to insert card.");

            // Test entering a PIN
            Assert.IsFalse(atm.EnterPIN("123"), "Entered incorrect PIN.");

 
        }
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


            // Test inserting a card
            Assert.IsTrue(atm.InsertCard(), "Failed to insert card.");

            // Test inserting a card
            Assert.IsFalse(atm.InsertCard(), "Failed to insert card.");

            // Test entering a PIN
            Assert.IsFalse(atm.EnterPIN("12344"), "Entered incorrect PIN.");

            // Test entering a PIN
            Assert.IsTrue(atm.EnterPIN("1234"), "Entered incorrect PIN.");

            // Test withdrawing cash
            Assert.IsTrue(atm.WithDrawCash(500), "Failed to withdraw cash ");

            // Test removing the card
            Assert.IsTrue(atm.RemoveCard(), "Removal card not successful");

            // Test checking the updated balance
            Assert.AreNotEqual(2000, atm.CheckBalance(), "Couldn't check balance");


        }
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

            // Test inserting a card
            Assert.IsTrue( atm.InsertCard() , "Failed to insert card." );

            // Test entering a PIN
            Assert.IsTrue( atm.EnterPIN( "1234" ) , "Entered incorrect PIN." );

            // Test withdrawing cash
            Assert.IsTrue( atm.WithDrawCash(1000) , "Failed to withdraw cash " );
            // Test withdrawing cash
            Assert.IsFalse( atm.WithDrawCash( 1500 ) , "Failed to withdraw cash2 " );
            
        }
    }
}
