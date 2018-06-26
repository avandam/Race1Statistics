using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RaceStatistics.Logic.Factory;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics
{
    /// <summary>
    /// Interaction logic for DisciplineOverview.xaml
    /// </summary>
    public partial class DisciplineOverview : UserControl
    {
        private readonly IRaceStats raceStats;

        private readonly MainWindow mainWindow;

        public DisciplineOverview()
        {
            InitializeComponent();
            raceStats = LogicFactory.GetRaceStats();
            UpdateUi();
        }

        public DisciplineOverview(MainWindow window) : this()
        {
            mainWindow = window;
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

        private void BtnShowSeasons_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowSeasons(LvDisciplines.SelectedItem as IDiscipline);
        }
    }
}
