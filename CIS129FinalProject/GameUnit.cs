using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public class GameUnit : GameObject
    {
        protected int _hp;
        protected int _maxHp;
        protected string _unitName;

        public GameUnit()
        {
            _unitName = "";
        }

        public int GetHP() { return _hp; }
        public int GetMaxHP() { return _maxHp; }
        public string GetUnitName() { return _unitName; }

        // A positive amount is healing, a negative amount is damage.
        public void AdjustHP(int amount)
        {
            _hp += amount;
            if (_hp > _maxHp) _hp = _maxHp;
            if (_hp < 0) _hp = 0;
            if (amount > 0)
            {
                Console.WriteLine($"The {GetUnitName()} has healed {amount} HP.");
            }
            else if (amount < 0)
            {
                Console.WriteLine($"The {GetUnitName()} has taken {-amount} damage.");
            }
            else
            {
                Console.WriteLine("... It appears to not have had any effect.");

            }
            Console.WriteLine($"The {GetUnitName()}'s current HP is now {_hp} out of {_maxHp}");
        }

        public override void Update()
        {

        }
    }
}
