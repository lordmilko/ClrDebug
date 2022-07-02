using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataAssemblyImport.GetFileProps"/> method.
    /// </summary>
    [DebuggerDisplay("szName = {szName}, ppbHashValue = {ppbHashValue.ToString(),nq}, pcbHashValue = {pcbHashValue}, pdwFileFlags = {pdwFileFlags.ToString(),nq}")]
    public struct GetFilePropsResult
    {
        /// <summary>
        /// The simple name of the file.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// A pointer to the hash value. This is the hash, using the SHA-1 algorithm, of the file.
        /// </summary>
        public IntPtr ppbHashValue { get; }

        /// <summary>
        /// The number of wide chars in the returned hash value.
        /// </summary>
        public int pcbHashValue { get; }

        /// <summary>
        /// A pointer to the flags that describe the metadata applied to a file. The flags value is a combination of one or more <see cref="CorFileFlags"/> values.
        /// </summary>
        public CorFileFlags pdwFileFlags { get; }

        public GetFilePropsResult(string szName, IntPtr ppbHashValue, int pcbHashValue, CorFileFlags pdwFileFlags)
        {
            this.szName = szName;
            this.ppbHashValue = ppbHashValue;
            this.pcbHashValue = pcbHashValue;
            this.pdwFileFlags = pdwFileFlags;
        }
    }
}