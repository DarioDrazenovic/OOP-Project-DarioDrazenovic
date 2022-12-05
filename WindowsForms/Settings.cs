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
    public partial class Settings : Form
    {


        private static readonly string directory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string fileNamePostavke = Path.Combine(directory, @"..\..\..\postavke.txt");
        private static readonly string pathPostavke = Path.GetFullPath(fileNamePostavke);

        private static readonly string fileNameNajdraziTim = Path.Combine(directory, @"..\..\..\najdraziTim.txt");
        private static readonly string pathNajdraziTim = Path.GetFullPath(fileNameNajdraziTim);


        private Object gender;
        private Object language;
        public Settings(Object gender, Object language)
        {
            InitializeComponent();
            this.gender = gender;
            this.language = language;
            Init();

        }

        private void Init()
        {
            cbGender.Items.Add(Spol.muško);
            cbGender.Items.Add(Spol.žensko);
            cbLanguge.Items.Add(JezikEnum.hrvatski);
            cbLanguge.Items.Add(JezikEnum.engleski);

            cbGender.SelectedIndex = 0;
            cbLanguge.SelectedIndex = 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Jeste li sigurni?", "Upozorenje", MessageBoxButtons.OKCancel);

            if (dialog == DialogResult.OK)
            {
                var selectedGender = cbGender.SelectedItem;
                var selectedLanguage = cbLanguge.SelectedItem;
                Repository.WriteInFile(selectedGender, selectedLanguage, pathPostavke);
                if (File.Exists(pathNajdraziTim))
                {
                    File.Delete(pathNajdraziTim);
                }
                this.Hide();
                FavouriteNationalTeam fnt = new FavouriteNationalTeam(selectedGender, selectedLanguage);
                fnt.ShowDialog(); 
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
