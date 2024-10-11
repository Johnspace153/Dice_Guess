using ConsoleHelperLibrary;
using DIceGuess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIceGuess
{
    public static class ConsoleMethods
    {
        static DiceModel dice = new DiceModel();
        public static void ChangeBackGroundWhite()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void ChangeWordColorMag()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }

        public static void ChangeWordColorRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void WelcomeMessage()
        {
            @"
  _____       _ _   _   _            _____  _          
 |  __ \     | | | | | | |          |  __ \(_)         
 | |__) |___ | | | | |_| |__   ___  | |  | |_  ___ ___ 
 |  _  // _ \| | | | __| '_ \ / _ \ | |  | | |/ __/ _ \
 | | \ \ (_) | | | | |_| | | |  __/ | |__| | | (_|  __/
 |_|  \_\___/|_|_|  \__|_| |_|\___| |_____/|_|\___\___|

".Center().PrintToConsole();

            @"
____________
|??        ??|
|            |
|??   ??   ??|
|            |
|??________??|
".Center().PrintToConsole();
            Console.WriteLine();

            /* Add Database or File to record top 3 scores*/
            //int highScore = dice.GetHighScore();
            //$"HighScore: {highScore}".PrintToConsole();

            "Let's play a game of Dice".Center().PrintToConsole();

            $"Instructions: ".PrintToConsole();
            $"\t >I will roll the Die each round.".PrintToConsole();
            $"\t >Guess High or Low.".PrintToConsole();
            $"\t >If you get it right, I'll give you 1 point.".PrintToConsole();
            Console.WriteLine();
        }

        public static void AskUserToPlay()
        {
            string answer = "";
            
            do
            {
                answer = "Do you want to play (Yes/No): ".RequestString();
                if (answer.ToLower() == "yes")
                {
                    PlayGame();
                }
                else if (answer.ToLower() == "no")
                {
                    Console.Clear();
                    "See you later".CenterVertAndHor().PrintToConsole();                   
                }

            } while (string.IsNullOrWhiteSpace(answer));

        }

        private static void GuessValue()
        {
            string answer;
            bool isValidGuess = true;
            do
            {
                answer = "Is it Low(1, 2, 3) or High(4, 5, 6): ".RequestString();
                Console.WriteLine();

                if ( dice.Value > 0 && dice.Value < 4 && answer.ToLower() == "low")
                {
                    ChangeWordColorMag();
                    "You are Correct".PrintToConsole();
                    ChangeBackGroundWhite();
                    dice.IncreaseScore();
                    isValidGuess = true;

                }
                else if (dice.Value > 3 && dice.Value < 7 && answer.ToLower() == "high")
                {
                    
                    ChangeWordColorMag();
                    "You are Correct".PrintToConsole();
                    ChangeBackGroundWhite();
                    dice.IncreaseScore();
                    isValidGuess = true;
                }
                else if(dice.Value > 3 && answer.ToLower() == "low")
                {
                    ChangeWordColorRed();
                    "You are wrong".PrintToConsole();
                    ChangeBackGroundWhite();
                    isValidGuess = true;

                }
                else if (dice.Value < 4 && answer.ToLower() == "high")
                {
                    ChangeWordColorRed();
                    "You are wrong".PrintToConsole();
                    ChangeBackGroundWhite();
                    isValidGuess = true;

                }
                else
                {
                    "Please enter in 'High' or 'Low'".PrintToConsole();
                    isValidGuess = false;
                }
            } while (isValidGuess == false);


        }
        public static void PlayGame()
        {
            Console.Clear();
            int numOfRounds = 5;
            bool exitGame = false;
            string exitText;
            int value;
            int exitNum = 0;
            do
            {
                value = dice.GetDieValue();
                GuessValue();
                $"Score: {dice.GetScore()}".PrintToConsole();
                dice.DiceRoll(value).Center().PrintToConsole();

                if (exitNum == numOfRounds)
                {
                    Console.Clear();
                    exitText = "Write 'Exit' if you want to quit: ".RequestString();
                    if (exitText.ToLower() == "exit")
                    {
                        Console.Clear();
                        "Thanks for playing alligator".CenterVertAndHor().PrintToConsole();
                        exitGame = true;
                    }
                    else
                    {
                        numOfRounds += 4;
                    }
                }
                else
                {
                    exitNum++;
                }
                
            } while (exitGame == false);

            
        }
    }
}
