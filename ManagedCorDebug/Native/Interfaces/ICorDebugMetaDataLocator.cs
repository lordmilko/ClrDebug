using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("7CEF8BA9-2EF7-42BF-973F-4171474F87D9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugMetaDataLocator
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMetaData(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszImagePath,
            [In] uint dwImageTimeStamp,
            [In] uint dwImageSize,
            [In] uint cchPathBuffer,
            out uint pcchPathBuffer,
            [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugMetaDataLocator wszPathBuffer);
    }
}