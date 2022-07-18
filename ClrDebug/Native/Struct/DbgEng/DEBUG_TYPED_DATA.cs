using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_TYPED_DATA structure describes typed data in the memory of the target.
    /// </summary>
    /// <remarks>
    /// Instances of this structure should be manipulated using the DEBUG_REQUEST_EXT_TYPED_DATA_ANSI Request operation.
    /// In particular, instances should be created and released using this method, and members of this structure should
    /// not be changed directly. There is one exception to the preceding rule: the EXT_TDOP_SET_FROM_TYPE_ID_AND_U64 and
    /// EXT_TDOP_SET_PTR_FROM_TYPE_ID_AND_U64 suboperations take a DEBUG_TYPED_DATA instance that is not manipulated using
    /// the Request method. These suboperations take a manually created instance with some members manually filled in.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DEBUG_TYPED_DATA
    {
        /// <summary>
        /// The base address of the module, in the target's virtual address space, that contains the typed data.
        /// </summary>
        public ulong ModBase;

        /// <summary>
        /// The location of the typed data in the target's memory. Offset is a virtual memory address unless there are flags present in Flags that specify that Offset is a physical memory address.
        /// </summary>
        public ulong Offset;

        /// <summary>
        /// Set to zero.
        /// </summary>
        public ulong EngineHandle;

        /// <summary>
        /// The data cast to a ULONG64. If Flags does not contain the DEBUG_TYPED_DATA_IS_IN_MEMORY flag, the data is not available and Data is set to zero.
        /// </summary>
        public ulong Data;

        /// <summary>
        /// The size, in bytes, of the data.
        /// </summary>
        public uint Size;

        /// <summary>
        /// The flags describing the target's memory in which the data resides. The following bit flags can be set.
        /// </summary>
        public DEBUG_TYPED_DATA_TYPE Flags;

        /// <summary>
        /// The type ID for the data's type.
        /// </summary>
        public uint TypeId;

        /// <summary>
        /// For generated types, the type ID of the type on which the data's type is based. For example, if the typed data represents a pointer (or an array), BaseTypeId is the type of the object pointed to (or held in the array).<para/>
        /// For other types, BaseTypeId is the same as TypeId.
        /// </summary>
        public uint BaseTypeId;

        /// <summary>
        /// The symbol tag of the typed data. This is a value from the SymTagEnum enumeration. For descriptions of the values, see the DbgHelp API documentation.
        /// </summary>
        public SymTagEnum Tag;

        /// <summary>
        /// The index of the processor's register containing the data, or zero if the data is not contained in a register. (Note that the zero value can represent either that the data is not in a register or that it is in the register whose index is zero.)
        /// </summary>
        public uint Register;

        /// <summary>
        /// Internal debugger engine data.
        /// </summary>
        public fixed ulong Internal[9];
    }
}