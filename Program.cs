using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Clue
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false; // game again outter loop control

            while ( end == false) // outter loop
            {
                KillersCase(out string TheKiller, out string TheVictim); // setting the victim and killer values for game // see method 5
                WeaponsCase(out string TheWeapon); // setting the weapon value for game // see method 6
                RoomsCase(out string TheRoom); //setting the room for game // see method 7
                List<string> Friendlies = new List<string>(); //open list to add user wrong guesses for killer
                List<string> NotWeapon = new List<string>(); //open list to add user wrong guesses for weapons
                List<string> NotRoom = new List<string>(); //open list to add user wrong guesses for room
                List<string> StillAlive = new List<string>(); //open list to add user wrong guesses for victim
                var ending = new List<EndingA>(); // setting class value list // see either EndingA or EndingB
                bool gKillerBool = false; //sets if statement bool for question on killer showing, till user guesses it
                bool gRoomBool = false; //sets if statement bool for question on room showing, till user guesses it
                bool gWeaponBool = false; //sets if statement bool for question on weapons showing, till user guesses it
                bool gVictimBool = false; //sets if statement bool for question on victim showing, till user guesses it
                int guesscounts = 4; // user guess count control value for loop
                int counter = 0; // also loop control value
                bool Win= false; // bool value for complete win where user answers all questions correct

                Clear();
                Loading(); // see method 1
                Console.ReadKey();

                Clear();
                Console.WriteLine("\n\n\n\n");
                Console.Write("{0,50}", "Please Enter your name: "); // output to user asking for name
                string gamer = Console.ReadLine(); // name or gamer setting value

                House(); // see method 2
                ReadKey();
                Clear();

                intro(gamer); // see method 4
                ReadKey();

                while (guesscounts > counter && Win == false) // inner loop set part of control
                {
                    Clear();
                    counter++;
                    Layout(); // see method 3

                    string[] Suspects = { "Miss Scarlet", "Colonel Mustard", "Mrs. White", "Reverend Green", "Mrs. Peacock", "Professor Plum" };// output of suspects to user
                    Console.WriteLine("\n Suspects: ");
                    foreach (string s in Suspects)
                    {
                        Console.Write("\t " + s);
                    }
                    Console.WriteLine();

                    string[] Weapons = { "Candlestick", "Knife", "Lead Pipe", "Revolver", "Rope", "Wrench" };// output of weapons to user
                    Console.WriteLine(" Weapons: ");
                    foreach (string w in Weapons)
                    {
                        Console.Write("\t " + w);
                    }
                    Console.WriteLine();

                    string[] Rooms = { "Ballroom", "Billiard Room", "Dining Room", "Main Hall", "Library", "Study" }; // output of rooms to user
                    Console.WriteLine(" Rooms: ");
                    foreach (string r in Rooms)
                    {
                        Console.Write("\t " + r);
                    }
                    Console.WriteLine();

                    if (counter > 1) // lets user see what they have guessed each time for each question
                    { 
                    Console.WriteLine();
                    Console.Write("Proven Innocent: ");
                    foreach (string f in Friendlies)
                    {
                        Console.Write("{0}, ", f);
                    }

                    Console.Write("Not the Weapon: ");
                    foreach (string nw in NotWeapon)
                    {
                        Console.Write("{0}, ", nw);
                    }

                    Console.Write("Not the Rooms: ");
                    foreach (string r in NotRoom)
                    {
                        Console.Write("{0}, ", r);
                    }

                    Console.Write("Not the Victim: ");
                    foreach (string v in StillAlive)
                    {
                        Console.Write("{0}, ", v);
                    }
                }

                    if (gKillerBool == false) // sets question to skip when guessed correct
                    {
                        Console.Write("\n\nPlease type your #{0} guess for the killer: ", counter);
                        string guesskiller = Console.ReadLine();
                        guesskiller = guesskiller.ToLower();//fail safe for caps

                        if (guesskiller == TheKiller)// setting if user got guess correct
                        {
                            Console.WriteLine("You guessed it, the killer is {0}", TheKiller);
                            gKillerBool = true; // setting show question value if right
                        }
                        else
                        {
                            Console.WriteLine("Try again!");
                            Friendlies.Add(guesskiller); //adding killer guess to friendlies list for user output
                        }
                    }
                    if (gWeaponBool == false) // sets question to skip when guessed correct
                    {
                        Console.Write("\nPlease type your #{0} guess for the murder weapon: ", counter);
                        string guessweapon = Console.ReadLine();
                        guessweapon = guessweapon.ToLower();//fail safe for caps

                        if (guessweapon == TheWeapon)// setting if user got guess correct
                        {
                            Console.WriteLine("You guessed it, the Weapon is {0}", TheWeapon);
                            gWeaponBool = true;// setting show question value if right
                        }
                        else
                        {
                            Console.WriteLine("Are you even trying, your life's in danger!");
                            NotWeapon.Add(guessweapon);//adding weapon guess to notweapon list for user output
                        }
                    }
                    if (gRoomBool == false) // sets question to skip when guessed correct
                    {
                        Console.Write("\nPlease type your #{0} guess for the room: ", counter);
                        string guessroom = Console.ReadLine();
                        guessroom = guessroom.ToLower();//fail safe for caps

                        if (guessroom == TheRoom)// setting if user got guess correct
                        {
                            Console.WriteLine("You guessed it, the room is {0}", TheRoom);
                            gRoomBool = true;// setting show question value if right
                        }
                        else
                        {
                            Console.WriteLine("You can do it! think harder");
                            NotRoom.Add(guessroom);//adding room guess to notroom list for user output
                        }
                    }
                    if (gVictimBool == false) // sets question to skip when guessed correct
                    {
                        Console.Write("\nPlease type your #{0} guess for the Victim: ", counter);
                        string guessvictim = Console.ReadLine();
                        guessvictim = guessvictim.ToLower();//fail safe for caps

                        if (guessvictim == TheVictim)// setting if user got guess correct
                        {
                            Console.WriteLine("You guessed it, the victim is {0}", TheVictim);
                            gVictimBool = true;// setting show question value if right
                        }
                        else
                        {
                            Console.WriteLine("You call that a guess..");
                            StillAlive.Add(guessvictim);//adding victim guess to alive list for user output
                        }
                    }

                    if (gRoomBool == true && gKillerBool == true && gWeaponBool == true && gVictimBool == true) // sets loop value complete winning game
                    {
                        Win = true;
                        break;
                    }

                    ReadKey();

                }
                Console.WriteLine();

                if (Win == true) // object class EndingA // see EndingA class cs.
                {
                    var f1 = new EndingA(gamer, TheKiller, TheRoom, TheWeapon, TheVictim);
                    ending.Add(f1);
                    foreach (var item in ending)
                    {
                        Console.WriteLine(item);
                        Console.WriteLine();
                    }
                }
                else // object class endingB // see EndingB class cs.
                {
                    var f2 = new EndingB(gamer, TheKiller, TheRoom, TheWeapon, TheVictim);
                    ending.Add(f2);
                    foreach (var item in ending)
                    {
                        Console.WriteLine(item);
                        Console.WriteLine();
                    }
                }
                
                endingCredits(); // see method 8

                Console.WriteLine("______________________________________________");
                Console.WriteLine("\n...Again? 'Y' or 'N'"); // play again prompt to user
                string again = Console.ReadLine();
                again = again.ToUpper();
                if (again == "Y") //sets play again bool value off user perference
                {
                    end = false;
                }
                else
                {
                    
                    break;
                }
            }
            Console.ReadLine();
        }
        
        public static void Loading() // method 1 // loading screen
        {
            string[] Loading = { "LOADING FLOORS….", "TRIMMING HEDGES…..", "HIDING WEAPONS….", "ADDING DRAMATIC WEATHER….", "POISONING WINE….", "HANDING OUT NAME TAGS….." };
            int count = 0;
                     
            while (count <= 5) // outputs loading array to user
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("{0,66}",Loading[count]);
                count++;
                ReadKey();
                Clear();
            }
            Console.WriteLine("\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("{0,66}","Enjoy the game before this killer gets you..");

        }

        public static void House() // method 2 // displays graphic of house
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("{0,70}", "        ____         ____________        ____");
            Console.WriteLine("{0,70}", "        ====         ============        ====");
            Console.WriteLine("{0,73}", "   )V V V V V    V V V V ^  V V V V   V V V V(");
            Console.WriteLine("{0,74}", "  )V V _ V V V V V V V V __ V V V V V V V _ V V(");
            Console.WriteLine("{0,75}", " )V V{ # } V V V V V V  {##} V V V V V { # } V V(");
            Console.WriteLine("{0,76}", ")V V V ~ V V V V V V V |  ~ | V V V V V V ~ V V V(");
            Console.WriteLine("{0,76}", "_______________________|____|_____________________");
            Console.WriteLine("{0,76}", "~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
            Console.WriteLine("{0,76}", ": : : # # # # : : :  # # # # # #: : # # # # : : : :");
            Console.WriteLine("{0,76}", ": : : # # # # : : :  # # # # # #: : # # # # : : : :");
            Console.WriteLine("{0,76}", ": : : # # # # : : :  # # # # # #: : # # # # : : : :");
            Console.WriteLine("{0,76}", ": : : : : : : : : : : : : : : : : : : : : : : : : :");
            Console.WriteLine("{0,75}", ":    _________         ~~~~~~	    _________      :");
            Console.WriteLine("{0,75}", ":    6 suspects        |    |	   “Enter..        :");
            Console.WriteLine("{0,75}", ":    6 weapons         |    |	    If..           :");
            Console.WriteLine("{0,76}", ":    6 rooms            CLUE       You Dare..”    :");
            Console.WriteLine("{0,76}", ":    4 guesses         |    |                     :");
            Console.WriteLine("{0,76}", ")(__|___|/____|/____|/_|____|_|/_____|/____|/____)(");
        }
        public static void Layout() // method 3 // displays graphic of room layout
        {
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("|           |  |            |  |             |");
            Console.WriteLine("|           |  |            |  |             |");
            Console.WriteLine("|Locked Door|  |  Ballroom  |  |Billiard Room|");
            Console.WriteLine("|           |  |            |  |             |");
            Console.WriteLine("|___________|__|____________|__|_____________|");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("|           |  |            |  |             |");
            Console.WriteLine("|           |  |                             |");
            Console.WriteLine("|Dining Room|  |  Main Hall       Entrance    ");
            Console.WriteLine("|           |  |                             |");
            Console.WriteLine("|___________|__|____________|__|_____________|");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("|           |  |            |  |             |");
            Console.WriteLine("|           |  |            |  |             |");
            Console.WriteLine("|  Library  |  |   Study    |  | Locked Door |");
            Console.WriteLine("|           |  |            |  |             |");
            Console.WriteLine("|___________|__|____________|__|_____________|");
        }
        public static void intro(string gamer) // method 4 // sets random storyline for user
        {
            string[] Suspects = { "Miss Scarlet", "Colonel Mustard", "Mrs. White", "Reverend Green", "Mrs. Peacock", "Professor Plum" };
            Random random = new Random(); //random values set to number by when they will appear in into story.
            int num = random.Next(0, 6);
            string one = Suspects[num];

            int num2 = random.Next(0, 6);
            string two = Suspects[num2];

            int num3 = random.Next(0, 6);
            string three = Suspects[num3];

            int num4 = random.Next(0, 6);
            string four = Suspects[num4];

            int num5 = random.Next(0, 6);
            string five = Suspects[num5];

            int num6 = random.Next(0, 6);
            string six = Suspects[num6];

            int num7 = random.Next(0, 6);
            string seven = Suspects[num7];

            int num8 = random.Next(0, 6);
            string eight = Suspects[num8];

            int num9 = random.Next(0, 6);
            string nine = Suspects[num9];

            int num10 = random.Next(0, 6);
            string ten = Suspects[num10];

            int num11 = random.Next(0, 6);
            string eleven = Suspects[num11];

            int num12 = random.Next(0, 6);
            string twelve = Suspects[num12];



            Console.WriteLine("\n\n\n\nHello {0},", gamer);
            Console.WriteLine(" We have been expecting you, looks the the storm of the century is brewing out here.");
            Console.WriteLine(" better come in quick before it starts, tonights festivities are about to start.");
            Console.WriteLine(" Greeted by {0} You learn what is on tonights adgenda.", one);
            Console.WriteLine(" {0} Leans in and gives you a handshake, 'Looks like a lively party tonight, my good friend.'", two);
            Console.WriteLine(" Later you see {0} and {1} agruing over something, ", three, four);
            Console.WriteLine(" but didnt bother since one of them stormed off angerily as quickly as the arguement started");
            Console.WriteLine(" {0} glares as the maid who bends over with the tray of drinks.", five);
            Console.WriteLine(" {0} mutters under their breath, 'despicable.'", six);
            Console.WriteLine(" The dinner bell rings Everyone sits down to eat,");
            Console.WriteLine(" {0} is over joyed with the food and wont stop talking.", seven);
            Console.WriteLine(" {0} regails the group with stories of hunting small game in africa", eight);
            Console.WriteLine(" Durring the seven courses you notice {0} and {1} eyeing eachother up, ", nine, ten);
            Console.WriteLine(" then excuse themselves and leave the room one at a time, The small group of strangers ramble into the hallway,");
            Console.WriteLine(" with each meandering into one of the six different rooms on the first floor");
            Console.WriteLine(" Suddenly the power goes out you hear a scream and a loud noise.");
            Console.WriteLine(" {0} peers into the room meek and throws themseleves at your feet crying and mumbling gibberish", eleven);
            Console.WriteLine(" {0} slaps them and say. 'get your act together.' ", twelve);
            Console.WriteLine(" You look at them and go 'shhhh, im thinking, then suggest we bring everyone together.'");
            Console.WriteLine(" when eveyone from the party is found you notice one is missing.");
            Console.WriteLine(" To save your own life you must figure out who's the victim, the killer, the weapon, and where the murder happened.");
            Console.WriteLine("\nSuspects:");
            Console.WriteLine(" Miss Vivienne Scarlet, the sultry and beautiful actress of the game.");
            Console.WriteLine(" Colonel Michael Mustard, the militant and athletic colonel of the game.");
            Console.WriteLine(" Mrs.Blanche White, the intrusive and kindly maid of the game.");
            Console.WriteLine(" Reverend Jonathan Green, the conniving and religious priest of the game.");
            Console.WriteLine(" Mrs.Elizabeth Peacock, the sinister and political senator of the game.");
            Console.WriteLine(" Professor Peter Plum, the uptight and intelligent professor of the game.");
            
        }
        public static void KillersCase(out string TheKiller, out string TheVictim) // method 5 // sets random the killer and the random victim
        {
            Random random = new Random();
            int num = random.Next(0, 6); 

            string[] Suspects = { "Miss Scarlet", "Colonel Mustard", "Mrs. White", "Reverend Green", "Mrs. Peacock", "Professor Plum" };
            TheKiller = Suspects[num];
            TheKiller = TheKiller.ToLower();
                      
            int num2 = random.Next(0, 6);

            while (num == num2) // makes sure the killer and the victim are not the same person
            {
                Random random2 = new Random();
                num2 = random2.Next(0, 6);
            }

            TheVictim = Suspects[num2];
            TheVictim = TheVictim.ToLower();

        }
        public static void WeaponsCase(out string TheWeapon) // method 6 // sets random the weapon value
        {
            Random random = new Random();
            int num = random.Next(0, 6); 
            

            string[] Weapons = { "Candlestick", "Knife", "Lead Pipe", "Revolver", "Rope", "Wrench" };
            TheWeapon = Weapons[num];
            TheWeapon = TheWeapon.ToLower();

        }
        public static void RoomsCase(out string TheRoom) // method 7 // sets random the room value
        {
            Random random = new Random();
            int num = random.Next(0, 6);

            string[] Rooms = { "Ballroom", "Billiard Room", "Dining Room", "Main Hall", "Library", "Study" };
        
            
            TheRoom = Rooms[num];
            TheRoom = TheRoom.ToLower();
        }
       public static void endingCredits() // method 8 // ending credits 
        {
            string[,] credit = { { "ROT BRAIN","ENTERTAINMENT,"," INC"}, 
                                 {"...sleep","when you're","un-dead" } }; 

            Console.WriteLine();

            for (int i = 0; i < 2; i++) //outter loop based off rows
            {
                for (int j = 0; j < 3; j++) //inner loop based off columns
                {
                    Write(credit[i, j] + "\t");
                    if ((j + 1) % 3 == 0)
                    {
                        Console.WriteLine("");
                    }

                }
            }

        }
    }
        
}
