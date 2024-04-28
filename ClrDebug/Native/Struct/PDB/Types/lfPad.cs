using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for pad leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct lfPad
    {
        public byte leaf;
    }
}
