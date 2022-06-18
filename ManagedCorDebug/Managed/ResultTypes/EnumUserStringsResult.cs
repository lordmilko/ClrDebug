using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumUserStrings"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rStrings = {rStrings}")]
    public struct EnumUserStringsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the String tokens.
        /// </summary>
        public mdString[] rStrings { get; }

        public EnumUserStringsResult(IntPtr phEnum, mdString[] rStrings)
        {
            this.phEnum = phEnum;
            this.rStrings = rStrings;
        }
    }
}