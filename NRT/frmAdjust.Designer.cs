using System;
using System.Drawing;
using System.Windows.Forms;

namespace NRT
{
    partial class frmAdjust
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdjust));
            pnlStartCard = new Panel();
            lblStartTitle = new Label();
            tableLayoutStart = new TableLayoutPanel();
            labelStartDate = new Label();
            datePickerStartDate = new DateTimePicker();
            labelStartTime = new Label();
            timePickerStartTime = new DateTimePicker();
            pnlStopCard = new Panel();
            lblStopTitle = new Label();
            tableLayoutStop = new TableLayoutPanel();
            labelStopDate = new Label();
            datePickerStopDate = new DateTimePicker();
            labelStopTime = new Label();
            timePickerStopTime = new DateTimePicker();
            btnSet = new Button();
            pnlStartCard.SuspendLayout();
            tableLayoutStart.SuspendLayout();
            pnlStopCard.SuspendLayout();
            tableLayoutStop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlStartCard
            // 
            pnlStartCard.BackColor = Color.White;
            pnlStartCard.BorderStyle = BorderStyle.FixedSingle;
            pnlStartCard.Controls.Add(lblStartTitle);
            pnlStartCard.Controls.Add(tableLayoutStart);
            pnlStartCard.Location = new Point(16, 16);
            pnlStartCard.Name = "pnlStartCard";
            pnlStartCard.Size = new Size(360, 120);
            pnlStartCard.TabIndex = 2;
            // 
            // lblStartTitle
            // 
            lblStartTitle.AutoSize = true;
            lblStartTitle.Font = new Font("Segoe UI Semibold", 10.5F);
            lblStartTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblStartTitle.Location = new Point(12, 10);
            lblStartTitle.Name = "lblStartTitle";
            lblStartTitle.Size = new Size(113, 19);
            lblStartTitle.TabIndex = 0;
            lblStartTitle.Text = "Started Chewing";
            // 
            // tableLayoutStart
            // 
            tableLayoutStart.ColumnCount = 2;
            tableLayoutStart.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutStart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutStart.Controls.Add(labelStartDate, 0, 0);
            tableLayoutStart.Controls.Add(datePickerStartDate, 1, 0);
            tableLayoutStart.Controls.Add(labelStartTime, 0, 1);
            tableLayoutStart.Controls.Add(timePickerStartTime, 1, 1);
            tableLayoutStart.Location = new Point(12, 36);
            tableLayoutStart.Name = "tableLayoutStart";
            tableLayoutStart.RowCount = 2;
            tableLayoutStart.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutStart.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutStart.Size = new Size(330, 70);
            tableLayoutStart.TabIndex = 1;
            // 
            // labelStartDate
            // 
            labelStartDate.Dock = DockStyle.Fill;
            labelStartDate.Font = new Font("Segoe UI", 9.5F);
            labelStartDate.Location = new Point(3, 0);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(74, 35);
            labelStartDate.TabIndex = 0;
            labelStartDate.Text = "Date:";
            labelStartDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // datePickerStartDate
            // 
            datePickerStartDate.Format = DateTimePickerFormat.Short;
            datePickerStartDate.Location = new Point(83, 3);
            datePickerStartDate.Name = "datePickerStartDate";
            datePickerStartDate.Size = new Size(200, 23);
            datePickerStartDate.TabIndex = 1;
            // 
            // labelStartTime
            // 
            labelStartTime.Dock = DockStyle.Fill;
            labelStartTime.Font = new Font("Segoe UI", 9.5F);
            labelStartTime.Location = new Point(3, 35);
            labelStartTime.Name = "labelStartTime";
            labelStartTime.Size = new Size(74, 35);
            labelStartTime.TabIndex = 2;
            labelStartTime.Text = "Time:";
            labelStartTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timePickerStartTime
            // 
            timePickerStartTime.Format = DateTimePickerFormat.Time;
            timePickerStartTime.Location = new Point(83, 38);
            timePickerStartTime.Name = "timePickerStartTime";
            timePickerStartTime.ShowUpDown = true;
            timePickerStartTime.Size = new Size(200, 23);
            timePickerStartTime.TabIndex = 3;
            // 
            // pnlStopCard
            // 
            pnlStopCard.BackColor = Color.White;
            pnlStopCard.BorderStyle = BorderStyle.FixedSingle;
            pnlStopCard.Controls.Add(lblStopTitle);
            pnlStopCard.Controls.Add(tableLayoutStop);
            pnlStopCard.Location = new Point(16, 148);
            pnlStopCard.Name = "pnlStopCard";
            pnlStopCard.Size = new Size(360, 120);
            pnlStopCard.TabIndex = 1;
            // 
            // lblStopTitle
            // 
            lblStopTitle.AutoSize = true;
            lblStopTitle.Font = new Font("Segoe UI Semibold", 10.5F);
            lblStopTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblStopTitle.Location = new Point(12, 10);
            lblStopTitle.Name = "lblStopTitle";
            lblStopTitle.Size = new Size(120, 19);
            lblStopTitle.TabIndex = 0;
            lblStopTitle.Text = "Stopped Chewing";
            // 
            // tableLayoutStop
            // 
            tableLayoutStop.ColumnCount = 2;
            tableLayoutStop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutStop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutStop.Controls.Add(labelStopDate, 0, 0);
            tableLayoutStop.Controls.Add(datePickerStopDate, 1, 0);
            tableLayoutStop.Controls.Add(labelStopTime, 0, 1);
            tableLayoutStop.Controls.Add(timePickerStopTime, 1, 1);
            tableLayoutStop.Location = new Point(12, 36);
            tableLayoutStop.Name = "tableLayoutStop";
            tableLayoutStop.RowCount = 2;
            tableLayoutStop.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutStop.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutStop.Size = new Size(330, 70);
            tableLayoutStop.TabIndex = 1;
            // 
            // labelStopDate
            // 
            labelStopDate.Dock = DockStyle.Fill;
            labelStopDate.Font = new Font("Segoe UI", 9.5F);
            labelStopDate.Location = new Point(3, 0);
            labelStopDate.Name = "labelStopDate";
            labelStopDate.Size = new Size(74, 35);
            labelStopDate.TabIndex = 0;
            labelStopDate.Text = "Date:";
            labelStopDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // datePickerStopDate
            // 
            datePickerStopDate.Format = DateTimePickerFormat.Short;
            datePickerStopDate.Location = new Point(83, 3);
            datePickerStopDate.Name = "datePickerStopDate";
            datePickerStopDate.Size = new Size(200, 23);
            datePickerStopDate.TabIndex = 1;
            // 
            // labelStopTime
            // 
            labelStopTime.Dock = DockStyle.Fill;
            labelStopTime.Font = new Font("Segoe UI", 9.5F);
            labelStopTime.Location = new Point(3, 35);
            labelStopTime.Name = "labelStopTime";
            labelStopTime.Size = new Size(74, 35);
            labelStopTime.TabIndex = 2;
            labelStopTime.Text = "Time:";
            labelStopTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timePickerStopTime
            // 
            timePickerStopTime.Format = DateTimePickerFormat.Time;
            timePickerStopTime.Location = new Point(83, 38);
            timePickerStopTime.Name = "timePickerStopTime";
            timePickerStopTime.ShowUpDown = true;
            timePickerStopTime.Size = new Size(200, 23);
            timePickerStopTime.TabIndex = 3;
            // 
            // btnSet
            // 
            btnSet.BackColor = Color.FromArgb(33, 150, 83);
            btnSet.FlatAppearance.BorderSize = 0;
            btnSet.FlatStyle = FlatStyle.Flat;
            btnSet.Font = new Font("Segoe UI Semibold", 10.5F);
            btnSet.ForeColor = Color.White;
            btnSet.Location = new Point(256, 284);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(120, 38);
            btnSet.TabIndex = 0;
            btnSet.Text = "Save Changes";
            btnSet.UseVisualStyleBackColor = false;
            btnSet.Click += btnSet_Click;
            // 
            // frmAdjust
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(392, 340);
            Controls.Add(btnSet);
            Controls.Add(pnlStopCard);
            Controls.Add(pnlStartCard);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAdjust";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adjust Last Gum Session";
            Load += frmAdjust_Load;
            pnlStartCard.ResumeLayout(false);
            pnlStartCard.PerformLayout();
            tableLayoutStart.ResumeLayout(false);
            pnlStopCard.ResumeLayout(false);
            pnlStopCard.PerformLayout();
            tableLayoutStop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlStartCard;
        private Panel pnlStopCard;

        private Label lblStartTitle;
        private Label lblStopTitle;

        private TableLayoutPanel tableLayoutStart;
        private TableLayoutPanel tableLayoutStop;

        private Label labelStartDate;
        private Label labelStartTime;
        private Label labelStopDate;
        private Label labelStopTime;

        private DateTimePicker datePickerStartDate;
        private DateTimePicker timePickerStartTime;
        private DateTimePicker datePickerStopDate;
        private DateTimePicker timePickerStopTime;

        private Button btnSet;
    }
}
