/******************************************************************************
* Filename    = CashWithdrawalState.cs
*
* Author      = Sreelaxme
* 
* Product     = ATM
* 
* Project     = ATMStateMachine
*
* Description =Represents the state of the ATM when a cash withdrawal operation has been initiated.
*****************************************************************************/
namespace ATMStateMachine
{
    /// <summary>
    /// Represents the state of the ATM when a cash withdrawal operation has been initiated.
    /// </summary>
    internal class CashWithdrawalState : IATMState
    {
        private readonly ATMContext _atmContext;
        /// <summary>
        /// Initializes a new instance of the CashWithdrawalState class.
        /// </summary>
        /// <param name="context">The ATM context associated with this state.</param>
        public CashWithdrawalState(ATMContext context)
        {
            _atmContext = context;
        }
        /// <summary>
        /// Checks and displays the account balance associated with the current PIN.
        /// </summary>
        /// <returns>Always returns 1 as it's used to indicate that the balance information is being displayed.</returns>
        public int CheckBalance()
        {
            string currPin = _atmContext._currentPIN;
            int balance = _atmContext._balances[currPin];
            Console.WriteLine($"Balance amount is {balance}");
            return 1;
        }

        /// <summary>
        /// Pin entry.
        /// </summary>
        /// <param name="pin">The PIN entered by the user.</param>
        /// <returns>Always returns false as PIN entry is not allowed in this state.</returns>
        public bool EnterPIN(string pin)
        {
            return false;
        }

        /// <summary>
        /// Card insertion.
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
        /// Cash withdrawal (cannot be initiated in this state).
        /// </summary>
        /// <param name="amount">The amount of cash to withdraw.</param>
        /// <returns>Always returns false as cash withdrawal is not allowed in this state.</returns>
        public bool WithDrawCash(int amount)
        {
            return false;
            
        }
    }
}
