using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("555241CF-9322-48F9-8E71-F39307783BE6")]
    [ComImport]
    public interface ISvcImageVersionDataEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out] out Guid pVersionDataIdentifierGuid,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataIdentifierString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataDescription,
            [Out] out VersionKind pVersionKind);
    }
}
