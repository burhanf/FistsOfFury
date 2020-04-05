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
    class Scorpion : Fighter
    {
        public Scorpion()
        {
            Name = "Scorpion";

            //set character icon
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/scharacter.PNG", UriKind.RelativeOrAbsolute));
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
