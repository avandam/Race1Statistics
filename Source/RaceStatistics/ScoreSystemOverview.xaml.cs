using System;
using System.Windows;
using System.Windows.Controls;
using RaceStatistics.Logic.Factory;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics
{
    // ReSharper disable once RedundantExtendsListEntry
    public partial class ScoreSystemOverview : UserControl
    {
        private readonly IScoreSystemCollection scoreSystemCollection;

        private readonly MainWindow mainWindow;

        public ScoreSystemOverview()
        {
            InitializeComponent();
            scoreSystemCollection = LogicFactory.GetScoreSystemCollection();
            UpdateUi();
        }

        public ScoreSystemOverview(MainWindow window) : this()
        {
            mainWindow = window;
        }

        private void BtnAddScoreSystem_Click(object sender, RoutedEventArgs e)
        {
            bool hasErrors = false;

            if (String.IsNullOrEmpty(TxtName.Text))
            {
                MessageBox.Show("Please fill in a discipline name before you add it.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                hasErrors = true;
            }

            if (!int.TryParse(TxtPointsForFastestLap.Text, out int pointsForFastestLap))
            {
                MessageBox.Show("Please fill in a number for the points for the fastest lap.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                hasErrors = true;
            }

            if (pointsForFastestLap < 0)
            {
                MessageBox.Show("Please fill in a positive number for the points for the fastest lap", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                hasErrors = true;
            }

            if (!hasErrors)
            {
                try
                {
                    scoreSystemCollection.AddScoreSystem(TxtName.Text, pointsForFastestLap);
                }
                catch (InvalidInputException exception)
                {
                    MessageBox.Show($"Input error on adding the score system.\nError: {exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (ConnectionException exception)
                {
                    MessageBox.Show($"Error adding the score system.\nError: {exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                UpdateUi();
            }
        }

        private void BtnRemoveScoreSystem_Click(object sender, RoutedEventArgs e)
        {
            if (LvScoreSystems.SelectedIndex >= 0)
            {
                IScoreSystem selectedScoreSystem = LvScoreSystems.SelectedItem as IScoreSystem;
                try
                {
                    scoreSystemCollection.RemoveScoreSystem(selectedScoreSystem);

                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Could not remove the score system\nError: {exception.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }

                UpdateUi();
            }
        }

        public void UpdateUi()
        {

            try
            {
                LvScoreSystems.ItemsSource = scoreSystemCollection.GetScoreSystems();

            }
            catch (ConnectionException exception)
            {
                MessageBox.Show($"Could not get the score systems\nError: {exception.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                LvScoreSystems.ItemsSource = null;
            }

            LvScoreSystems.Items.Refresh();
        }

        private void BtnEditScores_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.EditScores(LvScoreSystems.SelectedItem as IScoreSystem);
        }
    }
}
