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
        //By Burhan

        //property so it can be used throughout the class
        public Match Match { get; set; }
        public FightingPage()
        {
            this.InitializeComponent();
        }
        //called when naviagted to
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

            UpdateHealthAndScoreTextBlocks();
        }
        private async void DetermineAttackerButton_OnClick(object sender, RoutedEventArgs e)
        {
            //disable it so it cannot be pressed again
            DetermineAttackerButton.IsEnabled = false;

            //call determine attack
            List<int> dieResults = Match.Battle.DetermineAttacker();

            //set returned values from list to textblocks
            AttackerTextBlock.Text = $"The attacker is {Match.Battle.Attacker.Name}";
            PlayerOneSumTextBlock.Text = $"{dieResults[0]}";
            PlayerTwoSumTextBlock.Text = $"{dieResults[1]}";

            //enable the view attack button
            AttackMenuButton.IsEnabled = true;
        }

        //changes the appopriate image control
        public async void ChangeImage(Image playerImage)
        {
            playerImage.Source = Match.Battle.Attacker.Pose.Source;

            //wait and set back to default
            await Task.Delay(1000);
            playerImage.Source = Match.Battle.Attacker.DefaultPose().Source;
        }

        public void UpdateHealthAndScoreTextBlocks()
        {
            PlayerOneHealthTextBlock.Text = $"Health: {Match.Fighters[0].Health}";
            PlayerTwoHealthTextBlock.Text = $"Health: {Match.Fighters[1].Health}";

            PlayerOneScoreTextBlock.Text = $"Score: {Match.Fighters[0].Score}";
            PlayerTwoScoreTextBlock.Text = $"Score: {Match.Fighters[1].Score}";
        }

        private async void Punch_OnClick(object sender, RoutedEventArgs e)
        {
            //disable it so its not spammable
            PunchButton.IsEnabled = false;

            //the player that is the attacker will have it's pose changed
            if (Match.Battle.Attacker.IsPlayerOne)
            {
                //call attack(1)
                Match.Battle.ChooseAttack(1);
                ChangeImage(PlayerOneImage);
                //wait and set back to default
                //await Task.Delay(400);
                //PlayerOneImage.Source = Match.Battle.Attacker.DefaultPose().Source;
            }
            else
            {
                //call attack(1)
                Match.Battle.ChooseAttack(1);
                ChangeImage(PlayerTwoImage);
                //wait and set back to default
                //await Task.Delay(400);
            }

            //PlayerOneImage.Source = Match.Fighters[0].Pose.Source;
            UpdateHealthAndScoreTextBlocks();

            await Task.Delay(1000);
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

            UpdateHealthAndScoreTextBlocks();
            await Task.Delay(1000);
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

            UpdateHealthAndScoreTextBlocks();
            await Task.Delay(1000);
            ChangeVisibility();
        }

        private async void Bonus_OnClick(object sender, RoutedEventArgs e)
        {
            HighKickButton.IsEnabled = false;
            if (Match.Battle.Attacker.IsBonusUsed)
            {
                //let them know they can't use it
                MessageDialog dialog = new MessageDialog("Bonus is already used! Cannot use again.");
            }
            else
            {
                //run the code
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
            }
            UpdateHealthAndScoreTextBlocks();
            await Task.Delay(1000);
            ChangeVisibility();
        }

        
        private void ChangeVisibility()
        {
            if (DieRollGrid.Visibility == Visibility.Visible)
            {
                DieRollGrid.Visibility = Visibility.Collapsed;
                AttackGrid.Visibility = Visibility.Visible;
                //disable it so it cannot be pressed again
                DetermineAttackerButton.IsEnabled = true;
            }
            else
            {
                AttackGrid.Visibility = Visibility.Collapsed;
                DieRollGrid.Visibility = Visibility.Visible;

                //enable all attack buttons
                PunchButton.IsEnabled = true;
                HighKickButton.IsEnabled = true;
                LowKickButton.IsEnabled = true;
                BonusButton.IsEnabled = true;
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
