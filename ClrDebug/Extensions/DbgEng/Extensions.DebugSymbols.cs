using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    public partial class DbgEngExtensions
    {
        #region ReadTypedDataVirtual<T>

        /// <summary>
        /// The ReadTypedDataVirtual method reads the value of a variable in the target's virtual memory.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space of the variable to read.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type.</param>
        /// <returns>Receives the data that is read.</returns>
        public static T ReadTypedDataVirtual<T>(this DebugSymbols symbols, long offset, long module, int typeId)
        {
            T value;
            TryReadTypedDataVirtual(symbols, offset, module, typeId, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadTypedDataVirtual method reads the value of a variable in the target's virtual memory.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space of the variable to read.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type.</param>
        /// <param name="value">Receives the data that is read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadTypedDataVirtual<T>(this DebugSymbols symbols, long offset, long module, int typeId, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = symbols.TryReadTypedDataVirtual(offset, module, typeId, buffer, size, out read);

                if (hr == HRESULT.S_OK || hr == HRESULT.S_FALSE)
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
        #region ReadTypedDataVirtual (byte[])

        /// <summary>
        /// The ReadTypedDataVirtual method reads the value of a variable in the target's virtual memory.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space of the variable to read.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be read.</param>
        /// <returns>Receives the data that is read.</returns>
        public static byte[] ReadTypedDataVirtual(this DebugSymbols symbols, long offset, long module, int typeId, int size)
        {
            byte[] value;
            TryReadTypedDataVirtual(symbols, offset, module, typeId, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadTypedDataVirtual method reads the value of a variable in the target's virtual memory.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space of the variable to read.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be read.</param>
        /// <param name="value">Receives the data that is read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadTypedDataVirtual(this DebugSymbols symbols, long offset, long module, int typeId, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = symbols.TryReadTypedDataVirtual(offset, module, typeId, buffer, size, out read);

                if (hr == HRESULT.S_OK || hr == HRESULT.S_FALSE)
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
        #region WriteTypedDataVirtual<T>

        /// <summary>
        /// The WriteTypedDataVirtual method writes data to the target's virtual address space. The number of bytes written is the size of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space where the data will be written.</param>
        /// <param name="module">Specifies the base address of the module containing the type.</param>
        /// <param name="typeId">Specifies the type ID of the type.</param>
        /// <param name="value">Specifies the buffer containing the data to be written.</param>
        /// <returns>Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WriteTypedDataVirtual<T>(this DebugSymbols symbols, long offset, long module, int typeId, T value)
        {
            int read;
            TryWriteTypedDataVirtual(symbols, offset, module, typeId, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteTypedDataVirtual method writes data to the target's virtual address space. The number of bytes written is the size of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space where the data will be written.</param>
        /// <param name="module">Specifies the base address of the module containing the type.</param>
        /// <param name="typeId">Specifies the type ID of the type.</param>
        /// <param name="value">Specifies the buffer containing the data to be written.</param>
        /// <param name="read">Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteTypedDataVirtual<T>(this DebugSymbols symbols, long offset, long module, int typeId, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = symbols.TryWriteTypedDataVirtual(offset, module, typeId, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region WriteTypedDataVirtual (byte[])

        /// <summary>
        /// The WriteTypedDataVirtual method writes data to the target's virtual address space. The number of bytes written is the size of the specified type.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space where the data will be written.</param>
        /// <param name="module">Specifies the base address of the module containing the type.</param>
        /// <param name="typeId">Specifies the type ID of the type.</param>
        /// <param name="value">Specifies the buffer containing the data to be written.</param>
        /// <returns>Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WriteTypedDataVirtual(this DebugSymbols symbols, long offset, long module, int typeId, byte[] value)
        {
            int read;
            TryWriteTypedDataVirtual(symbols, offset, module, typeId, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteTypedDataVirtual method writes data to the target's virtual address space. The number of bytes written is the size of the specified type.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the location in the target's virtual address space where the data will be written.</param>
        /// <param name="module">Specifies the base address of the module containing the type.</param>
        /// <param name="typeId">Specifies the type ID of the type.</param>
        /// <param name="value">Specifies the buffer containing the data to be written.</param>
        /// <param name="read">Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteTypedDataVirtual(this DebugSymbols symbols, long offset, long module, int typeId, byte[] value, out int read)
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

                var hr = symbols.TryWriteTypedDataVirtual(offset, module, typeId, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region ReadTypedDataPhysical<T>

        /// <summary>
        /// The ReadTypedDataPhysical method reads the value of a variable from the target computer's physical memory.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address in the target computer's memory of the variable to be read.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type of the variable.</param>
        /// <returns>Receives the data that was read.</returns>
        public static T ReadTypedDataPhysical<T>(this DebugSymbols symbols, long offset, long module, int typeId)
        {
            T value;
            TryReadTypedDataPhysical(symbols, offset, module, typeId, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadTypedDataPhysical method reads the value of a variable from the target computer's physical memory.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address in the target computer's memory of the variable to be read.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type of the variable.</param>
        /// <param name="value">Receives the data that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadTypedDataPhysical<T>(this DebugSymbols symbols, long offset, long module, int typeId, out T value)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = symbols.TryReadTypedDataPhysical(offset, module, typeId, buffer, size, out read);

                if (hr == HRESULT.S_OK || hr == HRESULT.S_FALSE)
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
        #region ReadTypedDataPhysical (byte[])

        /// <summary>
        /// The ReadTypedDataPhysical method reads the value of a variable from the target computer's physical memory.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address in the target computer's memory of the variable to be read.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type of the variable.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <returns>Receives the data that was read.</returns>
        public static byte[] ReadTypedDataPhysical(this DebugSymbols symbols, long offset, long module, int typeId, int size)
        {
            byte[] value;
            TryReadTypedDataPhysical(symbols, offset, module, typeId, size, out value).ThrowDbgEngNotOK();

            return value;
        }

        /// <summary>
        /// The ReadTypedDataPhysical method reads the value of a variable from the target computer's physical memory.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address in the target computer's memory of the variable to be read.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type of the variable.</param>
        /// <param name="size">Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="value">Receives the data that was read.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryReadTypedDataPhysical(this DebugSymbols symbols, long offset, long module, int typeId, int size, out byte[] value)
        {
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                int read;
                var hr = symbols.TryReadTypedDataPhysical(offset, module, typeId, buffer, size, out read);

                if (hr == HRESULT.S_OK || hr == HRESULT.S_FALSE)
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
        #region WriteTypedDataPhysical<T>

        /// <summary>
        /// The WriteTypedDataPhysical method writes the value of a variable in the target computer's physical memory.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type of the variable.</param>
        /// <param name="value">Specifies the buffer containing the data to be written.</param>
        /// <returns>Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WriteTypedDataPhysical<T>(this DebugSymbols symbols, long offset, long module, int typeId, T value)
        {
            int read;
            TryWriteTypedDataPhysical(symbols, offset, module, typeId, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteTypedDataPhysical method writes the value of a variable in the target computer's physical memory.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type of the variable.</param>
        /// <param name="value">Specifies the buffer containing the data to be written.</param>
        /// <param name="read">Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteTypedDataPhysical<T>(this DebugSymbols symbols, long offset, long module, int typeId, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = symbols.TryWriteTypedDataPhysical(offset, module, typeId, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region WriteTypedDataPhysical (byte[])

        /// <summary>
        /// The WriteTypedDataPhysical method writes the value of a variable in the target computer's physical memory.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type of the variable.</param>
        /// <param name="value">Specifies the buffer containing the data to be written.</param>
        /// <returns>Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</returns>
        public static int WriteTypedDataPhysical(this DebugSymbols symbols, long offset, long module, int typeId, byte[] value)
        {
            int read;
            TryWriteTypedDataPhysical(symbols, offset, module, typeId, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The WriteTypedDataPhysical method writes the value of a variable in the target computer's physical memory.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="module">Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">Specifies the type ID of the type of the variable.</param>
        /// <param name="value">Specifies the buffer containing the data to be written.</param>
        /// <param name="read">Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryWriteTypedDataPhysical(this DebugSymbols symbols, long offset, long module, int typeId, byte[] value, out int read)
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

                var hr = symbols.TryWriteTypedDataPhysical(offset, module, typeId, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetScope<T>

        /// <summary>
        /// The GetScope method returns information about the current scope.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public static GetScopeResult<T> GetScope<T>(this DebugSymbols symbols)
        {
            GetScopeResult<T> result;
            TryGetScope(symbols, out result).ThrowDbgEngNotOK();
            return result;
        }

        /// <summary>
        /// The GetScope method returns information about the current scope.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetScope<T>(this DebugSymbols symbols, out GetScopeResult<T> result)
        {
            var size = Marshal.SizeOf<T>();

            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                T context;

                var hr = symbols.TryGetScope(buffer, size, out var rawResult);

                if (hr == HRESULT.S_OK)
                    context = Marshal.PtrToStructure<T>(buffer);
                else
                    context = default(T);

                result = new GetScopeResult<T>(context, rawResult.InstructionOffset, rawResult.ScopeFrame);

                return hr;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region SetScope<T>

        /// <summary>
        /// The SetScope method sets the current scope.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="instructionOffset">Specifies the location in the process's virtual address space for the scope's current instruction. This is only used if both ScopeFrame and ScopeContext are NULL; otherwise, it is ignored.</param>
        /// <param name="scopeFrame">Specifies the scope's stack frame. For information about this structure, see <see cref="DEBUG_STACK_FRAME"/>.</param>
        /// <param name="context">Specifies the scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.</param>
        public static void SetScope<T>(this DebugSymbols symbols, long instructionOffset, DEBUG_STACK_FRAME scopeFrame, in T context) =>
            TrySetScope(symbols, instructionOffset, scopeFrame, context).ThrowDbgEngNotOK();

        /// <summary>
        /// The SetScope method sets the current scope.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="instructionOffset">Specifies the location in the process's virtual address space for the scope's current instruction. This is only used if both ScopeFrame and ScopeContext are NULL; otherwise, it is ignored.</param>
        /// <param name="scopeFrame">Specifies the scope's stack frame. For information about this structure, see <see cref="DEBUG_STACK_FRAME"/>.</param>
        /// <param name="context">Specifies the scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TrySetScope<T>(this DebugSymbols symbols, long instructionOffset, DEBUG_STACK_FRAME scopeFrame, in T context)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(context, buffer, false);

                return symbols.TrySetScope(instructionOffset, scopeFrame, buffer, size);
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetScopeEx<T>


        /// <summary>
        /// Gets the scope as an extended frame structure.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public static GetScopeExResult<T> GetScopeEx<T>(this DebugSymbols symbols)
        {
            GetScopeExResult<T> result;
            TryGetScopeEx(symbols, out result).ThrowDbgEngNotOK();
            return result;
        }

        /// <summary>
        /// Gets the scope as an extended frame structure.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public static HRESULT TryGetScopeEx<T>(this DebugSymbols symbols, out GetScopeExResult<T> result)
        {
            var size = Marshal.SizeOf<T>();

            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                T context;

                var hr = symbols.TryGetScopeEx(buffer, size, out var rawResult);

                if (hr == HRESULT.S_OK)
                    context = Marshal.PtrToStructure<T>(buffer);
                else
                    context = default(T);

                result = new GetScopeExResult<T>(context, rawResult.InstructionOffset, rawResult.ScopeFrame);

                return hr;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region SetScopeEx<T>

        /// <summary>
        /// Sets the scope as an extended frame structure.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="instructionOffset">[in] The offset of the instruction for the scope.</param>
        /// <param name="scopeFrame">[in, optional] The scope frame to set as a <see cref="DEBUG_STACK_FRAME_EX"/> structure.</param>
        /// <param name="context">Specifies the scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.</param>
        public static void SetScopeEx<T>(this DebugSymbols symbols, long instructionOffset, DEBUG_STACK_FRAME_EX scopeFrame, in T context) =>
            TrySetScopeEx(symbols, instructionOffset, scopeFrame, context).ThrowDbgEngNotOK();

        /// <summary>
        /// Sets the scope as an extended frame structure.
        /// </summary>
        /// <typeparam name="T">The type of a processor specific CONTEXT structure that stores the thread context.</typeparam>
        /// /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="instructionOffset">[in] The offset of the instruction for the scope.</param>
        /// <param name="scopeFrame">[in, optional] The scope frame to set as a <see cref="DEBUG_STACK_FRAME_EX"/> structure.</param>
        /// <param name="context">Specifies the scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public static HRESULT TrySetScopeEx<T>(this DebugSymbols symbols, long instructionOffset, DEBUG_STACK_FRAME_EX scopeFrame, in T context)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(context, buffer, false);

                return symbols.TrySetScopeEx(instructionOffset, scopeFrame, buffer, size);
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetModuleVersionInformation<T>

        /// <summary>
        /// The GetModuleVersionInformation method returns version information for the specified module.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="value">Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <returns>Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</returns>
        public static int GetModuleVersionInformation<T>(this DebugSymbols symbols, int index, long @base, string item, T value)
        {
            int read;
            TryGetModuleVersionInformation(symbols, index, @base, item, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The GetModuleVersionInformation method returns version information for the specified module.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="value">Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <param name="read">Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetModuleVersionInformation<T>(this DebugSymbols symbols, int index, long @base, string item, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = symbols.TryGetModuleVersionInformation(index, @base, item, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetModuleVersionInformation (byte[])

        /// <summary>
        /// The GetModuleVersionInformation method returns version information for the specified module.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="value">Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <returns>Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</returns>
        public static int GetModuleVersionInformation(this DebugSymbols symbols, int index, long @base, string item, byte[] value)
        {
            int read;
            TryGetModuleVersionInformation(symbols, index, @base, item, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The GetModuleVersionInformation method returns version information for the specified module.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="value">Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <param name="read">Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetModuleVersionInformation(this DebugSymbols symbols, int index, long @base, string item, byte[] value, out int read)
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

                var hr = symbols.TryGetModuleVersionInformation(index, @base, item, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetModuleVersionInformationWide<T>

        /// <summary>
        /// The GetModuleVersionInformationWide method returns version information for the specified module.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="value">Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <returns>Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</returns>
        public static int GetModuleVersionInformationWide<T>(this DebugSymbols symbols, int index, long @base, string item, T value)
        {
            int read;
            TryGetModuleVersionInformationWide(symbols, index, @base, item, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The GetModuleVersionInformationWide method returns version information for the specified module.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="value">Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <param name="read">Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetModuleVersionInformationWide<T>(this DebugSymbols symbols, int index, long @base, string item, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = symbols.TryGetModuleVersionInformationWide(index, @base, item, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetModuleVersionInformationWide (byte[])

        /// <summary>
        /// The GetModuleVersionInformationWide method returns version information for the specified module.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="value">Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <returns>Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</returns>
        public static int GetModuleVersionInformationWide(this DebugSymbols symbols, int index, long @base, string item, byte[] value)
        {
            int read;
            TryGetModuleVersionInformationWide(symbols, index, @base, item, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The GetModuleVersionInformationWide method returns version information for the specified module.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="index">Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="value">Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <param name="read">Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetModuleVersionInformationWide(this DebugSymbols symbols, int index, long @base, string item, byte[] value, out int read)
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

                var hr = symbols.TryGetModuleVersionInformationWide(index, @base, item, buffer, value.Length, out read);

                return hr;
            }
            finally
            {
                if (buffer == IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetFunctionEntryByOffset<T>

        /// <summary>
        /// The GetFunctionEntryByOffset method returns the function entry information for a function.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies a location in the current process's virtual address space of the function's implementation. This is the value returned in the Offset parameter of <see cref="DebugSymbols.GetNextSymbolMatch"/> and <see cref="IDebugSymbolGroup2.GetSymbolOffset"/>, and the value of the Offset field in the <see cref="DEBUG_SYMBOL_ENTRY"/> structure.</param>
        /// <param name="flags">Specifies a bit-flag which alters the behavior of this method. If the bit DEBUG_GETFNENT_RAW_ENTRY_ONLY is not set, the engine will provide artificial entries for well known cases.<para/>
        /// If this bit is set the artificial entries are not used.</param>
        /// <param name="value">Receives the function entry information. If the effective processor is an x86, this is the FPO_DATA structure for the function.<para/>
        /// For all other architectures, this is the IMAGE_FUNCTION_ENTRY structure for that architecture.</param>
        /// <returns>Specifies the size of the function entry information.</returns>
        public static int GetFunctionEntryByOffset<T>(this DebugSymbols symbols, long offset, DEBUG_GETFNENT flags, T value)
        {
            int read;
            TryGetFunctionEntryByOffset(symbols, offset, flags, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The GetFunctionEntryByOffset method returns the function entry information for a function.
        /// </summary>
        /// <typeparam name="T">The type of value to use.</typeparam>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies a location in the current process's virtual address space of the function's implementation. This is the value returned in the Offset parameter of <see cref="DebugSymbols.GetNextSymbolMatch"/> and <see cref="IDebugSymbolGroup2.GetSymbolOffset"/>, and the value of the Offset field in the <see cref="DEBUG_SYMBOL_ENTRY"/> structure.</param>
        /// <param name="flags">Specifies a bit-flag which alters the behavior of this method. If the bit DEBUG_GETFNENT_RAW_ENTRY_ONLY is not set, the engine will provide artificial entries for well known cases.<para/>
        /// If this bit is set the artificial entries are not used.</param>
        /// <param name="value">Receives the function entry information. If the effective processor is an x86, this is the FPO_DATA structure for the function.<para/>
        /// For all other architectures, this is the IMAGE_FUNCTION_ENTRY structure for that architecture.</param>
        /// <param name="read">Specifies the size of the function entry information.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetFunctionEntryByOffset<T>(this DebugSymbols symbols, long offset, DEBUG_GETFNENT flags, T value, out int read)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, buffer, false);
                var hr = symbols.TryGetFunctionEntryByOffset(offset, flags, buffer, size, out read);

                return hr;
            }
            finally
            {
                Marshal.DestroyStructure<T>(buffer);
                Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region GetFunctionEntryByOffset (byte[])

        /// <summary>
        /// The GetFunctionEntryByOffset method returns the function entry information for a function.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies a location in the current process's virtual address space of the function's implementation. This is the value returned in the Offset parameter of <see cref="DebugSymbols.GetNextSymbolMatch"/> and <see cref="IDebugSymbolGroup2.GetSymbolOffset"/>, and the value of the Offset field in the <see cref="DEBUG_SYMBOL_ENTRY"/> structure.</param>
        /// <param name="flags">Specifies a bit-flag which alters the behavior of this method. If the bit DEBUG_GETFNENT_RAW_ENTRY_ONLY is not set, the engine will provide artificial entries for well known cases.<para/>
        /// If this bit is set the artificial entries are not used.</param>
        /// <param name="value">Receives the function entry information. If the effective processor is an x86, this is the FPO_DATA structure for the function.<para/>
        /// For all other architectures, this is the IMAGE_FUNCTION_ENTRY structure for that architecture.</param>
        /// <returns>Specifies the size of the function entry information.</returns>
        public static int GetFunctionEntryByOffset(this DebugSymbols symbols, long offset, DEBUG_GETFNENT flags, byte[] value)
        {
            int read;
            TryGetFunctionEntryByOffset(symbols, offset, flags, value, out read).ThrowDbgEngNotOK();

            return read;
        }

        /// <summary>
        /// The GetFunctionEntryByOffset method returns the function entry information for a function.
        /// </summary>
        /// <param name="symbols">The object on which this method operates.</param>
        /// <param name="offset">Specifies a location in the current process's virtual address space of the function's implementation. This is the value returned in the Offset parameter of <see cref="DebugSymbols.GetNextSymbolMatch"/> and <see cref="IDebugSymbolGroup2.GetSymbolOffset"/>, and the value of the Offset field in the <see cref="DEBUG_SYMBOL_ENTRY"/> structure.</param>
        /// <param name="flags">Specifies a bit-flag which alters the behavior of this method. If the bit DEBUG_GETFNENT_RAW_ENTRY_ONLY is not set, the engine will provide artificial entries for well known cases.<para/>
        /// If this bit is set the artificial entries are not used.</param>
        /// <param name="value">Receives the function entry information. If the effective processor is an x86, this is the FPO_DATA structure for the function.<para/>
        /// For all other architectures, this is the IMAGE_FUNCTION_ENTRY structure for that architecture.</param>
        /// <param name="read">Specifies the size of the function entry information.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public static HRESULT TryGetFunctionEntryByOffset(this DebugSymbols symbols, long offset, DEBUG_GETFNENT flags, byte[] value, out int read)
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

                var hr = symbols.TryGetFunctionEntryByOffset(offset, flags, buffer, value.Length, out read);

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
