using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Mirrors_Edge_Catalyst_SpeedOMeter
{
    internal class MemoryManager
    {
        /****************************************************
         * TODO : _ rewrite using Template                  *
         *        or work on, expand and import CatalystAPI *
         *        _ handle exceptions                       *
         ****************************************************/


        private Process _process;
        private IntPtr _prochandle;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(
            IntPtr hProcess,
            long lpBaseAddress,
            [Out] byte[] lpBuffer,
            int dwSize,
            out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(
            IntPtr hProcess,
            long lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            out IntPtr lpNumberOfBytesWritten);



        /*************************************************
         *                                               *
         *                READERS SECTION                *
         *                                               *
         *************************************************/



        public byte ReadByte(long memadress) // 1 byte
        {
            var val = new byte[sizeof(byte)];
            var bytesRead = IntPtr.Zero;

            ReadProcessMemory(_prochandle, memadress, val, 1, out bytesRead);

            if ( bytesRead.ToInt32() != 1)
                throw new UnauthorizedAccessException("Could not read memory");

            return val[0];
        }


        public int ReadInt(long memadress) // 4 bytes
        {
            var buffer = new byte[sizeof(int)];
            var bytesRead = IntPtr.Zero;

            ReadProcessMemory(_prochandle, memadress, buffer, buffer.Length, out bytesRead);

            if (bytesRead.ToInt32() != buffer.Length)
                throw new UnauthorizedAccessException("Could not read memory");

            return BitConverter.ToInt32(buffer, 0);
        }



        public float ReadFloat(long memadress) // 4 bytes
        {
            var buffer = new byte[sizeof(float)];
            var bytesRead = IntPtr.Zero;

            ReadProcessMemory(_prochandle, memadress, buffer, buffer.Length, out bytesRead);

            if (bytesRead.ToInt32() != buffer.Length)
                throw new UnauthorizedAccessException("Could not read memory");

            return BitConverter.ToSingle(buffer, 0);
        }


        public long ReadLong(long memadress) // 8 bytes
        {
            var buffer = new byte[sizeof(long)];
            var bytesRead = IntPtr.Zero;

            ReadProcessMemory(_prochandle, memadress, buffer, buffer.Length, out bytesRead);

            if (bytesRead.ToInt64() != buffer.Length)
                throw new UnauthorizedAccessException("Could not read memory");

            return BitConverter.ToInt64(buffer, 0);
        }



        /*************************************************
         *                                               *
         *               WRITERS SECTION                 *
         *                                               *
         *************************************************/



        public void WriteByte(long memaddress, byte value) // 1 bytes
        {
            var buffer = BitConverter.GetBytes(value);
            var bytesWritten = IntPtr.Zero;

            if (!WriteProcessMemory(_prochandle, memaddress, buffer, buffer.Length, out bytesWritten))
                throw new UnauthorizedAccessException("Could not write memory");
        }


        public void WriteInt(long memaddress, int value) // 4 bytes
        {
            var buffer = BitConverter.GetBytes(value);
            var bytesWritten = IntPtr.Zero;

            if (!WriteProcessMemory(_prochandle, memaddress, buffer, buffer.Length, out bytesWritten))
                throw new UnauthorizedAccessException("Could not write memory");
        }


        public void WriteFloat(long memaddress, float value) // 4 bytes
        {
            var buffer = BitConverter.GetBytes(value);
            var bytesWritten = IntPtr.Zero;

            if (!WriteProcessMemory(_prochandle, memaddress, buffer, buffer.Length, out bytesWritten))
                throw new UnauthorizedAccessException("Could not write memory");
        }


        public void WriteLong(long memaddress, long value) // 8 bytes
        {
            var buffer = BitConverter.GetBytes(value);
            var bytesWritten = IntPtr.Zero;

            if (!WriteProcessMemory(_prochandle, memaddress, buffer, buffer.Length, out bytesWritten))
                throw new UnauthorizedAccessException("Could not write memory");
        }



        /*************************************************
         *                                               *
         *                PROCESS LINKER                 *
         *                                               *
         *************************************************/



        public void openProcess(string exe)
        {
            _process = Process.GetProcessesByName(exe)[0];

            _prochandle = (IntPtr)_process.Handle.ToInt32();
        }

        public long GetModuleAddress(string modulname)
        {
            foreach (ProcessModule module in _process.Modules)
            {
                if (module.ModuleName == modulname)
                {
                    return (long)module.BaseAddress;
                }
            }
            return 0;
        }
    }
}