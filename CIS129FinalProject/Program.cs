// See https://aka.ms/new-console-template for more information
using CIS129FinalProject;
using static CIS129FinalProject.Wizert;

/* TODO and DONE List:
 * 
 * TODO: This NEEDS to be a text-based adventure game, no fansey graphical interfaces. (booo!)
 * 
 * TODO: The Player will take control of the Wizert
 * TODO: The Wizert uses Magicka to attack his Enemies
 * TODO: There is a Dungeon and the Wizert is caught inside it
 * TODO: The Wizert must Fight his way out of the Dungeon in order to not Die
 * TODO: If the Wizert manages to escape from the Dungeon, the Player Wins
 * TODO: The Wizert can move in four directions: North, South, East, & West
 * TODO: The Game needs to keep track of the Wizert's current location
 * TODO: The Wizert's current location is not information avalible to the player
 * TODO: After the Wizert Moves, he could encounter an Enemy
 * TODO: Durring an Enemy encounter, the Wizert has three options to choose from: Fireball, Heal, & Flee
 * TODO: The Fireball Attack has the listed description from the README, costs the Wizert 3 MP, and does 5 Damage to the Enemy
 * TODO: The Heal Option/Action has the listed description from the README, costs the Wizert 5 MP, and Heals 3 Heath Points (HP) to the Wizert
 * TODO: The Flee Option/Action has the listed description from the README, costs the Wizert 0 MP, and has a chance of allowing the Wizert to escape from the current Encounter
 * TODO: When an Action is performed, a description of what is happening should be displayed
 * TODO: When using an Action, the amount of MP consumed and the effects of the Action should be displayed.
 * TODO: When an Enemy takes an Attack from the Wizert, a display of the Enemy's new current HP should be displayed.
 * TODO: At the start of the game, the Wizert starts with 100 Health Points (HP) and 100 Magicka Points (MP).
 * TODO: If the Wizert's HP is depleted to 0 before escaping the Dungeon, it is Game Over (Bad Ending)
 * TODO: A message indicating that "The Wizert has lost" should be displayed to the console.
 * TODO: Once the Game is over, there should be an offer to play the Game again
 * 
 * TODO: There are three kinds/types of Enemies in the Dungeon
 * TODO: At least one of each type of Enemy should spawn within the Dungeon
 * TODO: Each Enemy type has their own Name, starting HP, Attack Name, and Attack Damage (See the README Table)
 * TODO: When an Enemy attacks, 1 oe 3 message(s) should be displayed to the user informing them:
 *       The name of the attack used, How much damage it cuased, and How much health the Wizert has left.
 * TODO: Enemy encounters should be set manually, not by chance. (Not like Pokemon's tall grass chance encounters)
 * TODO: You will not always engage in battle after making a move
 * TODO: At least half of your locations (13+) shoul.d have an Enemy
 * TODO: If you do engenge in battle in a certain location and defeat the Enemy there, then the Wizert should never have to fight in that spot again should they return to that location
 * TODO: If the Wizert flees the area, that same Enemy is still there waiting for him to continue the fight
 *       The Enemy's HP should be the same as it was after fleeing
 * 
 * TODO: Powerups should be scattered throughout the dungeon
 * TODO: There are 2 Powerup types: a Health Potion that restores 10 HP, and a Magicka Potion that Restores 20 MP
 * TODO: Each Powerup type has the name, description, and effect listed in the table in the README
 * TODO: Powerup locations should be set manually, just as with Enemy locations (No tall grass Pokemon logic)
 * TODO: The number of Powerups found in the Dungeon are at your discretion (Minimum 2, one of each type)
 * TODO: The Wizert should Automatically consume the Powerup if it is avalible at their location
 * TODO: A Powerup should only be avalible to be used only once at that location (Only one time use, no moving the Powerup)
 * TODO: Once a Powerup is used, no new or replacement Powerup should be present if the WIzert backtracks to that location
 * TODO: After consuming a Powerup, display how much HP or MP was restored, then display both the current HP and current MP of the Wizert
 * 
 * TODO: The Dungeon should be seperated into smaller Units
 * TODO: Each Unit represents a location of the dungeon that the Wizert can travel to
 * TODO: The Dungeon should be a 5x5 2D matrix of these Units for a total of 25 possible Units that the Wizert could travel to
 * TODO: A data structure that we learned in class should be what we use to support and represent this 2D graph
 * TODO: There should be walls surrounding the perimeter of the Dungeon that prevents the Wizert from traveling out of bounds
 *       You do not need to place walls anywhere else in the Dungeon. You can, but it is not required
 * TODO: Every Unit should have a description that describes the section of the Dungeon that the Wizert is in
 * TODO: This Unit description will be printed on the Console after each move
 *       Descriptions may be reused, but having them all be unique would be cool (A minimum of 25 descriptions would be required to do this)
 * TODO: After the description is displayed, the Wizert could also either encounter an Enemy or a Powerup
 *       Doing so will either iniciate an battle/combat or consume the Powerup respectively
 * TODO: Encountering an Enemy &/or Powerup should not be by chance, these should be set up manually in the code (No Pokemon tall grass mechanics)
 * TODO: If both an Enmey and a Powerup appear in the same location at the same time, have the Wizert fight off the Enemy first before consuming the Powerup
 * TODO: Upon startup, determine both the starting position of the Wizert and the Dungeon Exit location randomly
 *       These locations should not be displayed to the player, but they should still be saved somewhere for your program to remember them for determining other logic
 * TODO: When the Wizert reaches the exit, stop the Game and inform the player "You have won", then offer to let them play again
 * 
 * TODO: Practice good input validation when developing this application (See Input Validation HW)
 * TODO: When asking for user input, give the user options to select from (See the example in the README)
 * TODO: Validate that the user entered an expected number to the console
 * TODO: Ensure all of these steps for both when the Wizert is in battle and for when they are moving throughout the Dungeon
 * 
 * 
 * Make Sure To Use:
 * TODO: Various and Appropriate Data Types
 * TODO: Data Structures
 * TODO: Input Validation
 * TODO: Any External Libraries
 * TODO: Creating Classes
 * TODO: Instatiating your Classes into Objects
 * TODO: Appropriate Opperators
 * TODO: Conditional Statements (IF and/or Switch)
 * TODO: Loops
 * TODO: Inheritance
 * TODO: Encapsulation (Each Class is its own file & Do not put all of the funtionality into a single file)
 * 
 * 
 * Refactorings I want to make:
 *  - I want to change the Dungeon so that it is a 2D matrix of Room Objects, not a 2D matrix of List<GameObject> collections. This should be somewhat simple
 *      because each Room Object should only ever have 0 to 1 Wizert Objects, 0 to 1 Enemy Objects, and 0 to 1 Powerup Objects.
 *      Doing this should also allow me to do what I've wanted in the beginning which was have our Wizert actually be IN the Dungeon, like within the Dungeon Object!
 *      
 *  - I wanna adjust the dialogue for the Enemy encounters. Right now it repeats "You have encountered a [EnemyName]" each time when it should probably only say that
 *      for the first round of combat while any rounds of combat after the first should say something like, "You're still battling the [EnemyName]".
 * 
 *  - Depending on how my refactoring goes, I may or may not get rid of my "Garbage Collection" code since if I'm going to try to store everything in my Room Objects
 *      now rather than in a List in the Dungeon, then I should be able to edit the Room Objects more safely than deleting an entire object from a list while that
 *      list is in the middle of a for/forEach loop.
 * 
 *  - I want to add more comments to my code, basically moving the comments that I have below as well as some of the lines from the above checklist to where these 
 *      described comments happen in my code. I know the Prof. said that sometimes comments can be bad since we hope that code can just describe what it is doing itself, 
 *      but if I'm not going to documente this code then I want some more descriptions at what I am looking at.
 * 
 *  - If it is possible to put all of the sections that ask for user input together into one function, that would be great. 
 *      However, I still do not know how I would go about trying to achieve this.
 * 
 *  - Adjust the GameUnit class and all of its children to use the "Unit" variables rather than the Enemy or Wizert variables.
 *      This includes putting the name, hp, maxHp, attackName, attackDamage, attackDescription etc all into GameUnit and not seperated between Wizert or Enemy.
 * 
 *  - Delete the HealthPotion.cs and MagickaPotion.cs files. I've already been able to achieve their funtionality by using an enum within the Powerup class 
 *      so they are not needed anymore.
 * 
 *  - Go through and delete any commented out code. I kept most of these since I wasn't sure if I needed to go back to using them. 
 *      But now I know that I don't need them so they are unnessary and get in the way of actual code and actual comments.
 * 
 *  - When giving out options to the player, it might be a cool and good idea to ONLY display the options that the player can actually do.
 *      For example, if the Wizert is already all the way North as possible, then we could choose to not display "Go North" as an option to them.
 *      Doing this though may get a bit complicated, so I say it is fine if I don't get to this one.
 * 
 *  - It would also be nice to encapsulate some of the functionality of this Program.cs file into some functions within ProgramHelper.cs, espacially for any times 
 *      I find repeated blocks of code or chunks of code that take up a lot of vertical space like spawning the dungeon. 
 * 
 * 
 * Additional Questions or Confusions that I have that I need to solve for myself
 * ??? Who attacks first each combat? The Wizert? The Enemies? Is it random? I want to make it a 50/50 if an enemy gets an attack off first before the Wizert,
 *     but after looking at the example that Prof. Wu provided it appears as though the Wizert will always move before the enemies when he first encounters them.
 *     However, that was just an example and I cannot find an answer to this specific question, so I'll do it my way.
 * 
 * ??? Would the Wizert not just be able to heal themselves outside of combat? That just seems more like a common sense question more than anything else.
 *     Even though the provided example does not show this to be an option, I would like to do so for my version as a sort of Quality of Life change.
 * 
 * ??? I just noticed that the requirements do not actually specify what to do with a Powerup if the Wizert is already full on either his HP or MP when it finds one.
 *     The requirements just say that he consumes the Powerup and that's it. To me, if he's at full health and finds a health potion, then he shouldn't just waste it,
 *     he should save it for later for when he would need it then. Of course, this means that he just leaves the potion there and does not take it with him, 
 *     but doing that would directly go against the design requirements layed out for us, so I'll just settle for having him leave the potions when he is already full.
 * 
 * ??? How should we handle players giving us weird or invalid input during battle? Should the Game be nice and just repeatidly ask for input until it gets a valid response?
 *      Or should the Game be mean by skipping the Wizert's turn and then let the Enemy have it's turn and let it hit the player? In order to answer this question, 
 *      normally I would default back to week 10's lesson about user input and validation which would be to go with the nice option, keep asking until the user gets it right.
 *      That said, I do kinda want to do it the mean way, but I think it would be better to do it the nice way just in case that is a requirement and I missed it.
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

Random rnd = new();
int randInt;
string? input;
bool firstTime;
bool gameOver;
bool continuePlaying = true;
List<GameObject>[,] theDungeon;
Wizert wizert = new();
Room room = new(false, "The room is hard to see in the current light. You take a moment for your eyes to adjust to the darkness.");
Enemy? enemy;
Powerup powerup = new(Powerup.PotionType.Health);
(int, int) prevRoom = (0, 0);
(int, int) exitRoom = (0, 0);
(int, int) currentRoom = (0, 0);
List<(int, int, GameObject)> gameObjectsToRemove = new() { };
List<string> roomDescriptions;

/* Ok, new plan for spawning everything:
 * 
 * PLEASE DISREGARD EVERYTHING LISTED BELOW FOR NOW!
 * As I am refactoring and redesigning things for this project, I am for sure going to be changing how the spawning for this game works so this is probably going to change
 * 
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
    roomDescriptions = new List<string>
        {
            "You are in a room illuminated by torches.  It reeks of orc, though you do not see any nearby.",
            "Withered corpses are nailed to the corridor walls.",
            "Skeletons hang from chains and manacles against the walls.",
            "Several square holes are cut into the walls here.",
            "A narrow shaft falls into the center from above.",
            "A metallic odor fills the room.",
            "A scratching sound fills the room.",
            "A chute falls into the room from above.",
            "Numerous pillars line the room.",
            "Ghostly music fills the room.",
            "Upon a glancing look the room appears to be empty.",
            "A stream of water flows along a channel in the floor. Someone has scrawled \"The thief will betray you\" on the north wall.",
            "A well lies in the north-east corner of the room. A sundered & shattered helm lies in the south-west corner of the room.",
            "The walls are covered with cracks. A rusted chain shirt lies in the south-west corner of the room.",
            "A chute descends from the room into a pitch-black void below. Someone has scrawled \"You cannot kill it with wizardry\" in dwarvish runes on the east wall.",
            "Several iron cages are scattered throughout the room. Someone has scrawled an arcane symbol on the south wall.",
            "A faded and torn tapestry hangs from the north wal. Someone has scrawled \"Praise Illfang the Kobold Lord\" in orcish runes on the south wall.",
            "A stream of oil flows along a channel in the floor. A torn satchel lies in the north side of the room.",
            "A shallow pit lies in the north side of the room. The floor is covered in square tiles, alternating white and black.",
            "A tile mosaic of a legendary battle covers the floor. Someone has scrawled \"They ate Thainarv\" on the south wall.",
            "Someone has scrawled \"Abandon all hope\" on the west wall. A sour odor fills the room.",
            "An iron cauldron and round table sit in the south-west corner of the room. Someone has scrawled \"Three steps forward, six steps back\" on the east wall.",
            "A splashing noise can be faintly heard near the east wall. A pile of rotten fruit lies in the south-west corner of the room.",
            "A narrow ledge runs along the north and east walls. Spirals of blue stones cover the floor.",
            "Numerous pillars line the walls. Someone has scrawled \"Breder's Shields looted this place\" on the east wall.",
            "The room is hard to see in the current light. You take a moment for your eyes to adjust to the darkness."
        };
    randInt = rnd.Next(4);
    switch (randInt)
    {
        case 0:
            randInt = rnd.Next(roomDescriptions.Count);
            theDungeon[0, 0].Add(new Room(true, roomDescriptions[randInt]));
            roomDescriptions.RemoveAt(randInt);
            exitRoom = (0, 0);
            foreach (var item in theDungeon) if (item.Count == 0)
                {
                    randInt = rnd.Next(roomDescriptions.Count);
                    item.Add(new Room(false, roomDescriptions[randInt]));
                    roomDescriptions.RemoveAt(randInt);
                }
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
            randInt = rnd.Next(roomDescriptions.Count);
            theDungeon[0, 4].Add(new Room(true, roomDescriptions[randInt]));
            roomDescriptions.RemoveAt(randInt);
            exitRoom = (0, 4);
            foreach (var item in theDungeon) if (item.Count == 0)
                {
                    randInt = rnd.Next(roomDescriptions.Count);
                    item.Add(new Room(false, roomDescriptions[randInt]));
                    roomDescriptions.RemoveAt(randInt);
                }
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
            randInt = rnd.Next(roomDescriptions.Count);
            theDungeon[4, 0].Add(new Room(true, roomDescriptions[randInt]));
            roomDescriptions.RemoveAt(randInt);
            exitRoom = (4, 0);
            foreach (var item in theDungeon) if (item.Count == 0)
                {
                    randInt = rnd.Next(roomDescriptions.Count);
                    item.Add(new Room(false, roomDescriptions[randInt]));
                    roomDescriptions.RemoveAt(randInt);
                }
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
            randInt = rnd.Next(roomDescriptions.Count);
            theDungeon[4, 4].Add(new Room(true, roomDescriptions[randInt]));
            roomDescriptions.RemoveAt(randInt);
            exitRoom = (4, 4);
            foreach (var item in theDungeon) if (item.Count == 0)
                {
                    randInt = rnd.Next(roomDescriptions.Count);
                    item.Add(new Room(false, roomDescriptions[randInt]));
                    roomDescriptions.RemoveAt(randInt);
                }
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
            if (gameObjectsToRemove.Count > 0)
            {
                foreach (var item in gameObjectsToRemove)
                {
                    theDungeon[item.Item1, item.Item2].Remove(item.Item3);
                }
                gameObjectsToRemove = new List<(int, int, GameObject)> { };
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
                    Console.WriteLine();
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
                                        Console.WriteLine("You cast a spell to heal your wounds.");
                                        wizert.AdjustMP(-5);
                                        wizert.AdjustHP(3);
                                        Console.WriteLine($"You now have {wizert.GetHP()} HP and {wizert.GetMP()} MP.");
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
                    foreach (GameObject testRoom in theDungeon[currentRoom.Item1, currentRoom.Item2])
                    {
                        if (Room.ReferenceEquals(testRoom.GetType(), room.GetType()))
                        {
                            if (testRoom != null)
                            {
                                room = (Room)testRoom;
                                Console.WriteLine($"{room.GetDescription()}");
                            }
                        }
                    }
                    
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
                                Console.WriteLine();
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
                                                    Console.WriteLine("You cast a fireball that burns the enemy.");
                                                    wizert.AdjustMP(-3);
                                                    enemy.AdjustHP(-5);
                                                    //Console.WriteLine($"The {enemy.GetEnemyName()} now has {enemy.GetHP()} HP.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You try to cast a fireball, but find that you do not have enough MP to finish casting the spell.");
                                                    Console.WriteLine($"You currently have {wizert.GetMP()} MP left.");
                                                }

                                                if (enemy.GetHP() <= 0)
                                                {
                                                    Console.WriteLine($"The {enemy.GetEnemyName()} burns to a crisp.");
                                                    gameObjectsToRemove.Add((currentRoom.Item1, currentRoom.Item2, enemy));
                                                    //theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(enemy); 
                                                    // ^^^Removing an item from the collection that you're looping through will cause a runtime error.
                                                    wizert.SetNextState(WizertState.Search);
                                                }
                                                else
                                                {
                                                    Console.Write($"The {enemy.GetEnemyName()} uses it's {enemy.GetAttackName()} attack. ");
                                                    //Console.WriteLine($"It deals {enemy.GetAttackDamage()} damage");
                                                    wizert.AdjustHP(-enemy.GetAttackDamage());
                                                    //Console.WriteLine($"You have {wizert.GetHP()} HP left.");
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
                                                    Console.WriteLine("You cast a spell to heal your wounds.");
                                                    wizert.AdjustMP(-5);
                                                    wizert.AdjustHP(3);
                                                    Console.WriteLine($"You now have {wizert.GetHP()} HP and {wizert.GetMP()} MP.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You try to cast a heal, but find that you do not have enough MP to finish casting the spell.");
                                                    Console.WriteLine($"You currently have {wizert.GetMP()} MP left.");
                                                }

                                                Console.Write($"The {enemy.GetEnemyName()} uses it's {enemy.GetAttackName()} attack. ");
                                                //Console.WriteLine($"It deals {enemy.GetAttackDamage()} damage");
                                                wizert.AdjustHP(-enemy.GetAttackDamage());
                                                //Console.WriteLine($"You have {wizert.GetHP()} HP left.");

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
                                                    //Console.WriteLine($"It deals {enemy.GetAttackDamage()} damage");
                                                    wizert.AdjustHP(-enemy.GetAttackDamage());
                                                    //Console.WriteLine($"You have {wizert.GetHP()} HP left.");
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
                                                    gameObjectsToRemove.Add((currentRoom.Item1, currentRoom.Item2, wizert));
                                                    //theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(wizert);
                                                    // ^^^Removing an item from the collection that you're looping through will cause a runtime error.
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
                                        gameObjectsToRemove.Add((currentRoom.Item1, currentRoom.Item2, powerup));
                                        //theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(powerup);
                                        // ^^^Removing an item from the collection that you're looping through will cause a runtime error.
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
                                        gameObjectsToRemove.Add((currentRoom.Item1, currentRoom.Item2, powerup));
                                        //theDungeon[currentRoom.Item1, currentRoom.Item2].Remove(powerup);
                                        // ^^^Removing an item from the collection that you're looping through will cause a runtime error.
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
            Console.WriteLine("");
        }
    }

    Console.WriteLine("Would you like to play the game again? Press...\r" +
        "\n1.\tYes\r" +
        "\n2.\tNo\r");
    input = Console.ReadLine();
    Console.WriteLine();
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

