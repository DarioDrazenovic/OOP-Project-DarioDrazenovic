using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PlayersUC : UserControl
    {
        public Player Player { get; set; }
        public PlayersUC(Player player)
        {
            InitializeComponent();
            Player = player;
            SetData(player);
        }

        private void SetData(Player player)
        {
            lblName.Text = player.Name;
            lblNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.Position;

            if (player.Captain == true)
            {
                lblCaptain.Text = "CAPTAIN";
            }
            else 
            {
                lblCaptain.Text = "";
            }
            
        }

        //kontekstni meni
        private void TransferToFavouritePlayerMenuItem_Click(object sender, EventArgs e)
        {
            FavouritePlayers favouritePlayers = this.ParentForm as FavouritePlayers;
            favouritePlayers.TransferPlayerToFavourites(this);
        }

        public void CreateStar()
        {
            lblStar.Text = " * ";
        }

        private void TransferToAllPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FavouritePlayers favouritePlayers = this.ParentForm as FavouritePlayers;
            favouritePlayers.TransferPlayerToAllPlayers(this);
        }

        public void RemoveStar()
        {
            lblStar.Text = " ";
        }

        public override string ToString() => Player.Name;

        private void mouseDown(object sender, MouseEventArgs e)
        {
            PlayersUC playerUc=(PlayersUC)sender;
            playerUc.DoDragDrop(playerUc, DragDropEffects.Copy); 
        }

        private void btnAddPitcure_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "Slike|*.jpg;*.png;*.jpeg";
            if (dialog.ShowDialog()== DialogResult.OK)
            {
                pbPlayer.ImageLocation = dialog.FileName;
            } 
        }
    }
}