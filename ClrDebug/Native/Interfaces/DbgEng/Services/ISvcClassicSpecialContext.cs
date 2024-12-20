using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcClassicSpecialContext interface is provided by register contexts have a portion of their backing store given by a platform specific KSPECIAL_REGISTERS structure.<para/>
    /// No register context is required to support this interface. Any register context which supports this interface *IS REQUIRED* to support ISvcRegisterContext.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("33D1251E-BD8C-489E-B07A-CC545A27042C")]
    [ComImport]
    public interface ISvcClassicSpecialContext
    {
        /// <summary>
        /// Gets the size of the special context structure (KSPECIAL_REGISTERS for the given architecture that this ISvcClassicSpecialContext represents).
        /// </summary>
        [PreserveSig]
        long GetSpecialContextSize();

        /// <summary>
        /// Fills in a KSPECIAL_REGISTERS structure for the given machine architecture.
        /// </summary>
        [PreserveSig]
        HRESULT GetSpecialContext(
            [In] long bufferSize,
            [Out] IntPtr contextBuffer,
            [Out] out long contextSize);

        /// <summary>
        /// Changes the values in this register context to the ones given by the incoming KSPECIAL_REGISTERS structure.
        /// </summary>
        [PreserveSig]
        HRESULT SetSpecialContext(
            [In] long bufferSize,
            [In] IntPtr contextBuffer);
    }
}
