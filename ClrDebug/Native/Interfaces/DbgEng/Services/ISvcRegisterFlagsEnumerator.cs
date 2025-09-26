using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcRegisterFlagsEnumerator interface enumerates the flags bits of a flags register.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("55C7E6F4-D357-4209-ACF7-55D945AF3841")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcRegisterFlagsEnumerator
    {
        /// <summary>
        /// Gets the next flag in the register. Returns E_BOUNDS if there are no more.
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterFlagInformation flagInfo);

        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();
    }
}
