using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region ReadMemory<T>

        /// <summary>
        /// Reads a specified area of memory for this process.<para/>
        /// All reads by <see cref="ICorDebugProcess.ReadMemory(CORDB_ADDRESS, int, IntPtr, out int)"/> are internally split across page boundaries.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="process">The <see cref="CorDebugProcess"/> whose memory should be read.</param>
        /// <param name="address">A <see cref="CORDB_ADDRESS"/> value that specifies the base address of the memory to be read.</param>
        /// <returns>The value that was read.</returns>
        public static T ReadMemory<T>(this CorDebugProcess process, CORDB_ADDRESS address) where T : struct
        {
            T value;
            TryReadMemory(process, address, out value).ThrowOnNotOK();
            return value;
        }

        /// <summary>
        /// Tries to read a specified area of memory for this process.<para/>
        /// All reads by <see cref="ICorDebugProcess.ReadMemory(CORDB_ADDRESS, int, IntPtr, out int)"/> are internally split across page boundaries.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="process">The <see cref="CorDebugProcess"/> whose memory should be read.</param>
        /// <param name="address">A <see cref="CORDB_ADDRESS"/> value that specifies the base address of the memory to be read.</param>
        /// <param name="value">The value that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadMemory<T>(this CorDebugProcess process, CORDB_ADDRESS address, out T value) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = process.TryReadMemory(address, size, buffer, out read);

                if (hr == HRESULT.S_OK)
                    value = Marshal.PtrToStructure<T>(buffer);
                else
                    value = default(T);

                return hr;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadMemory (byte[])

        /// <summary>
        /// Reads a specified area of memory for this process.<para/>
        /// All reads by <see cref="ICorDebugProcess.ReadMemory(CORDB_ADDRESS, int, IntPtr, out int)"/> are internally split across page boundaries.
        /// </summary>
        /// <param name="process">The <see cref="CorDebugProcess"/> whose memory should be read.</param>
        /// <param name="address">A <see cref="CORDB_ADDRESS"/> value that specifies the base address of the memory to be read.</param>
        /// <param name="size">The number of bytes to read.</param>
        /// <returns>The bytes that were read. The number of bytes successfully read may be less than <paramref name="size"/>.</returns>
        public static byte[] ReadMemory(this CorDebugProcess process, CORDB_ADDRESS address, int size)
        {
            byte[] value;
            TryReadMemory(process, address, size, out value).ThrowOnNotOK();
            return value;
        }

        /// <summary>
        /// Tries to read a specified area of memory for this process.<para/>
        /// All reads by <see cref="ICorDebugProcess.ReadMemory(CORDB_ADDRESS, int, IntPtr, out int)"/> are internally split across page boundaries.
        /// </summary>
        /// <param name="process">The <see cref="CorDebugProcess"/> whose memory should be read.</param>
        /// <param name="address">A <see cref="CORDB_ADDRESS"/> value that specifies the base address of the memory to be read.</param>
        /// <param name="size">The number of bytes to read.</param>
        /// <param name="value">The bytes that were read. The number of bytes successfully read may be less than <paramref name="size"/>.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadMemory(this CorDebugProcess process, CORDB_ADDRESS address, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = process.TryReadMemory(address, size, buffer, out read);

                if (hr == HRESULT.S_OK)
                {
                    value = new byte[read];
                    Marshal.Copy(buffer, value, 0, read);
                }
                else
                    value = null;

                return hr;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetThreadContext<T>

        /// <summary>
        /// Gets the context for the given thread in this process.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="process">The <see cref="CorDebugProcess"/> containing the thread whose context should be retrieved.</param>
        /// <param name="threadId">The identifier of the thread whose context is to be retrieved. The identifier is defined by the operating system.</param>
        /// <param name="contextFlags">A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <returns>The thread context that was read.</returns>
        public static T GetThreadContext<T>(this CorDebugProcess process, int threadId, ContextFlags contextFlags) where T : struct
        {
            T context;
            TryGetThreadContext(process, threadId, contextFlags, out context).ThrowOnNotOK();
            return context;
        }

        /// <summary>
        /// Tries to get the context for the given thread in this process.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="process">The <see cref="CorDebugProcess"/> containing the thread whose context should be retrieved.</param>
        /// <param name="threadId">The identifier of the thread whose context is to be retrieved. The identifier is defined by the operating system.</param>
        /// <param name="contextFlags">A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <param name="context">The thread context that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetThreadContext<T>(this CorDebugProcess process, int threadId, ContextFlags contextFlags, out T context) where T : struct
        {
            var size = Marshal.SizeOf<T>();

            var buffer = AllocAndInitContext<T>(size, contextFlags);

            try
            {
                var hr = process.TryGetThreadContext(threadId, size, buffer);

                if (hr == HRESULT.S_OK)
                    context = Marshal.PtrToStructure<T>(buffer);
                else
                    context = default(T);

                return hr;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region SetThreadContext<T>

        /// <summary>
        /// Sets the context for the given thread in this process.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="process">The <see cref="CorDebugProcess"/> containing the thread whose context should be modified.</param>
        /// <param name="threadId">The ID of the thread for which to set the context.</param>
        /// <param name="context">The context to set. The context specifies the architecture of the processor on which the thread is executing.</param>
        public static void SetThreadContext<T>(this CorDebugProcess process, int threadId, T context) where T : struct
        {
            TrySetThreadContext(process, threadId, context).ThrowOnNotOK();
        }

        /// <summary>
        /// Tries to set the context for the given thread in this process.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="process">The <see cref="CorDebugProcess"/> containing the thread whose context should be modified.</param>
        /// <param name="threadId">The ID of the thread for which to set the context.</param>
        /// <param name="context">The context to set. The context specifies the architecture of the processor on which the thread is executing.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TrySetThreadContext<T>(this CorDebugProcess process, int threadId, T context) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(context, buffer, false);

                return process.TrySetThreadContext(threadId, size, buffer);
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
    }
}
