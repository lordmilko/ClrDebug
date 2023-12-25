using static ClrDebug.Extensions;

namespace ClrDebug
{
    /// <summary>
    /// Represents and provides information about an application domain.
    /// </summary>
    public class CorPublishAppDomain : ComObject<ICorPublishAppDomain>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorPublishAppDomain"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorPublishAppDomain(ICorPublishAppDomain raw) : base(raw)
        {
        }

        #region ICorPublishAppDomain
        #region Id

        /// <summary>
        /// Gets the unique identifier for this <see cref="ICorPublishAppDomain"/>.
        /// </summary>
        public int Id
        {
            get
            {
                int puId;
                TryGetID(out puId).ThrowOnNotOK();

                return puId;
            }
        }

        /// <summary>
        /// Gets the unique identifier for this <see cref="ICorPublishAppDomain"/>.
        /// </summary>
        /// <param name="puId">[out] A pointer to the identifier of the application domain.</param>
        /// <remarks>
        /// The identifier is unique only in the scope of the containing process.
        /// </remarks>
        public HRESULT TryGetID(out int puId)
        {
            /*HRESULT GetID(
            [Out] out int puId);*/
            return Raw.GetID(out puId);
        }

        #endregion
        #region Name

        /// <summary>
        /// Gets the name of the application domain that is represented by this <see cref="ICorPublishAppDomain"/>.
        /// </summary>
        public string Name
        {
            get
            {
                string szNameResult;
                TryGetName(out szNameResult).ThrowOnNotOK();

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets the name of the application domain that is represented by this <see cref="ICorPublishAppDomain"/>.
        /// </summary>
        /// <param name="szNameResult">[out] An array in which to store the name.</param>
        /// <remarks>
        /// If szName is non-null, the GetName method copies up to cchName characters (including the null terminator) into
        /// szName. If a non-null is returned in pcchName, the actual number of characters in the name (including the null
        /// terminator) is stored in the szName array. The GetName method returns an S_OK HRESULT regardless of how many characters
        /// were copied.
        /// </remarks>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);*/
            int cchName = 0;
            int pcchName;
            char[] szName;
            HRESULT hr = Raw.GetName(cchName, out pcchName, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new char[cchName];
            hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = CreateString(szName, pcchName);

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
