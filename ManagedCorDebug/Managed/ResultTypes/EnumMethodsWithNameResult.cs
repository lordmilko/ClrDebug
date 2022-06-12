using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodsWithName"/> method.
    /// </summary>
    public struct EnumMethodsWithNameResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [in] The name that limits the scope of the enumeration.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// [out] The array used to store the MethodDef tokens.
        /// </summary>
        public mdMethodDef[] rMethods { get; }

        /// <summary>
        /// [out] The number of MethodDef tokens returned in rMethods.
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