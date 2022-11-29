// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using CIS129FinalProject;
using static CIS129FinalProject.Wizert;

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
 * DONE: Implament the Dungeon's Outer Walls
 * 
 * TODO: Create various descriptions for the rooms of the Dungeon to display after the Wizert enters that room (About 25 of them)
 * 
 * 
 * Game Objects
 * DONE: Create the GameObject Class. All of the Enemies, Powerups, and the Wizert will be a child class of this GameObject class.
 * DONE: Track the Objects' locations within the Dungeon
 * 
 * 
 * DONE: Create the GameUnit Subclass from the GameObject Class
 * DONE: Define the Health Point (HP) and MaxHP Variables
 * DONE: Define the AdjustHealth Function to implament taking damage and healing
 * 
 * TODO: Whenever a Unit's health is adjusted, display what the difference is and how much remaining health it has left
 *      ^Do this within the actual AdjustHP and AdjustMP functions, maybe ...^
 * 
 * 
 * DONE: Create the Wizert Subclass, the player controlled character, from the GameUnit Class
 * DONE: Implement the Wizert's starting Health Points (100 HP) and Magicka Points (200 MP)
 * DONE: Create the Wizert's movement options (North, South, East, West) EXCEPT for when there is a wall in the way
 * 
 * TODO: Create the Wizert's combat options (Fireball, Heal, or Flee) EXCEPT for when the Wizert does not have enough MP to use certain certain actions
 *  ^I think it would be a cool idea to also allow the user to heal themselves during their movement outside of an encounter^
 * TODO: Implement the Flee Action (B/c it is supposed to be a random chance of either succeding or failing to flee, I'll just make it a 50/50 chance)
 *  ^A successful Flee should bring the Wizert back into the direction from which they came from, aka always going back to the same room that it used to enter^
 * TODO: Implement providing a description of what happens whenever the user chooses an action to perform
 * TODO: Whenever the Wizert expends any MP, display how much MP was used
 * TODO: When the Wizert's HP becomes 0 or less, the player is defeated and it is game over
 * TODO (Optional): Make a State Machine for the Player Character's Behaivor. 
 *  ^Spawn, Move, Search, Battle, AttemptExit, UsePowerup, Exit, Die^
 * 
 * 
 * DONE: Create the Enemy Subclass from the GameUnit Class
 * DONE: Create the various enemy Subclasses from the Enemy Class
 * 
 * TODO: When an enemy attacks, show a message that says the name of the attack, how much damage it did, and how much HP the Wizert has left
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
 * DONE: When the player is "Game Overed," ask if they would like to play again. If so, restart the program. If not, exit program.
 * 
 * TODO: If the Wizert enters a room with both an Enemy and a Powerup, then the Powerup is not consumed until the Enemy in that room is defeated
 * 
 * User Input
 * DONE: Whenever we need to ask for user input, we will display a list of possible options, each with a corrisponding number next to the option
 * DONE: User will enter a single diget number (1-9) to select which action option they whish to do.
 * DONE: Will display all possible options at each appropreate times, but if the option is not possible then we will give a reason why.
 *  ^For example, if the Wizert is all the way north any they attempt to go north, we will just say that they ran into a wall or something^
 * DONE: If the user enters an invalid input, then we will tell them to enter a valid input and to try again
 * 
 * ???Who attacks first each combat? The Wizert? The Enemies? Is it random? I want to make it a 50/50 if an enemy gets an attack off first before the Wizert,
 * BUT after looking at the example that Prof. Wu provided it appears as though the Wizert will always move before the enemies when he first encounters them.
 * 
 * Make sure to use:
 * 
 * DONE: Classes
 * DONE: Inheritance
 * DONE: Loops
 * DONE: Various and Appropriate Data Types
 * DONE: Data Structures
 * DONE: Input Validation
 * DONE: Instatiating your Classes into Objects
 * DONE: Conditional Statements (IF and/or Switch)
 * 
 * TODO: Any External Libraries
 * TODO: Appropriate Opperators
 * TODO: Encapsulation (Each Class is its own file & Do not put all of the funtionality into a single file)
 * 
 * 
 * Remember These Important Things:
 * -This NEEDS to be a text-based adventure game, no fansey graphical interfaces. (booo!)
 * 
 */

/* How the Program loop and Game loop will function
 * - Reset the Game
 * - Spawn everything in a Random Pattern
 * - Start the Game loop
 * - The Wizert will start by searching in any room it finds itself in.
 * - It i's search, it will report to the player a meaningless description and if there is a Powerup, Exit, &/or Enemy in that room.
 * - If any of these things are found, the Wizert will address each of them in reverse order. 
 * - If none of these things are present, the game will ask the player which direction they want to move, North, South, East, or West.
 *      > After moving, the Wizert will start searching this new room.
 *      > Alternatively to moving, the player may also opt to not move for now and heal themselves.
 * - If there is an Enemy in the room:
 *      > The player gets the choice of either attacking that Enemy, Healing themselves, or trying to run away.
 *      > If they choose to Attack, then the Wizert expends some MP and damages the Enemy.
 *          >If after this the Enemy's HP is set to 0 or less, the Enemy dies and is deleted.
 *          >Once the Enemy is deleted, the Wizert will go back to searching the room.
 *      > If they choose to Heal, then the Wizert expends some MP and restores some of the Wizert's HP.
 *      > If they choose to Flee, then the Wizert has a 50% chance of sucessfully fleeing back to the previous room that they came in from.
 *      > If they fail this 50% chance, then a notification informing them of this failure occurs.
 *      > If after this choice the Wizert is still in the same room with an Enemy still remaining, then the Enemy attacks the Wizert and damages them.
 *      > If the Wizert's HP is brought down to 0 or less, then the Wizert Dies.
 *      > If the Wizert did not die, then repeat this battle loop.
 * - If the Exit is in the room:
 *      > Then the Wizert Exits the Dungeon.
 * - If there is a Powerup in the room:
 *      > If the Wizert's stat for the powerup is already at its max value then it won't use the Powerup.
 *      > Otherwise, the Wizert will consume the Powerup, restoring that particular stat by a bit and deleting the Powerup.
 *      > After this, the Wizert will decide where they want to move.
 *          >Insead of having them search the room again, it would be simplier to have them to straight into moving.
 * - If at any point the Wizert's HP reaches 0 or less:
 *      > Then the Wizert Dies.
 * - Once the Wizert either Exits the Dungeon or Dies, it is Game Over!
 * - Once it is Game Over, we will leave the game loop.
 * - After leaving the Game loop, the program will ask if the player would like to play again.
 * - If yes then the Program will return back to "Reset the Game"
 * - If no, then the Program will terminate.
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

Random rnd = new();
int randInt;
string? input;
bool firstTime = true;
bool gameOver = false;
bool continuePlaying = true;
List<GameObject>[,] theDungeon;
Wizert wizert = new();
Room room = new(false);
Enemy? enemy = new();
Powerup powerup = new(Powerup.PotionType.Health);
(int, int) prevRoom = (0, 0);
(int, int) exitRoom = (0, 0);
(int, int) currentRoom = (0, 0);

/* Ok, new plan for spawning everything:
 * 1) Pick a random number 1, 2, 3, or 4. The chosen number will detrmine which corner the exit is spawned in. 
 *      >Spawn a room object in every space, giving them a randomly assigned description (ideally each of these would be unique)
 * 2) Spawn the Wizert in the opposite corner of the exit.
 * 3) For the remaining two corners, pick a number 1 or 2. The chosen number will determine which type of potion is spawned for the first corner. 
 *      >The other corner will get the other type of potion.
 * 4) For all of the rooms except for the one the Wizert starts in and the two rooms next to that room, spawn an Enemy of a random type by picking a number 1, 2, or 3.
 *      >I currently have it so they also spawn in the two rooms next to the Wizert's starting room which is not desired. 
 *      >Enemies are not meant to be in EVERY room, only most of them.
 */

do
{
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
    randInt = rnd.Next(4);
    switch (randInt)
    {
        case 0:
            theDungeon[0, 0].Add(new Room(true));
            exitRoom = (0, 0);
            foreach (var item in theDungeon) if (item.Count == 0) item.Add(new Room(false));
            //theDungeon[4, 4].Add(new Wizert());
            currentRoom = (4, 4);
            prevRoom = (4, 4);
            randInt = rnd.Next(2);
            if (randInt == 0)
            {
                theDungeon[0, 4].Add(new Powerup(Powerup.PotionType.Health));
                theDungeon[4, 0].Add(new Powerup(Powerup.PotionType.Magika));
            }
            else
            {
                theDungeon[0, 4].Add(new Powerup(Powerup.PotionType.Magika));
                theDungeon[4, 0].Add(new Powerup(Powerup.PotionType.Health));
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!((i == 3 && j == 4) || (i == 4 && j == 3) || (i == 4 && j == 4)))
                    {
                        enemy = ProgramHelper.SpawnRandomEnemy(rnd);
                        if (enemy != null) theDungeon[i, j].Add(enemy);
                    }
                }
            }
            break;

        case 1:
            theDungeon[0, 4].Add(new Room(true));
            exitRoom = (0, 4);
            foreach (var item in theDungeon) if (item.Count == 0) item.Add(new Room(false));
            //theDungeon[4, 0].Add(new Wizert());
            currentRoom = (4, 0);
            prevRoom = (4, 0);
            randInt = rnd.Next(2);
            if (randInt == 0)
            {
                theDungeon[0, 0].Add(new Powerup(Powerup.PotionType.Health));
                theDungeon[4, 4].Add(new Powerup(Powerup.PotionType.Magika));
            }
            else
            {
                theDungeon[0, 0].Add(new Powerup(Powerup.PotionType.Magika));
                theDungeon[4, 4].Add(new Powerup(Powerup.PotionType.Health));
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!((i == 3 && j == 0) || (i == 4 && j == 0) || (i == 4 && j == 1)))
                    {
                        enemy = ProgramHelper.SpawnRandomEnemy(rnd);
                        if (enemy != null) theDungeon[i, j].Add(enemy);
                    }
                }
            }
            break;

        case 2:
            theDungeon[4, 0].Add(new Room(true));
            exitRoom = (4, 0);
            foreach (var item in theDungeon) if (item.Count == 0) item.Add(new Room(false));
            //theDungeon[0, 4].Add(new Wizert());
            currentRoom = (0, 4);
            prevRoom = (0, 4);
            randInt = rnd.Next(2);
            if (randInt == 0)
            {
                theDungeon[0, 0].Add(new Powerup(Powerup.PotionType.Health));
                theDungeon[4, 4].Add(new Powerup(Powerup.PotionType.Magika));
            }
            else
            {
                theDungeon[0, 0].Add(new Powerup(Powerup.PotionType.Magika));
                theDungeon[4, 4].Add(new Powerup(Powerup.PotionType.Health));
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!((i == 0 && j == 3) || (i == 0 && j == 4) || (i == 1 && j == 4)))
                    {
                        enemy = ProgramHelper.SpawnRandomEnemy(rnd);
                        if (enemy != null) theDungeon[i, j].Add(enemy);
                    }
                }
            }
            break;

        case 3:
            theDungeon[4, 4].Add(new Room(true));
            exitRoom = (4, 4);
            foreach (var item in theDungeon) if (item.Count == 0) item.Add(new Room(false));
            //theDungeon[0, 0].Add(new Wizert());
            currentRoom = (0, 0);
            prevRoom = (0, 0);
            randInt = rnd.Next(2);
            if (randInt == 0)
            {
                theDungeon[0, 4].Add(new Powerup(Powerup.PotionType.Health));
                theDungeon[4, 0].Add(new Powerup(Powerup.PotionType.Magika));
            }
            else
            {
                theDungeon[0, 4].Add(new Powerup(Powerup.PotionType.Magika));
                theDungeon[4, 0].Add(new Powerup(Powerup.PotionType.Health));
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!((i == 0 && j == 0) || (i == 0 && j == 1) || (i == 1 && j == 0)))
                    {
                        enemy = ProgramHelper.SpawnRandomEnemy(rnd);
                        if (enemy != null) theDungeon[i, j].Add(enemy);
                    }
                }
            }
            break;

        default:
            Console.WriteLine("A critical error has occured {spawning the dungeon}");
            break;
    }
    gameOver = false;
    firstTime = true;

    while (!gameOver)
    {
        if (wizert != null)
        {
            if (firstTime)
            {
                wizert = new();
                wizert.SetNextState(WizertState.Spawn);
                firstTime = false;
            }
            wizert.Update();
            switch (wizert.GetState())
            {
                case Wizert.WizertState.Spawn:
                    Console.WriteLine("You, the Wizert, have found yourself within the Dungeon yet again, ...");
                    wizert.SetNextState(Wizert.WizertState.Search);
                    break;
                //////////////////////////////////////////////////////////////////////////////////////////////////
                case Wizert.WizertState.Move:
                    Console.WriteLine("Press..." +
                        "\n1.\tTo go north\r" +
                        "\n2.\tTo go south\r" +
                        "\n3.\tTo go east\r" +
                        "\n4.\tTo go west\r" +
                        "\n5.\tTo heal yourself");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Invalid input detected: <Null Or Empty>. Please try again");
                    }
                    else
                    {
                        if (ProgramHelper.ValidateUserInput(input))
                        {
                            // Check which number 0-9 was entered
                            switch (input)
                            {
                                case "1":
                                    Console.Write("You head to the north side of the room ");
                                    if (currentRoom.Item1 == 0)
                                    {
                                        Console.WriteLine("but you find no door on this wall.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("and you go through the door.");
                                        wizert.SetNextState(WizertState.Search);
                                        theDungeon[currentRoom.Item1 - 1, currentRoom.Item2].Add(wizert);
                                        theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(wizert);
                                        prevRoom = (currentRoom.Item1, currentRoom.Item2);
                                        currentRoom = (currentRoom.Item1 - 1, currentRoom.Item2);
                                    }
                                    break;

                                case "2":
                                    Console.Write("You head to the south side of the room ");
                                    if (currentRoom.Item1 == 4)
                                    {
                                        Console.WriteLine("but you find no door on this wall.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("and you go through the door.");
                                        wizert.SetNextState(WizertState.Search);
                                        theDungeon[currentRoom.Item1 + 1, currentRoom.Item2].Add(wizert);
                                        theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(wizert);
                                        prevRoom = (currentRoom.Item1, currentRoom.Item2);
                                        currentRoom = (currentRoom.Item1 + 1, currentRoom.Item2);
                                    }
                                    break;

                                case "3":
                                    Console.Write("You head to the east side of the room ");
                                    if (currentRoom.Item2 == 4)
                                    {
                                        Console.WriteLine("but you find no door on this wall.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("and you go through the door.");
                                        wizert.SetNextState(WizertState.Search);
                                        theDungeon[currentRoom.Item1, currentRoom.Item2 + 1].Add(wizert);
                                        theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(wizert);
                                        prevRoom = (currentRoom.Item1, currentRoom.Item2);
                                        currentRoom = (currentRoom.Item1, currentRoom.Item2 + 1);
                                    }
                                    break;

                                case "4":
                                    Console.Write("You head to the west side of the room ");
                                    if (currentRoom.Item2 == 0)
                                    {
                                        Console.WriteLine("but you find no door on this wall.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("and you go through the door.");
                                        wizert.SetNextState(WizertState.Search);
                                        theDungeon[currentRoom.Item1, currentRoom.Item2 - 1].Add(wizert);
                                        theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(wizert);
                                        prevRoom = (currentRoom.Item1, currentRoom.Item2);
                                        currentRoom = (currentRoom.Item1, currentRoom.Item2 - 1);
                                    }
                                    break;

                                case "5":
                                    if (wizert.GetHP() >= wizert.GetMaxHP())
                                    {
                                        Console.WriteLine("You think about healing yourself, but realize that you are currently at full HP.");
                                        Console.WriteLine($"You currently have {wizert.GetHP()} HP and {wizert.GetMP()} MP left.");
                                    }
                                    else if (wizert.GetMP() >= 5)
                                    {
                                        Console.WriteLine("You cast a spell to heal your wounds. You regain 3 HP using 5 MP.");
                                        wizert.AdjustMP(-5);
                                        wizert.AdjustHP(3);
                                        Console.WriteLine($"You now have {wizert.GetHP()} HP and {wizert.GetMP} MP.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("You try to cast a heal, but find that you do not have enough MP to finish casting the spell.");
                                        Console.WriteLine($"You currently have {wizert.GetMP()} MP left.");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Please choose a valid, single digit number from what is listed.");
                                    break;
                            }
                        }
                    }
                    break;
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case Wizert.WizertState.Search:
                    Console.WriteLine("You are in a room illuminated by torches.  It reeks of orc, though you do not see any nearby.");
                    wizert.SetNextState(Wizert.WizertState.Move);
                    foreach (GameObject testPowerup in theDungeon[currentRoom.Item1, currentRoom.Item2])
                    {
                        if (Powerup.ReferenceEquals(testPowerup.GetType(), powerup.GetType()))
                        {
                            if (testPowerup != null)
                            {
                                Console.WriteLine("While surveying the room, you notice a potion off in the corner.");
                                wizert.SetNextState(Wizert.WizertState.UsePowerup);
                            }
                        }
                    }
                    if (currentRoom.Item1 == exitRoom.Item1 && currentRoom.Item2 == exitRoom.Item2)
                    {
                        Console.WriteLine("And then you see it! The exit to this dungeon!");
                        wizert.SetNextState(Wizert.WizertState.Exit);
                    }
                    else
                    {
                        Console.WriteLine("After searching for a while, you do not see the exit to this dungeon.");
                    }
                    foreach (GameObject testEnemy in theDungeon[currentRoom.Item1, currentRoom.Item2])
                    {
                        if (EnemyGoblin.ReferenceEquals(testEnemy.GetType(), new EnemyGoblin().GetType()) ||
                            EnemyOrc.ReferenceEquals(testEnemy.GetType(), new EnemyOrc().GetType()) ||
                            EnemyBanshee.ReferenceEquals(testEnemy.GetType(), new EnemyBanshee().GetType()))
                        {
                            if (testEnemy != null)
                            {
                                Console.WriteLine("But suddenly, you see something move.");
                                wizert.SetNextState(Wizert.WizertState.Battle);
                            }
                        }
                    }
                    break;
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case Wizert.WizertState.Battle:
                    // We might not need this anymore, ... idk yet
                    //wizert.Update();
                    foreach (GameObject currentEnemy in theDungeon[currentRoom.Item1, currentRoom.Item2])
                    {
                        if (EnemyGoblin.ReferenceEquals(currentEnemy.GetType(), new EnemyGoblin().GetType()) ||
                            EnemyOrc.ReferenceEquals(currentEnemy.GetType(), new EnemyOrc().GetType()) ||
                            EnemyBanshee.ReferenceEquals(currentEnemy.GetType(), new EnemyBanshee().GetType()))
                        {
                            if (currentEnemy != null)
                            {
                                enemy = (Enemy)currentEnemy;
                                Console.WriteLine($"You have encountered a {enemy.GetEnemyName()}."); // currently doesn't account for "an orc".
                                Console.WriteLine($"It's current HP is {enemy.GetHP()}.");
                                Console.WriteLine("Press..." +
                                    "\n1.\tTo Attack with a Fireball\r" +
                                    "\n2.\tTo Heal yourself\r" +
                                    "\n3.\tTo Attempt to Flee\r");
                                input = Console.ReadLine();
                                if (string.IsNullOrEmpty(input))
                                {
                                    Console.WriteLine("Invalid input detected: <Null Or Empty>. Please try again");
                                }
                                else
                                {
                                    if (ProgramHelper.ValidateUserInput(input))
                                    {
                                        // Check which number 0-9 was entered
                                        switch (input)
                                        {
                                            case "1":
                                                if (wizert.GetMP() >= 3)
                                                {
                                                    // Still need to check if the wizert has enough MP to be able to cast any of its spell options, ...
                                                    Console.WriteLine("You cast a fireball that burns the enemy. It costed 3 MP and does 5 damage.");
                                                    wizert.AdjustMP(-3);
                                                    enemy.AdjustHP(-5);
                                                    Console.WriteLine($"The {enemy.GetEnemyName()} now has {enemy.GetHP()} HP.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You try to cast a fireball, but find that you do not have enough MP to finish casting the spell.");
                                                    Console.WriteLine($"You currently have {wizert.GetMP()} MP left.");
                                                }

                                                if (enemy.GetHP() <= 0)
                                                {
                                                    Console.WriteLine($"The {enemy.GetEnemyName()} burns to a crisp.");
                                                    theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(enemy);
                                                    wizert.SetNextState(WizertState.Search);
                                                }
                                                else
                                                {
                                                    Console.Write($"The {enemy.GetEnemyName()} uses it's {enemy.GetAttackName()} attack. ");
                                                    Console.WriteLine($"It deals {enemy.GetAttackDamage()} damage");
                                                    wizert.AdjustHP(-enemy.GetAttackDamage());
                                                    Console.WriteLine($"You have {wizert.GetHP()} HP left.");
                                                }

                                                if (wizert.GetHP() <= 0)
                                                {
                                                    Console.WriteLine("You have ran out of HP.");
                                                    wizert.SetNextState(WizertState.Die);
                                                }
                                                break;

                                            case "2":
                                                if (wizert.GetHP() >= wizert.GetMaxHP())
                                                {
                                                    Console.WriteLine("You think about healing yourself, but realize that you are currently at full HP.");
                                                    Console.WriteLine($"You currently have {wizert.GetHP()} HP and {wizert.GetMP()} MP left.");
                                                }
                                                else if (wizert.GetMP() >= 5)
                                                {
                                                    Console.WriteLine("You cast a spell to heal your wounds. You regain 3 HP using 5 MP.");
                                                    wizert.AdjustMP(-5);
                                                    wizert.AdjustHP(3);
                                                    Console.WriteLine($"You now have {wizert.GetHP()} HP and {wizert.GetMP} MP.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You try to cast a heal, but find that you do not have enough MP to finish casting the spell.");
                                                    Console.WriteLine($"You currently have {wizert.GetMP()} MP left.");
                                                }

                                                Console.Write($"The {enemy.GetEnemyName()} uses it's {enemy.GetAttackName()} attack. ");
                                                Console.WriteLine($"It deals {enemy.GetAttackDamage()} damage");
                                                wizert.AdjustHP(-enemy.GetAttackDamage());
                                                Console.WriteLine($"You have {wizert.GetHP()} HP left.");

                                                if (wizert.GetHP() <= 0)
                                                {
                                                    Console.WriteLine("You have ran out of HP.");
                                                    wizert.SetNextState(WizertState.Die);
                                                }
                                                break;

                                            case "3":
                                                Console.WriteLine("You attempt to flee from the battle.");
                                                randInt = rnd.Next(2);
                                                if (randInt == 0)
                                                {
                                                    // Did not escape
                                                    Console.WriteLine("You did not successfully escape from the battle.");
                                                    Console.Write($"The {enemy.GetEnemyName()} uses it's {enemy.GetAttackName()} attack. ");
                                                    Console.WriteLine($"It deals {enemy.GetAttackDamage()} damage");
                                                    wizert.AdjustHP(-enemy.GetAttackDamage());
                                                    Console.WriteLine($"You have {wizert.GetHP()} HP left.");
                                                    if (wizert.GetHP() <= 0)
                                                    {
                                                        Console.WriteLine("You have ran out of HP.");
                                                        wizert.SetNextState(WizertState.Die);
                                                    }
                                                }
                                                else
                                                {
                                                    // Did escape
                                                    Console.WriteLine("You successfully escaped from the battle.");
                                                    // Move back to your previous location, ...
                                                    wizert.SetNextState(WizertState.Search);
                                                    theDungeon[prevRoom.Item1, prevRoom.Item2].Add(wizert);
                                                    theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(wizert);
                                                    (int, int) _temp = prevRoom;
                                                    prevRoom = (currentRoom.Item1, currentRoom.Item2);
                                                    currentRoom = _temp;
                                                    break;
                                                }
                                                break;

                                            default:
                                                Console.WriteLine("Please choose a valid, single digit number from what is listed.");
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case Wizert.WizertState.UsePowerup:
                    foreach (GameObject currentPowerup in theDungeon[currentRoom.Item1, currentRoom.Item2])
                    {
                        if (Powerup.ReferenceEquals(currentPowerup.GetType(), powerup.GetType()))
                        {
                            if (currentPowerup != null)
                            {
                                powerup = (Powerup)currentPowerup;
                                Console.WriteLine("You look closer to examine the potion.");
                                if (powerup.GetPotionType() == Powerup.PotionType.Health)
                                {
                                    Console.WriteLine("Upon closer inspection it appears to be a health potion.");
                                    if (wizert.GetHP() >= wizert.GetMaxHP())
                                    {
                                        Console.WriteLine("You choose not to take the potion now since you don't need it.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("You choose to take the potion now since you need it.");
                                        wizert.AdjustHP(10);
                                        theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(powerup);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Upon closer inspection it appears to be a magicka potion.");
                                    if (wizert.GetMP() >= wizert.GetMaxMP())
                                    {
                                        Console.WriteLine("You choose not to take the potion now since you don't need it.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("You choose to take the potion now since you need it.");
                                        wizert.AdjustMP(20);
                                        theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(powerup);
                                    }
                                }
                            }
                        }
                    }
                    wizert.SetNextState(WizertState.Move);
                    break;
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                case Wizert.WizertState.Exit:
                    // Need to run the Update 1 more time in order to properly display the correct game over message(s)
                    // We might not need this anymore, ... idk yet
                    //wizert.Update();
                    Console.WriteLine("And with that, you finally touch the exit and you are whisked out of the dungeon.");
                    gameOver = true;
                    break;
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                case Wizert.WizertState.Die:
                    // Need to run the Update 1 more time in order to properly display the correct game over message(s)
                    // We might not need this anymore, ... idk yet
                    //wizert.Update();
                    Console.WriteLine("And with that, you take your last breath as you finally meet your end.");
                    gameOver = true;
                    break;
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                default:
                    Console.WriteLine("A critical error has occured {Wizert State}");
                    break;
            }
        }

    }

    Console.WriteLine("Would you like to play the game again? Press...\r" +
        "\n1.\tYes\r" +
        "\n2.\tNo\r");
    input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Invalid input detected: <Null Or Empty>. Please try again");
    }
    else
    {
        if (ProgramHelper.ValidateUserInput(input))
        {
            // Check which number 0-9 was entered
            switch (input)
            {
                case "1":
                    Console.WriteLine("Yes, you would like to Continue Playing.");
                    break;

                case "2":
                    Console.WriteLine("No, you would not like to Continue Playing.");
                    continuePlaying = false;
                    break;

                default:
                    Console.WriteLine("Please choose a valid, single digit number from what is listed.");
                    break;
            }
        }
    }

} while (continuePlaying);

