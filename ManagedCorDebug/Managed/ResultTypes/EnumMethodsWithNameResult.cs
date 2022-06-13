using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodsWithName"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, szName = {szName}, rMethods = {rMethods}, pcTokens = {pcTokens}")]
    public struct EnumMethodsWithNameResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The name that limits the scope of the enumeration.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// The array used to store the MethodDef tokens.
        /// </summary>
        public mdMethodDef[] rMethods { get; }

        /// <summary>
        /// The number of MethodDef tokens returned in rMethods.
        /// </summary>
        public int pcTokens { get; }

        public EnumMethodsWithNameResult(IntPtr phEnum, string szName, mdMethodDef[] rMethods, int pcTokens)
        {
            this.phEnum = phEnum;
            this.szName = szName;
            this.rMethods = rMethods;
            this.pcTokens = pcTokens;
        }
    }
}