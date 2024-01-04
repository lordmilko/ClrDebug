using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2F79D431-71BF-4F40-B959-96361E92AD04")]
    [ComImport]
    public interface ISvcStackProviderFrame
    {
        [PreserveSig]
        StackProviderFrameKind GetFrameKind();
    }
}
