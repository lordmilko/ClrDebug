using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataAssemblyImport.GetAssemblyRefProps"/> method.
    /// </summary>
    [DebuggerDisplay("ppbPublicKeyOrToken = {ppbPublicKeyOrToken}, pcbPublicKeyOrToken = {pcbPublicKeyOrToken}, szName = {szName}, pMetaData = {pMetaData}, ppbHashValue = {ppbHashValue}, pcbHashValue = {pcbHashValue}, pdwAssemblyFlags = {pdwAssemblyFlags}")]
    public struct GetAssemblyRefPropsResult
    {
        /// <summary>
        /// A pointer to the public key or the metadata token.
        /// </summary>
        public IntPtr ppbPublicKeyOrToken { get; }

        /// <summary>
        /// The number of bytes in the returned public key or token.
        /// </summary>
        public int pcbPublicKeyOrToken { get; }

        /// <summary>
        /// The simple name of the assembly.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// A pointer to an <see cref="ASSEMBLYMETADATA"/> structure that contains the assembly metadata.
        /// </summary>
        public ASSEMBLYMETADATA pMetaData { get; }

        /// <summary>
        /// A pointer to the hash value. This is the hash, using the SHA-1 algorithm, of the PublicKey property of the assembly being referenced, unless the arfFullOriginator flag of the <see cref="AssemblyRefFlags"/> enumeration is set.
        /// </summary>
        public IntPtr ppbHashValue { get; }

        /// <summary>
        /// The number of wide chars in the returned hash value.
        /// </summary>
        public int pcbHashValue { get; }

        /// <summary>
        /// A pointer to flags that describe the metadata applied to an assembly. The flags value is a combination of one or more <see cref="CorAssemblyFlags"/> values.
        /// </summary>
        public CorAssemblyFlags pdwAssemblyFlags { get; }

        public GetAssemblyRefPropsResult(IntPtr ppbPublicKeyOrToken, int pcbPublicKeyOrToken, string szName, ASSEMBLYMETADATA pMetaData, IntPtr ppbHashValue, int pcbHashValue, CorAssemblyFlags pdwAssemblyFlags)
        {
            this.ppbPublicKeyOrToken = ppbPublicKeyOrToken;
            this.pcbPublicKeyOrToken = pcbPublicKeyOrToken;
            this.szName = szName;
            this.pMetaData = pMetaData;
            this.ppbHashValue = ppbHashValue;
            this.pcbHashValue = pcbHashValue;
            this.pdwAssemblyFlags = pdwAssemblyFlags;
        }
    }
}