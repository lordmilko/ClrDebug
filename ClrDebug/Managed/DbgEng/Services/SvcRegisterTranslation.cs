namespace ClrDebug.DbgEng
{
    public class SvcRegisterTranslation : ComObject<ISvcRegisterTranslation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcRegisterTranslation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcRegisterTranslation(ISvcRegisterTranslation raw) : base(raw)
        {
        }

        #region ISvcRegisterTranslation
        #region TranslateFromCanonicalId

        public int TranslateFromCanonicalId(int canonicalId)
        {
            int domainId;
            TryTranslateFromCanonicalId(canonicalId, out domainId).ThrowDbgEngNotOK();

            return domainId;
        }

        public HRESULT TryTranslateFromCanonicalId(int canonicalId, out int domainId)
        {
            /*HRESULT TranslateFromCanonicalId(
            [In] int canonicalId,
            [Out] out int domainId);*/
            return Raw.TranslateFromCanonicalId(canonicalId, out domainId);
        }

        #endregion
        #region TranslateToCanonicalId

        public int TranslateToCanonicalId(int domainId)
        {
            int canonicalId;
            TryTranslateToCanonicalId(domainId, out canonicalId).ThrowDbgEngNotOK();

            return canonicalId;
        }

        public HRESULT TryTranslateToCanonicalId(int domainId, out int canonicalId)
        {
            /*HRESULT TranslateToCanonicalId(
            [In] int domainId,
            [Out] out int canonicalId);*/
            return Raw.TranslateToCanonicalId(domainId, out canonicalId);
        }

        #endregion
        #endregion
    }
}
