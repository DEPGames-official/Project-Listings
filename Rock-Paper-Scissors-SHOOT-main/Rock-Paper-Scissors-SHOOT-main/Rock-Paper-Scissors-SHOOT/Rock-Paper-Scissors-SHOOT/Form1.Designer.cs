namespace Rock_Paper_Scissors_SHOOT
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RPCText = new System.Windows.Forms.Label();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.RPCTimer = new System.Windows.Forms.Timer(this.components);
            this.ScissorsSelect = new System.Windows.Forms.Button();
            this.PaperSelect = new System.Windows.Forms.Button();
            this.RockSelect = new System.Windows.Forms.Button();
            this.Results = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RPCText
            // 
            this.RPCText.Font = new System.Drawing.Font("Segoe UI", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RPCText.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.RPCText.Location = new System.Drawing.Point(216, 123);
            this.RPCText.Name = "RPCText";
            this.RPCText.Size = new System.Drawing.Size(376, 163);
            this.RPCText.TabIndex = 0;
            this.RPCText.Text = "RPC";
            this.RPCText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(329, 289);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(127, 32);
            this.StartGameButton.TabIndex = 1;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // RPCTimer
            // 
            this.RPCTimer.Tick += new System.EventHandler(this.RPCTimer_Tick);
            // 
            // ScissorsSelect
            // 
            this.ScissorsSelect.Location = new System.Drawing.Point(613, 365);
            this.ScissorsSelect.Name = "ScissorsSelect";
            this.ScissorsSelect.Size = new System.Drawing.Size(127, 45);
            this.ScissorsSelect.TabIndex = 2;
            this.ScissorsSelect.Text = "Scissors";
            this.ScissorsSelect.UseVisualStyleBackColor = true;
            this.ScissorsSelect.Visible = false;
            this.ScissorsSelect.Click += new System.EventHandler(this.ScissorsSelect_Click);
            // 
            // PaperSelect
            // 
            this.PaperSelect.Location = new System.Drawing.Point(329, 365);
            this.PaperSelect.Name = "PaperSelect";
            this.PaperSelect.Size = new System.Drawing.Size(127, 45);
            this.PaperSelect.TabIndex = 3;
            this.PaperSelect.Text = "Paper";
            this.PaperSelect.UseVisualStyleBackColor = true;
            this.PaperSelect.Visible = false;
            this.PaperSelect.Click += new System.EventHandler(this.PaperSelect_Click);
            // 
            // RockSelect
            // 
            this.RockSelect.Location = new System.Drawing.Point(54, 365);
            this.RockSelect.Name = "RockSelect";
            this.RockSelect.Size = new System.Drawing.Size(127, 45);
            this.RockSelect.TabIndex = 4;
            this.RockSelect.Text = "Rock";
            this.RockSelect.UseVisualStyleBackColor = true;
            this.RockSelect.Visible = false;
            this.RockSelect.Click += new System.EventHandler(this.RockSelect_Click);
            // 
            // Results
            // 
            this.Results.Dock = System.Windows.Forms.DockStyle.Top;
            this.Results.Font = new System.Drawing.Font("Segoe UI", 34F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Results.ForeColor = System.Drawing.SystemColors.Control;
            this.Results.Location = new System.Drawing.Point(0, 0);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(800, 286);
            this.Results.TabIndex = 5;
            this.Results.Text = "Results";
            this.Results.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Results.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.RockSelect);
            this.Controls.Add(this.PaperSelect);
            this.Controls.Add(this.ScissorsSelect);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.RPCText);
            this.Name = "Form1";
            this.Text = "Rock, Paper, Scissors";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label RPCText;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Timer RPCTimer;
        private System.Windows.Forms.Button ScissorsSelect;
        private System.Windows.Forms.Button PaperSelect;
        private System.Windows.Forms.Button RockSelect;
        private System.Windows.Forms.Label Results;
    }
}
