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

        public static Room[,] GenerateDungeon(Random rnd)
        {
            int randInt1;
            int randInt2;

            Room[,] theDungeon = new Room[5, 5]
            {
                {
                    new Room(false), new Room(false), new Room(false), new Room(false), new Room(false)
                },
                {
                    new Room(false), new Room(false), new Room(false), new Room(false), new Room(false)
                },
                {
                    new Room(false), new Room(false), new Room(false), new Room(false), new Room(false)
                },
                {
                    new Room(false), new Room(false), new Room(false), new Room(false), new Room(false)
                },
                {
                    new Room(false), new Room(false), new Room(false), new Room(false), new Room(false)
                }
            };
            List<string> roomDescriptions = new()
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
                "A faded and torn tapestry hangs from the north wall. Someone has scrawled \"Praise Illfang the Kobold Lord\" in orcish runes on the south wall.",
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

            bool isExitSpawned;
            int numEnemies;
            int numGoblins;
            int numOrcs;
            int numBanshees;
            bool enemiesSpawned;
            int numHealths;
            int numMagics;

            // Give each room their own unique description
            foreach (Room roomDesc in theDungeon)
            {
                randInt1 = rnd.Next(roomDescriptions.Count);
                roomDesc.SetDescription(roomDescriptions[randInt1]);
                roomDescriptions.RemoveAt(randInt1);
            }

            //-Spawn everything in according to their own logic
            // Spawn the Wizert in a random Room
            randInt1 = rnd.Next(4);
            randInt2 = rnd.Next(4);
            theDungeon[randInt1, randInt2].WizertEnters(new Wizert());

            // Crate the Exit in a DIFFERENT random Room
            isExitSpawned = false;
            do
            {
                randInt1 = rnd.Next(4);
                randInt2 = rnd.Next(4);
                if (!theDungeon[randInt1, randInt2].IsWizertHere())
                {
                    theDungeon[randInt1, randInt2].SetExit(true);
                    isExitSpawned = true;
                }
            } while (!isExitSpawned);

            // Spawning between 13-23 (inclusive) Enemies, at least 1 of each of the 3 types, in any room other than the Wizert's starting room
            numEnemies = 0;
            // Spawn Enemies until there are over at least 12 in the Dungeon
            while (numEnemies < 13)
            {
                foreach (Room enemyRoom in theDungeon)
                {
                    // We can't let any Enemies spawn in the same room as the Wizert's starting room, otherwise the Fleeing from battle logic will not work as intended.
                    // This is because the Wizert needs to move at least once to be able to properly set its "previousRoom" location for him to be able to Flee to later.
                    if (!enemyRoom.IsWizertHere() && enemyRoom.GetEnemy() == null)
                    {
                        randInt1 = rnd.Next(4);
                        switch (randInt1)
                        {
                            case 0:
                                break;
                            case 1:
                                enemyRoom.SetEnemy(new EnemyGoblin());
                                numEnemies++;
                                break;
                            case 2:
                                enemyRoom.SetEnemy(new EnemyOrc());
                                numEnemies++;
                                break;
                            case 3:
                                enemyRoom.SetEnemy(new EnemyBanshee());
                                numEnemies++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            // If there is more than 23 enemies in the Dungeon, either 24 or 25, then we need to remove enemies until we get back down to 23
            while (numEnemies > 23)
            {
                randInt1 = rnd.Next(4);
                randInt2 = rnd.Next(4);
                if (theDungeon[randInt1, randInt2].GetEnemy() != null)
                {
                    theDungeon[randInt1, randInt2].SetEnemy(null);
                    numEnemies--;
                }
            }

            // We need to ensure that at least 1 of each type of Enemy has spawned in the Dungeon
            enemiesSpawned = false;
            do
            {
                numGoblins = 0;
                numOrcs = 0;
                numBanshees = 0;
                foreach (Room enemyRoom in theDungeon)
                {
                    // Count the number of each type of enemy there is in the Dungeon
                    if (enemyRoom.GetEnemy() != null)
                    {
                        if (EnemyGoblin.ReferenceEquals(enemyRoom.GetEnemy()!.GetType(), new EnemyGoblin().GetType())) numGoblins++;
                        if (EnemyOrc.ReferenceEquals(enemyRoom.GetEnemy()!.GetType(), new EnemyOrc().GetType())) numOrcs++;
                        if (EnemyBanshee.ReferenceEquals(enemyRoom.GetEnemy()!.GetType(), new EnemyBanshee().GetType())) numBanshees++;
                    }
                }
                // If a certain type of Enemy has not been spawned into the Dungeon, then we need to spawn at least one of that type!
                // However, since we might already be at the maximum number of allowed Enemies, we need to replace other enemies rather than make any new ones
                if (numGoblins > 0 && numOrcs > 0 && numBanshees > 0) enemiesSpawned = true;
                while (numGoblins <= 0)
                {
                    randInt1 = rnd.Next(4);
                    randInt2 = rnd.Next(4);
                    if (!theDungeon[randInt1, randInt2].IsWizertHere() && theDungeon[randInt1, randInt2].GetEnemy() != null &&
                        !EnemyGoblin.ReferenceEquals(theDungeon[randInt1, randInt2].GetEnemy()!.GetType(), new EnemyGoblin().GetType()))
                    {
                        theDungeon[randInt1, randInt2].SetEnemy(new EnemyGoblin());
                        numGoblins++;
                    }
                }
                while (numOrcs <= 0)
                {
                    randInt1 = rnd.Next(4);
                    randInt2 = rnd.Next(4);
                    if (!theDungeon[randInt1, randInt2].IsWizertHere() && theDungeon[randInt1, randInt2].GetEnemy() != null &&
                        !EnemyGoblin.ReferenceEquals(theDungeon[randInt1, randInt2].GetEnemy()!.GetType(), new EnemyOrc().GetType()))
                    {
                        theDungeon[randInt1, randInt2].SetEnemy(new EnemyOrc());
                        numOrcs++;
                    }
                }
                while (numBanshees <= 0)
                {
                    randInt1 = rnd.Next(4);
                    randInt2 = rnd.Next(4);
                    if (!theDungeon[randInt1, randInt2].IsWizertHere() && theDungeon[randInt1, randInt2].GetEnemy() != null &&
                        !EnemyGoblin.ReferenceEquals(theDungeon[randInt1, randInt2].GetEnemy()!.GetType(), new EnemyBanshee().GetType()))
                    {
                        theDungeon[randInt1, randInt2].SetEnemy(new EnemyBanshee());
                        numBanshees++;
                    }
                }
            } while (!enemiesSpawned);

            // Now we want to spawn at least 2 Powerups in the Dungeon, at least 1 of each type, but there is a REALLY small chance of spawning more!
            numHealths = 0;
            numMagics = 0;
            foreach (Room powerupRoom in theDungeon)
            {
                // This gives everyroom a 1/25 chance to spawn a Health Potion and a 1/25 chance to spawn a Magicka Potion
                // I am choosing right now to allow Powerups to be able to spawn in the Wizert's starting Room & in the Exit Room, might change this later
                randInt1 = rnd.Next(25);
                if (randInt1 == 0)
                {
                    powerupRoom.SetPowerup(new Powerup(Powerup.PotionType.Health));
                    numHealths++;
                }
                else if (randInt1 == 1)
                {
                    powerupRoom.SetPowerup(new Powerup(Powerup.PotionType.Magika));
                    numMagics++;
                }
            }
            // If it "just so happens" that only one or neither of the Potion Types managed to spawn on their own, then we will force at least one of each type to spawn
            while (numHealths <= 0 || numMagics <= 0)
            {
                if (numHealths <= 0)
                {
                    randInt1 = rnd.Next(4);
                    randInt2 = rnd.Next(4);
                    if (theDungeon[randInt1, randInt2].IsPowerupNull())
                    {
                        theDungeon[randInt1, randInt2].SetPowerup(new Powerup(Powerup.PotionType.Health));
                        numHealths++;
                    }
                }
                if (numMagics <= 0)
                {
                    randInt1 = rnd.Next(4);
                    randInt2 = rnd.Next(4);
                    if (theDungeon[randInt1, randInt2].IsPowerupNull())
                    {
                        theDungeon[randInt1, randInt2].SetPowerup(new Powerup(Powerup.PotionType.Magika));
                        numMagics++;
                    }
                }
            }



            return theDungeon;
        }

        public static bool IsObjectAnEnemy(Enemy enemyIn)
        {
            if (EnemyGoblin.ReferenceEquals(enemyIn.GetType(), new EnemyGoblin().GetType()) ||
                EnemyOrc.ReferenceEquals(enemyIn.GetType(), new EnemyOrc().GetType()) ||
                EnemyBanshee.ReferenceEquals(enemyIn.GetType(), new EnemyBanshee().GetType()))
            {
                return true;
            }
            else return false;
        }
    }
}
