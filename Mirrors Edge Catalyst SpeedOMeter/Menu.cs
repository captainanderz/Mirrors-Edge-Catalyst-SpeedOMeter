using System;
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
        /**********************************************************************
         * TODO : _ Serialize user settings, save them on Exit                *
         *          and restore them on launch                                *
         *        _ Add a Font selector for Windowed                          *
         *          .... and maybe Fullscreen too                             *
         *        _ clean those names ...                                     *
         *           numericUpDown1_ValueChanged wtf is this ?!?              *
         *           CloseSpeedOMeterButton_Click, maybe find a better        *
         *           suited names now that there is two methods               *
         *           etc                                                      *
         *        _ fix DecimalValue being update does not call               *
         *               fpsHijacker.setDecimal (only if fpsHijacker!= null   *
         *               and updating Decimal f*** up the windowed preview    *
         *        _ add supports for on the fly adjustment to windowed method *
         **********************************************************************/




        private PublicProperties PublicProperties = new PublicProperties();
        private static PrivateFontCollection Pfc = new PrivateFontCollection();
        private const int NumericDefaultValue = 2;
        private const int PreviewColorLabelFontDefaultSize = 55;
        private static int PreviewColorLabelLastSize { get; set; }
        private static int NumericLastValue { get; set; }
        private static bool FullScreenMode { get; set; } // Describe whether the program shall display the speed
                                                         // using In-Game overlay hijacking or overlaying app in Window mode
        private static int FSAlphaVal = 255; // Alpha Value of font used in FullScreen Mode


        public SpeedOMeter SpeedOMeter;
        public FpsHijacker fpsHijacker;
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
             * Thus the following hack
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
                            UpdateRateMenu.SelectedItem = 50;
                        SpeedOMeter = new SpeedOMeter((int)DecimalsNumericBox.Value, ColorPickerColor, (int)UpdateRateMenu.SelectedItem);
                        new Thread(() => Application.Run(SpeedOMeter)).Start();

                        LaunchSpeedOMeter.ForeColor = Color.Green;
                    }
                }
                else
                {
                    // Display Speed using IG Overlay Hijacking method 
                    // All work done in FPSHijacker.cs
                    //fpsHijacker = new FpsHijacker(40, 3, 9, 100, 150, 100);
                    if (UpdateRateMenu.SelectedItem == null)
                        UpdateRateMenu.SelectedItem = 50;
                    fpsHijacker = new FpsHijacker((int)UpdateRateMenu.SelectedItem,
                                                  (int)DecimalsNumericBox.Value,
                                                  (float)ScaleFontUIValue.Value,
                                                  (int)XOffsetUIValue.Value,
                                                  (int)YOffsetUIValue.Value,
                                                  (byte)AlphaFontScaleBar.Value
                                                   );
                    LaunchSpeedOMeter.ForeColor = Color.Green;
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
            if (!FullScreenMode)
            {

                if (LaunchSpeedOMeter.ForeColor == Color.Green)
                {
                    SpeedOMeter.SpeedOMeterClose();
                    SpeedOMeter = new SpeedOMeter(0, ColorPickerColor, (int)UpdateRateMenu.SelectedItem); // Random int given wich, does not matter
                    LaunchSpeedOMeter.ForeColor = Color.Red;
                }
            }
            else
            {
                fpsHijacker.destroy();
                LaunchSpeedOMeter.ForeColor = Color.Red;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // WTF ?!?
            PublicProperties.AmountOfDecimals = (int) DecimalsNumericBox.Value;
            if (DecimalsNumericBox.Value != 2)
            {
                if (DecimalsNumericBox.Value > NumericLastValue)
                {
                    NumericLastValue = (int) DecimalsNumericBox.Value;
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

                if (DecimalsNumericBox.Value < NumericLastValue)
                {
                    PreviewColorLabel.Font = new Font("Arial Narrow", (PreviewColorLabel.Font.Size + 10));
                    NumericLastValue = (int) DecimalsNumericBox.Value;
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
            if (SpeedOMeter != null)
               SpeedOMeter.SpeedOMeterClose();
            if (fpsHijacker != null)
                fpsHijacker.destroy();
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
            if (fpsHijacker != null)
                fpsHijacker.setalpha((byte)FSAlphaVal);
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
                if (fpsHijacker != null)
                    fpsHijacker.setalpha((byte)FSAlphaVal);
            }
            else
                // If user typed giberish, fallback to the scaleBar Value
                AlphaFontTextBox.Text = AlphaFontScaleBar.Value.ToString();
        }

        private void XOffsetUIValue_ValueChanged(object sender, EventArgs e)
        {
            if (fpsHijacker != null)
                fpsHijacker.setxOffset((int)XOffsetUIValue.Value);
        }

        private void YOffsetUIValue_ValueChanged(object sender, EventArgs e)
        {
            if (fpsHijacker != null)
                fpsHijacker.setyOffset((int)YOffsetUIValue.Value);
        }

        private void ScaleFontUIValue_ValueChanged(object sender, EventArgs e)
        {
            if (fpsHijacker != null)
                fpsHijacker.setdisplayScale((byte)ScaleFontUIValue.Value);
        }

        private void UpdateRateMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fpsHijacker != null)
                fpsHijacker.sethsTickRate((int)UpdateRateMenu.SelectedItem);
        }

    }
}
