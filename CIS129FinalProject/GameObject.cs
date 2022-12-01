using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public abstract class GameObject
    {
        protected bool needsRemoved;

        public GameObject()
        {
            needsRemoved = false;
        }

        public abstract void Update();

        public void FlagForRemoval() { needsRemoved = true; }

    }
}
