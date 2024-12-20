using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Notes - All implementations of ISvcWindowsBugCheckInformation must also implement ISvcExceptionInformation.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("228DBCF1-3E54-42FC-9DDD-5EFB76B13C70")]
    [ComImport]
    public interface ISvcWindowsBugCheckInformation
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
