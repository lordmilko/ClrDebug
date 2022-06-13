using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethods"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMethods = {rMethods}, pcTokens = {pcTokens}")]
    public struct EnumMethodsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array to store the MethodDef tokens.
        /// </summary>
        public mdMethodDef[] rMethods { get; }

        /// <summary>
        /// The number of MethodDef tokens returned in rMethods.
        /// </summary>
        public int pcTokens { get; }

        public EnumMethodsResult(IntPtr phEnum, mdMethodDef[] rMethods, int pcTokens)
        {
            this.phEnum = phEnum;
            this.rMethods = rMethods;
            this.pcTokens = pcTokens;
        }
    }
}