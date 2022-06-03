using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3721A26F-8B91-4D98-A388-DB17B356FADB")]
    [ComImport]
    public interface ICLRDataEnumMemoryRegionsCallback2 : ICLRDataEnumMemoryRegionsCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void EnumMemoryRegion([In] ulong address, [In] uint size);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UpdateMemoryRegion([In] ulong address, [In] uint bufferSize, [In] ref byte buffer);
    }
}