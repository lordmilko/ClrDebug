using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetParamProps"/> method.
    /// </summary>
    [DebuggerDisplay("pmd = {pmd.ToString(),nq}, pulSequence = {pulSequence}, szName = {szName}, pdwAttr = {pdwAttr.ToString(),nq}, pdwCPlusTypeFlag = {pdwCPlusTypeFlag.ToString(),nq}, ppValue = {ppValue.ToString(),nq}, pcchValue = {pcchValue}")]
    public struct GetParamPropsResult
    {
        /// <summary>
        /// A pointer to a MethodDef token representing the method that takes the parameter.
        /// </summary>
        public mdMethodDef pmd { get; }

        /// <summary>
        /// The ordinal position of the parameter in the method argument list.
        /// </summary>
        public int pulSequence { get; }

        /// <summary>
        /// A buffer to hold the name of the parameter.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// A pointer to any attribute flags associated with the parameter. This is a bitmask of <see cref="CorParamAttr"/> values.
        /// </summary>
        public CorParamAttr pdwAttr { get; }

        /// <summary>
        /// A pointer to a flag specifying that the parameter is a <see cref="ValueType"/>.
        /// </summary>
        public CorElementType pdwCPlusTypeFlag { get; }

        /// <summary>
        /// A pointer to a constant string returned by the parameter.
        /// </summary>
        public IntPtr ppValue { get; }

        /// <summary>
        /// The size of ppValue in wide characters, or zero if ppValue does not hold a string.
        /// </summary>
        public int pcchValue { get; }

        public GetParamPropsResult(mdMethodDef pmd, int pulSequence, string szName, CorParamAttr pdwAttr, CorElementType pdwCPlusTypeFlag, IntPtr ppValue, int pcchValue)
        {
            this.pmd = pmd;
            this.pulSequence = pulSequence;
            this.szName = szName;
            this.pdwAttr = pdwAttr;
            this.pdwCPlusTypeFlag = pdwCPlusTypeFlag;
            this.ppValue = ppValue;
            this.pcchValue = pcchValue;
        }
    }
}
