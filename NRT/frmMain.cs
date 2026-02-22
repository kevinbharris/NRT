using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace NRT
{
    public partial class frmMain : Form
    {
        private frmAdjust frmAdjust;

        private bool _startWithWindows;
        private bool _closeToTray;
        private bool _minimizeToTray;

        private FileInfo? _chewSoundFile;
        private FileInfo? _spitSoundFile;

        private DateTime _quitDate;
        private DateTime _stoppedChewingLastPieceOfGum;
        private DateTime _startedChewingLastPieceOfGum;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFileReader;

        private const string RegistryPath = @"SOFTWARE\kbhtech\NRT";

        private enum Stat { Ready, Chewing, Waiting }
        private Stat Status;

        private bool gumSpitAlertShown;
        private bool gumChewAlertShown;

        public frmMain()
        {
            InitializeComponent();

            Status = Stat.Waiting;
        }

        #region Registry Helpers

        private static bool TryReadValue<T>(string name, out T value)
        {
            value = default!;
            using var hive = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            using var settings = hive.OpenSubKey(RegistryPath, writable: false);
            if (settings?.GetValue(name) is T val)
            {
                value = val;
                return true;
            }
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]
        public bool StartWithWindows
        {
            get => _startWithWindows;
            set
            {
                if (_startWithWindows == value) return;
                _startWithWindows = value;
                WriteStartWithWindows(value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]
        public bool CloseToTray
        {
            get => _closeToTray;
            set
            {
                if (_closeToTray == value) return;
                _closeToTray = value;
                WriteBoolean("CloseToTray", value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]
        public bool MinimizeToTray
        {
            get => _minimizeToTray;
            set
            {
                if (_minimizeToTray == value) return;
                _minimizeToTray = value;
                WriteBoolean("MinimizeToTray", value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]
        public FileInfo? ChewSoundFile
        {
            get => _chewSoundFile;
            set
            {
                _chewSoundFile = value;

                if (value == null)
                    DeleteValue("ChewSoundFile");
                else
                    WriteFileInfo("ChewSoundFile", value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]
        public FileInfo? SpitSoundFile
        {
            get => _spitSoundFile;
            set
            {
                _spitSoundFile = value;

                if (value == null)
                    DeleteValue("SpitSoundFile");
                else
                    WriteFileInfo("SpitSoundFile", value);
            }
        }

        public bool PlayChewSoundFile => this.ChewSoundFile != null;

        public bool PlaySpitSoundFile => this.SpitSoundFile != null;

        private static bool TryReadTicks(string name, out DateTime value)
        {
            value = default;
            if (TryReadValue<long>(name, out long ticks) &&
                ticks >= DateTime.MinValue.Ticks &&
                ticks <= DateTime.MaxValue.Ticks)
            {
                value = new DateTime(ticks, DateTimeKind.Local);
                return true;
            }
            return false;
        }

        private static bool TryReadEnum<T>(string name, out T value) where T : struct
        {
            value = default;
            if (TryReadValue<string>(name, out string text))
            {
                return Enum.TryParse(text, true, out value);
            }
            return false;
        }

        private static bool TryReadString(string name, out string value)
        {
            value = string.Empty;
            if (TryReadValue<object>(name, out object raw) && raw != null)
            {
                value = raw.ToString() ?? string.Empty;
                return true;
            }
            return false;
        }

        private static bool TryReadFileInfo(string name, out FileInfo? value)
        {
            value = null!;

            if (TryReadString(name, out string path) && !string.IsNullOrWhiteSpace(path))
            {
                value = new FileInfo(path);
                return true;
            }

            return false;
        }

        private static bool TryReadBoolean(string name, out bool value)
        {
            value = false;
            if (TryReadValue<int>(name, out int intValue))
            {
                value = intValue != 0;
                return true;
            }
            return false;
        }

        public static bool TryReadStartWithWindows(out bool value)
        {
            value = false;

            using var hive = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            using var key = hive.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");

            if (key == null)
                return false; // true read failure

            value = key.GetValue("NRT") != null;
            return true; // read succeeded, value reflects enabled/disabled
        }

        private static void WriteTicks(string name, DateTime value)
        {
            using var hive = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            using var settings = hive.CreateSubKey(RegistryPath, writable: true) ?? throw new InvalidOperationException("Failed to open registry key.");
            settings.SetValue(name, value.Ticks, RegistryValueKind.QWord);
        }

        private static void WriteStatus(Stat status)
        {
            using var hive = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            using var settings = hive.CreateSubKey(RegistryPath, writable: true);
            settings.SetValue("Status", status.ToString(), RegistryValueKind.String);
        }

        private static void WriteBoolean(string name, bool value)
        {
            using var hive = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            using var settings = hive.CreateSubKey(RegistryPath, writable: true);
            settings.SetValue(name, value ? 1 : 0, RegistryValueKind.DWord);
        }

        public void WriteStartWithWindows(bool enable)
        {
            using var hive = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);

            if (enable)
            {
                using var key = hive.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", writable: true) ?? hive.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                key.SetValue("NRT", $"\"{Application.ExecutablePath}\"");
            }
            else
            {
                using var key = hive.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", writable: true);
                key?.DeleteValue("NRT", false);
            }
        }

        private static void WriteFileInfo(string name, FileInfo file)
        {
            if (file == null)
                return;

            using var hive = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            using var settings = hive.CreateSubKey(RegistryPath, writable: true);

            settings.SetValue(name, file.FullName, RegistryValueKind.String);
        }

        private static void DeleteValue(string name)
        {
            using var hive = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            using var settings = hive.OpenSubKey(RegistryPath, writable: true);

            settings?.DeleteValue(name, false);
        }

        #endregion

        #region Status Handling

        private void SetStatus(Stat newStatus)
        {
            if (Status == newStatus) return;
            Status = newStatus;
            WriteStatus(newStatus);
            UpdateUIForStatus();
        }

        private void UpdateUIForStatus()
        {
            switch (Status)
            {
                case Stat.Chewing:
                    btnChewNewPiece.Visible = btnChewNewPiece.Enabled = false;
                    lblStatus.Text = "Status: Chewing";
                    break;
                case Stat.Waiting:
                    btnChewNewPiece.Visible = btnChewNewPiece.Enabled = false;
                    lblStatus.Text = "Status: Waiting";
                    break;
                case Stat.Ready:
                    btnChewNewPiece.Visible = btnChewNewPiece.Enabled = true;
                    btnChewNewPiece.BackColor = Color.MediumSeaGreen;
                    btnChewNewPiece.Text = "Chew New Piece of Gum";
                    lblStatus.Text = "Status: Ready";
                    break;
            }
        }

        #endregion

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]
        public DateTime QuitDate
        {
            get => _quitDate;
            set
            {
                _quitDate = value;
                WriteTicks("QuitDateTicks", value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DateTime StoppedChewingLastPieceOfGum
        {
            get => _stoppedChewingLastPieceOfGum;
            set
            {
                _stoppedChewingLastPieceOfGum = value;
                WriteTicks("StoppedChewingLastPieceOfGumTicks", value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DateTime StartedChewingLastPieceOfGum
        {
            get => _startedChewingLastPieceOfGum;
            set
            {
                _startedChewingLastPieceOfGum = value;
                WriteTicks("StartedChewingLastPieceOfGumTicks", value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]
        public int Week => Math.Max(0, (DateTime.Now - QuitDate).Days / 7) + 1;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]
        public int HoursSinceLastGum => (int)Math.Max(0, (DateTime.Now - StoppedChewingLastPieceOfGum).TotalHours);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]
        public int TimeChewingPieceOfGum => (int)Math.Max(0, (DateTime.Now - StartedChewingLastPieceOfGum).TotalMinutes);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ReadOnly(true)]
        public int Stage => Week <= 6 ? 1 : Week <= 9 ? 2 : Week <= 12 ? 3 : 4;

        public int HoursBetweenPieces => Stage <= 1 ? 1 : Stage <= 2 ? 2 : Stage <= 3 ? 4 : 0;

        #endregion

        #region Timer Tick

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Status)
            {
                case Stat.Chewing:
                    if (TimeChewingPieceOfGum >= 30 && !gumSpitAlertShown)
                    {
                        gumSpitAlertShown = true;

                        // Play spit sound
                        PlaySound(_spitSoundFile);

                        MessageBox.Show("It's time to spit out the gum.", "Nicotine Replacement Therapy",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        StopCurrentSound();

                        StoppedChewingLastPieceOfGum = DateTime.Now;
                        SetStatus(Stat.Waiting);
                    }
                    break;

                case Stat.Waiting:
                    if (HoursBetweenPieces > 0 && HoursSinceLastGum >= HoursBetweenPieces && !gumChewAlertShown)
                    {
                        gumChewAlertShown = true;

                        // Play chew sound
                        PlaySound(_chewSoundFile);

                        SetStatus(Stat.Ready);
                    }
                    break;
            }

            UpdateStatsLabel();
        }

        private void PlaySound(FileInfo? file)
        {
            if (file == null || !file.Exists)
                return;

            try
            {
                StopCurrentSound();
                audioFileReader = new AudioFileReader(file.FullName);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFileReader);
                outputDevice.Play();
            }
            catch
            {
                StopCurrentSound();
            }
        }

        private void StopCurrentSound()
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
            outputDevice = null;

            audioFileReader?.Dispose();
            audioFileReader = null;
        }

        private void UpdateStatsLabel()
        {
            DateTime nextAllowed = StoppedChewingLastPieceOfGum.AddHours(HoursBetweenPieces);
            TimeSpan remaining = nextAllowed > DateTime.Now ? nextAllowed - DateTime.Now : TimeSpan.Zero;

            lblStats.Text =
                $"Week: {Week}\n" +
                $"Stage: {Stage}\n" +
                $"Last Piece of Gum: {StartedChewingLastPieceOfGum:G}\n" +
                $"Time Until Next Piece of Gum: {remaining:hh\\:mm\\:ss}";
        }

        #endregion

        #region UI Actions

        private void btnChewNewPiece_Click(object sender, EventArgs e)
        {
            gumChewAlertShown = false;
            gumSpitAlertShown = false;

            StopCurrentSound();
            StartedChewingLastPieceOfGum = DateTime.Now;
            SetStatus(Stat.Chewing);
        }

        private void lastDoseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAdjust == null || frmAdjust.IsDisposed)
                frmAdjust = new frmAdjust();

            frmAdjust.Show();
            frmAdjust.BringToFront();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmSettings Settings = new frmSettings(QuitDate, StartWithWindows, CloseToTray, MinimizeToTray, ChewSoundFile, SpitSoundFile))
            {
                var Result = Settings.ShowDialog();

                switch (Result)
                {
                    case DialogResult.OK:
                        StartWithWindows = Settings.StartWithWindows;
                        CloseToTray = Settings.CloseToTray;
                        MinimizeToTray = Settings.MinimizeToTray;
                        ChewSoundFile = Settings.ChewSoundFile;
                        SpitSoundFile = Settings.SpitSoundFile;
                        break;
                }
            }
        }

        #endregion

        #region Tray & Form Behavior

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!TryReadTicks("QuitDateTicks", out _quitDate))
            {
                using (frmConfig config = new frmConfig())
                {
                    if (config.ShowDialog() != DialogResult.OK)
                        throw new InvalidOperationException("Quit date is required by the application.");

                    QuitDate = config.QuitDate; // uses setter (cache + write)
                }
            }

            // Booleans
            TryReadStartWithWindows(out _startWithWindows);
            TryReadBoolean("CloseToTray", out _closeToTray);
            TryReadBoolean("MinimizeToTray", out _minimizeToTray);

            // Sounds
            TryReadFileInfo("ChewSoundFile", out _chewSoundFile);
            TryReadFileInfo("SpitSoundFile", out _spitSoundFile);

            if (!TryReadTicks("StoppedChewingLastPieceOfGumTicks", out _stoppedChewingLastPieceOfGum))
                _stoppedChewingLastPieceOfGum = DateTime.Now.AddHours(-1);

            if (!TryReadTicks("StartedChewingLastPieceOfGumTicks", out _startedChewingLastPieceOfGum))
                _startedChewingLastPieceOfGum = DateTime.Now.AddHours(-1).AddMinutes(-30);

            if (!TryReadEnum("Status", out Stat loaded))
                loaded = Stat.Waiting;

            SetStatus(loaded);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (MinimizeToTray && WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
            notifyIcon1.Visible = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseToTray)
            {
                e.Cancel = true;
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Developer: Kevin B. Harris <kevin.b.harris.2015@gmail.com>\n" +
                "Date: 2/21/2026 \n" +
                "Purpose: This application is a tool to keep up with your nicotine gum while in nicotine replacement therapy.", "About NRT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}