/******************************************************************************
* Filename    = IATMState.cs
*
* Author      = Sreelaxme
* 
* Product     = ATM
* 
* Project     = ATMStateMachine
*
* Description = Represents the interface for various states of an ATM
*****************************************************************************/
namespace ATMStateMachine
{
    /// <summary>
    /// Represents the interface for various states of an ATM (Automated Teller Machine).
    /// </summary>
    public interface IATMState
    {
        bool InsertCard();
        bool RemoveCard();
        bool EnterPIN(string pin);
        bool WithDrawCash(int amount);
        int CheckBalance();
    }
}
