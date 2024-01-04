using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("316D57FC-A856-400A-A259-93D9166955AF")]
    [ComImport]
    public interface ISvcEventArgumentExecutionStateChange
    {
        [PreserveSig]
        SvcExecutionStateChangeKind GetChangeKind();
        
        [PreserveSig]
        HRESULT GetChangeEffects(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit executionUnit);
    }
}
