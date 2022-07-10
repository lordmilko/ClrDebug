using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetSymbolEntriesByOffset"/> method.
    /// </summary>
    [DebuggerDisplay("Ids = {Ids}, Displacements = {Displacements}")]
    public struct GetSymbolEntriesByOffsetResult
    {
        /// <summary>
        /// Receives the symbols. This is an array of IdsCount entries of type <see cref="DEBUG_MODULE_AND_ID"/>.<para/>
        /// If Ids is NULL, this information is not returned.
        /// </summary>
        public DEBUG_MODULE_AND_ID[] Ids { get; }

        /// <summary>
        /// Receives the differences between the base addresses of the found symbols and the given address according to the symbol's range.
        /// </summary>
        public ulong[] Displacements { get; }

        public GetSymbolEntriesByOffsetResult(DEBUG_MODULE_AND_ID[] ids, ulong[] displacements)
        {
            Ids = ids;
            Displacements = displacements;
        }
    }
}
