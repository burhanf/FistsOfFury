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
        public List<Fighter> Fighters { get; set; }
        public Battle Battle { get; set; }

        public Match(Fighter fighterOne, Fighter fighterTwo)
        {
            Stats = new List<FightStats>();

            //burhans stuff for battle
            Fighters = new List<Fighter>{fighterOne, fighterTwo};

            Battle = new Battle(Fighters[0], Fighters[1]);
        }
    }
}
