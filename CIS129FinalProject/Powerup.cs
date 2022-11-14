using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public class Powerup : GameObject
    {
        protected PotionTypes _potionType;

        public enum PotionTypes
        {
            Health,
            Magika
        }

        public Powerup(PotionTypes potionType)
        {
            _potionType = potionType;
        }
    }
}
