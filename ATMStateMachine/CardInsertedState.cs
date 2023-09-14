/******************************************************************************
* Filename    = CardInsertedState.cs
*
* Author      = Sreelaxme
* 
* Product     = ATM
* 
* Project     = ATMStateMachine
*
* Description = Represents the state of the ATM when a card has been inserted.
*****************************************************************************/
namespace ATMStateMachine
{
    /// <summary>
    /// Represents the state of the ATM when a card has been inserted.
    /// </summary>
    internal class CardInsertedState : IATMState
    {
        
        private readonly ATMContext _atmContext;

        /// <summary>
        /// Initializes a new instance of the CardInsertedState class.
        /// </summary>
        /// <param name="atmContext">The ATM context associated with this state.</param>
        public CardInsertedState(ATMContext atmContext)
        {
            _atmContext = atmContext;
        }

        /// <summary>
        /// Always returns 0 as balance information is not available in this state.
        /// </summary>
        /// <returns>Always returns 0 as balance information is not available in this state.</returns>
        public int CheckBalance()
        {
            return 0;
        }

        /// <summary>
        /// Verifies if the entered PIN is correct and updates the state if it is.
        /// </summary>
        /// <param name="pin">The PIN entered by the user.</param>
        /// <returns>True if the PIN is correct and the state transitions to PinEnteredState, otherwise false.</returns>
        public bool EnterPIN(string pin)
        {
            //
            if (_atmContext._balances.ContainsKey(pin))
            {
                Console.WriteLine("Right PIN");
                return true;
            }
            Console.WriteLine("Wrong PIN");
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
        /// Cash withdrawal.
        /// </summary>
        /// <param name="amount">The amount of cash to withdraw.</param>
        /// <returns>Always returns false as cash withdrawal is not allowed in this state.</returns>
        public bool WithDrawCash(int amount)
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
    }
}
