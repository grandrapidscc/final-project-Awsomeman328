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
        protected (int, int) previousRoom;
        protected WizertState currentState;
        protected WizertState nextState;

        public Wizert()
        {
            _maxHp = 100;
            _hp = _maxHp;
            _unitName = "Wizert";
            _attackName = "Fireball";
            _attackDamage = 5;
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

        public (int, int) GetPreviousRoom() { return previousRoom; }

        public void SetPreviousRoom((int, int) newPrevious) { previousRoom = newPrevious; }

        public int GetMP() { return _mp; }
        public int GetMaxMP() { return _maxMp; }

        public void AdjustMP(int amount)
        {
            _mp += amount;
            if (_mp > _maxMp) _mp = _maxMp;
            if (_mp < 0) _mp = 0;
            if (amount > 0)
            {
                Console.Write($"You have restored {amount} MP. ");
            }
            else if (amount < 0)
            {
                Console.Write($"You have expended {-amount} MP. ");
            }
            else
            {
                Console.Write("... It appears to not have had any effect. ");

            }
            Console.WriteLine($"Your current MP is now {_mp} out of {_maxMp}");
        }

        public bool CanCastFireball()
        {
            // Still need to check if the wizert has enough MP to be able to cast any of its spell options, ...
            if (GetMP() >= 3)
            {
                Console.Write("You cast a Fireball that burns the enemy. ");
                AdjustMP(-3);
                return true;
            }
            else
            {
                Console.Write("You try to cast a Fireball, but find that you do not have enough MP to finish casting the spell. ");
                Console.WriteLine($"You currently have {GetMP()} MP left.");
                return false;
            }
        }

        public void CastHealSpell()
        {
            if (GetHP() >= GetMaxHP())
            {
                Console.Write("You think about healing yourself, but realize that you are currently at full HP. ");
                Console.WriteLine($"You currently have {GetHP()} HP and {GetMP()} MP left.");
            }
            else if (GetMP() >= 5)
            {
                Console.Write("You cast a Heal spell to restore your wounds. ");
                AdjustMP(-5);
                AdjustHP(3);
                Console.WriteLine($"You now have {GetHP()} HP and {GetMP()} MP.");
            }
            else
            {
                Console.Write("You try to cast a heal, but find that you do not have enough MP to finish casting the spell. ");
                Console.WriteLine($"You currently have {GetMP()} MP left.");
            }
        }
    }
}
