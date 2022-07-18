using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes a user minidump to read.
    /// </summary>
    /// <remarks>
    /// The DEBUG_REQUEST_READ_USER_MINIDUMP_STREAM <see cref="IDebugAdvanced2.Request"/> operation reads a stream from
    /// a user-mode minidump target. The DEBUG_READ_USER_MINIDUMP_STREAM structure holds the parameters for the DEBUG_REQUEST_READ_USER_MINIDUMP_STREAM
    /// <see cref="IDebugAdvanced2.Request"/> operation. The target must be a user-mode minidump file. Each minidump file
    /// contains a number of streams. These streams are blocks of data written to the minidump file.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_READ_USER_MINIDUMP_STREAM
    {
        /// <summary>
        /// The type of stream.
        /// </summary>
        public uint StreamType;

        /// <summary>
        /// Flags.
        /// </summary>
        public uint Flags;

        /// <summary>
        /// The offset of stream.
        /// </summary>
        public ulong Offset;

        /// <summary>
        /// Specifies the beginning of the buffer to read.
        /// </summary>
        public IntPtr Buffer;

        /// <summary>
        /// Specifies the length of the buffer to read.
        /// </summary>
        public uint BufferSize;

        /// <summary>
        /// The buffer used value.
        /// </summary>
        public uint BufferUsed;
    }
}