using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumSignatures"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rSignatures = {rSignatures}")]
    public struct EnumSignaturesResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the Signature tokens.
        /// </summary>
        public mdSignature[] rSignatures { get; }

        public EnumSignaturesResult(IntPtr phEnum, mdSignature[] rSignatures)
        {
            this.phEnum = phEnum;
            this.rSignatures = rSignatures;
        }
    }
}