﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FistsOfFury.Classes
{
    class Dice
    {
        //By Burhan
        //methods
        public int Roll()
        {
            //use max as a range to roll die
            //generate ONE random die
            Random randomNumberGenerator = new Random();

            int die1 = randomNumberGenerator.Next(1, 7);
            int die2 = randomNumberGenerator.Next(1, 7);

            return die1 + die2;

        }
    }
}
