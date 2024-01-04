using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5AC23A8A-6D8C-4C92-AC1B-813E6EF1B48A")]
    [ComImport]
    public interface ISvcModuleIndexProvider
    {
        [PreserveSig]
        HRESULT GetModuleIndexKey(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pModuleIndex,
            [Out] out Guid pModuleIndexKind);
    }
}
