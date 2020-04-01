using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ConsoleUI
    {
        WordGenerator wordGen = new WordGenerator();
        Assets assets = new Assets();
        int mistakes = 0;
        string blanks = null;
        private bool answer = false;
        string guessed = null;
        private int wins = 0;
        private int losses = 0;
        private int winStreak = 0;
        
        public void Play()
        {
            Console.WriteLine("" +
 "  _   _   \n" +
 " | | | | __ _ _ __   __ _ _ __ ___   __ _ _ __ \n" +
 " | |_| |/ _` | '_ \\ / _` | '_ ` _ \\ / _` | '_ \\ \n" +
 " |  _  | (_| | | | | (_| | | | | | | (_| | | | |\n" +
 " |_| |_|\\__,_|_| |_|\\__, |_| |_| |_|\\__,_|_| |_|\n" +
 "                    |___/                       \n" +
                "--Coded by Un Yon & Michael--  \n" +
                "Press any key to begin.");
            Console.ReadKey();
            Run();
        }
        public void Run()
        {
            guessed = null;
            mistakes = 0;
            string word = wordGen.GetWord();
            int length = word.Length - 1;
            List<char> guessedLetters = new List<char>();

            //Array creation and filling with values.
            string[] ArrayOfOutputs = new string[length];
            for (int i = 0; i < length; i++)
            {
                ArrayOfOutputs[i] = " _ ";
            }

            //Parsing array to printable string.
            blanks = string.Join("", ArrayOfOutputs);

            char[] charList = word.ToCharArray();


            Results();


            do
            {
                char input = Console.ReadKey().KeyChar;



                if (charList.Contains(input))
                {
                    do
                    {
                        int location = Array.IndexOf(charList, input);
                        charList[location] = '*';
                        ArrayOfOutputs[location] = $" {input} ";

                    } while (charList.Contains(input));


                    blanks = string.Join("", ArrayOfOutputs);

                    Results();

                }
                else
                {
                    if (mistakes < 6)
                    {
                        mistakes++;
                        guessedLetters.Add(input);
                        guessed = string.Join(", ", guessedLetters);

                        Results();
                    }
                    else
                    {
                        losses++;
                        winStreak = 0;
                        Console.Clear();
                        Console.WriteLine(assets.hang[6]);
                        Console.WriteLine($"Game Over!\n" +
                            $"Correct word was: {word}\n");
                        GameOver();
                    }

                }









            } while (blanks.Contains(" _ "));

            wins++;
            winStreak++;
            Console.WriteLine("You Win!");
           
            GameOver();




        }

        private void Results()
        {
            Console.Clear();
            Console.WriteLine($"Wins - {wins} || losses - {losses} || Current Streak - {winStreak}");
            Console.WriteLine("Guessed Letters:  " + guessed);
            Console.WriteLine(assets.hang[mistakes]);
            Console.WriteLine();
            Console.WriteLine(blanks);
        }

        private void GameOver()
        {
            
            Console.WriteLine("Play again? [y/n]");
            answer = false;

            do
            {

                switch (Console.ReadKey().KeyChar)
                {
                    case 'y':
                        answer = true;
                        Console.Clear();
                        Run();
                        break;
                    case 'n':
                        answer = true;
                        Console.Clear();
                        Console.WriteLine("Thanks for playing!  Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(" \n" +
                            "Invalid input.  Play again?  [y/n]");
                        break;
                }
            } while (!answer);

        }
    }
}


