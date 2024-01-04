namespace ClrDebug.DbgEng
{
    public class ClrDacDbiAndSosProvider : ClrDacAndSosProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClrDacDbiAndSosProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ClrDacDbiAndSosProvider(IClrDacDbiAndSosProvider raw) : base(raw)
        {
        }

        #region IClrDacDbiAndSosProvider

        public new IClrDacDbiAndSosProvider Raw => (IClrDacDbiAndSosProvider) base.Raw;

        #region IsClrImageEx

        public IsClrImageExResult IsClrImageEx(ISvcModule module)
        {
            IsClrImageExResult result;
            TryIsClrImageEx(module, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryIsClrImageEx(ISvcModule module, out IsClrImageExResult result)
        {
            /*HRESULT IsClrImageEx(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule module,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsClrImage,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrDac,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrDbi,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrSos);*/
            bool pIsClrImage;
            bool pbCanProvideClrDac;
            bool pbCanProvideClrDbi;
            bool pbCanProvideClrSos;
            HRESULT hr = Raw.IsClrImageEx(module, out pIsClrImage, out pbCanProvideClrDac, out pbCanProvideClrDbi, out pbCanProvideClrSos);

            if (hr == HRESULT.S_OK)
                result = new IsClrImageExResult(pIsClrImage, pbCanProvideClrDac, pbCanProvideClrDbi, pbCanProvideClrSos);
            else
                result = default(IsClrImageExResult);

            return hr;
        }

        #endregion
        #region ProvideClrDbi

        public string ProvideClrDbi(ISvcModule pModule, string forcePath)
        {
            string pDbiPath;
            TryProvideClrDbi(pModule, forcePath, out pDbiPath).ThrowDbgEngNotOK();

            return pDbiPath;
        }

        public HRESULT TryProvideClrDbi(ISvcModule pModule, string forcePath, out string pDbiPath)
        {
            /*HRESULT ProvideClrDbi(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDbiPath);*/
            return Raw.ProvideClrDbi(pModule, forcePath, out pDbiPath);
        }

        #endregion
        #endregion
    }
}
