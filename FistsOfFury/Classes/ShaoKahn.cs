using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FistsOfFury.Classes
{
    //By Burhan
    class ShaoKahn : Fighter
    {
        public ShaoKahn()
        {
            Name = "Shao Kahn";
        }
        public override void BonusAttack(Fighter opponent)
        {
            if (!IsBonusUsed)
            {
                //Hammer
                int land = DetermineIfLand();

                if (land >= 8)
                {
                    //bare damage
                    opponent.UpdateHealth(40);
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
