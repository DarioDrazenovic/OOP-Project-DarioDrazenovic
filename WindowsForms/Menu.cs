using DataLayer;
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
    public partial class Menu : Form
    {
        private static readonly string directory = AppDomain.CurrentDomain.BaseDirectory; 
        private static readonly string fileName = Path.Combine(directory, @"..\..\..\postavke.txt"); 
        private static readonly string path = Path.GetFullPath(fileName);

        public Menu()
        {
            InitializeComponent();
            ReadFile();
            Init();
        }

        private void ReadFile()
        {
            if (File.Exists(path))
            {
                var result=File.ReadAllLines(path);
                this.Close();
                FavouriteNationalTeam fnt = new FavouriteNationalTeam(result[0], result[1]);
                fnt.ShowDialog();
                
            }
           
        }

       
        private void Init()
        {
            cbGender.Items.Add(Spol.muško);
            cbGender.Items.Add(Spol.žensko);
            cbLanguge.Items.Add(JezikEnum.hrvatski);
            cbLanguge.Items.Add(JezikEnum.engleski);

            cbGender.SelectedIndex = 0;
            cbLanguge.SelectedIndex = 1;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var selectedGender = cbGender.SelectedItem;
            var selectedLanguage = cbLanguge.SelectedItem;
            Repository.WriteInFile(selectedGender, selectedLanguage, path);
            this.Hide();
            FavouriteNationalTeam fnt = new FavouriteNationalTeam(selectedGender, selectedLanguage);
            fnt.ShowDialog();
            this.Close();
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbLanguge_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
