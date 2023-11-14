using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Provides methods to do a stack walk using information in the .pdb file.
    /// </summary>
    /// <remarks>
    /// This interface is used to obtain a list of stack frames for a loaded module. Each of the methods is passed an IDiaStackWalkHelper
    /// object (implemented by the client application) which provides the necessary information to create the list of stack
    /// frames. This interface is obtained by calling the CoCreateInstance method with the class identifier CLSID_DiaStackWalker
    /// and the interface ID of IID_IDiaStackWalker. The example shows how this interface is obtained.
    /// </remarks>
    public class DiaStackWalker : ComObject<IDiaStackWalker>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaStackWalker"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaStackWalker(IDiaStackWalker raw) : base(raw)
        {
        }

        #region IDiaStackWalker
        #region GetEnumFrames

        public DiaEnumStackFrames GetEnumFrames(IDiaStackWalkHelper pHelper)
        {
            DiaEnumStackFrames ppenumResult;
            TryGetEnumFrames(pHelper, out ppenumResult).ThrowOnNotOK();

            return ppenumResult;
        }

        public HRESULT TryGetEnumFrames(IDiaStackWalkHelper pHelper, out DiaEnumStackFrames ppenumResult)
        {
            /*HRESULT getEnumFrames(
            [MarshalAs(UnmanagedType.Interface), In] IDiaStackWalkHelper pHelper,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumStackFrames ppenum);*/
            IDiaEnumStackFrames ppenum;
            HRESULT hr = Raw.getEnumFrames(pHelper, out ppenum);

            if (hr == HRESULT.S_OK)
                ppenumResult = new DiaEnumStackFrames(ppenum);
            else
                ppenumResult = default(DiaEnumStackFrames);

            return hr;
        }

        #endregion
        #region GetEnumFrames2

        public DiaEnumStackFrames GetEnumFrames2(CV_CPU_TYPE_e cpuid, IDiaStackWalkHelper pHelper)
        {
            DiaEnumStackFrames ppenumResult;
            TryGetEnumFrames2(cpuid, pHelper, out ppenumResult).ThrowOnNotOK();

            return ppenumResult;
        }

        public HRESULT TryGetEnumFrames2(CV_CPU_TYPE_e cpuid, IDiaStackWalkHelper pHelper, out DiaEnumStackFrames ppenumResult)
        {
            /*HRESULT getEnumFrames2(
            [In] CV_CPU_TYPE_e cpuid,
            [MarshalAs(UnmanagedType.Interface), In] IDiaStackWalkHelper pHelper,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumStackFrames ppenum);*/
            IDiaEnumStackFrames ppenum;
            HRESULT hr = Raw.getEnumFrames2(cpuid, pHelper, out ppenum);

            if (hr == HRESULT.S_OK)
                ppenumResult = new DiaEnumStackFrames(ppenum);
            else
                ppenumResult = default(DiaEnumStackFrames);

            return hr;
        }

        #endregion
        #endregion
        #region IDiaStackWalker2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaStackWalker2 Raw2 => (IDiaStackWalker2) Raw;

        #endregion
    }
}
