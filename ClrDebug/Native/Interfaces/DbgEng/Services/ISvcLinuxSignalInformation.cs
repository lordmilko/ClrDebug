using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DE815F6F-5824-4555-A010-286791BC79AD")]
    [ComImport]
    public interface ISvcLinuxSignalInformation
    {
        [PreserveSig]
        int GetSignalNumber();
        
        [PreserveSig]
        int GetErrorNumber();
        
        [PreserveSig]
        int GetSignalCode();
        
        [PreserveSig]
        HRESULT GetSourcePid(
            [Out] out long sourcePid);
    }
}
