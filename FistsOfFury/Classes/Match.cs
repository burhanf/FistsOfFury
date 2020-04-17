using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FistsOfFury.Classes
{
    public class Match
    {
        public List<FightStats> Stats { get; }
        public List<Fighter> Fighters { get; set; }
        public Battle Battle { get; set; }

        public Image ArenaImage { get; set; }

        public Match(Fighter fighterOne, Fighter fighterTwo)
        {
            Stats = new List<FightStats>();

            //burhans stuff for battle
            Fighters = new List<Fighter>{fighterOne, fighterTwo};

            Battle = new Battle(Fighters);
        }
    }
}
