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

        public enum PotionType
        {
            Health,
            Magika
        }

        public Powerup(PotionType potionType)
        {
            _potionType = potionType;
        }

        public override void Update()
        {

        }

        public PotionType GetPotionType() { return _potionType; }
    }
}
