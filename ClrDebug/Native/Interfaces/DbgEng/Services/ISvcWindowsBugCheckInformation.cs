using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("228DBCF1-3E54-42FC-9DDD-5EFB76B13C70")]
    [ComImport]
    public interface ISvcWindowsBugCheckInformation
    {
        [PreserveSig]
        int GetBugCheckCode();
        
        [PreserveSig]
        void GetBugCheckData(
            [Out] out long pBugCheckData);
    }
}
