using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that extend the capabilities of "ICorDebugCode".
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5F696509-452F-4436-A3FE-4D11FE7E2347")]
    [ComImport]
    public interface ICorDebugCode2
    {
        /// <summary>
        /// Gets the chunks of code that this code object is composed of.
        /// </summary>
        /// <param name="cbufSize">[in] Size of the chunks array.</param>
        /// <param name="pcnumChunks">[out] The number of chunks returned in the chunks array.</param>
        /// <param name="chunks">[out] An array of "CodeChunkInfo" structures, each of which represents a single chunk of code. If the value of cbufSize is 0, this parameter can be null.</param>
        /// <remarks>
        /// The code chunks will never overlap, and they will follow the order in which they would have been concatenated by
        /// <see cref="ICorDebugCode.GetCode"/>. A Microsoft intermediate language (MSIL) code object in the .NET Framework
        /// version 2.0 will comprise a single code chunk.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCodeChunks([In] int cbufSize, [Out] out int pcnumChunks, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] CodeChunkInfo[] chunks);

        /// <summary>
        /// Gets the flags that specify the conditions under which this code object was either just-in-time (JIT) compiled or generated using the native image generator (Ngen.exe).
        /// </summary>
        /// <param name="pdwFlags">[out] A pointer to a value of the <see cref="CorDebugJITCompilerFlags"/> enumeration that specifies the behavior of the JIT compiler or the native image generator.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCompilerFlags([Out] out CorDebugJITCompilerFlags pdwFlags);
    }
}