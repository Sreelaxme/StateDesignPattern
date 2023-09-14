/******************************************************************************
* Filename    = PinEnteredState.cs
*
* Author      = Sreelaxme
* 
* Product     = ATM
* 
* Project     = ATMStateMachine
*
* Description =  Represents the state of the ATM when a valid PIN has been entered.
*****************************************************************************/
namespace ATMStateMachine
{
    /// <summary>
    /// Represents the state of the ATM when a valid PIN has been entered.
    /// </summary>
    internal class PinEnteredState : IATMState
    {
        private readonly ATMContext _atmContext;

        /// <summary>
        /// Initializes a new instance of the PinEnteredState class.
        /// </summary>
        /// <param name="atmContext">The ATM context associated with this state.</param>
        public PinEnteredState(ATMContext atmContext) 
        {
            _atmContext = atmContext;
        }

        /// <summary>
        /// Checks and displays the account balance associated with the current PIN.
        /// </summary>
        /// <returns>The account balance </returns>
        public int CheckBalance()
        {
            string currPin= _atmContext._currentPIN;
            int balance = _atmContext._balances[currPin];    
            Console.WriteLine($"Balance amount {balance}");
            return balance;
        }
        /// <summary>
        /// Invalid operation: Entering a new PIN is not allowed in this state.
        /// </summary>
        /// <param name="pin">The PIN entered by the user.</param>
        /// <returns>Always returns false as PIN entry is not allowed in this state.</returns>
        public bool EnterPIN(string pin)
        {
            return false;
        }

        /// <summary>
        /// Invalid operation: Card insertion is not allowed in this state.
        /// </summary>
        /// <returns>Always returns false as card insertion is not allowed in this state.</returns>
        public bool InsertCard()
        {
            return false;
        }
        /// <summary>
        /// Removes the card from the ATM and transitions to the NoCardState.
        /// </summary>
        /// <returns>True if card removal is successful and the state changes, otherwise false.</returns>
        public bool RemoveCard()
        {
            Console.WriteLine("Card removed");
            return true;
        }
        /// <summary>
        /// Attempts to withdraw cash from the ATM, updating the balance if sufficient funds are available.
        /// </summary>
        /// <param name="amount">The amount of cash to withdraw.</param>
        /// <returns>True if cash withdrawal is successful, otherwise false.</returns>
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
