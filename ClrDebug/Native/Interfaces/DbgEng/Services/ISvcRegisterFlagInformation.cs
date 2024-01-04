using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5ED13135-FA5D-4D29-BB93-C80CB72ADFD4")]
    [ComImport]
    public interface ISvcRegisterFlagInformation
    {
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string flagName);
        
        [PreserveSig]
        HRESULT GetAbbreviation(
            [Out, MarshalAs(UnmanagedType.BStr)] out string abbrevName);
        
        [PreserveSig]
        int GetPosition();
        
        [PreserveSig]
        int GetSize();
    }
}
