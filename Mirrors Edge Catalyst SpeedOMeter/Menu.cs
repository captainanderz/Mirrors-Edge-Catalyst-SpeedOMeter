﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirrors_Edge_Catalyst_SpeedOMeter
{
    public partial class Menu : Form
    {
        private PublicProperties PublicProperties = new PublicProperties();
        private static PrivateFontCollection Pfc = new PrivateFontCollection();
        private const int NumericDefaultValue = 2;
        private const int PreviewColorLabelFontDefaultSize = 55;
        private static int PreviewColorLabelLastSize { get; set; }
        private static int NumericLastValue { get; set; }
        private static bool FullScreenMode { get; set; } // Describe whether the program shall display the speed
                                                         // using In-Game overlay hijacking or overlaying app in Window mode
        // Every FS prefixed Variable is specific to the FullScreenMode
        private static int FSAlphaVal = 255;


        public SpeedOMeter SpeedOMeter;
        public SolidBrush ColorPickerColor;

        public Menu()
        {
            PreviewColorLabelLastSize = 2;
            NumericLastValue = 2;
            InitializeComponent();
            AddItemsToComboBox();
            /*
             * On creation of the Menu, we need to resize the size of
             * CentralSettingsContainer & relocate BottomSettingsContainer
             * in order to display only the informations necessary according to FullSCreenHackCheckbox
             * Thus :
             */
            CentralSettingsContainer.Height = SpeedOMeterSettingsContainer.Height; // resize CentralSettingsContainer
            FullScreenSettingsContainer.Top = 0; // relocate FullScreenSettings at top of CentralSettingsContainer (even thought it is hidden)
            BotSettingsContainer.Top = SpeedOMeterSettingsContainer.Top + CentralSettingsContainer.Height + 30; // reposition BotSettingsContainer
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            LaunchSpeedOMeter.ForeColor = Color.Red;
        }

        private void ColorPickerMenu_ColorSelected(object sender, ColorSelectedArg e)
        {
            ColorPickerColor = new SolidBrush(e.Color);

            PreviewColorLabel.ForeColor = e.Color;
        }

        private void CheckGameStatus_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("MirrorsEdgeCatalyst").Length > 0)
            {
                GameStatus.Text = "RUNNING";
                GameStatus.ForeColor = Color.Green;
            }
            else
            {
                GameStatus.Text = "NOT RUNNING";
                GameStatus.ForeColor = Color.Red;
            }
        }

        private void LaunchSpeedOMeter_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("MirrorsEdgeCatalyst").Length > 0)
            {
                if ( !FullScreenMode )
                { // Display speed using overlay (Window/Borderless compatible only)
                    FormCollection fc = Application.OpenForms;
                    if (fc.Count < 2)
                    {
                        if (UpdateRateMenu.SelectedItem == null)
                        {
                            UpdateRateMenu.SelectedItem = 50;
                        }
                        SpeedOMeter = new SpeedOMeter((int)numericUpDown1.Value, ColorPickerColor, (int)UpdateRateMenu.SelectedItem);
                        new Thread(() => Application.Run(SpeedOMeter)).Start();

                        LaunchSpeedOMeter.ForeColor = Color.Green;
                    }
                }
                else
                {
                    //TODO

                    /*
                     * Display speed hijacking In-Game FPS Counter Overlay
                     * 
                     * How to do so :
                     * 1/ Activate in-game FPS counter, by changing the IG variable "PerfOverlay.enable true" AND "PerfOverlay.DrawFPS true"
                     * 2/ Match UpdateRateMenu's program variable with IG variable "PerfOverlay.FpsTimePeriod"
                     * 3/ Hijack IG "FPS Displayed value"
                     *      (warning! different than "IG actual FPS value",
                     *       "IG FPS Displayed value" is actualized according every "PerfOverlay.FpsTimePeriod"
                     *       acccording to "IG actual FPS value"
                     * 
                     * TODO : translate cheatengine pointer to deepPointer
                     *       locate PerfOverlay.enable AND PerfOverlay.DrawFPS pointers
                     *       
                     */


                }
            }
            else
            {
                MessageBox.Show("Launch the game before running SpeedOMeter");
            }
        }
        public void LoadFont()
        {
            // specify embedded resource name
            string resource = "Mirrors_Edge_Catalyst_SpeedOMeter.good_times_rg.ttf";
            // receive resource stream
            Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            // create a buffer to read in to
            byte[] fontdata = new byte[fontStream.Length];
            // read the font data from the resource
            fontStream.Read(fontdata, 0, (int)fontStream.Length);
            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
            // pass the font to the font collection
            Pfc.AddMemoryFont(data, (int)fontStream.Length);
            // close the resource stream
            fontStream.Close();
            // free the unsafe memory
            Marshal.FreeCoTaskMem(data);
        }

        private void CloseSpeedOMeterButton_Click(object sender, EventArgs e)
        {
            if (LaunchSpeedOMeter.ForeColor == Color.Green)
            {
                SpeedOMeter.SpeedOMeterClose();
                SpeedOMeter = new SpeedOMeter(0, ColorPickerColor, (int)UpdateRateMenu.SelectedItem); // Random int given with, does not matter
                LaunchSpeedOMeter.ForeColor = Color.Red;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PublicProperties.AmountOfDecimals = (int) numericUpDown1.Value;
            if (numericUpDown1.Value != 2)
            {
                if (numericUpDown1.Value > NumericLastValue)
                {
                    NumericLastValue = (int) numericUpDown1.Value;
                    PreviewColorLabel.Text = PreviewColorLabel.Text + "0";

                    if (PreviewColorLabel.Text.ToCharArray().Count() > 5)
                    {
                        if ((int) PreviewColorLabel.Font.Size > PreviewColorLabelLastSize)
                        {
                            PreviewColorLabel.Font = new Font("Arial Narrow", (PreviewColorLabel.Font.Size - 10));
                        }
                        PreviewColorLabelLastSize = (int) PreviewColorLabel.Font.Size;
                    }
                    return;
                }

                if (numericUpDown1.Value < NumericLastValue)
                {
                    PreviewColorLabel.Font = new Font("Arial Narrow", (PreviewColorLabel.Font.Size + 10));
                    NumericLastValue = (int) numericUpDown1.Value;
                    PreviewColorLabel.Text = PreviewColorLabel.Text.Remove(PreviewColorLabel.Text.Length - 1, 1) + "";
                }
            }
            else
            {
                PreviewColorLabel.Text = "7.00";
                PreviewColorLabel.Font = new Font("Arial Narrow", PreviewColorLabelFontDefaultSize);
                return;
            }
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void AddItemsToComboBox()
        {
            UpdateRateMenu.Items.Add(50);
            UpdateRateMenu.Items.Add(100);
            UpdateRateMenu.Items.Add(200);
            UpdateRateMenu.Items.Add(500);
            UpdateRateMenu.Items.Add(1000);
        }

        private void FullScreenHackCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            /************************************************
             * Toggle unused UI elements for FullScreenMode *
             *         and raise FullScreenMode Flag        *
             ************************************************/
            if ( FullScreenHackCheckBox.Checked )
            {
                // hide & unHide elements
                SpeedOMeterSettingsContainer.Visible = false;
                FullScreenSettingsContainer.Visible = true;
                // raise FullScreenMode Flag
                FullScreenMode = true;
            }
            else
            {   
                // hide & unHide elements
                SpeedOMeterSettingsContainer.Visible = true;
                FullScreenSettingsContainer.Visible = false;
                // raise FullScreenMode Flag
                FullScreenMode = false;
            }
        }

        private void AlphaFontScaleBar_Scroll(object sender, EventArgs e)
        {
            /*************************************
             *      Update FSAlphaVal value      *
             *************************************/

            AlphaFontTextBox.Text = AlphaFontScaleBar.Value.ToString();
            FSAlphaVal = AlphaFontScaleBar.Value;
        }

        private void AlphaFontTextBox_TextChanged(object sender, EventArgs e)
        {
            /*************************************
             *  Link ScaleBar and TextBox value  *
             *      Update FSAlphaVal value      *
             *************************************/
            int parsedText;

            if (int.TryParse(AlphaFontTextBox.Text, out parsedText) && parsedText <= 255 && parsedText >= 0)
            {
                // Parse text value, check it's within 0-255 and modify ScaleBar dynamicaly
                FSAlphaVal = parsedText;
                AlphaFontScaleBar.Value = parsedText;
            }
            else
                // If user typed giberish, fallback to the scaleBar Value
                AlphaFontTextBox.Text = AlphaFontScaleBar.Value.ToString();
        }

    }
}
