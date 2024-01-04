using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E44474E7-99EC-40D5-9C94-7554EA45C4CF")]
    [ComImport]
    public interface IComponentStackUnwinderStackProviderInitializer
    {
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.U1)] bool provideInlineFrames);
    }
}
