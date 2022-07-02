using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetMemberProps"/> method.
    /// </summary>
    [DebuggerDisplay("pClass = {pClass.ToString(),nq}, szMember = {szMember}, pdwAttr = {pdwAttr}, ppvSigBlob = {ppvSigBlob.ToString(),nq}, pcbSigBlob = {pcbSigBlob}, pulCodeRVA = {pulCodeRVA}, pdwImplFlags = {pdwImplFlags}, pdwCPlusTypeFlag = {pdwCPlusTypeFlag.ToString(),nq}, ppValue = {ppValue.ToString(),nq}, pcchValue = {pcchValue}")]
    public struct GetMemberPropsResult
    {
        /// <summary>
        /// A pointer to the metadata token that represents the class of the member.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// The name of the member.
        /// </summary>
        public string szMember { get; }

        /// <summary>
        /// Any flag values applied to the member. If the member is a <see cref="mdMethodDef"/> this value is a bitwise combination of <see cref="CorMethodAttr"/> values. Otherwise, it is a bitwise combination of <see cref="CorFieldAttr"/> values.
        /// </summary>
        public int pdwAttr { get; }

        /// <summary>
        /// A pointer to the binary metadata signature of the member.
        /// </summary>
        public IntPtr ppvSigBlob { get; }

        /// <summary>
        /// The size in bytes of ppvSigBlob.
        /// </summary>
        public int pcbSigBlob { get; }

        /// <summary>
        /// A pointer to the relative virtual address of the member.
        /// </summary>
        public int pulCodeRVA { get; }

        /// <summary>
        /// Any method implementation flags associated with the member. If the member is an <see cref="mdMethodDef"/> these flags are a bitwise combination of <see cref="CorMethodImpl"/> values.
        /// </summary>
        public int pdwImplFlags { get; }

        /// <summary>
        /// A flag that marks a <see cref="ValueType"/>. It is one of the ELEMENT_TYPE_* values.
        /// </summary>
        public CorElementType pdwCPlusTypeFlag { get; }

        /// <summary>
        /// A constant string value returned by this member.
        /// </summary>
        public IntPtr ppValue { get; }

        /// <summary>
        /// The size in characters of ppValue, or zero if ppValue does not hold a string.
        /// </summary>
        public int pcchValue { get; }

        public GetMemberPropsResult(mdTypeDef pClass, string szMember, int pdwAttr, IntPtr ppvSigBlob, int pcbSigBlob, int pulCodeRVA, int pdwImplFlags, CorElementType pdwCPlusTypeFlag, IntPtr ppValue, int pcchValue)
        {
            this.pClass = pClass;
            this.szMember = szMember;
            this.pdwAttr = pdwAttr;
            this.ppvSigBlob = ppvSigBlob;
            this.pcbSigBlob = pcbSigBlob;
            this.pulCodeRVA = pulCodeRVA;
            this.pdwImplFlags = pdwImplFlags;
            this.pdwCPlusTypeFlag = pdwCPlusTypeFlag;
            this.ppValue = ppValue;
            this.pcchValue = pcchValue;
        }
    }
}