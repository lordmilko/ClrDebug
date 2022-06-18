using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumInterfaceImpls"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rImpls = {rImpls}")]
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

        public EnumInterfaceImplsResult(IntPtr phEnum, mdInterfaceImpl[] rImpls)
        {
            this.phEnum = phEnum;
            this.rImpls = rImpls;
        }
    }
}