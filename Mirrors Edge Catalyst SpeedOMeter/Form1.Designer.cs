namespace Mirrors_Edge_Catalyst_SpeedOMeter
{
    partial class SpeedOMeter
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
        private void InitializeComponent(int UpdateRate)
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpeedOMeter));
            this.IsRunningTimer1 = new System.Windows.Forms.Timer(this.components);
            this.ReadTimer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // IsRunningTimer1
            // 
            this.IsRunningTimer1.Enabled = true;
            this.IsRunningTimer1.Tick += new System.EventHandler(this.IsRunningTimer1_Tick);
            // 
            // ReadTimer1
            // 
            this.ReadTimer1.Interval = UpdateRate;
            this.ReadTimer1.Tick += new System.EventHandler(this.ReadTimer1_Tick);
            // 
            // SpeedOMeter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpeedOMeter";
            this.Text = "SpeedOMeter";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer IsRunningTimer1;
        private System.Windows.Forms.Timer ReadTimer1;
    }
}

