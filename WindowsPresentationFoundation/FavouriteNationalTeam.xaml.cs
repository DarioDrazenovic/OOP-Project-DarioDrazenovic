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
    /// Interaction logic for FavouriteNationalTeam.xaml
    /// </summary>
    public partial class FavouriteNationalTeam : Window
    {
        private const string Path_woman = "http://worldcup.sfg.io/teams/";
        private const string Path_man = "http://world-cup-json-2018.herokuapp.com/teams";

       
        private const string PathWomanFifaCode = "http://worldcup.sfg.io/matches/country?fifa_code=";
        private const string PathManFifaCode = "http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";

        private static readonly string directory = AppDomain.CurrentDomain.BaseDirectory;

        //za json
        private static readonly string fileNameTeamWomen = Path.Combine(directory, @"..\..\..\worldcup.sfg.io\women\teams.json");
        private static readonly string pathTeamWomen = Path.GetFullPath(fileNameTeamWomen);

        private static readonly string fileNameTeamMen = Path.Combine(directory, @"..\..\..\worldcup.sfg.io\men\teams.json");
        private static readonly string pathTeamMen = Path.GetFullPath(fileNameTeamMen);

        private static readonly string konfiguracijska = Path.Combine(directory, @"..\..\..\konfiguracijskaDatoteka.txt");
        private static readonly string pathKonfiguracijska = Path.GetFullPath(konfiguracijska);


        Object gender;
        Object language;
        Object resolution;

        private List<Utakmica> deserializedData = new List<Utakmica>();

        Object favourite;
        Object opponent;


        
        List<string> opponentTeams = new List<string>();

        public FavouriteNationalTeam(object gender, object language, object resolution)
        {
            InitializeComponent();
            this.gender = gender;
            this.language = language;
            this.resolution = resolution;
            SetScreenSize(resolution);
            FillCbFavTeam();
        }

      
           

        //dohvati reprezentacije tj. napuni timove
        private async void FillCbFavTeam()
        {
            try
            {

                if (gender.ToString() == "muško")
                {
                    if (Repository.ReadConfig(konfiguracijska) == "link")
                    {
                        await GetResults(Path_man);
                    }
                    else if (Repository.ReadConfig(konfiguracijska) == "datoteka")
                    {
                        GetResultsFromFile(pathTeamMen);
                    }


                }
                else if (gender.ToString() == "žensko")
                {
                    if (Repository.ReadConfig(konfiguracijska) == "link")
                    {
                        await GetResults(Path_woman);
                    }
                    else if (Repository.ReadConfig(konfiguracijska) == "datoteka")
                    {
                        GetResultsFromFile(pathTeamWomen);
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //API dohvacanje
        private async Task GetResults(string path)
        {
            var data = await Repository.GetData<Tim>(path); //tu su stigli podaci u obliku json-a
            var deserializedData = JsonConvert.DeserializeObject<List<Tim>>(data.Content);

            AddDataToCombo(deserializedData);
        }

        private void AddDataToCombo(List<Tim> listTeams)
        {
            foreach (var item in listTeams)
            {
                cbFavouriteTeam.Items.Add(item);
            }

            cbFavouriteTeam.SelectedIndex = 0;
        }

        //Datoteka dohvacanje
        private void GetResultsFromFile(string path)
        {
            var listTeams = Repository.ReadJsonData<Tim>(path);

            AddDataToCombo(listTeams);
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


       
        private async void cbFavouriteTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            try
            {
                if (gender.ToString() == "muško")
                {
                    await GetResultsMatches(PathManFifaCode);
                }
                else if (gender.ToString() == "žensko")
                {
                    await GetResultsMatches(PathWomanFifaCode);
                }
               
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


       
        private async Task GetResultsMatches(string path)
        {
            deserializedData.Clear();

            var favouriteCountry = cbFavouriteTeam.SelectedItem;
            int zagradaOtvarajuca = favouriteCountry.ToString().IndexOf('(');
            var fifaCode = favouriteCountry.ToString().Substring(zagradaOtvarajuca + 1, 3);

            // podatci u obliku jsona su tu
            var data = await Repository.GetData<Utakmica>($"{path}{fifaCode}");
            deserializedData = JsonConvert.DeserializeObject<List<Utakmica>>(data.Content);
            FillCbOpponent(deserializedData,favouriteCountry, zagradaOtvarajuca);
        }


       
        //dohvati protivnika
        private void FillCbOpponent(List<Utakmica> deserializedData, object favouriteCountry, int zagrada)
        {
            
            opponentTeams.Clear();

            foreach (var match in deserializedData)
            {
                if (favouriteCountry.ToString().Substring(0, zagrada-1) == match.HomeTeamCountry)
                {
                    opponentTeams.Add(match.AwayTeamCountry);
                }
                else if(favouriteCountry.ToString().Substring(0, zagrada-1) == match.AwayTeamCountry)
                {
                    opponentTeams.Add(match.HomeTeamCountry);
                }
            }
            cbOppenentTeam.Items.Clear();
            foreach (var team in opponentTeams)
            {
                cbOppenentTeam.Items.Add(team);
            }

            cbOppenentTeam.SelectedIndex = 0;
            

        }

        //tu se pojavlja rezultat
        private void cbOppenentTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            lblResultFavourite.Content = "";
            lblResultOpponent.Content = "";

            favourite = (Object)cbFavouriteTeam.SelectedItem;
            opponent = "";
            if (cbOppenentTeam.Items.Count > 0)
            {
                opponent = (Object)cbOppenentTeam.SelectedItem;
            }
            

            int zagradaOtvarajuca = favourite.ToString().IndexOf('(');

            foreach (var match in deserializedData)
            {
                if (favourite.ToString().Substring(0,zagradaOtvarajuca-1)  == match.HomeTeamCountry && opponent.ToString() == match.AwayTeamCountry)
                {
                    lblResultFavourite.Content = match.HomeTeam.Goals;
                    lblResultOpponent.Content = match.AwayTeam.Goals;
                } 
                else if(opponent.ToString() == match.HomeTeamCountry && favourite.ToString().Substring(0, zagradaOtvarajuca-1) == match.AwayTeamCountry)
                {
                    lblResultFavourite.Content = match.AwayTeam.Goals;
                    lblResultOpponent.Content = match.HomeTeam.Goals;
                }
            }
           

        }

        private void btnInfoFavourite_Click(object sender, RoutedEventArgs e)
        {
            
            int zagradaOtvarajuca = favourite.ToString().IndexOf('(');

            var fav = favourite.ToString().Substring(0, zagradaOtvarajuca - 1);
            

            TeamInformation teamInformation = new TeamInformation(gender, language, fav);
            teamInformation.ShowDialog();
        }

        private void btnInfoOpponent_Click(object sender, RoutedEventArgs e)
        {
            TeamInformation teamInformation = new TeamInformation(gender, language, opponent);
            teamInformation.ShowDialog();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            StartingPlayers startingPlayers = new StartingPlayers(gender, language, resolution, favourite, opponent);
            this.Hide();
            startingPlayers.ShowDialog();
            this.Close();
        }
    }
}
