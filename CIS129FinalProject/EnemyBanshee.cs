using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public class EnemyBanshee : Enemy
    {
        public EnemyBanshee()
        {
            _unitName = "Banshee";
            _maxHp = 8;
            _hp = _maxHp;
            _attackName = "Screech";
            _attackDamage = 5;
        }
    }
}
