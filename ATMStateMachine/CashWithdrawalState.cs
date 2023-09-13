using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStateMachine
{
    internal class CashWithdrawalState : IATMState
    {
        private ATMContext atmContext;
        public CashWithdrawalState(ATMContext context)
        {
            atmContext = context;
        }
        public int CheckBalance()
        {
            int balance = atmContext.accountBalance;
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
