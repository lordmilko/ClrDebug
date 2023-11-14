using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("guidVersion = {guidVersion.ToString(),nq}, pStream = {pStream.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct VERSIONEDSTREAM
    {
        public Guid guidVersion;
        public IntPtr pStream; //IStream
    }
}
