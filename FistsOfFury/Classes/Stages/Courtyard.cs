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
    class Courtyard : Maps
    {
        public Courtyard()
        {
            ImageName = "CourtYard";

            MapsBio =
                "Shang Tsung's Courtyard, Here, tournaments (including Mortal Kombat tournaments matches) are held where shaolin monks can spectate.";

            MImage = new Image();
            MImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Maps/CourtYard.png", UriKind.RelativeOrAbsolute));
        }


    }
}
