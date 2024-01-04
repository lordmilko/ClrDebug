using System;

namespace ClrDebug.DbgEng
{
    public class SvcRegisterContextTranslation : ComObject<ISvcRegisterContextTranslation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcRegisterContextTranslation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcRegisterContextTranslation(ISvcRegisterContextTranslation raw) : base(raw)
        {
        }

        #region ISvcRegisterContextTranslation
        #region DomainContextSize

        public int DomainContextSize
        {
            get
            {
                /*int GetDomainContextSize();*/
                return Raw.GetDomainContextSize();
            }
        }

        #endregion
        #region TranslateToCanonicalContext

        public void TranslateToCanonicalContext(int domainContextSize, IntPtr domainContext, ref ISvcRegisterContext canonicalContext)
        {
            TryTranslateToCanonicalContext(domainContextSize, domainContext, ref canonicalContext).ThrowDbgEngNotOK();
        }

        public HRESULT TryTranslateToCanonicalContext(int domainContextSize, IntPtr domainContext, ref ISvcRegisterContext canonicalContext)
        {
            /*HRESULT TranslateToCanonicalContext(
            [In] int domainContextSize,
            [In] IntPtr domainContext,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext canonicalContext);*/
            return Raw.TranslateToCanonicalContext(domainContextSize, domainContext, ref canonicalContext);
        }

        #endregion
        #region TranslateFromCanonicalContext

        public void TranslateFromCanonicalContext(ISvcRegisterContext canonicalContext, int domainRecordSize, IntPtr domainContext)
        {
            TryTranslateFromCanonicalContext(canonicalContext, domainRecordSize, domainContext).ThrowDbgEngNotOK();
        }

        public HRESULT TryTranslateFromCanonicalContext(ISvcRegisterContext canonicalContext, int domainRecordSize, IntPtr domainContext)
        {
            /*HRESULT TranslateFromCanonicalContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext canonicalContext,
            [In] int domainRecordSize,
            [Out] IntPtr domainContext);*/
            return Raw.TranslateFromCanonicalContext(canonicalContext, domainRecordSize, domainContext);
        }

        #endregion
        #endregion
    }
}
