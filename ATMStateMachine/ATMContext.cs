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
        public int accountBalance = 2500;
        public ATMContext()
        {
            // Initialize with a default state, such as NoCardState
            currentState = new NoCardState(this);
        }

        public void SetState(IATMState state)
        {
            currentState = state;
           
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
                currentState =new PinEnteredState(this);

            }
            return result;
                
        }

        public bool WithDrawCash(int amount)
        {
            bool result = currentState.WithDrawCash(amount);
            if(result) 
            {
                accountBalance -= amount;
                if (accountBalance>0)
                {
                    currentState = new CashWithdrawalState(this);
                    
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                    return false;
                }
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
                return accountBalance;
            }
                
            return -1;
        }
        // Other methods and properties related to the ATM context
    }

}
