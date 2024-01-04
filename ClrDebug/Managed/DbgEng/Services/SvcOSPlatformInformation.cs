using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class SvcOSPlatformInformation : ComObject<ISvcOSPlatformInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcOSPlatformInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcOSPlatformInformation(ISvcOSPlatformInformation raw) : base(raw)
        {
        }

        #region ISvcOSPlatformInformation
        #region OSPlatform

        public SvcOSPlatform OSPlatform
        {
            get
            {
                SvcOSPlatform pOSPlatform;
                TryGetOSPlatform(out pOSPlatform).ThrowDbgEngNotOK();

                return pOSPlatform;
            }
        }

        public HRESULT TryGetOSPlatform(out SvcOSPlatform pOSPlatform)
        {
            /*HRESULT GetOSPlatform(
            [Out] out SvcOSPlatform pOSPlatform);*/
            return Raw.GetOSPlatform(out pOSPlatform);
        }

        #endregion
        #endregion
        #region ISvcOSPlatformInformation2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISvcOSPlatformInformation2 Raw2 => (ISvcOSPlatformInformation2) Raw;

        #region OSVersion

        public GetOSVersionResult OSVersion
        {
            get
            {
                GetOSVersionResult result;
                TryGetOSVersion(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetOSVersion(out GetOSVersionResult result)
        {
            /*HRESULT GetOSVersion(
            [Out] out short pMajor,
            [Out] out short pMinor,
            [Out] out short pBuild,
            [Out] out short pRevision);*/
            short pMajor;
            short pMinor;
            short pBuild;
            short pRevision;
            HRESULT hr = Raw2.GetOSVersion(out pMajor, out pMinor, out pBuild, out pRevision);

            if (hr == HRESULT.S_OK)
                result = new GetOSVersionResult(pMajor, pMinor, pBuild, pRevision);
            else
                result = default(GetOSVersionResult);

            return hr;
        }

        #endregion
        #region OSBuildLab

        public string OSBuildLab
        {
            get
            {
                string pBuildLab;
                TryGetOSBuildLab(out pBuildLab).ThrowDbgEngNotOK();

                return pBuildLab;
            }
        }

        public HRESULT TryGetOSBuildLab(out string pBuildLab)
        {
            /*HRESULT GetOSBuildLab(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pBuildLab);*/
            return Raw2.GetOSBuildLab(out pBuildLab);
        }

        #endregion
        #endregion
    }
}
