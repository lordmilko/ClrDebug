using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F980577B-73FA-40FE-95A3-C4D44100FD68")]
    [ComImport]
    public interface ISvcWindowsKdInfrastructure
    {
        /// <summary>
        /// Finds the KD version block and returns its address. If the version block is not located within the address space of the debug source, this may fail.<para/>
        /// In such cases, GetKdVersionBlock may be called.
        /// </summary>
        [PreserveSig]
        HRESULT FindKdVersionBlock(
            [Out] out long kdVersionBlockAddress);

        /// <summary>
        /// Finds the KD debugger data block and returns its address. If the debugger data block is not located within the address space of the debug source, this may fail.<para/>
        /// In such cases, GetKdDebuggerDataBlock may be called.
        /// </summary>
        [PreserveSig]
        HRESULT FindKdDebuggerDataBlock(
            [Out] out long kdDebuggerDataBlockAddress);

        /// <summary>
        /// Retrieves a pointer to the read debugger data block in memory. The valid size of the block is returned as well.<para/>
        /// This pointer is guaranteed to be valid until the virtual memory service in the service stack changes. In this case, any cached copy of this pointer must be flushed and reread.
        /// </summary>
        [PreserveSig]
        HRESULT GetKdDebuggerDataBlock(
            [Out] out IntPtr kdDebuggerDataBlock,
            [Out] out long dataBlockSize);
    }
}
