using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using FontFactory = SharpDX.DirectWrite.Factory;

namespace Mirrors_Edge_Catalyst_SpeedOMeter
{
    public partial class SpeedOMeter : Form
    {
        private static readonly PrivateFontCollection Pfc = new PrivateFontCollection();
        private readonly SpeedOMeter thisSpeedOMeter;
        private Process _process;
        private Thread _procMonThread;
        private long address;
        private bool isRunning;
        private MemoryManager Mem;
        public PublicProperties PublicProperties = new PublicProperties();
        private Rectangle ScreenResolution;
        private decimal speed;
        private readonly int Decimals;
        private SolidBrush PaintColor;

        public SpeedOMeter(int decimals, SolidBrush Color, int UpdateRate)
        {
            Decimals = decimals;
            PaintColor = Color;
            thisSpeedOMeter = this;
            LoadFont();
            InitializeComponent(UpdateRate);
        }
        
        private float _Height { get; set; }
        private float _Width { get; set; }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            _procMonThread = new Thread(ProcMonThreadFunc);
            _procMonThread.Start();
        }

        private void CloseSpeedOMeter()
        {
            if (thisSpeedOMeter != null)
            {
                thisSpeedOMeter.Close();
            }
        }

        public void SpeedOMeterClose()
        {
            if (thisSpeedOMeter != null)
            {
                thisSpeedOMeter.Invoke(new CloseSpeedOMeterdelegate(CloseSpeedOMeter));
            }
        }

        private void IsRunningTimer1_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("MirrorsEdgeCatalyst").Length > 0)
            {
                if (!isRunning)
                {
                    Mem = new MemoryManager();
                    Mem.openProcess("MirrorsEdgeCatalyst");
                    ReadTimer1.Enabled = true;
                    isRunning = true;
                }
            }
            else
            {
                ReadTimer1.Enabled = false;
                isRunning = false;
            }
        }

        private void ReadTimer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Read Memory
                address = Mem.ReadInt(Mem.GetModuleAddress("MirrorsEdgeCatalyst.exe") + 0x023DD6F8);
                address = Mem.ReadInt(address + 0x1e8);
                address = Mem.ReadInt(address + 0x10);
                address += 0x438;

                speed = Math.Round((decimal)Mem.ReadFloat(address), Decimals);

                Invalidate();
            }
            catch (Exception)
            {
                //ignore
            }
        }

        private void UpdateWindow()
        {
            if (_process != null && _process.HasExited == false)
            {
                ScreenResolution = new Rectangle();
                GetClientRect(_process.MainWindowHandle, ref ScreenResolution);
                if (ScreenResolution.Size.IsEmpty) // true of _process window is minimized
                {
                    Hide();
                }
                else
                {
                    WindowState = FormWindowState.Normal;
                    Show();
                    var topLeft = new Point(0, 0);
                    ClientToScreen(_process.MainWindowHandle, ref topLeft);
                    var oRect = new Rectangle(topLeft, ScreenResolution.Size);
                    if (Location != oRect.Location || Size != oRect.Size)
                    {
                        Location = oRect.Location;
                        Size = oRect.Size;
                        Invalidate();
                    }
                }
            }
            else
            {
                Visible = false;
            }
        }

        private void ProcMonThreadFunc(object data) // Main Thread
        {
            while (_process == null || _process.HasExited)
            {
                try
                {
                    _process = Process.GetProcessesByName("MirrorsEdgeCatalyst")[0];
                }
                catch
                {
                    _process = null;
                }
                Thread.Sleep(2000);
            }

            var lastRect = new Rectangle();
            var rect = new Rectangle();
            while (_process != null && _process.HasExited == false)
            {
                GetWindowRect(_process.MainWindowHandle, ref rect);
                if (lastRect != rect)
                {
                    lastRect = rect;
                    Invoke(new FormUpdateCallback(UpdateWindow));
                }
                Thread.Sleep(5000);
            }
        }

        // PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT PAINT

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            _Height = ScreenResolution.Height / 2;
            _Height = Height - (_Height / 2);

            _Width = ScreenResolution.Width / 2;
            _Width = Width - (_Width / 2);

            var myFont = new Font(Pfc.Families[0], 40, FontStyle.Bold); // "Helvetica"

            // Get ColorPicker color
            if (PaintColor == null)
            {
                PaintColor = (SolidBrush)Brushes.Red;
            }

            graphics.DrawString(speed.ToString(), myFont, PaintColor, new PointF(_Width, _Height));
        }

        public void LoadFont()
        {
            // specify embedded resource name
            var resource = "Mirrors_Edge_Catalyst_SpeedOMeter.good_times_rg.ttf";
            // receive resource stream
            var fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
            // create an unsafe memory block for the font data
            var data = Marshal.AllocCoTaskMem((int) fontStream.Length);
            // create a buffer to read in to
            var fontdata = new byte[fontStream.Length];
            // read the font data from the resource
            fontStream.Read(fontdata, 0, (int) fontStream.Length);
            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, (int) fontStream.Length);
            // pass the font to the font collection
            Pfc.AddMemoryFont(data, (int) fontStream.Length);
            // close the resource stream
            fontStream.Close();
            // free the unsafe memory
            Marshal.FreeCoTaskMem(data);
        }

        private delegate void CloseSpeedOMeterdelegate();

        private delegate void FormUpdateCallback();

        #region Native functions

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetClientRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        #endregion
    }
}