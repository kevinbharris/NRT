namespace NRT
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            tableMain = new TableLayoutPanel();
            cardQuitDate = new Panel();
            lblQuitDateTitle = new Label();
            dtpQuitDate = new DateTimePicker();
            cardStartup = new Panel();
            lblStartupTitle = new Label();
            chkStartWithWindows = new CheckBox();
            cardExit = new Panel();
            lblExitTitle = new Label();
            chkCloseToTray = new CheckBox();
            chkMinimizeToTray = new CheckBox();
            cardReminder = new Panel();
            lblReminderTitle = new Label();
            chkPlayChewSound = new CheckBox();
            txtChewSoundPath = new TextBox();
            btnBrowseChewSound = new Button();
            chkPlaySpitSound = new CheckBox();
            txtSpitSoundPath = new TextBox();
            btnBrowseSpitSound = new Button();
            pnlButtons = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnOK = new Button();
            btnCancel = new Button();
            ofdAudioFile = new OpenFileDialog();
            tableMain.SuspendLayout();
            cardQuitDate.SuspendLayout();
            cardStartup.SuspendLayout();
            cardExit.SuspendLayout();
            cardReminder.SuspendLayout();
            pnlButtons.SuspendLayout();
            flowButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tableMain
            // 
            tableMain.ColumnCount = 1;
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableMain.Controls.Add(cardQuitDate, 0, 0);
            tableMain.Controls.Add(cardStartup, 0, 1);
            tableMain.Controls.Add(cardExit, 0, 2);
            tableMain.Controls.Add(cardReminder, 0, 3);
            tableMain.Controls.Add(pnlButtons, 0, 4);
            tableMain.Dock = DockStyle.Fill;
            tableMain.Location = new Point(0, 0);
            tableMain.Name = "tableMain";
            tableMain.Padding = new Padding(20);
            tableMain.RowCount = 5;
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableMain.Size = new Size(1208, 611);
            tableMain.TabIndex = 0;
            // 
            // cardQuitDate
            // 
            cardQuitDate.BackColor = Color.White;
            cardQuitDate.BorderStyle = BorderStyle.FixedSingle;
            cardQuitDate.Controls.Add(lblQuitDateTitle);
            cardQuitDate.Controls.Add(dtpQuitDate);
            cardQuitDate.Dock = DockStyle.Fill;
            cardQuitDate.Location = new Point(23, 23);
            cardQuitDate.Name = "cardQuitDate";
            cardQuitDate.Padding = new Padding(16);
            cardQuitDate.Size = new Size(1162, 84);
            cardQuitDate.TabIndex = 0;
            // 
            // lblQuitDateTitle
            // 
            lblQuitDateTitle.AutoSize = true;
            lblQuitDateTitle.Font = new Font("Segoe UI Semibold", 11F);
            lblQuitDateTitle.Location = new Point(16, 14);
            lblQuitDateTitle.Name = "lblQuitDateTitle";
            lblQuitDateTitle.Size = new Size(74, 20);
            lblQuitDateTitle.TabIndex = 0;
            lblQuitDateTitle.Text = "Quit Date";
            // 
            // dtpQuitDate
            // 
            dtpQuitDate.Enabled = false;
            dtpQuitDate.Location = new Point(20, 48);
            dtpQuitDate.Name = "dtpQuitDate";
            dtpQuitDate.Size = new Size(250, 23);
            dtpQuitDate.TabIndex = 1;
            // 
            // cardStartup
            // 
            cardStartup.BackColor = Color.White;
            cardStartup.BorderStyle = BorderStyle.FixedSingle;
            cardStartup.Controls.Add(lblStartupTitle);
            cardStartup.Controls.Add(chkStartWithWindows);
            cardStartup.Dock = DockStyle.Fill;
            cardStartup.Location = new Point(23, 113);
            cardStartup.Name = "cardStartup";
            cardStartup.Padding = new Padding(16);
            cardStartup.Size = new Size(1162, 84);
            cardStartup.TabIndex = 1;
            // 
            // lblStartupTitle
            // 
            lblStartupTitle.AutoSize = true;
            lblStartupTitle.Font = new Font("Segoe UI Semibold", 11F);
            lblStartupTitle.Location = new Point(16, 14);
            lblStartupTitle.Name = "lblStartupTitle";
            lblStartupTitle.Size = new Size(124, 20);
            lblStartupTitle.TabIndex = 0;
            lblStartupTitle.Text = "Startup Behavior";
            // 
            // chkStartWithWindows
            // 
            chkStartWithWindows.Location = new Point(20, 48);
            chkStartWithWindows.Name = "chkStartWithWindows";
            chkStartWithWindows.Size = new Size(350, 24);
            chkStartWithWindows.TabIndex = 1;
            chkStartWithWindows.Text = "Start automatically after I log into Windows";
            chkStartWithWindows.CheckedChanged += chkStartWithWindows_CheckedChanged;
            // 
            // cardExit
            // 
            cardExit.BackColor = Color.White;
            cardExit.BorderStyle = BorderStyle.FixedSingle;
            cardExit.Controls.Add(lblExitTitle);
            cardExit.Controls.Add(chkCloseToTray);
            cardExit.Controls.Add(chkMinimizeToTray);
            cardExit.Dock = DockStyle.Fill;
            cardExit.Location = new Point(23, 203);
            cardExit.Name = "cardExit";
            cardExit.Padding = new Padding(16);
            cardExit.Size = new Size(1162, 114);
            cardExit.TabIndex = 2;
            // 
            // lblExitTitle
            // 
            lblExitTitle.AutoSize = true;
            lblExitTitle.Font = new Font("Segoe UI Semibold", 11F);
            lblExitTitle.Location = new Point(16, 14);
            lblExitTitle.Name = "lblExitTitle";
            lblExitTitle.Size = new Size(99, 20);
            lblExitTitle.TabIndex = 0;
            lblExitTitle.Text = "Exit Behavior";
            // 
            // chkCloseToTray
            // 
            chkCloseToTray.Location = new Point(20, 48);
            chkCloseToTray.Name = "chkCloseToTray";
            chkCloseToTray.Size = new Size(380, 24);
            chkCloseToTray.TabIndex = 1;
            chkCloseToTray.Text = "Close to system tray instead of exiting";
            // 
            // chkMinimizeToTray
            // 
            chkMinimizeToTray.Location = new Point(20, 76);
            chkMinimizeToTray.Name = "chkMinimizeToTray";
            chkMinimizeToTray.Size = new Size(380, 24);
            chkMinimizeToTray.TabIndex = 2;
            chkMinimizeToTray.Text = "Minimize to system tray";
            // 
            // cardReminder
            // 
            cardReminder.BackColor = Color.White;
            cardReminder.BorderStyle = BorderStyle.FixedSingle;
            cardReminder.Controls.Add(lblReminderTitle);
            cardReminder.Controls.Add(chkPlayChewSound);
            cardReminder.Controls.Add(txtChewSoundPath);
            cardReminder.Controls.Add(btnBrowseChewSound);
            cardReminder.Controls.Add(chkPlaySpitSound);
            cardReminder.Controls.Add(txtSpitSoundPath);
            cardReminder.Controls.Add(btnBrowseSpitSound);
            cardReminder.Dock = DockStyle.Fill;
            cardReminder.Location = new Point(23, 323);
            cardReminder.Name = "cardReminder";
            cardReminder.Padding = new Padding(16);
            cardReminder.Size = new Size(1162, 194);
            cardReminder.TabIndex = 3;
            // 
            // lblReminderTitle
            // 
            lblReminderTitle.AutoSize = true;
            lblReminderTitle.Font = new Font("Segoe UI Semibold", 11F);
            lblReminderTitle.Location = new Point(16, 14);
            lblReminderTitle.Name = "lblReminderTitle";
            lblReminderTitle.Size = new Size(117, 20);
            lblReminderTitle.TabIndex = 0;
            lblReminderTitle.Text = "Gum Reminders";
            // 
            // chkPlayChewSound
            // 
            chkPlayChewSound.Location = new Point(20, 48);
            chkPlayChewSound.Name = "chkPlayChewSound";
            chkPlayChewSound.Size = new Size(420, 24);
            chkPlayChewSound.TabIndex = 1;
            chkPlayChewSound.Text = "Play a sound when it's time to chew a new piece";
            chkPlayChewSound.CheckedChanged += chkPlayChewSound_CheckedChanged;
            // 
            // txtChewSoundPath
            // 
            txtChewSoundPath.Location = new Point(20, 78);
            txtChewSoundPath.Name = "txtChewSoundPath";
            txtChewSoundPath.Size = new Size(520, 23);
            txtChewSoundPath.TabIndex = 2;
            txtChewSoundPath.TextChanged += txtChewSoundPath_TextChanged;
            // 
            // btnBrowseChewSound
            // 
            btnBrowseChewSound.Location = new Point(550, 76);
            btnBrowseChewSound.Name = "btnBrowseChewSound";
            btnBrowseChewSound.Size = new Size(75, 27);
            btnBrowseChewSound.TabIndex = 3;
            btnBrowseChewSound.Text = "Browse";
            btnBrowseChewSound.Click += btnBrowseChewSound_Click;
            // 
            // chkPlaySpitSound
            // 
            chkPlaySpitSound.Location = new Point(20, 118);
            chkPlaySpitSound.Name = "chkPlaySpitSound";
            chkPlaySpitSound.Size = new Size(420, 24);
            chkPlaySpitSound.TabIndex = 4;
            chkPlaySpitSound.Text = "Play a sound when it's time to spit out the gum";
            chkPlaySpitSound.CheckedChanged += chkPlaySpitSound_CheckedChanged;
            // 
            // txtSpitSoundPath
            // 
            txtSpitSoundPath.Location = new Point(20, 148);
            txtSpitSoundPath.Name = "txtSpitSoundPath";
            txtSpitSoundPath.Size = new Size(520, 23);
            txtSpitSoundPath.TabIndex = 5;
            txtSpitSoundPath.TextChanged += txtSpitSoundPath_TextChanged;
            // 
            // btnBrowseSpitSound
            // 
            btnBrowseSpitSound.Location = new Point(550, 146);
            btnBrowseSpitSound.Name = "btnBrowseSpitSound";
            btnBrowseSpitSound.Size = new Size(75, 27);
            btnBrowseSpitSound.TabIndex = 6;
            btnBrowseSpitSound.Text = "Browse";
            btnBrowseSpitSound.Click += btnBrowseSpitSound_Click;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(flowButtons);
            pnlButtons.Dock = DockStyle.Fill;
            pnlButtons.Location = new Point(23, 523);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(0, 12, 0, 0);
            pnlButtons.Size = new Size(1162, 65);
            pnlButtons.TabIndex = 4;
            // 
            // flowButtons
            // 
            flowButtons.Controls.Add(btnOK);
            flowButtons.Controls.Add(btnCancel);
            flowButtons.Dock = DockStyle.Right;
            flowButtons.FlowDirection = FlowDirection.RightToLeft;
            flowButtons.Location = new Point(962, 12);
            flowButtons.Name = "flowButtons";
            flowButtons.Size = new Size(200, 53);
            flowButtons.TabIndex = 0;
            flowButtons.WrapContents = false;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(33, 150, 83);
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI Semibold", 10F);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(97, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 36);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(-9, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 36);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1208, 611);
            Controls.Add(tableMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmSettings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            FormClosing += frmSettings_FormClosing;
            Load += frmSettings_Load;
            tableMain.ResumeLayout(false);
            cardQuitDate.ResumeLayout(false);
            cardQuitDate.PerformLayout();
            cardStartup.ResumeLayout(false);
            cardStartup.PerformLayout();
            cardExit.ResumeLayout(false);
            cardExit.PerformLayout();
            cardReminder.ResumeLayout(false);
            cardReminder.PerformLayout();
            pnlButtons.ResumeLayout(false);
            flowButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableMain;

        private Panel cardQuitDate;
        private Label lblQuitDateTitle;
        private DateTimePicker dtpQuitDate;

        private Panel cardStartup;
        private Label lblStartupTitle;
        private CheckBox chkStartWithWindows;

        private Panel cardExit;
        private Label lblExitTitle;
        private CheckBox chkCloseToTray;
        private CheckBox chkMinimizeToTray;

        private Panel cardReminder;
        private Label lblReminderTitle;
        private CheckBox chkPlayChewSound;
        private TextBox txtChewSoundPath;
        private Button btnBrowseChewSound;
        private CheckBox chkPlaySpitSound;
        private TextBox txtSpitSoundPath;
        private Button btnBrowseSpitSound;

        private Panel pnlButtons;
        private FlowLayoutPanel flowButtons;
        private Button btnOK;
        private Button btnCancel;

        private OpenFileDialog ofdAudioFile;
    }
}