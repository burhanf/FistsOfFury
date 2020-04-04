using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FistsOfFury.Classes
{
    //By Burhan
    class SubZero : Fighter
    {
        public SubZero()
        {
            Name = "Sub-Zero";
        }
        public override void BonusAttack(Fighter opponent)
        {
            if (!IsBonusUsed)
            {
                //LowPunch
                int land = DetermineIfLand();

                if (land >= 8)
                {
                    //gives health
                    Health += 20;
                    opponent.UpdateHealth(10);
                    IsBonusUsed = true;
                    //image change
                }
            }
            else
            {
                throw new Exception("Bonus is already used");
            }

        }
    }
}
