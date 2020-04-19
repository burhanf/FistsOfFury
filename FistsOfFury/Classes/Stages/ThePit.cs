using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace FistsOfFury.Classes
{
    class ThePit : Maps
    {
        public ThePit()
        {
            ImageName = "ThePit";

            MapsBio =
                "The Pit lies on Shang Tsung's Island. Kombatants fight on a bridge suspended over a sea of steel spikes, which is the source of death for anyone unlucky enough " +
                "to be knocked off.";

            MImage = new Image();
            MImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Maps/ThePit.png", UriKind.RelativeOrAbsolute));
        }

    }
}