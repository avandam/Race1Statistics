using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using RaceStatistics.Logic.Interfaces.Interfaces;

namespace RaceStatistics
{
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

        #region Ribbon button handles
        private void EditDisciplines_Click(object sender, RoutedEventArgs e)
        {
            ShowDisciplines();
        }

        private void EditScoreSystems_Click(object sender, RoutedEventArgs e)
        {
            ShowScoreSystems();
        }
        #endregion Ribbon button handles

        #region Actions
        public void ShowDisciplines()
        {
            HideAllUserControls();
            GrdMain.Children.Add(customControls["Discipline"]);
        }

        public void ShowScoreSystems()
        {
            HideAllUserControls();
            ScoreSystemOverview scoreSystemOverview = new ScoreSystemOverview(this);
            AddCustomControl("ScoreSystem", scoreSystemOverview);
            GrdMain.Children.Add(scoreSystemOverview);
        }

        public void EditSeasons(IDiscipline discipline)
        {
            HideAllUserControls();
            SeasonOverview seasonOverview = new SeasonOverview(this);
            AddCustomControl("Season", seasonOverview);
            GrdMain.Children.Add(seasonOverview);
        }

        public void EditScores(IScoreSystem scoreSystem)
        {
            throw new System.NotImplementedException();
        }


        public void CloseSeason()
        {
            HideAllUserControls();
            RemoveCustomControl("Season");
            GrdMain.Children.Add(customControls["Discipline"]);
        }

        #endregion Actions

        #region Control management
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

        private void HideAllUserControls()
        {
            foreach (var control in customControls)
            {
                if (GrdMain.Children.Contains(control.Value))
                {
                    GrdMain.Children.Remove(control.Value);
                }
            }
        }
        #endregion Control management

    }
}
