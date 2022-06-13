using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumUnresolvedMethods"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMethods = {rMethods}, pcTokens = {pcTokens}")]
    public struct EnumUnresolvedMethodsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the MemberDef tokens.
        /// </summary>
        public mdToken[] rMethods { get; }

        /// <summary>
        /// The number of MemberDef tokens returned in rMethods.
        /// </summary>
        public int pcTokens { get; }

        public EnumUnresolvedMethodsResult(IntPtr phEnum, mdToken[] rMethods, int pcTokens)
        {
            this.phEnum = phEnum;
            this.rMethods = rMethods;
            this.pcTokens = pcTokens;
        }
    }
}