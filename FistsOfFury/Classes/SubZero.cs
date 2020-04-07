using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace FistsOfFury.Classes
{
    //By Burhan
    public class SubZero : Fighter
    {
        public SubZero()
        {
            Name = "Sub-Zero";

            //set character icon
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/szcharacter.PNG", UriKind.RelativeOrAbsolute));
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
