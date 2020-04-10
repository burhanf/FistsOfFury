using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FistsOfFury.Classes;
using MessageDialog = Windows.UI.Popups.MessageDialog;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FistsOfFury.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CharacterSelection : Page
    {
        public CharacterSelection()
        {
            this.InitializeComponent();

            //call to populate characters
            PopulateCharacters();

            //save all info
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        //populate character list
        public void PopulateCharacters()
        {
            //instance of fighters
            Scorpion scorpion = new Scorpion();
            SubZero subZero = new SubZero();
            ShaoKahn shaoKahn = new ShaoKahn();

            //create a list of fighters to easily add them to the list view
            List<Fighter> fighters = new List<Fighter>();
            fighters.Add(scorpion);
            fighters.Add(subZero);
            fighters.Add(shaoKahn);

            foreach (var fighter in fighters)
            {
                PlayerOneListView.Items.Add(fighter);
                PlayerTwoListView.Items.Add(fighter);
            }
        }

        private void ConfirmCharacterButton_OnClick(object sender, RoutedEventArgs e)
        {
            //check if name is entered for player1, player2
            if (string.IsNullOrEmpty(PlayerOneNameTextBlock.Text))
            {
                MessageDialog message = new MessageDialog("Player 1 must enter a username");
                message.ShowAsync();
            }
            else if (string.IsNullOrEmpty(PlayerTwoNameTextBlock.Text))
            {
                MessageDialog message = new MessageDialog("Player 2 must enter a username");
                message.ShowAsync();
            }

            //check if a character choice is selected for player1, player2
            else if (PlayerOneListView.SelectedItem == null)
            {
                MessageDialog message = new MessageDialog("Player 1 must choose a character");
                message.ShowAsync();
            }
            else if (PlayerTwoListView.SelectedItem == null)
            {
                MessageDialog message = new MessageDialog("Player 2 must choose a character");
                message.ShowAsync();
            }
            else
            {
                //todo if conditions are met, make objects of USER that contains a fighter instance of each character
                //fighter for player1 must use images that face right
                //fighter for player2 must use images that face left
                CreateFighters();
            }
            
        }

        private void ReturnToMain_OnClick(object sender, RoutedEventArgs e)
        {
            //goes back to home page
            this.Frame.GoBack();
        }

        public void CreateFighters()
        {
            //todo must use username to create PLAYER/USER
            //user will have a fighter for history purposes? OR
            //can send the fighter to user after a battle

            //todo new code, create objects from user selected
            Fighter fighterOne = PlayerOneListView.SelectedItem as Fighter;
            fighterOne.IsPlayerOne = true;

            Fighter fighterTwo = PlayerTwoListView.SelectedItem as Fighter;
            fighterTwo.IsPlayerOne = false;

            //send these to fighting apge where itll make a match in there
            Match match = new Match(fighterOne, fighterTwo);

            //todo send this match to FighterScreen?
            this.Frame.Navigate(typeof(FightingPage), match);

        }
    }
}
