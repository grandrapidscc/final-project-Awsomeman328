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
        protected string _attackName;
        protected int _attackDamage;

        public GameUnit()
        {
            _unitName = "";
            _attackName = "";
        }

        public int GetHP() { return _hp; }
        public int GetMaxHP() { return _maxHp; }
        public string GetUnitName() { return _unitName; }
        public string GetAttackName() { return _attackName; }
        public int GetAttackDamage() { return _attackDamage; }

        // A positive amount is healing, a negative amount is damage.
        public void AdjustHP(int amount)
        {
            _hp += amount;
            if (_hp > _maxHp) _hp = _maxHp;
            if (_hp < 0) _hp = 0;
            bool isWizert = false;
            if (Wizert.ReferenceEquals(this.GetType(), new Wizert().GetType())) isWizert = true;
            if (amount > 0)
            {
                if (isWizert) Console.Write($"You have healed {amount} HP. ");
                else Console.Write($"The {GetUnitName()} has healed {amount} HP. ");
            }
            else if (amount < 0)
            {
                if (isWizert) Console.Write($"You have taken {-amount} damage. ");
                else Console.Write($"The {GetUnitName()} has taken {-amount} damage. ");
            }
            else
            {
                Console.Write("... It appears to not have had any effect. ");

            }
            if (isWizert) Console.WriteLine($"Your current HP is now {_hp} out of {_maxHp}");
            else Console.WriteLine($"The {GetUnitName()}'s current HP is now {_hp} out of {_maxHp}");
        }

        public override void Update()
        {

        }
    }
}
