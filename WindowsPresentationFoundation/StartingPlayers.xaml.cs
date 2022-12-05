using DataLayer;
using DataLayer.Models;
using Newtonsoft.Json;
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
using WindowsForms.Models;

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for StartingPlayers.xaml
    /// </summary>
    public partial class StartingPlayers : Window
    {
        private const string Path_woman = "http://worldcup.sfg.io/matches";
        private const string Path_man = "http://world-cup-json-2018.herokuapp.com/matches";

        private static readonly string directory = AppDomain.CurrentDomain.BaseDirectory;

        private static readonly string fileNameMatchWomen = Path.Combine(directory, @"..\..\..\worldcup.sfg.io\women\matches.json");
        private static readonly string pathMatchWomen = Path.GetFullPath(fileNameMatchWomen);

        private static readonly string fileNameMatchMen = Path.Combine(directory, @"..\..\..\worldcup.sfg.io\men\matches.json");
        private static readonly string pathMatchMen = Path.GetFullPath(fileNameMatchMen);

        private static readonly string konfiguracijska = Path.Combine(directory, @"..\..\..\konfiguracijskaDatoteka.txt");
        private static readonly string pathKonfiguracijska = Path.GetFullPath(konfiguracijska);

        private Object favourite;
        private Object gender;
        private Object language;
        private Object resolution;
        private Object opponent;

        public StartingPlayers(Object gender, Object language, Object resolution, Object favorite, Object opponent)
        {
            InitializeComponent();
            this.gender = gender;
            this.language = language;
            this.resolution = resolution;
            this.favourite = SubstringFavourite(favorite);
            this.opponent = opponent;
            SetScreenSize(resolution);
            GetPlayers();
            
        }

        private Object SubstringFavourite(Object favourite)
        {
            int zagradaOtvarajuca = favourite.ToString().IndexOf('(');
            return favourite.ToString().Substring(0, zagradaOtvarajuca-1);
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
            SetUserControlsFavourite(listMatches);
            SetUserControlsOpponent(listMatches);
        }


        private async Task GetResults(string path)
        {
            //podatci u obliku jsona tu dolaze
            var data = await Repository.GetData<Utakmica>(path);
            var deserializedData = JsonConvert.DeserializeObject<List<Utakmica>>(data.Content);
            SetUserControlsFavourite(deserializedData);
            SetUserControlsOpponent(deserializedData);
        }

        private void SetUserControlsFavourite(List<Utakmica> deserializedData)
        {
            
            foreach (var match in deserializedData)
            {
                if (favourite.ToString() == match.HomeTeam.CountryName)
                {
                    List<Player> allPlayers = new List<Player>();
                    //home tim statistika
                    match.HomeTeamStatistics.StartingEleven.ToList().ForEach(player => allPlayers.Add(player));
                    allPlayers.ToList().ForEach(player => pnlFavourite.Children.Add(new PlayersNameUC(player)));
                    break;
                }
                else if (favourite.ToString() == match.AwayTeam.CountryName)
                {
                    //away tim statistika
                    List<Player> allPlayers = new List<Player>();
                    match.AwayTeamStatistics.StartingEleven.ToList().ForEach(player => allPlayers.Add(player));
                    allPlayers.ToList().ForEach(player => pnlFavourite.Children.Add(new PlayersNameUC(player)));
                    break;
                }
                
            }
        }


        private void SetUserControlsOpponent(List<Utakmica> listMatches)
        {
            int zagradaOtvarajuca = favourite.ToString().IndexOf('(');

            foreach (var match in listMatches)
            {
                if (opponent.ToString() == match.HomeTeam.CountryName)
                {
                    List<Player> allPlayers = new List<Player>();
                    //home tim statistika
                    match.HomeTeamStatistics.StartingEleven.ToList().ForEach(player => allPlayers.Add(player));
                    allPlayers.ToList().ForEach(player => pnlOpponent.Children.Add(new PlayersNameUC(player)));
                    break;
                }
                else if (opponent.ToString() == match.AwayTeam.CountryName)
                {
                    //away tim statistika
                    List<Player> allPlayers = new List<Player>();
                    match.AwayTeamStatistics.StartingEleven.ToList().ForEach(player => allPlayers.Add(player));
                    allPlayers.ToList().ForEach(player => pnlOpponent.Children.Add(new PlayersNameUC(player)));
                    break;
                }

            }
        }

        

        private void SetScreenSize(object resolution)
        {
            switch (resolution)
            {
                case Rezolucija.small:
                    SetResolution(350, 300);
                    break;
                case Rezolucija.large:
                    SetResolution(650, 500);
                    break;
                case Rezolucija.fullscreen:
                    WindowState = WindowState.Maximized;
                    break;
                default:
                    break;
            }
        }

        private void SetResolution(int width, int height)
        {
            WindowState = WindowState.Normal;
            this.Width = width;
            this.Height = height;
        }

        private void btnPostavke_Click(object sender, RoutedEventArgs e)
        {
          
            MessageBoxResult result = MessageBox.Show("Jeste li sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Hide();
                Menu menu = new Menu();
                menu.ShowDialog();
                this.Close();
            }
        }
    }
}
