using System.Windows;
using System.Windows.Controls;

namespace RaceStatistics
{
    // ReSharper disable once RedundantExtendsListEntry
    public partial class SeasonOverview : UserControl
    {
        private readonly MainWindow mainWindow;

        public SeasonOverview()
        {
            InitializeComponent();
        }

        public SeasonOverview(MainWindow mainWindow) : this()
        {
            this.mainWindow = mainWindow;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CloseSeason();
        }
    }
}
