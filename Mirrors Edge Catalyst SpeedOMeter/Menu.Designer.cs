namespace Mirrors_Edge_Catalyst_SpeedOMeter
{
    partial class Menu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.GameNameLabel = new System.Windows.Forms.Label();
            this.GameStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ColorPickerMenu = new System.Windows.Forms.ThemeColorPicker();
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.PreviewText = new System.Windows.Forms.GroupBox();
            this.PreviewColorLabel = new System.Windows.Forms.Label();
            this.CheckGameStatus = new System.Windows.Forms.Timer(this.components);
            this.LaunchSpeedOMeter = new System.Windows.Forms.Button();
            this.CloseSpeedOMeterButton = new System.Windows.Forms.Button();
            this.SpeedOMeterButtons = new System.Windows.Forms.GroupBox();
            this.DecimalsGroupBox = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.UpdateRateMenu = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.PreviewText.SuspendLayout();
            this.SpeedOMeterButtons.SuspendLayout();
            this.DecimalsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // GameNameLabel
            // 
            this.GameNameLabel.AutoSize = true;
            this.GameNameLabel.Location = new System.Drawing.Point(13, 13);
            this.GameNameLabel.Name = "GameNameLabel";
            this.GameNameLabel.Size = new System.Drawing.Size(71, 13);
            this.GameNameLabel.TabIndex = 0;
            this.GameNameLabel.Text = "Mirror\'s Edge:";
            // 
            // GameStatus
            // 
            this.GameStatus.AutoSize = true;
            this.GameStatus.Location = new System.Drawing.Point(90, 13);
            this.GameStatus.Name = "GameStatus";
            this.GameStatus.Size = new System.Drawing.Size(37, 13);
            this.GameStatus.TabIndex = 1;
            this.GameStatus.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ColorPickerMenu);
            this.groupBox1.Location = new System.Drawing.Point(16, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 192);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color";
            // 
            // ColorPickerMenu
            // 
            this.ColorPickerMenu.BackColor = System.Drawing.SystemColors.Control;
            this.ColorPickerMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ColorPickerMenu.BackgroundImage")));
            this.ColorPickerMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ColorPickerMenu.Color = System.Drawing.Color.Empty;
            this.ColorPickerMenu.CustomColors = new int[0];
            this.ColorPickerMenu.Location = new System.Drawing.Point(6, 19);
            this.ColorPickerMenu.Name = "ColorPickerMenu";
            this.ColorPickerMenu.Size = new System.Drawing.Size(176, 167);
            this.ColorPickerMenu.TabIndex = 0;
            this.ColorPickerMenu.ColorSelected += new System.Windows.Forms.ThemeColorPicker.colorSelected(this.ColorPickerMenu_ColorSelected);
            // 
            // ColorPicker
            // 
            this.ColorPicker.AnyColor = true;
            this.ColorPicker.FullOpen = true;
            // 
            // PreviewText
            // 
            this.PreviewText.Controls.Add(this.PreviewColorLabel);
            this.PreviewText.Location = new System.Drawing.Point(210, 46);
            this.PreviewText.Name = "PreviewText";
            this.PreviewText.Size = new System.Drawing.Size(207, 192);
            this.PreviewText.TabIndex = 3;
            this.PreviewText.TabStop = false;
            this.PreviewText.Text = "Preview Text";
            // 
            // PreviewColorLabel
            // 
            this.PreviewColorLabel.Font = new System.Drawing.Font("Arial Narrow", 55F);
            this.PreviewColorLabel.ForeColor = System.Drawing.Color.Red;
            this.PreviewColorLabel.Location = new System.Drawing.Point(6, 19);
            this.PreviewColorLabel.Name = "PreviewColorLabel";
            this.PreviewColorLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PreviewColorLabel.Size = new System.Drawing.Size(195, 167);
            this.PreviewColorLabel.TabIndex = 0;
            this.PreviewColorLabel.Text = "7.00";
            this.PreviewColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PreviewColorLabel.UseMnemonic = false;
            // 
            // CheckGameStatus
            // 
            this.CheckGameStatus.Enabled = true;
            this.CheckGameStatus.Interval = 1000;
            this.CheckGameStatus.Tick += new System.EventHandler(this.CheckGameStatus_Tick);
            // 
            // LaunchSpeedOMeter
            // 
            this.LaunchSpeedOMeter.Location = new System.Drawing.Point(107, 19);
            this.LaunchSpeedOMeter.Name = "LaunchSpeedOMeter";
            this.LaunchSpeedOMeter.Size = new System.Drawing.Size(94, 23);
            this.LaunchSpeedOMeter.TabIndex = 4;
            this.LaunchSpeedOMeter.Text = "Run";
            this.LaunchSpeedOMeter.UseVisualStyleBackColor = true;
            this.LaunchSpeedOMeter.Click += new System.EventHandler(this.LaunchSpeedOMeter_Click);
            // 
            // CloseSpeedOMeterButton
            // 
            this.CloseSpeedOMeterButton.Location = new System.Drawing.Point(6, 19);
            this.CloseSpeedOMeterButton.Name = "CloseSpeedOMeterButton";
            this.CloseSpeedOMeterButton.Size = new System.Drawing.Size(94, 23);
            this.CloseSpeedOMeterButton.TabIndex = 5;
            this.CloseSpeedOMeterButton.Text = "Close";
            this.CloseSpeedOMeterButton.UseVisualStyleBackColor = true;
            this.CloseSpeedOMeterButton.Click += new System.EventHandler(this.CloseSpeedOMeterButton_Click);
            // 
            // SpeedOMeterButtons
            // 
            this.SpeedOMeterButtons.Controls.Add(this.LaunchSpeedOMeter);
            this.SpeedOMeterButtons.Controls.Add(this.CloseSpeedOMeterButton);
            this.SpeedOMeterButtons.Location = new System.Drawing.Point(210, 244);
            this.SpeedOMeterButtons.Name = "SpeedOMeterButtons";
            this.SpeedOMeterButtons.Size = new System.Drawing.Size(207, 53);
            this.SpeedOMeterButtons.TabIndex = 6;
            this.SpeedOMeterButtons.TabStop = false;
            this.SpeedOMeterButtons.Text = "SpeedOMeter";
            // 
            // DecimalsGroupBox
            // 
            this.DecimalsGroupBox.Controls.Add(this.numericUpDown1);
            this.DecimalsGroupBox.Location = new System.Drawing.Point(13, 245);
            this.DecimalsGroupBox.Name = "DecimalsGroupBox";
            this.DecimalsGroupBox.Size = new System.Drawing.Size(191, 52);
            this.DecimalsGroupBox.TabIndex = 7;
            this.DecimalsGroupBox.TabStop = false;
            this.DecimalsGroupBox.Text = "Decimals";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(7, 20);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(178, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // UpdateRateMenu
            // 
            this.UpdateRateMenu.FormattingEnabled = true;
            this.UpdateRateMenu.Location = new System.Drawing.Point(297, 12);
            this.UpdateRateMenu.Name = "UpdateRateMenu";
            this.UpdateRateMenu.Size = new System.Drawing.Size(121, 21);
            this.UpdateRateMenu.TabIndex = 8;
            this.UpdateRateMenu.Text = "Update Rate ms";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(430, 309);
            this.Controls.Add(this.UpdateRateMenu);
            this.Controls.Add(this.DecimalsGroupBox);
            this.Controls.Add(this.SpeedOMeterButtons);
            this.Controls.Add(this.PreviewText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GameStatus);
            this.Controls.Add(this.GameNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SpeedOMeter - by CaptainAnderz";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.PreviewText.ResumeLayout(false);
            this.SpeedOMeterButtons.ResumeLayout(false);
            this.DecimalsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameNameLabel;
        private System.Windows.Forms.Label GameStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ColorDialog ColorPicker;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ThemeColorPicker ColorPickerMenu;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.GroupBox PreviewText;
        private System.Windows.Forms.Label PreviewColorLabel;
        private System.Windows.Forms.Timer CheckGameStatus;
        private System.Windows.Forms.Button LaunchSpeedOMeter;
        private System.Windows.Forms.Button CloseSpeedOMeterButton;
        private System.Windows.Forms.GroupBox SpeedOMeterButtons;
        private System.Windows.Forms.GroupBox DecimalsGroupBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox UpdateRateMenu;
    }
}