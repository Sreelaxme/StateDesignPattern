/******************************************************************************
* Filename    = Program.cs
*
* Author      = Sreelaxme
* 
* Product     = ATM
* 
* Project     = MyApp
*
* Description =  Entry point for the ATM simulation application(Just for a trial).
*****************************************************************************/
using ATMStateMachine;
namespace MyApp
{
    /// <summary>
    /// Entry point for the ATM simulation application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method for the ATM simulation program.
        /// </summary>
        static void Main()
        {

            var initialBalances = new Dictionary<string , int>
            {
                { "1234", 2500 },
                { "2345", 3500 },
                // Add more accounts as needed
            };
            IATMState atmMachine = new ATMContext( initialBalances );

            

            Console.WriteLine();
            atmMachine.InsertCard();

            atmMachine.EnterPIN("1234");
            atmMachine.CheckBalance();
            atmMachine.WithDrawCash(250);
            atmMachine.CheckBalance();
            atmMachine.RemoveCard();
            atmMachine.CheckBalance();

            Console.WriteLine();
            
        }
    }
}
