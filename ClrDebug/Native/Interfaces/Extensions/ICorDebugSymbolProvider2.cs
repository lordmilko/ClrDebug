using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Logically extends the <see cref="ICorDebugSymbolProvider"/> interface to retrieve additional debug symbol information.
    /// </summary>
    [Guid("F9801807-4764-4330-9E67-4F685094165E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugSymbolProvider2
    {
        /// <summary>
        /// Retrieves a generic dictionary map.
        /// </summary>
        /// <param name="ppMemoryBuffer">[out] A pointer to the address of an <see cref="ICorDebugMemoryBuffer"/> object containing the generic dictionary map.<para/>
        /// See the Remarks section for more information.</param>
        /// <remarks>
        /// The map consists of two top-level sections: 
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetGenericDictionaryInfo(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);

        /// <summary>
        /// Returns the method starting relative virtual address of a method and the parent frame given a code relative virtual address.
        /// </summary>
        /// <param name="codeRva">[in] A code relative virtual address.</param>
        /// <param name="pCodeStartRva">[out] A pointer to the method's starting relative virtual address.</param>
        /// <param name="pParentFrameStartRva">[out] A pointer to the frame's starting relative virtual address.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFrameProps(
            [In] int codeRva,
            [Out] out int pCodeStartRva,
            [Out] out int pParentFrameStartRva);
    }
}
