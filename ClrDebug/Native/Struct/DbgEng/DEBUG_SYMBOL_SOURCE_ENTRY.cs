using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_SYMBOL_SOURCE_ENTRY structure describes a section of the source code and a corresponding region of the target's memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_SYMBOL_SOURCE_ENTRY
    {
        /// <summary>
        /// The base address, in the target's virtual address space, of the module that the source symbol came from.
        /// </summary>
        public long ModuleBase;

        /// <summary>
        /// The location of the memory corresponding to the source code in the target's virtual address space.
        /// </summary>
        public long Offset;

        /// <summary>
        /// Identifier for the source code file name. If this information is not available, FieldNameId is set to zero.
        /// </summary>
        public long FileNameId;

        /// <summary>
        /// Reserved for internal debugger engine use.
        /// </summary>
        public long EngineInternal;

        /// <summary>
        /// The size of the region of memory corresponding to the source code. If this information is not available, Size is set to one.
        /// </summary>
        public int Size;

        /// <summary>
        /// Set to zero.
        /// </summary>
        public int Flags;

        /// <summary>
        /// The number of characters in the source filename, including the terminator.
        /// </summary>
        public int FileNameSize;

        /// <summary>
        /// The line number of the start of the region of source code in the file. The number of the first line in the file is one.<para/>
        /// If this information is not available, StartLine is set to DEBUG_ANY_ID.
        /// </summary>
        public int StartLine;

        /// <summary>
        /// The line number of the end of the region of source code in the file. The number of the first line in the file is one.<para/>
        /// If this information is not available, StartLine is set to DEBUG_ANY_ID.
        /// </summary>
        public int EndLine;

        /// <summary>
        /// The column number of the start of the region of source code. The number of the first column is one. If this information is not available, StartLine is set to DEBUG_ANY_ID.
        /// </summary>
        public int StartColumn;

        /// <summary>
        /// The column number of the end of the region of source code. The number of the first column is one. If this information is not available, StartLine is set to DEBUG_ANY_ID.
        /// </summary>
        public int EndColumn;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public int Reserved;
    }
}
