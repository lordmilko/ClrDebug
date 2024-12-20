using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_OS_INFORMATION.
    /// </summary>
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

        /// <summary>
        /// Gets the high level infromation about the platform that the target is running on. A component which runs on a platform that is not described by SvcOSPlatform may return SvcOSPlatUnknown.
        /// </summary>
        public SvcOSPlatform OSPlatform
        {
            get
            {
                SvcOSPlatform pOSPlatform;
                TryGetOSPlatform(out pOSPlatform).ThrowDbgEngNotOK();

                return pOSPlatform;
            }
        }

        /// <summary>
        /// Gets the high level infromation about the platform that the target is running on. A component which runs on a platform that is not described by SvcOSPlatform may return SvcOSPlatUnknown.
        /// </summary>
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

        /// <summary>
        /// Gets the 1-4 digit version of the platform. When digits are not appropriate for the platform, use a 0 default. If the implementation cannot make a determination of the OS Version Number, E_NOT_SET may legally be returned.<para/>
        /// If the implementation doesn't support the concept of an OS Version Number, E_NOTIMPL may legally be returned.
        /// </summary>
        public GetOSVersionResult OSVersion
        {
            get
            {
                GetOSVersionResult result;
                TryGetOSVersion(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets the 1-4 digit version of the platform. When digits are not appropriate for the platform, use a 0 default. If the implementation cannot make a determination of the OS Version Number, E_NOT_SET may legally be returned.<para/>
        /// If the implementation doesn't support the concept of an OS Version Number, E_NOTIMPL may legally be returned.
        /// </summary>
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

        /// <summary>
        /// Gets the string that represents the Build Lab (environment) that built this version of the platform. If the implementation cannot make a determination of the Build Lab, E_NOT_SET may legally be returned.<para/>
        /// If the implementation doesn't support the concept of a Build Lab, E_NOTIMPL may legally be returned.
        /// </summary>
        public string OSBuildLab
        {
            get
            {
                string pBuildLab;
                TryGetOSBuildLab(out pBuildLab).ThrowDbgEngNotOK();

                return pBuildLab;
            }
        }

        /// <summary>
        /// Gets the string that represents the Build Lab (environment) that built this version of the platform. If the implementation cannot make a determination of the Build Lab, E_NOT_SET may legally be returned.<para/>
        /// If the implementation doesn't support the concept of a Build Lab, E_NOTIMPL may legally be returned.
        /// </summary>
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
