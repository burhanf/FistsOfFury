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
        //might not need fighter list
        public List<Fighter> Fighters { get; set; }

        public Match(Fighter fighter1, Fighter fighter2)
        {
            Stats = new List<FightStats>();

            //burhans stuff for battle
            Fighters = new List<Fighter>();
            Fighters.Add(fighter1);
            Fighters.Add(fighter2);
        }

        //todo call this in fight page?
        public void PerformBattle(Fighter Player1, Fighter Player2)
        {
            //todo get actual fighters from CharacterSelection2, users made a fighter property

            //create a battle
            //todo call this is fight page?
            Battle battle = new Battle(Player1, Player2);

            while (!battle.IsGameOver)
            {
                //determine attacker and opponent, REPEATS
                //todo 1.button must click this
                //return die results to display
                battle.DetermineAttacker();

                //todo player will click a choice, dont need switch? call attack directly?
                //simulate a random choice
                Random randomNumberGenerator = new Random();

                if (Player1.IsBonusUsed || Player2.IsBonusUsed)
                {
                    int choice = randomNumberGenerator.Next(1, 4);
                    //button for this

                    //todo 2.player will click a choice, dont need switch? call attack directly?
                    //can probably remove the whole switch and call the attack directly, must make object of fighter as well though
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
