using System;
using System.Collections.Generic;

namespace FistsOfFury.Classes
{
    public class Battle
    {
        //By Burhan
        //properties
        public List<Fighter> Fighters { get; set; }
        public Fighter Attacker { get; set; }
        public Fighter Opponent { get; set; }
        public bool IsGameOver { get; private set; }
        public Fighter Winner { get; set; }

        //ctor
        public Battle(Fighter player1, Fighter player2)
        {
            //initialize types
            Fighters = new List<Fighter> { player1, player2 };
            //Fighters.Add(player1);
            //Fighters.Add(player2);
            //Dice = new Dice();
            SetImages();
        }

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
        //methods
        //determine attacker
        //highest die roll wins
        public List<int> DetermineAttacker()
        {
            //return these to output to screen
            int playerOneRoll = Dice.Roll();
            int playerTwoRoll = Dice.Roll();

            //reset the attacker and opponent
            Attacker = null;
            Opponent = null;

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
            //tie, goes to the previous attacker
            else
            {
                //todo 3.roll again, stack overflow?
                //temp fix: First one that rolled it got it
                //DetermineAttacker();
            }
            List<int> sumList = new List<int>();
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
                        //attacker chooses punch
                        Attacker.Punch(Opponent);
                        break;
                    }
                //highkick
                case 2:
                    {
                        //attacker chooses high kick
                        Attacker.HighKick(Opponent);
                        break;
                    }
                //low kick
                case 3:
                    {
                        //attacker chooses low kick
                        Attacker.LowKick(Opponent);
                        break;
                    }
                //bonus
                case 4:
                    {
                        //attacker chooses bonus move
                        Attacker.BonusAttack(Opponent);
                        break;
                    }
                default:
                    {
                        throw new Exception("Invalid choice");
                    }
            }
            CheckIfGameIsOver();

        }
        public void CheckIfGameIsOver()
        {
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
