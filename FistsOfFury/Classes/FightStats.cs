using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FistsOfFury.Classes
{
    /// <summary>
    /// Principal Author: Burhan
    /// Co Author: Marco (Created constructors and FighterName+Score properties for database)
    /// This class keeps track and calculates the attacks that are thrown
    /// </summary>

    public class FightStats
    {
        //Marco:
        public FightStats() { }
        public FightStats(string name)
        {
            Name = name.ToLower();
        }
        public FightStats(string name, int score, int punchesThrown, int highKicksThrown, int lowKicksThrown, int punchesLanded, int highKicksLanded, int lowKicksLanded) : this(name)
        {
            Name = name.ToLower();
            Score = score;
            PunchesThrown = punchesThrown;
            HighKicksThrown = highKicksThrown;
            LowKicksThrown = lowKicksThrown;
            PunchesLanded = punchesLanded;
            HighKicksLanded = highKicksLanded;
            LowKicksLanded = lowKicksLanded;
        }

        public String Name { get; private set; }
        public int Score { get; private set; }
        //Burhan:
        public int PunchesThrown { get; private set; }
        public int HighKicksThrown { get; private set; }
        public int LowKicksThrown { get; private set; }
        public int PunchesLanded { get; private set; }
        public int HighKicksLanded { get; private set; }
        public int LowKicksLanded { get; private set; }
        public double PunchAccuracy { get; private set; }
        public double LowKickAccuracy { get; private set; }
        public double HighKickAccuracy { get; private set; }

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
        //calculating accuracies are methods so that the value of the property can be obtained, rather than recalculating every time
        public void CalculatePunchAccuracy()
        {
            if (PunchesThrown != 0)
            {
                PunchAccuracy = (PunchesLanded / PunchesThrown * 100);
            }
            else
            {
                PunchAccuracy = 0;
            }
        }
        public void CalculateLowKickAccuracy()
        {
            if (LowKicksThrown != 0)
            {
                LowKickAccuracy = (LowKicksLanded / LowKicksThrown * 100);
            }
            else
            {
                LowKickAccuracy = 0;
            }
        }
        public void CalculateHighKickAccuracy()
        {
            if (HighKicksThrown != 0)
            {
                HighKickAccuracy = (HighKicksLanded / HighKicksThrown * 100);
            }
            else
            {
                HighKickAccuracy = 0;
            }
        }
    }
}
