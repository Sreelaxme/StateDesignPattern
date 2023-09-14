/******************************************************************************
* Filename    = NoCardState.cs
*
* Author      = Sreelaxme
* 
* Product     = ATM
* 
* Project     = ATMStateMachine
*
* Description = Represents the initial state of the ATM when no card has been inserted.
*****************************************************************************/
namespace ATMStateMachine
{
    /// <summary>
    /// Represents the initial state of the ATM when no card has been inserted.
    /// </summary>
    internal class NoCardState : IATMState
    {
        private readonly ATMContext _atmContext;

        /// <summary>
        /// Initializes a new instance of the NoCardState class.
        /// </summary>
        /// <param name="atmContext">The ATM context associated with this state.</param>
        public NoCardState(ATMContext atmContext)
        {
            _atmContext = atmContext;
        }

        /// <summary>
        /// Returns the account Balance.
        /// </summary>
        /// <returns>Always returns 0 as balance information is not available in this state.</returns>
        public int CheckBalance()
        {
            Console.WriteLine("No card");
            return 0;
        }

        /// <summary>
        /// Takes the PIN.
        /// </summary>
        /// <param name="pin">The PIN entered by the user.</param>
        /// <returns>Always returns false as PIN entry is not allowed in this state.</returns>
        public bool EnterPIN(string pin)
        {
            return false;
        }

        /// <summary>
        /// Allows card insertion and transitions to the CardInsertedState.
        /// </summary>
        /// <returns>True if card insertion is successful and the state changes, otherwise false.</returns>
        public bool InsertCard()
        {
            Console.WriteLine("Card inserted");
            return true;
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
        /// Card removal.
        /// </summary>
        /// <returns>Always returns false as card removal is not allowed in this state.</returns>
        public bool RemoveCard() 
        {
            return false;
        }
    }
}
