using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetFieldProps"/> method.
    /// </summary>
    [DebuggerDisplay("pClass = {pClass.ToString(),nq}, szField = {szField}, pdwAttr = {pdwAttr.ToString(),nq}, ppvSigBlob = {ppvSigBlob.ToString(),nq}, pcbSigBlob = {pcbSigBlob}, pdwCPlusTypeFlag = {pdwCPlusTypeFlag.ToString(),nq}, ppValue = {ppValue.ToString(),nq}, pcchValue = {pcchValue}")]
    public struct GetFieldPropsResult
    {
        /// <summary>
        /// A pointer to a TypeDef token that represents the type of the class that the field belongs to.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// The name of the field.
        /// </summary>
        public string szField { get; }

        /// <summary>
        /// Flags associated with the field's metadata.
        /// </summary>
        public CorFieldAttr pdwAttr { get; }

        /// <summary>
        /// A pointer to the binary metadata value that describes the field.
        /// </summary>
        public IntPtr ppvSigBlob { get; }

        /// <summary>
        /// The size in bytes of ppvSigBlob.
        /// </summary>
        public int pcbSigBlob { get; }

        /// <summary>
        /// A flag that specifies the value type of the field.
        /// </summary>
        public CorElementType pdwCPlusTypeFlag { get; }

        /// <summary>
        /// A constant value for the field.
        /// </summary>
        public IntPtr ppValue { get; }

        /// <summary>
        /// The size in chars of ppValue, or zero if no string exists.
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
