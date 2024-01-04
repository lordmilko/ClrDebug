using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B45C31AD-8149-4EA9-9DB8-F4468D710A36")]
    [ComImport]
    public interface ISvcProcess
    {
        [PreserveSig]
        HRESULT GetKey(
            [Out] out long processKey);
        
        [PreserveSig]
        HRESULT GetId(
            [Out] out long processId);
    }
}
