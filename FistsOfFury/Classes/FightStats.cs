using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FistsOfFury.Classes
{
    //Principal Author: Burhan
    //This class keeps track and calculates the attacks that are thrown
    public class FightStats
    {
        public double PunchesThrown { get; private set; }
        public double HighKicksThrown { get; private set; }
        public double LowKicksThrown { get; private set; }
        public double PunchesLanded { get; private set; }
        public double HighKicksLanded { get; private set; }
        public double LowKicksLanded { get; private set; }
        //todo is a private variable required to be declared for this property that has a calculated getter?
        //calculation is done in getter
        public double PunchAccuracy{get { PunchesThrown <= 0 ?return PunchesLanded / PunchesThrown:return 0;}}
        public double LowKickAccuracy{get{LowKicksThrown >= 0 ?return LowKicksLanded / LowKicksThrown:return 0;}}
        public double HighKickAccuracy {get{HighKicksThrown >= 0 ?return HighKicksLanded / HighKicksThrown:return 0;}}
        //methods
        public void UpdatePunchThrown()
        {
            PunchesThrown++;
        }
        public void UpdateHighKicksThrown()
        {
            HighKicksThrown++;
        }
        public void UpdateLowKicksThrown()
        {
            LowKicksThrown++;
        }
        public void UpdatePunchLanded()
        {
            PunchesLanded++;
        }
        public void UpdateHighKicksLanded()
        {
            HighKicksLanded++;
        }
        public void UpdateLowKicksLanded()
        {
            LowKicksLanded++;
        }
    }
}
