using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public class Enemy : GameUnit
    {
        protected string _enemyName = "";
        protected string _attackName = "";
        protected int _attackDamage;

        public string GetEnemyName() { return _enemyName; }
        public string GetAttackName() { return _attackName; }
        public int GetAttackDamage() { return _attackDamage; }
    }
}
