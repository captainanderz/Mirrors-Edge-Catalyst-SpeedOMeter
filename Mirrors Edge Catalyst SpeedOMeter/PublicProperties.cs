using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mirrors_Edge_Catalyst_SpeedOMeter
{
    public class PublicProperties
    {
        public SolidBrush FontColor { get; set; }
        public PrivateFontCollection Pfc = new PrivateFontCollection();
        public int AmountOfDecimals { get; set; }
        
    }
}
