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

            MImage = new Image();
            MImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Maps/ThePit.png", UriKind.RelativeOrAbsolute));
        }

    }
}