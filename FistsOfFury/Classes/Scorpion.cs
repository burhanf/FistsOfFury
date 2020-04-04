using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FistsOfFury.Classes
{
    //By Burhan
    class Scorpion : Fighter
    {
        public Scorpion()
        {
            Name = "Scorpion";
        }

        public override void BonusAttack(Fighter opponent)
        {
            if (!IsBonusUsed)
            {
                //Uppercut
                int land = DetermineIfLand();

                if (land >= 8)
                {
                    //gives health
                    Points += 800;

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
