using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace NRT
{
    public partial class frmAdjust : Form
    {
        public frmAdjust()
        {
            InitializeComponent();
        }

        // =========================
        // Registry helpers
        // =========================

        private static bool TryReadTicks(string name, out DateTime value)
        {
            value = default;
            try
            {
                using var hive = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
                using var settings = hive.CreateSubKey(@"SOFTWARE\kbhtech\NRT", writable: false);
                if (settings?.GetValue(name) is long ticks &&
                    ticks >= DateTime.MinValue.Ticks &&
                    ticks <= DateTime.MaxValue.Ticks)
                {
                    value = new DateTime(ticks, DateTimeKind.Local);
                    return true;
                }
            }
            catch { }
            return false;
        }

        private static void WriteTicks(string name, DateTime value)
        {
            try
            {
                using var hive = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
                using var settings = hive.CreateSubKey(@"SOFTWARE\kbhtech\NRT", writable: true)
                    ?? throw new InvalidOperationException("Failed to open registry key.");
                settings.SetValue(name, value.Ticks, RegistryValueKind.QWord);
            }
            catch
            {
                MessageBox.Show("Failed to save settings to registry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // Properties
        // =========================

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public DateTime StartedChewingLastPieceOfGum
        {
            get
            {
                if (TryReadTicks("StartedChewingLastPieceOfGumTicks", out DateTime dt))
                    return dt;

                DateTime fallback = DateTime.Now.AddHours(-1);
                WriteTicks("StartedChewingLastPieceOfGumTicks", fallback);
                return fallback;
            }
            set => WriteTicks("StartedChewingLastPieceOfGumTicks", value);
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public DateTime StoppedChewingLastPieceOfGum
        {
            get
            {
                if (TryReadTicks("StoppedChewingLastPieceOfGumTicks", out DateTime dt))
                    return dt;

                DateTime fallback = DateTime.Now;
                WriteTicks("StoppedChewingLastPieceOfGumTicks", fallback);
                return fallback;
            }
            set => WriteTicks("StoppedChewingLastPieceOfGumTicks", value);
        }

        // =========================
        // Events
        // =========================

        private void frmAdjust_Load(object sender, EventArgs e)
        {
            datePickerStartDate.Value = StartedChewingLastPieceOfGum;
            timePickerStartTime.Value = StartedChewingLastPieceOfGum;
            datePickerStopDate.Value = StoppedChewingLastPieceOfGum;
            timePickerStopTime.Value = StoppedChewingLastPieceOfGum;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            StartedChewingLastPieceOfGum = new DateTime(
                datePickerStartDate.Value.Year,
                datePickerStartDate.Value.Month,
                datePickerStartDate.Value.Day,
                timePickerStartTime.Value.Hour,
                timePickerStartTime.Value.Minute,
                timePickerStartTime.Value.Second
            );

            StoppedChewingLastPieceOfGum = new DateTime(
                datePickerStopDate.Value.Year,
                datePickerStopDate.Value.Month,
                datePickerStopDate.Value.Day,
                timePickerStopTime.Value.Hour,
                timePickerStopTime.Value.Minute,
                timePickerStopTime.Value.Second
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
