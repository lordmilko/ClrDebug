using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetMethodSpecProps"/> method.
    /// </summary>
    [DebuggerDisplay("tkParent = {tkParent.ToString(),nq}, ppvSigBlob = {ppvSigBlob.ToString(),nq}, pcbSigBlob = {pcbSigBlob}")]
    public struct GetMethodSpecPropsResult
    {
        /// <summary>
        /// A pointer to the MethodDef or MethodRef token that represents the method definition.
        /// </summary>
        public mdToken tkParent { get; }

        /// <summary>
        /// A pointer to the binary metadata signature of the method.
        /// </summary>
        public IntPtr ppvSigBlob { get; }

        /// <summary>
        /// The size, in bytes, of ppvSigBlob.
        /// </summary>
        public int pcbSigBlob { get; }

        public GetMethodSpecPropsResult(mdToken tkParent, IntPtr ppvSigBlob, int pcbSigBlob)
        {
            this.tkParent = tkParent;
            this.ppvSigBlob = ppvSigBlob;
            this.pcbSigBlob = pcbSigBlob;
        }
    }
}