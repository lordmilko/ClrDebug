using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetMethodProps"/> method.
    /// </summary>
    [DebuggerDisplay("pClass = {pClass}, szMethod = {szMethod}, pdwAttr = {pdwAttr}, ppvSigBlob = {ppvSigBlob}, pcbSigBlob = {pcbSigBlob}, pulCodeRVA = {pulCodeRVA}, pdwImplFlags = {pdwImplFlags}")]
    public struct MetaDataImport_GetMethodPropsResult
    {
        /// <summary>
        /// [out] A Pointer to a TypeDef token that represents the type that implements the method.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// [out] A Pointer to a buffer that has the method's name.
        /// </summary>
        public string szMethod { get; }

        /// <summary>
        /// [out] A pointer to any flags associated with the method.
        /// </summary>
        public CorMethodAttr pdwAttr { get; }

        /// <summary>
        /// [out] A pointer to the binary metadata signature of the method.
        /// </summary>
        public IntPtr ppvSigBlob { get; }

        /// <summary>
        /// [out] A Pointer to the size in bytes of ppvSigBlob.
        /// </summary>
        public int pcbSigBlob { get; }

        /// <summary>
        /// [out] A pointer to the relative virtual address of the method.
        /// </summary>
        public int pulCodeRVA { get; }

        /// <summary>
        /// [out] A pointer to any implementation flags for the method.
        /// </summary>
        public int pdwImplFlags { get; }

        public MetaDataImport_GetMethodPropsResult(mdTypeDef pClass, string szMethod, CorMethodAttr pdwAttr, IntPtr ppvSigBlob, int pcbSigBlob, int pulCodeRVA, int pdwImplFlags)
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