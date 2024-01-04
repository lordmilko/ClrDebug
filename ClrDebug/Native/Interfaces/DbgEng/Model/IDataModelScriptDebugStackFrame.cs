using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DEC6ED5E-6360-4941-AB4C-A26409DE4F82")]
    [ComImport]
    public interface IDataModelScriptDebugStackFrame
    {
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);
        
        [PreserveSig]
        HRESULT GetPosition(
            [Out] out ScriptDebugPosition position,
            [Out] out ScriptDebugPosition positionSpanEnd,
            [Out, MarshalAs(UnmanagedType.BStr)] out string lineText);
        
        [PreserveSig]
        HRESULT IsTransitionPoint(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isTransitionPoint);
        
        [PreserveSig]
        HRESULT GetTransition(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScript transitionScript,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isTransitionContiguous);
        
        [PreserveSig]
        HRESULT Evaluate(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszExpression,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult);
        
        [PreserveSig]
        HRESULT EnumerateLocals(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugVariableSetEnumerator variablesEnum);
        
        [PreserveSig]
        HRESULT EnumerateArguments(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugVariableSetEnumerator variablesEnum);
    }
}
