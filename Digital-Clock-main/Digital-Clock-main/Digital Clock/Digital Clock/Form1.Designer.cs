namespace Digital_Clock
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        internal void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.time = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.TimeFormat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // time
            // 
            this.time.Dock = System.Windows.Forms.DockStyle.Top;
            this.time.Font = new System.Drawing.Font("Segoe UI", 54F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.time.Location = new System.Drawing.Point(0, 0);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(1010, 177);
            this.time.TabIndex = 0;
            this.time.Text = "time";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // date
            // 
            this.date.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.date.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.date.Location = new System.Drawing.Point(0, 292);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(1010, 269);
            this.date.TabIndex = 1;
            this.date.Text = "date";
            this.date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeFormat
            // 
            this.TimeFormat.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TimeFormat.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TimeFormat.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.TimeFormat.Location = new System.Drawing.Point(400, 226);
            this.TimeFormat.Name = "TimeFormat";
            this.TimeFormat.Size = new System.Drawing.Size(201, 41);
            this.TimeFormat.TabIndex = 2;
            this.TimeFormat.Text = "12/24 Hour Switch";
            this.TimeFormat.UseVisualStyleBackColor = false;
            this.TimeFormat.Click += new System.EventHandler(this.TimeFormat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1010, 561);
            this.Controls.Add(this.TimeFormat);
            this.Controls.Add(this.date);
            this.Controls.Add(this.time);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Button TimeFormat;
    }
}
