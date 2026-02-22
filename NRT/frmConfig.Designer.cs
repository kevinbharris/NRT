using System;
using System.Drawing;
using System.Windows.Forms;

namespace NRT
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            pnlCard = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            tableLayoutPanel = new TableLayoutPanel();
            lblQuitDate = new Label();
            dtpQuitDate = new DateTimePicker();
            panelButtons = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            pnlCard.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(tableLayoutPanel);
            pnlCard.Location = new Point(16, 16);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(420, 140);
            pnlCard.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 12F);
            lblTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblTitle.Location = new Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(79, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quit Date";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(96, 96, 96);
            lblSubtitle.Location = new Point(16, 38);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(301, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Set the date you stopped using tobacco products.";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(lblQuitDate, 0, 0);
            tableLayoutPanel.Controls.Add(dtpQuitDate, 1, 0);
            tableLayoutPanel.Location = new Point(16, 68);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(388, 40);
            tableLayoutPanel.TabIndex = 2;
            // 
            // lblQuitDate
            // 
            lblQuitDate.Anchor = AnchorStyles.Right;
            lblQuitDate.AutoSize = true;
            lblQuitDate.Font = new Font("Segoe UI", 9.5F);
            lblQuitDate.Location = new Point(32, 11);
            lblQuitDate.Name = "lblQuitDate";
            lblQuitDate.Size = new Size(65, 17);
            lblQuitDate.TabIndex = 0;
            lblQuitDate.Text = "Quit date:";
            // 
            // dtpQuitDate
            // 
            dtpQuitDate.Anchor = AnchorStyles.Left;
            dtpQuitDate.Font = new Font("Segoe UI", 9.5F);
            dtpQuitDate.Format = DateTimePickerFormat.Short;
            dtpQuitDate.Location = new Point(103, 8);
            dtpQuitDate.Name = "dtpQuitDate";
            dtpQuitDate.Size = new Size(200, 24);
            dtpQuitDate.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.FlowDirection = FlowDirection.RightToLeft;
            panelButtons.Location = new Point(16, 164);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(420, 56);
            panelButtons.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(33, 150, 83);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 10F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(307, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 36);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(211, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 36);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // frmConfig
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            CancelButton = btnCancel;
            ClientSize = new Size(452, 232);
            Controls.Add(panelButtons);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfig";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quit Date Settings";
            Load += frmConfig_Load;
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCard;
        private Label lblTitle;
        private Label lblSubtitle;

        private TableLayoutPanel tableLayoutPanel;
        private Label lblQuitDate;
        private DateTimePicker dtpQuitDate;

        private FlowLayoutPanel panelButtons;
        private Button btnSave;
        private Button btnCancel;
    }
}
