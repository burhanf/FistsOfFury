using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Devices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FistsOfFury.Classes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FistsOfFury.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StageScreen : Page
    {
        public Match Match { get; private set; }
        public StageScreen()
        {
            this.InitializeComponent();

            PopulateStages();

            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        public void PopulateStages()
        {
            Courtyard courtyard = new Courtyard();
            ThePit thePit = new ThePit();
            DeadPool deadPool = new DeadPool();

            List<Maps> maps = new List<Maps>();
            maps.Add(deadPool);
            maps.Add(courtyard);
            maps.Add(thePit);
            foreach (var map in maps)
            {
                Stages.Items.Add(map);
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Match = e.Parameter as Match;

            Match.ArenaImage = new Image();
        }
        
        private void GoToBattle_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FightingPage), Match);
        }

        private void ReturnToCharacters_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

    }
}