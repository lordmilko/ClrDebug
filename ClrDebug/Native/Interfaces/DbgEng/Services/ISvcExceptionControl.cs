using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5A37C25E-4F8D-47BE-87F5-94A933824A83")]
    [ComImport]
    public interface ISvcExceptionControl
    {
        [PreserveSig]
        HRESULT IsFirstChance(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isFirstChance);
        
        [return: MarshalAs(UnmanagedType.U1)]
        bool WillPassToTarget();
        
        [PreserveSig]
        HRESULT PassToTarget(
            [In] int flags);
        
        [PreserveSig]
        HRESULT Handle(
            [In] int flags);
    }
}
