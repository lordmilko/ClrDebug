using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumUserStrings"/> method.
    /// </summary>
    public struct EnumUserStringsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array used to store the String tokens.
        /// </summary>
        public mdString[] rStrings { get; }

        /// <summary>
        /// [out] The number of String tokens returned in rStrings.
        /// </summary>
        public int pcStrings { get; }

        public EnumUserStringsResult(IntPtr phEnum, mdString[] rStrings, int pcStrings)
        {
            this.phEnum = phEnum;
            this.rStrings = rStrings;
            this.pcStrings = pcStrings;
        }
    }
}