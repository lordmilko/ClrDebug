namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which represents a variant part of a data structure (whether the discriminator or a discriminant) should implement ISvcSymbolVariantInfo.
    /// </summary>
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

        /// <summary>
        /// Indicates whether this member/field is a discriminator for a variant record.
        /// </summary>
        public bool IsDiscriminator
        {
            get
            {
                bool pIsDiscriminator;
                TryIsDiscriminator(out pIsDiscriminator).ThrowDbgEngNotOK();

                return pIsDiscriminator;
            }
        }

        /// <summary>
        /// Indicates whether this member/field is a discriminator for a variant record.
        /// </summary>
        public HRESULT TryIsDiscriminator(out bool pIsDiscriminator)
        {
            /*HRESULT IsDiscriminator(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsDiscriminator);*/
            return Raw.IsDiscriminator(out pIsDiscriminator);
        }

        #endregion
        #region IsDiscriminated

        /// <summary>
        /// Indicates whether this member/field is conditional based on the value of the discriminator. This can also optionally return the discriminator symbol.
        /// </summary>
        public IsDiscriminatedResult IsDiscriminated
        {
            get
            {
                IsDiscriminatedResult result;
                TryIsDiscriminated(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Indicates whether this member/field is conditional based on the value of the discriminator. This can also optionally return the discriminator symbol.
        /// </summary>
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

        /// <summary>
        /// Indicates the set of discriminator values for which this field/member is valid. This can return one of several things - Two variants that are both empty: The discriminator is a default discriminator (used if no other discriminator matches) - One variant (pLowRange) and one empty variant: The discriminator is a single value "pLowRange" - Two variants of identical type: The discriminator values are a range [pLowRange, pHighRange) Either of the above with a return value of S_FALSE: The set of discriminator values is disjoint and cannot be expressed by a single range.<para/>
        /// In this case, you must call EnumerateDiscriminatorValues to get a full accounting of discriminator values for which this field/member is valid.
        /// </summary>
        public GetDiscriminatorValuesResult DiscriminatorValues
        {
            get
            {
                GetDiscriminatorValuesResult result;
                TryGetDiscriminatorValues(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Indicates the set of discriminator values for which this field/member is valid. This can return one of several things - Two variants that are both empty: The discriminator is a default discriminator (used if no other discriminator matches) - One variant (pLowRange) and one empty variant: The discriminator is a single value "pLowRange" - Two variants of identical type: The discriminator values are a range [pLowRange, pHighRange) Either of the above with a return value of S_FALSE: The set of discriminator values is disjoint and cannot be expressed by a single range.<para/>
        /// In this case, you must call EnumerateDiscriminatorValues to get a full accounting of discriminator values for which this field/member is valid.
        /// </summary>
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

        /// <summary>
        /// Indicates whether this *TYPE* has variant members or is a variant record.
        /// </summary>
        public bool HasVariantMembers()
        {
            bool pHasVariantMembers;
            TryHasVariantMembers(out pHasVariantMembers).ThrowDbgEngNotOK();

            return pHasVariantMembers;
        }

        /// <summary>
        /// Indicates whether this *TYPE* has variant members or is a variant record.
        /// </summary>
        public HRESULT TryHasVariantMembers(out bool pHasVariantMembers)
        {
            /*HRESULT HasVariantMembers(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pHasVariantMembers);*/
            return Raw.HasVariantMembers(out pHasVariantMembers);
        }

        #endregion
        #region EnumerateDiscriminatorValues

        /// <summary>
        /// Enumerates all discriminator values for which this field/member is valid. While this function always works, it only NEEDS to be used if GetDiscriminatorValues returns S_FALSE as an indication that there are disjoint values.
        /// </summary>
        public SvcSymbolDiscriminatorValuesEnumerator EnumerateDiscriminatorValues()
        {
            SvcSymbolDiscriminatorValuesEnumerator ppEnumResult;
            TryEnumerateDiscriminatorValues(out ppEnumResult).ThrowDbgEngNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Enumerates all discriminator values for which this field/member is valid. While this function always works, it only NEEDS to be used if GetDiscriminatorValues returns S_FALSE as an indication that there are disjoint values.
        /// </summary>
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
