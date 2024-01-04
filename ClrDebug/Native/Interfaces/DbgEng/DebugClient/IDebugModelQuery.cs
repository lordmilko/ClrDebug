using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4E7B1C9E-9D91-4054-9B9F-DABE4277D1EC")]
    [ComImport]
    public interface IDebugModelQuery
    {
        [PreserveSig]
        HRESULT QueryModel(
            [MarshalAs(UnmanagedType.LPWStr), In] string queryString,
            [In] MODEL_QUERY flags,
            [In] int recursionDepth,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);

        [PreserveSig]
        HRESULT QueryModelForCompletion(
            [MarshalAs(UnmanagedType.LPWStr), In] string queryString,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);

        [PreserveSig]
        HRESULT WriteModel(
            [MarshalAs(UnmanagedType.LPWStr), In] string lvalueExpression,
            [MarshalAs(UnmanagedType.LPWStr), In] string rvalueExpression,
            [In] MODEL_QUERY flags,
            [In] int recursionDepth,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);
    }
}
