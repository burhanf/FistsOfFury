using System;
using System.Collections.Generic;

namespace FistsOfFury.Classes
{
    public class Battle
    {
        //Principal Author: Burhan
        //This class is responsible for performing a fight and calls the appopriate methods from various classes to do so
        //properties
        public List<Fighter> Fighters { get; }
        public Fighter Attacker { get; private set; }
        public Fighter Opponent { get; private set; }
        public bool IsGameOver { get; private set; }
        public Fighter Winner { get; private set; }

        //constructor
        public Battle(List<Fighter> fighterList)
        {
            //initialize types
            Fighters = new List<Fighter>();
            Fighters = fighterList;
            SetImages();
        }
        //methods
        public void SetImages()
        {
            foreach (var fighter in Fighters)
            {
                //set images
                fighter.PopulateImageSet();

                //set to stand
                fighter.Pose = fighter.ImageSet[0];
            }
        }
        public List<int> DetermineAttacker()
        {
            //highest die roll is attacker
            int playerOneRoll = Dice.Roll();
            int playerTwoRoll = Dice.Roll();
            List<int> sumList = new List<int>();

            if (playerOneRoll > playerTwoRoll)
            {
                //player 1 is attacker
                Attacker = Fighters[0];
                Opponent = Fighters[1];
            }
            else if (playerTwoRoll > playerOneRoll)
            {
                //player 2 is attacker
                Attacker = Fighters[1];
                Opponent = Fighters[0];
            }
            else
            {
                //roll again if there's a tie
                return DetermineAttacker();
            }
            sumList.Add(playerOneRoll);
            sumList.Add(playerTwoRoll);
            return sumList;
        }

        public void ChooseAttack(int choice)
        {
            switch (choice)
            {
                //punch
                case 1:
                    {
                        Attacker.Punch(Opponent);
                        break;
                    }
                //highkick
                case 2:
                    {
                        Attacker.HighKick(Opponent);
                        break;
                    }
                //low kick
                case 3:
                    {
                        Attacker.LowKick(Opponent);
                        break;
                    }
                //bonus
                case 4:
                    {
                        Attacker.BonusAttack(Opponent);
                        break;
                    }
                default:
                    {
                        //in case none of the cases are called, a default case is used 
                        throw new Exception("Invalid choice");
                    }
            }
            CheckIfGameIsOver();
        }
        public void CheckIfGameIsOver()
        {
            //game is over when either player's health is less than or equal to 0
            if (Fighters[0].Health <= 0)
            {
                IsGameOver = true;
                Winner = Fighters[1];
            }
            else if (Fighters[1].Health <= 0)
            {
                IsGameOver = true;
                Winner = Fighters[0];
            }
        }

    }
}
