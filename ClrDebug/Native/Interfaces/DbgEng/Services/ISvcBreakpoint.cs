using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("862E028B-A31A-4AAA-9661-6470F3D50B25")]
    [ComImport]
    public interface ISvcBreakpoint
    {
        [PreserveSig]
        BreakpointKind GetKind();
        
        [PreserveSig]
        long GetProcessKey();
        
        [PreserveSig]
        long GetAddress();
        
        [PreserveSig]
        HRESULT Delete();
        
        [PreserveSig]
        HRESULT Disable();
        
        [PreserveSig]
        HRESULT Enable();
        
        [PreserveSig]
        HRESULT GetDataAccessFlags(
            [Out] out DataAccessFlags pFlags);
        
        [PreserveSig]
        HRESULT GetDataWidth(
            [Out] out long pWidth);
    }
}
