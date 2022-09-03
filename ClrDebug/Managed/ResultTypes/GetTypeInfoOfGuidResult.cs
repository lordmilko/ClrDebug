using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ComTypeLib.TypeInfoOfGuid"/> property.
    /// </summary>
    [DebuggerDisplay("guid = {guid.ToString(),nq}, ppTInfo = {ppTInfo.ToString(),nq}")]
    public struct GetTypeInfoOfGuidResult
    {
        /// <summary>
        /// The IID of the interface or CLSID of the class whose type info is requested.
        /// </summary>
        public Guid guid { get; }

        /// <summary>
        /// When this method returns, contains the requested <see cref="ITypeInfo"/> interface. This parameter is passed uninitialized.
        /// </summary>
        public TypeInfo ppTInfo { get; }

        public GetTypeInfoOfGuidResult(Guid guid, TypeInfo ppTInfo)
        {
            this.guid = guid;
            this.ppTInfo = ppTInfo;
        }
    }
}
