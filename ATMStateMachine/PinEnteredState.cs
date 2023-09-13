using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStateMachine
{
    internal class PinEnteredState : IATMState
    {
        private readonly ATMContext _atmContext;
        public PinEnteredState(ATMContext atmContext) 
        {
            _atmContext = atmContext;
        }
        public int CheckBalance()
        {
            string currPin= _atmContext._currentPIN;
            int balance = _atmContext._balances[currPin];    
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
            string currPin = _atmContext._currentPIN;
            int balance = _atmContext._balances[currPin];
            if(balance-amount > 0)
            {
                _atmContext._balances[currPin] = balance - amount;
                Console.WriteLine( "Amount withdrawn" );
                return true;
            }
            return false;
        }
    }
}
