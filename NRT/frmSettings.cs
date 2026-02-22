using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace NRT
{
    public partial class frmSettings : Form
    {
        private DateTime _QuitDate;
        private Boolean _StartWithWindows, _CloseToTray, _MinimizeToTray;
        private System.IO.FileInfo? _ChewSoundFile, _SpitSoundFile;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]

        /// <summary>
        /// Should the app start with windows?
        /// </summary>
        public Boolean StartWithWindows
        {
            get
            {
                return _StartWithWindows;
            }
            set
            {
                _StartWithWindows = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]

        /// <summary>
        /// Should the app close to the system tray?
        /// </summary>
        public Boolean CloseToTray
        {
            get
            {
                return _CloseToTray;
            }
            set
            {
                _CloseToTray = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]

        /// <summary>
        /// Should the app minimize to the system tray?
        /// </summary>
        public Boolean MinimizeToTray
        {
            get
            {
                return _MinimizeToTray;
            }
            set
            {
                _MinimizeToTray = value;
            }
        }

        /// <summary>
        /// Should the app play a sound when its time to spit out a piece of gum?
        /// </summary>
        public Boolean PlaySpitSound
        {
            get
            {
                return SpitSoundFile != null;
            }
        }

        /// <summary>
        /// Should the app play a sound when its time to chew a new piece of gum?
        /// </summary>
        public Boolean PlayChewSound
        {
            get
            {
                return ChewSoundFile != null;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]

        /// <summary>
        /// What *.mp3 file should be played when it is time to spit out a piece of gum?
        /// </summary>

        public System.IO.FileInfo? SpitSoundFile
        {
            get
            {
                return _SpitSoundFile;
            }
            set
            {
                _SpitSoundFile = value;
            }

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]

        /// <summary>
        /// What *.mp3 file should be played when it is time to chew a new piece of gum?
        /// </summary>
        public System.IO.FileInfo? ChewSoundFile
        {
            get
            {
                return _ChewSoundFile;
            }
            set
            {
                _ChewSoundFile = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]

        /// <summary>
        /// What *.mp3 file should be played when it is time to chew a new piece of gum?
        /// </summary>
        public DateTime QuitDate
        {
            get
            {
                return _QuitDate;
            }
        }

        private const string RegistryPath = @"Software\kbhtech\NRT";
        private const string RunKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string AppName = "NRT (Nicotine Replacement Therapy)";
        private static readonly DateTime DefaultQuitDate = new DateTime(2025, 11, 25, 0, 0, 0, DateTimeKind.Local);


        private void frmSettings_Load(object sender, EventArgs e)
        {
           
            chkStartWithWindows.Checked = StartWithWindows;
            chkCloseToTray.Checked = CloseToTray;
            chkMinimizeToTray.Checked = MinimizeToTray;
            chkPlayChewSound.Checked = PlayChewSound;
            chkPlaySpitSound.Checked = PlaySpitSound;

            if (PlayChewSound == true)
                txtChewSoundPath.Text = ChewSoundFile.FullName;

            if (PlaySpitSound == true)
                txtSpitSoundPath.Text = SpitSoundFile.FullName;

            txtChewSoundPath.Enabled = PlayChewSound;
            btnBrowseChewSound.Enabled = PlayChewSound;
            txtSpitSoundPath.Enabled = PlaySpitSound;
            btnBrowseSpitSound.Enabled = PlaySpitSound;

            dtpQuitDate.Value = QuitDate;
            dtpQuitDate.Enabled = false;
        }

        private frmSettings() => this.InitializeComponent();

        /// <summary>
        /// Initialize with these fields already set.
        /// </summary>
        /// <param name="QuitDate">The day you stopped smoking.</param>
        /// <param name="StartWithWindows">Should the tracker start with Windows?</param>
        /// <param name="CloseToTray">Should the tracker close to the System Tray?</param>
        /// <param name="MinimizeToTray">Should the tracker minimize to the System Tray?</param>
        public frmSettings(DateTime QuitDate, bool StartWithWindows, bool CloseToTray, bool MinimizeToTray) : this()
        {
            this._QuitDate = QuitDate;
            this._StartWithWindows = StartWithWindows;
            this._CloseToTray = CloseToTray;
            this._MinimizeToTray = MinimizeToTray;
        }

        /// <summary>
        /// Initialize with these fields already set.
        /// </summary>
        /// <param name="QuitDate">The day you stopped smoking.</param>
        /// <param name="StartWithWindows">Should the tracker start with Windows?</param>
        /// <param name="CloseToTray">Should the tracker close to the System Tray?</param>
        /// <param name="MinimizeToTray">Should the tracker minimize to the System Tray?</param>
        /// <param name="ChewSoundFile">What is the sound to play when its time to start chewing a piece of gum?</param>
        /// <param name="SpitSoundFile">What is the sound to play when its time top spit out a piece of gum?</param>
        public frmSettings(DateTime QuitDate, bool StartWithWindows, bool CloseToTray, bool MinimizeToTray, System.IO.FileInfo? ChewSoundFile, System.IO.FileInfo? SpitSoundFile) : this(QuitDate, StartWithWindows, CloseToTray, MinimizeToTray)
        {
            this._ChewSoundFile = ChewSoundFile;
            this._SpitSoundFile = SpitSoundFile;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            // Push UI values into backing fields first
            _StartWithWindows = chkStartWithWindows.Checked;
            _CloseToTray = chkCloseToTray.Checked;
            _MinimizeToTray = chkMinimizeToTray.Checked;

            if (System.IO.File.Exists(txtChewSoundPath.Text))
                _ChewSoundFile = new FileInfo(txtChewSoundPath.Text);
            else
                _ChewSoundFile = null;

            if (System.IO.File.Exists(txtSpitSoundPath.Text))
                _SpitSoundFile = new FileInfo(txtSpitSoundPath.Text);
            else
                _SpitSoundFile = null;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnBrowseChewSound_Click(object sender, EventArgs e)
        {
            if (ofdAudioFile.ShowDialog() == DialogResult.OK)
                txtChewSoundPath.Text = ofdAudioFile.FileName;
        }

        private void btnBrowseSpitSound_Click(object sender, EventArgs e)
        {
            if (ofdAudioFile.ShowDialog() == DialogResult.OK)
                txtSpitSoundPath.Text = ofdAudioFile.FileName;
        }

        private void chkPlayChewSound_CheckedChanged(object sender, EventArgs e)
        {
            switch (chkPlayChewSound.Checked)
            {
                case false:
                    txtChewSoundPath.Text = "";
                    break;
            }

            txtChewSoundPath.Enabled = chkPlayChewSound.Checked;
            btnBrowseChewSound.Enabled = chkPlayChewSound.Checked;

        }

        private void chkPlaySpitSound_CheckedChanged(object sender, EventArgs e)
        {
            switch (chkPlaySpitSound.Checked)
            {
                case false:
                    txtSpitSoundPath.Text = "";
                    break;
            }

            txtSpitSoundPath.Enabled = chkPlaySpitSound.Checked;
            btnBrowseSpitSound.Enabled = chkPlaySpitSound.Checked;
        }

        private void chkStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            _StartWithWindows = chkStartWithWindows.Checked;
        }

        private void txtChewSoundPath_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(txtChewSoundPath.Text))
                ChewSoundFile = new FileInfo(txtChewSoundPath.Text);
        }

        private void txtSpitSoundPath_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(txtSpitSoundPath.Text))
                SpitSoundFile = new FileInfo(txtSpitSoundPath.Text);
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
 
        }
    }
}
