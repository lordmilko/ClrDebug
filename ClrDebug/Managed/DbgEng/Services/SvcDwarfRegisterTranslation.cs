namespace ClrDebug.DbgEng
{
    public class SvcDwarfRegisterTranslation : ComObject<ISvcDwarfRegisterTranslation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcDwarfRegisterTranslation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcDwarfRegisterTranslation(ISvcDwarfRegisterTranslation raw) : base(raw)
        {
        }

        #region ISvcDwarfRegisterTranslation
        #region TranslateFromAbstractId

        public int TranslateFromAbstractId(SvcAbstractRegister abstractId)
        {
            int domainId;
            TryTranslateFromAbstractId(abstractId, out domainId).ThrowDbgEngNotOK();

            return domainId;
        }

        public HRESULT TryTranslateFromAbstractId(SvcAbstractRegister abstractId, out int domainId)
        {
            /*HRESULT TranslateFromAbstractId(
            [In] SvcAbstractRegister abstractId,
            [Out] out int domainId);*/
            return Raw.TranslateFromAbstractId(abstractId, out domainId);
        }

        #endregion
        #region TranslateTypicalCfa

        public SvcSymbolLocation TranslateTypicalCfa()
        {
            SvcSymbolLocation cfaLocation;
            TryTranslateTypicalCfa(out cfaLocation).ThrowDbgEngNotOK();

            return cfaLocation;
        }

        public HRESULT TryTranslateTypicalCfa(out SvcSymbolLocation cfaLocation)
        {
            /*HRESULT TranslateTypicalCfa(
            [Out] out SvcSymbolLocation cfaLocation);*/
            return Raw.TranslateTypicalCfa(out cfaLocation);
        }

        #endregion
        #endregion
    }
}
