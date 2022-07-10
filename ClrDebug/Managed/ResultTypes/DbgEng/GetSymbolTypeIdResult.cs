using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetSymbolTypeId"/> method.
    /// </summary>
    [DebuggerDisplay("TypeId = {TypeId}, Module = {Module}")]
    public struct GetSymbolTypeIdResult
    {
        /// <summary>
        /// Receives the type ID.
        /// </summary>
        public uint TypeId { get; }

        /// <summary>
        /// Receives the base address of the module containing the symbol. For more information, see Modules.<para/>
        /// If Module is NULL, this information is not returned.
        /// </summary>
        public ulong Module { get; }

        public GetSymbolTypeIdResult(uint typeId, ulong module)
        {
            TypeId = typeId;
            Module = module;
        }
    }
}
