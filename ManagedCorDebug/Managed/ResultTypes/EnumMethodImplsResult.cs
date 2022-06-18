using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodImpls"/> method.
    /// </summary>
    [DebuggerDisplay("rMethodBody = {rMethodBody}, rMethodDecl = {rMethodDecl}")]
    public struct EnumMethodImplsResult
    {
        /// <summary>
        /// The array to store the MethodBody tokens.
        /// </summary>
        public mdToken[] rMethodBody { get; }

        /// <summary>
        /// The array to store the MethodDeclaration tokens.
        /// </summary>
        public mdToken[] rMethodDecl { get; }

        public EnumMethodImplsResult(mdToken[] rMethodBody, mdToken[] rMethodDecl)
        {
            this.rMethodBody = rMethodBody;
            this.rMethodDecl = rMethodDecl;
        }
    }
}