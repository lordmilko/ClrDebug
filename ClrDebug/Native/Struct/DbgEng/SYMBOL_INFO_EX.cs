using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The SYMBOL_INFO_EX structure describes the extended line symbol information.
    /// </summary>
    /// <remarks>
    /// Glue lines are code lines added to the binary by the compiler/linker. Glue lines do not have corresponding lines
    /// in the original source code. They are added to bind together functionality inside of the PE generated binary, for
    /// example calling NET framework functions inside of a native binary.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SYMBOL_INFO_EX
    {
        /// <summary>
        /// Set to sizeof(SYMBOL_INFO_EX).
        /// </summary>
        public int SizeOfStruct;

        /// <summary>
        /// Type of the symbol information stored. DEBUG_SYMINFO_BREAKPOINT_SOURCE_LINE is the only supported type.
        /// </summary>
        public DEBUG_SYMINFO TypeOfInfo;

        /// <summary>
        /// Address of the first line that does not correspond to compiler added glue line.
        /// </summary>
        public long Offset;

        /// <summary>
        /// First line number that does not correspond to a compiler added glue line.
        /// </summary>
        public int Line;

        /// <summary>
        /// Line displacement: Offset between given address and the first instruction of the line.
        /// </summary>
        public int Displacement;

        public fixed int Reserved[4];
    }
}
