using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetSymbolTypeIdWide"/> method.
    /// </summary>
    [DebuggerDisplay("TypeId = {TypeId}, Module = {Module}")]
    public struct GetSymbolTypeIdWideResult
    {
        /// <summary>
        /// Receives the type ID.
        /// </summary>
        public int TypeId { get; }

        /// <summary>
        /// Receives the base address of the module containing the symbol. For more information, see Modules.<para/>
        /// If Module is NULL, this information is not returned.
        /// </summary>
        public long Module { get; }

        public GetSymbolTypeIdWideResult(int typeId, long module)
        {
            TypeId = typeId;
            Module = module;
        }
    }
}
