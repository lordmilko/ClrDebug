using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BCDD6908-BA2D-4EC5-96CF-DF4D5CDCB4A4")]
    [ComImport]
    public interface ICLRDataEnumMemoryRegionsCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumMemoryRegion([In] ulong address, [In] uint size);
    }
}