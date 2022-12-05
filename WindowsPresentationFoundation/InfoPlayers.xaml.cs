using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for InfoPlayers.xaml
    /// </summary>
    public partial class InfoPlayers : Window
    {

        public Player Player { get; set; }
        public InfoPlayers(Player player)
        {
            InitializeComponent();
            this.Player = player;
            SetData();
        }

        private void SetData()
        {
            lblPlayerName.Content = Player.Name;
            lblShirtNumber.Content = Player.ShirtNumber;
            lblPosition.Content = Player.Position;
            lblGoalsScored.Content = Player.Goals;
            lblYellowCard.Content = Player.YellowCards;

            if (Player.Captain)
            {
                lblCaptain.Content = "Captain";
            }
        }

        private void btnIzadi_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
