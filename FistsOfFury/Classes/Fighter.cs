using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace FistsOfFury.Classes
{
    /// <summary>
    /// Principal Author: Burhan
    /// This abstract class is a base class for all fighters and contains logic for each attack
    /// </summary>
    public abstract class Fighter
    {
        public string Name { get; protected set; }
        public string Bio { get; protected set; }
        public int Health { get; protected set; }
        public int Score { get; protected set; }

        //stats
        public FightStats PlayerStats { get; }

        //images
        public Image IconImage { get; set; }
        public bool IsPlayerOne { get; set; }
        public Image Pose { get; set; }
        public List<Image> ImageSet { get; set; }
        public bool IsBonusUsed { get; protected set; }
        public bool IsAttackMissed { get; protected set; }

        //constructor
        public Fighter()
        {
            Health = 100;
            PlayerStats = new FightStats(Name);

            Pose = new Image();
            ImageSet = new List<Image>();
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
            Pose = ImageSet[1];

            //must be greater than 3 to land (70% chance)
            if (land >= 3)
            {
                opponent.UpdateHealth(8);
                PlayerStats.UpdatePunchLanded();
                Score += 100;
                IsAttackMissed = false;
            }
            else
            {
                IsAttackMissed = true;
            }
        }
        public void HighKick(Fighter opponent)
        {

            PlayerStats.UpdateHighKicksThrown();
            int land = DetermineIfLand();
            Pose = ImageSet[2];

            //must be greater than 8 to land (30% chance)
            if (land >= 7)
            {
                opponent.UpdateHealth(16);
                PlayerStats.UpdateHighKicksLanded();
                Score += 300;
                IsAttackMissed = false;
            }
            else
            {
                IsAttackMissed = true;
            }
        }
        public void LowKick(Fighter opponent)
        {
            PlayerStats.UpdateLowKicksThrown();
            int land = DetermineIfLand();
            Pose = ImageSet[3];

            //must be greater than 8 to land (50% chance)
            if (land >= 5)
            {
                opponent.UpdateHealth(12);
                PlayerStats.UpdateLowKicksLanded();
                Score += 200;
                IsAttackMissed = false;
            }
            else
            {
                IsAttackMissed = true;
            }
        }
        public void UpdateHealth(int healthToRemove)
        {
            //removes health
            Health -= healthToRemove;
        }

        //set default pose 
        public Image DefaultPose()
        {
            return ImageSet[0];
        }
        public abstract void BonusAttack(Fighter opponent);
        public abstract void PopulateImageSet();
    }
}