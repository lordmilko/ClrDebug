using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ClrDebug
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

            throw new NotImplementedException("Encountered an 'ICorDebugDataTarget' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugDataTarget"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected CorDebugDataTarget(ICorDebugDataTarget raw) : base(raw)
        {
        }

        #region ICorDebugDataTarget
        #region Platform

        /// <summary>
        /// Provides information about the platform, including processor architecture and operating system, on which the target process is running.
        /// </summary>
        public CorDebugPlatform Platform
        {
            get
            {
                CorDebugPlatform pTargetPlatform;
                TryGetPlatform(out pTargetPlatform).ThrowOnNotOK();

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
            /*HRESULT GetPlatform([Out] out CorDebugPlatform pTargetPlatform);*/
            return Raw.GetPlatform(out pTargetPlatform);
        }

        #endregion
        #region ReadVirtual

        /// <summary>
        /// Gets a block of contiguous memory starting at the specified address, and returns it in the supplied buffer.
        /// </summary>
        /// <param name="address">[in] The start address of requested memory.</param>
        /// <param name="pBuffer">[out] The buffer where the memory will be stored.</param>
        /// <param name="bytesRequested">[in] The number of bytes to get from the target address.</param>
        /// <returns>[out] The number of bytes actually read from the target address. This can be fewer than bytesRequested.</returns>
        /// <remarks>
        /// If the first byte (at the specified start address) can be read, the call should return success (to support efficient
        /// reading of data structures with self-describing length, like null-terminated strings).
        /// </remarks>
        public int ReadVirtual(CORDB_ADDRESS address, IntPtr pBuffer, int bytesRequested)
        {
            int pBytesRead;
            TryReadVirtual(address, pBuffer, bytesRequested, out pBytesRead).ThrowOnNotOK();

            return pBytesRead;
        }

        /// <summary>
        /// Gets a block of contiguous memory starting at the specified address, and returns it in the supplied buffer.
        /// </summary>
        /// <param name="address">[in] The start address of requested memory.</param>
        /// <param name="pBuffer">[out] The buffer where the memory will be stored.</param>
        /// <param name="bytesRequested">[in] The number of bytes to get from the target address.</param>
        /// <param name="pBytesRead">[out] The number of bytes actually read from the target address. This can be fewer than bytesRequested.</param>
        /// <remarks>
        /// If the first byte (at the specified start address) can be read, the call should return success (to support efficient
        /// reading of data structures with self-describing length, like null-terminated strings).
        /// </remarks>
        public HRESULT TryReadVirtual(CORDB_ADDRESS address, IntPtr pBuffer, int bytesRequested, out int pBytesRead)
        {
            /*HRESULT ReadVirtual([In] CORDB_ADDRESS address, [Out] IntPtr pBuffer, [In] int bytesRequested, [Out] out int pBytesRead);*/
            return Raw.ReadVirtual(address, pBuffer, bytesRequested, out pBytesRead);
        }

        #endregion
        #region GetThreadContext

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
        public void GetThreadContext(int dwThreadId, ContextFlags contextFlags, int contextSize, IntPtr pContext)
        {
            TryGetThreadContext(dwThreadId, contextFlags, contextSize, pContext).ThrowOnNotOK();
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
        public HRESULT TryGetThreadContext(int dwThreadId, ContextFlags contextFlags, int contextSize, IntPtr pContext)
        {
            /*HRESULT GetThreadContext([In] int dwThreadId, [In] ContextFlags contextFlags, [In] int contextSize, [Out] IntPtr pContext);*/
            return Raw.GetThreadContext(dwThreadId, contextFlags, contextSize, pContext);
        }

        #endregion
        #endregion
        #region ICorDebugDataTarget2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugDataTarget2 Raw2 => (ICorDebugDataTarget2) Raw;

        #region GetImageFromPointer

        /// <summary>
        /// Returns the module base address and size from an address in that module.
        /// </summary>
        /// <param name="addr">A <see cref="CORDB_ADDRESS"/> value that represents an address in a module.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetImageFromPointerResult GetImageFromPointer(CORDB_ADDRESS addr)
        {
            GetImageFromPointerResult result;
            TryGetImageFromPointer(addr, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Returns the module base address and size from an address in that module.
        /// </summary>
        /// <param name="addr">A <see cref="CORDB_ADDRESS"/> value that represents an address in a module.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetImageFromPointer(CORDB_ADDRESS addr, out GetImageFromPointerResult result)
        {
            /*HRESULT GetImageFromPointer([In] CORDB_ADDRESS addr, [Out] out CORDB_ADDRESS pImageBase, [Out] out int pSize);*/
            CORDB_ADDRESS pImageBase;
            int pSize;
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
            string szNameResult;
            TryGetImageLocation(baseAddress, out szNameResult).ThrowOnNotOK();

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
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName;
            HRESULT hr = Raw2.GetImageLocation(baseAddress, cchName, out pcchName, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(cchName);
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
            CorDebugSymbolProvider ppSymProviderResult;
            TryGetSymbolProviderForImage(imageBaseAddress, out ppSymProviderResult).ThrowOnNotOK();

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
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugSymbolProvider ppSymProvider);*/
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
        /// <returns>An array of thread identifiers.</returns>
        public int[] EnumerateThreadIDs()
        {
            int[] pThreadIds;
            TryEnumerateThreadIDs(out pThreadIds).ThrowOnNotOK();

            return pThreadIds;
        }

        /// <summary>
        /// Returns a list of active thread IDs.
        /// </summary>
        /// <param name="pThreadIds">An array of thread identifiers.</param>
        public HRESULT TryEnumerateThreadIDs(out int[] pThreadIds)
        {
            /*HRESULT EnumerateThreadIDs([In] int cThreadIds, [Out] out int pcThreadIds, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] pThreadIds);*/
            int cThreadIds = 0;
            int pcThreadIds;
            pThreadIds = null;
            HRESULT hr = Raw2.EnumerateThreadIDs(cThreadIds, out pcThreadIds, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cThreadIds = pcThreadIds;
            pThreadIds = new int[cThreadIds];
            hr = Raw2.EnumerateThreadIDs(cThreadIds, out pcThreadIds, pThreadIds);
            fail:
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
        public CorDebugVirtualUnwinder CreateVirtualUnwinder(int nativeThreadID, ContextFlags contextFlags, int cbContext, IntPtr initialContext)
        {
            CorDebugVirtualUnwinder ppUnwinderResult;
            TryCreateVirtualUnwinder(nativeThreadID, contextFlags, cbContext, initialContext, out ppUnwinderResult).ThrowOnNotOK();

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
        public HRESULT TryCreateVirtualUnwinder(int nativeThreadID, ContextFlags contextFlags, int cbContext, IntPtr initialContext, out CorDebugVirtualUnwinder ppUnwinderResult)
        {
            /*HRESULT CreateVirtualUnwinder(
            [In] int nativeThreadID,
            [In] ContextFlags contextFlags,
            [In] int cbContext,
            [In] IntPtr initialContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugVirtualUnwinder ppUnwinder);*/
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugDataTarget3 Raw3 => (ICorDebugDataTarget3) Raw;

        #region LoadedModules

        /// <summary>
        /// Gets a list of the modules that have been loaded so far.
        /// </summary>
        public CorDebugLoadedModule[] LoadedModules
        {
            get
            {
                CorDebugLoadedModule[] pLoadedModulesResult;
                TryGetLoadedModules(out pLoadedModulesResult).ThrowOnNotOK();

                return pLoadedModulesResult;
            }
        }

        /// <summary>
        /// Gets a list of the modules that have been loaded so far.
        /// </summary>
        /// <param name="pLoadedModulesResult">[out] A pointer to an array of <see cref="ICorDebugLoadedModule"/> objects that provide information about loaded modules.</param>
        public HRESULT TryGetLoadedModules(out CorDebugLoadedModule[] pLoadedModulesResult)
        {
            /*HRESULT GetLoadedModules(
            [In] int cRequestedModules,
            [Out] out int pcFetchedModules,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ICorDebugLoadedModule[] pLoadedModules);*/
            int cRequestedModules = 0;
            int pcFetchedModules;
            ICorDebugLoadedModule[] pLoadedModules;
            HRESULT hr = Raw3.GetLoadedModules(cRequestedModules, out pcFetchedModules, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cRequestedModules = pcFetchedModules;
            pLoadedModules = new ICorDebugLoadedModule[cRequestedModules];
            hr = Raw3.GetLoadedModules(cRequestedModules, out pcFetchedModules, pLoadedModules);

            if (hr == HRESULT.S_OK)
            {
                pLoadedModulesResult = pLoadedModules.Select(v => new CorDebugLoadedModule(v)).ToArray();

                return hr;
            }

            fail:
            pLoadedModulesResult = default(CorDebugLoadedModule[]);

            return hr;
        }

        #endregion
        #endregion
    }
}
