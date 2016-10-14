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
            this.ColorPickerContainer = new System.Windows.Forms.GroupBox();
            this.ColorPickerMenu = new System.Windows.Forms.ThemeColorPicker();
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.PreviewTextContainer = new System.Windows.Forms.GroupBox();
            this.PreviewColorLabel = new System.Windows.Forms.Label();
            this.CheckGameStatus = new System.Windows.Forms.Timer(this.components);
            this.LaunchSpeedOMeter = new System.Windows.Forms.Button();
            this.CloseSpeedOMeterButton = new System.Windows.Forms.Button();
            this.SpeedOMeterButtons = new System.Windows.Forms.GroupBox();
            this.DecimalsGroupBox = new System.Windows.Forms.GroupBox();
            this.DecimalsNumericBox = new System.Windows.Forms.NumericUpDown();
            this.UpdateRateMenu = new System.Windows.Forms.ComboBox();
            this.FullScreenHackCheckBox = new System.Windows.Forms.CheckBox();
            this.SpeedOMeterSettingsContainer = new System.Windows.Forms.Panel();
            this.FullScreenSettingsContainer = new System.Windows.Forms.Panel();
            this.ScaleFontGroupBox = new System.Windows.Forms.GroupBox();
            this.ScaleFontUIValue = new System.Windows.Forms.NumericUpDown();
            this.YOffsetGroupBox = new System.Windows.Forms.GroupBox();
            this.YOffsetUIValue = new System.Windows.Forms.NumericUpDown();
            this.XOffsetGroupBox = new System.Windows.Forms.GroupBox();
            this.XOffsetUIValue = new System.Windows.Forms.NumericUpDown();
            this.AlphaFontGroupBox = new System.Windows.Forms.GroupBox();
            this.AlphaFontTextBox = new System.Windows.Forms.TextBox();
            this.AlphaFontScaleBar = new System.Windows.Forms.TrackBar();
            this.FullScreenModeInstructions = new System.Windows.Forms.Label();
            this.CentralSettingsContainer = new System.Windows.Forms.Panel();
            this.BotSettingsContainer = new System.Windows.Forms.Panel();
            this.ColorPickerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.PreviewTextContainer.SuspendLayout();
            this.SpeedOMeterButtons.SuspendLayout();
            this.DecimalsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalsNumericBox)).BeginInit();
            this.SpeedOMeterSettingsContainer.SuspendLayout();
            this.FullScreenSettingsContainer.SuspendLayout();
            this.ScaleFontGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleFontUIValue)).BeginInit();
            this.YOffsetGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YOffsetUIValue)).BeginInit();
            this.XOffsetGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XOffsetUIValue)).BeginInit();
            this.AlphaFontGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaFontScaleBar)).BeginInit();
            this.CentralSettingsContainer.SuspendLayout();
            this.BotSettingsContainer.SuspendLayout();
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
            this.GameStatus.Location = new System.Drawing.Point(85, 13);
            this.GameStatus.Name = "GameStatus";
            this.GameStatus.Size = new System.Drawing.Size(37, 13);
            this.GameStatus.TabIndex = 1;
            this.GameStatus.Text = "Status";
            // 
            // ColorPickerContainer
            // 
            this.ColorPickerContainer.Controls.Add(this.ColorPickerMenu);
            this.ColorPickerContainer.Location = new System.Drawing.Point(4, 2);
            this.ColorPickerContainer.Name = "ColorPickerContainer";
            this.ColorPickerContainer.Size = new System.Drawing.Size(188, 192);
            this.ColorPickerContainer.TabIndex = 2;
            this.ColorPickerContainer.TabStop = false;
            this.ColorPickerContainer.Text = "Color";
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
            // PreviewTextContainer
            // 
            this.PreviewTextContainer.Controls.Add(this.PreviewColorLabel);
            this.PreviewTextContainer.Location = new System.Drawing.Point(198, 2);
            this.PreviewTextContainer.Name = "PreviewTextContainer";
            this.PreviewTextContainer.Size = new System.Drawing.Size(207, 192);
            this.PreviewTextContainer.TabIndex = 3;
            this.PreviewTextContainer.TabStop = false;
            this.PreviewTextContainer.Text = "Preview Text";
            // 
            // PreviewColorLabel
            // 
            this.PreviewColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 55F);
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
            this.SpeedOMeterButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeedOMeterButtons.Controls.Add(this.LaunchSpeedOMeter);
            this.SpeedOMeterButtons.Controls.Add(this.CloseSpeedOMeterButton);
            this.SpeedOMeterButtons.Location = new System.Drawing.Point(240, 0);
            this.SpeedOMeterButtons.Name = "SpeedOMeterButtons";
            this.SpeedOMeterButtons.Size = new System.Drawing.Size(210, 50);
            this.SpeedOMeterButtons.TabIndex = 6;
            this.SpeedOMeterButtons.TabStop = false;
            this.SpeedOMeterButtons.Text = "SpeedOMeter";
            // 
            // DecimalsGroupBox
            // 
            this.DecimalsGroupBox.Controls.Add(this.DecimalsNumericBox);
            this.DecimalsGroupBox.Location = new System.Drawing.Point(10, 0);
            this.DecimalsGroupBox.Name = "DecimalsGroupBox";
            this.DecimalsGroupBox.Size = new System.Drawing.Size(190, 50);
            this.DecimalsGroupBox.TabIndex = 7;
            this.DecimalsGroupBox.TabStop = false;
            this.DecimalsGroupBox.Text = "Decimals";
            // 
            // DecimalsNumericBox
            // 
            this.DecimalsNumericBox.Location = new System.Drawing.Point(7, 20);
            this.DecimalsNumericBox.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.DecimalsNumericBox.Name = "DecimalsNumericBox";
            this.DecimalsNumericBox.Size = new System.Drawing.Size(178, 20);
            this.DecimalsNumericBox.TabIndex = 0;
            this.DecimalsNumericBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DecimalsNumericBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.DecimalsNumericBox.ValueChanged += new System.EventHandler(this.DecimalsNumericBox_ValueChanged);
            // 
            // UpdateRateMenu
            // 
            this.UpdateRateMenu.FormattingEnabled = true;
            this.UpdateRateMenu.Location = new System.Drawing.Point(327, 10);
            this.UpdateRateMenu.Name = "UpdateRateMenu";
            this.UpdateRateMenu.Size = new System.Drawing.Size(121, 21);
            this.UpdateRateMenu.TabIndex = 8;
            this.UpdateRateMenu.Text = "Update Rate ms";
            this.UpdateRateMenu.SelectedIndexChanged += new System.EventHandler(this.UpdateRateMenu_SelectedIndexChanged);
            // 
            // FullScreenHackCheckBox
            // 
            this.FullScreenHackCheckBox.AutoSize = true;
            this.FullScreenHackCheckBox.Location = new System.Drawing.Point(200, 13);
            this.FullScreenHackCheckBox.Name = "FullScreenHackCheckBox";
            this.FullScreenHackCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FullScreenHackCheckBox.Size = new System.Drawing.Size(112, 17);
            this.FullScreenHackCheckBox.TabIndex = 9;
            this.FullScreenHackCheckBox.Text = ": FullScreen Mode";
            this.FullScreenHackCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FullScreenHackCheckBox.UseVisualStyleBackColor = true;
            this.FullScreenHackCheckBox.CheckedChanged += new System.EventHandler(this.FullScreenHackCheckBox_CheckedChanged);
            // 
            // SpeedOMeterSettingsContainer
            // 
            this.SpeedOMeterSettingsContainer.Controls.Add(this.PreviewTextContainer);
            this.SpeedOMeterSettingsContainer.Controls.Add(this.ColorPickerContainer);
            this.SpeedOMeterSettingsContainer.Location = new System.Drawing.Point(15, 3);
            this.SpeedOMeterSettingsContainer.Name = "SpeedOMeterSettingsContainer";
            this.SpeedOMeterSettingsContainer.Size = new System.Drawing.Size(435, 210);
            this.SpeedOMeterSettingsContainer.TabIndex = 10;
            // 
            // FullScreenSettingsContainer
            // 
            this.FullScreenSettingsContainer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FullScreenSettingsContainer.Controls.Add(this.ScaleFontGroupBox);
            this.FullScreenSettingsContainer.Controls.Add(this.YOffsetGroupBox);
            this.FullScreenSettingsContainer.Controls.Add(this.XOffsetGroupBox);
            this.FullScreenSettingsContainer.Controls.Add(this.AlphaFontGroupBox);
            this.FullScreenSettingsContainer.Controls.Add(this.FullScreenModeInstructions);
            this.FullScreenSettingsContainer.Location = new System.Drawing.Point(0, 234);
            this.FullScreenSettingsContainer.Name = "FullScreenSettingsContainer";
            this.FullScreenSettingsContainer.Size = new System.Drawing.Size(435, 210);
            this.FullScreenSettingsContainer.TabIndex = 11;
            this.FullScreenSettingsContainer.Visible = false;
            // 
            // ScaleFontGroupBox
            // 
            this.ScaleFontGroupBox.Controls.Add(this.ScaleFontUIValue);
            this.ScaleFontGroupBox.Location = new System.Drawing.Point(287, 65);
            this.ScaleFontGroupBox.Name = "ScaleFontGroupBox";
            this.ScaleFontGroupBox.Size = new System.Drawing.Size(88, 51);
            this.ScaleFontGroupBox.TabIndex = 3;
            this.ScaleFontGroupBox.TabStop = false;
            this.ScaleFontGroupBox.Text = "Scale Font";
            // 
            // ScaleFontUIValue
            // 
            this.ScaleFontUIValue.Location = new System.Drawing.Point(15, 19);
            this.ScaleFontUIValue.Name = "ScaleFontUIValue";
            this.ScaleFontUIValue.Size = new System.Drawing.Size(56, 20);
            this.ScaleFontUIValue.TabIndex = 0;
            this.ScaleFontUIValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ScaleFontUIValue.ValueChanged += new System.EventHandler(this.ScaleFontUIValue_ValueChanged);
            // 
            // YOffsetGroupBox
            // 
            this.YOffsetGroupBox.Controls.Add(this.YOffsetUIValue);
            this.YOffsetGroupBox.Location = new System.Drawing.Point(166, 65);
            this.YOffsetGroupBox.Name = "YOffsetGroupBox";
            this.YOffsetGroupBox.Size = new System.Drawing.Size(76, 51);
            this.YOffsetGroupBox.TabIndex = 2;
            this.YOffsetGroupBox.TabStop = false;
            this.YOffsetGroupBox.Text = "Y Offset";
            // 
            // YOffsetUIValue
            // 
            this.YOffsetUIValue.Location = new System.Drawing.Point(12, 19);
            this.YOffsetUIValue.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.YOffsetUIValue.Name = "YOffsetUIValue";
            this.YOffsetUIValue.Size = new System.Drawing.Size(52, 20);
            this.YOffsetUIValue.TabIndex = 0;
            this.YOffsetUIValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.YOffsetUIValue.ValueChanged += new System.EventHandler(this.YOffsetUIValue_ValueChanged);
            // 
            // XOffsetGroupBox
            // 
            this.XOffsetGroupBox.Controls.Add(this.XOffsetUIValue);
            this.XOffsetGroupBox.Location = new System.Drawing.Point(36, 65);
            this.XOffsetGroupBox.Name = "XOffsetGroupBox";
            this.XOffsetGroupBox.Size = new System.Drawing.Size(76, 51);
            this.XOffsetGroupBox.TabIndex = 1;
            this.XOffsetGroupBox.TabStop = false;
            this.XOffsetGroupBox.Text = "X Offset";
            // 
            // XOffsetUIValue
            // 
            this.XOffsetUIValue.Location = new System.Drawing.Point(8, 19);
            this.XOffsetUIValue.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.XOffsetUIValue.Name = "XOffsetUIValue";
            this.XOffsetUIValue.Size = new System.Drawing.Size(56, 20);
            this.XOffsetUIValue.TabIndex = 0;
            this.XOffsetUIValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.XOffsetUIValue.ValueChanged += new System.EventHandler(this.XOffsetUIValue_ValueChanged);
            // 
            // AlphaFontGroupBox
            // 
            this.AlphaFontGroupBox.Controls.Add(this.AlphaFontTextBox);
            this.AlphaFontGroupBox.Controls.Add(this.AlphaFontScaleBar);
            this.AlphaFontGroupBox.Location = new System.Drawing.Point(10, 122);
            this.AlphaFontGroupBox.Name = "AlphaFontGroupBox";
            this.AlphaFontGroupBox.Size = new System.Drawing.Size(395, 65);
            this.AlphaFontGroupBox.TabIndex = 4;
            this.AlphaFontGroupBox.TabStop = false;
            this.AlphaFontGroupBox.Text = "Alpha Font";
            // 
            // AlphaFontTextBox
            // 
            this.AlphaFontTextBox.Location = new System.Drawing.Point(350, 20);
            this.AlphaFontTextBox.Name = "AlphaFontTextBox";
            this.AlphaFontTextBox.Size = new System.Drawing.Size(35, 20);
            this.AlphaFontTextBox.TabIndex = 1;
            this.AlphaFontTextBox.Text = "255";
            this.AlphaFontTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AlphaFontTextBox.TextChanged += new System.EventHandler(this.AlphaFontTextBox_TextChanged);
            // 
            // AlphaFontScaleBar
            // 
            this.AlphaFontScaleBar.Location = new System.Drawing.Point(8, 15);
            this.AlphaFontScaleBar.Maximum = 255;
            this.AlphaFontScaleBar.Name = "AlphaFontScaleBar";
            this.AlphaFontScaleBar.Size = new System.Drawing.Size(340, 45);
            this.AlphaFontScaleBar.TabIndex = 0;
            this.AlphaFontScaleBar.Value = 255;
            this.AlphaFontScaleBar.Scroll += new System.EventHandler(this.AlphaFontScaleBar_Scroll);
            // 
            // FullScreenModeInstructions
            // 
            this.FullScreenModeInstructions.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullScreenModeInstructions.ForeColor = System.Drawing.Color.Red;
            this.FullScreenModeInstructions.Location = new System.Drawing.Point(8, 3);
            this.FullScreenModeInstructions.Name = "FullScreenModeInstructions";
            this.FullScreenModeInstructions.Size = new System.Drawing.Size(410, 55);
            this.FullScreenModeInstructions.TabIndex = 0;
            this.FullScreenModeInstructions.Text = resources.GetString("FullScreenModeInstructions.Text");
            this.FullScreenModeInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CentralSettingsContainer
            // 
            this.CentralSettingsContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CentralSettingsContainer.Controls.Add(this.SpeedOMeterSettingsContainer);
            this.CentralSettingsContainer.Controls.Add(this.FullScreenSettingsContainer);
            this.CentralSettingsContainer.Location = new System.Drawing.Point(13, 37);
            this.CentralSettingsContainer.Name = "CentralSettingsContainer";
            this.CentralSettingsContainer.Size = new System.Drawing.Size(440, 450);
            this.CentralSettingsContainer.TabIndex = 12;
            // 
            // BotSettingsContainer
            // 
            this.BotSettingsContainer.Controls.Add(this.DecimalsGroupBox);
            this.BotSettingsContainer.Controls.Add(this.SpeedOMeterButtons);
            this.BotSettingsContainer.Location = new System.Drawing.Point(3, 500);
            this.BotSettingsContainer.Name = "BotSettingsContainer";
            this.BotSettingsContainer.Size = new System.Drawing.Size(460, 60);
            this.BotSettingsContainer.TabIndex = 13;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(464, 562);
            this.Controls.Add(this.BotSettingsContainer);
            this.Controls.Add(this.CentralSettingsContainer);
            this.Controls.Add(this.FullScreenHackCheckBox);
            this.Controls.Add(this.UpdateRateMenu);
            this.Controls.Add(this.GameStatus);
            this.Controls.Add(this.GameNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SpeedOMeter - by CaptainAnderz & Aryetis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ColorPickerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.PreviewTextContainer.ResumeLayout(false);
            this.SpeedOMeterButtons.ResumeLayout(false);
            this.DecimalsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DecimalsNumericBox)).EndInit();
            this.SpeedOMeterSettingsContainer.ResumeLayout(false);
            this.FullScreenSettingsContainer.ResumeLayout(false);
            this.ScaleFontGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScaleFontUIValue)).EndInit();
            this.YOffsetGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YOffsetUIValue)).EndInit();
            this.XOffsetGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XOffsetUIValue)).EndInit();
            this.AlphaFontGroupBox.ResumeLayout(false);
            this.AlphaFontGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaFontScaleBar)).EndInit();
            this.CentralSettingsContainer.ResumeLayout(false);
            this.BotSettingsContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameNameLabel;
        private System.Windows.Forms.Label GameStatus;
        private System.Windows.Forms.GroupBox ColorPickerContainer;
        public System.Windows.Forms.ColorDialog ColorPicker;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ThemeColorPicker ColorPickerMenu;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.GroupBox PreviewTextContainer;
        private System.Windows.Forms.Label PreviewColorLabel;
        private System.Windows.Forms.Timer CheckGameStatus;
        private System.Windows.Forms.Button LaunchSpeedOMeter;
        private System.Windows.Forms.Button CloseSpeedOMeterButton;
        private System.Windows.Forms.GroupBox SpeedOMeterButtons;
        private System.Windows.Forms.GroupBox DecimalsGroupBox;
        private System.Windows.Forms.NumericUpDown DecimalsNumericBox;
        private System.Windows.Forms.ComboBox UpdateRateMenu;
        private System.Windows.Forms.CheckBox FullScreenHackCheckBox;
        private System.Windows.Forms.Panel SpeedOMeterSettingsContainer;
        private System.Windows.Forms.Panel FullScreenSettingsContainer;
        private System.Windows.Forms.GroupBox AlphaFontGroupBox;
        private System.Windows.Forms.GroupBox ScaleFontGroupBox;
        private System.Windows.Forms.GroupBox YOffsetGroupBox;
        private System.Windows.Forms.GroupBox XOffsetGroupBox;
        private System.Windows.Forms.TrackBar AlphaFontScaleBar;
        private System.Windows.Forms.NumericUpDown ScaleFontUIValue;
        private System.Windows.Forms.NumericUpDown YOffsetUIValue;
        private System.Windows.Forms.NumericUpDown XOffsetUIValue;
        private System.Windows.Forms.Panel CentralSettingsContainer;
        private System.Windows.Forms.Panel BotSettingsContainer;
        private System.Windows.Forms.TextBox AlphaFontTextBox;
        private System.Windows.Forms.Label FullScreenModeInstructions;
    }
}