using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataAssemblyImport.GetAssemblyProps"/> method.
    /// </summary>
    [DebuggerDisplay("ppbPublicKey = {ppbPublicKey}, pcbPublicKey = {pcbPublicKey}, pulHashAlgId = {pulHashAlgId}, szName = {szName}, pMetaData = {pMetaData}, pdwAssemblyFlags = {pdwAssemblyFlags}")]
    public struct GetAssemblyPropsResult
    {
        /// <summary>
        /// A pointer to the public key or the metadata token.
        /// </summary>
        public IntPtr ppbPublicKey { get; }

        /// <summary>
        /// The number of bytes in the returned public key.
        /// </summary>
        public int pcbPublicKey { get; }

        /// <summary>
        /// A pointer to the algorithm used to hash the files in the assembly.
        /// </summary>
        public int pulHashAlgId { get; }

        /// <summary>
        /// The simple name of the assembly.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// A pointer to an <see cref="ASSEMBLYMETADATA"/> structure that contains the assembly metadata.
        /// </summary>
        public ASSEMBLYMETADATA pMetaData { get; }

        /// <summary>
        /// Flags that describe the metadata applied to an assembly. This value is a combination of one or more <see cref="CorAssemblyFlags"/> values.
        /// </summary>
        public CorAssemblyFlags pdwAssemblyFlags { get; }

        public GetAssemblyPropsResult(IntPtr ppbPublicKey, int pcbPublicKey, int pulHashAlgId, string szName, ASSEMBLYMETADATA pMetaData, CorAssemblyFlags pdwAssemblyFlags)
        {
            this.ppbPublicKey = ppbPublicKey;
            this.pcbPublicKey = pcbPublicKey;
            this.pulHashAlgId = pulHashAlgId;
            this.szName = szName;
            this.pMetaData = pMetaData;
            this.pdwAssemblyFlags = pdwAssemblyFlags;
        }
    }
}