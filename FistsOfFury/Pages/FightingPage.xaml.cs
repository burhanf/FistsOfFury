using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FistsOfFury.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FightingPage : Page
    {
        /// <summary>
        /// Principal Author: Burhan
        /// This class is responsible for the players fighting each other 
        /// </summary>

        //Properties
        public Match Match { get; private set; }
        public FightingPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //assign the match to have fighters from character selection
            Match = e.Parameter as Match;

            //set initial poses
            PlayerOneImage.Source = Match.Fighters[0].Pose.Source;
            PlayerTwoImage.Source = Match.Fighters[1].Pose.Source;

            //set names and initial details
            FighterOneNameTextBlock.Text = Match.Fighters[0].Name;
            FighterTwoNameTextBlock.Text = Match.Fighters[1].Name;

            //todo this must be replaced with the player's name
            PlayerOneNameTextBlock.Text = Match.Fighters[0].Name;
            PlayerTwoNameTextBlock.Text = Match.Fighters[1].Name;

            //todo set background to the image selected from ArenaSelection
            background.ImageSource = Match.ArenaImage.Source;

            UpdateHealthAndScoreTextBlocks();
        }
        private void DetermineAttackerButton_OnClick(object sender, RoutedEventArgs e)
        {
            //check if there's a winner to display
            if (Match.Battle.Winner != null)
            {
                //todo Go to next page fight statistics screen
                MessageDialog dialog = new MessageDialog($"The winner is {Match.Battle.Winner.Name}!\nPunch Accuracy: {Match.Battle.Winner.PlayerStats.PunchAccuracy}%\nLow Kick Accuracy: {Match.Battle.Winner.PlayerStats.LowKickAccuracy}%\nHigh Kick Accuracy: {Match.Battle.Winner.PlayerStats.HighKickAccuracy}%");
                dialog.ShowAsync();
            }
            else
            {
                //disable button so it cannot be pressed multiple times
                DetermineAttackerButton.IsEnabled = false;

                List<int> dieResults = Match.Battle.DetermineAttacker();

                //set returned values from list to textblocks
                AttackerTextBlock.Text = $"The attacker is {Match.Battle.Attacker.Name}";
                PlayerOneSumTextBlock.Text = $"{dieResults[0]}";
                PlayerTwoSumTextBlock.Text = $"{dieResults[1]}";

                //allow player to view attack's
                AttackMenuButton.IsEnabled = true;
            }

        }
        private async void ChangeImage(Image playerImage)
        {
            //changes the appopriate image control

            playerImage.Source = Match.Battle.Attacker.Pose.Source;
            //wait and set back to default
            await Task.Delay(1000);
            playerImage.Source = Match.Battle.Attacker.DefaultPose().Source;
        }

        private void UpdateHealthAndScoreTextBlocks()
        {
            PlayerOneHealthTextBlock.Text = $"Health: {Match.Fighters[0].Health}";
            PlayerTwoHealthTextBlock.Text = $"Health: {Match.Fighters[1].Health}";
            PlayerOneHealthBar.Value = Match.Fighters[0].Health;
            PlayerTwoHealthBar.Value = Match.Fighters[1].Health;

            PlayerOneScoreTextBlock.Text = $"Score: {Match.Fighters[0].Score}";
            PlayerTwoScoreTextBlock.Text = $"Score: {Match.Fighters[1].Score}";
        }

        private void DisplayMissedAttackPrompt()
        {
            //if the fighter has attempted an attack and missed, notify the player
            if (Match.Battle.Attacker.IsAttackMissed)
            {
                MessageDialog dialog = new MessageDialog("Missed!");
                dialog.ShowAsync();
            }
        }

        private async void Punch_OnClick(object sender, RoutedEventArgs e)
        {
            //disable it so it cannot be pressed multiple times
            PunchButton.IsEnabled = false;

            //the player that is the attacker will have it's pose changed
            if (Match.Battle.Attacker.IsPlayerOne)
            {
                Match.Battle.ChooseAttack(1);
                ChangeImage(PlayerOneImage);
            }
            else
            {
                Match.Battle.ChooseAttack(1);
                ChangeImage(PlayerTwoImage);
            }
            DisplayMissedAttackPrompt();
            UpdateHealthAndScoreTextBlocks();

            await Task.Delay(900);
            ChangeVisibility();
        }

        private async void HighKick_OnClick(object sender, RoutedEventArgs e)
        {
            HighKickButton.IsEnabled = false;

            if (Match.Battle.Attacker.IsPlayerOne)
            {
                Match.Battle.ChooseAttack(2);
                ChangeImage(PlayerOneImage);
            }
            else
            {
                Match.Battle.ChooseAttack(2);
                ChangeImage(PlayerTwoImage);
            }
            DisplayMissedAttackPrompt();
            UpdateHealthAndScoreTextBlocks();
            await Task.Delay(900);
            ChangeVisibility();
        }

        private async void LowKick_OnClick(object sender, RoutedEventArgs e)
        {
            LowKickButton.IsEnabled = false;

            if (Match.Battle.Attacker.IsPlayerOne)
            {
                Match.Battle.ChooseAttack(3);
                ChangeImage(PlayerOneImage);
            }
            else
            {
                Match.Battle.ChooseAttack(3);
                ChangeImage(PlayerTwoImage);
            }
            DisplayMissedAttackPrompt();
            UpdateHealthAndScoreTextBlocks();
            await Task.Delay(900);
            ChangeVisibility();
        }

        private async void Bonus_OnClick(object sender, RoutedEventArgs e)
        {
            HighKickButton.IsEnabled = false;

            if (Match.Battle.Attacker.IsPlayerOne)
            {
                Match.Battle.ChooseAttack(4);
                ChangeImage(PlayerOneImage);
            }
            else
            {
                Match.Battle.ChooseAttack(4);
                ChangeImage(PlayerTwoImage);
            }
            DisplayMissedAttackPrompt();
            UpdateHealthAndScoreTextBlocks();
            await Task.Delay(900);
            ChangeVisibility();
        }


        private void ChangeVisibility()
        {
            //if the current screen is the die roll, change it to the attack screen, if not, make it die roll screen
            if (DieRollGrid.Visibility == Visibility.Visible)
            {
                DieRollGrid.Visibility = Visibility.Collapsed;
                AttackGrid.Visibility = Visibility.Visible;
                //disable it so it cannot be pressed multiple times
                DetermineAttackerButton.IsEnabled = true;

                //bonus move can only be used once in entire game for each player
                //only let bonus be used again for that player if they haven't used their bonus move yet
                if ((Match.Battle.Fighters[0] == Match.Battle.Attacker) && Match.Battle.Attacker.IsBonusUsed)
                {
                    BonusButton.IsEnabled = false;
                }
                else if ((Match.Battle.Fighters[1] == Match.Battle.Attacker) && Match.Battle.Attacker.IsBonusUsed)
                {
                    BonusButton.IsEnabled = false;
                }
                else
                {
                    BonusButton.IsEnabled = true;
                }
            }
            else
            {
                AttackGrid.Visibility = Visibility.Collapsed;
                DieRollGrid.Visibility = Visibility.Visible;

                //enable all attack buttons
                PunchButton.IsEnabled = true;
                HighKickButton.IsEnabled = true;
                LowKickButton.IsEnabled = true;
            }

            //if a winner has been found, update the determine button to let user go to stats page
            if (Match.Battle.Winner != null)
            {
                //change the text of the button to tell user to advance to next screen
                DetermineAttackerButton.Content = "See Winner Details";

                //change the attacker text to display the winner's name
                AttackerTextBlock.Text = $"The winner is {Match.Battle.Winner.Name}!";
            }
        }

        private void AttackMenuButton_OnClick(object sender, RoutedEventArgs e)
        {
            //make it disabled until an attacker is determined
            AttackMenuButton.IsEnabled = false;
            ChangeVisibility();
        }
    }
}
