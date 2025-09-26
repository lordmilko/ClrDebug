using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Notes - All implementations of ISvcWindowsBugCheckInformation must also implement ISvcExceptionInformation.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("228DBCF1-3E54-42FC-9DDD-5EFB76B13C70")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcWindowsBugCheckInformation
    {
        /// <summary>
        /// Gets the bugcheck code.
        /// </summary>
        [PreserveSig]
        int GetBugCheckCode();

        /// <summary>
        /// Gets the bugcheck data.
        /// </summary>
        [PreserveSig]
        void GetBugCheckData(
            [Out] out long pBugCheckData);
    }
}
