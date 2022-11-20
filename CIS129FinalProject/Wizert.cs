using System;
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
        protected WizertState state;

        public Wizert()
        {
            _maxHp = 100;
            _hp = _maxHp;
            _maxMp = 200;
            _mp = _maxMp;
            state = WizertState.Spawn;
        }

        public override void Update()
        {
            switch (state)
            {
                // The starting state for when the Wizert first spawns in.
                case WizertState.Spawn:
                    Console.WriteLine("You, the Wizert, have found yourself within the Dungeon yet again, ...");
                    state = WizertState.Search;
                    break;
                
                // The Wizert deciding which direction to move to.
                case WizertState.Move:

                    break;
                
                // The Wizert searching through the room to see what's here (most states are connected to this one).
                case WizertState.Search:

                    break;
                
                // The Wizert is battling an Enemy.
                case WizertState.Battle:

                    break;
                
                // The Wizert consumes a Powerup when there is one and no Enemies are present.
                case WizertState.UsePowerup:

                    break;
                
                // The Wizert got to the Exit Room with no Enemies in it and wins!
                case WizertState.Exit:

                    break;
               
                // The Wizert's HP reaches 0 or less and losses.
                case WizertState.Die:

                    break;
               
                // If somehow we get an invalid Wizert State
                default:
                    Console.WriteLine("A critical error has occured {Wizert State}");
                    break;
            }
        }

        public WizertState GetState()
        {
            return state;
        }
    }
}
