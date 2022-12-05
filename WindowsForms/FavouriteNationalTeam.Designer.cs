
namespace WindowsForms
{
    partial class FavouriteNationalTeam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouriteNationalTeam));
            this.label1 = new System.Windows.Forms.Label();
            this.cbFavouriteTeam = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Name = "label1";
            // 
            // cbFavouriteTeam
            // 
            resources.ApplyResources(this.cbFavouriteTeam, "cbFavouriteTeam");
            this.cbFavouriteTeam.DropDownHeight = 250;
            this.cbFavouriteTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFavouriteTeam.FormattingEnabled = true;
            this.cbFavouriteTeam.Name = "cbFavouriteTeam";
            // 
            // btnConfirm
            // 
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.BackColor = System.Drawing.Color.Maroon;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // FavouriteNationalTeam
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsForms.Properties.Resources.MenuMessi;
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbFavouriteTeam);
            this.Controls.Add(this.label1);
            this.Name = "FavouriteNationalTeam";
            this.Load += new System.EventHandler(this.FavouriteNationalTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFavouriteTeam;
        private System.Windows.Forms.Button btnConfirm;
    }
}