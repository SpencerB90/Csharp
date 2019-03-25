using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Clue
{
    class EndingA
    {
        public EndingA() //no arguments constructor method, automatically done by constructor
        {
        }

        //this is your custom constructor method.
        public EndingA(string hero, string killer, string room, string weapon, string victim) // with this dont need commented out section
        {
            Hero = hero;
            Killer = killer;
            Room = room;
            Weapon = weapon;
            Victim = victim;
        }

        //getting and setting the values used in the output of values to user, for hero, killer, weapons, victim, room
        private string hero; 
        public string Hero
        {
            get { return hero.ToLower(); }
            set { hero = value; }
        }

        private string killer; 
        public string Killer
        {
            get { return killer.ToLower(); }
            set { killer = value; }
        }

        private string room; 
        public string Room
        {
            get { return room.ToLower(); }
            set { room = value; }
        }

        private string weapon; 
        public string Weapon
        {
            get { return weapon.ToLower(); }
            set { weapon = value; }
        }
        private string victim;
        public string Victim
        {
            get { return victim.ToLower(); }
            set { victim = value; }
        }


        public override string ToString() // output to the user of the game ending
        {
            return "Congragulations " + Hero +
                ", the killer " + Killer +
                " was captured in the " + Room + 
                " with a "+ Weapon +
                " after killing " + Victim +
                ", Great detective work!";
        }
    }
}
