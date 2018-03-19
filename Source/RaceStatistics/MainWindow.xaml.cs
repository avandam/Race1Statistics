using System;
using System.Windows;
using RaceStatistics.Domain.Exceptions;
using RaceStatistics.Factory;
using RaceStatistics.Logic;
using RaceStatistics.Logic.Interfaces;

namespace RaceStatistics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRaceStats raceStats;
        public MainWindow()
        {
            InitializeComponent();
            raceStats = RaceStatsFactory.GetRaceStats();
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
                catch (DisciplineExistsException exception)
                {
                    MessageBox.Show($"Could not add discipline. Error: {exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                UpdateUi();
            }
            else
            {
                MessageBox.Show("Please fill in a discipline before you add it.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRemoveDiscipline_Click(object sender, RoutedEventArgs e)
        {
            if (LvDisciplines.SelectedIndex >= 0)
            {
                IDiscipline selectedDiscipline = LvDisciplines.SelectedItem as IDiscipline;
                raceStats.RemoveDiscipline(selectedDiscipline);
                UpdateUi();
            }
        }

        public void UpdateUi()
        {
            LvDisciplines.ItemsSource = raceStats.GetDisciplines();
            LvDisciplines.Items.Refresh();
        }
    }
}
