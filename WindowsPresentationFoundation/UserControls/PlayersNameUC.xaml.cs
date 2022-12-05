using DataLayer.Models;
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

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for PlayersNameUC.xaml
    /// </summary>
    public partial class PlayersNameUC : UserControl
    {
        public Player Player { get; set; }
        public PlayersNameUC(Player player)
        {
            InitializeComponent();
            Player = player;
            SetData(player);
        }

        private void SetData(Player player)
        {
            lblName.Content = player.Name;
            btnInfo.Content = player.ShirtNumber;
        }

        
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoPlayers infoPlayers = new InfoPlayers(Player);
            infoPlayers.ShowDialog();
        }
    }
}
