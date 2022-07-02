using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("74B9D34C-A612-4B07-93DD-5462178FCE11")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface4
    {
        [PreserveSig]
        HRESULT GetClrNotification(
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] arguments,
            [In] int count,
            [Out] out int pNeeded);
    }
}
