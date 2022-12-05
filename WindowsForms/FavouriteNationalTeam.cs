using DataLayer;
using Newtonsoft.Json;
using RestSharp;
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
    public partial class FavouriteNationalTeam : Form
    {
        private const string Path_woman = "http://worldcup.sfg.io/teams/";
        private const string Path_man = "http://world-cup-json-2018.herokuapp.com/teams";
        private const string ENGLISH = "en";
        private const string CROATIAN = "hr";
        private static readonly string directory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string fileName = Path.Combine(directory, @"..\..\..\najdraziTim.txt");
        private static readonly string path = Path.GetFullPath(fileName);

        //za json
        private static readonly string fileNameTeamWomen = Path.Combine(directory, @"..\..\..\worldcup.sfg.io\women\teams.json");
        private static readonly string pathTeamWomen = Path.GetFullPath(fileNameTeamWomen);
        
        private static readonly string fileNameTeamMen = Path.Combine(directory, @"..\..\..\worldcup.sfg.io\men\teams.json");
        private static readonly string pathTeamMen = Path.GetFullPath(fileNameTeamMen);

        private static readonly string konfiguracijska = Path.Combine(directory, @"..\..\..\konfiguracijskaDatoteka.txt");
        private static readonly string pathKonfiguracijska = Path.GetFullPath(konfiguracijska);


        private Object gender;
        private Object language;

        public FavouriteNationalTeam(Object gender, Object language)
        {
            InitializeComponent();
            this.gender = gender;
            this.language = language;
            ReadFile();
            
        }

        private void FavouriteNationalTeam_Load(object sender, EventArgs e)
        {
            SetLanguage();
            //ovo ce napuniti podatcima cbfavouriteteam
            FillCbFteamWithData();
        }

        private void SetLanguage()
        {
            if (language.ToString() == "engleski")
            {
                Repository.SetLanguageCulture(ENGLISH);
            }
            else
            {
                Repository.SetLanguageCulture(CROATIAN);
            }
            this.Controls.Clear();
            InitializeComponent();
        }

        private void ReadFile()
        {

            try
            {
                if (File.Exists(path))
                {
                    var result = File.ReadAllLines(path);
                    this.Close();
                    FavouritePlayers fPlayers = new FavouritePlayers(result[0], gender, language);
                    fPlayers.ShowDialog();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        private async void FillCbFteamWithData()
        {
            try
            {

                if (gender.ToString() == "muško")
                {
                    if (Repository.ReadConfig(konfiguracijska) == "link")
                    {
                        await GetResults(Path_man); 
                    }
                    else if(Repository.ReadConfig(konfiguracijska) == "datoteka")
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

        
        //pomocu ovog dohvacamo podatke iz datoteke
        private void GetResultsFromFile(string path)
        {
            var listTeams = Repository.ReadJsonData<Tim>(path);

            AddDataToCombo(listTeams);
        }

        private void AddDataToCombo(List<Tim> listTeams)
        {
            foreach (var item in listTeams)
            {
                cbFavouriteTeam.Items.Add(item);
            }

            cbFavouriteTeam.SelectedIndex = 0;
        }

        private async Task GetResults(string path)
        {
            //podatci u obliku jsona stizu tu
            var data = await Repository.GetData<Tim>(path); 
            var deserializedData = JsonConvert.DeserializeObject<List<Tim>>(data.Content);

            AddDataToCombo(deserializedData);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var fTeam = cbFavouriteTeam.SelectedItem;
            Repository.WriteInFileFTeam(fTeam, path);
            this.Hide();
            this.Close();
            FavouritePlayers fPlayers = new FavouritePlayers(fTeam,gender,language);
            fPlayers.ShowDialog();
        }
    }
}
