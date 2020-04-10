using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace FistsOfFury.Classes
{
    //By Burhan
    public abstract class Fighter
    {
        public string Name { get; set; }
        public int Health { get; protected set; }
        public int Score { get; protected set; }

        //public bool IsBonusUsed { get; set; }

        //stats
        public FightStats PlayerStats { get; set; }

        //images
        public Image IconImage { get; set; }
        public bool IsPlayerOne { get; set; }
        public Image Pose { get; set; }
        public List<Image> ImageSet { get; set; }
        //public bool IsAttackingPlayer { get; set; }
        public  bool IsBonusUsed { get; set; }

        //ctor
        public Fighter()
        {
            Health = 100;
            PlayerStats = new FightStats();
            //Dice = new Dice();

            Pose = new Image();
            ImageSet = new List<Image>();
            //ImageSet = _imageset;
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
                //image change
            }
            else
            {
                //todo can i do this here?
                MessageDialog dialog = new MessageDialog("Missed!");
                dialog.ShowAsync();
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
                //image change
            }
            else
            {
                //todo can i do this here?
                MessageDialog dialog = new MessageDialog("Missed!");
                dialog.ShowAsync();
            }
        }

        public void HighKick(Fighter opponent)
        {

            PlayerStats.UpdateHighKicksThrown();
            int land = DetermineIfLand();
            //int land = 8;
            Pose = ImageSet[2];

            //must be greater than 8 to land (30% chance)
            if (land >= 7)
            {
                //should be opponent.UpdateHealth(16)
                opponent.UpdateHealth(16);
                PlayerStats.UpdateHighKicksLanded();
                Score += 300;
                //image change
            }
            else
            {
                //todo can i do this here?
                MessageDialog dialog = new MessageDialog("Missed!");
                dialog.ShowAsync();
            }
        }
        public abstract void BonusAttack(Fighter opponent);
        public abstract void PopulateImageSet();
        public void UpdateHealth(int healthToRemove)
        {
            //removes health
            Health -= healthToRemove;
        }
        //choose attack
        public void ChooseAttack()
        {
            //Battle.ChooseAttack();
        }

        //set default pose 
        public Image DefaultPose()
        {
            return ImageSet[0];
        }
    }
}