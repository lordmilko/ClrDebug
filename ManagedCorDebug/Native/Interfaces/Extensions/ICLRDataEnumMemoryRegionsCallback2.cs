using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3721A26F-8B91-4D98-A388-DB17B356FADB")]
    [ComImport]
    public interface ICLRDataEnumMemoryRegionsCallback2 : ICLRDataEnumMemoryRegionsCallback
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT EnumMemoryRegion([In] ulong address, [In] uint size);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UpdateMemoryRegion([In] ulong address, [In] uint bufferSize, [In] ref byte buffer);
    }
}