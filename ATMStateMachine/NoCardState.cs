using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStateMachine
{
    internal class NoCardState : IATMState
    {
        private readonly ATMContext _atmContext;
        public NoCardState(ATMContext atmContext)
        {
            _atmContext = atmContext;
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
