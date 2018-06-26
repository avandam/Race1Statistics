using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class MainWindow : RibbonWindow
    {
        private readonly Dictionary<string, UserControl> customControls = new Dictionary<string, UserControl>();

        public MainWindow()
        {
            InitializeComponent();
            DisciplineOverview disciplineOverview = new DisciplineOverview(this);
            customControls.Add("Discipline", disciplineOverview);
            GrdMain.Children.Add(disciplineOverview);
        }

        private void ViewDisciplines_OnClick(object sender, RoutedEventArgs e)
        {
            ShowDisciplines();
        }

        public void ShowDisciplines()
        {
            HideAllUserControls();
            GrdMain.Children.Add(customControls["Discipline"]);
        }

        public void ShowSeasons(IDiscipline discipline)
        {
            HideAllUserControls();
            SeasonOverview seasonOverview = new SeasonOverview(this);
            AddCustomControl("Season", seasonOverview);
            GrdMain.Children.Add(seasonOverview);
        }

        public void CloseSeason()
        {
            HideAllUserControls();
            RemoveCustomControl("Season");
            GrdMain.Children.Add(customControls["Discipline"]);
        }

        private void AddCustomControl(string name, UserControl control)
        {
            if (customControls.ContainsKey(name))
            {
                customControls[name] = control;
            }
            else
            {
                customControls.Add(name, control);
            }
        }

        private void RemoveCustomControl(string name)
        {
            if (customControls.ContainsKey(name))
            {
                customControls.Remove(name);
            }
        }

        public void HideAllUserControls()
        {
            foreach (var control in customControls)
            {
                if (GrdMain.Children.Contains(control.Value))
                {
                    GrdMain.Children.Remove(control.Value);
                }
            }
        }

    }
}
