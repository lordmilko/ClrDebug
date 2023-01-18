using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region CreateVirtualUnwinder

        /// <summary>
        /// Creates a new stack unwinder that starts unwinding from an initial context (which isn't necessarily the leaf of a thread).
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure to be passed as the initial context.</typeparam>
        /// <param name="dataTarget">The <see cref="CorDebugDataTarget"/> containing the stack to unwind.</param>
        /// <param name="nativeThreadID">The native thread ID of the thread whose stack is to be unwound.</param>
        /// <param name="contextFlags">Flags that specify which parts of the context are defined in initialContext.</param>
        /// <param name="initialContext">The initial context to pass to the unwinder.</param>
        /// <returns>A <see cref="CorDebugVirtualUnwinder"/> object.</returns>
        public static CorDebugVirtualUnwinder CreateVirtualUnwinder<T>(
            this CorDebugDataTarget dataTarget,
            int nativeThreadID,
            ContextFlags contextFlags,
            T initialContext)
        {
            CorDebugVirtualUnwinder ppUnwinderResult;
            TryCreateVirtualUnwinder<T>(dataTarget, nativeThreadID, contextFlags, initialContext, out ppUnwinderResult).ThrowOnNotOK();
            return ppUnwinderResult;
        }

        /// <summary>
        /// Tries to create a new stack unwinder that starts unwinding from an initial context (which isn't necessarily the leaf of a thread).
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure to be passed as the initial context.</typeparam>
        /// <param name="dataTarget">The <see cref="CorDebugDataTarget"/> containing the stack to unwind.</param>
        /// <param name="nativeThreadID">The native thread ID of the thread whose stack is to be unwound.</param>
        /// <param name="contextFlags">Flags that specify which parts of the context are defined in initialContext.</param>
        /// <param name="initialContext">The initial context to pass to the unwinder.</param>
        /// <param name="ppUnwinderResult">A <see cref="CorDebugVirtualUnwinder"/> object.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryCreateVirtualUnwinder<T>(
            this CorDebugDataTarget dataTarget,
            int nativeThreadID,
            ContextFlags contextFlags,
            T initialContext,
            out CorDebugVirtualUnwinder ppUnwinderResult)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(initialContext, buffer, false);

                return dataTarget.TryCreateVirtualUnwinder(nativeThreadID, contextFlags, size, buffer, out ppUnwinderResult);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadVirtual<T>

        /// <summary>
        /// Gets a block of contiguous memory starting at the specified address.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataTarget">The <see cref="CorDebugDataTarget"/> whose memory should be read.</param>
        /// <param name="address">The start address of requested memory.</param>
        /// <returns>The value that was read.</returns>
        public static T ReadVirtual<T>(this CorDebugDataTarget dataTarget, CORDB_ADDRESS address) where T : struct
        {
            T value;
            TryReadVirtual(dataTarget, address, out value).ThrowOnNotOK();
            return value;
        }

        /// <summary>
        /// Tries to get a block of contiguous memory starting at the specified address.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataTarget">The <see cref="CorDebugDataTarget"/> whose memory should be read.</param>
        /// <param name="address">The start address of requested memory.</param>
        /// <param name="value">The value that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadVirtual<T>(this CorDebugDataTarget dataTarget, CORDB_ADDRESS address, out T value) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataTarget.TryReadVirtual(address, buffer, size, out read);

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
        #region ReadVirtual (byte[])

        /// <summary>
        /// Gets a block of contiguous memory starting at the specified address.
        /// </summary>
        /// <param name="dataTarget">The <see cref="CorDebugDataTarget"/> whose memory should be read.</param>
        /// <param name="address">The start address of requested memory.</param>
        /// <param name="size">The number of bytes to get from the target address.</param>
        /// <returns>The bytes that were read. The number of bytes successfully read may be less than <paramref name="size"/>.</returns>
        public static byte[] ReadVirtual(this CorDebugDataTarget dataTarget, CORDB_ADDRESS address, int size)
        {
            byte[] value;
            TryReadVirtual(dataTarget, address, size, out value).ThrowOnNotOK();
            return value;
        }

        /// <summary>
        /// Tries to get a block of contiguous memory starting at the specified address.
        /// </summary>
        /// <param name="dataTarget">The <see cref="CorDebugDataTarget"/> whose memory should be read.</param>
        /// <param name="address">The start address of requested memory.</param>
        /// <param name="size">The number of bytes to get from the target address.</param>
        /// <param name="value">The bytes that were read. The number of bytes successfully read may be less than <paramref name="size"/>.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadVirtual(this CorDebugDataTarget dataTarget, CORDB_ADDRESS address, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataTarget.TryReadVirtual(address, buffer, size, out read);

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
        #region WriteVirtual<T>

        /// <summary>
        /// Writes memory into the target process address space.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataTarget">The <see cref="CorDebugDataTarget"/> whose memory should be written to.</param>
        /// <param name="address">The address at which to write the specified value.</param>
        /// <param name="value">The value to be written.</param>
        public static void WriteVirtual<T>(this CorDebugMutableDataTarget dataTarget, CORDB_ADDRESS address, T value) where T : struct
        {
            TryWriteVirtual(dataTarget, address, value).ThrowOnNotOK();
        }

        /// <summary>
        /// Tries to write memory into the target process address space.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be written to.</param>
        /// <param name="address">The address at which to write the specified value.</param>
        /// <param name="value">The value to be written.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteVirtual<T>(this CorDebugMutableDataTarget dataTarget, CORDB_ADDRESS address, T value) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);

                var hr = dataTarget.TryWriteVirtual(address, buffer, size);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);

                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region WriteVirtual (byte[])

        /// <summary>
        /// Writes memory into the target process address space.
        /// </summary>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be written to.</param>
        /// <param name="address">The address at which to write the specified value.</param>
        /// <param name="value">The value to be written.</param>
        public static void WriteVirtual(this CorDebugMutableDataTarget dataTarget, CORDB_ADDRESS address, byte[] value)
        {
            TryWriteVirtual(dataTarget, address, value).ThrowOnNotOK();
        }

        /// <summary>
        /// Tries to write memory into the target process address space.
        /// </summary>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be written to.</param>
        /// <param name="address">The address at which to write the specified value.</param>
        /// <param name="value">The value to be written.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteVirtual(this CorDebugMutableDataTarget dataTarget, CORDB_ADDRESS address, byte[] value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            IntPtr buffer = IntPtr.Zero;

            try
            {
                if (value.Length != 0)
                {
                    buffer = Marshal.AllocHGlobal(value.Length);
                    Marshal.Copy(value, 0, buffer, value.Length);
                }

                var hr = dataTarget.TryWriteVirtual(address, buffer, value.Length);

                return hr;
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetThreadContext<T>

        /// <summary>
        /// Returns the current thread context for the specified thread.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="dataTarget">The <see cref="CorDebugDataTarget"/> containing the thread whose context should be retrieved.</param>
        /// <param name="threadId">The identifier of the thread whose context is to be retrieved. The identifier is defined by the operating system.</param>
        /// <param name="contextFlags">A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <returns>The thread context that was read.</returns>
        public static T GetThreadContext<T>(this CorDebugDataTarget dataTarget, int threadId, ContextFlags contextFlags) where T : struct
        {
            T context;
            TryGetThreadContext(dataTarget, threadId, contextFlags, out context).ThrowOnNotOK();
            return context;
        }

        /// <summary>
        /// Tries to return the current thread context for the specified thread.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="dataTarget">The <see cref="CorDebugDataTarget"/> containing the thread whose context should be retrieved.</param>
        /// <param name="threadId">The identifier of the thread whose context is to be retrieved. The identifier is defined by the operating system.</param>
        /// <param name="contextFlags">A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <param name="context">The thread context that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetThreadContext<T>(this CorDebugDataTarget dataTarget, int threadId, ContextFlags contextFlags, out T context) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                var hr = dataTarget.TryGetThreadContext(threadId, contextFlags, size, buffer);

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
        /// Sets the context (register values) for a thread.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="dataTarget">The <see cref="CorDebugMutableDataTarget"/> containing the thread whose context should be modified.</param>
        /// <param name="threadId">The operating system-defined thread identifier.</param>
        /// <param name="context">The context to set. The context specifies the architecture of the processor on which the thread is executing.</param>
        public static void SetThreadContext<T>(this CorDebugMutableDataTarget dataTarget, int threadId, T context) where T : struct
        {
            TrySetThreadContext(dataTarget, threadId, context).ThrowOnNotOK();
        }

        /// <summary>
        /// Tries to set the context (register values) for a thread.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="dataTarget">The <see cref="CorDebugMutableDataTarget"/> containing the thread whose context should be modified.</param>
        /// <param name="threadId">The operating system-defined thread identifier.</param>
        /// <param name="context">The context to set. The context specifies the architecture of the processor on which the thread is executing.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TrySetThreadContext<T>(this CorDebugMutableDataTarget dataTarget, int threadId, T context) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(context, buffer, false);

                return dataTarget.TrySetThreadContext(threadId, size, buffer);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
    }
}
