namespace NRT
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            timerMain = new System.Windows.Forms.Timer(components);
            menuMain = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            menuExit = new ToolStripMenuItem();
            menuEdit = new ToolStripMenuItem();
            menuLastDoseDetails = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            statusMain = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            pnlCard = new Panel();
            lblStats = new Label();
            lblCardTitle = new Label();
            btnChewNewPiece = new Button();
            notifyIcon1 = new NotifyIcon(components);
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            menuMain.SuspendLayout();
            statusMain.SuspendLayout();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // timerMain
            // 
            timerMain.Enabled = true;
            timerMain.Interval = 1000;
            timerMain.Tick += timer1_Tick;
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { menuFile, menuEdit, helpToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(520, 24);
            menuMain.TabIndex = 3;
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuExit });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(37, 20);
            menuFile.Text = "&File";
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.Size = new Size(92, 22);
            menuExit.Text = "E&xit";
            menuExit.Click += exitToolStripMenuItem_Click;
            // 
            // menuEdit
            // 
            menuEdit.DropDownItems.AddRange(new ToolStripItem[] { menuLastDoseDetails, settingsToolStripMenuItem });
            menuEdit.Name = "menuEdit";
            menuEdit.Size = new Size(39, 20);
            menuEdit.Text = "&Edit";
            // 
            // menuLastDoseDetails
            // 
            menuLastDoseDetails.Name = "menuLastDoseDetails";
            menuLastDoseDetails.Size = new Size(180, 22);
            menuLastDoseDetails.Text = "Last Dose Details";
            menuLastDoseDetails.Click += lastDoseDetailsToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(180, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // statusMain
            // 
            statusMain.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusMain.Location = new Point(0, 336);
            statusMain.Name = "statusMain";
            statusMain.Size = new Size(520, 22);
            statusMain.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(86, 17);
            lblStatus.Text = "Status: Waiting";
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCard.Controls.Add(lblStats);
            pnlCard.Controls.Add(lblCardTitle);
            pnlCard.Location = new Point(20, 48);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(480, 170);
            pnlCard.TabIndex = 1;
            // 
            // lblStats
            // 
            lblStats.Font = new Font("Segoe UI", 10F);
            lblStats.ForeColor = Color.FromArgb(64, 64, 64);
            lblStats.Location = new Point(16, 48);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(440, 100);
            lblStats.TabIndex = 0;
            lblStats.Text = "—";
            // 
            // lblCardTitle
            // 
            lblCardTitle.AutoSize = true;
            lblCardTitle.Font = new Font("Segoe UI Semibold", 11F);
            lblCardTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblCardTitle.Location = new Point(16, 14);
            lblCardTitle.Name = "lblCardTitle";
            lblCardTitle.Size = new Size(124, 20);
            lblCardTitle.TabIndex = 1;
            lblCardTitle.Text = "Current Progress";
            // 
            // btnChewNewPiece
            // 
            btnChewNewPiece.BackColor = Color.FromArgb(33, 150, 83);
            btnChewNewPiece.Enabled = false;
            btnChewNewPiece.FlatAppearance.BorderSize = 0;
            btnChewNewPiece.FlatStyle = FlatStyle.Flat;
            btnChewNewPiece.Font = new Font("Segoe UI Semibold", 14F);
            btnChewNewPiece.ForeColor = Color.White;
            btnChewNewPiece.Location = new Point(20, 232);
            btnChewNewPiece.Name = "btnChewNewPiece";
            btnChewNewPiece.Size = new Size(480, 64);
            btnChewNewPiece.TabIndex = 0;
            btnChewNewPiece.Text = "Chew New Piece";
            btnChewNewPiece.UseVisualStyleBackColor = false;
            btnChewNewPiece.Visible = false;
            btnChewNewPiece.Click += btnChewNewPiece_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "NRT Tracker";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(180, 22);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(520, 358);
            Controls.Add(btnChewNewPiece);
            Controls.Add(pnlCard);
            Controls.Add(statusMain);
            Controls.Add(menuMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuMain;
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NRT Tracker";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            Resize += frmMain_Resize;
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            statusMain.ResumeLayout(false);
            statusMain.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timerMain;

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuLastDoseDetails;

        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label lblStats;

        private System.Windows.Forms.Button btnChewNewPiece;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}
