using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodImpls"/> method.
    /// </summary>
    public struct EnumMethodImplsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array to store the MethodBody tokens.
        /// </summary>
        public mdToken[] rMethodBody { get; }

        /// <summary>
        /// [out] The array to store the MethodDeclaration tokens.
        /// </summary>
        public mdToken[] rMethodDecl { get; }

        /// <summary>
        /// [in] The actual number of methods returned in rMethodBody and rMethodDecl.
        /// </summary>
        public int pcTokens { get; }

        public EnumMethodImplsResult(IntPtr phEnum, mdToken[] rMethodBody, mdToken[] rMethodDecl, int pcTokens)
        {
            this.phEnum = phEnum;
            this.rMethodBody = rMethodBody;
            this.rMethodDecl = rMethodDecl;
            this.pcTokens = pcTokens;
        }
    }
}