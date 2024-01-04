using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("53FBB33A-2F42-4465-9F02-0899ABF13460")]
    [ComImport]
    public interface ISvcBreakpointEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpoint ppBreakpoint);
    }
}
