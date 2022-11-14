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

        public Wizert()
        {
            _maxHp = 100;
            _hp = _maxHp;
            _maxMp = 200;
            _mp = _maxMp;
        }
    }
}
