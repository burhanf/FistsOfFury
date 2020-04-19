using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FistsOfFury.Classes;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FistsOfFury.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Leaderboard : Page, IDatabase
    {
        public Database Database { get; set; }
        public Leaderboard()
        {
            this.InitializeComponent();
            Database = new Database();

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Database.GetLeaderboard())
            {
                leaderboard.Items.Add(Database.Deserialize(item));
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}

