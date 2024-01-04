using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2DDF4CC0-BBA8-4FB0-BD53-5F4C92218280")]
    [ComImport]
    public interface ISvcAddressContext
    {
        [PreserveSig]
        AddressContextKind GetAddressContextKind();
    }
}
