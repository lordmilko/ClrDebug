namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Provides the managed definition of the ITypeComp interface.
    /// </summary>
    public class TypeComp : ComObject<ITypeComp>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeComp"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public TypeComp(ITypeComp raw) : base(raw)
        {
        }

        #region ITypeComp
        #region Bind

        /// <summary>
        /// Maps a name to a member of a type, or binds global variables and functions contained in a type library.
        /// </summary>
        /// <param name="szName">The name to bind.</param>
        /// <param name="lHashVal">A hash value for szName computed by LHashValOfNameSys.</param>
        /// <param name="wFlags">A flags word containing one or more of the invoke flags defined in the INVOKEKIND enumeration.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public BindResult Bind(string szName, int lHashVal, short wFlags)
        {
            BindResult result;
            TryBind(szName, lHashVal, wFlags, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Maps a name to a member of a type, or binds global variables and functions contained in a type library.
        /// </summary>
        /// <param name="szName">The name to bind.</param>
        /// <param name="lHashVal">A hash value for szName computed by LHashValOfNameSys.</param>
        /// <param name="wFlags">A flags word containing one or more of the invoke flags defined in the INVOKEKIND enumeration.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryBind(string szName, int lHashVal, short wFlags, out BindResult result)
        {
            /*HRESULT Bind(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] int lHashVal,
            [In] short wFlags,
            [Out] out ITypeInfo ppTInfo,
            [Out] out DESCKIND pDescKind,
            [Out] out BINDPTR pBindPtr);*/
            ITypeInfo ppTInfo;
            DESCKIND pDescKind;
            BINDPTR pBindPtr;
            HRESULT hr = Raw.Bind(szName, lHashVal, wFlags, out ppTInfo, out pDescKind, out pBindPtr);

            if (hr == HRESULT.S_OK)
                result = new BindResult(new TypeInfo(ppTInfo), pDescKind, pBindPtr);
            else
                result = default(BindResult);

            return hr;
        }

        #endregion
        #region BindType

        /// <summary>
        /// Binds to the type descriptions contained within a type library.
        /// </summary>
        /// <param name="szName">The name to bind.</param>
        /// <param name="lHashVal">A hash value for szName determined by LHashValOfNameSys.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public BindTypeResult BindType(string szName, int lHashVal)
        {
            BindTypeResult result;
            TryBindType(szName, lHashVal, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Binds to the type descriptions contained within a type library.
        /// </summary>
        /// <param name="szName">The name to bind.</param>
        /// <param name="lHashVal">A hash value for szName determined by LHashValOfNameSys.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryBindType(string szName, int lHashVal, out BindTypeResult result)
        {
            /*HRESULT BindType(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] int lHashVal,
            [Out] out ITypeInfo ppTInfo,
            [Out] out ITypeComp ppTComp);*/
            ITypeInfo ppTInfo;
            ITypeComp ppTComp;
            HRESULT hr = Raw.BindType(szName, lHashVal, out ppTInfo, out ppTComp);

            if (hr == HRESULT.S_OK)
                result = new BindTypeResult(new TypeInfo(ppTInfo), new TypeComp(ppTComp));
            else
                result = default(BindTypeResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
