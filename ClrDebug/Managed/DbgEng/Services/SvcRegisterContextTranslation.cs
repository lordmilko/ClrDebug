using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_REGISTERCONTEXTTRANSLATION. The ISvcRegisterContextTranslation interface provides translation between register context domains.<para/>
    /// This can be utilized, for instance, to translate from Windows context record (struct CONTEXT / AMD64_CONTEXT, etc...) to a canonical ISvcRegisterContext or vice-versa.<para/>
    /// It can also be used to translate from a custom context record (e.g.: a custom architecture's user mode register context stored in a core dump) to a canonical ISvcRegisterContext or vice-versa.
    /// </summary>
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

        /// <summary>
        /// Gets the size of the domain specific context record.
        /// </summary>
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

        /// <summary>
        /// Translates from a domain specific context record to a canonical context record.
        /// </summary>
        public void TranslateToCanonicalContext(int domainContextSize, IntPtr domainContext, ref ISvcRegisterContext canonicalContext)
        {
            TryTranslateToCanonicalContext(domainContextSize, domainContext, ref canonicalContext).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Translates from a domain specific context record to a canonical context record.
        /// </summary>
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

        /// <summary>
        /// Translates from a canonical context record to a domain specific context record.
        /// </summary>
        public void TranslateFromCanonicalContext(ISvcRegisterContext canonicalContext, int domainRecordSize, IntPtr domainContext)
        {
            TryTranslateFromCanonicalContext(canonicalContext, domainRecordSize, domainContext).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Translates from a canonical context record to a domain specific context record.
        /// </summary>
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
