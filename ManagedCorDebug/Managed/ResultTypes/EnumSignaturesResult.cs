using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumSignatures"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rSignatures = {rSignatures}, pcSignatures = {pcSignatures}")]
    public struct EnumSignaturesResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array used to store the Signature tokens.
        /// </summary>
        public mdSignature[] rSignatures { get; }

        /// <summary>
        /// [out] The number of Signature tokens returned in rSignatures.
        /// </summary>
        public int pcSignatures { get; }

        public EnumSignaturesResult(IntPtr phEnum, mdSignature[] rSignatures, int pcSignatures)
        {
            this.phEnum = phEnum;
            this.rSignatures = rSignatures;
            this.pcSignatures = pcSignatures;
        }
    }
}