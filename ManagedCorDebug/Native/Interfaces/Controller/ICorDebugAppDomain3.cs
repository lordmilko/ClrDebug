using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("8CB96A16-B588-42E2-B71C-DD849FC2ECCC")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugAppDomain3
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCachedWinRTTypesForIIDs(
            [In] uint cReqTypes,
            [In] ref Guid iidsToResolve,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTypesEnum);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCachedWinRTTypes([MarshalAs(UnmanagedType.Interface)] out ICorDebugGuidToTypeEnum ppGuidToTypeEnum);
    }
}