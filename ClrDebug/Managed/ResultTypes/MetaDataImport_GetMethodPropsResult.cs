using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetMethodProps"/> method.
    /// </summary>
    [DebuggerDisplay("pClass = {pClass.ToString(),nq}, szMethod = {szMethod}, pdwAttr = {pdwAttr.ToString(),nq}, ppvSigBlob = {ppvSigBlob.ToString(),nq}, pcbSigBlob = {pcbSigBlob}, pulCodeRVA = {pulCodeRVA}, pdwImplFlags = {pdwImplFlags.ToString(),nq}")]
    public struct MetaDataImport_GetMethodPropsResult
    {
        /// <summary>
        /// A Pointer to a TypeDef token that represents the type that implements the method.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// A Pointer to a buffer that has the method's name.
        /// </summary>
        public string szMethod { get; }

        /// <summary>
        /// A pointer to any flags associated with the method.
        /// </summary>
        public CorMethodAttr pdwAttr { get; }

        /// <summary>
        /// A pointer to the binary metadata signature of the method.
        /// </summary>
        public IntPtr ppvSigBlob { get; }

        /// <summary>
        /// A Pointer to the size in bytes of ppvSigBlob.
        /// </summary>
        public int pcbSigBlob { get; }

        /// <summary>
        /// A pointer to the relative virtual address of the method.
        /// </summary>
        public int pulCodeRVA { get; }

        /// <summary>
        /// A pointer to any implementation flags for the method.
        /// </summary>
        public CorMethodImpl pdwImplFlags { get; }

        public MetaDataImport_GetMethodPropsResult(mdTypeDef pClass, string szMethod, CorMethodAttr pdwAttr, IntPtr ppvSigBlob, int pcbSigBlob, int pulCodeRVA, CorMethodImpl pdwImplFlags)
        {
            this.pClass = pClass;
            this.szMethod = szMethod;
            this.pdwAttr = pdwAttr;
            this.ppvSigBlob = ppvSigBlob;
            this.pcbSigBlob = pcbSigBlob;
            this.pulCodeRVA = pulCodeRVA;
            this.pdwImplFlags = pdwImplFlags;
        }
    }
}
