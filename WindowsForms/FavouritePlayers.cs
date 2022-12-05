using DataLayer;
using DataLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.Models;

namespace WindowsForms
{
    public partial class FavouritePlayers : Form
    {
        private const string Path_woman = "http://worldcup.sfg.io/matches";
        private const string Path_man = "http://world-cup-json-2018.herokuapp.com/matches";

        private static readonly string directory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string fileName = Path.Combine(directory, @"..\..\..\najdraziIgraci.txt");
        private static readonly string path = Path.GetFullPath(fileName);

        //za json
        private static readonly string fileNameMatchWomen = Path.Combine(directory, @"..\..\..\worldcup.sfg.io\women\matches.json");
        private static readonly string pathMatchWomen = Path.GetFullPath(fileNameMatchWomen);

        private static readonly string fileNameMatchMen = Path.Combine(directory, @"..\..\..\worldcup.sfg.io\men\matches.json");
        private static readonly string pathMatchMen = Path.GetFullPath(fileNameMatchMen);

        private static readonly string konfiguracijska = Path.Combine(directory, @"..\..\..\konfiguracijskaDatoteka.txt");
        private static readonly string pathKonfiguracijska = Path.GetFullPath(konfiguracijska);



        private Object favouriteCountry;
        private Object gender;
        private Object language;
        public FavouritePlayers(Object country,Object gender, Object language)
        {
            InitializeComponent();
            this.favouriteCountry = country;
            this.gender = gender;
            this.language = language;
        }

        private void FavouritePlayers_Load(object sender, EventArgs e)
        {
            GetPlayers();
        }

        private  async void GetPlayers()
        {
            try
            {
                if (gender.ToString() == "muško")
                {
                    if (Repository.ReadConfig(pathKonfiguracijska) == "link")
                    {
                        await GetResults(Path_man);
                    }
                    else if (Repository.ReadConfig(pathKonfiguracijska) == "datoteka")
                    {
                        GetResultsFromFile(pathMatchMen);
                    }

                }
                else if (gender.ToString() == "žensko")
                {

                    if (Repository.ReadConfig(pathKonfiguracijska) == "link")
                    {
                        await GetResults(Path_woman);
                    }
                    else if (Repository.ReadConfig(pathKonfiguracijska) == "datoteka")
                    {
                        GetResultsFromFile(pathMatchWomen);
                    }

                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private void GetResultsFromFile(string path)
        {
            var listMatches = Repository.ReadJsonData<Utakmica>(path);
            SetUserControls(listMatches);
            
        }

        private  async Task GetResults(string path)
        {
            //podatci u obliku jsona stizu tu
            var data = await Repository.GetData<Utakmica>(path);
            var deserializedData = JsonConvert.DeserializeObject<List<Utakmica>>(data.Content);
            SetUserControls(deserializedData);

        }

        private void SetUserControls(List<Utakmica> deserializedData)
        {
            int zagradaOtvarajuca = favouriteCountry.ToString().IndexOf('(');

            foreach (var match in deserializedData)
            {
                if (favouriteCountry.ToString().Substring(0, zagradaOtvarajuca-1) == match.HomeTeam.CountryName)
                {
                    List<Player> allPlayers = new List<Player>();
                    //home tim statistika
                    match.HomeTeamStatistics.StartingEleven.ToList().ForEach(player => allPlayers.Add(player));
                    match.HomeTeamStatistics.Substitutes.ToList().ForEach(player => allPlayers.Add(player));
                    allPlayers.ToList().ForEach(player => pnlPlayers.Controls.Add(new PlayersUC(player)));
                    break;
                }
                else if (favouriteCountry.ToString().Substring(0, zagradaOtvarajuca-1) == match.AwayTeam.CountryName)
                {
                    //away tim statistika
                    List<Player> allPlayers = new List<Player>();
                    match.AwayTeamStatistics.StartingEleven.ToList().ForEach(player => allPlayers.Add(player));
                    match.AwayTeamStatistics.Substitutes.ToList().ForEach(player => allPlayers.Add(player));
                    allPlayers.ToList().ForEach(player => pnlPlayers.Controls.Add(new PlayersUC(player)));
                    break;
                }
            }
        }

        //kontekstni meni
        public void TransferPlayerToAllPlayers(PlayersUC playersUC)
        {
            pnlFPlayers.Controls.Remove(playersUC);
            pnlPlayers.Controls.Add(playersUC);
            playersUC.RemoveStar();
        }

        public void TransferPlayerToFavourites(PlayersUC playersUC)
        {
            pnlPlayers.Controls.Remove(playersUC);
           
                pnlFPlayers.Controls.Add(playersUC);
                playersUC.CreateStar();
            
        }



        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (pnlFPlayers.Controls.Count==3)
            {
                this.Hide();
                List<Object> players = new List<Object>();
                foreach (var item in pnlFPlayers.Controls)
                {
                    players.Add(item);
                }
                Repository.WriteInFilePlayers(players, path);
                RankingList rl = new RankingList(favouriteCountry, gender, language);
                rl.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Morate odabrati 3 najdraza igraca!");
            }
        }

        
        //Drag'n drop
        private void dragEnterFavouritePlayers(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dragEnterPlayers(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        //poziva se kad zavrsi uspjesni drop
        private void dragDropFavouritePlayers(object sender, DragEventArgs e) 
        {
            PlayersUC favouriteplayerUc = (PlayersUC)e.Data.GetData(typeof(PlayersUC));
            TransferPlayerToFavourites(favouriteplayerUc);

        }
        //poziva se kad zavrsi uspjesni drop
        private void dragDropPlayers(object sender, DragEventArgs e) 
        {
            PlayersUC playerUc = (PlayersUC)e.Data.GetData(typeof(PlayersUC));
            TransferPlayerToAllPlayers(playerUc);

        }

        
    }
}
