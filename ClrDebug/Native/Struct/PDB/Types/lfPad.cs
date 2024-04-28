using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for pad leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf}")]
    public struct lfPad
    {
        public byte leaf;
    }
}
