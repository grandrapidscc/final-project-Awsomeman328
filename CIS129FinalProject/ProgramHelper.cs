using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS129FinalProject
{
    public static class ProgramHelper
    {
        public static bool ValidateUserInput(string input)
        {
            if (!char.TryParse(input, out char _1))
            {
                Console.WriteLine("Invalid input detected: <Must be a single digit number>. Please try again");
                return false;
            }
            else if (!int.TryParse(input, out int _2))
            {
                Console.WriteLine("Invalid input detected: <Must be a number>. Please try again");
                return false;
            }
            else return true;
        }

        public static Enemy? SpawnRandomEnemy(Random rnd)
        {
            int randInt = rnd.Next(3);
            switch (randInt)
            {
                case 0: return new EnemyGoblin();

                case 1: return new EnemyOrc();

                case 2: return new EnemyBanshee();

                default:
                    Console.WriteLine("A critical error has occured {spawning an enemy}");
                    return null;
            }
        }
    }
}
