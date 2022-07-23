using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugDataSpaces.GetNextTagged"/> method.
    /// </summary>
    [DebuggerDisplay("Tag = {Tag.ToString(),nq}, Size = {Size}")]
    public struct GetNextTaggedResult
    {
        /// <summary>
        /// Receives the GUID identifying the tagged data. The data may be retrieved by passing this GUID to <see cref="DebugDataSpaces.ReadTagged"/>.
        /// </summary>
        public Guid Tag { get; }

        /// <summary>
        /// Receives the size of the data identified by the GUID Tag.
        /// </summary>
        public int Size { get; }

        public GetNextTaggedResult(Guid tag, int size)
        {
            Tag = tag;
            Size = size;
        }
    }
}
