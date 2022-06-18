using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumCustomAttributes"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rCustomAttributes = {rCustomAttributes}")]
    public struct EnumCustomAttributesResult
    {
        /// <summary>
        /// A pointer to the returned enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// An array of custom attribute tokens.
        /// </summary>
        public mdCustomAttribute[] rCustomAttributes { get; }

        public EnumCustomAttributesResult(IntPtr phEnum, mdCustomAttribute[] rCustomAttributes)
        {
            this.phEnum = phEnum;
            this.rCustomAttributes = rCustomAttributes;
        }
    }
}