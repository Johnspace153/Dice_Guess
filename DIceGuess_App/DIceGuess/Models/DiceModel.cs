using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DIceGuess.Models
{
    public class DiceModel
    {
        public int Value { get; set; } 
        private int CurrentScore { get; set; }

        /*Want to add HighScore */
        private static int HighScore { get; set; }


        public DiceModel()
        {
            CurrentScore = 0;  
        }

        public void IncreaseScore()
        {
            CurrentScore++;
            HighScore = CurrentScore;
        }
        //Return HighScore
        public int GetHighScore() 
        {
            return HighScore;
        }
        public int GetScore()
        {
            return CurrentScore;
        }

        public int GetDieValue()
        {
            int output = RndIntGenerator();
            Value = output;
            return output;
        }

        private int RndIntGenerator()
        {
            Random rnd = new Random();
            int output = rnd.Next(1, 7);

            return output;
        }

        public string DiceRoll(int value)
        {
            string output = @"
____________
|??        ??|
|            |
|??   ??   ??|
|            |
|??________??|
                            ";

            if (value == 1)
            {
                output = @"
____________
|            |
|            |
|     oo     |
|            |
|____________|
                          ";
            }
            else if (value == 2)
            {
                output = @"
____________
|oo          |
|            |
|            |
|            |
|__________oo|
                          ";
            }
            else if (value == 3)
            {
                output = @"
____________
|oo          |
|            |
|     oo     |
|            |
|__________oo|
                          ";
            }
            else if (value == 4)
            {
                output = @"
____________
|oo        oo|
|            |
|            |
|            |
|oo________oo|
                          ";
            }
            else if (value == 5)
            {
                output = @"
____________
|oo        oo|
|            |
|     oo     |
|            |
|oo________oo|
                          ";
            }
            else if (value == 6)
            {
                output = @"
____________
|oo        oo|
|            |
|oo        oo|
|            |
|oo________oo|
                          ";
            }


            return output;
        }

       


    }
}
