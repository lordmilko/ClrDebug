using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("e77a39ea-3548-44d9-b171-8569ed1a9423")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataExceptionNotification5
    {
        [PreserveSig]
        HRESULT OnCodeGenerated2(
            [In] IXCLRDataMethodInstance method,
            [In] CLRDATA_ADDRESS nativeCodeLocation);
    }
}
