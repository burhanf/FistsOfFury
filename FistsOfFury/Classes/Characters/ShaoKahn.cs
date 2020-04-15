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
    //Principal Author: Burhan
    public class ShaoKahn : Fighter
    {
        public ShaoKahn()
        {
            Name = "Shao Kahn";
            Bio = "Shao Kahn is the ruler of Outworld. His bonus move is a hammer attack which inflicts 40 damage.";

            //set character icon
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/skcharacter.PNG", UriKind.RelativeOrAbsolute));
        }
        public override void BonusAttack(Fighter opponent)
        {
            //if (!IsBonusUsed)
            {
                //Hammer
                IsBonusUsed = true;
                int land = DetermineIfLand();
                Pose = ImageSet[4];

                if (land >= 8)
                {
                    //lots of damage
                    opponent.UpdateHealth(40);
                    //IsBonusUsed = true;
                    //image change
                }
                else
                {
                    //todo can i do this here?
                    MessageDialog dialog = new MessageDialog("Missed!");
                    dialog.ShowAsync();
                }
            }
            //else
            //{
            //    throw new Exception("Bonus is already used");
            //}
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
                    Source = new BitmapImage(new Uri($"ms-appx:///Assets/Characters/ShaoKahn/Player2Poses/SKPunch.png", UriKind.RelativeOrAbsolute))
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
