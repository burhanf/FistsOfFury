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
    public class ShaoKahn : Fighter
    {
        public ShaoKahn()
        {
            Name = "Shao Kahn";

            //set character icon
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/skcharacter.PNG", UriKind.RelativeOrAbsolute));
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
