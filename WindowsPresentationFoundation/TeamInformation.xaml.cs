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

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for TeamInformation.xaml
    /// </summary>
    public partial class TeamInformation : Window
    {
        private const string Path_woman = "http://worldcup.sfg.io/teams/results";
        private const string Path_man = "http://world-cup-json-2018.herokuapp.com/teams/results";

        private static readonly string directory = AppDomain.CurrentDomain.BaseDirectory;

        //za json
        private static readonly string fileNameInfoWomen = Path.Combine(directory, @"..\..\..\worldcup.sfg.io\women\results.json");
        private static readonly string pathInfoWomen = Path.GetFullPath(fileNameInfoWomen);

        private static readonly string fileNameInfoMen = Path.Combine(directory, @"..\..\..\worldcup.sfg.io\men\results.json");
        private static readonly string pathInfoMen = Path.GetFullPath(fileNameInfoMen);

        private static readonly string konfiguracijska = Path.Combine(directory, @"..\..\..\konfiguracijskaDatoteka.txt");
        private static readonly string pathKonfiguracijska = Path.GetFullPath(konfiguracijska);

        Object team;
        Object gender;
        Object language;

        public TeamInformation(Object gender, object language, Object team)
        {
            InitializeComponent();
            this.team = team;
            this.gender = gender;
            this.language = language;
            
            GetData();
            
        }

        

        private async void GetData()
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
                        GetResultsFromFile(fileNameInfoMen);
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
                        GetResultsFromFile(fileNameInfoWomen);
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
            var listTeams = Repository.ReadJsonData<TimInfo>(path);

            PrintInformation(listTeams);

        }

        private async Task GetResults(string path)
        {
            //podatci u obliku jsona tu dolaze
            var data = await Repository.GetData<TimInfo>(path);
            var deserializedData = JsonConvert.DeserializeObject<List<TimInfo>>(data.Content);

            PrintInformation(deserializedData);

        }

        private void PrintInformation(List<TimInfo> information)
        {
            

            foreach (var item in information)
            {
                if (team.ToString() == item.Country)
                {
                    lblCountry.Content = item.Country;
                    lblFifaCode.Content = item.FifaCode;
                    lblPlayedGames.Content = item.GamesPlayed;
                    lblWin.Content = item.Wins;
                    lblDefeat.Content = item.Losses;
                    lblDraw.Content = item.Draws;
                    lblGoals.Content = item.GoalsFor;
                    lblGoalsConceded.Content = item.GoalsAgainst;
                    lblGoalsDifference.Content = item.GoalDifferential;

                }
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Close();
            
        }

        
    }
}
