using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetOffsetTypeId"/> method.
    /// </summary>
    [DebuggerDisplay("TypeId = {TypeId}, Module = {Module}")]
    public struct GetOffsetTypeIdResult
    {
        /// <summary>
        /// Receives the type ID of the symbol.
        /// </summary>
        public uint TypeId { get; }

        /// <summary>
        /// Specifies the location in the target's memory address space of the base of the module to which the symbol belongs.<para/>
        /// For more information, see Modules. If Module is NULL, this information is not returned.
        /// </summary>
        public ulong Module { get; }

        public GetOffsetTypeIdResult(uint typeId, ulong module)
        {
            TypeId = typeId;
            Module = module;
        }
    }
}
