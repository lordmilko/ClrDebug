using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetMethodSpecProps"/> method.
    /// </summary>
    public struct GetMethodSpecPropsResult
    {
        /// <summary>
        /// [out] A pointer to the MethodDef or MethodRef token that represents the method definition.
        /// </summary>
        public mdToken tkParent { get; }

        /// <summary>
        /// [out] A pointer to the binary metadata signature of the method.
        /// </summary>
        public IntPtr ppvSigBlob { get; }

        /// <summary>
        /// [out] The size, in bytes, of ppvSigBlob.
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