using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    public delegate HRESULT DebugCreateDelegate(
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid InterfaceId,
        [Out] out IntPtr Interface);

    public delegate HRESULT DebugCreateExDelegate(
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid InterfaceId,
        [In] DEBUG_ENGOPT DbgEngOptions, [Out] out IntPtr Interface);

    public delegate HRESULT DebugConnectDelegate(
        [In, MarshalAs(UnmanagedType.LPStr)] string RemoteOptions,
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid InterfaceId,
        [Out] out IntPtr Interface);

    public delegate HRESULT DebugConnectWideDelegate(
        [In, MarshalAs(UnmanagedType.LPWStr)] string RemoteOptions,
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid InterfaceId,
        [Out] out IntPtr Interface);


    public static partial class DbgEngExtensions
    {
        public const int DMP_PHYSICAL_MEMORY_BLOCK_SIZE_32 = 700;
        public const int DMP_CONTEXT_RECORD_SIZE_32 = 1200;
        public const int DMP_RESERVED_0_SIZE_32 = 1768;
        public const int DMP_RESERVED_1_SIZE_32 = 4;
        public const int DMP_RESERVED_2_SIZE_32 = 16;
        public const int DMP_RESERVED_3_SIZE_32 = 56;

        public const int DMP_PHYSICAL_MEMORY_BLOCK_SIZE_64 = 700;
        public const int DMP_CONTEXT_RECORD_SIZE_64 = 3000;
        public const int DMP_RESERVED_0_SIZE_64 = 4024;

        public const int DMP_HEADER_COMMENT_SIZE = 128;

        public static void ThrowDbgEngNotOK(this HRESULT hr)
        {
            if (hr == HRESULT.S_FALSE)
                throw new DbgEngPartialResultsException($"DbgEng reported that the specified operation completed with partial results, however the caller expected DbgEng to complete with full results. HRESULT: {hr}");

            ThrowDbgEngFailed(hr);
        }

        public static HRESULT ThrowDbgEngFailed(this HRESULT hr)
        {
            if (hr == HRESULT.S_OK)
                return hr;

            if (hr == HRESULT.E_FAIL)
                throw new DbgEngOperationFailedException($"DbgEng reported that the specified operation could not be performed. HRESULT: {hr}");

            if (hr == HRESULT.E_INVALIDARG)
                throw new DbgEngArgumentException($"One of the arguments that was passed to DbgEng was invalid. HRESULT: {hr}");

            if (hr == HRESULT.E_NOINTERFACE)
                throw new DbgEngItemNotFoundException($"DbgEng reported that the value that was searched for could not be found on the specified target. HRESULT: {hr}");

            if (hr == HRESULT.E_OUTOFMEMORY)
                throw new DbgEngOutOfMemoryException("DbgEng could not allocate enough memory to complete the desired operation.");

            if (hr == HRESULT.E_UNEXPECTED)
                throw new DbgEngInvalidStateException($"DbgEng reported that the target does not support the specified operation, was not accessible, or is not currently in a state where the specified operation can be performed. HRESULT: {hr}");

            if (hr == HRESULT.E_NOTIMPL)
                throw new DbgEngNotImplementedException("DbgEng reported that the specified operation is not supported on the specified target.");

            throw new DebugException(hr);
        }
    }
}
