using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStateMachine
{
    public interface IATMState
    {
        bool InsertCard();
        bool RemoveCard();
        bool EnterPIN(string pin);
        bool WithDrawCash(int amount);
        int CheckBalance();
    }
}
