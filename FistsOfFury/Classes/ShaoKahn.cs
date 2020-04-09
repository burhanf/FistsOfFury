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
        public override void PopulateImageSet()
        {
            if (IsPlayerOne)
            {
                //add the player 1 images to the list
                //TODO NEEDED IN EACH CHARACTER
                Image standing = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player1Poses/SKStanding.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(standing);

                Image punch = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player1Poses/SKPunch.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(punch);

                Image highKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player1Poses/SKHighKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(highKick);

                Image lowKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player1Poses/SKLowKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(lowKick);

                Image bonus = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player1Poses/SKBonus.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(bonus);
            }
            else
            {
                //add the player 2 images to the list
                Image standing = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player2Poses/SKStanding.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(standing);

                Image punch = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player2Poses/SKStanding.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(punch);

                Image highKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player2Poses/SKHighKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(highKick);

                Image lowKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player2Poses/SKLowKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(lowKick);

                Image bonus = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player2Poses/SKBonus.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(bonus);
            }
        }
    }
}
