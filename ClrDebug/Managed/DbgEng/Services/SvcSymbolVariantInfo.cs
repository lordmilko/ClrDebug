namespace ClrDebug.DbgEng
{
    public class SvcSymbolVariantInfo : ComObject<ISvcSymbolVariantInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolVariantInfo"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolVariantInfo(ISvcSymbolVariantInfo raw) : base(raw)
        {
        }

        #region ISvcSymbolVariantInfo
        #region IsDiscriminator

        public bool IsDiscriminator
        {
            get
            {
                bool pIsDiscriminator;
                TryIsDiscriminator(out pIsDiscriminator).ThrowDbgEngNotOK();

                return pIsDiscriminator;
            }
        }

        public HRESULT TryIsDiscriminator(out bool pIsDiscriminator)
        {
            /*HRESULT IsDiscriminator(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsDiscriminator);*/
            return Raw.IsDiscriminator(out pIsDiscriminator);
        }

        #endregion
        #region IsDiscriminated

        public IsDiscriminatedResult IsDiscriminated
        {
            get
            {
                IsDiscriminatedResult result;
                TryIsDiscriminated(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryIsDiscriminated(out IsDiscriminatedResult result)
        {
            /*HRESULT IsDiscriminated(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsDiscriminated,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppDiscriminator);*/
            bool pIsDiscriminated;
            ISvcSymbol ppDiscriminator;
            HRESULT hr = Raw.IsDiscriminated(out pIsDiscriminated, out ppDiscriminator);

            if (hr == HRESULT.S_OK)
                result = new IsDiscriminatedResult(pIsDiscriminated, ppDiscriminator == null ? null : new SvcSymbol(ppDiscriminator));
            else
                result = default(IsDiscriminatedResult);

            return hr;
        }

        #endregion
        #region DiscriminatorValues

        public GetDiscriminatorValuesResult DiscriminatorValues
        {
            get
            {
                GetDiscriminatorValuesResult result;
                TryGetDiscriminatorValues(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetDiscriminatorValues(out GetDiscriminatorValuesResult result)
        {
            /*HRESULT GetDiscriminatorValues(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pLowRange,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pHighRange);*/
            object pLowRange;
            object pHighRange;
            HRESULT hr = Raw.GetDiscriminatorValues(out pLowRange, out pHighRange);

            if (hr == HRESULT.S_OK)
                result = new GetDiscriminatorValuesResult(pLowRange, pHighRange);
            else
                result = default(GetDiscriminatorValuesResult);

            return hr;
        }

        #endregion
        #region HasVariantMembers

        public bool HasVariantMembers()
        {
            bool pHasVariantMembers;
            TryHasVariantMembers(out pHasVariantMembers).ThrowDbgEngNotOK();

            return pHasVariantMembers;
        }

        public HRESULT TryHasVariantMembers(out bool pHasVariantMembers)
        {
            /*HRESULT HasVariantMembers(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pHasVariantMembers);*/
            return Raw.HasVariantMembers(out pHasVariantMembers);
        }

        #endregion
        #region EnumerateDiscriminatorValues

        public SvcSymbolDiscriminatorValuesEnumerator EnumerateDiscriminatorValues()
        {
            SvcSymbolDiscriminatorValuesEnumerator ppEnumResult;
            TryEnumerateDiscriminatorValues(out ppEnumResult).ThrowDbgEngNotOK();

            return ppEnumResult;
        }

        public HRESULT TryEnumerateDiscriminatorValues(out SvcSymbolDiscriminatorValuesEnumerator ppEnumResult)
        {
            /*HRESULT EnumerateDiscriminatorValues(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolDiscriminatorValuesEnumerator ppEnum);*/
            ISvcSymbolDiscriminatorValuesEnumerator ppEnum;
            HRESULT hr = Raw.EnumerateDiscriminatorValues(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new SvcSymbolDiscriminatorValuesEnumerator(ppEnum);
            else
                ppEnumResult = default(SvcSymbolDiscriminatorValuesEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
