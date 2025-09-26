using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: Optionally provided by any symbol set. Represents a way to query the capabilities (and some key properties) of a symbol set.<para/>
    /// This interface is *ENTIRELY* optional. If it is not present, the default value of any capability queried must be assumed.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("05D19D56-C15E-4C1D-9125-BB14D61B9784")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcSymbolSetCapabilities
    {
        /// <summary>
        /// Asks the symbol set about a particular capability as identified by a set GUID and an ID within that set. Each GUID/ID identifies the type of data returned in the resulting buffer.<para/>
        /// The following error codes carry special semantics with this API E_NOT_SET: The symbol set does not understand the capability.<para/>
        /// Assume default behavior.
        /// </summary>
        [PreserveSig]
        HRESULT QueryCapability(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid set,
            [In] int id,
            [In] int bufferSize,
            [Out] IntPtr buffer);
    }
}
