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
    public class Scorpion : Fighter
    {
        public Scorpion()
        {
            Name = "Scorpion";
            Bio = "Scorpion is the leader of the Shirai-Ryu. His bonus move is an uppercut which gives 800 points and inflicts 10 damage.";
            //set character icon
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/scharacter.PNG", UriKind.RelativeOrAbsolute));
        }

        public override void BonusAttack(Fighter opponent)
        {
            //Uppercut
            IsBonusUsed = true;
            int land = DetermineIfLand();
            Pose = ImageSet[4];

            if (land >= 8)
            {
                //gives health
                Score += 800;

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
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/Player1Poses/SStanding.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(standing);

                Image punch = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/Player1Poses/SPunch.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(punch);

                Image highKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/Player1Poses/SHighKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(highKick);

                Image lowKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/Player1Poses/SLowKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(lowKick);

                Image bonus = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/Player1Poses/SBonus.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(bonus);
            }
            else
            {
                //add the player 2 images to the list
                Image standing = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/Player2Poses/SStanding.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(standing);

                Image punch = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/Player2Poses/SPunch.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(punch);

                Image highKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/Player2Poses/SHighKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(highKick);

                Image lowKick = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/Player2Poses/SLowKick.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(lowKick);

                Image bonus = new Image
                {
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/Scorpion/Player2Poses/SBonus.png", UriKind.RelativeOrAbsolute))
                };
                ImageSet.Add(bonus);
            }
        }
    }
}
