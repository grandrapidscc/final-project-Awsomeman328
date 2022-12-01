﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public class Wizert : GameUnit
    {
        protected int _mp;
        protected int _maxMp;
        public enum WizertState
        {
            Spawn,
            Move,
            Search,
            Battle,
            UsePowerup,
            Exit,
            Die
        }
        protected WizertState currentState;
        protected WizertState nextState;

        public Wizert()
        {
            _maxHp = 100;
            _hp = _maxHp;
            _unitName = "Wizert";
            _maxMp = 200;
            _mp = _maxMp;
            currentState = WizertState.Spawn;
        }

        public override void Update()
        {
            if (nextState != currentState) currentState = nextState;
        }

        public WizertState GetState()
        {
            return currentState;
        }

        public void SetNextState(WizertState inState)
        {
            nextState = inState;
        }

        

        public int GetMP() { return _mp; }
        public int GetMaxMP() { return _maxMp; }

        public void AdjustMP(int amount)
        {
            _mp += amount;
            if (_mp > _maxMp) _mp = _maxMp;
            if (_mp < 0) _mp = 0;
            if (amount > 0)
            {
                Console.WriteLine($"The {GetUnitName()} has restored {amount} MP.");
            }
            else if (amount < 0)
            {
                Console.WriteLine($"The {GetUnitName()} has expended {-amount} MP.");
            }
            else
            {
                Console.WriteLine("... It appears to not have had any effect.");

            }
            Console.WriteLine($"The {GetUnitName()}'s current MP is now {_mp} out of {_maxMp}");
        }
    }
}
