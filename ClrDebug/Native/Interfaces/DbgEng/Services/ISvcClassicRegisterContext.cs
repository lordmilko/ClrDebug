using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcClassicRegisterContext interface is provided by register contexts whose backing store is a platform specific CONTEXT structure.<para/>
    /// No register context is required to support this interface. Any register context which supports this interface *IS REQUIRED* to support ISvcRegisterContext.<para/>
    /// Note that one can achieve the same thing by getting the DEBUG_SERVICE_REGISTERCONTEXTTRANSLATION for the Windows platform domain.<para/>
    /// This is just faster for contexts that support such.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D9E1F476-4FAE-4051-89C9-45D25925DB41")]
    [ComImport]
    public interface ISvcClassicRegisterContext
    {
        /// <summary>
        /// Gets the size of the context structure (CONTEXT for the given architecture that this ISvcClassicRegisterContext represents).
        /// </summary>
        [PreserveSig]
        long GetContextSize();

        /// <summary>
        /// Fills in a Win32 CONTEXT structure for the given machine architecture.
        /// </summary>
        [PreserveSig]
        HRESULT GetContext(
            [In] long bufferSize,
            [Out] IntPtr contextBuffer,
            [Out] out long contextSize);

        /// <summary>
        /// Changes the values in this register context to the ones given by the incoming Win32 CONTEXT structure.
        /// </summary>
        [PreserveSig]
        HRESULT SetContext(
            [In] long bufferSize,
            [In] IntPtr contextBuffer);
    }
}
