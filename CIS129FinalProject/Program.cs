// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using CIS129FinalProject;

/* TODO LIST:
 * 
 * DONE: Create this TODO List
 * 
 * Dungeon
 * DONE: Create the Dungeon, a 5x5xN 3-dimentional grid that will be populated by various GameObject Class Objects.
 * DONE: Spawn the Wizert into a random room in the Dungeon
 * 
 * TODO: Implament the Dungeon's Outer Walls
 * TODO: Create various descriptions for the rooms of the Dungeon to display after the Wizert enters that room (About 25 of them)
 * TODO: Spawn the Dugeon Exit into a different random room in the Dungeon (Preferably on both a different row and column)
 * TODO: Spawn at least 13 enemies, only 1 in any room (One in every room that's on both a different row and column)
 *  ^IDK why the instructions say that encountering these should not be by chance when typically these objects' positions in the grid would be ^
 *  ^randomly generated at the start of the game. But whatever, the professor wants these to have predictable spawn locations.^
 * TODO: Spawn any number of Powerups, only 1 in each room ("The number of Powerups is at my discretion.")
 *  ^Spawn 1 Powerup everywhere except in 6 rooms, the player's starting location, the 4 rooms next to their starting location, and the Exit^
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
 * 
 * TODO: Create the Wizert's movement options (North, South, East, West) EXCEPT for when there is a wall in the way
 * TODO: Implement the Wizert's starting Health Points (100 HP) and Magicka Points (200 MP)
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
 * 
 * TODO: Various and Appropriate Data Types
 * TODO: Data Structures
 * TODO: Input Validation
 * TODO: Any External Libraries
 * TODO: Instatiating your Classes into Objects
 * TODO: Appropriate Opperators
 * TODO: Conditional Statements (IF and/or Switch)
 * TODO: Loops
 * TODO: Encapsulation (Each Class is its own file & Do not put all of the funtionality into a single file)
 * 
 * 
 * Remember These Important Things:
 * -This NEEDS to be a text-based adventure game, no fansey graphical interfaces. (booo!)
 * 
 */

Random rnd = new Random();
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

/* This is another way to make the Dungeon, but I like the above version better so I'm using that one instead.
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

int rand1 = rnd.Next(5);
int rand2 = rnd.Next(5);
theDungeon[rand1, rand2].Add(new Wizert());

int rand3 = rnd.Next(5);
int rand4 = rnd.Next(5);
while (rand3 == rand1)
{
    rand3 = rnd.Next(5);
}
while (rand4 == rand2)
{
    rand4 = rnd.Next(5);
}
theDungeon[rand3, rand4].Add(new GameObject());

Console.WriteLine("b");