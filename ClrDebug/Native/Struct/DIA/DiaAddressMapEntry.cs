using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Describes an entry in an address map.
    /// </summary>
    [DebuggerDisplay("rva = {rva}, rvaTo = {rvaTo}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct DiaAddressMapEntry
    {
        /// <summary>
        /// A relative virtual address (RVA) in image A.
        /// </summary>
        public int rva;

        /// <summary>
        /// The relative virtual address rva is mapped to in image B.
        /// </summary>
        public int rvaTo;
    }
}
