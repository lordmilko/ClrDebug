using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugAdvanced.GetSymbolInformation"/> method.
    /// </summary>
    [DebuggerDisplay("StringBuffer = {StringBuffer}, StringSize = {StringSize}")]
    public struct GetSymbolInformationResult
    {
        /// <summary>
        /// Receives the requested string. The interpretation of this string depends on the value of Which.<para/>
        /// If StringBuffer is NULL, this information is not returned.
        /// </summary>
        public string StringBuffer { get; }

        /// <summary>
        /// Receives the size, in characters, of the string returned to StringBuffer. If StringSize is NULL, this information is not returned.
        /// </summary>
        public int StringSize { get; }

        public GetSymbolInformationResult(string stringBuffer, int stringSize)
        {
            StringBuffer = stringBuffer;
            StringSize = stringSize;
        }
    }
}
