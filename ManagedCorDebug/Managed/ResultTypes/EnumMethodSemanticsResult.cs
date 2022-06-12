using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMethodSemantics"/> method.
    /// </summary>
    public struct EnumMethodSemanticsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array used to store the events or properties.
        /// </summary>
        public mdToken[] rEventProp { get; }

        /// <summary>
        /// [out] The number of events or properties returned in rEventProp.
        /// </summary>
        public int pcEventProp { get; }

        public EnumMethodSemanticsResult(IntPtr phEnum, mdToken[] rEventProp, int pcEventProp)
        {
            this.phEnum = phEnum;
            this.rEventProp = rEventProp;
            this.pcEventProp = pcEventProp;
        }
    }
}