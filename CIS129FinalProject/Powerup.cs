using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public class Powerup : GameObject
    {
        protected PotionType _potionType;
        protected int _restoreAmount;

        public enum PotionType
        {
            Health,
            Magika
        }

        public Powerup(PotionType potionType)
        {
            _potionType = potionType;
            if (_potionType == PotionType.Health) _restoreAmount = 10;
            else _restoreAmount = 20;
        }

        public override void Update()
        {

        }

        public PotionType GetPotionType() { return _potionType; }
        public int GetRestoreAmount() { return _restoreAmount; }
    }
}
