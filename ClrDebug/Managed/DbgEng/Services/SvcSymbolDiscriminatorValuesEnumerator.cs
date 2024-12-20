﻿namespace ClrDebug.DbgEng
{
    public class SvcSymbolDiscriminatorValuesEnumerator : ComObject<ISvcSymbolDiscriminatorValuesEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolDiscriminatorValuesEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolDiscriminatorValuesEnumerator(ISvcSymbolDiscriminatorValuesEnumerator raw) : base(raw)
        {
        }

        #region ISvcSymbolDiscriminatorValuesEnumerator
        #region Next

        /// <summary>
        /// Gets the next range of discriminator values in the enumerator. Note that this has identical semantics to ISvcSymbolVariantInfo::GetDescriminatorValues in terms of pLowValue and pHighValue.
        /// </summary>
        public SvcSymbolDiscriminatorValuesEnumerator_GetNextResult Next
        {
            get
            {
                SvcSymbolDiscriminatorValuesEnumerator_GetNextResult result;
                TryGetNext(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets the next range of discriminator values in the enumerator. Note that this has identical semantics to ISvcSymbolVariantInfo::GetDescriminatorValues in terms of pLowValue and pHighValue.
        /// </summary>
        public HRESULT TryGetNext(out SvcSymbolDiscriminatorValuesEnumerator_GetNextResult result)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pLowValue,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pHighValue);*/
            object pLowValue;
            object pHighValue;
            HRESULT hr = Raw.GetNext(out pLowValue, out pHighValue);

            if (hr == HRESULT.S_OK)
                result = new SvcSymbolDiscriminatorValuesEnumerator_GetNextResult(pLowValue, pHighValue);
            else
                result = default(SvcSymbolDiscriminatorValuesEnumerator_GetNextResult);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
