using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumProperties"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rProperties = {rProperties}")]
    public struct EnumPropertiesResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the PropertyDef tokens.
        /// </summary>
        public mdProperty[] rProperties { get; }

        public EnumPropertiesResult(IntPtr phEnum, mdProperty[] rProperties)
        {
            this.phEnum = phEnum;
            this.rProperties = rProperties;
        }
    }
}