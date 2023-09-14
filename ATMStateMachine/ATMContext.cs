/******************************************************************************
* Filename    = ATMContext.cs
*
* Author      = Sreelaxme
* 
* Product     = ATM
* 
* Project     = ATMStateMachine
*
* Description = Represents the context of an ATM.
*****************************************************************************/


namespace ATMStateMachine
{
    /// <summary>
    /// Represents the context of an ATM (Automated Teller Machine) using the State design pattern.
    /// </summary>
    public class ATMContext : IATMState
    {
        public IATMState currentState;
        public readonly Dictionary<string , int> _balances = new();
        public string _currentPIN;

        /// <summary>
        /// Initializes a new instance of the ATMContext class with the specified account balances.
        /// </summary>
        /// <param name="balances">A dictionary containing account balances associated with PINs.</param>
        public ATMContext( Dictionary<string , int> balances )
        {
            // Initialize with a default state, such as NoCardState
            currentState = new NoCardState(this);
            _balances = balances;
            _currentPIN = "0";
        }

        /// <summary>
        /// Attempts to insert a card into the ATM. The state can change only if card insertion is successful.
        /// </summary>
        /// <returns>True if card insertion is successful and the state changes, otherwise false.</returns>
        public bool InsertCard()
        {
            
            bool result =  currentState.InsertCard();
            if(result)
            {
                currentState = new CardInsertedState(this);
            }
            return result;
            
        }

        /// <summary>
        /// Attempts to enter a PIN into the ATM. The state can change only if PIN entry is successful.
        /// </summary>
        /// <param name="pin">The PIN entered by the user.</param>
        /// <returns>True if PIN entry is successful and the state changes, otherwise false.</returns>
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

        /// <summary>
        /// Attempts to withdraw cash from the ATM. The state can change only if cash withdrawal is successful.
        /// </summary>
        /// <param name="amount">The amount of cash to withdraw.</param>
        /// <returns>True if cash withdrawal is successful and the state changes, otherwise false.</returns>
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

        /// <summary>
        /// Attempts to remove the card from the ATM. The state can change only if card removal is successful.
        /// </summary>
        /// <returns>True if card removal is successful and the state changes, otherwise false.</returns>
        public bool RemoveCard() 
        {
            bool result = currentState.RemoveCard();
            if(result ) 
            {
                currentState = new NoCardState(this);
            }
            return result;
        }

        /// <summary>
        /// Checks and returns the account balance associated with the current PIN.
        /// </summary>
        /// <returns>The account balance if available, or -1 if not found.</returns>
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
