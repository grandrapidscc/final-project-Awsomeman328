using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public class Room: GameObject
    {
        protected bool _isExit;
        protected string _description;

        public Room(bool isExit, string desc)
        {
            _isExit = isExit;
            _description = desc;
        }

        public override void Update()
        {

        }

        public bool IsExit() { return _isExit; }
        public string GetDescription() { return _description; }
    }
}
