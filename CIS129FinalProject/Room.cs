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
        protected Wizert? wizert;
        protected Enemy? enemy;
        protected Powerup? powerup;

        public Room(bool isExit = false, string desc = "The room is hard to see in the current light. You take a moment for your eyes to adjust to the darkness.")
        {
            _isExit = isExit;
            _description = desc;
            wizert = null;
            enemy = null;
            powerup = null;
        }

        public override void Update()
        {

        }

        public void SetExit(bool newValue) { _isExit = newValue; }
        public bool IsExit() { return _isExit; }
        public void SetDescription(string newValue) { _description = newValue; }
        public string GetDescription() { return _description; }

        public void WizertEnters(Wizert wizertIn)
        {
            if (wizert == null)
            {
                wizert = wizertIn;
            }
            else
            {
                Console.WriteLine("A fatal error has occured, tried to put a Wizert in a room that already has a Wizert, ...");
            }
        }
        public Wizert? GetWizert() { return wizert; }
        public void WizertExits() { wizert = null; }
        public Room TransferWizertsToOtherRoom(Room otherRoom)
        {
            otherRoom.WizertEnters(GetWizert());
            WizertExits();
            return otherRoom;
        }

        public void SetEnemy(Enemy? enemyIn) { enemy = enemyIn; }
        public Enemy? GetEnemy() { return enemy; }
        public void SetPowerup(Powerup? powerupIn) { powerup = powerupIn; }
        public Powerup? GetPowerup() { return powerup; }
    }
}
