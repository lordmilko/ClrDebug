using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetMemberProps"/> method.
    /// </summary>
    [DebuggerDisplay("pClass = {pClass}, szMember = {szMember}, pdwAttr = {pdwAttr}, ppvSigBlob = {ppvSigBlob}, pcbSigBlob = {pcbSigBlob}, pulCodeRVA = {pulCodeRVA}, pdwImplFlags = {pdwImplFlags}, pdwCPlusTypeFlag = {pdwCPlusTypeFlag}, ppValue = {ppValue}, pcchValue = {pcchValue}")]
    public struct GetMemberPropsResult
    {
        /// <summary>
        /// [out] A pointer to the metadata token that represents the class of the member.
        /// </summary>
        public mdTypeDef pClass { get; }

        /// <summary>
        /// [out] The name of the member.
        /// </summary>
        public string szMember { get; }

        /// <summary>
        /// [out] Any flag values applied to the member.
        /// </summary>
        public int pdwAttr { get; }

        /// <summary>
        /// [out] A pointer to the binary metadata signature of the member.
        /// </summary>
        public IntPtr ppvSigBlob { get; }

        /// <summary>
        /// [out] The size in bytes of ppvSigBlob.
        /// </summary>
        public int pcbSigBlob { get; }

        /// <summary>
        /// [out] A pointer to the relative virtual address of the member.
        /// </summary>
        public int pulCodeRVA { get; }

        /// <summary>
        /// [out] Any method implementation flags associated with the member.
        /// </summary>
        public int pdwImplFlags { get; }

        /// <summary>
        /// [out] A flag that marks a <see cref="ValueType"/>. It is one of the ELEMENT_TYPE_* values.
        /// </summary>
        public CorElementType pdwCPlusTypeFlag { get; }

        /// <summary>
        /// [out] A constant string value returned by this member.
        /// </summary>
        public IntPtr ppValue { get; }

        /// <summary>
        /// [out] The size in characters of ppValue, or zero if ppValue does not hold a string.
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