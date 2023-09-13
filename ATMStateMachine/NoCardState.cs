using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStateMachine
{
    public class NoCardState : IATMState
    {
        private ATMContext atmContext;
        public NoCardState(ATMContext atmContext)
        {
            this.atmContext = atmContext;
        }

        public int CheckBalance()
        {
            Console.WriteLine("No card");
            return 0;
        }

        public bool EnterPIN(string pin)
        {
            return false;
        }

        public bool InsertCard()
        {
            Console.WriteLine("Card inserted");
            return true;
        }

        public bool WithDrawCash(int amount)
        {
            return false;
        }
        public bool RemoveCard() 
        {
            return false;
        }
    }
}
