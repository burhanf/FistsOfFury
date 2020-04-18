using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using FistsOfFury.Classes;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FistsOfFury.Pages
{
    /// <summary>
    /// Principal Author: Burhan
    /// This class is just a main menu that navigates to requested page
    /// </summary>
    public sealed partial class MainPage : Page


    {
        Database Database { get; }


        public MainPage()
        {
            this.InitializeComponent();
            Database = new Database();
            var x = new MessageDialog("");
            foreach (var document in Database.GetLeaderboard())
            {
                x.Title=document.GetValue("Name").ToString();
                x.ShowAsync();
            }
            
        }

        private void PlayButton_OnClick(object sender, RoutedEventArgs e)
        {
            //go to the character selection screen
            this.Frame.Navigate(typeof(CharacterSelection), Database);
        }

        private void LeaderboardButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Leaderboard), Database);
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(History), Database);
        }
    }
}
