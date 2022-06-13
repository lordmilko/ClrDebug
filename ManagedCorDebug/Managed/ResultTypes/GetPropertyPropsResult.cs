using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetPropertyProps"/> method.
    /// </summary>
    [DebuggerDisplay("pClass = {pClass}, szProperty = {szProperty}, pdwPropFlags = {pdwPropFlags}, ppvSig = {ppvSig}, pbSig = {pbSig}, pdwCPlusTypeFlag = {pdwCPlusTypeFlag}, ppDefaultValue = {ppDefaultValue}, pcchDefaultValue = {pcchDefaultValue}, pmdSetter = {pmdSetter}, pmdGetter = {pmdGetter}, rmdOtherMethod = {rmdOtherMethod}")]
    public struct GetPropertyPropsResult
    {
        /// <summary>
        /// A pointer to the TypeDef token that represents the type that implements the property.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// A buffer to hold the property name.
        /// </summary>
        public string szProperty { get; }

        /// <summary>
        /// A pointer to any attribute flags applied to the property. This value is a bitmask from the <see cref="CorPropertyAttr"/> enumeration.
        /// </summary>
        public CorPropertyAttr pdwPropFlags { get; }

        /// <summary>
        /// A pointer to the metadata signature of the property.
        /// </summary>
        public IntPtr ppvSig { get; }

        /// <summary>
        /// The number of bytes returned in ppvSig.
        /// </summary>
        public int pbSig { get; }

        /// <summary>
        /// A flag specifying the type of the constant that is the default value of the property. This value is from the <see cref="CorElementType"/> enumeration.
        /// </summary>
        public CorElementType pdwCPlusTypeFlag { get; }

        /// <summary>
        /// A pointer to the bytes that store the default value for this property.
        /// </summary>
        public IntPtr ppDefaultValue { get; }

        /// <summary>
        /// The size in wide characters of ppDefaultValue, if pdwCPlusTypeFlag is ELEMENT_TYPE_STRING; otherwise, this value is not relevant.<para/>
        /// In that case, the length of ppDefaultValue is inferred from the type that is specified by pdwCPlusTypeFlag.
        /// </summary>
        public int pcchDefaultValue { get; }

        /// <summary>
        /// A pointer to the MethodDef token that represents the set accessor method for the property.
        /// </summary>
        public mdMethodDef pmdSetter { get; }

        /// <summary>
        /// A pointer to the MethodDef token that represents the get accessor method for the property.
        /// </summary>
        public mdMethodDef pmdGetter { get; }

        /// <summary>
        /// An array of MethodDef tokens that represent other methods associated with the property.
        /// </summary>
        public mdMethodDef[] rmdOtherMethod { get; }

        public GetPropertyPropsResult(mdTypeDef pClass, string szProperty, CorPropertyAttr pdwPropFlags, IntPtr ppvSig, int pbSig, CorElementType pdwCPlusTypeFlag, IntPtr ppDefaultValue, int pcchDefaultValue, mdMethodDef pmdSetter, mdMethodDef pmdGetter, mdMethodDef[] rmdOtherMethod)
        {
            this.pClass = pClass;
            this.szProperty = szProperty;
            this.pdwPropFlags = pdwPropFlags;
            this.ppvSig = ppvSig;
            this.pbSig = pbSig;
            this.pdwCPlusTypeFlag = pdwCPlusTypeFlag;
            this.ppDefaultValue = ppDefaultValue;
            this.pcchDefaultValue = pcchDefaultValue;
            this.pmdSetter = pmdSetter;
            this.pmdGetter = pmdGetter;
            this.rmdOtherMethod = rmdOtherMethod;
        }
    }
}