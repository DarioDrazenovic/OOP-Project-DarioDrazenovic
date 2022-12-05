
namespace WindowsForms
{
    partial class PlayersUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersUC));
            this.lblName = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblStar = new System.Windows.Forms.Label();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.contextMenuUC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferToPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddPitcure = new System.Windows.Forms.Button();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.contextMenuUC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblNumber
            // 
            resources.ApplyResources(this.lblNumber, "lblNumber");
            this.lblNumber.Name = "lblNumber";
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.Name = "lblPosition";
            // 
            // lblStar
            // 
            resources.ApplyResources(this.lblStar, "lblStar");
            this.lblStar.Name = "lblStar";
            // 
            // lblCaptain
            // 
            resources.ApplyResources(this.lblCaptain, "lblCaptain");
            this.lblCaptain.Name = "lblCaptain";
            // 
            // contextMenuUC
            // 
            this.contextMenuUC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseToolStripMenuItem,
            this.transferToPlayersToolStripMenuItem});
            this.contextMenuUC.Name = "contextMenuUC";
            resources.ApplyResources(this.contextMenuUC, "contextMenuUC");
            // 
            // chooseToolStripMenuItem
            // 
            this.chooseToolStripMenuItem.Name = "chooseToolStripMenuItem";
            resources.ApplyResources(this.chooseToolStripMenuItem, "chooseToolStripMenuItem");
            this.chooseToolStripMenuItem.Click += new System.EventHandler(this.TransferToFavouritePlayerMenuItem_Click);
            // 
            // transferToPlayersToolStripMenuItem
            // 
            this.transferToPlayersToolStripMenuItem.Name = "transferToPlayersToolStripMenuItem";
            resources.ApplyResources(this.transferToPlayersToolStripMenuItem, "transferToPlayersToolStripMenuItem");
            this.transferToPlayersToolStripMenuItem.Click += new System.EventHandler(this.TransferToAllPlayersToolStripMenuItem_Click);
            // 
            // btnAddPitcure
            // 
            this.btnAddPitcure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnAddPitcure, "btnAddPitcure");
            this.btnAddPitcure.Name = "btnAddPitcure";
            this.btnAddPitcure.UseVisualStyleBackColor = false;
            this.btnAddPitcure.Click += new System.EventHandler(this.btnAddPitcure_Click);
            // 
            // pbPlayer
            // 
            resources.ApplyResources(this.pbPlayer, "pbPlayer");
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.TabStop = false;
            // 
            // PlayersUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContextMenuStrip = this.contextMenuUC;
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.btnAddPitcure);
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblStar);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblName);
            this.Name = "PlayersUC";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.contextMenuUC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblStar;
        private System.Windows.Forms.Label lblCaptain;
        private System.Windows.Forms.ContextMenuStrip contextMenuUC;
        private System.Windows.Forms.ToolStripMenuItem chooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferToPlayersToolStripMenuItem;
        private System.Windows.Forms.Button btnAddPitcure;
        private System.Windows.Forms.PictureBox pbPlayer;
    }
}
