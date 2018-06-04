using System;
using System.Windows;
using RaceStatistics.Logic.Factory;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class MainWindow : Window
    {
        private readonly IRaceStats raceStats;
        public MainWindow()
        {
            InitializeComponent();
            raceStats = LogicFactory.GetRaceStats();
            UpdateUi();
        }

        private void BtnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtAddDiscipline.Text))
            {
                try
                {
                    raceStats.AddDiscipline(TxtAddDiscipline.Text);
                }
                catch (InvalidInputException exception)
                {
                    MessageBox.Show($"Input error on adding a discipline.\nError: {exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (ConnectionException exception)
                {
                    MessageBox.Show($"Error adding discipline.\nError: {exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                UpdateUi();
            }
            else
            {
                MessageBox.Show("Please fill in a discipline name before you add it.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRemoveDiscipline_Click(object sender, RoutedEventArgs e)
        {
            if (LvDisciplines.SelectedIndex >= 0)
            {
                IDiscipline selectedDiscipline = LvDisciplines.SelectedItem as IDiscipline;
                try
                {
                    raceStats.RemoveDiscipline(selectedDiscipline);

                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Could not remove the disciplines\nError: {exception.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }

                UpdateUi();
            }
        }

        public void UpdateUi()
        {

            try
            {
                LvDisciplines.ItemsSource = raceStats.GetDisciplines();

            }
            catch (ConnectionException exception)
            {
                MessageBox.Show($"Could not get the disciplines\nError: {exception.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                LvDisciplines.ItemsSource = null;
            }

            LvDisciplines.Items.Refresh();
        }
    }
}
