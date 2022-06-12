using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumProperties"/> method.
    /// </summary>
    public struct EnumPropertiesResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array used to store the PropertyDef tokens.
        /// </summary>
        public mdProperty[] rProperties { get; }

        /// <summary>
        /// [out] The number of PropertyDef tokens returned in rProperties.
        /// </summary>
        public int pcProperties { get; }

        public EnumPropertiesResult(IntPtr phEnum, mdProperty[] rProperties, int pcProperties)
        {
            this.phEnum = phEnum;
            this.rProperties = rProperties;
            this.pcProperties = pcProperties;
        }
    }
}