﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMStateMachine
{
    internal class CardInsertedState : IATMState
    {
        readonly string _pin = "123456"; //Random
        private readonly ATMContext _atmContext;
        public CardInsertedState(ATMContext atmContext)
        {
            _atmContext = atmContext;
        }
        public int CheckBalance()
        {
            return 0;
        }

        public bool EnterPIN(string pin)
        {
            if (_pin == pin) 
            {
                Console.WriteLine("Right PIN");
                return true;
            }
            Console.WriteLine("Wrong PIN");
            return false;
        }

        public bool InsertCard()
        {
            return false;
        }

        public bool WithDrawCash(int amount)
        {
            return false;
        }
        public bool RemoveCard()
        {
            Console.WriteLine("Card removed");
            return true;
        }
    }
}
