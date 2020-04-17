using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace FistsOfFury.Classes
{
    class DeadPool : Maps
    {
        public DeadPool()
        {
            ImageName = "DeadPool";

            MImage = new Image();
            MImage.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Maps/Deadpool.png", UriKind.RelativeOrAbsolute));
        }

    }
}