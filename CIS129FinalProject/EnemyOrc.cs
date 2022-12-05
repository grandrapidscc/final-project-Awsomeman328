using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public class EnemyOrc : Enemy
    {
        public EnemyOrc()
        {
            _unitName = "Orc";
            _maxHp = 5;
            _hp = _maxHp;
            _attackName = "Cleave";
            _attackDamage = 3;
        }
    }
}
