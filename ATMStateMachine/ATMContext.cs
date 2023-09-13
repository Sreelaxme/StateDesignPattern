using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStateMachine
{

    public class ATMContext : IATMState
    {
        public IATMState currentState;
        //public int accountBalance { get; private set; } = 2500;

        public readonly Dictionary<string , int> _balances = new();
        public string _currentPIN;
        
        public ATMContext( Dictionary<string , int> balances )
        {
            // Initialize with a default state, such as NoCardState
            currentState = new NoCardState(this);
            _balances = balances;
            _currentPIN = "0";
        }

        public bool InsertCard()
        {
            bool result =  currentState.InsertCard();
            if(result)
            {
                currentState = new CardInsertedState(this);
            }
            return result;
            
        }

        public bool EnterPIN(string pin)
        {
            bool result = currentState.EnterPIN(pin);
            if(result)
            {
                _currentPIN = pin;
                currentState =new PinEnteredState(this);

            }
            return result;
                
        }

        public bool WithDrawCash(int amount)
        {
            bool result = currentState.WithDrawCash(amount);
            if(result) 
            {
                //accountBalance -= amount;
                
                currentState = new CashWithdrawalState(this);
                    
                
            }
            return result;

        }
        public bool RemoveCard() 
        {
            bool result = currentState.RemoveCard();
            if(result ) 
            {
                currentState = new NoCardState(this);
            }
            return result;
        }
        public int CheckBalance()
        {
            if (currentState.CheckBalance()!=0)
            {
                //Console.WriteLine($"Your account balance is from context {accountBalance}");
                return _balances[_currentPIN];
            }
                
            return -1;
        }
        // Other methods and properties related to the ATM context
    }

}
