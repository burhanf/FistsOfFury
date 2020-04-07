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
        }
    }
}
