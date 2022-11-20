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

        public Room(bool isExit)
        {
            _isExit = isExit;
            _description = "You are in a room, and this is a test string to make sure that everything is working as intended.";
        }

        public override void Update()
        {

        }
    }
}
