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
            var atm = new ATMContext();

            // Test inserting a card
            Assert.IsTrue(atm.InsertCard(), "Failed to insert card.");

            // Test entering a PIN
            Assert.IsTrue(atm.EnterPIN("123456") ,"Entered incorrect PIN.");

            // Test checking the balance
            Assert.AreEqual(2500, atm.CheckBalance(), "Balance check failed.");

            // Test withdrawing cash
            Assert.IsTrue(atm.WithDrawCash(500), "Failed to withdraw cash ");

            // Test checking the updated balance
            Assert.AreEqual(2000, atm.CheckBalance(), "Couldn't check balance");

            // Test removing the card
            Assert.IsTrue(atm.RemoveCard(), "Removal card not successful");

            // Ensure that after removing the card, we are back to the NoCardState
            Assert.IsInstanceOfType(atm.currentState, typeof(NoCardState), "ATM state is not in NoCardState.");
        }
        [TestMethod]
        public void WithdrawBeforePIN()
        {
            var atm = new ATMContext();

            // Test inserting a card
            Assert.IsTrue(atm.InsertCard(), "Failed to insert card.");

            // Test withdrawing cash
            Assert.IsFalse(atm.WithDrawCash(500), "Failed to withdraw cash with incorrect PIN.");

            //Entering PIN and trying again
            Assert.IsTrue(atm.EnterPIN("123456"), "Wrong PIN ");

            //Now trying to withdraw cash
            Assert.IsTrue(atm.WithDrawCash(500), "Failed to withdraw cash with incorrect PIN.");



        }
        [TestMethod]
        public void InsufficientBalance()
        {
            var atm = new ATMContext();

            // Test inserting a card
            Assert.IsTrue(atm.InsertCard(), "Failed to insert card.");

            // Test entering a PIN
            Assert.IsTrue(atm.EnterPIN("123456"), "Entered incorrect PIN.");

            // Test withdrawing cash
            Assert.IsFalse(atm.WithDrawCash(5000), "Failed to withdraw cash ");

            
            
        }
        [TestMethod]
        public void IncorrectPIN()
        {
            var atm = new ATMContext();

            // Test inserting a card
            Assert.IsTrue(atm.InsertCard(), "Failed to insert card.");

            // Test entering a PIN
            Assert.IsFalse(atm.EnterPIN("123"), "Entered incorrect PIN.");

 
        }
        [TestMethod]
        public void SameState()
        {
            var atm = new ATMContext();

            // Test inserting a card
            Assert.IsTrue(atm.InsertCard(), "Failed to insert card.");

            // Test inserting a card
            Assert.IsFalse(atm.InsertCard(), "Failed to insert card.");

            // Test entering a PIN
            Assert.IsFalse(atm.EnterPIN("1234"), "Entered incorrect PIN.");

            // Test entering a PIN
            Assert.IsTrue(atm.EnterPIN("123456"), "Entered incorrect PIN.");

            // Test withdrawing cash
            Assert.IsTrue(atm.WithDrawCash(500), "Failed to withdraw cash ");

            // Test removing the card
            Assert.IsTrue(atm.RemoveCard(), "Removal card not successful");

            // Test checking the updated balance
            Assert.AreEqual(2000, atm.CheckBalance(), "Couldn't check balance");


        }
    }
}