using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Represents a managed debugging assistant (MDA) message.
    /// </summary>
    public class CorDebugMDA : ComObject<ICorDebugMDA>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugMDA"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugMDA(ICorDebugMDA raw) : base(raw)
        {
        }

        #region ICorDebugMDA
        #region Name

        /// <summary>
        /// Gets a string containing the name of the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
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
        /// Gets a string containing the name of the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        /// <param name="szNameResult">[out] An array in which to store the name.</param>
        /// <remarks>
        /// MDA names are unique values. The GetName method is a convenient performance alternative to getting the XML stream
        /// and extracting the name from the stream based on the schema.
        /// </remarks>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, [Out] out int pcchName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
            hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region Description

        /// <summary>
        /// Gets a string containing the description of the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        public string Description
        {
            get
            {
                string szNameResult;
                TryGetDescription(out szNameResult).ThrowOnNotOK();

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets a string containing the description of the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        /// <param name="szNameResult">[out] A string buffer containing the description of the MDA.</param>
        /// <remarks>
        /// The string can be zero in length.
        /// </remarks>
        public HRESULT TryGetDescription(out string szNameResult)
        {
            /*HRESULT GetDescription([In] int cchName, [Out] out int pcchName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetDescription(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
            hr = Raw.GetDescription(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region XML

        /// <summary>
        /// Gets the full XML stream associated with the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        public string XML
        {
            get
            {
                string szNameResult;
                TryGetXML(out szNameResult).ThrowOnNotOK();

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets the full XML stream associated with the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        /// <param name="szNameResult">[out] An array in which to store the XML stream. The array may be empty.</param>
        /// <remarks>
        /// The GetXML method can potentially affect performance, depending on the size of the associated XML stream.
        /// </remarks>
        public HRESULT TryGetXML(out string szNameResult)
        {
            /*HRESULT GetXML([In] int cchName, [Out] out int pcchName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetXML(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
            hr = Raw.GetXML(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region OSThreadId

        /// <summary>
        /// Gets the operating system (OS) thread identifier upon which the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/> is executing.
        /// </summary>
        public int OSThreadId
        {
            get
            {
                int pOsTid;
                TryGetOSThreadId(out pOsTid).ThrowOnNotOK();

                return pOsTid;
            }
        }

        /// <summary>
        /// Gets the operating system (OS) thread identifier upon which the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/> is executing.
        /// </summary>
        /// <param name="pOsTid">[out] A pointer to the OS thread identifier.</param>
        /// <remarks>
        /// The OS thread is used instead of an <see cref="ICorDebugThread"/> to allow for situations in which an MDA is fired either on
        /// a native thread or on a managed thread that has not yet entered managed code.
        /// </remarks>
        public HRESULT TryGetOSThreadId(out int pOsTid)
        {
            /*HRESULT GetOSThreadId([Out] out int pOsTid);*/
            return Raw.GetOSThreadId(out pOsTid);
        }

        #endregion
        #region GetFlags

        /// <summary>
        /// Gets the flags associated with the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        /// <param name="pFlags">[in] A bitwise combination of the <see cref="CorDebugMDAFlags"/> enumeration values that specify the settings of the flags for this MDA.</param>
        public void GetFlags(CorDebugMDAFlags pFlags)
        {
            TryGetFlags(pFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Gets the flags associated with the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        /// <param name="pFlags">[in] A bitwise combination of the <see cref="CorDebugMDAFlags"/> enumeration values that specify the settings of the flags for this MDA.</param>
        public HRESULT TryGetFlags(CorDebugMDAFlags pFlags)
        {
            /*HRESULT GetFlags([In] ref CorDebugMDAFlags pFlags);*/
            return Raw.GetFlags(ref pFlags);
        }

        #endregion
        #endregion
    }
}
