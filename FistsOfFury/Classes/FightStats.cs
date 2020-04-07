using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FistsOfFury.Classes
{
    //By Burhan
    public class FightStats
    {
        public double PunchesThrown { get; private set; }
        public double HighKicksThrown { get; private set; }
        public double LowKicksThrown { get; private set; }
        public double PunchesLanded { get; private set; }
        public double HighKicksLanded { get; private set; }
        public double LowKicksLanded { get; private set; }
        public double PunchAccuracy
        {
            get
            {
                if (PunchesThrown != 0)
                {
                    return PunchesLanded / PunchesThrown * 100;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double LowKickAccuracy
        {
            get
            {
                if (LowKicksThrown != 0)
                {
                    return LowKicksLanded / LowKicksThrown * 100;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double HighKickAccuracy
        {
            get
            {
                if (HighKicksThrown != 0)
                {
                    return HighKicksLanded / HighKicksThrown * 100;
                }
                else
                {
                    return 0;
                }
            }
        }
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
