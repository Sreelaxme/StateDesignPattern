using System;
using ATMStateMachine;
namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            IATMState atmMachine = new ATMContext();
            
            Console.WriteLine();
            atmMachine.InsertCard();

            atmMachine.EnterPIN("123456");
            atmMachine.CheckBalance();
            atmMachine.WithDrawCash(250);
            atmMachine.CheckBalance();
            atmMachine.RemoveCard();
            atmMachine.CheckBalance();

            Console.WriteLine();
            
        }
    }
}