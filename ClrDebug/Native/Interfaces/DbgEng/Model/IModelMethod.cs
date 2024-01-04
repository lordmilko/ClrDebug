using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("80600C1F-B90B-4896-82AD-1C00207909E8")]
    [ComImport]
    public interface IModelMethod
    {
        [PreserveSig]
        HRESULT Call(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pContextObject,
            [In] long argCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] ppArguments,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore ppMetadata);
    }
}
