using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FistsOfFury.Classes
{
    class Battle
    {
        //By Burhan
        //properties
        public List<Fighter> Fighters { get; set; }
        public Fighter Attacker { get; set; }
        public Fighter Opponent { get; set; }
        public bool IsGameOver { get; private set; }
        public Fighter Winner { get; set; }

        //todo die exists in here because its only needed for the battle
        //public Dice Dice { get; set; }

        //ctor
        public Battle(Fighter player1, Fighter player2)
        {
            //initialize types
            Fighters = new List<Fighter>();
            Fighters.Add(player1);
            Fighters.Add(player2);
            //Dice = new Dice();
        }

        //methods
        //determine attacker
        //highest die roll wins
        public void DetermineAttacker()
        { 
            //return these to output to screen
            int playerOneRoll = Dice.Roll();
            int playerTwoRoll = Dice.Roll();

            if (playerOneRoll >= playerTwoRoll)
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
            //tie
            else
            {
                //todo 3.roll again, stack overflow?
                //temp fix: First one that rolled it got it
                DetermineAttacker();
            }
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
                //lowkick
                case 2:
                    {
                        //attacker chooses low kick
                        Attacker.LowKick(Opponent);
                        break;
                    }
                //high kick
                case 3:
                    {
                        //attacker chooses high kick
                        Attacker.HighKick(Opponent);
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
                //check if health is depleted/game is over
            }

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
