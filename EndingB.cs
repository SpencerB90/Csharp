using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Clue
{
    class EndingB : EndingA // set to use arguments from EndingA
    {


        public EndingB() //no arguments constructor method, automatically done by constructor
        {
        }


        public EndingB(string hero, string killer, string room, string weapon, string victim) : // brings in variables from main program
            base(hero, killer, room, weapon, victim)
        {

        }

        public override string ToString() // output to user of the game ending
        {
            return "The killer " + Killer +
                ", convinced everyone that you " + Hero +
                ", are the person who murdered "+ Victim +
                ", your finger prints were planted on the " + Weapon +
                " now you are stuck in the " + Room +
                ", awaiting a angry mob to seal your fate.";
        }
    }   
}
