
namespace WindowsForms
{
    partial class FavouritePlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouritePlayers));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Name = "label2";
            // 
            // pnlPlayers
            // 
            resources.ApplyResources(this.pnlPlayers, "pnlPlayers");
            this.pnlPlayers.AllowDrop = true;
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragDropPlayers);
            this.pnlPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragEnterPlayers);
            // 
            // pnlFPlayers
            // 
            resources.ApplyResources(this.pnlFPlayers, "pnlFPlayers");
            this.pnlFPlayers.AllowDrop = true;
            this.pnlFPlayers.Name = "pnlFPlayers";
            this.pnlFPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragDropFavouritePlayers);
            this.pnlFPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragEnterFavouritePlayers);
            // 
            // btnPotvrdi
            // 
            resources.ApplyResources(this.btnPotvrdi, "btnPotvrdi");
            this.btnPotvrdi.BackColor = System.Drawing.Color.Maroon;
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = false;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // FavouritePlayers
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsForms.Properties.Resources.MenuMessi;
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.pnlFPlayers);
            this.Controls.Add(this.pnlPlayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FavouritePlayers";
            this.Load += new System.EventHandler(this.FavouritePlayers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel pnlPlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlFPlayers;
        private System.Windows.Forms.Button btnPotvrdi;
    }
}