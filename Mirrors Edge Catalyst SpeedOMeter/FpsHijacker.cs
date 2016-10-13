using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;




namespace Mirrors_Edge_Catalyst_SpeedOMeter
{
    public class FpsHijacker
    {
        private static System.Timers.Timer updateTickTimer;
        private static long baseAddress; // during testing baseAdress was always equals to 0x140000000
                                         // further adresses in commentaries are based on this value
        private static long address;
        private static MemoryManager Mem;


        private static int hsTickRate; // "Hijack RefreshRate" of the "FPS Displayed Value" by IG Overlay
                                       //expressed in ms


        /*****************************
         *    IG Hidden Variables    *
         *****************************/
        private static decimal speed; // Faith's Speed



        /*****************************
         *    IG Console Variables   *
         *****************************/
        private static float displayScale // <=> IG PerfOverlay.FpsDisplayScale 
        {
            get
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x68; // change offset to point to correct address
                return Mem.ReadFloat(address); // Read IG value for "PerfOverlay.FpsDisplayScale" 
            }
            set
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x68; // change offset to point to correct address
                Mem.WriteFloat(address, value); // Change IG value for "PerfOverlay.FpsDisplayScale" 
            }
        }
        private static float ig_TickRate // <=> IG PerfOverlay.FpsTimerPeriod
        {
            get
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x60; // change offset to point to correct address
                return Mem.ReadFloat(address); // Read IG value for "PerfOverlay.FpsTimerPeriod" 
            }
            set
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x60; // change offset to point to correct address
                Mem.WriteFloat(address, value); // Change IG value for "PerfOverlay.FpsTimerPeriod" 
            }

        }
        private static int xOffset // <=> IG  PerfOverlay.FpsDisplayOffsetX
        {
            get
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x6c; // change offset to point to correct address
                return Mem.ReadInt(address); // Read IG value for "PerfOverlay.FpsDisplayOffsetX" 
            }
            set
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x6c; // change offset to point to correct address
                Mem.WriteInt(address, value); // Change IG value for "PerfOverlay.FpsDisplayOffsetX" 
            }
        }
        private static int yOffset // <=> IG  PerfOverlay.FpsDisplayOffsetY
        {
            get
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x70; // change offset to point to correct address
                return Mem.ReadInt(address); // Read IG value for "PerfOverlay.FpsDisplayOffsetY" 
            }
            set
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x70; // change offset to point to correct address
                Mem.WriteInt(address, value); // Change IG value for "PerfOverlay.FpsDisplayOffsetY" 
            }
        }
        private static byte alpha // <=> IG  PerfOverlay.FpsDisplayAlpha
        {
            get
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x7c; // change offset to point to correct address
                return Mem.ReadByte(address); // Read IG value for "PerfOverlay.FpsDisplayOffsetY" 

            }
            set
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x7c; // change offset to point to correct address
                Mem.WriteByte(address, value); // Change IG value for "PerfOverlay.FpsDisplayOffsetY" 

            }
        }
        private static byte enable // <=> IG  PerfOverlay.Enable
        {
            get
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100" // should be 1EB73F80
                address += 0x74; // change offset to point to correct value
                return Mem.ReadByte(address); // Read IG value for "PerfOverlay.Enable"
            }
            set
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100" // should be 1EB73F80
                address += 0x74; // change offset to point to correct value
                Mem.WriteByte(address, value); // Change IG value for "PerfOverlay.Enable" 
            }
        }
        private static byte drawFps // <=> IG  PerfOverlay.DrawFps
        {
            get
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100" // should be 1EB73F80
                address += 0x7a; // change offset to point to correct value
                return Mem.ReadByte(address); // Read IG value for "PerfOverlay.DrawFps"
            }
            set
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100" // should be 1EB73F80
                address += 0x7a; // change offset to point to correct value
                Mem.WriteByte(address, value); // Change IG value for "PerfOverlay.DrawFps" 

            }
        }
        private static byte displayFormat // NOT USED "YET" <=> IG PerfOverlay.FpsDisplayFormat
        {
            get
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100" // should be 1EB73F80
                address += 0x64; // change offset to point to correct value
                return Mem.ReadByte(address); // Read IG value for "PerfOverlay.FpsDisplayFormat"
            }
            set
            {
                address = Mem.ReadLong(baseAddress + 0x024AA100); // Jump to adress pointed at "baseAddress + 0x024AA100" // should be 1EB73F80
                address += 0x64; // change offset to point to correct value
                Mem.WriteByte(address, value); // Change IG value for "PerfOverlay.FpsDisplayFormat" 
            }
        }


        public FpsHijacker(int hsTickRate, float DisplayScale_, int XOffset_, int YOffset_, int Alpha_)
        {
            Mem = new MemoryManager();
            Mem.openProcess("MirrorsEdgeCatalyst");
            baseAddress = Mem.GetModuleAddress("MirrorsEdgeCatalyst.exe"); // should be 0x140000000

            updateTickTimer = new System.Timers.Timer();
            updateTickTimer.Elapsed += new ElapsedEventHandler(HijackRoutine); // call HijackRoutine every TickRate
            updateTickTimer.Interval = hsTickRate; // TickRate in ms
            updateTickTimer.Enabled = true;
        }



        private void HijackRoutine(object source, ElapsedEventArgs e)
        {
            /********* DEBUG SECTION ******************/
            //enable = 1;
            //displayFormat = 2;
            //drawFps = 1;
            //xOffset = 50;
            //yOffset = 70;
            //alpha = 120;
            //ig_TickRate = 1.5F;
            //displayScale = 8.5F;
            /********** ALL IG VARIABLE WORK, YEAH !!!! ******/



            /******************************************/

        }

    }
}
