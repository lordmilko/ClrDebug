using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
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

        public HRESULT TryGetPlatform(out CorDebugPlatform pTargetPlatform)
        {
            /*HRESULT GetPlatform(out CorDebugPlatform pTargetPlatform);*/
            return Raw.GetPlatform(out pTargetPlatform);
        }

        #endregion
        #region ReadVirtual

        public CorDebugDataTarget_ReadVirtualResult ReadVirtual(ulong address, uint bytesRequested)
        {
            HRESULT hr;
            CorDebugDataTarget_ReadVirtualResult result;

            if ((hr = TryReadVirtual(address, bytesRequested, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public byte GetThreadContext(uint dwThreadId, uint contextFlags, uint contextSize)
        {
            HRESULT hr;
            byte pContext;

            if ((hr = TryGetThreadContext(dwThreadId, contextFlags, contextSize, out pContext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pContext;
        }

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

        public GetImageFromPointerResult GetImageFromPointer(CORDB_ADDRESS addr)
        {
            HRESULT hr;
            GetImageFromPointerResult result;

            if ((hr = TryGetImageFromPointer(addr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public string GetImageLocation(CORDB_ADDRESS baseAddress)
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetImageLocation(baseAddress, out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

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

        public CorDebugSymbolProvider GetSymbolProviderForImage(CORDB_ADDRESS imageBaseAddress)
        {
            HRESULT hr;
            CorDebugSymbolProvider ppSymProviderResult;

            if ((hr = TryGetSymbolProviderForImage(imageBaseAddress, out ppSymProviderResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppSymProviderResult;
        }

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

        public EnumerateThreadIDsResult EnumerateThreadIDs(uint cThreadIds)
        {
            HRESULT hr;
            EnumerateThreadIDsResult result;

            if ((hr = TryEnumerateThreadIDs(cThreadIds, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public CorDebugVirtualUnwinder CreateVirtualUnwinder(uint nativeThreadID, uint contextFlags, uint cbContext, IntPtr initialContext)
        {
            HRESULT hr;
            CorDebugVirtualUnwinder ppUnwinderResult;

            if ((hr = TryCreateVirtualUnwinder(nativeThreadID, contextFlags, cbContext, initialContext, out ppUnwinderResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppUnwinderResult;
        }

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

        public GetLoadedModulesResult GetLoadedModules(uint cRequestedModules)
        {
            HRESULT hr;
            GetLoadedModulesResult result;

            if ((hr = TryGetLoadedModules(cRequestedModules, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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