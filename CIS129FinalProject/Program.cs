// See https://aka.ms/new-console-template for more information
using CIS129FinalProject;
using System;
using System.Diagnostics.Metrics;
using System.Net;
using static CIS129FinalProject.Wizert;

/* TODO and DONE List:
 * 
 * DONE: This NEEDS to be a text-based adventure game, no fansey graphical interfaces. (booo!)
 * 
 * DONE: The Player will take control of the Wizert
 * DONE: The Wizert uses Magicka to attack his Enemies
 * DONE: There is a Dungeon and the Wizert is caught inside it
 * DONE: The Wizert must Fight his way out of the Dungeon in order to not Die
 * DONE: If the Wizert manages to escape from the Dungeon, the Player Wins
 * DONE: The Wizert can move in four directions: North, South, East, & West
 * DONE: The Game needs to keep track of the Wizert's current location
 * DONE: The Wizert's current location is not information avalible to the player
 * DONE: After the Wizert Moves, he could encounter an Enemy
 * DONE: Durring an Enemy encounter, the Wizert has three options to choose from: Fireball, Heal, & Flee
 * DONE: The Fireball Attack has the listed description from the README, costs the Wizert 3 MP, and does 5 Damage to the Enemy
 * DONE: The Heal Option/Action has the listed description from the README, costs the Wizert 5 MP, and Heals 3 Heath Points (HP) to the Wizert
 * DONE: The Flee Option/Action has the listed description from the README, costs the Wizert 0 MP, and has a chance of allowing the Wizert to escape from the current Encounter
 * DONE: When an Action is performed, a description of what is happening should be displayed
 * DONE: When using an Action, the amount of MP consumed and the effects of the Action should be displayed.
 * DONE: When an Enemy takes an Attack from the Wizert, a display of the Enemy's new current HP should be displayed.
 * DONE: At the start of the game, the Wizert starts with 100 Health Points (HP) and 200 Magicka Points (MP).
 * DONE: If the Wizert's HP is depleted to 0 before escaping the Dungeon, it is Game Over (Bad Ending)
 * DONE: A message indicating that "The Wizert has lost" should be displayed to the console.
 * DONE: Once the Game is over, there should be an offer to play the Game again
 * 
 * DONE: There are three kinds/types of Enemies in the Dungeon
 * DONE: At least one of each type of Enemy should spawn within the Dungeon
 * DONE: Each Enemy type has their own Name, starting HP, Attack Name, and Attack Damage (See the README Table)
 * DONE: When an Enemy attacks, 1 to 3 message(s) should be displayed to the user informing them:
 *       The name of the attack used, How much damage it cuased, and How much health the Wizert has left.
 * DONE: Enemy encounters should be set manually, not by chance. (Not like Pokemon's tall grass chance encounters)
 * DONE: You will not always engage in battle after making a move
 * DONE: At least half of your locations (13+) should have an Enemy
 * DONE: If you do engenge in battle in a certain location and defeat the Enemy there, then the Wizert should never have to fight in that spot again should they return to that location
 * DONE: If the Wizert flees the area, that same Enemy is still there waiting for him to continue the fight
 *       The Enemy's HP should be the same as it was after fleeing
 * 
 * DONE: Powerups should be scattered throughout the dungeon
 * DONE: There are 2 Powerup types: a Health Potion that restores 10 HP, and a Magicka Potion that Restores 20 MP
 * DONE: Each Powerup type has the name, description, and effect listed in the table in the README
 * DONE: Powerup locations should be set manually, just as with Enemy locations (No tall grass Pokemon logic)
 * DONE: The number of Powerups found in the Dungeon are at your discretion (Minimum 2, one of each type)
 * DONE: The Wizert should Automatically consume the Powerup if it is avalible at their location
 * DONE: A Powerup should only be avalible to be used only once at that location (Only one time use, no moving the Powerup)
 * DONE: Once a Powerup is used, no new or replacement Powerup should be present if the WIzert backtracks to that location
 * DONE: After consuming a Powerup, display how much HP or MP was restored, then display both the current HP and current MP of the Wizert
 * 
 * DONE: The Dungeon should be seperated into smaller Units
 * DONE: Each Unit represents a location of the dungeon that the Wizert can travel to
 * DONE: The Dungeon should be a 5x5 2D matrix of these Units for a total of 25 possible Units that the Wizert could travel to
 * DONE: A data structure that we learned in class should be what we use to support and represent this 2D graph
 * DONE: There should be walls surrounding the perimeter of the Dungeon that prevents the Wizert from traveling out of bounds
 *       You do not need to place walls anywhere else in the Dungeon. You can, but it is not required
 * DONE: Every Unit should have a description that describes the section of the Dungeon that the Wizert is in
 * DONE: This Unit description will be printed on the Console after each move
 *       Descriptions may be reused, but having them all be unique would be cool (A minimum of 25 descriptions would be required to do this)
 * DONE: After the description is displayed, the Wizert could also either encounter an Enemy or a Powerup
 *       Doing so will either iniciate an battle/combat or consume the Powerup respectively
 * DONE: Encountering an Enemy &/or Powerup should not be by chance, these should be set up manually in the code (No Pokemon tall grass mechanics)
 * DONE: If both an Enmey and a Powerup appear in the same location at the same time, have the Wizert fight off the Enemy first before consuming the Powerup
 * DONE: Upon startup, determine both the starting position of the Wizert and the Dungeon Exit location randomly
 *       These locations should not be displayed to the player, but they should still be saved somewhere for your program to remember them for determining other logic
 * DONE: When the Wizert reaches the exit, stop the Game and inform the player "You have won", then offer to let them play again
 * 
 * DONE: Practice good input validation when developing this application (See Input Validation HW)
 * DONE: When asking for user input, give the user options to select from (See the example in the README)
 * DONE: Validate that the user entered an expected number to the console
 * DONE: Ensure all of these steps for both when the Wizert is in battle and for when they are moving throughout the Dungeon
 * 
 * 
 * Make Sure To Use:
 * DONE: Various and Appropriate Data Types
 * DONE: Data Structures
 * DONE: Input Validation
 * TODO: Any External Libraries (I might end up not using any myself, ... oops, oh well I guess.)
 * DONE: Creating Classes
 * DONE: Instatiating your Classes into Objects
 * DONE: Appropriate Opperators
 * DONE: Conditional Statements (IF and/or Switch)
 * DONE: Loops
 * DONE: Inheritance
 * DONE: Encapsulation (Each Class is its own file & Do not put all of the funtionality into a single file)
 * (^This might not be 100% realized, but I've done the best that I think that I can do to accomplbish this for now.^)
 * 
 * 
 * Refactorings I want to make:
 * DONE: I want to change the Dungeon so that it is a 2D matrix of Room Objects, not a 2D matrix of List<GameObject> collections. This should be somewhat simple
 *       because each Room Object should only ever have 0 to 1 Wizert Objects, 0 to 1 Enemy Objects, and 0 to 1 Powerup Objects.
 *       Doing this should also allow me to do what I've wanted in the beginning which was have our Wizert actually be IN the Dungeon, like within the Dungeon Object!
 *      
 * DONE: I wanna adjust the dialogue for the Enemy encounters. Right now it repeats "You have encountered a [EnemyName]" each time when it should probably only say that
 *       for the first round of combat while any rounds of combat after the first should say something like, "You continue your battle against the [EnemyName]".
 * 
 * DONE: Depending on how my refactoring goes, I may or may not get rid of my "Garbage Collection" code since if I'm going to try to store everything in my Room Objects
 *       now rather than in a List in the Dungeon, then I should be able to edit the Room Objects more safely than deleting an entire object from a list while that
 *       list is in the middle of a for/forEach loop.
 * 
 * DONE: I want to add more comments to my code, basically moving the comments that I have below as well as some of the lines from the above checklist to where these 
 *       described comments happen in my code. I know the Prof. said that sometimes comments can be bad since we hope that code can just describe what it is doing itself, 
 *       but if I'm not going to documente this code then I want some more descriptions at what I am looking at.
 * 
 * DONE: Adjust the GameUnit class and all of its children to use the "Unit" variables rather than the Enemy or Wizert variables.
 *       This includes putting the name, hp, maxHp, attackName, attackDamage, etc all into GameUnit and not seperated between Wizert or Enemy.
 *       I was orignally going to add an attackDescription variable, but since this would mainly only apply to the Wizert and it is for only his one attack, it doesn't seem worth it.
 * 
 * DONE: Delete the HealthPotion.cs and MagickaPotion.cs files. I've already been able to achieve their funtionality by using an enum within the Powerup class 
 *       so they are not needed anymore.
 * 
 * DONE: Go through and delete any commented out code. I kept most of these since I wasn't sure if I needed to go back to using them. 
 *       But now I know that I don't need them so they are unnessary and get in the way of actual code and actual comments.
 * 
 * TODO: (Not Doing) When giving out options to the player, it might be a cool and good idea to ONLY display the options that the player can actually do.
 *       For example, if the Wizert is already all the way North as possible, then we could choose to not display "Go North" as an option to them.
 *       Doing this though may get a bit complicated, so I say it is fine if I don't get to this one.
 * 
 * TODO: (Not Doing) If it is possible to put all of the sections that ask for user input together into one function, that would be great. 
 *       However, I still do not know how I would go about trying to achieve this. Plus I would mainly only want to do this if I do the above with filtering out player options.
 * 
 * TODO: (Started Doing) It would also be nice to encapsulate some of the functionality of this Program.cs file into some functions within ProgramHelper.cs, espacially for any times 
 *       I find repeated blocks of code or chunks of code that take up a lot of vertical space like spawning the dungeon. 
 *       (I have kind of done this one already, but there may be more that I would want to do. By this TODO's very nature, there is not ever a very clean &/or obvious "DONE" for it.)
 * 
 * 
 * Additional Questions or Confusions that I have that I need to solve for myself
 * DONE:
 * ??? Who attacks first each combat? The Wizert? The Enemies? Is it random? I want to make it a 50/50 if an enemy gets an attack off first before the Wizert,
 *     but after looking at the example that Prof. Wu provided it appears as though the Wizert will always move before the enemies when he first encounters them.
 *     However, that was just an example and I cannot find an answer to this specific question, so I'll do it my way.
 * 
 * DONE:
 * ??? Would the Wizert not just be able to heal themselves outside of combat? That just seems more like a common sense question more than anything else.
 *     Even though the provided example does not show this to be an option, I would like to do so for my version as a sort of Quality of Life change.
 * 
 * DONE:
 * ??? I just noticed that the requirements do not actually specify what to do with a Powerup if the Wizert is already full on either his HP or MP when it finds one.
 *     The requirements just say that he consumes the Powerup and that's it. To me, if he's at full health and finds a health potion, then he shouldn't just waste it,
 *     he should save it for later for when he would need it then. Of course, this means that he just leaves the potion there and does not take it with him, 
 *     but doing that would directly go against the design requirements layed out for us, so I'll just settle for having him leave the potions when he is already full.
 * 
 * DONE:
 * ??? How should we handle players giving us weird or invalid input during battle? Should the Game be nice and just repeatidly ask for input until it gets a valid response?
 *      Or should the Game be mean by skipping the Wizert's turn and then let the Enemy have it's turn and let it hit the player? In order to answer this question, 
 *      normally I would default back to week 10's lesson about user input and validation which would be to go with the nice option, keep asking until the user gets it right.
 *      That said, I do kinda want to do it the mean way, but I think it would be better to do it the nice way just in case that is a requirement and I missed it.
 * 
 * DONE:
 * ??? When the Wizert successuflly flees from a battle, in what direction do they flee in? The README doesn't describe this at all, they just say they "Flee" ...
 *      This could mean that the Wizert would then be able to move however they want, however to me I imagine that trying to "Flee" would involve trying to get back to 
 *      known safety, as in where they originally came from. As such, if the Wizert succeeds in fleeing, then they just go back to the room that they were previously in.
 * 
 * DONE:
 * ??? So the when it comes to spawning the Wizert and the Exit at the start of the game, the README doesn't actually specify if it is ok for these two things to spawn
 *      at the same location. However, I believe it is implied that these two starting locations should be different from one another, so that's what I'll do.
 *      The same thing goes for the enemies, I have them not spawn in the Wizert's starting room. This is also to make sure that the Wizert always moves at least once to set his
 *      previousLocation for him to Flee back to. Without this, he's have nowhere to Flee to. Now as for Powerups, ... I could see it going either way.
 * 
 * DONE:
 * ??? So I've already gone over this with the professor, but the "Manual spawning" for the Enemies and Powerups is still a bit wierd to me. Honestly, I don't want to 
 *      set any of it up manually myself, I would much rather perfer that it be random somehow. Before I said that the decent compromise between these two views is to 
 *      have each of these spawn in psudo-randomly by having predesigned patterns and then having one of these patterns get picked to use. But to me, both as a game 
 *      designer and as a player, after playing this game for a while with this, I find that it is a lot more fun when there are more things that are unpredictable. 
 *      As such, I am just going to go ahead and make the placements of my Enemies and Powerups random. If this costs me to lose points over this, oh well, I still 
 *      think that doing it this way is an improvement, in my opinion anyway.
 * 
 */

Random rnd = new();
int randInt1;

Room[,] theDungeon;

bool gameOver;
bool continuePlaying = true;

string? input;

bool isFirstRoundOfCombat = false;

do
{
    //- Reset the Game
    theDungeon = ProgramHelper.GenerateDungeon(rnd);

    gameOver = false;

    //- Start the Game loop
    while (!gameOver)
    {
        // Find the Wizert in the Dungeon
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (theDungeon[x, y].IsWizertHere())
                {
                    theDungeon[x, y].GetWizert()!.Update();
                    switch (theDungeon[x, y].GetWizert()!.GetState())
                    {
                        case Wizert.WizertState.Spawn:
                            Console.WriteLine("You, the Wizert, have found yourself within the Dungeon yet again, ...");
                            theDungeon[x, y].GetWizert()!.SetNextState(Wizert.WizertState.Search);
                            break;

                        //- Once in the Move state, the game will ask the player which direction they want to move, North, South, East, or West.
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
                                            if (x == 0)
                                            {
                                                Console.WriteLine("but you find no door on this wall.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("and you go through the door.");

                                                //> After moving, the Wizert will start searching this new room.
                                                theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Search);
                                                theDungeon[x, y].GetWizert()!.SetPreviousRoom((x, y));
                                                theDungeon[x, y].MoveWizertToOtherRoom(theDungeon[x - 1, y]);
                                            }
                                            break;

                                        case "2":
                                            Console.Write("You head to the south side of the room ");
                                            if (x == 4)
                                            {
                                                Console.WriteLine("but you find no door on this wall.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("and you go through the door.");

                                                //> After moving, the Wizert will start searching this new room.
                                                theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Search);
                                                theDungeon[x, y].GetWizert()!.SetPreviousRoom((x, y));
                                                theDungeon[x, y].MoveWizertToOtherRoom(theDungeon[x + 1, y]);
                                            }
                                            break;

                                        case "3":
                                            Console.Write("You head to the east side of the room ");
                                            if (y == 4)
                                            {
                                                Console.WriteLine("but you find no door on this wall.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("and you go through the door.");

                                                //> After moving, the Wizert will start searching this new room.
                                                theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Search);
                                                theDungeon[x, y].GetWizert()!.SetPreviousRoom((x, y));
                                                theDungeon[x, y].MoveWizertToOtherRoom(theDungeon[x, y + 1]);
                                            }
                                            break;

                                        case "4":
                                            Console.Write("You head to the west side of the room ");
                                            if (y == 0)
                                            {
                                                Console.WriteLine("but you find no door on this wall.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("and you go through the door.");

                                                //> After moving, the Wizert will start searching this new room.
                                                theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Search);
                                                theDungeon[x, y].GetWizert()!.SetPreviousRoom((x, y));
                                                theDungeon[x, y].MoveWizertToOtherRoom(theDungeon[x, y - 1]);
                                            }
                                            break;

                                        //> Alternatively to moving, the player may also opt to not move for now and to heal themselves.
                                        case "5":
                                            theDungeon[x, y].GetWizert()!.CastHealSpell();
                                            break;

                                        default:
                                            Console.WriteLine("Please choose a valid, single digit number from what is listed.");
                                            break;
                                    }
                                }
                            }
                            break;

                        //- The Wizert will start its behaivor by searching the Room that he finds himself in
                        case Wizert.WizertState.Search:

                            //- First the Wizert will report to the player a meaningless but colorful description of the room.
                            Console.WriteLine($"{theDungeon[x, y].GetDescription()}");

                            //- Next in its search, the Game will report to the player if there is a Powerup, an Exit, &/or an Enemy in the room.
                            //- If none of these things are present, the Wizert will go to its Move state
                            theDungeon[x, y].GetWizert()!.SetNextState(Wizert.WizertState.Move);

                            //- If any of these things are found, the Wizert will address each of them in reverse order.
                            if (theDungeon[x, y].GetPowerup() != null)
                            {
                                if (Powerup.ReferenceEquals(theDungeon[x, y].GetPowerup()!.GetType(), new Powerup(Powerup.PotionType.Health).GetType()))
                                {
                                    Console.WriteLine("While surveying the room, you notice a potion off in the corner.");
                                    theDungeon[x, y].GetWizert()!.SetNextState(Wizert.WizertState.UsePowerup);
                                }
                            }

                            if (theDungeon[x, y].IsExit())
                            {
                                Console.WriteLine("And then you see it! The exit to this dungeon!");
                                theDungeon[x, y].GetWizert()!.SetNextState(Wizert.WizertState.Exit);
                            }
                            else
                            {
                                Console.WriteLine("After searching for a while, you do not see an exit to this dungeon.");
                            }

                            if (theDungeon[x, y].GetEnemy() != null)
                            {
                                if (ProgramHelper.IsObjectAnEnemy(theDungeon[x, y].GetEnemy()!))
                                {
                                    Console.WriteLine("But suddenly, you see something move.");
                                    theDungeon[x, y].GetWizert()!.SetNextState(Wizert.WizertState.Battle);
                                    isFirstRoundOfCombat = true;
                                }
                            }
                            break;

                        //- If we've gotten to this state, then there is an Enemy in the room!
                        case Wizert.WizertState.Battle:
                            if (theDungeon[x, y].GetEnemy() != null)
                            {
                                if (ProgramHelper.IsObjectAnEnemy(theDungeon[x, y].GetEnemy()!))
                                {
                                    // 
                                    if (theDungeon[x, y].GetEnemy()!.GetHasMet())
                                    {
                                        Console.WriteLine($"You continue your battle against the {theDungeon[x, y].GetEnemy()!.GetUnitName()}.");
                                    }
                                    else
                                    {
                                        // The "GetAOrAn() is for when an Enemy Name starts with a vowel letter, like with "Orc".
                                        Console.WriteLine($"You have encountered {theDungeon[x, y].GetEnemy()!.GetAOrAn()} {theDungeon[x, y].GetEnemy()!.GetUnitName()}.");
                                        theDungeon[x, y].GetEnemy()!.SetHasMet(true);
                                    }

                                    // There is a 50% chance that either the Enemy will go first or the Wizert.
                                    if (isFirstRoundOfCombat)
                                    {
                                        randInt1 = rnd.Next(2);
                                        if (randInt1 == 0)
                                        {
                                            Console.WriteLine("The enemy managed to suprise you and was able to attack you before you could react!");
                                            Console.WriteLine($"The {theDungeon[x, y].GetEnemy()!.GetUnitName()} uses it's {theDungeon[x, y].GetEnemy()!.GetAttackName()} attack. ");
                                            theDungeon[x, y].GetWizert()!.AdjustHP(-theDungeon[x, y].GetEnemy()!.GetAttackDamage());
                                        }
                                    }
                                    isFirstRoundOfCombat = false;

                                    // We need to check if the Wizert has died from the Enemy's most recent attack!
                                    //> If the Wizert's HP is brought down to 0 or less, then the Wizert Dies.
                                    if (theDungeon[x, y].GetWizert()!.GetHP() <= 0)
                                    {
                                        Console.WriteLine("You have ran out of HP.");
                                        theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Die);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"It's current HP is {theDungeon[x, y].GetEnemy()!.GetHP()}.");
                                        //> The player gets the choice of either attacking that Enemy, Healing themselves, or trying to run away.
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
                                                    //> If they choose to Attack, then the Wizert expends some MP and damages the Enemy.
                                                    case "1":
                                                        // Still need to check if the wizert has enough MP to be able to cast any of its spell options, ...
                                                        if (theDungeon[x, y].GetWizert()!.CanCastFireball()) theDungeon[x, y].GetEnemy()!.AdjustHP(-5);

                                                        // After attacking the Enemy, we need to check its current HP.
                                                        if (theDungeon[x, y].GetEnemy()!.GetHP() <= 0)
                                                        {
                                                            //> If the Enemy's HP is set to 0 or less, the Enemy dies and is deleted.
                                                            Console.WriteLine($"The {theDungeon[x, y].GetEnemy()!.GetUnitName()} burns to a crisp.");
                                                            theDungeon[x, y].SetEnemy(null);

                                                            //>Once the Enemy is deleted, the Wizert will go back to searching the room.
                                                            theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Search);
                                                        }
                                                        else
                                                        {
                                                            //> If after this choice the Wizert is still in the same room with an Enemy still remaining,
                                                            //  then the Enemy attacks the Wizert and damages them.
                                                            Console.WriteLine($"The {theDungeon[x, y].GetEnemy()!.GetUnitName()} uses it's {theDungeon[x, y].GetEnemy()!.GetAttackName()} attack. ");
                                                            theDungeon[x, y].GetWizert()!.AdjustHP(-theDungeon[x, y].GetEnemy()!.GetAttackDamage());
                                                        }

                                                        //> If the Wizert's HP is brought down to 0 or less, then the Wizert Dies.
                                                        if (theDungeon[x, y].GetWizert()!.GetHP() <= 0)
                                                        {
                                                            Console.WriteLine("You have ran out of HP.");
                                                            theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Die);
                                                        }
                                                        break;

                                                    //> If they choose to Heal, then the Wizert expends some MP and restores some of the Wizert's HP.
                                                    case "2":
                                                        theDungeon[x, y].GetWizert()!.CastHealSpell();

                                                        //> If after this choice the Wizert is still in the same room with an Enemy still remaining,
                                                        //  then the Enemy attacks the Wizert and damages them.
                                                        Console.WriteLine($"The {theDungeon[x, y].GetEnemy()!.GetUnitName()} uses it's {theDungeon[x, y].GetEnemy()!.GetAttackName()} attack. ");
                                                        theDungeon[x, y].GetWizert()!.AdjustHP(-theDungeon[x, y].GetEnemy()!.GetAttackDamage());

                                                        //> If the Wizert's HP is brought down to 0 or less, then the Wizert Dies.
                                                        if (theDungeon[x, y].GetWizert()!.GetHP() <= 0)
                                                        {
                                                            Console.WriteLine("You have ran out of HP.");
                                                            theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Die);
                                                        }
                                                        break;

                                                    //> If they choose to Flee, then the Wizert has a 50% chance of sucessfully fleeing back to the previous room that they came in from.
                                                    case "3":
                                                        Console.WriteLine("You attempt to flee from the battle.");
                                                        Console.WriteLine("...");
                                                        randInt1 = rnd.Next(2);
                                                        if (randInt1 == 0)
                                                        {
                                                            //> If they fail this 50% chance, then a notification informing them of this failure occurs.
                                                            Console.WriteLine("You did not successfully escape from the battle.");

                                                            //> If after this choice the Wizert is still in the same room with an Enemy still remaining,
                                                            //  then the Enemy attacks the Wizert and damages them.
                                                            Console.WriteLine($"The {theDungeon[x, y].GetEnemy()!.GetUnitName()} uses it's {theDungeon[x, y].GetEnemy()!.GetAttackName()} attack. ");
                                                            theDungeon[x, y].GetWizert()!.AdjustHP(-theDungeon[x, y].GetEnemy()!.GetAttackDamage());

                                                            //> If the Wizert's HP is brought down to 0 or less, then the Wizert Dies.
                                                            if (theDungeon[x, y].GetWizert()!.GetHP() <= 0)
                                                            {
                                                                Console.WriteLine("You have ran out of HP.");
                                                                theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Die);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //> If they win this 50% chance, then a notification informing them of thier success occurs.
                                                            Console.WriteLine("You successfully escaped from the battle.");
                                                            Console.WriteLine("You were able to return back to the room that you were previously in.");

                                                            // Move back to your previous location, ...
                                                            theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Search);
                                                            (int, int) _temp = theDungeon[x, y].GetWizert()!.GetPreviousRoom();
                                                            theDungeon[x, y].GetWizert()!.SetPreviousRoom((x, y));
                                                            theDungeon[x, y].MoveWizertToOtherRoom(theDungeon[_temp.Item1, _temp.Item2]);
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

                        //- If there is a Powerup in the room but no Exit and no Enemy, then we move to this state
                        case Wizert.WizertState.UsePowerup:
                            if (theDungeon[x, y].GetPowerup() != null)
                            {
                                if (Powerup.ReferenceEquals(theDungeon[x, y].GetPowerup()!.GetType(), new Powerup(Powerup.PotionType.Health).GetType()))
                                {
                                    Console.WriteLine("You look closer to examine the potion.");
                                    if (theDungeon[x, y].GetPowerup()!.GetPotionType() == Powerup.PotionType.Health)
                                    {
                                        Console.WriteLine("Upon closer inspection it appears to be a health potion.");

                                        //> If the Wizert's stat for the powerup is already at its max value then it won't use the Powerup.
                                        // Otherwise, the Wizert will consume the Powerup, restoring that particular stat by a bit and deleting the Powerup.
                                        if (theDungeon[x, y].GetWizert()!.GetHP() >= theDungeon[x, y].GetWizert()!.GetMaxHP())
                                        {
                                            Console.WriteLine("You choose not to take the potion now since you don't need it.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You choose to take the potion now to restore some health since you need it.");
                                            theDungeon[x, y].GetWizert()!.AdjustHP(theDungeon[x, y].GetPowerup()!.GetRestoreAmount()); // RestoreAmount for HP is 10
                                            theDungeon[x, y].SetPowerup(null);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Upon closer inspection it appears to be a magicka potion.");

                                        //> If the Wizert's stat for the powerup is already at its max value then it won't use the Powerup.
                                        // Otherwise, the Wizert will consume the Powerup, restoring that particular stat by a bit and deleting the Powerup.
                                        if (theDungeon[x, y].GetWizert()!.GetMP() >= theDungeon[x, y].GetWizert()!.GetMaxMP())
                                        {
                                            Console.WriteLine("You choose not to take the potion now since you don't need it.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You choose to take the potion now to restore some magicka since you need it.");
                                            theDungeon[x, y].GetWizert()!.AdjustMP(theDungeon[x, y].GetPowerup()!.GetRestoreAmount()); // RestoreAmount for MP is 20
                                            theDungeon[x, y].SetPowerup(null);
                                        }
                                    }
                                }
                            }

                            //> After this, the Wizert will decide where they want to move.
                            //  Insead of having them search the room again, it is simplier to have them go straight into moving.
                            theDungeon[x, y].GetWizert()!.SetNextState(WizertState.Move);
                            break;

                        //- If the Exit is in the room, then the Wizert Exits the Dungeon and the player wins!
                        case Wizert.WizertState.Exit:
                            Console.Write("And with that, you finally touch the exit and you are whisked out of the dungeon. ");
                            Console.WriteLine("You have won!");

                            //- Once the Wizert either Exits the Dungeon or Dies, it is Game Over!
                            gameOver = true;
                            break;

                        //- If at any point the Wizert's HP reaches 0 or less, then the Wizert Dies and the player loses.
                        case Wizert.WizertState.Die:
                            Console.Write("And with that, you take your last breath as you finally meet your end. ");
                            Console.WriteLine("You have lost.");

                            //- Once the Wizert either Exits the Dungeon or Dies, it is Game Over!
                            gameOver = true;
                            break;
                        
                        // If we've somehow defaulted on the Wizert's State, then something must have gone VERY wrong.
                        default:
                            Console.WriteLine("A critical error has occured {Wizert State}");
                            break;
                    }
                }
            }
        }
        
        Console.WriteLine("");
        //- Once it is Game Over, we will leave the game loop.
    }
    //- After leaving the Game loop, the program will ask if the player would like to play again.
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
                //- If yes then the Program will return back to "Reset the Game"
                case "1":
                    Console.WriteLine("Yes, you would like to Continue Playing.");
                    break;

                //-If no, then the Program will terminate.
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

