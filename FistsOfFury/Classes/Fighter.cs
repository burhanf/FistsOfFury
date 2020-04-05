using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FistsOfFury.Classes
{
    //By Burhan
    abstract class Fighter
    {
        public string Name { get; set; }
        public int Health { get; protected set; }
        public int Points { get; protected set; }

        public bool IsBonusUsed { get; set; }

        //stats
        public FightStats PlayerStats { get; set; }

        //images
        public Image IconImage { get; set; }

        //ctor
        public Fighter()
        {
            Health = 100;
            PlayerStats = new FightStats();
            //Dice = new Dice();
        }

        //methods
        public int DetermineIfLand()
        {
            Random random = new Random();

            int land = random.Next(1, 11);

            return land;
        }

        public void Punch(Fighter opponent)
        {
            PlayerStats.UpdatePunchThrown();
            int land = DetermineIfLand();

            //must be greater than 3 to land (70% chance)
            if (land >= 3)
            {
                opponent.UpdateHealth(8);
                PlayerStats.UpdatePunchLanded();
                Points += 100;
                //image change
            }
        }

        public void LowKick(Fighter opponent)
        {
            PlayerStats.UpdateLowKicksThrown();
            int land = DetermineIfLand();

            //must be greater than 8 to land (50% chance)
            if (land >= 5)
            {
                opponent.UpdateHealth(12);
                PlayerStats.UpdateLowKicksLanded();
                Points += 200;
                //image change
            }
        }

        public void HighKick(Fighter opponent)
        {

            PlayerStats.UpdateHighKicksThrown();
            int land = DetermineIfLand();
            //int land = 8;

            //must be greater than 8 to land (30% chance)
            if (land >= 7)
            {
                //should be opponent.UpdateHealth(16)
                opponent.UpdateHealth(16);
                PlayerStats.UpdateHighKicksLanded();
                Points += 300;
                //image change
            }
        }
        public abstract void BonusAttack(Fighter opponent);

        public void UpdateHealth(int healthToRemove)
        {
            //removes health
            Health -= healthToRemove;
        }
    }
}