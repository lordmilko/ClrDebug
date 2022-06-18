using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodImpls"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMethodBody = {rMethodBody}, rMethodDecl = {rMethodDecl}")]
    public struct EnumMethodImplsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array to store the MethodBody tokens.
        /// </summary>
        public mdToken[] rMethodBody { get; }

        /// <summary>
        /// The array to store the MethodDeclaration tokens.
        /// </summary>
        public mdToken[] rMethodDecl { get; }

        public EnumMethodImplsResult(IntPtr phEnum, mdToken[] rMethodBody, mdToken[] rMethodDecl)
        {
            this.phEnum = phEnum;
            this.rMethodBody = rMethodBody;
            this.rMethodDecl = rMethodDecl;
        }
    }
}