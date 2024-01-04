using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4D0BDD20-61CD-4F18-936A-7E9350B30966")]
    [ComImport]
    public interface ISvcStackProviderInlineFrame
    {
        [PreserveSig]
        HRESULT GetUnderlyingFrame(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrame ppFrame);
        
        [PreserveSig]
        long GetInlineDepth();
        
        [PreserveSig]
        long GetMaximalInlineDepth();
    }
}
