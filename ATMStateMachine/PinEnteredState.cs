using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStateMachine
{
    internal class PinEnteredState : IATMState
    {
        private ATMContext atmContext;
        public PinEnteredState(ATMContext atmContext) 
        {
            this.atmContext = atmContext;
        }
        public int CheckBalance()
        {
            int balance = atmContext.accountBalance;    
            Console.WriteLine($"Balance amount {balance}");
            return balance;
        }

        public bool EnterPIN(string pin)
        {
            return false;
        }

        public bool InsertCard()
        {
            return false;
        }

        public bool RemoveCard()
        {
            Console.WriteLine("Card removed");
            return true;
        }

        public bool WithDrawCash(int amount)
        {
            Console.WriteLine("Amount withdrawn");
            return true;
        }
    }
}
