using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    public static partial class DbgEngExtensions
    {
        #region ReadVirtual<T>

        /// <summary>
        /// The ReadVirtual method reads memory from the target's virtual address space.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be read.</param>
        /// <returns>Specifies the buffer to read the memory into.</returns>
        public static T ReadVirtual<T>(this DebugDataSpaces dataSpaces, long offset)
        {
            T value;
            TryReadVirtual(dataSpaces, offset, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadVirtual method reads memory from the target's virtual address space.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="value">Specifies the buffer to read the memory into.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadVirtual<T>(this DebugDataSpaces dataSpaces, long offset, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadVirtual(offset, buffer, size, out read);

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
        /// The ReadVirtual method reads memory from the target's virtual address space.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="size">Specifies the size in bytes of the buffer. This is also the number of bytes being requested.</param>
        /// <returns>Specifies the buffer to read the memory into.</returns>
        public static byte[] ReadVirtual(this DebugDataSpaces dataSpaces, long offset, int size)
        {
            byte[] value;
            TryReadVirtual(dataSpaces, offset, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadVirtual method reads memory from the target's virtual address space.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="size">Specifies the size in bytes of the buffer. This is also the number of bytes being requested.</param>
        /// <param name="value">Specifies the buffer to read the memory into.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadVirtual(this DebugDataSpaces dataSpaces, long offset, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadVirtual(offset, buffer, size, out read);

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
        /// The WriteVirtual method writes data to the target's virtual address space.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="value">Specifies the buffer to write the memory from.</param>
        /// <returns>Receives the number of bytes that were written. If it is set to NULL, this information is not returned.</returns>
        public static int WriteVirtual<T>(this DebugDataSpaces dataSpaces, long offset, T value)
        {
            int read;
            TryWriteVirtual(dataSpaces, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteVirtual method writes data to the target's virtual address space.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="value">Specifies the buffer to write the memory from.</param>
        /// <param name="read">Receives the number of bytes that were written. If it is set to NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteVirtual<T>(this DebugDataSpaces dataSpaces, long offset, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TryWriteVirtual(offset, buffer, size, out read);

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
        /// The WriteVirtual method writes data to the target's virtual address space.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="value">Specifies the buffer to write the memory from.</param>
        /// <returns>Receives the number of bytes that were written. If it is set to NULL, this information is not returned.</returns>
        public static int WriteVirtual(this DebugDataSpaces dataSpaces, long offset, byte[] value)
        {
            int read;
            TryWriteVirtual(dataSpaces, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteVirtual method writes data to the target's virtual address space.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="value">Specifies the buffer to write the memory from.</param>
        /// <param name="read">Receives the number of bytes that were written. If it is set to NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteVirtual(this DebugDataSpaces dataSpaces, long offset, byte[] value, out int read)
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

                var hr = dataSpaces.TryWriteVirtual(offset, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region SearchVirtual<T>

        /// <summary>
        /// The SearchVirtual method searches the target's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to start searching for the pattern.</param>
        /// <param name="length">Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="value">Specifies the pattern to search for.</param>
        /// <param name="patternGranularity">Specifies the granularity of the pattern. For a successful match the pattern must occur a multiple of this value after the start location.</param>
        /// <returns>Receives the location in the target's virtual address space of the pattern, if it was found.</returns>
        public static long SearchVirtual<T>(this DebugDataSpaces dataSpaces, long offset, long length, T value, int patternGranularity)
        {
            long matchOffset;
            TrySearchVirtual(dataSpaces, offset, length, value, patternGranularity, out matchOffset).ThrowDbgEngNotOK();

            return matchOffset;
        }

        /// <summary>
        /// The SearchVirtual method searches the target's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to start searching for the pattern.</param>
        /// <param name="length">Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="value">Specifies the pattern to search for.</param>
        /// <param name="patternGranularity">Specifies the granularity of the pattern. For a successful match the pattern must occur a multiple of this value after the start location.</param>
        /// <param name="matchOffset">Receives the location in the target's virtual address space of the pattern, if it was found.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TrySearchVirtual<T>(this DebugDataSpaces dataSpaces, long offset, long length, T value, int patternGranularity, out long matchOffset)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TrySearchVirtual(offset, length, buffer, size, patternGranularity, out matchOffset);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region SearchVirtual (byte[])

        /// <summary>
        /// The SearchVirtual method searches the target's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to start searching for the pattern.</param>
        /// <param name="length">Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="value">Specifies the pattern to search for.</param>
        /// <param name="patternGranularity">Specifies the granularity of the pattern. For a successful match the pattern must occur a multiple of this value after the start location.</param>
        /// <returns>Receives the location in the target's virtual address space of the pattern, if it was found.</returns>
        public static long SearchVirtual(this DebugDataSpaces dataSpaces, long offset, long length, byte[] value, int patternGranularity)
        {
            long matchOffset;
            TrySearchVirtual(dataSpaces, offset, length, value, patternGranularity, out matchOffset).ThrowDbgEngNotOK();

            return matchOffset;
        }

        /// <summary>
        /// The SearchVirtual method searches the target's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to start searching for the pattern.</param>
        /// <param name="length">Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="value">Specifies the pattern to search for.</param>
        /// <param name="patternGranularity">Specifies the granularity of the pattern. For a successful match the pattern must occur a multiple of this value after the start location.</param>
        /// <param name="matchOffset">Receives the location in the target's virtual address space of the pattern, if it was found.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TrySearchVirtual(this DebugDataSpaces dataSpaces, long offset, long length, byte[] value, int patternGranularity, out long matchOffset)
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

                var hr = dataSpaces.TrySearchVirtual(offset, length, buffer, value.Length, patternGranularity, out matchOffset);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadVirtualUncached<T>

        /// <summary>
        /// The ReadVirtualUncached method reads memory from the target's virtual address space.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be read.</param>
        /// <returns>Specifies the buffer to read the memory into.</returns>
        public static T ReadVirtualUncached<T>(this DebugDataSpaces dataSpaces, long offset)
        {
            T value;
            TryReadVirtualUncached(dataSpaces, offset, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadVirtualUncached method reads memory from the target's virtual address space.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="value">Specifies the buffer to read the memory into.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadVirtualUncached<T>(this DebugDataSpaces dataSpaces, long offset, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadVirtualUncached(offset, buffer, size, out read);

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
        #region ReadVirtualUncached (byte[])

        /// <summary>
        /// The ReadVirtualUncached method reads memory from the target's virtual address space.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="size">Specifies the size in bytes of the buffer. This is also the number of bytes being requested.</param>
        /// <returns>Specifies the buffer to read the memory into.</returns>
        public static byte[] ReadVirtualUncached(this DebugDataSpaces dataSpaces, long offset, int size)
        {
            byte[] value;
            TryReadVirtualUncached(dataSpaces, offset, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadVirtualUncached method reads memory from the target's virtual address space.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be read.</param>
        /// <param name="size">Specifies the size in bytes of the buffer. This is also the number of bytes being requested.</param>
        /// <param name="value">Specifies the buffer to read the memory into.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadVirtualUncached(this DebugDataSpaces dataSpaces, long offset, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadVirtualUncached(offset, buffer, size, out read);

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
        #region WriteVirtualUncached<T>

        /// <summary>
        /// The WriteVirtualUncached method writes data to the target's virtual address space.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="value">Specifies the buffer to write the memory from.</param>
        /// <returns>Receives the number of bytes that were actually written. If it is set to NULL, this information is not returned.</returns>
        public static int WriteVirtualUncached<T>(this DebugDataSpaces dataSpaces, long offset, T value)
        {
            int read;
            TryWriteVirtualUncached(dataSpaces, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteVirtualUncached method writes data to the target's virtual address space.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="value">Specifies the buffer to write the memory from.</param>
        /// <param name="read">Receives the number of bytes that were actually written. If it is set to NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteVirtualUncached<T>(this DebugDataSpaces dataSpaces, long offset, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TryWriteVirtualUncached(offset, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region WriteVirtualUncached (byte[])

        /// <summary>
        /// The WriteVirtualUncached method writes data to the target's virtual address space.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="value">Specifies the buffer to write the memory from.</param>
        /// <returns>Receives the number of bytes that were actually written. If it is set to NULL, this information is not returned.</returns>
        public static int WriteVirtualUncached(this DebugDataSpaces dataSpaces, long offset, byte[] value)
        {
            int read;
            TryWriteVirtualUncached(dataSpaces, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteVirtualUncached method writes data to the target's virtual address space.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space to be written.</param>
        /// <param name="value">Specifies the buffer to write the memory from.</param>
        /// <param name="read">Receives the number of bytes that were actually written. If it is set to NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteVirtualUncached(this DebugDataSpaces dataSpaces, long offset, byte[] value, out int read)
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

                var hr = dataSpaces.TryWriteVirtualUncached(offset, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadPhysical<T>

        /// <summary>
        /// The ReadPhysical method reads the target's memory from the specified physical address.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to read.</param>
        /// <returns>Receives the memory that is read.</returns>
        public static T ReadPhysical<T>(this DebugDataSpaces dataSpaces, long offset)
        {
            T value;
            TryReadPhysical(dataSpaces, offset, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadPhysical method reads the target's memory from the specified physical address.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to read.</param>
        /// <param name="value">Receives the memory that is read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadPhysical<T>(this DebugDataSpaces dataSpaces, long offset, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadPhysical(offset, buffer, size, out read);

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
        #region ReadPhysical (byte[])

        /// <summary>
        /// The ReadPhysical method reads the target's memory from the specified physical address.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to read.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <returns>Receives the memory that is read.</returns>
        public static byte[] ReadPhysical(this DebugDataSpaces dataSpaces, long offset, int size)
        {
            byte[] value;
            TryReadPhysical(dataSpaces, offset, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadPhysical method reads the target's memory from the specified physical address.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to read.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="value">Receives the memory that is read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadPhysical(this DebugDataSpaces dataSpaces, long offset, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadPhysical(offset, buffer, size, out read);

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
        #region WritePhysical<T>

        /// <summary>
        /// The WritePhysical method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to write the data to.</param>
        /// <param name="value">Specifies the data to write.</param>
        /// <returns>Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WritePhysical<T>(this DebugDataSpaces dataSpaces, long offset, T value)
        {
            int read;
            TryWritePhysical(dataSpaces, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WritePhysical method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to write the data to.</param>
        /// <param name="value">Specifies the data to write.</param>
        /// <param name="read">Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWritePhysical<T>(this DebugDataSpaces dataSpaces, long offset, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TryWritePhysical(offset, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region WritePhysical (byte[])

        /// <summary>
        /// The WritePhysical method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to write the data to.</param>
        /// <param name="value">Specifies the data to write.</param>
        /// <returns>Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WritePhysical(this DebugDataSpaces dataSpaces, long offset, byte[] value)
        {
            int read;
            TryWritePhysical(dataSpaces, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WritePhysical method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to write the data to.</param>
        /// <param name="value">Specifies the data to write.</param>
        /// <param name="read">Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWritePhysical(this DebugDataSpaces dataSpaces, long offset, byte[] value, out int read)
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

                var hr = dataSpaces.TryWritePhysical(offset, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadControl<T>

        /// <summary>
        /// The ReadControl method reads implementation-specific system data.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose information is to be read.</param>
        /// <param name="offset">Specifies the offset in the control space of the memory to read.</param>
        /// <returns>Receives the data read from the control-space memory.</returns>
        public static T ReadControl<T>(this DebugDataSpaces dataSpaces, int processor, long offset)
        {
            T value;
            TryReadControl(dataSpaces, processor, offset, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadControl method reads implementation-specific system data.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose information is to be read.</param>
        /// <param name="offset">Specifies the offset in the control space of the memory to read.</param>
        /// <param name="value">Receives the data read from the control-space memory.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadControl<T>(this DebugDataSpaces dataSpaces, int processor, long offset, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadControl(processor, offset, buffer, size, out read);

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
        #region ReadControl (byte[])

        /// <summary>
        /// The ReadControl method reads implementation-specific system data.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose information is to be read.</param>
        /// <param name="offset">Specifies the offset in the control space of the memory to read.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <returns>Receives the data read from the control-space memory.</returns>
        public static byte[] ReadControl(this DebugDataSpaces dataSpaces, int processor, long offset, int size)
        {
            byte[] value;
            TryReadControl(dataSpaces, processor, offset, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadControl method reads implementation-specific system data.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose information is to be read.</param>
        /// <param name="offset">Specifies the offset in the control space of the memory to read.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="value">Receives the data read from the control-space memory.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadControl(this DebugDataSpaces dataSpaces, int processor, long offset, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadControl(processor, offset, buffer, size, out read);

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
        #region WriteControl<T>

        /// <summary>
        /// The WriteControl method writes implementation-specific system data.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose information is to be written.</param>
        /// <param name="offset">Specifies the offset of the control space of the memory to write.</param>
        /// <param name="value">Specifies the data to write to the control-space memory.</param>
        /// <returns>Receives the number of bytes returned in the buffer Buffer. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WriteControl<T>(this DebugDataSpaces dataSpaces, int processor, long offset, T value)
        {
            int read;
            TryWriteControl(dataSpaces, processor, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteControl method writes implementation-specific system data.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose information is to be written.</param>
        /// <param name="offset">Specifies the offset of the control space of the memory to write.</param>
        /// <param name="value">Specifies the data to write to the control-space memory.</param>
        /// <param name="read">Receives the number of bytes returned in the buffer Buffer. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteControl<T>(this DebugDataSpaces dataSpaces, int processor, long offset, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TryWriteControl(processor, offset, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region WriteControl (byte[])

        /// <summary>
        /// The WriteControl method writes implementation-specific system data.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose information is to be written.</param>
        /// <param name="offset">Specifies the offset of the control space of the memory to write.</param>
        /// <param name="value">Specifies the data to write to the control-space memory.</param>
        /// <returns>Receives the number of bytes returned in the buffer Buffer. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WriteControl(this DebugDataSpaces dataSpaces, int processor, long offset, byte[] value)
        {
            int read;
            TryWriteControl(dataSpaces, processor, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteControl method writes implementation-specific system data.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose information is to be written.</param>
        /// <param name="offset">Specifies the offset of the control space of the memory to write.</param>
        /// <param name="value">Specifies the data to write to the control-space memory.</param>
        /// <param name="read">Receives the number of bytes returned in the buffer Buffer. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteControl(this DebugDataSpaces dataSpaces, int processor, long offset, byte[] value, out int read)
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

                var hr = dataSpaces.TryWriteControl(processor, offset, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadIo<T>

        /// <summary>
        /// The ReadIo method reads from the system and bus I/O memory.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="interfaceType">Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">This parameter must be equal to one.</param>
        /// <param name="offset">Specifies the I/O address within the address space.</param>
        /// <returns>Receives the data read from the I/O bus.</returns>
        public static T ReadIo<T>(this DebugDataSpaces dataSpaces, INTERFACE_TYPE interfaceType, int busNumber, int addressSpace, long offset)
        {
            T value;
            TryReadIo(dataSpaces, interfaceType, busNumber, addressSpace, offset, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadIo method reads from the system and bus I/O memory.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="interfaceType">Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">This parameter must be equal to one.</param>
        /// <param name="offset">Specifies the I/O address within the address space.</param>
        /// <param name="value">Receives the data read from the I/O bus.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadIo<T>(this DebugDataSpaces dataSpaces, INTERFACE_TYPE interfaceType, int busNumber, int addressSpace, long offset, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadIo(interfaceType, busNumber, addressSpace, offset, buffer, size, out read);

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
        #region ReadIo (byte[])

        /// <summary>
        /// The ReadIo method reads from the system and bus I/O memory.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="interfaceType">Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">This parameter must be equal to one.</param>
        /// <param name="offset">Specifies the I/O address within the address space.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read. At present, this must be 1, 2, or 4.</param>
        /// <returns>Receives the data read from the I/O bus.</returns>
        public static byte[] ReadIo(this DebugDataSpaces dataSpaces, INTERFACE_TYPE interfaceType, int busNumber, int addressSpace, long offset, int size)
        {
            byte[] value;
            TryReadIo(dataSpaces, interfaceType, busNumber, addressSpace, offset, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadIo method reads from the system and bus I/O memory.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="interfaceType">Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">This parameter must be equal to one.</param>
        /// <param name="offset">Specifies the I/O address within the address space.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read. At present, this must be 1, 2, or 4.</param>
        /// <param name="value">Receives the data read from the I/O bus.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadIo(this DebugDataSpaces dataSpaces, INTERFACE_TYPE interfaceType, int busNumber, int addressSpace, long offset, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadIo(interfaceType, busNumber, addressSpace, offset, buffer, size, out read);

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
        #region WriteIo<T>

        /// <summary>
        /// The WriteIo method writes to the system and bus I/O memory.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="interfaceType">Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">Set to one.</param>
        /// <param name="offset">Specifies the location of the requested data.</param>
        /// <param name="value">Specifies the data to write to the I/O bus.</param>
        /// <returns>Receives the number of bytes written to I/O bus. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WriteIo<T>(this DebugDataSpaces dataSpaces, INTERFACE_TYPE interfaceType, int busNumber, int addressSpace, long offset, T value)
        {
            int read;
            TryWriteIo(dataSpaces, interfaceType, busNumber, addressSpace, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteIo method writes to the system and bus I/O memory.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="interfaceType">Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">Set to one.</param>
        /// <param name="offset">Specifies the location of the requested data.</param>
        /// <param name="value">Specifies the data to write to the I/O bus.</param>
        /// <param name="read">Receives the number of bytes written to I/O bus. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteIo<T>(this DebugDataSpaces dataSpaces, INTERFACE_TYPE interfaceType, int busNumber, int addressSpace, long offset, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TryWriteIo(interfaceType, busNumber, addressSpace, offset, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region WriteIo (byte[])

        /// <summary>
        /// The WriteIo method writes to the system and bus I/O memory.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="interfaceType">Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">Set to one.</param>
        /// <param name="offset">Specifies the location of the requested data.</param>
        /// <param name="value">Specifies the data to write to the I/O bus.</param>
        /// <returns>Receives the number of bytes written to I/O bus. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WriteIo(this DebugDataSpaces dataSpaces, INTERFACE_TYPE interfaceType, int busNumber, int addressSpace, long offset, byte[] value)
        {
            int read;
            TryWriteIo(dataSpaces, interfaceType, busNumber, addressSpace, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteIo method writes to the system and bus I/O memory.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="interfaceType">Specifies the interface type of the I/O bus. This parameter may take values in the INTERFACE_TYPE enumeration defined in wdm.h.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same interface type.</param>
        /// <param name="addressSpace">Set to one.</param>
        /// <param name="offset">Specifies the location of the requested data.</param>
        /// <param name="value">Specifies the data to write to the I/O bus.</param>
        /// <param name="read">Receives the number of bytes written to I/O bus. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteIo(this DebugDataSpaces dataSpaces, INTERFACE_TYPE interfaceType, int busNumber, int addressSpace, long offset, byte[] value, out int read)
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

                var hr = dataSpaces.TryWriteIo(interfaceType, busNumber, addressSpace, offset, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadBusData<T>

        /// <summary>
        /// The ReadBusData method reads data from a system bus.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="busDataType">Specifies the bus data type to read from. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">Specifies the logical slot number on the bus.</param>
        /// <param name="offset">Specifies the offset in the bus data to start reading from.</param>
        /// <returns>Receives the data from the bus.</returns>
        public static T ReadBusData<T>(this DebugDataSpaces dataSpaces, BUS_DATA_TYPE busDataType, int busNumber, int slotNumber, int offset)
        {
            T value;
            TryReadBusData(dataSpaces, busDataType, busNumber, slotNumber, offset, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadBusData method reads data from a system bus.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="busDataType">Specifies the bus data type to read from. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">Specifies the logical slot number on the bus.</param>
        /// <param name="offset">Specifies the offset in the bus data to start reading from.</param>
        /// <param name="value">Receives the data from the bus.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadBusData<T>(this DebugDataSpaces dataSpaces, BUS_DATA_TYPE busDataType, int busNumber, int slotNumber, int offset, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadBusData(busDataType, busNumber, slotNumber, offset, buffer, size, out read);

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
        #region ReadBusData (byte[])

        /// <summary>
        /// The ReadBusData method reads data from a system bus.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="busDataType">Specifies the bus data type to read from. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">Specifies the logical slot number on the bus.</param>
        /// <param name="offset">Specifies the offset in the bus data to start reading from.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <returns>Receives the data from the bus.</returns>
        public static byte[] ReadBusData(this DebugDataSpaces dataSpaces, BUS_DATA_TYPE busDataType, int busNumber, int slotNumber, int offset, int size)
        {
            byte[] value;
            TryReadBusData(dataSpaces, busDataType, busNumber, slotNumber, offset, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadBusData method reads data from a system bus.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="busDataType">Specifies the bus data type to read from. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">Specifies the logical slot number on the bus.</param>
        /// <param name="offset">Specifies the offset in the bus data to start reading from.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="value">Receives the data from the bus.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadBusData(this DebugDataSpaces dataSpaces, BUS_DATA_TYPE busDataType, int busNumber, int slotNumber, int offset, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadBusData(busDataType, busNumber, slotNumber, offset, buffer, size, out read);

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
        #region WriteBusData<T>

        /// <summary>
        /// The WriteBusData method writes data to a system bus.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="busDataType">Specifies the bus data type of the bus to write to. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">Specifies the logical slot number on the bus.</param>
        /// <param name="offset">Specifies the offset in the bus data to start writing to.</param>
        /// <param name="value">Specifies the data to write to the bus.</param>
        /// <returns>Receives the number of bytes written to the bus. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WriteBusData<T>(this DebugDataSpaces dataSpaces, BUS_DATA_TYPE busDataType, int busNumber, int slotNumber, int offset, T value)
        {
            int read;
            TryWriteBusData(dataSpaces, busDataType, busNumber, slotNumber, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteBusData method writes data to a system bus.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="busDataType">Specifies the bus data type of the bus to write to. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">Specifies the logical slot number on the bus.</param>
        /// <param name="offset">Specifies the offset in the bus data to start writing to.</param>
        /// <param name="value">Specifies the data to write to the bus.</param>
        /// <param name="read">Receives the number of bytes written to the bus. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteBusData<T>(this DebugDataSpaces dataSpaces, BUS_DATA_TYPE busDataType, int busNumber, int slotNumber, int offset, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TryWriteBusData(busDataType, busNumber, slotNumber, offset, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region WriteBusData (byte[])

        /// <summary>
        /// The WriteBusData method writes data to a system bus.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="busDataType">Specifies the bus data type of the bus to write to. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">Specifies the logical slot number on the bus.</param>
        /// <param name="offset">Specifies the offset in the bus data to start writing to.</param>
        /// <param name="value">Specifies the data to write to the bus.</param>
        /// <returns>Receives the number of bytes written to the bus. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WriteBusData(this DebugDataSpaces dataSpaces, BUS_DATA_TYPE busDataType, int busNumber, int slotNumber, int offset, byte[] value)
        {
            int read;
            TryWriteBusData(dataSpaces, busDataType, busNumber, slotNumber, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteBusData method writes data to a system bus.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="busDataType">Specifies the bus data type of the bus to write to. For details of allowed values see the documentation for the BUS_DATA_TYPE enumeration in the Microsoft Windows SDK.</param>
        /// <param name="busNumber">Specifies the system-assigned number of the bus. This is usually zero, unless the system has more than one bus of the same bus data type.</param>
        /// <param name="slotNumber">Specifies the logical slot number on the bus.</param>
        /// <param name="offset">Specifies the offset in the bus data to start writing to.</param>
        /// <param name="value">Specifies the data to write to the bus.</param>
        /// <param name="read">Receives the number of bytes written to the bus. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteBusData(this DebugDataSpaces dataSpaces, BUS_DATA_TYPE busDataType, int busNumber, int slotNumber, int offset, byte[] value, out int read)
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

                var hr = dataSpaces.TryWriteBusData(busDataType, busNumber, slotNumber, offset, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadDebuggerData<T>

        /// <summary>
        /// The ReadDebuggerData method returns information about the target that the debugger engine has queried or determined during the current session.<para/>
        /// The available information includes the locations of certain key target kernel locations, specific status values, and a number of other things.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the data to retrieve. The following values are valid: Returns FALSE otherwise. Some of the information contained in this structure is displayed by the debugger extension !kuser.<para/>
        /// This value should be interpreted the same way as the wProductType field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// This value should be interpreted the same way as the wSuiteMask field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// The following values are valid for Windows XP and later versions of Windows: The following values are valid for Windows Server 2003 and later versions of Windows: For all other processors: Returns the offset of the CpuType field in the KPRCB structure.<para/>
        /// For all other processors: Returns the offset of the VendorString field in the KPRCB structure.</param>
        /// <returns>Receives the value of the specified debugger data. The "Return Type" column in the above table specifies the data type that is returned.<para/>
        /// The data can be accessed by casting Buffer to a pointer to that type.</returns>
        public static T ReadDebuggerData<T>(this DebugDataSpaces dataSpaces, DEBUG_DATA index)
        {
            T value;
            TryReadDebuggerData(dataSpaces, index, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadDebuggerData method returns information about the target that the debugger engine has queried or determined during the current session.<para/>
        /// The available information includes the locations of certain key target kernel locations, specific status values, and a number of other things.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the data to retrieve. The following values are valid: Returns FALSE otherwise. Some of the information contained in this structure is displayed by the debugger extension !kuser.<para/>
        /// This value should be interpreted the same way as the wProductType field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// This value should be interpreted the same way as the wSuiteMask field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// The following values are valid for Windows XP and later versions of Windows: The following values are valid for Windows Server 2003 and later versions of Windows: For all other processors: Returns the offset of the CpuType field in the KPRCB structure.<para/>
        /// For all other processors: Returns the offset of the VendorString field in the KPRCB structure.</param>
        /// <param name="value">Receives the value of the specified debugger data. The "Return Type" column in the above table specifies the data type that is returned.<para/>
        /// The data can be accessed by casting Buffer to a pointer to that type.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadDebuggerData<T>(this DebugDataSpaces dataSpaces, DEBUG_DATA index, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadDebuggerData(index, buffer, size, out read);

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
        #region ReadDebuggerData (byte[])

        /// <summary>
        /// The ReadDebuggerData method returns information about the target that the debugger engine has queried or determined during the current session.<para/>
        /// The available information includes the locations of certain key target kernel locations, specific status values, and a number of other things.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the data to retrieve. The following values are valid: Returns FALSE otherwise. Some of the information contained in this structure is displayed by the debugger extension !kuser.<para/>
        /// This value should be interpreted the same way as the wProductType field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// This value should be interpreted the same way as the wSuiteMask field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// The following values are valid for Windows XP and later versions of Windows: The following values are valid for Windows Server 2003 and later versions of Windows: For all other processors: Returns the offset of the CpuType field in the KPRCB structure.<para/>
        /// For all other processors: Returns the offset of the VendorString field in the KPRCB structure.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer.</param>
        /// <returns>Receives the value of the specified debugger data. The "Return Type" column in the above table specifies the data type that is returned.<para/>
        /// The data can be accessed by casting Buffer to a pointer to that type.</returns>
        public static byte[] ReadDebuggerData(this DebugDataSpaces dataSpaces, DEBUG_DATA index, int size)
        {
            byte[] value;
            TryReadDebuggerData(dataSpaces, index, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadDebuggerData method returns information about the target that the debugger engine has queried or determined during the current session.<para/>
        /// The available information includes the locations of certain key target kernel locations, specific status values, and a number of other things.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the data to retrieve. The following values are valid: Returns FALSE otherwise. Some of the information contained in this structure is displayed by the debugger extension !kuser.<para/>
        /// This value should be interpreted the same way as the wProductType field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// This value should be interpreted the same way as the wSuiteMask field of the structure OSVERSIONINFOEX, which is documented in the Windows SDK.<para/>
        /// The following values are valid for Windows XP and later versions of Windows: The following values are valid for Windows Server 2003 and later versions of Windows: For all other processors: Returns the offset of the CpuType field in the KPRCB structure.<para/>
        /// For all other processors: Returns the offset of the VendorString field in the KPRCB structure.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer.</param>
        /// <param name="value">Receives the value of the specified debugger data. The "Return Type" column in the above table specifies the data type that is returned.<para/>
        /// The data can be accessed by casting Buffer to a pointer to that type.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadDebuggerData(this DebugDataSpaces dataSpaces, DEBUG_DATA index, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadDebuggerData(index, buffer, size, out read);

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
        #region ReadProcessorSystemData<T>

        /// <summary>
        /// The ReadProcessorSystemData method returns data about the specified processor.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose data is to be read.</param>
        /// <param name="index">Specifies the data type to read. The following table contains the valid values. After successful completion, the data returned in the buffer Buffer has the type specified by the middle column.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PDEBUG_PROCESSOR_IDENTIFICATION_ALL . In this case, the argument Buffer can be considered to have type PULONG.</param>
        /// <returns>Receives the processor data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.</returns>
        public static T ReadProcessorSystemData<T>(this DebugDataSpaces dataSpaces, int processor, DEBUG_DATA index)
        {
            T value;
            TryReadProcessorSystemData(dataSpaces, processor, index, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadProcessorSystemData method returns data about the specified processor.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose data is to be read.</param>
        /// <param name="index">Specifies the data type to read. The following table contains the valid values. After successful completion, the data returned in the buffer Buffer has the type specified by the middle column.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PDEBUG_PROCESSOR_IDENTIFICATION_ALL . In this case, the argument Buffer can be considered to have type PULONG.</param>
        /// <param name="value">Receives the processor data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadProcessorSystemData<T>(this DebugDataSpaces dataSpaces, int processor, DEBUG_DATA index, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadProcessorSystemData(processor, index, buffer, size, out read);

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
        #region ReadProcessorSystemData (byte[])

        /// <summary>
        /// The ReadProcessorSystemData method returns data about the specified processor.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose data is to be read.</param>
        /// <param name="index">Specifies the data type to read. The following table contains the valid values. After successful completion, the data returned in the buffer Buffer has the type specified by the middle column.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PDEBUG_PROCESSOR_IDENTIFICATION_ALL . In this case, the argument Buffer can be considered to have type PULONG.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <returns>Receives the processor data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.</returns>
        public static byte[] ReadProcessorSystemData(this DebugDataSpaces dataSpaces, int processor, DEBUG_DATA index, int size)
        {
            byte[] value;
            TryReadProcessorSystemData(dataSpaces, processor, index, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadProcessorSystemData method returns data about the specified processor.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="processor">Specifies the processor whose data is to be read.</param>
        /// <param name="index">Specifies the data type to read. The following table contains the valid values. After successful completion, the data returned in the buffer Buffer has the type specified by the middle column.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG64. In this case, the argument Buffer can be considered to have type PULONG64.<para/>
        /// In this case, the argument Buffer can be considered to have type PDEBUG_PROCESSOR_IDENTIFICATION_ALL . In this case, the argument Buffer can be considered to have type PULONG.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="value">Receives the processor data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadProcessorSystemData(this DebugDataSpaces dataSpaces, int processor, DEBUG_DATA index, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadProcessorSystemData(processor, index, buffer, size, out read);

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
        #region ReadHandleData<T>

        /// <summary>
        /// The ReadHandleData method retrieves information about a system object specified by a system handle.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="handle">Specifies the system handle of the object whose data is requested. See Handles for information about system handles.</param>
        /// <param name="dataType">Specifies the data type to return for the system handle. The following table contains the valid values, along with the corresponding return type: In this case, the argument Buffer can be considered to have type <see cref="DEBUG_HANDLE_DATA_BASIC"/>.<para/>
        /// In this case, the argument Buffer can be considered to have type PSTR. In this case, the argument Buffer can be considered to have type PSTR.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG. In this case, the argument Buffer can be considered to have type PWSTR In this case, the argument Buffer can be considered to have type PWSTR.</param>
        /// <returns>Receives the object data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.<para/>
        /// If Buffer is NULL, this information is not returned.</returns>
        public static T ReadHandleData<T>(this DebugDataSpaces dataSpaces, long handle, DEBUG_HANDLE_DATA_TYPE dataType)
        {
            T value;
            TryReadHandleData(dataSpaces, handle, dataType, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadHandleData method retrieves information about a system object specified by a system handle.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="handle">Specifies the system handle of the object whose data is requested. See Handles for information about system handles.</param>
        /// <param name="dataType">Specifies the data type to return for the system handle. The following table contains the valid values, along with the corresponding return type: In this case, the argument Buffer can be considered to have type <see cref="DEBUG_HANDLE_DATA_BASIC"/>.<para/>
        /// In this case, the argument Buffer can be considered to have type PSTR. In this case, the argument Buffer can be considered to have type PSTR.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG. In this case, the argument Buffer can be considered to have type PWSTR In this case, the argument Buffer can be considered to have type PWSTR.</param>
        /// <param name="value">Receives the object data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadHandleData<T>(this DebugDataSpaces dataSpaces, long handle, DEBUG_HANDLE_DATA_TYPE dataType, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadHandleData(handle, dataType, buffer, size, out read);

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
        #region ReadHandleData (byte[])

        /// <summary>
        /// The ReadHandleData method retrieves information about a system object specified by a system handle.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="handle">Specifies the system handle of the object whose data is requested. See Handles for information about system handles.</param>
        /// <param name="dataType">Specifies the data type to return for the system handle. The following table contains the valid values, along with the corresponding return type: In this case, the argument Buffer can be considered to have type <see cref="DEBUG_HANDLE_DATA_BASIC"/>.<para/>
        /// In this case, the argument Buffer can be considered to have type PSTR. In this case, the argument Buffer can be considered to have type PSTR.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG. In this case, the argument Buffer can be considered to have type PWSTR In this case, the argument Buffer can be considered to have type PWSTR.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <returns>Receives the object data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.<para/>
        /// If Buffer is NULL, this information is not returned.</returns>
        public static byte[] ReadHandleData(this DebugDataSpaces dataSpaces, long handle, DEBUG_HANDLE_DATA_TYPE dataType, int size)
        {
            byte[] value;
            TryReadHandleData(dataSpaces, handle, dataType, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadHandleData method retrieves information about a system object specified by a system handle.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="handle">Specifies the system handle of the object whose data is requested. See Handles for information about system handles.</param>
        /// <param name="dataType">Specifies the data type to return for the system handle. The following table contains the valid values, along with the corresponding return type: In this case, the argument Buffer can be considered to have type <see cref="DEBUG_HANDLE_DATA_BASIC"/>.<para/>
        /// In this case, the argument Buffer can be considered to have type PSTR. In this case, the argument Buffer can be considered to have type PSTR.<para/>
        /// In this case, the argument Buffer can be considered to have type PULONG. In this case, the argument Buffer can be considered to have type PWSTR In this case, the argument Buffer can be considered to have type PWSTR.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="value">Receives the object data. Upon successful completion of the method, the contents of this buffer may be accessed by casting Buffer to the type specified in the above table.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadHandleData(this DebugDataSpaces dataSpaces, long handle, DEBUG_HANDLE_DATA_TYPE dataType, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadHandleData(handle, dataType, buffer, size, out read);

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
        #region FillVirtual<T>

        /// <summary>
        /// The FillVirtual method writes a pattern of bytes to the target's virtual memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="start">Specifies the location in the target's virtual address space at which to start writing the pattern.</param>
        /// <param name="size">Specifies how many bytes to write to the target's memory.</param>
        /// <param name="value">Specifies the memory location of the pattern.</param>
        /// <returns>Receives the number of bytes written. If it is set to NULL, this information isn't returned.</returns>
        public static int FillVirtual<T>(this DebugDataSpaces dataSpaces, long start, int size, T value)
        {
            int read;
            TryFillVirtual(dataSpaces, start, size, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The FillVirtual method writes a pattern of bytes to the target's virtual memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="start">Specifies the location in the target's virtual address space at which to start writing the pattern.</param>
        /// <param name="size">Specifies how many bytes to write to the target's memory.</param>
        /// <param name="value">Specifies the memory location of the pattern.</param>
        /// <param name="read">Receives the number of bytes written. If it is set to NULL, this information isn't returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryFillVirtual<T>(this DebugDataSpaces dataSpaces, long start, int size, T value, out int read)
        {
            var patternSize = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(patternSize);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TryFillVirtual(start, size, buffer, patternSize, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region FillVirtual (byte[])

        /// <summary>
        /// The FillVirtual method writes a pattern of bytes to the target's virtual memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="start">Specifies the location in the target's virtual address space at which to start writing the pattern.</param>
        /// <param name="size">Specifies how many bytes to write to the target's memory.</param>
        /// <param name="value">Specifies the memory location of the pattern.</param>
        /// <returns>Receives the number of bytes written. If it is set to NULL, this information isn't returned.</returns>
        public static int FillVirtual(this DebugDataSpaces dataSpaces, long start, int size, byte[] value)
        {
            int read;
            TryFillVirtual(dataSpaces, start, size, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The FillVirtual method writes a pattern of bytes to the target's virtual memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="start">Specifies the location in the target's virtual address space at which to start writing the pattern.</param>
        /// <param name="size">Specifies how many bytes to write to the target's memory.</param>
        /// <param name="value">Specifies the memory location of the pattern.</param>
        /// <param name="read">Receives the number of bytes written. If it is set to NULL, this information isn't returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryFillVirtual(this DebugDataSpaces dataSpaces, long start, int size, byte[] value, out int read)
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

                var hr = dataSpaces.TryFillVirtual(start, size, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region FillPhysical<T>

        /// <summary>
        /// The FillPhysical method writes a pattern of bytes to the target's physical memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="start">Specifies the location in the target's physical memory at which to start writing the pattern.</param>
        /// <param name="size">Specifies how many bytes to write to the target's memory.</param>
        /// <param name="value">Specifies the pattern to write.</param>
        /// <returns>Receives the number of bytes written. If it is set to NULL, this information isn't returned.</returns>
        public static int FillPhysical<T>(this DebugDataSpaces dataSpaces, long start, int size, T value)
        {
            int read;
            TryFillPhysical(dataSpaces, start, size, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The FillPhysical method writes a pattern of bytes to the target's physical memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="start">Specifies the location in the target's physical memory at which to start writing the pattern.</param>
        /// <param name="size">Specifies how many bytes to write to the target's memory.</param>
        /// <param name="value">Specifies the pattern to write.</param>
        /// <param name="read">Receives the number of bytes written. If it is set to NULL, this information isn't returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryFillPhysical<T>(this DebugDataSpaces dataSpaces, long start, int size, T value, out int read)
        {
            var patternSize = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(patternSize);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TryFillPhysical(start, size, buffer, patternSize, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region FillPhysical (byte[])

        /// <summary>
        /// The FillPhysical method writes a pattern of bytes to the target's physical memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="start">Specifies the location in the target's physical memory at which to start writing the pattern.</param>
        /// <param name="size">Specifies how many bytes to write to the target's memory.</param>
        /// <param name="value">Specifies the pattern to write.</param>
        /// <returns>Receives the number of bytes written. If it is set to NULL, this information isn't returned.</returns>
        public static int FillPhysical(this DebugDataSpaces dataSpaces, long start, int size, byte[] value)
        {
            int read;
            TryFillPhysical(dataSpaces, start, size, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The FillPhysical method writes a pattern of bytes to the target's physical memory. The pattern is written repeatedly until the specified memory range is filled.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="start">Specifies the location in the target's physical memory at which to start writing the pattern.</param>
        /// <param name="size">Specifies how many bytes to write to the target's memory.</param>
        /// <param name="value">Specifies the pattern to write.</param>
        /// <param name="read">Receives the number of bytes written. If it is set to NULL, this information isn't returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryFillPhysical(this DebugDataSpaces dataSpaces, long start, int size, byte[] value, out int read)
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

                var hr = dataSpaces.TryFillPhysical(start, size, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadTagged<T>

        /// <summary>
        /// The ReadTagged method reads the tagged data that might be associated with a debugger session.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="tag">Specifies the GUID identifying the data requested.</param>
        /// <param name="offset">Specifies the offset within the data to read.</param>
        /// <returns>Receives the data. If Buffer is NULL, the data is not returned.</returns>
        public static T ReadTagged<T>(this DebugDataSpaces dataSpaces, Guid tag, int offset)
        {
            T value;
            TryReadTagged(dataSpaces, tag, offset, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadTagged method reads the tagged data that might be associated with a debugger session.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="tag">Specifies the GUID identifying the data requested.</param>
        /// <param name="offset">Specifies the offset within the data to read.</param>
        /// <param name="value">Receives the data. If Buffer is NULL, the data is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadTagged<T>(this DebugDataSpaces dataSpaces, Guid tag, int offset, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadTagged(tag, offset, buffer, size, out read);

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
        #region ReadTagged (byte[])

        /// <summary>
        /// The ReadTagged method reads the tagged data that might be associated with a debugger session.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="tag">Specifies the GUID identifying the data requested.</param>
        /// <param name="offset">Specifies the offset within the data to read.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <returns>Receives the data. If Buffer is NULL, the data is not returned.</returns>
        public static byte[] ReadTagged(this DebugDataSpaces dataSpaces, Guid tag, int offset, int size)
        {
            byte[] value;
            TryReadTagged(dataSpaces, tag, offset, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadTagged method reads the tagged data that might be associated with a debugger session.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="tag">Specifies the GUID identifying the data requested.</param>
        /// <param name="offset">Specifies the offset within the data to read.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be returned.</param>
        /// <param name="value">Receives the data. If Buffer is NULL, the data is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadTagged(this DebugDataSpaces dataSpaces, Guid tag, int offset, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadTagged(tag, offset, buffer, size, out read);

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
        #region GetOffsetInformation<T>

        /// <summary>
        /// The GetOffsetInformation method provides general information about an address in a process's data space.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="space">Specifies the data space to which the Offset parameter applies. The allowed values depend on the Which parameter.</param>
        /// <param name="which">Specifies which information about the data is being queried. This determines the possible values for Space and the type of the data returned in Buffer.<para/>
        /// Possible values are: Returns the source of the target's virtual memory at Offset. This is where the debugger engine reads the memory from.<para/>
        /// Space must be set to DEBUG_DATA_SPACE_VIRTUAL. A ULONG is returned to Buffer. This ULONG can take the values listed in the following table.<para/>
        /// This could mean that the address is invalid, or that the memory is unavailable -- for example, a crash-dump file might not contain all of the memory for the process or for the kernel.</param>
        /// <param name="offset">Specifies the offset in the target's data space for which the information is returned.</param>
        /// <param name="value">Specifies the buffer to receive the information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>Receives the size, in bytes, of the information that is returned. If InfoSize is NULL, this information is not returned.</returns>
        public static int GetOffsetInformation<T>(this DebugDataSpaces dataSpaces, DEBUG_DATA_SPACE space, DEBUG_OFFSINFO which, long offset, T value)
        {
            int read;
            TryGetOffsetInformation(dataSpaces, space, which, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The GetOffsetInformation method provides general information about an address in a process's data space.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="space">Specifies the data space to which the Offset parameter applies. The allowed values depend on the Which parameter.</param>
        /// <param name="which">Specifies which information about the data is being queried. This determines the possible values for Space and the type of the data returned in Buffer.<para/>
        /// Possible values are: Returns the source of the target's virtual memory at Offset. This is where the debugger engine reads the memory from.<para/>
        /// Space must be set to DEBUG_DATA_SPACE_VIRTUAL. A ULONG is returned to Buffer. This ULONG can take the values listed in the following table.<para/>
        /// This could mean that the address is invalid, or that the memory is unavailable -- for example, a crash-dump file might not contain all of the memory for the process or for the kernel.</param>
        /// <param name="offset">Specifies the offset in the target's data space for which the information is returned.</param>
        /// <param name="value">Specifies the buffer to receive the information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="read">Receives the size, in bytes, of the information that is returned. If InfoSize is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetOffsetInformation<T>(this DebugDataSpaces dataSpaces, DEBUG_DATA_SPACE space, DEBUG_OFFSINFO which, long offset, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TryGetOffsetInformation(space, which, offset, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetOffsetInformation (byte[])

        /// <summary>
        /// The GetOffsetInformation method provides general information about an address in a process's data space.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="space">Specifies the data space to which the Offset parameter applies. The allowed values depend on the Which parameter.</param>
        /// <param name="which">Specifies which information about the data is being queried. This determines the possible values for Space and the type of the data returned in Buffer.<para/>
        /// Possible values are: Returns the source of the target's virtual memory at Offset. This is where the debugger engine reads the memory from.<para/>
        /// Space must be set to DEBUG_DATA_SPACE_VIRTUAL. A ULONG is returned to Buffer. This ULONG can take the values listed in the following table.<para/>
        /// This could mean that the address is invalid, or that the memory is unavailable -- for example, a crash-dump file might not contain all of the memory for the process or for the kernel.</param>
        /// <param name="offset">Specifies the offset in the target's data space for which the information is returned.</param>
        /// <param name="value">Specifies the buffer to receive the information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>Receives the size, in bytes, of the information that is returned. If InfoSize is NULL, this information is not returned.</returns>
        public static int GetOffsetInformation(this DebugDataSpaces dataSpaces, DEBUG_DATA_SPACE space, DEBUG_OFFSINFO which, long offset, byte[] value)
        {
            int read;
            TryGetOffsetInformation(dataSpaces, space, which, offset, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The GetOffsetInformation method provides general information about an address in a process's data space.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="space">Specifies the data space to which the Offset parameter applies. The allowed values depend on the Which parameter.</param>
        /// <param name="which">Specifies which information about the data is being queried. This determines the possible values for Space and the type of the data returned in Buffer.<para/>
        /// Possible values are: Returns the source of the target's virtual memory at Offset. This is where the debugger engine reads the memory from.<para/>
        /// Space must be set to DEBUG_DATA_SPACE_VIRTUAL. A ULONG is returned to Buffer. This ULONG can take the values listed in the following table.<para/>
        /// This could mean that the address is invalid, or that the memory is unavailable -- for example, a crash-dump file might not contain all of the memory for the process or for the kernel.</param>
        /// <param name="offset">Specifies the offset in the target's data space for which the information is returned.</param>
        /// <param name="value">Specifies the buffer to receive the information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="read">Receives the size, in bytes, of the information that is returned. If InfoSize is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetOffsetInformation(this DebugDataSpaces dataSpaces, DEBUG_DATA_SPACE space, DEBUG_OFFSINFO which, long offset, byte[] value, out int read)
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

                var hr = dataSpaces.TryGetOffsetInformation(space, which, offset, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region SearchVirtual2<T>

        /// <summary>
        /// The SearchVirtual2 method searches the process's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the process's virtual address space to start searching for the pattern.</param>
        /// <param name="length">Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="flags">Specifies a bit field of flags for the search. Currently, the only bit-flag that can be set is DEBUG_VSEARCH_WRITABLE_ONLY, which restricts the search to writable memory.</param>
        /// <param name="value">Specifies the pattern to search for.</param>
        /// <param name="patternGranularity">Specifies the granularity of the pattern. For a successful match, the difference between the location of the found pattern and Offset must be a multiple of PatternGranularity.</param>
        /// <returns>Receives the location in the process's virtual address space of the pattern, if it was found.</returns>
        public static long SearchVirtual2<T>(this DebugDataSpaces dataSpaces, long offset, long length, DEBUG_VSEARCH flags, T value, int patternGranularity)
        {
            long matchOffset;
            TrySearchVirtual2(dataSpaces, offset, length, flags, value, patternGranularity, out matchOffset).ThrowDbgEngNotOK();

            return matchOffset;
        }

        /// <summary>
        /// The SearchVirtual2 method searches the process's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the process's virtual address space to start searching for the pattern.</param>
        /// <param name="length">Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="flags">Specifies a bit field of flags for the search. Currently, the only bit-flag that can be set is DEBUG_VSEARCH_WRITABLE_ONLY, which restricts the search to writable memory.</param>
        /// <param name="value">Specifies the pattern to search for.</param>
        /// <param name="patternGranularity">Specifies the granularity of the pattern. For a successful match, the difference between the location of the found pattern and Offset must be a multiple of PatternGranularity.</param>
        /// <param name="matchOffset">Receives the location in the process's virtual address space of the pattern, if it was found.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TrySearchVirtual2<T>(this DebugDataSpaces dataSpaces, long offset, long length, DEBUG_VSEARCH flags, T value, int patternGranularity, out long matchOffset)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TrySearchVirtual2(offset, length, flags, buffer, size, patternGranularity, out matchOffset);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region SearchVirtual2 (byte[])

        /// <summary>
        /// The SearchVirtual2 method searches the process's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the process's virtual address space to start searching for the pattern.</param>
        /// <param name="length">Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="flags">Specifies a bit field of flags for the search. Currently, the only bit-flag that can be set is DEBUG_VSEARCH_WRITABLE_ONLY, which restricts the search to writable memory.</param>
        /// <param name="value">Specifies the pattern to search for.</param>
        /// <param name="patternGranularity">Specifies the granularity of the pattern. For a successful match, the difference between the location of the found pattern and Offset must be a multiple of PatternGranularity.</param>
        /// <returns>Receives the location in the process's virtual address space of the pattern, if it was found.</returns>
        public static long SearchVirtual2(this DebugDataSpaces dataSpaces, long offset, long length, DEBUG_VSEARCH flags, byte[] value, int patternGranularity)
        {
            long matchOffset;
            TrySearchVirtual2(dataSpaces, offset, length, flags, value, patternGranularity, out matchOffset).ThrowDbgEngNotOK();

            return matchOffset;
        }

        /// <summary>
        /// The SearchVirtual2 method searches the process's virtual memory for a specified pattern of bytes.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the process's virtual address space to start searching for the pattern.</param>
        /// <param name="length">Specifies how far to search for the pattern. A successful match requires the entire pattern to be found before Length bytes have been examined.</param>
        /// <param name="flags">Specifies a bit field of flags for the search. Currently, the only bit-flag that can be set is DEBUG_VSEARCH_WRITABLE_ONLY, which restricts the search to writable memory.</param>
        /// <param name="value">Specifies the pattern to search for.</param>
        /// <param name="patternGranularity">Specifies the granularity of the pattern. For a successful match, the difference between the location of the found pattern and Offset must be a multiple of PatternGranularity.</param>
        /// <param name="matchOffset">Receives the location in the process's virtual address space of the pattern, if it was found.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TrySearchVirtual2(this DebugDataSpaces dataSpaces, long offset, long length, DEBUG_VSEARCH flags, byte[] value, int patternGranularity, out long matchOffset)
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

                var hr = dataSpaces.TrySearchVirtual2(offset, length, flags, buffer, value.Length, patternGranularity, out matchOffset);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadPhysical2<T>

        /// <summary>
        /// The ReadPhysical2 method reads the target's memory from the specified physical address.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to read.</param>
        /// <param name="flags">Specifies the properties of the physical memory to be read. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <returns>Receives the memory that is read.</returns>
        public static T ReadPhysical2<T>(this DebugDataSpaces dataSpaces, long offset, DEBUG_PHYSICAL flags)
        {
            T value;
            TryReadPhysical2(dataSpaces, offset, flags, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadPhysical2 method reads the target's memory from the specified physical address.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to read.</param>
        /// <param name="flags">Specifies the properties of the physical memory to be read. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="value">Receives the memory that is read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadPhysical2<T>(this DebugDataSpaces dataSpaces, long offset, DEBUG_PHYSICAL flags, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadPhysical2(offset, flags, buffer, size, out read);

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
        #region ReadPhysical2 (byte[])

        /// <summary>
        /// The ReadPhysical2 method reads the target's memory from the specified physical address.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to read.</param>
        /// <param name="flags">Specifies the properties of the physical memory to be read. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="size">Specifies the size, in bytes, of the Buffer buffer. This is the maximum number of bytes that will be read.</param>
        /// <returns>Receives the memory that is read.</returns>
        public static byte[] ReadPhysical2(this DebugDataSpaces dataSpaces, long offset, DEBUG_PHYSICAL flags, int size)
        {
            byte[] value;
            TryReadPhysical2(dataSpaces, offset, flags, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadPhysical2 method reads the target's memory from the specified physical address.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to read.</param>
        /// <param name="flags">Specifies the properties of the physical memory to be read. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="size">Specifies the size, in bytes, of the Buffer buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="value">Receives the memory that is read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadPhysical2(this DebugDataSpaces dataSpaces, long offset, DEBUG_PHYSICAL flags, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = dataSpaces.TryReadPhysical2(offset, flags, buffer, size, out read);

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
        #region WritePhysical2<T>

        /// <summary>
        /// The WritePhysical2 method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to write the data to.</param>
        /// <param name="flags">Specifies the properties of the physical memory to be written to. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="value">Specifies the data to write.</param>
        /// <returns>Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WritePhysical2<T>(this DebugDataSpaces dataSpaces, long offset, DEBUG_PHYSICAL flags, T value)
        {
            int read;
            TryWritePhysical2(dataSpaces, offset, flags, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WritePhysical2 method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to write the data to.</param>
        /// <param name="flags">Specifies the properties of the physical memory to be written to. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="value">Specifies the data to write.</param>
        /// <param name="read">Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWritePhysical2<T>(this DebugDataSpaces dataSpaces, long offset, DEBUG_PHYSICAL flags, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = dataSpaces.TryWritePhysical2(offset, flags, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region WritePhysical2 (byte[])

        /// <summary>
        /// The WritePhysical2 method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to write the data to.</param>
        /// <param name="flags">Specifies the properties of the physical memory to be written to. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="value">Specifies the data to write.</param>
        /// <returns>Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WritePhysical2(this DebugDataSpaces dataSpaces, long offset, DEBUG_PHYSICAL flags, byte[] value)
        {
            int read;
            TryWritePhysical2(dataSpaces, offset, flags, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WritePhysical2 method writes data to the specified physical address in the target's memory.
        /// </summary>
        /// <param name="dataSpaces">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address of the memory to write the data to.</param>
        /// <param name="flags">Specifies the properties of the physical memory to be written to. This must match the way the physical memory was advertised to the operating system on the target.<para/>
        /// Possible values are listed in the following table.</param>
        /// <param name="value">Specifies the data to write.</param>
        /// <param name="read">Receives the number of bytes written to the target's memory. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWritePhysical2(this DebugDataSpaces dataSpaces, long offset, DEBUG_PHYSICAL flags, byte[] value, out int read)
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

                var hr = dataSpaces.TryWritePhysical2(offset, flags, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
    }
}
