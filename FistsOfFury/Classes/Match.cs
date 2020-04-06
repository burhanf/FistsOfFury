using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FistsOfFury.Classes
{
    public class Match
    {
        public List<FightStats> Stats { get; }

        public Match()
        {
            Stats = new List<FightStats>();

            //burhans stuff for battle
            //todo get actual fighters from CharacterSelection2 users made a fighter property
            Fighter Player1 = new Scorpion();
            Fighter Player2 = new SubZero();

            //create a battle
            Battle battle = new Battle(Player1, Player2);

            while (!battle.IsGameOver)
            {
                //determine attacker and opponent, REPEATS
                battle.DetermineAttacker();

                //todo player will click a choice
                //simulate a random choice
                Random randomNumberGenerator = new Random();

                if (Player1.IsBonusUsed || Player2.IsBonusUsed)
                {
                    int choice = randomNumberGenerator.Next(1, 4);
                    battle.ChooseAttack(choice);
                }
                else
                {
                    int choice = randomNumberGenerator.Next(1, 5);
                    battle.ChooseAttack(choice);
                }
                //see if game is over
                battle.CheckIfGameIsOver();
            }

        }
    }
}
