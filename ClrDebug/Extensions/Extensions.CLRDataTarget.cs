using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        #region ReadVirtual<T>

        /// <summary>
        /// Reads data from the specified virtual memory address.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be read.</param>
        /// <param name="address">A CLRDATA_ADDRESS that stores the virtual memory address.</param>
        /// <returns>The value that was read.</returns>
        public static T ReadVirtual<T>(this CLRDataTarget dataTarget, CORDB_ADDRESS address) where T : struct
        {
            T value;
            TryReadVirtual(dataTarget, address, out value).ThrowOnNotOK();
            return value;
        }

        /// <summary>
        /// Tries to read data from the specified virtual memory address.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be read.</param>
        /// <param name="address">A CLRDATA_ADDRESS that stores the virtual memory address.</param>
        /// <param name="value">The value that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadVirtual<T>(this CLRDataTarget dataTarget, CORDB_ADDRESS address, out T value) where T : struct
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
        /// Reads data from the specified virtual memory address.
        /// </summary>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be read.</param>
        /// <param name="address">A CLRDATA_ADDRESS that stores the virtual memory address.</param>
        /// <param name="size">The number of bytes to get from the target address.</param>
        /// <returns>The bytes that were read. The number of bytes successfully read may be less than <paramref name="size"/>.</returns>
        public static byte[] ReadVirtual(this CLRDataTarget dataTarget, CORDB_ADDRESS address, int size)
        {
            byte[] value;
            TryReadVirtual(dataTarget, address, size, out value).ThrowOnNotOK();
            return value;
        }

        /// <summary>
        /// Tries to read data from the specified virtual memory address.
        /// </summary>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be read.</param>
        /// <param name="address">A CLRDATA_ADDRESS that stores the virtual memory address.</param>
        /// <param name="size">The number of bytes to get from the target address.</param>
        /// <param name="value">The bytes that were read. The number of bytes successfully read may be less than <paramref name="size"/>.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadVirtual(this CLRDataTarget dataTarget, CORDB_ADDRESS address, int size, out byte[] value)
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
        /// Writes data from the specified buffer to the specified virtual memory address.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be written to.</param>
        /// <param name="address">The address at which to write the specified value.</param>
        /// <param name="value">The value to be written.</param>
        /// <returns>The actual number of bytes that were written.</returns>
        public static int WriteVirtual<T>(this CLRDataTarget dataTarget, CORDB_ADDRESS address, T value) where T : struct
        {
            int bytesWritten;
            TryWriteVirtual(dataTarget, address, value, out bytesWritten).ThrowOnNotOK();
            return bytesWritten;
        }

        /// <summary>
        /// Tries to write data from the specified buffer to the specified virtual memory address.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be written to.</param>
        /// <param name="address">The address at which to write the specified value.</param>
        /// <param name="value">The value to be written.</param>
        /// <param name="bytesWritten">The actual number of bytes that were written.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteVirtual<T>(this CLRDataTarget dataTarget, CORDB_ADDRESS address, T value, out int bytesWritten) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);

                var hr = dataTarget.TryWriteVirtual(address, buffer, size, out bytesWritten);

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
        /// Writes data from the specified buffer to the specified virtual memory address.
        /// </summary>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be written to.</param>
        /// <param name="address">The address at which to write the specified value.</param>
        /// <param name="value">The value to be written.</param>
        /// <returns>The actual number of bytes that were written.</returns>
        public static int WriteVirtual(this CLRDataTarget dataTarget, CORDB_ADDRESS address, byte[] value)
        {
            int bytesWritten;
            TryWriteVirtual(dataTarget, address, value, out bytesWritten).ThrowOnNotOK();
            return bytesWritten;
        }

        /// <summary>
        /// Tries to write data from the specified buffer to the specified virtual memory address.
        /// </summary>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> whose memory should be written to.</param>
        /// <param name="address">The address at which to write the specified value.</param>
        /// <param name="value">The value to be written.</param>
        /// <param name="bytesWritten">The actual number of bytes that were written.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteVirtual(this CLRDataTarget dataTarget, CORDB_ADDRESS address, byte[] value, out int bytesWritten)
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

                var hr = dataTarget.TryWriteVirtual(address, buffer, value.Length, out bytesWritten);

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
        /// Gets the current execution context for the given thread in the target process. This method is called by the common language runtime data access services.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> containing the thread whose context should be retrieved.</param>
        /// <param name="threadId">The operating system identifier of a thread in the target process.</param>
        /// <param name="contextFlags">Flags that specify which parts of the context to return. The implementation will return at least these parts of the context.</param>
        /// <returns>The thread context that was read.</returns>
        public static T GetThreadContext<T>(this CLRDataTarget dataTarget, int threadId, ContextFlags contextFlags) where T : struct
        {
            T context;
            TryGetThreadContext(dataTarget, threadId, contextFlags, out context).ThrowOnNotOK();
            return context;
        }

        /// <summary>
        /// Tries to get the current execution context for the given thread in the target process. This method is called by the common language runtime data access services.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> containing the thread whose context should be retrieved.</param>
        /// <param name="threadId">The operating system identifier of a thread in the target process.</param>
        /// <param name="contextFlags">Flags that specify which parts of the context to return. The implementation will return at least these parts of the context.</param>
        /// <param name="context">The thread context that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetThreadContext<T>(this CLRDataTarget dataTarget, int threadId, ContextFlags contextFlags, out T context) where T : struct
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
                Marshal.AllocHGlobal(buffer);
            }
        }

        #endregion
        #region SetThreadContext<T>

        /// <summary>
        /// Sets the current context of the specified thread in the target process.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> containing the thread whose context should be modified.</param>
        /// <param name="threadId">The operating system identifier of a thread in the target process.</param>
        /// <param name="context">The context to set. The data in the context buffer will be in the format of the Win32 CONTEXT structure.</param>
        public static void SetThreadContext<T>(this CLRDataTarget dataTarget, int threadId, T context) where T : struct
        {
            TrySetThreadContext(dataTarget, threadId, context).ThrowOnNotOK();
        }

        /// <summary>
        /// Tries to set the current context of the specified thread in the target process.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="dataTarget">The <see cref="CLRDataTarget"/> containing the thread whose context should be modified.</param>
        /// <param name="threadId">The operating system identifier of a thread in the target process.</param>
        /// <param name="context">The context to set. The data in the context buffer will be in the format of the Win32 CONTEXT structure.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TrySetThreadContext<T>(this CLRDataTarget dataTarget, int threadId, T context) where T : struct
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
