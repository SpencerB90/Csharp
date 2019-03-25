using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Hangman
{
    //spencer
    //hangman
    //1-9-18
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "coffee","saki","energy","vodka","bourbon","wine","pizza", "cheese", "pepper", "tequila", "beer" }; //words to guess
            string again = "yes"; // outside loop control value
            int num; // value set for the random number gen to set random word
            Random random = new Random(); // random number generator
            char userGuess = 'u'; // value for user guess
            int x = 6; //contol the game inner loop
            int guessNum = 0; // loop control value for inner loop
            bool[] answers; // value for answer reveal
            int lettersFound = 0; //end condition value for completely correct

            Console.WriteLine("\nLets play a game.. you will have 6 attempts."); //output welcoming user
            Console.ReadLine();

            while (again != "no") // outside loop for another game
            {
                Console.Clear();               
                num = random.Next(0,10); //setting random number to assign to word to guess
                string WORD = words[num]; //value set for mystery word
                char[] letters = words[num].ToCharArray(); //puts my array into a char form to make easier to analyze
                answers = new bool[letters.Length]; // for the revealing letters part
                               
                while ( userGuess != '7' && x > guessNum) // control inner game loop
                {
                    Console.Clear();
                    Console.WriteLine("\n\nit's HANGMAN! a fun word game.\n"); //output on screen telling what program is to user    
                    Console.Write("Guess this word : "); //output showing what ** is to user
                    for (int i = 0; i < letters.Length; i++) //shows word length on screen
                    {
                        if (answers[i] == true)  //reveals true letters             
                            Console.Write(" {0}", letters[i] );                        
                        else                         
                            Console.Write(" .*.");  // keeps letters hidden if not true                    
                    }
                    Console.WriteLine();
                    Console.WriteLine("\nPlease type your letter guess here, or '7' to end."); // output on screen for user input
                    userGuess = Convert.ToChar(ReadLine()); // user input

                    if (userGuess == '7') // for the sentinal value to get out of loop
                    {
                        Console.WriteLine("The answer is {0}.", WORD); // letting user know the word
                        break;
                    }
                    for (int i = 0; i < letters.Length; i++) //runs through word and checks if letter is true, then sets value
                    {
                        if (letters[i] == userGuess)// setting values for correct letters
                        {                            
                            answers[i] = true;
                            lettersFound++; //set end compairison for win
                        } 
                    }
                    if (letters.Contains(userGuess) == true) // if letters are true
                    {
                        Console.WriteLine();
                        Console.WriteLine("Letter {0} is right!", userGuess); //ouput of just a right letter                     
                        if (lettersFound == letters.Length) // if all letters found
                        {
                            Console.WriteLine("CONGRATS! the word is {0}. YOU WIN!!", WORD); //output of winning game
                            break;
                        }
                    }
                    if (letters.Contains(userGuess) == false) // if letters are false
                    {
                        x--;
                        Console.WriteLine();
                        Console.WriteLine("Letter {0}, is not in the word.", userGuess); //output to user of incorrect answer
                        Console.WriteLine("You have {0} lives remaining.", x); //lets user know how many lives left
                        if (x == guessNum) // if user loses game
                        {
                            Console.WriteLine();
                            Console.WriteLine("Sorry the word is {0}, better luck next time.", WORD); //output letting user know word
                        }
                    }
                    Console.WriteLine("Click enter to continue.");
                    Console.ReadLine(); // too keep output on screen for the clear
                } // end while

                Console.WriteLine();
                again = ""; // resets value for outside loop control

                Console.WriteLine("Try again? type 'yes' or 'no'"); // prompt to user for outside loop control
                string temper = Console.ReadLine(); temper = temper.ToLower(); // user input for outside loop control
                if (temper == "yes") // user input to set outside loop control for yes
                {
                    again = "yes"; // outside loop control for correct
                    x = 6; userGuess = 'u'; lettersFound = 0; // reset values to play loop again
                }
                else if (temper == "no") // user input to set outside loop control for no
                    again = "no"; // outside loop control for incorrect
                
            } //end while
            Console.WriteLine(); // to keep output on screen
        }
    }
}
