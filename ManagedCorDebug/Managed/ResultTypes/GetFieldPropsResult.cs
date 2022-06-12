using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetFieldProps"/> method.
    /// </summary>
    public struct GetFieldPropsResult
    {
        /// <summary>
        /// [out] A pointer to a TypeDef token that represents the type of the class that the field belongs to.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// [out] The name of the field.
        /// </summary>
        public string szField { get; }

        /// <summary>
        /// [out] Flags associated with the field's metadata.
        /// </summary>
        public CorFieldAttr pdwAttr { get; }

        /// <summary>
        /// [out] A pointer to the binary metadata value that describes the field.
        /// </summary>
        public IntPtr ppvSigBlob { get; }

        /// <summary>
        /// [out] The size in bytes of ppvSigBlob.
        /// </summary>
        public int pcbSigBlob { get; }

        /// <summary>
        /// [out] A flag that specifies the value type of the field.
        /// </summary>
        public CorElementType pdwCPlusTypeFlag { get; }

        /// <summary>
        /// [out] A constant value for the field.
        /// </summary>
        public IntPtr ppValue { get; }

        /// <summary>
        /// [out] The size in chars of ppValue, or zero if no string exists.
        /// </summary>
        public int pcchValue { get; }

        public GetFieldPropsResult(mdTypeDef pClass, string szField, CorFieldAttr pdwAttr, IntPtr ppvSigBlob, int pcbSigBlob, CorElementType pdwCPlusTypeFlag, IntPtr ppValue, int pcchValue)
        {
            this.pClass = pClass;
            this.szField = szField;
            this.pdwAttr = pdwAttr;
            this.ppvSigBlob = ppvSigBlob;
            this.pcbSigBlob = pcbSigBlob;
            this.pdwCPlusTypeFlag = pdwCPlusTypeFlag;
            this.ppValue = ppValue;
            this.pcchValue = pcchValue;
        }
    }
}