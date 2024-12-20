using System;

namespace ClrDebug
{
    public class Inspectable : ComObject<IInspectable>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Inspectable"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public Inspectable(IInspectable raw) : base(raw)
        {
        }

        #region IInspectable
        #region Iids

        public GetIidsResult Iids
        {
            get
            {
                GetIidsResult result;
                TryGetIids(out result).ThrowOnNotOK();

                return result;
            }
        }

        public HRESULT TryGetIids(out GetIidsResult result)
        {
            /*HRESULT GetIids(
            [Out] out int iidCount,
            [Out] out IntPtr iids);*/
            int iidCount;
            IntPtr iids;
            HRESULT hr = Raw.GetIids(out iidCount, out iids);

            if (hr == HRESULT.S_OK)
                result = new GetIidsResult(iidCount, iids);
            else
                result = default(GetIidsResult);

            return hr;
        }

        #endregion
        #region RuntimeClassName

        public string RuntimeClassName
        {
            get
            {
                string className;
                TryGetRuntimeClassName(out className).ThrowOnNotOK();

                return className;
            }
        }

        public HRESULT TryGetRuntimeClassName(out string className)
        {
            /*HRESULT GetRuntimeClassName(
            [Out, MarshalAs(UnmanagedType.HString)] out string className);*/
            return Raw.GetRuntimeClassName(out className);
        }

        #endregion
        #region TrustLevel

        public TrustLevel TrustLevel
        {
            get
            {
                TrustLevel trustLevel;
                TryGetTrustLevel(out trustLevel).ThrowOnNotOK();

                return trustLevel;
            }
        }

        public HRESULT TryGetTrustLevel(out TrustLevel trustLevel)
        {
            /*HRESULT GetTrustLevel(
            [Out] out TrustLevel trustLevel);*/
            return Raw.GetTrustLevel(out trustLevel);
        }

        #endregion
        #endregion
    }
}
