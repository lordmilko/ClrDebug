using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E4622136-927D-4490-874F-581F3E4E3688")]
    [ComImport]
    public interface IModelIterator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] indexers,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
    }
}
