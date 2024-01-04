using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A117A435-1FB4-4092-A2AB-A929576C1E87")]
    [ComImport]
    public interface IDebugHostEvaluator2 : IDebugHostEvaluator
    {
        [PreserveSig]
        new HRESULT EvaluateExpression(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string expression,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject bindingContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject result,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        new HRESULT EvaluateExtendedExpression(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string expression,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject bindingContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject result,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
        
        [PreserveSig]
        HRESULT AssignTo(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject assignmentReference,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject assignmentValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject assignmentResult,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore assignmentMetadata);
    }
}
