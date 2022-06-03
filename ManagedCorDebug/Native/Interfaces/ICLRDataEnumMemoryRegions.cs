using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("471C35B4-7C2F-4EF0-A945-00F8C38056F1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICLRDataEnumMemoryRegions
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumMemoryRegions(
            [MarshalAs(UnmanagedType.Interface), In]
            ICLRDataEnumMemoryRegionsCallback callback,
            [In] uint miniDumpFlags,
            [In] CLRDataEnumMemoryFlags clrFlags);
    }
}