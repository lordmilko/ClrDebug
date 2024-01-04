using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugAdvanced.GetSymbolInformationWideEx"/> method.
    /// </summary>
    [DebuggerDisplay("InfoSize = {InfoSize}, StringBuffer = {StringBuffer}, pInfoEx = {pInfoEx.ToString(),nq}")]
    public struct GetSymbolInformationWideExResult
    {
        /// <summary>
        /// If this method returns S_OK, InfoSize receives the size, in bytes, of the symbol information returned to Buffer.<para/>
        /// If this method returns S_FALSE, the supplied buffer is not big enough, and InfoSize receives the required buffer size.<para/>
        /// If InfoSize is NULL, this information is not returned.
        /// </summary>
        public int InfoSize { get; }

        /// <summary>
        /// Receives the requested string. The interpretation of this string depends on the value of Which.<para/>
        /// If StringBuffer is NULL, this information is not returned.
        /// </summary>
        public string StringBuffer { get; }

        /// <summary>
        /// A pointer to a <see cref="SYMBOL_INFO_EX"/> structure.
        /// </summary>
        public SYMBOL_INFO_EX pInfoEx { get; }

        public GetSymbolInformationWideExResult(int infoSize, string stringBuffer, SYMBOL_INFO_EX pInfoEx)
        {
            InfoSize = infoSize;
            StringBuffer = stringBuffer;
            this.pInfoEx = pInfoEx;
        }
    }
}
