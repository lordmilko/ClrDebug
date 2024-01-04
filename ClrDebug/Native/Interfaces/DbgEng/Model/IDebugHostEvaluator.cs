using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0FEF9A21-577E-4997-AC7B-1C4883241D99")]
    [ComImport]
    public interface IDebugHostEvaluator
    {
        [PreserveSig]
        HRESULT EvaluateExpression(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string expression,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject bindingContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject result,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        HRESULT EvaluateExtendedExpression(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string expression,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject bindingContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject result,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
    }
}
