using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace FistsOfFury.Classes
{
    /// <summary>
    /// Principal Author: Burhan
    /// This derived class is one of the three characters
    /// </summary>
    public class SubZero : Fighter
    {
        public SubZero()
        {
            FighterName = "Sub-Zero";
            Bio = "Sub-Zero is the leader of the Lin Kuei clan. His bonus move is a low punch which gives him 20 health and inflicts 10 damage.";

            //set character icon
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/szcharacter.PNG", UriKind.RelativeOrAbsolute));
        }
        public override void BonusAttack(Fighter opponent)
        {
            //LowPunch
            IsBonusUsed = true;
            int land = DetermineIfLand();
            Pose = ImageSet[4];

            if (land >= 8)
            {
                //gives health
                Health += 20;
                opponent.UpdateHealth(10);
                IsAttackMissed = false;
            }
            else
            {
                IsAttackMissed = true;
            }
        }
        public override void PopulateImageSet()
        {
            if (IsPlayerOne)
            {
                //add the player 1 images to the list
                Image standing = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/Player1Poses/SZStanding.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(standing);

                Image punch = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/Player1Poses/SZPunch.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(punch);

                Image highKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/Player1Poses/SZHighKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(highKick);

                Image lowKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/Player1Poses/SZLowKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(lowKick);

                Image bonus = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/Player1Poses/SZBonus.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(bonus);
            }
            else
            {
                //add the player 2 images to the list
                Image standing = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/Player2Poses/SZStanding.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(standing);

                Image punch = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/Player2Poses/SZPunch.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(punch);

                Image highKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/Player2Poses/SZHighKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(highKick);

                Image lowKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/Player2Poses/SZLowKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(lowKick);

                Image bonus = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/SubZero/Player2Poses/SZBonus.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(bonus);
            }
        }
    }
}
