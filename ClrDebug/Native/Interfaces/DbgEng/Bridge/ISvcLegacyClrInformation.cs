using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Private bridge interface to inquire about existing CLR capability.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("25C75342-66A8-44cb-89A9-13751F662786")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcLegacyClrInformation
    {
        /// <summary>
        /// Indicates whether or not there is specific unwinder support for managed stack unwinds.
        /// </summary>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool SupportsManagedStackUnwind();
    }
}
