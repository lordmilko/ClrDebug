using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E92274A2-47F4-4538-A196-B83DB25FE403")]
    [ComImport]
    public interface IDebugHostContext2 : IDebugHostContext
    {
        [PreserveSig]
        new HRESULT IsEqualTo(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext pContext,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsEqual);
        
        [PreserveSig]
        HRESULT GetAddressSpaceRelation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext2 pContext,
            [Out] out AddressSpaceRelation pAddressSpaceRelation);
    }
}
