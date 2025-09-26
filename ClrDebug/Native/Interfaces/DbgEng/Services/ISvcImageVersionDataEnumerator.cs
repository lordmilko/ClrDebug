using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("555241CF-9322-48F9-8E71-F39307783BE6")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcImageVersionDataEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid pVersionDataIdentifierGuid,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataIdentifierString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataDescription,
            [Out] out VersionKind pVersionKind);
    }
}
