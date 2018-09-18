using System;
using System.Windows;
using System.Windows.Controls;
using RaceStatistics.Logic.Factory;
using RaceStatistics.Logic.Interfaces.Exceptions;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics
{
    // ReSharper disable once RedundantExtendsListEntry
    public partial class DisciplineOverview : UserControl
    {
        private readonly IDisciplineCollection disciplineCollection;

        private readonly MainWindow mainWindow;

        public DisciplineOverview()
        {
            InitializeComponent();
            disciplineCollection = LogicFactory.GetDisciplineCollection();
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
                    disciplineCollection.AddDiscipline(TxtAddDiscipline.Text);
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
                    disciplineCollection.RemoveDiscipline(selectedDiscipline);

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
                LvDisciplines.ItemsSource = disciplineCollection.GetDisciplines();

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
            mainWindow.EditSeasons(LvDisciplines.SelectedItem as IDiscipline);
        }
    }
}
