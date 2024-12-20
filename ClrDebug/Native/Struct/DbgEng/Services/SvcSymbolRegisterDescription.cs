using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes a register.
    /// </summary>
    [DebuggerDisplay("Number = {Number}, Size = {Size}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcSymbolRegisterDescription
    {
        /// <summary>
        /// The register number in the architecture's canonical register numbering domain (this is the numbering scheme that is returned from ISvcRegisterInformation).<para/>
        /// Any value above 0xfffffff0 is interpreted as "invalid" -- that the symbol provider was unable to provide the information.
        /// </summary>
        public int Number;

        /// <summary>
        /// The size of the register in bytes.
        /// </summary>
        public int Size;
    }
}
