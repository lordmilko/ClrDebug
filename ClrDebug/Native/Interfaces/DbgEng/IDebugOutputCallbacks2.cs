using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("67721fe9-56d2-4a44-a325-2b65513ce6eb")]
    [ComImport]
    public interface IDebugOutputCallbacks2 : IDebugOutputCallbacks
    {
        #region IDebugOutputCallbacks

        [PreserveSig]
        new HRESULT Output(
            [In] DEBUG_OUTPUT mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string text);

        #endregion
        #region IDebugOutputCallbacks2

        [PreserveSig]
        HRESULT GetInterestMask(
            [Out] out DEBUG_OUTCBI mask);

        [PreserveSig]
        HRESULT Output2(
            [In] DEBUG_OUTCB which,
            [In] DEBUG_OUTCBF flags,
            [In] ulong arg,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text);

        #endregion
    }
}
