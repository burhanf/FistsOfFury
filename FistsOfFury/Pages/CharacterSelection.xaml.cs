﻿using System;
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
        /// <summary>
        /// Principal Author: Burhan
        /// This class is responsible for displaying the characters and allowing users to choose them
        /// </summary>
        public CharacterSelection()
        {
            this.InitializeComponent();

            //call to populate characters
            PopulateCharacters();

            //save all info
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }
        private void PopulateCharacters()
        {
            //Fighters that have images for when they are on the left/player1
            Scorpion scorpionPlayerOne = new Scorpion { IsPlayerOne = true };
            SubZero subZeroPlayerOne = new SubZero { IsPlayerOne = true };
            ShaoKahn shaoKahnPlayerOne = new ShaoKahn { IsPlayerOne = true };

            //Fighters that have images for when they are on the right/player2
            Scorpion scorpionPlayerTwo = new Scorpion { IsPlayerOne = false };
            SubZero subZeroPlayerTwo = new SubZero { IsPlayerOne = false };
            ShaoKahn shaoKahnPlayerTwo = new ShaoKahn { IsPlayerOne = false };

            //create a list of fighters to easily add them to the list view
            List<Fighter> playerOneFighters = new List<Fighter> { scorpionPlayerOne, subZeroPlayerOne, shaoKahnPlayerOne };
            List<Fighter> playerTwoFighters = new List<Fighter> { scorpionPlayerTwo, subZeroPlayerTwo, shaoKahnPlayerTwo };
            foreach (var fighter in playerOneFighters)
            {
                PlayerOneListView.Items.Add(fighter);
            }
            foreach (var fighter in playerTwoFighters)
            {
                PlayerTwoListView.Items.Add(fighter);
            }
        }

        private async void ConfirmCharacterButton_OnClick(object sender, RoutedEventArgs e)
        {
            //check if name is the same for both players. Should be unique names (case sensitive)
            if (PlayerOneNameTextBlock.Text == PlayerTwoNameTextBlock.Text ||
                PlayerTwoNameTextBlock.Text == PlayerOneNameTextBlock.Text)
            {
                MessageDialog message = new MessageDialog("Both players cannot have the same username. Please enter different usernames. (Case sensitive)");
                await message.ShowAsync();
            }
            else if (string.IsNullOrEmpty(PlayerOneNameTextBlock.Text))
            {
                MessageDialog message = new MessageDialog("Player 1 must enter a username");
                await message.ShowAsync();
            }
            else if (string.IsNullOrEmpty(PlayerTwoNameTextBlock.Text))
            {
                MessageDialog message = new MessageDialog("Player 2 must enter a username");
                await message.ShowAsync();
            }

            //check if a character choice is selected for player1, player2
            else if (PlayerOneListView.SelectedItem == null)
            {
                MessageDialog message = new MessageDialog("Player 1 must choose a character");
                await message.ShowAsync();
            }
            else if (PlayerTwoListView.SelectedItem == null)
            {
                MessageDialog message = new MessageDialog("Player 2 must choose a character");
                await message.ShowAsync();
            }
            else
            {
                CreateFighters();
            }
        }

        private void ReturnToMain_OnClick(object sender, RoutedEventArgs e)
        {
            //goes back to home page
            this.Frame.GoBack();
        }

        private void CreateFighters()
        {
            //create objects from user's choice
            Fighter fighterOne = PlayerOneListView.SelectedItem as Fighter;
            fighterOne.PlayerStats.Name = PlayerOneNameTextBlock.Text;

            Fighter fighterTwo = PlayerTwoListView.SelectedItem as Fighter;
            fighterTwo.PlayerStats.Name = PlayerTwoNameTextBlock.Text;

            //send these to Fighting Screen as an object of Match
            Match match = new Match(fighterOne, fighterTwo);
            this.Frame.Navigate(typeof(StageScreen), match);

        }
    }
}
