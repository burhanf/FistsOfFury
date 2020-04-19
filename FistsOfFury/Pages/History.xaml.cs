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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FistsOfFury.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class History : Page, IDatabase
    {
        public Database Database { get; set;  }
        public History()
        {
            this.InitializeComponent();
            Database = new Database();


        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Database.GetUserHistory(playerName.Text))
            {
                myListView.Items.Add(Database.Deserialize(item));
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);
        //    Database = (Database)e.Parameter;

        //}
    }
}
