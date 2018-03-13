using System;
using System.Windows;
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
                raceStats.AddDiscipline(TxtAddDiscipline.Text);
                UpdateUi();
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
