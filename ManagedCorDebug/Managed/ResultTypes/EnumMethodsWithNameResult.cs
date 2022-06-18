using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodsWithName"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, szName = {szName}, rMethods = {rMethods}")]
    public struct EnumMethodsWithNameResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The name that limits the scope of the enumeration.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// The array used to store the MethodDef tokens.
        /// </summary>
        public mdMethodDef[] rMethods { get; }

        public EnumMethodsWithNameResult(IntPtr phEnum, string szName, mdMethodDef[] rMethods)
        {
            this.phEnum = phEnum;
            this.szName = szName;
            this.rMethods = rMethods;
        }
    }
}