using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4EA0C43F-8378-43D9-BE1C-E698F5508E58")]
    [ComImport]
    public interface ISvcImageVersionParser2 : ISvcImageVersionParser
    {
        [PreserveSig]
        new HRESULT GetVersionString(
            [In] VersionKind kind,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersion);
        
        [PreserveSig]
        new HRESULT GetVersionNumber(
            [In] VersionKind kind,
            [Out] out long p1,
            [Out] out long p2,
            [Out] out long p3,
            [Out] out long p4);
        
        [PreserveSig]
        new HRESULT GetVersionDataString(
            [In] Guid pVersionDataIdentifierGuid,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pVersionDataIdentifierString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataString);
        
        [PreserveSig]
        HRESULT EnumerateVersionData(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageVersionDataEnumerator enumerator);
    }
}
