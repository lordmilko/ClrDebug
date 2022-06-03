using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("AA8FA804-BC05-4642-B2C5-C353ED22FC63")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICLRMetadataLocator
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMetadata(
            [MarshalAs(UnmanagedType.LPWStr), In] string imagePath,
            [In] uint imageTimestamp,
            [In] uint imageSize,
            [In] ref Guid mvid,
            [In] uint mdRva,
            [In] uint flags,
            [In] uint bufferSize,
            out byte buffer,
            out uint dataSize);
    }
}