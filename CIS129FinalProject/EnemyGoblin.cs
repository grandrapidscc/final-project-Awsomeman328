using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public class EnemyGoblin : Enemy
    {
        public EnemyGoblin()
        {
            _unitName = "Goblin";
            _maxHp = 3;
            _hp = _maxHp;
            _attackName = "Body Slam";
            _attackDamage = 2;
        }
    }
}
