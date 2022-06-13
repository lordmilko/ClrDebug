using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumInterfaceImpls"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rImpls = {rImpls}, pcImpls = {pcImpls}")]
    public struct EnumInterfaceImplsResult
    {
        /// <summary>
        /// A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the MethodDef tokens.
        /// </summary>
        public mdInterfaceImpl[] rImpls { get; }

        /// <summary>
        /// The actual number of tokens returned in rImpls.
        /// </summary>
        public int pcImpls { get; }

        public EnumInterfaceImplsResult(IntPtr phEnum, mdInterfaceImpl[] rImpls, int pcImpls)
        {
            this.phEnum = phEnum;
            this.rImpls = rImpls;
            this.pcImpls = pcImpls;
        }
    }
}