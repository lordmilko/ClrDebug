using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetFieldMarshal"/> method.
    /// </summary>
    [DebuggerDisplay("ppvNativeType = {ppvNativeType.ToString(),nq}, pcbNativeType = {pcbNativeType}")]
    public struct GetFieldMarshalResult
    {
        /// <summary>
        /// A pointer to the metadata signature of the field's native type.
        /// </summary>
        public IntPtr ppvNativeType { get; }

        /// <summary>
        /// The size in bytes of ppvNativeType.
        /// </summary>
        public int pcbNativeType { get; }

        public GetFieldMarshalResult(IntPtr ppvNativeType, int pcbNativeType)
        {
            this.ppvNativeType = ppvNativeType;
            this.pcbNativeType = pcbNativeType;
        }
    }
}