using System;
using System.Diagnostics;
using ClrDebug.TypeLib;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The memory access interface to the underlying debugger.
    /// </summary>
    public class DebugHostMemory : ComObject<IDebugHostMemory>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostMemory"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostMemory(IDebugHostMemory raw) : base(raw)
        {
        }

        #region IDebugHostMemory
        #region ReadBytes

        /// <summary>
        /// Reads a number of bytes from the address space of the target as defined by the inpassed context and location.The number of bytes read is returned in "bytesRead" upon success.
        /// </summary>
        /// <param name="context">The host context in which to read bytes. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to read bytes. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="buffer">The bytes read from the debug target will be written to this buffer.</param>
        /// <param name="bufferSize">The size of the buffer and the number of bytes to read.</param>
        /// <returns>The number of bytes actually read from the debug target will be returned here. If the method can complete a partial read, S_FALSE will be returned and the value in bytesRead may be less than the requested number of bytes.<para/>
        /// If the method returns S_OK, a full read was completed.</returns>
        public long ReadBytes(IDebugHostContext context, Location location, IntPtr buffer, long bufferSize)
        {
            long bytesRead;
            TryReadBytes(context, location, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOK();

            return bytesRead;
        }

        /// <summary>
        /// Reads a number of bytes from the address space of the target as defined by the inpassed context and location.The number of bytes read is returned in "bytesRead" upon success.
        /// </summary>
        /// <param name="context">The host context in which to read bytes. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to read bytes. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="buffer">The bytes read from the debug target will be written to this buffer.</param>
        /// <param name="bufferSize">The size of the buffer and the number of bytes to read.</param>
        /// <param name="bytesRead">The number of bytes actually read from the debug target will be returned here. If the method can complete a partial read, S_FALSE will be returned and the value in bytesRead may be less than the requested number of bytes.<para/>
        /// If the method returns S_OK, a full read was completed.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryReadBytes(IDebugHostContext context, Location location, IntPtr buffer, long bufferSize, out long bytesRead)
        {
            /*HRESULT ReadBytes(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [Out] IntPtr buffer,
            [In] long bufferSize,
            [Out] out long bytesRead);*/
            return Raw.ReadBytes(context, location, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WriteBytes

        /// <summary>
        /// Writes a number of bytes to the address space of the target as defined by the inpassed context and location. The number of bytes written is returned in "bytesWritten" upon success.
        /// </summary>
        /// <param name="context">The host context in which to write bytes. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to write bytes. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="buffer">The bytes to write to the debug target.</param>
        /// <param name="bufferSize">The size of the buffer / number of bytes to write to the debug target.</param>
        /// <returns>The number of bytes actually written to the debug target will be returned here. If the method can complete a partial write, S_FALSE will be returned and the value in bytesWritten may be less than the requested number of bytes.<para/>
        /// If the method returns S_OK, a full write was completed.</returns>
        public long WriteBytes(IDebugHostContext context, Location location, IntPtr buffer, long bufferSize)
        {
            long bytesWritten;
            TryWriteBytes(context, location, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOK();

            return bytesWritten;
        }

        /// <summary>
        /// Writes a number of bytes to the address space of the target as defined by the inpassed context and location. The number of bytes written is returned in "bytesWritten" upon success.
        /// </summary>
        /// <param name="context">The host context in which to write bytes. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to write bytes. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="buffer">The bytes to write to the debug target.</param>
        /// <param name="bufferSize">The size of the buffer / number of bytes to write to the debug target.</param>
        /// <param name="bytesWritten">The number of bytes actually written to the debug target will be returned here. If the method can complete a partial write, S_FALSE will be returned and the value in bytesWritten may be less than the requested number of bytes.<para/>
        /// If the method returns S_OK, a full write was completed.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryWriteBytes(IDebugHostContext context, Location location, IntPtr buffer, long bufferSize, out long bytesWritten)
        {
            /*HRESULT WriteBytes(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] IntPtr buffer,
            [In] long bufferSize,
            [Out] out long bytesWritten);*/
            return Raw.WriteBytes(context, location, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #region ReadPointers

        /// <summary>
        /// Reads a number of pointer sized objects from the address space of the target as defined by the inpassed context and location.<para/>
        /// Each read pointer is, if necessary, zero extended to 64-bits and returned.
        /// </summary>
        /// <param name="context">The host context in which to read pointers. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to read pointers. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="count">The number of pointers to read.</param>
        /// <returns>The pointers read from the debug target will be placed into the array passed here. Any pointers less than 64-bits in size will be zero extended to 64-bits.</returns>
        public long[] ReadPointers(IDebugHostContext context, Location location, long count)
        {
            long[] pointers;
            TryReadPointers(context, location, count, out pointers).ThrowDbgEngNotOK();

            return pointers;
        }

        /// <summary>
        /// Reads a number of pointer sized objects from the address space of the target as defined by the inpassed context and location.<para/>
        /// Each read pointer is, if necessary, zero extended to 64-bits and returned.
        /// </summary>
        /// <param name="context">The host context in which to read pointers. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to read pointers. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="count">The number of pointers to read.</param>
        /// <param name="pointers">The pointers read from the debug target will be placed into the array passed here. Any pointers less than 64-bits in size will be zero extended to 64-bits.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryReadPointers(IDebugHostContext context, Location location, long count, out long[] pointers)
        {
            /*HRESULT ReadPointers(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] long count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] pointers);*/
            pointers = new long[(int) count];
            HRESULT hr = Raw.ReadPointers(context, location, count, pointers);

            return hr;
        }

        #endregion
        #region WritePointers

        /// <summary>
        /// Takes a number of pointers as held in unsigned 64-bit values, truncates them to the native pointer size of the target, and writes them into the address space of the target as defined by the inpassed context and location.
        /// </summary>
        /// <param name="context">The host context in which to write pointers. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to write pointers. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="count">The number of pointers to write.</param>
        /// <param name="pointers">The pointers to write to the debug target. If the target is 32-bits, the pointer values here will be truncated prior to writing them to the underlying debug target.</param>
        public void WritePointers(IDebugHostContext context, Location location, long count, long[] pointers)
        {
            TryWritePointers(context, location, count, pointers).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Takes a number of pointers as held in unsigned 64-bit values, truncates them to the native pointer size of the target, and writes them into the address space of the target as defined by the inpassed context and location.
        /// </summary>
        /// <param name="context">The host context in which to write pointers. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location at which to write pointers. This location may represent a virtual address within the address space defined by context or it may represent something like a register within a context record for a thread.</param>
        /// <param name="count">The number of pointers to write.</param>
        /// <param name="pointers">The pointers to write to the debug target. If the target is 32-bits, the pointer values here will be truncated prior to writing them to the underlying debug target.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryWritePointers(IDebugHostContext context, Location location, long count, long[] pointers)
        {
            /*HRESULT WritePointers(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] long count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] pointers);*/
            return Raw.WritePointers(context, location, count, pointers);
        }

        #endregion
        #region GetDisplayStringForLocation

        /// <summary>
        /// For a given location within the address space of the target as defined by context and location, convert the location to a displayable string (according to whatever format the host chooses).<para/>
        /// If the "verbose" argument is true, the string conversion may be "more verbose"
        /// </summary>
        /// <param name="context">The host context in which the location is valid. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location to convert to a displayable string.</param>
        /// <param name="verbose">An indication of whether the conversion should be verbose or not. A verbose conversion will contain more information than a non-verbose one.<para/>
        /// The default is for a non-verbose conversion.</param>
        /// <returns>A displayable string for the location will be returned here. This string is allocated by SysAllocString and the caller is responsible for freeing the allocation with a call to the SysFreeString function.</returns>
        public string GetDisplayStringForLocation(IDebugHostContext context, Location location, bool verbose)
        {
            string locationName;
            TryGetDisplayStringForLocation(context, location, verbose, out locationName).ThrowDbgEngNotOK();

            return locationName;
        }

        /// <summary>
        /// For a given location within the address space of the target as defined by context and location, convert the location to a displayable string (according to whatever format the host chooses).<para/>
        /// If the "verbose" argument is true, the string conversion may be "more verbose"
        /// </summary>
        /// <param name="context">The host context in which the location is valid. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location to convert to a displayable string.</param>
        /// <param name="verbose">An indication of whether the conversion should be verbose or not. A verbose conversion will contain more information than a non-verbose one.<para/>
        /// The default is for a non-verbose conversion.</param>
        /// <param name="locationName">A displayable string for the location will be returned here. This string is allocated by SysAllocString and the caller is responsible for freeing the allocation with a call to the SysFreeString function.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetDisplayStringForLocation(IDebugHostContext context, Location location, bool verbose, out string locationName)
        {
            /*HRESULT GetDisplayStringForLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In, MarshalAs(UnmanagedType.U1)] bool verbose,
            [Out, MarshalAs(UnmanagedType.BStr)] out string locationName);*/
            return Raw.GetDisplayStringForLocation(context, location, verbose, out locationName);
        }

        #endregion
        #endregion
        #region IDebugHostMemory2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostMemory2 Raw2 => (IDebugHostMemory2) Raw;

        #region LinearizeLocation

        /// <summary>
        /// Takes a location which may represent something other than a virtual memory address and attempts to linearize the location into a virtual memory address within the given context.<para/>
        /// This operation may fail if the location cannot be represented by a virtual address (e.g.: it's a register).
        /// </summary>
        /// <param name="context">The host context in which the location is valid. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location to linearize into a virtual memory address.</param>
        /// <returns>A new location representing a virtual memory address will be returned here. If the location cannot be linearized into a virtual memory address (e.g.: the location represents an enregistered value), this method will fail.</returns>
        public Location LinearizeLocation(IDebugHostContext context, Location location)
        {
            Location pLinearizedLocation;
            TryLinearizeLocation(context, location, out pLinearizedLocation).ThrowDbgEngNotOK();

            return pLinearizedLocation;
        }

        /// <summary>
        /// Takes a location which may represent something other than a virtual memory address and attempts to linearize the location into a virtual memory address within the given context.<para/>
        /// This operation may fail if the location cannot be represented by a virtual address (e.g.: it's a register).
        /// </summary>
        /// <param name="context">The host context in which the location is valid. This represents, for example, the address space in which the location exists.</param>
        /// <param name="location">The location to linearize into a virtual memory address.</param>
        /// <param name="pLinearizedLocation">A new location representing a virtual memory address will be returned here. If the location cannot be linearized into a virtual memory address (e.g.: the location represents an enregistered value), this method will fail.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryLinearizeLocation(IDebugHostContext context, Location location, out Location pLinearizedLocation)
        {
            /*HRESULT LinearizeLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [Out] out Location pLinearizedLocation);*/
            return Raw2.LinearizeLocation(context, location, out pLinearizedLocation);
        }

        #endregion
        #endregion
        #region IDebugHostMemory3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostMemory3 Raw3 => (IDebugHostMemory3) Raw;

        #region CanonicalizeLocation

        public Location CanonicalizeLocation(IDebugHostContext context, Location location)
        {
            Location pCanonicalizedLocation;
            TryCanonicalizeLocation(context, location, out pCanonicalizedLocation).ThrowDbgEngNotOK();

            return pCanonicalizedLocation;
        }

        public HRESULT TryCanonicalizeLocation(IDebugHostContext context, Location location, out Location pCanonicalizedLocation)
        {
            /*HRESULT CanonicalizeLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [Out] out Location pCanonicalizedLocation);*/
            return Raw3.CanonicalizeLocation(context, location, out pCanonicalizedLocation);
        }

        #endregion
        #endregion
        #region IDebugHostMemory4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostMemory4 Raw4 => (IDebugHostMemory4) Raw;

        #region GetPhysicalAddressLocation

        public Location GetPhysicalAddressLocation(long physAddr)
        {
            Location pPhysicalAddressLocation;
            TryGetPhysicalAddressLocation(physAddr, out pPhysicalAddressLocation).ThrowDbgEngNotOK();

            return pPhysicalAddressLocation;
        }

        public HRESULT TryGetPhysicalAddressLocation(long physAddr, out Location pPhysicalAddressLocation)
        {
            /*HRESULT GetPhysicalAddressLocation(
            [In] long physAddr,
            [Out] out Location pPhysicalAddressLocation);*/
            return Raw4.GetPhysicalAddressLocation(physAddr, out pPhysicalAddressLocation);
        }

        #endregion
        #region IsPhysicalAddressLocation

        public bool IsPhysicalAddressLocation(Location pLocation)
        {
            /*bool IsPhysicalAddressLocation(
            [In] ref Location pLocation);*/
            return Raw4.IsPhysicalAddressLocation(ref pLocation);
        }

        #endregion
        #endregion
        #region IDebugHostMemory5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostMemory5 Raw5 => (IDebugHostMemory5) Raw;

        #region ReadIntrinsics

        public ReadIntrinsicsResult ReadIntrinsics(IDebugHostContext context, Location location, VARENUM vt, long count)
        {
            ReadIntrinsicsResult result;
            TryReadIntrinsics(context, location, vt, count, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryReadIntrinsics(IDebugHostContext context, Location location, VARENUM vt, long count, out ReadIntrinsicsResult result)
        {
            /*HRESULT ReadIntrinsics(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] VARENUM vt,
            [In] long count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 3)] object[] vals,
            [Out] out long intrinsicsRead);*/
            object[] vals = new object[(int) count];
            long intrinsicsRead;
            HRESULT hr = Raw5.ReadIntrinsics(context, location, vt, count, vals, out intrinsicsRead);

            if (hr == HRESULT.S_OK)
                result = new ReadIntrinsicsResult(vals, intrinsicsRead);
            else
                result = default(ReadIntrinsicsResult);

            return hr;
        }

        #endregion
        #region ReadOrdinalIntrinsics

        public ReadOrdinalIntrinsicsResult ReadOrdinalIntrinsics(IDebugHostContext context, Location location, long ordinalSize, bool ordinalIsSigned, long count)
        {
            ReadOrdinalIntrinsicsResult result;
            TryReadOrdinalIntrinsics(context, location, ordinalSize, ordinalIsSigned, count, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryReadOrdinalIntrinsics(IDebugHostContext context, Location location, long ordinalSize, bool ordinalIsSigned, long count, out ReadOrdinalIntrinsicsResult result)
        {
            /*HRESULT ReadOrdinalIntrinsics(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location location,
            [In] long ordinalSize,
            [In, MarshalAs(UnmanagedType.U1)] bool ordinalIsSigned,
            [In] long count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 4)] object[] vals,
            [Out] out long intrinsicsRead);*/
            object[] vals = new object[(int) count];
            long intrinsicsRead;
            HRESULT hr = Raw5.ReadOrdinalIntrinsics(context, location, ordinalSize, ordinalIsSigned, count, vals, out intrinsicsRead);

            if (hr == HRESULT.S_OK)
                result = new ReadOrdinalIntrinsicsResult(vals, intrinsicsRead);
            else
                result = default(ReadOrdinalIntrinsicsResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
