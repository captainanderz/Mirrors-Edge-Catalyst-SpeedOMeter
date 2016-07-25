using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Mirrors_Edge_Catalyst_SpeedOMeter
{
    internal class MemoryManager
    {
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

        public void WriteFloat(long memaddress, float value)
        {
            var buffer = BitConverter.GetBytes(value);
            var bytesWritten = IntPtr.Zero;

            WriteProcessMemory(_prochandle, memaddress, buffer, buffer.Length, out bytesWritten);
        }

        public long ReadInt(long memadress)
        {
            var buffer = new byte[sizeof(long)];
            var bytesRead = IntPtr.Zero;

            ReadProcessMemory(_prochandle, memadress, buffer, buffer.Length, out bytesRead);

            if (bytesRead.ToInt64() != buffer.Length)
            {
                return -1;
            }

            return BitConverter.ToInt64(buffer, 0);
        }

        public float ReadFloat(long memadress)
        {
            var buffer = new byte[sizeof(float)];
            var bytesRead = IntPtr.Zero;

            ReadProcessMemory(_prochandle, memadress, buffer, buffer.Length, out bytesRead);

            if (bytesRead.ToInt32() != buffer.Length)
            {
                return -1;
            }

            return BitConverter.ToSingle(buffer, 0);
        }

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