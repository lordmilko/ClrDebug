using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugAdvanced.GetSymbolInformationWide"/> method.
    /// </summary>
    [DebuggerDisplay("InfoSize = {InfoSize}, StringBuffer = {StringBuffer}")]
    public struct GetSymbolInformationWideResult
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

        public GetSymbolInformationWideResult(int infoSize, string stringBuffer)
        {
            InfoSize = infoSize;
            StringBuffer = stringBuffer;
        }
    }
}
