using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

/*
 * TODO : insert CT file in github
 **/


namespace Mirrors_Edge_Catalyst_SpeedOMeter
{
    public class FpsHijacker
    {
        /****************************************************************************************************************************
        * Display speed by hijacking In-Game FPS Counter Overlay                                                                    *
        *                                                                                                                           *
        * How does it work :                                                                                                        *
        * 1/ Activate in-game FPS counter, by changing the IG variable "PerfOverlay.enable true" AND "PerfOverlay.DrawFPS true"     *
        * 2/ Match UpdateRateMenu's program variable with IG variable "PerfOverlay.FpsTimePeriod"                                   *
        * 3/ Hijack IG "FPS Displayed value"                                                                                        *
        *      (warning! different than "IG actual FPS value", there is multiple "FPS counter" in the memory                        *
        *       "IG FPS Displayed value" is actualized according every "PerfOverlay.FpsTimePeriod"                                  *
        *       acccording to "IG actual FPS value"                                                                                 *
        *                                                                                                                           *
        *       Refer to MirrorsEdgeCatalyst.CT CheatEngine files for more info on the pointers                                     *
        *       or take a look at https://docs.google.com/document/d/1udBmNPPr6L4wYiCSA_hypr1CmbjecS60FZPHofqYAxk/edit              *
        *****************************************************************************************************************************/

        /******************************** 
         * Proper FpsHijacker Variables *
         ********************************/
        private static System.Timers.Timer updateTickTimer; // used to determine how many time per second to hijack "IG FPS counter" value
        private static long baseAddress; // during testing baseAdress was always equals to 0x140000000
                                         // further adresses in commentaries are based on this value
        private static long address; // address used to point to IG variables, used in getters and setters 
        private static MemoryManager Mem; // MemoryManager to allow speedOmeter to fiddle with Mirror's Edge Catalyst memory
        private static int hsTickRate; // "Hijack RefreshRate" of the "FPS Displayed Value" by IG Overlay, expressed in ms
        private static int decimals; // number of faith's speed's decimals to draw on screen


        /*****************************
         *    IG Hidden Variables    *
         *****************************/
        private static float speed // Faith's Speed based on X and Z axis, we don't care about her falling speed....
        {
            get
            {
                address = Mem.ReadLong(baseAddress + 0x023DD6F8); // Jump to adress pointed at "baseAddress + 0x023DD6F8"
                address = Mem.ReadLong(baseAddress + 0x1e8); // Jump
                address = Mem.ReadLong(baseAddress + 0x10); // Put your hands up in the air !
                address += 0x438;

                return Mem.ReadFloat(address) *(decimals*10)  ; // get Faith's speed
                                                                // and manipulate it so we "shift" its value enough to get rid of the comma
                                                                // according to the decimals variable decided by the User
            }
            set
            {
                // No need for it ... It's memory protected, will be overwritten by the game as soon as you modify it
                // Don't want to mess with that either, I'm all clean yo ! No BlackHat shenanigans
            }
        }
        private static float displayedFpsValue // Value Displayed on the IG Overlay as "Fps Counter", that's the one we hijack !
        {
            get
            {
                address = Mem.ReadLong(baseAddress + 0x028352C8); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x4c; // change offset to point to correct address
                return Mem.ReadFloat(address); // Read its value
            }
            set
            {
                address = Mem.ReadLong(baseAddress + 0x028352C8); // Jump to adress pointed at "baseAddress + 0x024AA100"
                address += 0x4c; // change offset to point to correct address
                Mem.WriteFloat(address, value); // Change its value
            }
        }



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
        private static float FpsTimePeriod // <=> IG refresh rate of the "FPS counter" variable
                                           //     we put this to an absurd value, so "FPS counter" will not be
                                           //     overwritten by the game anymore 
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




        /*********************************************************************************
         *                                                                               *      
         *                            FpsHijacker INITIALIZER                            *
         *                                                                               *
         * *******************************************************************************/



        public FpsHijacker(int hsTickRate, int decimals, float displayScale_, int xOffset_, int yOffset_, byte alpha_)
        {
            /*
             * hsTickRate <=> Number of time we will write over the IG FPS variable per ms 
             * decimals <=> numbers of decimals to display, note that speed has to be shifted cause we can't print comma, 
             *              int only display limitations at the moment. TODO : HACK second FPS Display method which is a string
             * displayScale_ <=> scale of the FPS counter display In-Game
             * xOffset_ <=> xOffset of the display from top right corner
             * yOffset_ <=> yOffset of the display from top right corner
             * alpha_ <=> alpha channel, transparency setting
             */

            // Initialize Memory Manager and baseAdress to avoid recalculating all the time
            Mem = new MemoryManager();
            Mem.openProcess("MirrorsEdgeCatalyst");
            baseAddress = Mem.GetModuleAddress("MirrorsEdgeCatalyst.exe"); // should be 0x140000000

            /* Initialization of IG variable to display FPS */
            enable = 1; // enable Overlay , should be on by default, but who knows
            FpsTimePeriod = float.MaxValue; // Setting IG "FPS value counter" to an absurd value, so it won't be overwritten by the game while we hijack it
            displayFormat = 0; // set the FPS IG counter so it display only the int value we're gonna hijack
            xOffset = xOffset_;
            yOffset = yOffset_;
            alpha = alpha_;
            displayScale = displayScale_;

            // Create a timer to hijack the "FPS Value counter" every hsTickRate 
            updateTickTimer = new System.Timers.Timer();
            updateTickTimer.Elapsed += new ElapsedEventHandler(HijackRoutine); // call HijackRoutine every TickRate
            updateTickTimer.Interval = hsTickRate; // TickRate in ms
            updateTickTimer.Enabled = true;
        }





        /*********************************************************************************
         *                                                                               *      
         *                       FpsHijacker """DESTRUCTOR"""                            *
         *                                                                               *
         ********************************************************************************/

        public void destroy()
        {
            /***************************************************************************
             *  User requested to end the FpsHijacker                                  *
             *  Thus we restore default values for IG variables                        *
             *  TODO : capture previous variables state, store them, and restore them  *
             ***************************************************************************/
            enable = 1;
            xOffset = 10;
            yOffset = 10;
            alpha = 255;
            displayScale = 3;
            drawFps = 0;
        }




        /*********************************************************************************
         *                                                                               *      
         *                         FpsHijacker's ROUTINES                                *
         *                                                                               *
         ********************************************************************************/

        private void HijackRoutine(object source, ElapsedEventArgs e)
        {
            /* Simply Hijack the FPS Value Counter*/
            displayedFpsValue = speed;
        }


        /****************************************************************
         *    Setters to allow User to modify parameters on the fly     *
         ****************************************************************/

        public void setxOffset(int xOffset_)
        {
            xOffset = xOffset_;
        }

        public void setyOffset(int yOffset_)
        {
            yOffset = yOffset_;
        }

        public void setdisplayScale(byte displayScale_)
        {
            displayScale = displayScale_;
        }

        public void setalpha(byte alpha_)
        {
            alpha = alpha_;
        }

        public void setdecimals(int decimals_)
        {
            decimals = decimals_;
        }

    }
}
