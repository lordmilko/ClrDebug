using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("dwLowDateTime = {dwLowDateTime}, dwHighDateTime = {dwHighDateTime}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct FILETIME
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;

        public override string ToString()
        {
            return DateTime.FromFileTime((long) dwHighDateTime << 32 | (long) dwLowDateTime).ToString();
        }
    }
}
