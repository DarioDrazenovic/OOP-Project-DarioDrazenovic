using DataLayer;
using DataLayer.Models;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using WindowsForms.Models;

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private static readonly string directory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string fileName = Path.Combine(directory, @"..\..\..\postavke.txt");
        private static readonly string path = Path.GetFullPath(fileName);

        object selectedResolution;

        public Menu()
        {
            InitializeComponent();
            Init();
            ReadFile();

        }

        private void Init()
        {
            cbGender.Items.Add(Spol.muško);
            cbGender.Items.Add(Spol.žensko);
            cbLanguage.Items.Add(JezikEnum.hrvatski);
            cbLanguage.Items.Add(JezikEnum.engleski);
            cbScreen.Items.Add(Rezolucija.small);
            cbScreen.Items.Add(Rezolucija.large);
            cbScreen.Items.Add(Rezolucija.fullscreen);

            cbGender.SelectedIndex = 0;
            cbLanguage.SelectedIndex = 0;
            cbScreen.SelectedIndex = 0;
        }

        private void ReadFile()
        {
            if (File.Exists(path))
            {
                var result = File.ReadAllLines(path);
                var gender= result[0];
                var language = result[1];

                if (gender == Spol.žensko.ToString())
                {
                    cbGender.SelectedItem = Spol.žensko;
                }
                else if (gender == Spol.muško.ToString())
                {
                    cbGender.SelectedItem = Spol.muško;
                }

                if (language == JezikEnum.engleski.ToString())
                {
                    cbLanguage.SelectedItem = JezikEnum.engleski;
                }
                else if (language == JezikEnum.hrvatski.ToString())
                {
                    cbLanguage.SelectedItem = JezikEnum.hrvatski;
                }

            }

        }

        //rezolucija
        private void cbScreen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedResolution = cbScreen.SelectedItem;

            switch (selectedResolution)
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
            Application.Current.MainWindow.Width = width;
            Application.Current.MainWindow.Height = height;
           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var selectedGender = cbGender.SelectedItem;
            var selectedLanguage = cbLanguage.SelectedItem;
            selectedResolution = cbScreen.SelectedItem;
            Repository.WriteInFile(selectedGender, selectedLanguage, path);
            this.Hide();
            FavouriteNationalTeam fnt = new FavouriteNationalTeam(selectedGender, selectedLanguage, selectedResolution);
            fnt.ShowDialog();
            this.Close();
        }

        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedLanguage = cbLanguage.SelectedItem;

            if (selectedLanguage.ToString() == "engleski")
            {
                Repository.SetLanguageCulture("");
            } 
            else {

                Repository.SetLanguageCulture("hr");
                
            }
        }
    }
}
