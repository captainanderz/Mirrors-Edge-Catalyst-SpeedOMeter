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
        private PublicProperties PublicProperties = new PublicProperties();
        private static PrivateFontCollection Pfc = new PrivateFontCollection();
        public SpeedOMeter SpeedOMeter;
        public SolidBrush ColorPickerColor;

        public Menu()
        {
            PreviewColorLabelLastSize = 2;
            NumericLastValue = 2;
            InitializeComponent();
            AddItemsToComboBox();
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

        private const int NumericDefaultValue = 2;
        private const int PreviewColorLabelFontDefaultSize = 55;
        private static int PreviewColorLabelLastSize{ get; set; }
        private static int NumericLastValue { get; set; }

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
    }
}
