using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: Various services.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("50DEB97A-25CC-41C1-B467-96C5E3F454CA")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcPrivateProperties
    {
        /// <summary>
        /// Indicates whether this object supports a private property.
        /// </summary>
        [PreserveSig]
        HRESULT HasProperty(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid set,
            [In] int id,
            [Out, MarshalAs(UnmanagedType.U1)] out bool hasProperty);

        /// <summary>
        /// Gets a private property.
        /// </summary>
        [PreserveSig]
        HRESULT GetProperty(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid set,
            [In] int id,
            [In] int bufferSize,
            [Out] IntPtr buffer);

        /// <summary>
        /// Sets a private property.
        /// </summary>
        [PreserveSig]
        HRESULT SetProperty(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            Guid set,
            [In] int id,
            [In] int valueSize,
            [In] IntPtr valueBuffer);
    }
}
