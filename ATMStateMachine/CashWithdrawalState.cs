using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStateMachine
{
    internal class CashWithdrawalState : IATMState
    {
        private readonly ATMContext _atmContext;
        public CashWithdrawalState(ATMContext context)
        {
            _atmContext = context;
        }
        public int CheckBalance()
        {
            string currPin = _atmContext._currentPIN;
            int balance = _atmContext._balances[currPin];
            Console.WriteLine($"Balance amount is {balance}");
            return 1;
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
            return false;
            
        }
    }
}
