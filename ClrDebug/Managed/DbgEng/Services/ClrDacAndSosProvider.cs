namespace ClrDebug.DbgEng
{
    public class ClrDacAndSosProvider : ComObject<IClrDacAndSosProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClrDacAndSosProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ClrDacAndSosProvider(IClrDacAndSosProvider raw) : base(raw)
        {
        }

        #region IClrDacAndSosProvider
        #region IsClrImage

        /// <summary>
        /// Determines if an image/module is a CLR image and if it can provide (retrieve/download/etc.) the CLR DAC and SOS for it.
        /// </summary>
        public IsClrImageResult IsClrImage(ISvcModule module)
        {
            IsClrImageResult result;
            TryIsClrImage(module, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Determines if an image/module is a CLR image and if it can provide (retrieve/download/etc.) the CLR DAC and SOS for it.
        /// </summary>
        public HRESULT TryIsClrImage(ISvcModule module, out IsClrImageResult result)
        {
            /*HRESULT IsClrImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule module,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsClrImage,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrDac,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrSos);*/
            bool pIsClrImage;
            bool pbCanProvideClrDac;
            bool pbCanProvideClrSos;
            HRESULT hr = Raw.IsClrImage(module, out pIsClrImage, out pbCanProvideClrDac, out pbCanProvideClrSos);

            if (hr == HRESULT.S_OK)
                result = new IsClrImageResult(pIsClrImage, pbCanProvideClrDac, pbCanProvideClrSos);
            else
                result = default(IsClrImageResult);

            return hr;
        }

        #endregion
        #region ProvideClrDac

        /// <summary>
        /// Retrieves/downloads/etc. the CLR DAC.
        /// </summary>
        public string ProvideClrDac(ISvcModule pModule, string forcePath)
        {
            string pDacPath;
            TryProvideClrDac(pModule, forcePath, out pDacPath).ThrowDbgEngNotOK();

            return pDacPath;
        }

        /// <summary>
        /// Retrieves/downloads/etc. the CLR DAC.
        /// </summary>
        public HRESULT TryProvideClrDac(ISvcModule pModule, string forcePath, out string pDacPath)
        {
            /*HRESULT ProvideClrDac(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDacPath);*/
            return Raw.ProvideClrDac(pModule, forcePath, out pDacPath);
        }

        #endregion
        #region ProvideClrSos

        /// <summary>
        /// Retrieves/downloads/etc. the CLR SOS.
        /// </summary>
        public string ProvideClrSos(ISvcModule pModule, string forcePath)
        {
            string pSosPath;
            TryProvideClrSos(pModule, forcePath, out pSosPath).ThrowDbgEngNotOK();

            return pSosPath;
        }

        /// <summary>
        /// Retrieves/downloads/etc. the CLR SOS.
        /// </summary>
        public HRESULT TryProvideClrSos(ISvcModule pModule, string forcePath, out string pSosPath)
        {
            /*HRESULT ProvideClrSos(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pSosPath);*/
            return Raw.ProvideClrSos(pModule, forcePath, out pSosPath);
        }

        #endregion
        #endregion
    }
}
