using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("2D7BABEB-4415-4A19-8BE0-DFACC7611594")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISymUnmanagedCompilerInfoReader
    {
        /// <summary>
        /// Returns compiler version number and name.
        /// </summary>
        [PreserveSig]
        HRESULT GetCompilerInfo(
            [Out] out int major,
            [Out] out int minor,
            [Out] out int build,
            [Out] out int revision,
            [In] int bufferLength,
            [Out] out int count,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0), SRI.Out] char[] name);
    }
}
