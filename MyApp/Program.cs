using System;
using ATMStateMachine;
namespace MyApp
{
    public class Program
    {
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
