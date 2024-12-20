using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7EBB44D0-3C22-41E1-AAB9-083E774CFF5D")]
    [ComImport]
    public interface ISvcDebugSourceFileMapping
    {
        /// <summary>
        /// Returns a complete memory mapping of the file. Note that this entire interface can only be used in process and is in no way required of a source file implementation.
        /// </summary>
        [PreserveSig]
        HRESULT MapFile(
            [Out] out IntPtr mapAddress,
            [Out] out long mapSize);

        /// <summary>
        /// Gets the original handle associated with this file mapping.
        /// </summary>
        [PreserveSig]
        HRESULT GetHandle(
            [Out] out IntPtr pHandle);
    }
}
