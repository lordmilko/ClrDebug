using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethods"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMethods = {rMethods}")]
    public struct EnumMethodsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array to store the MethodDef tokens.
        /// </summary>
        public mdMethodDef[] rMethods { get; }

        public EnumMethodsResult(IntPtr phEnum, mdMethodDef[] rMethods)
        {
            this.phEnum = phEnum;
            this.rMethods = rMethods;
        }
    }
}