using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("81E83593-5AA9-43AA-8A5D-B964411E4B53")]
    [ComImport]
    public interface ISvcStackProviderFrameSetEnumerator
    {
        [PreserveSig]
        HRESULT GetUnwindContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackUnwindContext unwindContext);
        
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetCurrentFrame(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrame currentFrame);
        
        [PreserveSig]
        HRESULT MoveNext();
    }
}
