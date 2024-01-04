using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6BB27B35-02E6-47CB-90A0-5371244032DE")]
    [ComImport]
    public interface IDataModelScriptDebugBreakpoint
    {
        [PreserveSig]
        long GetId();
        
        [return: MarshalAs(UnmanagedType.U1)]
        bool IsEnabled();
        
        [PreserveSig]
        void Enable();
        
        [PreserveSig]
        void Disable();
        
        [PreserveSig]
        void Remove();
        
        [PreserveSig]
        HRESULT GetPosition(
            [Out] out ScriptDebugPosition position,
            [Out] out ScriptDebugPosition positionSpanEnd,
            [Out, MarshalAs(UnmanagedType.BStr)] out string lineText);
    }
}
