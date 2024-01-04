using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B91E34DE-6407-4583-BBAE-95FE20548363")]
    [ComImport]
    public interface ISvcRegisterInformation
    {
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string registerName);
        
        [PreserveSig]
        int GetId();
        
        [PreserveSig]
        SvcContextFlags GetFlags();
        
        [PreserveSig]
        int GetSize();
        
        [PreserveSig]
        HRESULT GetSubRegisterInformation(
            [Out] out int parentRegisterId,
            [Out] out int lsbOfMapping,
            [Out] out int msbOfMapping);
        
        [PreserveSig]
        HRESULT EnumerateRegisterFlags(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterFlagsEnumerator flagsEnum);
        
        [PreserveSig]
        HRESULT GetRegisterFlagInformation(
            [In] int position,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterFlagInformation flagInfo);
    }
}
