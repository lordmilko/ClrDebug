using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("E5F3039D-2C0C-4230-A69E-12AF1C3E563C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRLibrarySupport
    {
        [PreserveSig]
        HRESULT LoadHardboundDependency(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] ref Guid mvid,
            [Out] out long loadedBase);

        [PreserveSig]
        HRESULT LoadSoftboundDependency(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] IntPtr assemblymetadataBinding,
            [In] IntPtr hash,
            [In] int hashLength,
            [Out] out long loadedBase);

    }
}
