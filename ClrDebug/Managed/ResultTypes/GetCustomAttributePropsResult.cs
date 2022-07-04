using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetCustomAttributeProps"/> method.
    /// </summary>
    [DebuggerDisplay("ptkObj = {ptkObj.ToString(),nq}, ptkType = {ptkType.ToString(),nq}, ppBlob = {ppBlob.ToString(),nq}, pcbSize = {pcbSize}")]
    public struct GetCustomAttributePropsResult
    {
        /// <summary>
        /// [out, optional] A metadata token representing the object that the custom attribute modifies. This value can be any type of metadata token except <see cref="mdCustomAttribute"/>.
        /// </summary>
        public mdToken ptkObj { get; }

        /// <summary>
        /// [out, optional] An <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/> metadata token representing the <see cref="Type"/> of the returned custom attribute.
        /// </summary>
        public mdToken ptkType { get; }

        /// <summary>
        /// [out, optional] A pointer to an array of data that is the value of the custom attribute.
        /// </summary>
        public IntPtr ppBlob { get; }

        /// <summary>
        /// [out, optional] The size in bytes of the data returned in *ppBlob.
        /// </summary>
        public int pcbSize { get; }

        public GetCustomAttributePropsResult(mdToken ptkObj, mdToken ptkType, IntPtr ppBlob, int pcbSize)
        {
            this.ptkObj = ptkObj;
            this.ptkType = ptkType;
            this.ppBlob = ppBlob;
            this.pcbSize = pcbSize;
        }
    }
}
