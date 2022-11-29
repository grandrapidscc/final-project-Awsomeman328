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

        public int GetHP() { return _hp; }
        public int GetMaxHP() { return _maxHp; }

        // A positive amount is healing, a negative amount is damage.
        public void AdjustHP(int amount)
        {
            _hp += amount;
            if (_hp > _maxHp) _hp = _maxHp;
            if (_hp < 0) _hp = 0;
        }

        public override void Update()
        {

        }
    }
}
