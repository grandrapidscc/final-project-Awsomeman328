// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using CIS129FinalProject;
using System.Globalization;

/* TODO LIST:
 * 
 * DONE: Create this TODO List
 * 
 * Dungeon
 * DONE: Create the Dungeon, a 5x5xN 3-dimentional grid that will be populated by various GameObject Class Objects.
 * DONE: Spawn the Wizert into a random room in the Dungeon (one of the 4 corners)
 * DONE: Spawn the Dugeon Exit into a different random room in the Dungeon (Preferably on both a different row and column)
 * DONE: Spawn at least 13 enemies, only 1 in any room (One in every room that's on both a different row and column)
 *  ^IDK why the instructions say that encountering these should not be by chance when typically these objects' positions in the grid would be ^
 *  ^randomly generated at the start of the game. But whatever, the professor wants these to have predictable spawn locations.^
 * DONE: Spawn any number of Powerups, only 1 in each room ("The number of Powerups is at my discretion.")
 *  ^Spawn 2 Powerups, one of each type, to two opposite corners of the Dungeon (not the Wizert's corner)^
 * 
 * TODO: Implament the Dungeon's Outer Walls
 * TODO: Create various descriptions for the rooms of the Dungeon to display after the Wizert enters that room (About 25 of them)
 * 
 * 
 * Game Objects
 * DONE: Create the GameObject Class. All of the Enemies, Powerups, and the Wizert will be a child class of this GameObject class.
 * 
 * TODO: Track the Objects' locations within the Dungeon
 * 
 * 
 * DONE: Create the GameUnit Subclass from the GameObject Class
 * DONE: Define the Health Point (HP) and MaxHP Variables
 * DONE: Define the AdjustHealth Function to implament taking damage and healing
 * 
 * TODO: Whenever a Unit's health is adjusted, display what the difference is and how much remaining health it has left
 * 
 * 
 * DONE: Create the Wizert Subclass, the player controlled character, from the GameUnit Class
 * DONE: Implement the Wizert's starting Health Points (100 HP) and Magicka Points (200 MP)
 * 
 * TODO: Create the Wizert's movement options (North, South, East, West) EXCEPT for when there is a wall in the way
 * TODO: Create the Wizert's combat options (Fireball, Heal, or Flee) EXCEPT for when the Wizert does not have enough MP to use certain certain actions
 *  ^I think it would be a cool idea to also allow the user to heal themselves during their movement outside of an encounter^
 * TODO: Implement the Flee Action (B/c it is supposed to be a random chance of either succeding or failing to flee, I'll just make it a 50/50 chance)
 *  ^A successful Flee should bring the Wizert back into the direction from which they came from, aka always going back to the same room that it used to enter^
 * TODO: Implement providing a description of what happens whenever the user chooses an action to perform
 * TODO: Whenever the Wizert expends any MP, display how much MP was used
 * TODO: When the Wizert's HP becomes 0 or less, the player is defeated and it is game over
 * TODO (Optional): Make a State Machine for the Player Character's Behaivor. 
 *  ^Move, Search, Battle, AttemptExit, UsePowerup, Exit, Die^
 * 
 * 
 * DONE: Create the Enemy Subclass from the GameUnit Class
 * DONE: Create the various enemy Subclasses from the Enemy Class
 * 
 * TODO: When an enemy attacks, shwo a message that says the name of the attack, how much damage it did, and how much HP the Wizert has left
 * TODO: Once an enemy's HP hits 0 or less, the enemy is defeated and should be despawned from the room
 * TODO: If the Wizert flees the room and then returns, the same enemy should still be there and should have the same amount of health (no healing enemies)
 * 
 * 
 * DONE: Create the Powerup Subclass from the GameObject Class
 * DONE: Create the various powerup Subclasses from the Powerup Class
 * 
 * TODO: If the Wizert enters a room with a Powerup, then they immedeately consume the Powerup with a message displayed of the effects.
 *  ^If the Wizert encounters a Powerup while their respective HP or MP is already at max, then the Powerup is not consumed and will remain in that room until consumed^
 *  ^Also if there is an Enemy in the same room as a Powerup, then the Powerup is not consumed until the Enemy in that room is defeated.^
 * TODO: Once a Powerup is used, it needs to be despawned from the Dungeon with a message displaying how much HP or MP was restored and the Wizert's new current HP or MP
 * 
 * Game Logic
 * TODO: When the player is "Game Overed," ask if they would like to play again. If so, restart the program. If not, exit program.
 * TODO: If the Wizert enters a room with both an Enemy and a Powerup, then the Powerup is not consumed until the Enemy in that room is defeated
 * 
 * User Input
 * TODO: Whenever we need to ask for user input, we will display a list of possible options, each with a corrisponding number next to the option
 * TODO: User will enter a single diget number (1-9) to select which action option they whish to do.
 * TODO: Will display all possible options at each appropreate times, but if the option is not possible then we will give a reason why.
 *  ^For example, if thw Wizert is all the way north any they attempt to go north, we will just say that they ran into a wall or something^
 * TODO: If the user enters an invalid input, then we will tell them to enter a valid input and to try again
 * 
 * ???Who attacks first each combat? The Wizert? The Enemies? Is it random? I want to make it a 50/50 if an enemy gets an attack off first before the Wizert,
 * BUT after looking at the example that Prof. Wu provided it appears as though the Wizert will always move before the enemies when he first encounters them.
 * 
 * Make sure to use:
 * 
 * DONE: Classes
 * DONE: Inheritance
 * DONE: Loops
 * 
 * TODO: Various and Appropriate Data Types
 * TODO: Data Structures
 * TODO: Input Validation
 * TODO: Any External Libraries
 * TODO: Instatiating your Classes into Objects
 * TODO: Appropriate Opperators
 * TODO: Conditional Statements (IF and/or Switch)
 * TODO: Encapsulation (Each Class is its own file & Do not put all of the funtionality into a single file)
 * 
 * 
 * Remember These Important Things:
 * -This NEEDS to be a text-based adventure game, no fansey graphical interfaces. (booo!)
 * 
 */

/* This is another way to make the Dungeon, but I like the other version I made more so I'm using that one instead.
List<GameObject>[][] theDungeon2 = new List<GameObject>[5][]
{
    new List<GameObject>[5]{
        new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }
    },
    new List<GameObject>[5]{
        new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }
    },
    new List<GameObject>[5]{
        new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }
    },
    new List<GameObject>[5]{
        new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }
    },
    new List<GameObject>[5]{
        new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }
    }
};*/

Random rnd = new Random();
int randInt;
string ?input;
bool gameOver = false;
bool continuePlaying = true;
List<GameObject>[,] theDungeon;

theDungeon = new List<GameObject>[5, 5]
{
    {
        new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }
    },
    {
        new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }
    },
    {
        new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }
    },
    {
        new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }
    },
    {
        new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }, new List<GameObject> { }
    }
};

/* Ok, new plan for spawning everything:
 * 1) Pick a random number 1, 2, 3, or 4. The chosen number will detrmine which corner the exit is spawned in. 
 *      >Spawn a room object in every space, giving them a randomly assigned description (ideally each of these would be unique)
 * 2) Spawn the Wizert in the opposite corner of the exit.
 * 3) For the remaining two corners, pick a number 1 or 2. The chosen number will determine which type of potion is spawned for the first corner. 
 *      >The other corner will get the other type of potion.
 * 4) For all of the rooms except for the one the Wizert starts in, spawn an Enemy of a random type by picking a number 1, 2, or 3.
 *      >I currently have it so they also can't spawn in a room with a powerup which is not desired, but I'll try to fix this later.
 */

do
{
    randInt = rnd.Next(4);
    switch (randInt)
    {
        case 0:
            theDungeon[0, 0].Add(new Room(true));
            foreach (var item in theDungeon) if (item.Count() == 0) item.Add(new Room(false));
            theDungeon[4, 4].Add(new Wizert());
            randInt = rnd.Next(2);
            if (randInt == 0)
            {
                theDungeon[0, 4].Add(new Powerup(Powerup.PotionTypes.Health));
                theDungeon[4, 0].Add(new Powerup(Powerup.PotionTypes.Magika));
            }
            else
            {
                theDungeon[0, 4].Add(new Powerup(Powerup.PotionTypes.Magika));
                theDungeon[4, 0].Add(new Powerup(Powerup.PotionTypes.Health));
            }
            break;

        case 1:
            theDungeon[0, 4].Add(new Room(true));
            foreach (var item in theDungeon) if (item.Count() == 0) item.Add(new Room(false));
            theDungeon[4, 0].Add(new Wizert());
            randInt = rnd.Next(2);
            if (randInt == 0)
            {
                theDungeon[0, 0].Add(new Powerup(Powerup.PotionTypes.Health));
                theDungeon[4, 4].Add(new Powerup(Powerup.PotionTypes.Magika));
            }
            else
            {
                theDungeon[0, 0].Add(new Powerup(Powerup.PotionTypes.Magika));
                theDungeon[4, 4].Add(new Powerup(Powerup.PotionTypes.Health));
            }
            break;

        case 2:
            theDungeon[4, 0].Add(new Room(true));
            foreach (var item in theDungeon) if (item.Count() == 0) item.Add(new Room(false));
            theDungeon[0, 4].Add(new Wizert());
            randInt = rnd.Next(2);
            if (randInt == 0)
            {
                theDungeon[0, 0].Add(new Powerup(Powerup.PotionTypes.Health));
                theDungeon[4, 4].Add(new Powerup(Powerup.PotionTypes.Magika));
            }
            else
            {
                theDungeon[0, 0].Add(new Powerup(Powerup.PotionTypes.Magika));
                theDungeon[4, 4].Add(new Powerup(Powerup.PotionTypes.Health));
            }
            break;

        case 3:
            theDungeon[4, 4].Add(new Room(true));
            foreach (var item in theDungeon) if (item.Count() == 0) item.Add(new Room(false));
            theDungeon[0, 0].Add(new Wizert());
            randInt = rnd.Next(2);
            if (randInt == 0)
            {
                theDungeon[0, 4].Add(new Powerup(Powerup.PotionTypes.Health));
                theDungeon[4, 0].Add(new Powerup(Powerup.PotionTypes.Magika));
            }
            else
            {
                theDungeon[0, 4].Add(new Powerup(Powerup.PotionTypes.Magika));
                theDungeon[4, 0].Add(new Powerup(Powerup.PotionTypes.Health));
            }
            break;

        default:
            Console.WriteLine("A critical error has occured {spawning the dungeon}");
            break;
    }
    foreach (var item in theDungeon)
    {
        if (item.Count() == 1)
        {
            randInt = rnd.Next(3);
            switch (randInt)
            {
                case 0:
                    item.Add(new EnemyGoblin());
                    break;

                case 1:
                    item.Add(new EnemyOrc());
                    break;

                case 2:
                    item.Add(new EnemyBanshee());
                    break;

                default:
                    Console.WriteLine("A critical error has occured {spawning the enemies}");
                    break;
            }
        }
    }

    do
    {
        gameOver = true;
    } while (!gameOver);

    Console.WriteLine("Would you like to play the game again? Press...\r" +
        "\n8.\tYes\r" +
        "\n9.\tNo\r");
    input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Invalid input detected: <Null Or Empty>. Please try again");
    }
    else
    {
        if (!(char.TryParse(input, out char _1)))
        {
            Console.WriteLine("Invalid input detected: <Must be a single digit number>. Please try again");
        }
        else if (!(int.TryParse(input, out int _2)))
        {
            Console.WriteLine("Invalid input detected: <Must be a number>. Please try again");
        }
        else
        {
            // Check which number 0-9 was entered
            switch (input)
            {
                case "0":
                    Console.WriteLine("0 doesn't do anything, dummy! hahaha");
                    break;

                case "1":
                    Console.WriteLine("You try to go North.");
                    break;

                case "2":
                    Console.WriteLine("You try to go South.");
                    break;

                case "3":
                    Console.WriteLine("You try to go East.");
                    break;

                case "4":
                    Console.WriteLine("You try to go West.");
                    break;

                case "5":
                    Console.WriteLine("You try to attack with your Fireball spell.");
                    break;

                case "6":
                    Console.WriteLine("You try to go Heal yourself with your Magicka.");
                    break;

                case "7":
                    Console.WriteLine("You try to Flee back from where you came from.");
                    break;

                case "8":
                    Console.WriteLine("Yes, you would like to Continue Playing.");
                    break;

                case "9":
                    Console.WriteLine("No, you would not like to Continue Playing.");
                    continuePlaying = false;
                    break;

                default:
                    Console.WriteLine("Something must have gone wrong: <Selecting 0-9>. Please try again");
                    break;
            }
        }
    }

} while (continuePlaying);

