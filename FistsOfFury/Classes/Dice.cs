using System;

namespace FistsOfFury.Classes
{
    public class Dice
    {
        //Principal Author: Burhan
        //This class contains a static method that just rolls 2 dice and returns the result
        public static int Roll()
        {
            Random randomNumberGenerator = new Random();
            int die1 = randomNumberGenerator.Next(1, 7);
            int die2 = randomNumberGenerator.Next(1, 7);

            return die1 + die2;

        }
    }
}
