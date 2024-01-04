using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D2419F4A-7E8D-4C15-A499-73902B015ABB")]
    [ComImport]
    public interface IDebugHostEvaluator3 : IDebugHostEvaluator2
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
        new HRESULT AssignTo(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject assignmentReference,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject assignmentValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject assignmentResult,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore assignmentMetadata);
        
        [PreserveSig]
        HRESULT Compare(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pLeft,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pRight,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult);
    }
}
