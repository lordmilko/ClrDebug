using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="TypeInfo.GetDllEntry"/> method.
    /// </summary>
    [DebuggerDisplay("pBstrDllName = {pBstrDllName}, pBstrName = {pBstrName}, pwOrdinal = {pwOrdinal}")]
    public struct GetDllEntryResult
    {
        /// <summary>
        /// If not null, the function sets pBstrDllName to a BSTR that contains the name of the DLL.
        /// </summary>
        public string pBstrDllName { get; }

        /// <summary>
        /// If not null, the function sets lpbstrName to a BSTR that contains the name of the entry point.
        /// </summary>
        public string pBstrName { get; }

        /// <summary>
        /// If not null, and the function is defined by an ordinal, then lpwOrdinal is set to point to the ordinal.
        /// </summary>
        public short pwOrdinal { get; }

        public GetDllEntryResult(string pBstrDllName, string pBstrName, short pwOrdinal)
        {
            this.pBstrDllName = pBstrDllName;
            this.pBstrName = pBstrName;
            this.pwOrdinal = pwOrdinal;
        }
    }
}
