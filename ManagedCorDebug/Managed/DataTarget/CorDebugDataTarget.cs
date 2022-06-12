using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides a callback interface that provides access to a particular target process.
    /// </summary>
    /// <remarks>
    /// <see cref="ICorDebugDataTarget"/> and its methods have the following characteristics: The target process should be stopped and
    /// not changed in any way while ICorDebug* interfaces (and therefore <see cref="ICorDebugDataTarget"/> methods) are being called.
    /// If the target is a live process and its state changes, the <see cref="CLRDebugging.OpenVirtualProcess"/> method
    /// has to be called again to provide a replacement <see cref="ICorDebugProcess"/> instance.
    /// </remarks>
    public abstract class CorDebugDataTarget : ComObject<ICorDebugDataTarget>
    {
        public static CorDebugDataTarget New(ICorDebugDataTarget value)
        {
            if (value is ICorDebugMutableDataTarget)
                return new CorDebugMutableDataTarget((ICorDebugMutableDataTarget) value);

            throw new NotImplementedException("Encountered an ICorDebugDataTarget' interface of an unknown type. Cannot create wrapper type.");
        }

        protected CorDebugDataTarget(ICorDebugDataTarget raw) : base(raw)
        {
        }

        #region ICorDebugDataTarget
        #region GetPlatform

        /// <summary>
        /// Provides information about the platform, including processor architecture and operating system, on which the target process is running.
        /// </summary>
        public CorDebugPlatform Platform
        {
            get
            {
                HRESULT hr;
                CorDebugPlatform pTargetPlatform;

                if ((hr = TryGetPlatform(out pTargetPlatform)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pTargetPlatform;
            }
        }

        /// <summary>
        /// Provides information about the platform, including processor architecture and operating system, on which the target process is running.
        /// </summary>
        /// <param name="pTargetPlatform">[out] A pointer to a <see cref="CorDebugPlatform"/> enumeration that describes the target platform.</param>
        /// <remarks>
        /// The CorDebugPlatformEnum enumeration return value is used by the <see cref="ICorDebug"/> interface to determine
        /// details of the target process such as its pointer size, address space layout, register set, instruction format,
        /// context layout, and calling conventions. The pTargetPlatform value may refer to a platform that is being emulated
        /// for the target instead of specifying the actual hardware in use. For example, a process that is running in the
        /// Windows on Windows (WOW) environment on a 64-bit edition of the Windows operating system should use the CORDB_PLATFORM_WINDOWS_X86
        /// value of the <see cref="CorDebugPlatform"/> enumeration. This method must succeed. If it fails, the target platform
        /// is unusable. The method may fail for the following reasons:
        /// </remarks>
        public HRESULT TryGetPlatform(out CorDebugPlatform pTargetPlatform)
        {
            /*HRESULT GetPlatform(out CorDebugPlatform pTargetPlatform);*/
            return Raw.GetPlatform(out pTargetPlatform);
        }

        #endregion
        #region ReadVirtual

        /// <summary>
        /// Gets a block of contiguous memory starting at the specified address, and returns it in the supplied buffer.
        /// </summary>
        /// <param name="address">[in] The start address of requested memory.</param>
        /// <param name="bytesRequested">[in] The number of bytes to get from the target address.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// If the first byte (at the specified start address) can be read, the call should return success (to support efficient
        /// reading of data structures with self-describing length, like null-terminated strings).
        /// </remarks>
        public CorDebugDataTarget_ReadVirtualResult ReadVirtual(ulong address, uint bytesRequested)
        {
            HRESULT hr;
            CorDebugDataTarget_ReadVirtualResult result;

            if ((hr = TryReadVirtual(address, bytesRequested, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a block of contiguous memory starting at the specified address, and returns it in the supplied buffer.
        /// </summary>
        /// <param name="address">[in] The start address of requested memory.</param>
        /// <param name="bytesRequested">[in] The number of bytes to get from the target address.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// If the first byte (at the specified start address) can be read, the call should return success (to support efficient
        /// reading of data structures with self-describing length, like null-terminated strings).
        /// </remarks>
        public HRESULT TryReadVirtual(ulong address, uint bytesRequested, out CorDebugDataTarget_ReadVirtualResult result)
        {
            /*HRESULT ReadVirtual([In] ulong address, out byte pBuffer, [In] uint bytesRequested, out uint pBytesRead);*/
            byte pBuffer;
            uint pBytesRead;
            HRESULT hr = Raw.ReadVirtual(address, out pBuffer, bytesRequested, out pBytesRead);

            if (hr == HRESULT.S_OK)
                result = new CorDebugDataTarget_ReadVirtualResult(pBuffer, pBytesRead);
            else
                result = default(CorDebugDataTarget_ReadVirtualResult);

            return hr;
        }

        #endregion
        #region GetThreadContext

        /// <summary>
        /// Returns the current thread context for the specified thread.
        /// </summary>
        /// <param name="dwThreadId">[in] The identifier of the thread whose context is to be retrieved. The identifier is defined by the operating system.</param>
        /// <param name="contextFlags">[in] A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <param name="contextSize">[in] The size of pContext.</param>
        /// <returns>[out] The buffer where the thread context will be stored.</returns>
        /// <remarks>
        /// On Windows platforms, pContext must be a CONTEXT structure (defined in WinNT.h) that is appropriate for the machine
        /// type specified by the <see cref="Platform"/> property. contextFlags must have the same values as the ContextFlags
        /// field of the CONTEXT structure. The CONTEXT structure is processor-specific; refer to the WinNT.h file for details.
        /// </remarks>
        public byte GetThreadContext(uint dwThreadId, uint contextFlags, uint contextSize)
        {
            HRESULT hr;
            byte pContext;

            if ((hr = TryGetThreadContext(dwThreadId, contextFlags, contextSize, out pContext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pContext;
        }

        /// <summary>
        /// Returns the current thread context for the specified thread.
        /// </summary>
        /// <param name="dwThreadId">[in] The identifier of the thread whose context is to be retrieved. The identifier is defined by the operating system.</param>
        /// <param name="contextFlags">[in] A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.</param>
        /// <param name="contextSize">[in] The size of pContext.</param>
        /// <param name="pContext">[out] The buffer where the thread context will be stored.</param>
        /// <remarks>
        /// On Windows platforms, pContext must be a CONTEXT structure (defined in WinNT.h) that is appropriate for the machine
        /// type specified by the <see cref="Platform"/> property. contextFlags must have the same values as the ContextFlags
        /// field of the CONTEXT structure. The CONTEXT structure is processor-specific; refer to the WinNT.h file for details.
        /// </remarks>
        public HRESULT TryGetThreadContext(uint dwThreadId, uint contextFlags, uint contextSize, out byte pContext)
        {
            /*HRESULT GetThreadContext([In] uint dwThreadId, [In] uint contextFlags, [In] uint contextSize, out byte pContext);*/
            return Raw.GetThreadContext(dwThreadId, contextFlags, contextSize, out pContext);
        }

        #endregion
        #endregion
        #region ICorDebugDataTarget2

        public ICorDebugDataTarget2 Raw2 => (ICorDebugDataTarget2) Raw;

        #region GetImageFromPointer

        /// <summary>
        /// Returns the module base address and size from an address in that module.
        /// </summary>
        /// <param name="addr">A <see cref="CORDB_ADDRESS"/> value that represents an address in a module.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetImageFromPointerResult GetImageFromPointer(CORDB_ADDRESS addr)
        {
            HRESULT hr;
            GetImageFromPointerResult result;

            if ((hr = TryGetImageFromPointer(addr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Returns the module base address and size from an address in that module.
        /// </summary>
        /// <param name="addr">A <see cref="CORDB_ADDRESS"/> value that represents an address in a module.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetImageFromPointer(CORDB_ADDRESS addr, out GetImageFromPointerResult result)
        {
            /*HRESULT GetImageFromPointer([In] CORDB_ADDRESS addr, out CORDB_ADDRESS pImageBase, out uint pSize);*/
            CORDB_ADDRESS pImageBase;
            uint pSize;
            HRESULT hr = Raw2.GetImageFromPointer(addr, out pImageBase, out pSize);

            if (hr == HRESULT.S_OK)
                result = new GetImageFromPointerResult(pImageBase, pSize);
            else
                result = default(GetImageFromPointerResult);

            return hr;
        }

        #endregion
        #region GetImageLocation

        /// <summary>
        /// Returns the path of a module from the module's base address.
        /// </summary>
        /// <param name="baseAddress">[in] A <see cref="CORDB_ADDRESS"/> value that represents the module's base address.</param>
        /// <returns>[out] The path of the module.</returns>
        public string GetImageLocation(CORDB_ADDRESS baseAddress)
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetImageLocation(baseAddress, out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// Returns the path of a module from the module's base address.
        /// </summary>
        /// <param name="baseAddress">[in] A <see cref="CORDB_ADDRESS"/> value that represents the module's base address.</param>
        /// <param name="szNameResult">[out] The path of the module.</param>
        public HRESULT TryGetImageLocation(CORDB_ADDRESS baseAddress, out string szNameResult)
        {
            /*HRESULT GetImageLocation(
            [In] CORDB_ADDRESS baseAddress,
            [In] uint cchName,
            out uint pcchName,
            [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw2.GetImageLocation(baseAddress, cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw2.GetImageLocation(baseAddress, cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetSymbolProviderForImage

        /// <summary>
        /// Returns the symbol-provider for a module from the base address of that module.
        /// </summary>
        /// <param name="imageBaseAddress">[in] A <see cref="CORDB_ADDRESS"/> value that represents the base address of a module.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugSymbolProvider"/> object.</returns>
        public CorDebugSymbolProvider GetSymbolProviderForImage(CORDB_ADDRESS imageBaseAddress)
        {
            HRESULT hr;
            CorDebugSymbolProvider ppSymProviderResult;

            if ((hr = TryGetSymbolProviderForImage(imageBaseAddress, out ppSymProviderResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppSymProviderResult;
        }

        /// <summary>
        /// Returns the symbol-provider for a module from the base address of that module.
        /// </summary>
        /// <param name="imageBaseAddress">[in] A <see cref="CORDB_ADDRESS"/> value that represents the base address of a module.</param>
        /// <param name="ppSymProviderResult">[out] A pointer to the address of an <see cref="ICorDebugSymbolProvider"/> object.</param>
        public HRESULT TryGetSymbolProviderForImage(CORDB_ADDRESS imageBaseAddress, out CorDebugSymbolProvider ppSymProviderResult)
        {
            /*HRESULT GetSymbolProviderForImage(
            [In] CORDB_ADDRESS imageBaseAddress,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugSymbolProvider ppSymProvider);*/
            ICorDebugSymbolProvider ppSymProvider;
            HRESULT hr = Raw2.GetSymbolProviderForImage(imageBaseAddress, out ppSymProvider);

            if (hr == HRESULT.S_OK)
                ppSymProviderResult = new CorDebugSymbolProvider(ppSymProvider);
            else
                ppSymProviderResult = default(CorDebugSymbolProvider);

            return hr;
        }

        #endregion
        #region EnumerateThreadIDs

        /// <summary>
        /// Returns a list of active thread IDs.
        /// </summary>
        /// <param name="cThreadIds">[in] The maximum number of threads whose IDs can be returned.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumerateThreadIDsResult EnumerateThreadIDs(uint cThreadIds)
        {
            HRESULT hr;
            EnumerateThreadIDsResult result;

            if ((hr = TryEnumerateThreadIDs(cThreadIds, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Returns a list of active thread IDs.
        /// </summary>
        /// <param name="cThreadIds">[in] The maximum number of threads whose IDs can be returned.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryEnumerateThreadIDs(uint cThreadIds, out EnumerateThreadIDsResult result)
        {
            /*HRESULT EnumerateThreadIDs([In] uint cThreadIds, out uint pcThreadIds, [Out] uint[] pThreadIds);*/
            uint pcThreadIds;
            uint[] pThreadIds = default(uint[]);
            HRESULT hr = Raw2.EnumerateThreadIDs(cThreadIds, out pcThreadIds, pThreadIds);

            if (hr == HRESULT.S_OK)
                result = new EnumerateThreadIDsResult(pcThreadIds, pThreadIds);
            else
                result = default(EnumerateThreadIDsResult);

            return hr;
        }

        #endregion
        #region CreateVirtualUnwinder

        /// <summary>
        /// Creates a new stack unwinder that starts unwinding from an initial context (which isn't necessarily the leaf of a thread).
        /// </summary>
        /// <param name="nativeThreadID">[in] The native thread ID of the thread whose stack is to be unwound.</param>
        /// <param name="contextFlags">[in] Flags that specify which parts of the context are defined in initialContext.</param>
        /// <param name="cbContext">[in] The size of initialContext.</param>
        /// <param name="initialContext">[in] The data in the context.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugVirtualUnwinder"/> interface object.</returns>
        public CorDebugVirtualUnwinder CreateVirtualUnwinder(uint nativeThreadID, uint contextFlags, uint cbContext, IntPtr initialContext)
        {
            HRESULT hr;
            CorDebugVirtualUnwinder ppUnwinderResult;

            if ((hr = TryCreateVirtualUnwinder(nativeThreadID, contextFlags, cbContext, initialContext, out ppUnwinderResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppUnwinderResult;
        }

        /// <summary>
        /// Creates a new stack unwinder that starts unwinding from an initial context (which isn't necessarily the leaf of a thread).
        /// </summary>
        /// <param name="nativeThreadID">[in] The native thread ID of the thread whose stack is to be unwound.</param>
        /// <param name="contextFlags">[in] Flags that specify which parts of the context are defined in initialContext.</param>
        /// <param name="cbContext">[in] The size of initialContext.</param>
        /// <param name="initialContext">[in] The data in the context.</param>
        /// <param name="ppUnwinderResult">[out] A pointer to the address of an <see cref="ICorDebugVirtualUnwinder"/> interface object.</param>
        /// <returns>S_OK if successful. Any other <see cref="HRESULT"/> indicates failure. Any failing <see cref="HRESULT"/> received by mscordbi is considered fatal and causes <see cref="ICorDebug"/> methods to return CORDBG_E_DATA_TARGET_ERROR.</returns>
        public HRESULT TryCreateVirtualUnwinder(uint nativeThreadID, uint contextFlags, uint cbContext, IntPtr initialContext, out CorDebugVirtualUnwinder ppUnwinderResult)
        {
            /*HRESULT CreateVirtualUnwinder(
            [In] uint nativeThreadID,
            [In] uint contextFlags,
            [In] uint cbContext,
            [In] IntPtr initialContext,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugVirtualUnwinder ppUnwinder);*/
            ICorDebugVirtualUnwinder ppUnwinder;
            HRESULT hr = Raw2.CreateVirtualUnwinder(nativeThreadID, contextFlags, cbContext, initialContext, out ppUnwinder);

            if (hr == HRESULT.S_OK)
                ppUnwinderResult = new CorDebugVirtualUnwinder(ppUnwinder);
            else
                ppUnwinderResult = default(CorDebugVirtualUnwinder);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugDataTarget3

        public ICorDebugDataTarget3 Raw3 => (ICorDebugDataTarget3) Raw;

        #region GetLoadedModules

        /// <summary>
        /// Gets a list of the modules that have been loaded so far.
        /// </summary>
        /// <param name="cRequestedModules">[in] The number of modules for which information is requested.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetLoadedModulesResult GetLoadedModules(uint cRequestedModules)
        {
            HRESULT hr;
            GetLoadedModulesResult result;

            if ((hr = TryGetLoadedModules(cRequestedModules, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a list of the modules that have been loaded so far.
        /// </summary>
        /// <param name="cRequestedModules">[in] The number of modules for which information is requested.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetLoadedModules(uint cRequestedModules, out GetLoadedModulesResult result)
        {
            /*HRESULT GetLoadedModules(
            [In] uint cRequestedModules,
            out uint pcFetchedModules,
            [Out] IntPtr pLoadedModules);*/
            uint pcFetchedModules;
            IntPtr pLoadedModules = default(IntPtr);
            HRESULT hr = Raw3.GetLoadedModules(cRequestedModules, out pcFetchedModules, pLoadedModules);

            if (hr == HRESULT.S_OK)
                result = new GetLoadedModulesResult(pcFetchedModules, pLoadedModules);
            else
                result = default(GetLoadedModulesResult);

            return hr;
        }

        #endregion
        #endregion
    }
}