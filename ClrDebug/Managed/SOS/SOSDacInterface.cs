using System;
using System.Diagnostics;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    /// <summary>
    /// Provides helper methods to access data from SOS.
    /// </summary>
    /// <remarks>
    /// This interface lives inside the runtime and is not exposed through any headers or library files. However, it's
    /// a COM interface that derives from IUnknown with GUID 436f00f2-b42a-4b9f-870c-e73db66ae930 that can be obtained
    /// through the usual COM mechanisms.
    /// </remarks>
    public class SOSDacInterface : ComObject<ISOSDacInterface>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SOSDacInterface"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SOSDacInterface(ISOSDacInterface raw) : base(raw)
        {
        }

        #region ISOSDacInterface
        #region ThreadStoreData

        public DacpThreadStoreData ThreadStoreData
        {
            get
            {
                DacpThreadStoreData data;
                TryGetThreadStoreData(out data).ThrowOnNotOK();

                return data;
            }
        }

        public HRESULT TryGetThreadStoreData(out DacpThreadStoreData data)
        {
            /*HRESULT GetThreadStoreData(
            [Out] out DacpThreadStoreData data);*/
            return Raw.GetThreadStoreData(out data);
        }

        #endregion
        #region AppDomainStoreData

        public DacpAppDomainStoreData AppDomainStoreData
        {
            get
            {
                DacpAppDomainStoreData data;
                TryGetAppDomainStoreData(out data).ThrowOnNotOK();

                return data;
            }
        }

        public HRESULT TryGetAppDomainStoreData(out DacpAppDomainStoreData data)
        {
            /*HRESULT GetAppDomainStoreData(
            [Out] out DacpAppDomainStoreData data);*/
            return Raw.GetAppDomainStoreData(out data);
        }

        #endregion
        #region JitManagerList

        public DacpJitManagerInfo[] JitManagerList
        {
            get
            {
                DacpJitManagerInfo[] managers;
                TryGetJitManagerList(out managers).ThrowOnNotOK();

                return managers;
            }
        }

        public HRESULT TryGetJitManagerList(out DacpJitManagerInfo[] managers)
        {
            /*HRESULT GetJitManagerList(
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DacpJitManagerInfo[] managers,
            [Out] out int pNeeded);*/
            int count = 0;
            managers = null;
            int pNeeded;
            HRESULT hr = Raw.GetJitManagerList(count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            managers = new DacpJitManagerInfo[count];
            hr = Raw.GetJitManagerList(count, managers, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region ThreadpoolData

        public DacpThreadpoolData ThreadpoolData
        {
            get
            {
                DacpThreadpoolData data;
                TryGetThreadpoolData(out data).ThrowOnNotOK();

                return data;
            }
        }

        public HRESULT TryGetThreadpoolData(out DacpThreadpoolData data)
        {
            /*HRESULT GetThreadpoolData(
            [Out] out DacpThreadpoolData data);*/
            return Raw.GetThreadpoolData(out data);
        }

        #endregion
        #region GCHeapData

        public DacpGcHeapData GCHeapData
        {
            get
            {
                DacpGcHeapData data;
                TryGetGCHeapData(out data).ThrowOnNotOK();

                return data;
            }
        }

        public HRESULT TryGetGCHeapData(out DacpGcHeapData data)
        {
            /*HRESULT GetGCHeapData(
            [Out] out DacpGcHeapData data);*/
            return Raw.GetGCHeapData(out data);
        }

        #endregion
        #region GCHeapList

        public CLRDATA_ADDRESS[] GCHeapList
        {
            get
            {
                CLRDATA_ADDRESS[] heaps;
                TryGetGCHeapList(out heaps).ThrowOnNotOK();

                return heaps;
            }
        }

        public HRESULT TryGetGCHeapList(out CLRDATA_ADDRESS[] heaps)
        {
            /*HRESULT GetGCHeapList(
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] CLRDATA_ADDRESS[] heaps,
            [Out] out int pNeeded);*/
            int count = 0;
            heaps = null;
            int pNeeded;
            HRESULT hr = Raw.GetGCHeapList(count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            heaps = new CLRDATA_ADDRESS[count];
            hr = Raw.GetGCHeapList(count, heaps, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region GCHeapStaticData

        public DacpGcHeapDetails GCHeapStaticData
        {
            get
            {
                DacpGcHeapDetails data;
                TryGetGCHeapStaticData(out data).ThrowOnNotOK();

                return data;
            }
        }

        public HRESULT TryGetGCHeapStaticData(out DacpGcHeapDetails data)
        {
            /*HRESULT GetGCHeapStaticData(
            [Out] out DacpGcHeapDetails data);*/
            return Raw.GetGCHeapStaticData(out data);
        }

        #endregion
        #region OOMStaticData

        public DacpOomData OOMStaticData
        {
            get
            {
                DacpOomData data;
                TryGetOOMStaticData(out data).ThrowOnNotOK();

                return data;
            }
        }

        public HRESULT TryGetOOMStaticData(out DacpOomData data)
        {
            /*HRESULT GetOOMStaticData(
            [Out] out DacpOomData data);*/
            return Raw.GetOOMStaticData(out data);
        }

        #endregion
        #region HeapAnalyzeStaticData

        public DacpGcHeapAnalyzeData HeapAnalyzeStaticData
        {
            get
            {
                DacpGcHeapAnalyzeData data;
                TryGetHeapAnalyzeStaticData(out data).ThrowOnNotOK();

                return data;
            }
        }

        public HRESULT TryGetHeapAnalyzeStaticData(out DacpGcHeapAnalyzeData data)
        {
            /*HRESULT GetHeapAnalyzeStaticData(
            [Out] out DacpGcHeapAnalyzeData data);*/
            return Raw.GetHeapAnalyzeStaticData(out data);
        }

        #endregion
        #region HandleEnum

        public SOSHandleEnum HandleEnum
        {
            get
            {
                SOSHandleEnum ppHandleEnumResult;
                TryGetHandleEnum(out ppHandleEnumResult).ThrowOnNotOK();

                return ppHandleEnumResult;
            }
        }

        public HRESULT TryGetHandleEnum(out SOSHandleEnum ppHandleEnumResult)
        {
            /*HRESULT GetHandleEnum(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSHandleEnum ppHandleEnum);*/
            ISOSHandleEnum ppHandleEnum;
            HRESULT hr = Raw.GetHandleEnum(out ppHandleEnum);

            if (hr == HRESULT.S_OK)
                ppHandleEnumResult = ppHandleEnum == null ? null : new SOSHandleEnum(ppHandleEnum);
            else
                ppHandleEnumResult = default(SOSHandleEnum);

            return hr;
        }

        #endregion
        #region StressLogAddress

        public CLRDATA_ADDRESS StressLogAddress
        {
            get
            {
                CLRDATA_ADDRESS stressLog;
                TryGetStressLogAddress(out stressLog).ThrowOnNotOK();

                return stressLog;
            }
        }

        public HRESULT TryGetStressLogAddress(out CLRDATA_ADDRESS stressLog)
        {
            /*HRESULT GetStressLogAddress(
            [Out] out CLRDATA_ADDRESS stressLog);*/
            return Raw.GetStressLogAddress(out stressLog);
        }

        #endregion
        #region UsefulGlobals

        public DacpUsefulGlobalsData UsefulGlobals
        {
            get
            {
                DacpUsefulGlobalsData data;
                TryGetUsefulGlobals(out data).ThrowOnNotOK();

                return data;
            }
        }

        public HRESULT TryGetUsefulGlobals(out DacpUsefulGlobalsData data)
        {
            /*HRESULT GetUsefulGlobals(
            [Out] out DacpUsefulGlobalsData data);*/
            return Raw.GetUsefulGlobals(out data);
        }

        #endregion
        #region TLSIndex

        public int TLSIndex
        {
            get
            {
                int pIndex;
                TryGetTLSIndex(out pIndex).ThrowOnNotOK();

                return pIndex;
            }
        }

        public HRESULT TryGetTLSIndex(out int pIndex)
        {
            /*HRESULT GetTLSIndex(
            [Out] out int pIndex);*/
            return Raw.GetTLSIndex(out pIndex);
        }

        #endregion
        #region DacModuleHandle

        public IntPtr DacModuleHandle
        {
            get
            {
                IntPtr phModule;
                TryGetDacModuleHandle(out phModule).ThrowOnNotOK();

                return phModule;
            }
        }

        public HRESULT TryGetDacModuleHandle(out IntPtr phModule)
        {
            /*HRESULT GetDacModuleHandle(
            [Out] out IntPtr phModule);*/
            return Raw.GetDacModuleHandle(out phModule);
        }

        #endregion
        #region GetAppDomainList

        /// <summary>
        /// Gets the addresses of all AppDomains present in a process, excluding the System and Shared AppDomains.
        /// </summary>
        /// <param name="count">The size of the values array. The number of active AppDomains can be retrieved from <see cref="AppDomainStoreData"/>.</param>
        /// <returns>The array to store the addresses of returned AppDomains.</returns>
        public CLRDATA_ADDRESS[] GetAppDomainList(int count)
        {
            CLRDATA_ADDRESS[] values;
            TryGetAppDomainList(count, out values).ThrowOnNotOK();

            return values;
        }

        /// <summary>
        /// Gets the addresses of all AppDomains present in a process, excluding the System and Shared AppDomains.
        /// </summary>
        /// <param name="count">The size of the values array. The number of active AppDomains can be retrieved from <see cref="AppDomainStoreData"/>.</param>
        /// <param name="values">The array to store the addresses of returned AppDomains.</param>
        /// <returns>A HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetAppDomainList(int count, out CLRDATA_ADDRESS[] values)
        {
            /*HRESULT GetAppDomainList(
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] CLRDATA_ADDRESS[] values,
            [Out] out int pNeeded);*/
            values = new CLRDATA_ADDRESS[count];
            int pNeeded;
            HRESULT hr = Raw.GetAppDomainList(count, values, out pNeeded);

            if (count != pNeeded)
                Array.Resize(ref values, pNeeded);

            return hr;
        }

        #endregion
        #region GetAppDomainData

        public DacpAppDomainData GetAppDomainData(CLRDATA_ADDRESS addr)
        {
            DacpAppDomainData data;
            TryGetAppDomainData(addr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetAppDomainData(CLRDATA_ADDRESS addr, out DacpAppDomainData data)
        {
            /*HRESULT GetAppDomainData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpAppDomainData data);*/
            return Raw.GetAppDomainData(addr, out data);
        }

        #endregion
        #region GetAppDomainName

        public string GetAppDomainName(CLRDATA_ADDRESS addr)
        {
            string nameResult;
            TryGetAppDomainName(addr, out nameResult).ThrowOnNotOK();

            return nameResult;
        }

        public HRESULT TryGetAppDomainName(CLRDATA_ADDRESS addr, out string nameResult)
        {
            /*HRESULT GetAppDomainName(
            [In] CLRDATA_ADDRESS addr,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] name,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] name;
            int pNeeded;
            HRESULT hr = Raw.GetAppDomainName(addr, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            name = new char[count];
            hr = Raw.GetAppDomainName(addr, count, name, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                nameResult = CreateString(name, pNeeded);

                return hr;
            }

            fail:
            nameResult = default(string);

            return hr;
        }

        #endregion
        #region GetDomainFromContext

        public CLRDATA_ADDRESS GetDomainFromContext(CLRDATA_ADDRESS context)
        {
            CLRDATA_ADDRESS domain;
            TryGetDomainFromContext(context, out domain).ThrowOnNotOK();

            return domain;
        }

        public HRESULT TryGetDomainFromContext(CLRDATA_ADDRESS context, out CLRDATA_ADDRESS domain)
        {
            /*HRESULT GetDomainFromContext(
            [In] CLRDATA_ADDRESS context,
            [Out] out CLRDATA_ADDRESS domain);*/
            return Raw.GetDomainFromContext(context, out domain);
        }

        #endregion
        #region GetAssemblyList

        public CLRDATA_ADDRESS[] GetAssemblyList(CLRDATA_ADDRESS appDomain)
        {
            CLRDATA_ADDRESS[] values;
            TryGetAssemblyList(appDomain, out values).ThrowOnNotOK();

            return values;
        }

        public HRESULT TryGetAssemblyList(CLRDATA_ADDRESS appDomain, out CLRDATA_ADDRESS[] values)
        {
            /*HRESULT GetAssemblyList(
            [In] CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] values,
            [Out] out int pNeeded);*/
            int count = 0;
            values = null;
            int pNeeded;
            HRESULT hr = Raw.GetAssemblyList(appDomain, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            values = new CLRDATA_ADDRESS[count];
            hr = Raw.GetAssemblyList(appDomain, count, values, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region GetAssemblyData

        public DacpAssemblyData GetAssemblyData(CLRDATA_ADDRESS baseDomainPtr, CLRDATA_ADDRESS assembly)
        {
            DacpAssemblyData data;
            TryGetAssemblyData(baseDomainPtr, assembly, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetAssemblyData(CLRDATA_ADDRESS baseDomainPtr, CLRDATA_ADDRESS assembly, out DacpAssemblyData data)
        {
            /*HRESULT GetAssemblyData(
            [In] CLRDATA_ADDRESS baseDomainPtr,
            [In] CLRDATA_ADDRESS assembly,
            [Out] out DacpAssemblyData data);*/
            return Raw.GetAssemblyData(baseDomainPtr, assembly, out data);
        }

        #endregion
        #region GetAssemblyName

        public string GetAssemblyName(CLRDATA_ADDRESS assembly)
        {
            string nameResult;
            TryGetAssemblyName(assembly, out nameResult).ThrowOnNotOK();

            return nameResult;
        }

        public HRESULT TryGetAssemblyName(CLRDATA_ADDRESS assembly, out string nameResult)
        {
            /*HRESULT GetAssemblyName(
            [In] CLRDATA_ADDRESS assembly,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] name,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] name;
            int pNeeded;
            HRESULT hr = Raw.GetAssemblyName(assembly, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            name = new char[count];
            hr = Raw.GetAssemblyName(assembly, count, name, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                nameResult = CreateString(name, pNeeded);

                return hr;
            }

            fail:
            nameResult = default(string);

            return hr;
        }

        #endregion
        #region GetModule

        public XCLRDataModule GetModule(CLRDATA_ADDRESS addr)
        {
            XCLRDataModule modResult;
            TryGetModule(addr, out modResult).ThrowOnNotOK();

            return modResult;
        }

        public HRESULT TryGetModule(CLRDATA_ADDRESS addr, out XCLRDataModule modResult)
        {
            /*HRESULT GetModule(
            [In] CLRDATA_ADDRESS addr,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule mod);*/
            IXCLRDataModule mod;
            HRESULT hr = Raw.GetModule(addr, out mod);

            if (hr == HRESULT.S_OK)
                modResult = mod == null ? null : new XCLRDataModule(mod);
            else
                modResult = default(XCLRDataModule);

            return hr;
        }

        #endregion
        #region GetModuleData

        /// <summary>
        /// Fetches the data corresponding to the module loaded at a given address.
        /// </summary>
        /// <param name="moduleAddr">[in] The address of the module to retrieve information for.</param>
        /// <returns>[out] The <see cref="DacpModuleData"/> to hold the information of the loaded module.</returns>
        /// <remarks>
        /// The provided method is part of the ISOSDacInterface interface and corresponds to the 14th slot of the virtual method
        /// table.
        /// </remarks>
        public DacpModuleData GetModuleData(CLRDATA_ADDRESS moduleAddr)
        {
            DacpModuleData data;
            TryGetModuleData(moduleAddr, out data).ThrowOnNotOK();

            return data;
        }

        /// <summary>
        /// Fetches the data corresponding to the module loaded at a given address.
        /// </summary>
        /// <param name="moduleAddr">[in] The address of the module to retrieve information for.</param>
        /// <param name="data">[out] The <see cref="DacpModuleData"/> to hold the information of the loaded module.</param>
        /// <remarks>
        /// The provided method is part of the ISOSDacInterface interface and corresponds to the 14th slot of the virtual method
        /// table.
        /// </remarks>
        public HRESULT TryGetModuleData(CLRDATA_ADDRESS moduleAddr, out DacpModuleData data)
        {
            /*HRESULT GetModuleData(
            [In] CLRDATA_ADDRESS moduleAddr,
            [Out] out DacpModuleData data);*/
            return Raw.GetModuleData(moduleAddr, out data);
        }

        #endregion
        #region TraverseModuleMap

        public void TraverseModuleMap(ModuleMapType mmt, CLRDATA_ADDRESS moduleAddr, MODULEMAPTRAVERSE pCallback, IntPtr token)
        {
            TryTraverseModuleMap(mmt, moduleAddr, pCallback, token).ThrowOnNotOK();
        }

        public HRESULT TryTraverseModuleMap(ModuleMapType mmt, CLRDATA_ADDRESS moduleAddr, MODULEMAPTRAVERSE pCallback, IntPtr token)
        {
            /*HRESULT TraverseModuleMap(
            [In] ModuleMapType mmt,
            [In] CLRDATA_ADDRESS moduleAddr,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] MODULEMAPTRAVERSE pCallback,
            [In] IntPtr token);*/
            return Raw.TraverseModuleMap(mmt, moduleAddr, pCallback, token);
        }

        #endregion
        #region GetAssemblyModuleList

        public CLRDATA_ADDRESS[] GetAssemblyModuleList(CLRDATA_ADDRESS assembly)
        {
            CLRDATA_ADDRESS[] modules;
            TryGetAssemblyModuleList(assembly, out modules).ThrowOnNotOK();

            return modules;
        }

        public HRESULT TryGetAssemblyModuleList(CLRDATA_ADDRESS assembly, out CLRDATA_ADDRESS[] modules)
        {
            /*HRESULT GetAssemblyModuleList(
            [In] CLRDATA_ADDRESS assembly,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] modules,
            [Out] out int pNeeded);*/
            int count = 0;
            modules = null;
            int pNeeded;
            HRESULT hr = Raw.GetAssemblyModuleList(assembly, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            modules = new CLRDATA_ADDRESS[count];
            hr = Raw.GetAssemblyModuleList(assembly, count, modules, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region GetILForModule

        public CLRDATA_ADDRESS GetILForModule(CLRDATA_ADDRESS moduleAddr, int rva)
        {
            CLRDATA_ADDRESS il;
            TryGetILForModule(moduleAddr, rva, out il).ThrowOnNotOK();

            return il;
        }

        public HRESULT TryGetILForModule(CLRDATA_ADDRESS moduleAddr, int rva, out CLRDATA_ADDRESS il)
        {
            /*HRESULT GetILForModule(
            [In] CLRDATA_ADDRESS moduleAddr,
            [In] int rva,
            [Out] out CLRDATA_ADDRESS il);*/
            return Raw.GetILForModule(moduleAddr, rva, out il);
        }

        #endregion
        #region GetThreadData

        public DacpThreadData GetThreadData(CLRDATA_ADDRESS thread)
        {
            DacpThreadData data;
            TryGetThreadData(thread, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetThreadData(CLRDATA_ADDRESS thread, out DacpThreadData data)
        {
            /*HRESULT GetThreadData(
            [In] CLRDATA_ADDRESS thread,
            [Out] out DacpThreadData data);*/
            return Raw.GetThreadData(thread, out data);
        }

        #endregion
        #region GetThreadFromThinlockID

        public CLRDATA_ADDRESS GetThreadFromThinlockID(int thinLockId)
        {
            CLRDATA_ADDRESS pThread;
            TryGetThreadFromThinlockID(thinLockId, out pThread).ThrowOnNotOK();

            return pThread;
        }

        public HRESULT TryGetThreadFromThinlockID(int thinLockId, out CLRDATA_ADDRESS pThread)
        {
            /*HRESULT GetThreadFromThinlockID(
            [In] int thinLockId,
            [Out] out CLRDATA_ADDRESS pThread);*/
            return Raw.GetThreadFromThinlockID(thinLockId, out pThread);
        }

        #endregion
        #region GetStackLimits

        public GetStackLimitsResult GetStackLimits(CLRDATA_ADDRESS threadPtr)
        {
            GetStackLimitsResult result;
            TryGetStackLimits(threadPtr, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetStackLimits(CLRDATA_ADDRESS threadPtr, out GetStackLimitsResult result)
        {
            /*HRESULT GetStackLimits(
            [In] CLRDATA_ADDRESS threadPtr,
            [Out] out CLRDATA_ADDRESS lower,
            [Out] out CLRDATA_ADDRESS upper,
            [Out] out CLRDATA_ADDRESS fp);*/
            CLRDATA_ADDRESS lower;
            CLRDATA_ADDRESS upper;
            CLRDATA_ADDRESS fp;
            HRESULT hr = Raw.GetStackLimits(threadPtr, out lower, out upper, out fp);

            if (hr == HRESULT.S_OK)
                result = new GetStackLimitsResult(lower, upper, fp);
            else
                result = default(GetStackLimitsResult);

            return hr;
        }

        #endregion
        #region GetMethodDescData

        /// <summary>
        /// Gets the data for the given MethodDesc pointer.
        /// </summary>
        /// <param name="methodDesc">[in] The address of the MethodDesc.</param>
        /// <param name="ip">[in] The IP address of the method.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The provided method is part of the ISOSDacInterface interface and corresponds to the 21st slot of the virtual method
        /// table. To be able to use them, Markdig.Syntax.Inlines.CodeInline must be defined as a 64-bit unsigned integer.
        /// </remarks>
        public GetMethodDescDataResult GetMethodDescData(CLRDATA_ADDRESS methodDesc, CLRDATA_ADDRESS ip)
        {
            GetMethodDescDataResult result;
            TryGetMethodDescData(methodDesc, ip, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the data for the given MethodDesc pointer.
        /// </summary>
        /// <param name="methodDesc">[in] The address of the MethodDesc.</param>
        /// <param name="ip">[in] The IP address of the method.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The provided method is part of the ISOSDacInterface interface and corresponds to the 21st slot of the virtual method
        /// table. To be able to use them, Markdig.Syntax.Inlines.CodeInline must be defined as a 64-bit unsigned integer.
        /// </remarks>
        public HRESULT TryGetMethodDescData(CLRDATA_ADDRESS methodDesc, CLRDATA_ADDRESS ip, out GetMethodDescDataResult result)
        {
            /*HRESULT GetMethodDescData(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] CLRDATA_ADDRESS ip,
            [Out] out DacpMethodDescData data,
            [In] int cRevertedRejitVersions,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DacpReJitData[] rgRevertedRejitData,
            [Out] out int pcNeededRevertedRejitData);*/
            DacpMethodDescData data;
            int cRevertedRejitVersions = 0;
            DacpReJitData[] rgRevertedRejitData;
            int pcNeededRevertedRejitData;
            HRESULT hr = Raw.GetMethodDescData(methodDesc, ip, out data, cRevertedRejitVersions, null, out pcNeededRevertedRejitData);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cRevertedRejitVersions = pcNeededRevertedRejitData;
            rgRevertedRejitData = new DacpReJitData[cRevertedRejitVersions];
            hr = Raw.GetMethodDescData(methodDesc, ip, out data, cRevertedRejitVersions, rgRevertedRejitData, out pcNeededRevertedRejitData);

            if (hr == HRESULT.S_OK)
            {
                result = new GetMethodDescDataResult(data, rgRevertedRejitData);

                return hr;
            }

            fail:
            result = default(GetMethodDescDataResult);

            return hr;
        }

        #endregion
        #region GetMethodDescPtrFromIP

        /// <summary>
        /// Retrieves the pointer of the MethodDesc corresponding the method containing the given native instruction address.
        /// </summary>
        /// <param name="ip">[in] An address within the method at run time.</param>
        /// <returns>[out] The address of the MethodDesc for the particular method.</returns>
        /// <remarks>
        /// The provided method is part of the <see cref="ISOSDacInterface"/> and corresponds to the 22nd slot of the virtual
        /// method table.
        /// </remarks>
        public CLRDATA_ADDRESS GetMethodDescPtrFromIP(CLRDATA_ADDRESS ip)
        {
            CLRDATA_ADDRESS ppMD;
            TryGetMethodDescPtrFromIP(ip, out ppMD).ThrowOnNotOK();

            return ppMD;
        }

        /// <summary>
        /// Retrieves the pointer of the MethodDesc corresponding the method containing the given native instruction address.
        /// </summary>
        /// <param name="ip">[in] An address within the method at run time.</param>
        /// <param name="ppMD">[out] The address of the MethodDesc for the particular method.</param>
        /// <remarks>
        /// The provided method is part of the <see cref="ISOSDacInterface"/> and corresponds to the 22nd slot of the virtual
        /// method table.
        /// </remarks>
        public HRESULT TryGetMethodDescPtrFromIP(CLRDATA_ADDRESS ip, out CLRDATA_ADDRESS ppMD)
        {
            /*HRESULT GetMethodDescPtrFromIP(
            [In] CLRDATA_ADDRESS ip,
            [Out] out CLRDATA_ADDRESS ppMD);*/
            return Raw.GetMethodDescPtrFromIP(ip, out ppMD);
        }

        #endregion
        #region GetMethodDescName

        public string GetMethodDescName(CLRDATA_ADDRESS methodDesc)
        {
            string nameResult;
            TryGetMethodDescName(methodDesc, out nameResult).ThrowOnNotOK();

            return nameResult;
        }

        public HRESULT TryGetMethodDescName(CLRDATA_ADDRESS methodDesc, out string nameResult)
        {
            /*HRESULT GetMethodDescName(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] name,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] name;
            int pNeeded;
            HRESULT hr = Raw.GetMethodDescName(methodDesc, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            name = new char[count];
            hr = Raw.GetMethodDescName(methodDesc, count, name, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                nameResult = CreateString(name, pNeeded);

                return hr;
            }

            fail:
            nameResult = default(string);

            return hr;
        }

        #endregion
        #region GetMethodDescPtrFromFrame

        public CLRDATA_ADDRESS GetMethodDescPtrFromFrame(CLRDATA_ADDRESS frameAddr)
        {
            CLRDATA_ADDRESS ppMD;
            TryGetMethodDescPtrFromFrame(frameAddr, out ppMD).ThrowOnNotOK();

            return ppMD;
        }

        public HRESULT TryGetMethodDescPtrFromFrame(CLRDATA_ADDRESS frameAddr, out CLRDATA_ADDRESS ppMD)
        {
            /*HRESULT GetMethodDescPtrFromFrame(
            [In] CLRDATA_ADDRESS frameAddr,
            [Out] out CLRDATA_ADDRESS ppMD);*/
            return Raw.GetMethodDescPtrFromFrame(frameAddr, out ppMD);
        }

        #endregion
        #region GetMethodDescFromToken

        public CLRDATA_ADDRESS GetMethodDescFromToken(CLRDATA_ADDRESS moduleAddr, mdToken token)
        {
            CLRDATA_ADDRESS methodDesc;
            TryGetMethodDescFromToken(moduleAddr, token, out methodDesc).ThrowOnNotOK();

            return methodDesc;
        }

        public HRESULT TryGetMethodDescFromToken(CLRDATA_ADDRESS moduleAddr, mdToken token, out CLRDATA_ADDRESS methodDesc)
        {
            /*HRESULT GetMethodDescFromToken(
            [In] CLRDATA_ADDRESS moduleAddr,
            [In] mdToken token,
            [Out] out CLRDATA_ADDRESS methodDesc);*/
            return Raw.GetMethodDescFromToken(moduleAddr, token, out methodDesc);
        }

        #endregion
        #region GetMethodDescTransparencyData

        public DacpMethodDescTransparencyData GetMethodDescTransparencyData(CLRDATA_ADDRESS methodDesc)
        {
            DacpMethodDescTransparencyData data;
            TryGetMethodDescTransparencyData(methodDesc, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetMethodDescTransparencyData(CLRDATA_ADDRESS methodDesc, out DacpMethodDescTransparencyData data)
        {
            /*HRESULT GetMethodDescTransparencyData(
            [In] CLRDATA_ADDRESS methodDesc,
            [Out] out DacpMethodDescTransparencyData data);*/
            return Raw.GetMethodDescTransparencyData(methodDesc, out data);
        }

        #endregion
        #region GetCodeHeaderData

        public DacpCodeHeaderData GetCodeHeaderData(CLRDATA_ADDRESS ip)
        {
            DacpCodeHeaderData data;
            TryGetCodeHeaderData(ip, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetCodeHeaderData(CLRDATA_ADDRESS ip, out DacpCodeHeaderData data)
        {
            /*HRESULT GetCodeHeaderData(
            [In] CLRDATA_ADDRESS ip,
            [Out] out DacpCodeHeaderData data);*/
            return Raw.GetCodeHeaderData(ip, out data);
        }

        #endregion
        #region GetJitHelperFunctionName

        public string GetJitHelperFunctionName(CLRDATA_ADDRESS ip)
        {
            string nameResult;
            TryGetJitHelperFunctionName(ip, out nameResult).ThrowOnNotOK();

            return nameResult;
        }

        public HRESULT TryGetJitHelperFunctionName(CLRDATA_ADDRESS ip, out string nameResult)
        {
            /*HRESULT GetJitHelperFunctionName(
            [In] CLRDATA_ADDRESS ip,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] name,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] name;
            int pNeeded;
            HRESULT hr = Raw.GetJitHelperFunctionName(ip, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            name = new char[count];
            hr = Raw.GetJitHelperFunctionName(ip, count, name, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                nameResult = CreateString(name, pNeeded);

                return hr;
            }

            fail:
            nameResult = default(string);

            return hr;
        }

        #endregion
        #region GetJumpThunkTarget

        public GetJumpThunkTargetResult GetJumpThunkTarget(IntPtr ctx)
        {
            GetJumpThunkTargetResult result;
            TryGetJumpThunkTarget(ctx, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetJumpThunkTarget(IntPtr ctx, out GetJumpThunkTargetResult result)
        {
            /*HRESULT GetJumpThunkTarget(
            [In] IntPtr ctx,
            [Out] out CLRDATA_ADDRESS targetIP,
            [Out] out CLRDATA_ADDRESS targetMD);*/
            CLRDATA_ADDRESS targetIP;
            CLRDATA_ADDRESS targetMD;
            HRESULT hr = Raw.GetJumpThunkTarget(ctx, out targetIP, out targetMD);

            if (hr == HRESULT.S_OK)
                result = new GetJumpThunkTargetResult(targetIP, targetMD);
            else
                result = default(GetJumpThunkTargetResult);

            return hr;
        }

        #endregion
        #region GetWorkRequestData

        public DacpWorkRequestData GetWorkRequestData(CLRDATA_ADDRESS addrWorkRequest)
        {
            DacpWorkRequestData data;
            TryGetWorkRequestData(addrWorkRequest, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetWorkRequestData(CLRDATA_ADDRESS addrWorkRequest, out DacpWorkRequestData data)
        {
            /*HRESULT GetWorkRequestData(
            [In] CLRDATA_ADDRESS addrWorkRequest,
            [Out] out DacpWorkRequestData data);*/
            return Raw.GetWorkRequestData(addrWorkRequest, out data);
        }

        #endregion
        #region GetHillClimbingLogEntry

        public DacpHillClimbingLogEntry GetHillClimbingLogEntry(CLRDATA_ADDRESS addr)
        {
            DacpHillClimbingLogEntry data;
            TryGetHillClimbingLogEntry(addr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetHillClimbingLogEntry(CLRDATA_ADDRESS addr, out DacpHillClimbingLogEntry data)
        {
            /*HRESULT GetHillClimbingLogEntry(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpHillClimbingLogEntry data);*/
            return Raw.GetHillClimbingLogEntry(addr, out data);
        }

        #endregion
        #region GetObjectData

        public DacpObjectData GetObjectData(CLRDATA_ADDRESS objAddr)
        {
            DacpObjectData data;
            TryGetObjectData(objAddr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetObjectData(CLRDATA_ADDRESS objAddr, out DacpObjectData data)
        {
            /*HRESULT GetObjectData(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out DacpObjectData data);*/
            return Raw.GetObjectData(objAddr, out data);
        }

        #endregion
        #region GetObjectStringData

        public string GetObjectStringData(CLRDATA_ADDRESS obj)
        {
            string stringDataResult;
            TryGetObjectStringData(obj, out stringDataResult).ThrowOnNotOK();

            return stringDataResult;
        }

        public HRESULT TryGetObjectStringData(CLRDATA_ADDRESS obj, out string stringDataResult)
        {
            /*HRESULT GetObjectStringData(
            [In] CLRDATA_ADDRESS obj,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] stringData,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] stringData;
            int pNeeded;
            HRESULT hr = Raw.GetObjectStringData(obj, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            stringData = new char[count];
            hr = Raw.GetObjectStringData(obj, count, stringData, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                stringDataResult = CreateString(stringData, pNeeded);

                return hr;
            }

            fail:
            stringDataResult = default(string);

            return hr;
        }

        #endregion
        #region GetObjectClassName

        public string GetObjectClassName(CLRDATA_ADDRESS obj)
        {
            string classNameResult;
            TryGetObjectClassName(obj, out classNameResult).ThrowOnNotOK();

            return classNameResult;
        }

        public HRESULT TryGetObjectClassName(CLRDATA_ADDRESS obj, out string classNameResult)
        {
            /*HRESULT GetObjectClassName(
            [In] CLRDATA_ADDRESS obj,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] className,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] className;
            int pNeeded;
            HRESULT hr = Raw.GetObjectClassName(obj, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            className = new char[count];
            hr = Raw.GetObjectClassName(obj, count, className, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                classNameResult = CreateString(className, pNeeded);

                return hr;
            }

            fail:
            classNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetMethodTableName

        public string GetMethodTableName(CLRDATA_ADDRESS mt)
        {
            string mtNameResult;
            TryGetMethodTableName(mt, out mtNameResult).ThrowOnNotOK();

            return mtNameResult;
        }

        public HRESULT TryGetMethodTableName(CLRDATA_ADDRESS mt, out string mtNameResult)
        {
            /*HRESULT GetMethodTableName(
            [In] CLRDATA_ADDRESS mt,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] mtName,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] mtName;
            int pNeeded;
            HRESULT hr = Raw.GetMethodTableName(mt, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            mtName = new char[count];
            hr = Raw.GetMethodTableName(mt, count, mtName, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                mtNameResult = CreateString(mtName, pNeeded);

                return hr;
            }

            fail:
            mtNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetMethodTableData

        public DacpMethodTableData GetMethodTableData(CLRDATA_ADDRESS mt)
        {
            DacpMethodTableData data;
            TryGetMethodTableData(mt, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetMethodTableData(CLRDATA_ADDRESS mt, out DacpMethodTableData data)
        {
            /*HRESULT GetMethodTableData(
            [In] CLRDATA_ADDRESS mt,
            [Out] out DacpMethodTableData data);*/
            return Raw.GetMethodTableData(mt, out data);
        }

        #endregion
        #region GetMethodTableSlot

        public CLRDATA_ADDRESS GetMethodTableSlot(CLRDATA_ADDRESS mt, int slot)
        {
            CLRDATA_ADDRESS value;
            TryGetMethodTableSlot(mt, slot, out value).ThrowOnNotOK();

            return value;
        }

        public HRESULT TryGetMethodTableSlot(CLRDATA_ADDRESS mt, int slot, out CLRDATA_ADDRESS value)
        {
            /*HRESULT GetMethodTableSlot(
            [In] CLRDATA_ADDRESS mt,
            [In] int slot,
            [Out] out CLRDATA_ADDRESS value);*/
            return Raw.GetMethodTableSlot(mt, slot, out value);
        }

        #endregion
        #region GetMethodTableFieldData

        public DacpMethodTableFieldData GetMethodTableFieldData(CLRDATA_ADDRESS mt)
        {
            DacpMethodTableFieldData data;
            TryGetMethodTableFieldData(mt, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetMethodTableFieldData(CLRDATA_ADDRESS mt, out DacpMethodTableFieldData data)
        {
            /*HRESULT GetMethodTableFieldData(
            [In] CLRDATA_ADDRESS mt,
            [Out] out DacpMethodTableFieldData data);*/
            return Raw.GetMethodTableFieldData(mt, out data);
        }

        #endregion
        #region GetMethodTableTransparencyData

        public DacpMethodTableTransparencyData GetMethodTableTransparencyData(CLRDATA_ADDRESS mt)
        {
            DacpMethodTableTransparencyData data;
            TryGetMethodTableTransparencyData(mt, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetMethodTableTransparencyData(CLRDATA_ADDRESS mt, out DacpMethodTableTransparencyData data)
        {
            /*HRESULT GetMethodTableTransparencyData(
            [In] CLRDATA_ADDRESS mt,
            [Out] out DacpMethodTableTransparencyData data);*/
            return Raw.GetMethodTableTransparencyData(mt, out data);
        }

        #endregion
        #region GetMethodTableForEEClass

        public CLRDATA_ADDRESS GetMethodTableForEEClass(CLRDATA_ADDRESS eeClass)
        {
            CLRDATA_ADDRESS value;
            TryGetMethodTableForEEClass(eeClass, out value).ThrowOnNotOK();

            return value;
        }

        public HRESULT TryGetMethodTableForEEClass(CLRDATA_ADDRESS eeClass, out CLRDATA_ADDRESS value)
        {
            /*HRESULT GetMethodTableForEEClass(
            [In] CLRDATA_ADDRESS eeClass,
            [Out] out CLRDATA_ADDRESS value);*/
            return Raw.GetMethodTableForEEClass(eeClass, out value);
        }

        #endregion
        #region GetFieldDescData

        public DacpFieldDescData GetFieldDescData(CLRDATA_ADDRESS fieldDesc)
        {
            DacpFieldDescData data;
            TryGetFieldDescData(fieldDesc, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetFieldDescData(CLRDATA_ADDRESS fieldDesc, out DacpFieldDescData data)
        {
            /*HRESULT GetFieldDescData(
            [In] CLRDATA_ADDRESS fieldDesc,
            [Out] out DacpFieldDescData data);*/
            return Raw.GetFieldDescData(fieldDesc, out data);
        }

        #endregion
        #region GetFrameName

        public string GetFrameName(CLRDATA_ADDRESS vtable)
        {
            string frameNameResult;
            TryGetFrameName(vtable, out frameNameResult).ThrowOnNotOK();

            return frameNameResult;
        }

        public HRESULT TryGetFrameName(CLRDATA_ADDRESS vtable, out string frameNameResult)
        {
            /*HRESULT GetFrameName(
            [In] CLRDATA_ADDRESS vtable,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] frameName,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] frameName;
            int pNeeded;
            HRESULT hr = Raw.GetFrameName(vtable, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            frameName = new char[count];
            hr = Raw.GetFrameName(vtable, count, frameName, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                frameNameResult = CreateString(frameName, pNeeded);

                return hr;
            }

            fail:
            frameNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetPEFileBase

        public CLRDATA_ADDRESS GetPEFileBase(CLRDATA_ADDRESS addr)
        {
            CLRDATA_ADDRESS _base;
            TryGetPEFileBase(addr, out _base).ThrowOnNotOK();

            return _base;
        }

        public HRESULT TryGetPEFileBase(CLRDATA_ADDRESS addr, out CLRDATA_ADDRESS _base)
        {
            /*HRESULT GetPEFileBase(
            [In] CLRDATA_ADDRESS addr,
            [Out] out CLRDATA_ADDRESS _base);*/
            return Raw.GetPEFileBase(addr, out _base);
        }

        #endregion
        #region GetPEFileName

        public string GetPEFileName(CLRDATA_ADDRESS addr)
        {
            string fileNameResult;
            TryGetPEFileName(addr, out fileNameResult).ThrowOnNotOK();

            return fileNameResult;
        }

        public HRESULT TryGetPEFileName(CLRDATA_ADDRESS addr, out string fileNameResult)
        {
            /*HRESULT GetPEFileName(
            [In] CLRDATA_ADDRESS addr,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] fileName,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] fileName;
            int pNeeded;
            HRESULT hr = Raw.GetPEFileName(addr, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            fileName = new char[count];
            hr = Raw.GetPEFileName(addr, count, fileName, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                fileNameResult = CreateString(fileName, pNeeded);

                return hr;
            }

            fail:
            fileNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetGCHeapDetails

        public DacpGcHeapDetails GetGCHeapDetails(CLRDATA_ADDRESS heap)
        {
            DacpGcHeapDetails details;
            TryGetGCHeapDetails(heap, out details).ThrowOnNotOK();

            return details;
        }

        public HRESULT TryGetGCHeapDetails(CLRDATA_ADDRESS heap, out DacpGcHeapDetails details)
        {
            /*HRESULT GetGCHeapDetails(
            [In] CLRDATA_ADDRESS heap,
            [Out] out DacpGcHeapDetails details);*/
            return Raw.GetGCHeapDetails(heap, out details);
        }

        #endregion
        #region GetHeapSegmentData

        public DacpHeapSegmentData GetHeapSegmentData(CLRDATA_ADDRESS seg)
        {
            DacpHeapSegmentData data;
            TryGetHeapSegmentData(seg, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetHeapSegmentData(CLRDATA_ADDRESS seg, out DacpHeapSegmentData data)
        {
            /*HRESULT GetHeapSegmentData(
            [In] CLRDATA_ADDRESS seg,
            [Out] out DacpHeapSegmentData data);*/
            return Raw.GetHeapSegmentData(seg, out data);
        }

        #endregion
        #region GetOOMData

        public DacpOomData GetOOMData(CLRDATA_ADDRESS oomAddr)
        {
            DacpOomData data;
            TryGetOOMData(oomAddr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetOOMData(CLRDATA_ADDRESS oomAddr, out DacpOomData data)
        {
            /*HRESULT GetOOMData(
            [In] CLRDATA_ADDRESS oomAddr,
            [Out] out DacpOomData data);*/
            return Raw.GetOOMData(oomAddr, out data);
        }

        #endregion
        #region GetHeapAnalyzeData

        public DacpGcHeapAnalyzeData GetHeapAnalyzeData(CLRDATA_ADDRESS addr)
        {
            DacpGcHeapAnalyzeData data;
            TryGetHeapAnalyzeData(addr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetHeapAnalyzeData(CLRDATA_ADDRESS addr, out DacpGcHeapAnalyzeData data)
        {
            /*HRESULT GetHeapAnalyzeData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpGcHeapAnalyzeData data);*/
            return Raw.GetHeapAnalyzeData(addr, out data);
        }

        #endregion
        #region GetDomainLocalModuleData

        public DacpDomainLocalModuleData GetDomainLocalModuleData(CLRDATA_ADDRESS addr)
        {
            DacpDomainLocalModuleData data;
            TryGetDomainLocalModuleData(addr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetDomainLocalModuleData(CLRDATA_ADDRESS addr, out DacpDomainLocalModuleData data)
        {
            /*HRESULT GetDomainLocalModuleData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpDomainLocalModuleData data);*/
            return Raw.GetDomainLocalModuleData(addr, out data);
        }

        #endregion
        #region GetDomainLocalModuleDataFromAppDomain

        public DacpDomainLocalModuleData GetDomainLocalModuleDataFromAppDomain(CLRDATA_ADDRESS appDomainAddr, int moduleID)
        {
            DacpDomainLocalModuleData data;
            TryGetDomainLocalModuleDataFromAppDomain(appDomainAddr, moduleID, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetDomainLocalModuleDataFromAppDomain(CLRDATA_ADDRESS appDomainAddr, int moduleID, out DacpDomainLocalModuleData data)
        {
            /*HRESULT GetDomainLocalModuleDataFromAppDomain(
            [In] CLRDATA_ADDRESS appDomainAddr,
            [In] int moduleID,
            [Out] out DacpDomainLocalModuleData data);*/
            return Raw.GetDomainLocalModuleDataFromAppDomain(appDomainAddr, moduleID, out data);
        }

        #endregion
        #region GetDomainLocalModuleDataFromModule

        public DacpDomainLocalModuleData GetDomainLocalModuleDataFromModule(CLRDATA_ADDRESS moduleAddr)
        {
            DacpDomainLocalModuleData data;
            TryGetDomainLocalModuleDataFromModule(moduleAddr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetDomainLocalModuleDataFromModule(CLRDATA_ADDRESS moduleAddr, out DacpDomainLocalModuleData data)
        {
            /*HRESULT GetDomainLocalModuleDataFromModule(
            [In] CLRDATA_ADDRESS moduleAddr,
            [Out] out DacpDomainLocalModuleData data);*/
            return Raw.GetDomainLocalModuleDataFromModule(moduleAddr, out data);
        }

        #endregion
        #region GetThreadLocalModuleData

        public DacpThreadLocalModuleData GetThreadLocalModuleData(CLRDATA_ADDRESS thread, int index)
        {
            DacpThreadLocalModuleData data;
            TryGetThreadLocalModuleData(thread, index, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetThreadLocalModuleData(CLRDATA_ADDRESS thread, int index, out DacpThreadLocalModuleData data)
        {
            /*HRESULT GetThreadLocalModuleData(
            [In] CLRDATA_ADDRESS thread,
            [In] int index,
            [Out] out DacpThreadLocalModuleData data);*/
            return Raw.GetThreadLocalModuleData(thread, index, out data);
        }

        #endregion
        #region GetSyncBlockData

        public DacpSyncBlockData GetSyncBlockData(int number)
        {
            DacpSyncBlockData data;
            TryGetSyncBlockData(number, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetSyncBlockData(int number, out DacpSyncBlockData data)
        {
            /*HRESULT GetSyncBlockData(
            [In] int number,
            [Out] out DacpSyncBlockData data);*/
            return Raw.GetSyncBlockData(number, out data);
        }

        #endregion
        #region GetSyncBlockCleanupData

        public DacpSyncBlockCleanupData GetSyncBlockCleanupData(CLRDATA_ADDRESS addr)
        {
            DacpSyncBlockCleanupData data;
            TryGetSyncBlockCleanupData(addr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetSyncBlockCleanupData(CLRDATA_ADDRESS addr, out DacpSyncBlockCleanupData data)
        {
            /*HRESULT GetSyncBlockCleanupData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpSyncBlockCleanupData data);*/
            return Raw.GetSyncBlockCleanupData(addr, out data);
        }

        #endregion
        #region GetHandleEnumForTypes

        public SOSHandleEnum GetHandleEnumForTypes(int[] types, int count)
        {
            SOSHandleEnum ppHandleEnumResult;
            TryGetHandleEnumForTypes(types, count, out ppHandleEnumResult).ThrowOnNotOK();

            return ppHandleEnumResult;
        }

        public HRESULT TryGetHandleEnumForTypes(int[] types, int count, out SOSHandleEnum ppHandleEnumResult)
        {
            /*HRESULT GetHandleEnumForTypes(
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] types,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSHandleEnum ppHandleEnum);*/
            ISOSHandleEnum ppHandleEnum;
            HRESULT hr = Raw.GetHandleEnumForTypes(types, count, out ppHandleEnum);

            if (hr == HRESULT.S_OK)
                ppHandleEnumResult = ppHandleEnum == null ? null : new SOSHandleEnum(ppHandleEnum);
            else
                ppHandleEnumResult = default(SOSHandleEnum);

            return hr;
        }

        #endregion
        #region GetHandleEnumForGC

        public SOSHandleEnum GetHandleEnumForGC(int gen)
        {
            SOSHandleEnum ppHandleEnumResult;
            TryGetHandleEnumForGC(gen, out ppHandleEnumResult).ThrowOnNotOK();

            return ppHandleEnumResult;
        }

        public HRESULT TryGetHandleEnumForGC(int gen, out SOSHandleEnum ppHandleEnumResult)
        {
            /*HRESULT GetHandleEnumForGC(
            [In] int gen,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSHandleEnum ppHandleEnum);*/
            ISOSHandleEnum ppHandleEnum;
            HRESULT hr = Raw.GetHandleEnumForGC(gen, out ppHandleEnum);

            if (hr == HRESULT.S_OK)
                ppHandleEnumResult = ppHandleEnum == null ? null : new SOSHandleEnum(ppHandleEnum);
            else
                ppHandleEnumResult = default(SOSHandleEnum);

            return hr;
        }

        #endregion
        #region TraverseEHInfo

        public void TraverseEHInfo(CLRDATA_ADDRESS ip, DUMPEHINFO pCallback, IntPtr token)
        {
            TryTraverseEHInfo(ip, pCallback, token).ThrowOnNotOK();
        }

        public HRESULT TryTraverseEHInfo(CLRDATA_ADDRESS ip, DUMPEHINFO pCallback, IntPtr token)
        {
            /*HRESULT TraverseEHInfo(
            [In] CLRDATA_ADDRESS ip,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] DUMPEHINFO pCallback,
            [In] IntPtr token);*/
            return Raw.TraverseEHInfo(ip, pCallback, token);
        }

        #endregion
        #region GetNestedExceptionData

        public GetNestedExceptionDataResult GetNestedExceptionData(CLRDATA_ADDRESS exception)
        {
            GetNestedExceptionDataResult result;
            TryGetNestedExceptionData(exception, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetNestedExceptionData(CLRDATA_ADDRESS exception, out GetNestedExceptionDataResult result)
        {
            /*HRESULT GetNestedExceptionData(
            [In] CLRDATA_ADDRESS exception,
            [Out] out CLRDATA_ADDRESS exceptionObject,
            [Out] out CLRDATA_ADDRESS nextNestedException);*/
            CLRDATA_ADDRESS exceptionObject;
            CLRDATA_ADDRESS nextNestedException;
            HRESULT hr = Raw.GetNestedExceptionData(exception, out exceptionObject, out nextNestedException);

            if (hr == HRESULT.S_OK)
                result = new GetNestedExceptionDataResult(exceptionObject, nextNestedException);
            else
                result = default(GetNestedExceptionDataResult);

            return hr;
        }

        #endregion
        #region TraverseLoaderHeap

        public void TraverseLoaderHeap(CLRDATA_ADDRESS loaderHeapAddr, VISITHEAP pCallback)
        {
            TryTraverseLoaderHeap(loaderHeapAddr, pCallback).ThrowOnNotOK();
        }

        public HRESULT TryTraverseLoaderHeap(CLRDATA_ADDRESS loaderHeapAddr, VISITHEAP pCallback)
        {
            /*HRESULT TraverseLoaderHeap(
            [In] CLRDATA_ADDRESS loaderHeapAddr,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITHEAP pCallback);*/
            return Raw.TraverseLoaderHeap(loaderHeapAddr, pCallback);
        }

        #endregion
        #region GetCodeHeapList

        public DacpJitCodeHeapInfo[] GetCodeHeapList(CLRDATA_ADDRESS jitManager)
        {
            DacpJitCodeHeapInfo[] codeHeaps;
            TryGetCodeHeapList(jitManager, out codeHeaps).ThrowOnNotOK();

            return codeHeaps;
        }

        public HRESULT TryGetCodeHeapList(CLRDATA_ADDRESS jitManager, out DacpJitCodeHeapInfo[] codeHeaps)
        {
            /*HRESULT GetCodeHeapList(
            [In] CLRDATA_ADDRESS jitManager,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DacpJitCodeHeapInfo[] codeHeaps,
            [Out] out int pNeeded);*/
            int count = 0;
            codeHeaps = null;
            int pNeeded;
            HRESULT hr = Raw.GetCodeHeapList(jitManager, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            codeHeaps = new DacpJitCodeHeapInfo[count];
            hr = Raw.GetCodeHeapList(jitManager, count, codeHeaps, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region TraverseVirtCallStubHeap

        public void TraverseVirtCallStubHeap(CLRDATA_ADDRESS pAppDomain, VCSHeapType heaptype, VISITHEAP pCallback)
        {
            TryTraverseVirtCallStubHeap(pAppDomain, heaptype, pCallback).ThrowOnNotOK();
        }

        public HRESULT TryTraverseVirtCallStubHeap(CLRDATA_ADDRESS pAppDomain, VCSHeapType heaptype, VISITHEAP pCallback)
        {
            /*HRESULT TraverseVirtCallStubHeap(
            [In] CLRDATA_ADDRESS pAppDomain,
            [In] VCSHeapType heaptype,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITHEAP pCallback);*/
            return Raw.TraverseVirtCallStubHeap(pAppDomain, heaptype, pCallback);
        }

        #endregion
        #region GetClrWatsonBuckets

        public void GetClrWatsonBuckets(CLRDATA_ADDRESS thread, IntPtr pGenericModeBlock)
        {
            TryGetClrWatsonBuckets(thread, pGenericModeBlock).ThrowOnNotOK();
        }

        public HRESULT TryGetClrWatsonBuckets(CLRDATA_ADDRESS thread, IntPtr pGenericModeBlock)
        {
            /*HRESULT GetClrWatsonBuckets(
            [In] CLRDATA_ADDRESS thread,
            [In] IntPtr pGenericModeBlock);*/
            return Raw.GetClrWatsonBuckets(thread, pGenericModeBlock);
        }

        #endregion
        #region GetRCWData

        public DacpRCWData GetRCWData(CLRDATA_ADDRESS addr)
        {
            DacpRCWData data;
            TryGetRCWData(addr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetRCWData(CLRDATA_ADDRESS addr, out DacpRCWData data)
        {
            /*HRESULT GetRCWData(
            [In] CLRDATA_ADDRESS addr,
            [Out] out DacpRCWData data);*/
            return Raw.GetRCWData(addr, out data);
        }

        #endregion
        #region GetRCWInterfaces

        public DacpCOMInterfacePointerData[] GetRCWInterfaces(CLRDATA_ADDRESS rcw)
        {
            DacpCOMInterfacePointerData[] interfaces;
            TryGetRCWInterfaces(rcw, out interfaces).ThrowOnNotOK();

            return interfaces;
        }

        public HRESULT TryGetRCWInterfaces(CLRDATA_ADDRESS rcw, out DacpCOMInterfacePointerData[] interfaces)
        {
            /*HRESULT GetRCWInterfaces(
            [In] CLRDATA_ADDRESS rcw,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DacpCOMInterfacePointerData[] interfaces,
            [Out] out int pNeeded);*/
            int count = 0;
            interfaces = null;
            int pNeeded;
            HRESULT hr = Raw.GetRCWInterfaces(rcw, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            interfaces = new DacpCOMInterfacePointerData[count];
            hr = Raw.GetRCWInterfaces(rcw, count, interfaces, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region GetCCWData

        public DacpCCWData GetCCWData(CLRDATA_ADDRESS ccw)
        {
            DacpCCWData data;
            TryGetCCWData(ccw, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetCCWData(CLRDATA_ADDRESS ccw, out DacpCCWData data)
        {
            /*HRESULT GetCCWData(
            [In] CLRDATA_ADDRESS ccw,
            [Out] out DacpCCWData data);*/
            return Raw.GetCCWData(ccw, out data);
        }

        #endregion
        #region GetCCWInterfaces

        public DacpCOMInterfacePointerData[] GetCCWInterfaces(CLRDATA_ADDRESS ccw)
        {
            DacpCOMInterfacePointerData[] interfaces;
            TryGetCCWInterfaces(ccw, out interfaces).ThrowOnNotOK();

            return interfaces;
        }

        public HRESULT TryGetCCWInterfaces(CLRDATA_ADDRESS ccw, out DacpCOMInterfacePointerData[] interfaces)
        {
            /*HRESULT GetCCWInterfaces(
            [In] CLRDATA_ADDRESS ccw,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DacpCOMInterfacePointerData[] interfaces,
            [Out] out int pNeeded);*/
            int count = 0;
            interfaces = null;
            int pNeeded;
            HRESULT hr = Raw.GetCCWInterfaces(ccw, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            interfaces = new DacpCOMInterfacePointerData[count];
            hr = Raw.GetCCWInterfaces(ccw, count, interfaces, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region TraverseRCWCleanupList

        public void TraverseRCWCleanupList(CLRDATA_ADDRESS cleanupListPtr, VISITRCWFORCLEANUP pCallback, IntPtr token)
        {
            TryTraverseRCWCleanupList(cleanupListPtr, pCallback, token).ThrowOnNotOK();
        }

        public HRESULT TryTraverseRCWCleanupList(CLRDATA_ADDRESS cleanupListPtr, VISITRCWFORCLEANUP pCallback, IntPtr token)
        {
            /*HRESULT TraverseRCWCleanupList(
            [In] CLRDATA_ADDRESS cleanupListPtr,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITRCWFORCLEANUP pCallback,
            [In] IntPtr token);*/
            return Raw.TraverseRCWCleanupList(cleanupListPtr, pCallback, token);
        }

        #endregion
        #region GetStackReferences

        public SOSStackRefEnum GetStackReferences(int osThreadID)
        {
            SOSStackRefEnum ppEnumResult;
            TryGetStackReferences(osThreadID, out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        public HRESULT TryGetStackReferences(int osThreadID, out SOSStackRefEnum ppEnumResult)
        {
            /*HRESULT GetStackReferences(
            [In] int osThreadID,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSStackRefEnum ppEnum);*/
            ISOSStackRefEnum ppEnum;
            HRESULT hr = Raw.GetStackReferences(osThreadID, out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new SOSStackRefEnum(ppEnum);
            else
                ppEnumResult = default(SOSStackRefEnum);

            return hr;
        }

        #endregion
        #region GetRegisterName

        public string GetRegisterName(int regName)
        {
            string bufferResult;
            TryGetRegisterName(regName, out bufferResult).ThrowOnNotOK();

            return bufferResult;
        }

        public HRESULT TryGetRegisterName(int regName, out string bufferResult)
        {
            /*HRESULT GetRegisterName(
            [In] int regName,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] buffer,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] buffer;
            int pNeeded;
            HRESULT hr = Raw.GetRegisterName(regName, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            buffer = new char[count];
            hr = Raw.GetRegisterName(regName, count, buffer, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, pNeeded);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetThreadAllocData

        public DacpAllocData GetThreadAllocData(CLRDATA_ADDRESS thread)
        {
            DacpAllocData data;
            TryGetThreadAllocData(thread, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetThreadAllocData(CLRDATA_ADDRESS thread, out DacpAllocData data)
        {
            /*HRESULT GetThreadAllocData(
            [In] CLRDATA_ADDRESS thread,
            [Out] out DacpAllocData data);*/
            return Raw.GetThreadAllocData(thread, out data);
        }

        #endregion
        #region GetHeapAllocData

        public GetHeapAllocDataResult GetHeapAllocData(int count)
        {
            GetHeapAllocDataResult result;
            TryGetHeapAllocData(count, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetHeapAllocData(int count, out GetHeapAllocDataResult result)
        {
            /*HRESULT GetHeapAllocData(
            [In] int count,
            [Out] out DacpGenerationAllocData data,
            [Out] out int pNeeded);*/
            DacpGenerationAllocData data;
            int pNeeded;
            HRESULT hr = Raw.GetHeapAllocData(count, out data, out pNeeded);

            if (hr == HRESULT.S_OK)
                result = new GetHeapAllocDataResult(data, pNeeded);
            else
                result = default(GetHeapAllocDataResult);

            return hr;
        }

        #endregion
        #region GetFailedAssemblyList

        public CLRDATA_ADDRESS[] GetFailedAssemblyList(CLRDATA_ADDRESS appDomain)
        {
            CLRDATA_ADDRESS[] values;
            TryGetFailedAssemblyList(appDomain, out values).ThrowOnNotOK();

            return values;
        }

        public HRESULT TryGetFailedAssemblyList(CLRDATA_ADDRESS appDomain, out CLRDATA_ADDRESS[] values)
        {
            /*HRESULT GetFailedAssemblyList(
            [In] CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] values,
            [Out] out int pNeeded);*/
            int count = 0;
            values = null;
            int pNeeded;
            HRESULT hr = Raw.GetFailedAssemblyList(appDomain, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            values = new CLRDATA_ADDRESS[count];
            hr = Raw.GetFailedAssemblyList(appDomain, count, values, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region GetPrivateBinPaths

        public string GetPrivateBinPaths(CLRDATA_ADDRESS appDomain)
        {
            string pathsResult;
            TryGetPrivateBinPaths(appDomain, out pathsResult).ThrowOnNotOK();

            return pathsResult;
        }

        public HRESULT TryGetPrivateBinPaths(CLRDATA_ADDRESS appDomain, out string pathsResult)
        {
            /*HRESULT GetPrivateBinPaths(
            [In] CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] paths,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] paths;
            int pNeeded;
            HRESULT hr = Raw.GetPrivateBinPaths(appDomain, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            paths = new char[count];
            hr = Raw.GetPrivateBinPaths(appDomain, count, paths, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                pathsResult = CreateString(paths, pNeeded);

                return hr;
            }

            fail:
            pathsResult = default(string);

            return hr;
        }

        #endregion
        #region GetAssemblyLocation

        public string GetAssemblyLocation(CLRDATA_ADDRESS assembly)
        {
            string locationResult;
            TryGetAssemblyLocation(assembly, out locationResult).ThrowOnNotOK();

            return locationResult;
        }

        public HRESULT TryGetAssemblyLocation(CLRDATA_ADDRESS assembly, out string locationResult)
        {
            /*HRESULT GetAssemblyLocation(
            [In] CLRDATA_ADDRESS assembly,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] location,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] location;
            int pNeeded;
            HRESULT hr = Raw.GetAssemblyLocation(assembly, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            location = new char[count];
            hr = Raw.GetAssemblyLocation(assembly, count, location, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                locationResult = CreateString(location, pNeeded);

                return hr;
            }

            fail:
            locationResult = default(string);

            return hr;
        }

        #endregion
        #region GetAppDomainConfigFile

        public string GetAppDomainConfigFile(CLRDATA_ADDRESS appDomain)
        {
            string configFileResult;
            TryGetAppDomainConfigFile(appDomain, out configFileResult).ThrowOnNotOK();

            return configFileResult;
        }

        public HRESULT TryGetAppDomainConfigFile(CLRDATA_ADDRESS appDomain, out string configFileResult)
        {
            /*HRESULT GetAppDomainConfigFile(
            [In] CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] configFile,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] configFile;
            int pNeeded;
            HRESULT hr = Raw.GetAppDomainConfigFile(appDomain, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            configFile = new char[count];
            hr = Raw.GetAppDomainConfigFile(appDomain, count, configFile, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                configFileResult = CreateString(configFile, pNeeded);

                return hr;
            }

            fail:
            configFileResult = default(string);

            return hr;
        }

        #endregion
        #region GetApplicationBase

        public string GetApplicationBase(CLRDATA_ADDRESS appDomain)
        {
            string _baseResult;
            TryGetApplicationBase(appDomain, out _baseResult).ThrowOnNotOK();

            return _baseResult;
        }

        public HRESULT TryGetApplicationBase(CLRDATA_ADDRESS appDomain, out string _baseResult)
        {
            /*HRESULT GetApplicationBase(
            [In] CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] _base,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] _base;
            int pNeeded;
            HRESULT hr = Raw.GetApplicationBase(appDomain, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            _base = new char[count];
            hr = Raw.GetApplicationBase(appDomain, count, _base, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                _baseResult = CreateString(_base, pNeeded);

                return hr;
            }

            fail:
            _baseResult = default(string);

            return hr;
        }

        #endregion
        #region GetFailedAssemblyData

        public GetFailedAssemblyDataResult GetFailedAssemblyData(CLRDATA_ADDRESS assembly)
        {
            GetFailedAssemblyDataResult result;
            TryGetFailedAssemblyData(assembly, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetFailedAssemblyData(CLRDATA_ADDRESS assembly, out GetFailedAssemblyDataResult result)
        {
            /*HRESULT GetFailedAssemblyData(
            [In] CLRDATA_ADDRESS assembly,
            [Out] out int pContext,
            [Out] out HRESULT pResult);*/
            int pContext;
            HRESULT pResult;
            HRESULT hr = Raw.GetFailedAssemblyData(assembly, out pContext, out pResult);

            if (hr == HRESULT.S_OK)
                result = new GetFailedAssemblyDataResult(pContext, pResult);
            else
                result = default(GetFailedAssemblyDataResult);

            return hr;
        }

        #endregion
        #region GetFailedAssemblyLocation

        public string GetFailedAssemblyLocation(CLRDATA_ADDRESS assesmbly)
        {
            string locationResult;
            TryGetFailedAssemblyLocation(assesmbly, out locationResult).ThrowOnNotOK();

            return locationResult;
        }

        public HRESULT TryGetFailedAssemblyLocation(CLRDATA_ADDRESS assesmbly, out string locationResult)
        {
            /*HRESULT GetFailedAssemblyLocation(
            [In] CLRDATA_ADDRESS assesmbly,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] location,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] location;
            int pNeeded;
            HRESULT hr = Raw.GetFailedAssemblyLocation(assesmbly, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            location = new char[count];
            hr = Raw.GetFailedAssemblyLocation(assesmbly, count, location, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                locationResult = CreateString(location, pNeeded);

                return hr;
            }

            fail:
            locationResult = default(string);

            return hr;
        }

        #endregion
        #region GetFailedAssemblyDisplayName

        public string GetFailedAssemblyDisplayName(CLRDATA_ADDRESS assembly)
        {
            string nameResult;
            TryGetFailedAssemblyDisplayName(assembly, out nameResult).ThrowOnNotOK();

            return nameResult;
        }

        public HRESULT TryGetFailedAssemblyDisplayName(CLRDATA_ADDRESS assembly, out string nameResult)
        {
            /*HRESULT GetFailedAssemblyDisplayName(
            [In] CLRDATA_ADDRESS assembly,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] name,
            [Out] out int pNeeded);*/
            int count = 0;
            char[] name;
            int pNeeded;
            HRESULT hr = Raw.GetFailedAssemblyDisplayName(assembly, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            name = new char[count];
            hr = Raw.GetFailedAssemblyDisplayName(assembly, count, name, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                nameResult = CreateString(name, pNeeded);

                return hr;
            }

            fail:
            nameResult = default(string);

            return hr;
        }

        #endregion
        #endregion
        #region ISOSDacInterface2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface2 Raw2 => (ISOSDacInterface2) Raw;

        #region GetObjectExceptionData

        public DacpExceptionObjectData GetObjectExceptionData(CLRDATA_ADDRESS objAddr)
        {
            DacpExceptionObjectData data;
            TryGetObjectExceptionData(objAddr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetObjectExceptionData(CLRDATA_ADDRESS objAddr, out DacpExceptionObjectData data)
        {
            /*HRESULT GetObjectExceptionData(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out DacpExceptionObjectData data);*/
            return Raw2.GetObjectExceptionData(objAddr, out data);
        }

        #endregion
        #region IsRCWDCOMProxy

        public bool IsRCWDCOMProxy(CLRDATA_ADDRESS rcwAddr)
        {
            bool isDCOMProxy;
            TryIsRCWDCOMProxy(rcwAddr, out isDCOMProxy).ThrowOnNotOK();

            return isDCOMProxy;
        }

        public HRESULT TryIsRCWDCOMProxy(CLRDATA_ADDRESS rcwAddr, out bool isDCOMProxy)
        {
            /*HRESULT IsRCWDCOMProxy(
            [In] CLRDATA_ADDRESS rcwAddr,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isDCOMProxy);*/
            return Raw2.IsRCWDCOMProxy(rcwAddr, out isDCOMProxy);
        }

        #endregion
        #endregion
        #region ISOSDacInterface3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface3 Raw3 => (ISOSDacInterface3) Raw;

        #region GCInterestingInfoStaticData

        public DacpGCInterestingInfoData GCInterestingInfoStaticData
        {
            get
            {
                DacpGCInterestingInfoData data;
                TryGetGCInterestingInfoStaticData(out data).ThrowOnNotOK();

                return data;
            }
        }

        public HRESULT TryGetGCInterestingInfoStaticData(out DacpGCInterestingInfoData data)
        {
            /*HRESULT GetGCInterestingInfoStaticData(
            [Out] out DacpGCInterestingInfoData data);*/
            return Raw3.GetGCInterestingInfoStaticData(out data);
        }

        #endregion
        #region GetGCInterestingInfoData

        public DacpGCInterestingInfoData GetGCInterestingInfoData(CLRDATA_ADDRESS interestingInfoAddr)
        {
            DacpGCInterestingInfoData data;
            TryGetGCInterestingInfoData(interestingInfoAddr, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetGCInterestingInfoData(CLRDATA_ADDRESS interestingInfoAddr, out DacpGCInterestingInfoData data)
        {
            /*HRESULT GetGCInterestingInfoData(
            [In] CLRDATA_ADDRESS interestingInfoAddr,
            [Out] out DacpGCInterestingInfoData data);*/
            return Raw3.GetGCInterestingInfoData(interestingInfoAddr, out data);
        }

        #endregion
        #region GetGCGlobalMechanisms

        public void GetGCGlobalMechanisms(long[] globalMechanisms)
        {
            TryGetGCGlobalMechanisms(globalMechanisms).ThrowOnNotOK();
        }

        public HRESULT TryGetGCGlobalMechanisms(long[] globalMechanisms)
        {
            /*HRESULT GetGCGlobalMechanisms(
            [In, MarshalAs(UnmanagedType.LPArray, SizeConst = DAC_MAX_GLOBAL_GC_MECHANISMS_COUNT)] long[] globalMechanisms);*/
            return Raw3.GetGCGlobalMechanisms(globalMechanisms);
        }

        #endregion
        #endregion
        #region ISOSDacInterface4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface4 Raw4 => (ISOSDacInterface4) Raw;

        #region ClrNotification

        public CLRDATA_ADDRESS[] ClrNotification
        {
            get
            {
                CLRDATA_ADDRESS[] arguments;
                TryGetClrNotification(out arguments).ThrowOnNotOK();

                return arguments;
            }
        }

        public HRESULT TryGetClrNotification(out CLRDATA_ADDRESS[] arguments)
        {
            /*HRESULT GetClrNotification(
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] arguments,
            [In] int count,
            [Out] out int pNeeded);*/
            arguments = null;
            int count = 0;
            int pNeeded;
            HRESULT hr = Raw4.GetClrNotification(null, count, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            arguments = new CLRDATA_ADDRESS[count];
            hr = Raw4.GetClrNotification(arguments, count, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #endregion
        #region ISOSDacInterface5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface5 Raw5 => (ISOSDacInterface5) Raw;

        #region GetTieredVersions

        public DacpTieredVersionData[] GetTieredVersions(CLRDATA_ADDRESS methodDesc, int rejitId)
        {
            DacpTieredVersionData[] nativeCodeAddrs;
            TryGetTieredVersions(methodDesc, rejitId, out nativeCodeAddrs).ThrowOnNotOK();

            return nativeCodeAddrs;
        }

        public HRESULT TryGetTieredVersions(CLRDATA_ADDRESS methodDesc, int rejitId, out DacpTieredVersionData[] nativeCodeAddrs)
        {
            /*HRESULT GetTieredVersions(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] int rejitId,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DacpTieredVersionData[] nativeCodeAddrs,
            [In] int cNativeCodeAddrs,
            [Out] out int pcNativeCodeAddrs);*/
            nativeCodeAddrs = null;
            int cNativeCodeAddrs = 0;
            int pcNativeCodeAddrs;
            HRESULT hr = Raw5.GetTieredVersions(methodDesc, rejitId, null, cNativeCodeAddrs, out pcNativeCodeAddrs);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cNativeCodeAddrs = pcNativeCodeAddrs;
            nativeCodeAddrs = new DacpTieredVersionData[cNativeCodeAddrs];
            hr = Raw5.GetTieredVersions(methodDesc, rejitId, nativeCodeAddrs, cNativeCodeAddrs, out pcNativeCodeAddrs);
            fail:
            return hr;
        }

        #endregion
        #endregion
        #region ISOSDacInterface6

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface6 Raw6 => (ISOSDacInterface6) Raw;

        #region GetMethodTableCollectibleData

        public DacpMethodTableCollectibleData GetMethodTableCollectibleData(CLRDATA_ADDRESS mt)
        {
            DacpMethodTableCollectibleData data;
            TryGetMethodTableCollectibleData(mt, out data).ThrowOnNotOK();

            return data;
        }

        public HRESULT TryGetMethodTableCollectibleData(CLRDATA_ADDRESS mt, out DacpMethodTableCollectibleData data)
        {
            /*HRESULT GetMethodTableCollectibleData(
            [In] CLRDATA_ADDRESS mt,
            [Out] out DacpMethodTableCollectibleData data);*/
            return Raw6.GetMethodTableCollectibleData(mt, out data);
        }

        #endregion
        #endregion
        #region ISOSDacInterface7

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface7 Raw7 => (ISOSDacInterface7) Raw;

        #region GetPendingReJITID

        public int GetPendingReJITID(CLRDATA_ADDRESS methodDesc)
        {
            int pRejitId;
            TryGetPendingReJITID(methodDesc, out pRejitId).ThrowOnNotOK();

            return pRejitId;
        }

        public HRESULT TryGetPendingReJITID(CLRDATA_ADDRESS methodDesc, out int pRejitId)
        {
            /*HRESULT GetPendingReJITID(
            [In] CLRDATA_ADDRESS methodDesc,
            [Out] out int pRejitId);*/
            return Raw7.GetPendingReJITID(methodDesc, out pRejitId);
        }

        #endregion
        #region GetReJITInformation

        public DacpReJitData2 GetReJITInformation(CLRDATA_ADDRESS methodDesc, int rejitId)
        {
            DacpReJitData2 pRejitData;
            TryGetReJITInformation(methodDesc, rejitId, out pRejitData).ThrowOnNotOK();

            return pRejitData;
        }

        public HRESULT TryGetReJITInformation(CLRDATA_ADDRESS methodDesc, int rejitId, out DacpReJitData2 pRejitData)
        {
            /*HRESULT GetReJITInformation(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] int rejitId,
            [Out] out DacpReJitData2 pRejitData);*/
            return Raw7.GetReJITInformation(methodDesc, rejitId, out pRejitData);
        }

        #endregion
        #region GetProfilerModifiedILInformation

        public DacpProfilerILData GetProfilerModifiedILInformation(CLRDATA_ADDRESS methodDesc)
        {
            DacpProfilerILData pILData;
            TryGetProfilerModifiedILInformation(methodDesc, out pILData).ThrowOnNotOK();

            return pILData;
        }

        public HRESULT TryGetProfilerModifiedILInformation(CLRDATA_ADDRESS methodDesc, out DacpProfilerILData pILData)
        {
            /*HRESULT GetProfilerModifiedILInformation(
            [In] CLRDATA_ADDRESS methodDesc,
            [Out] out DacpProfilerILData pILData);*/
            return Raw7.GetProfilerModifiedILInformation(methodDesc, out pILData);
        }

        #endregion
        #region GetMethodsWithProfilerModifiedIL

        public CLRDATA_ADDRESS[] GetMethodsWithProfilerModifiedIL(CLRDATA_ADDRESS mod)
        {
            CLRDATA_ADDRESS[] methodDescs;
            TryGetMethodsWithProfilerModifiedIL(mod, out methodDescs).ThrowOnNotOK();

            return methodDescs;
        }

        public HRESULT TryGetMethodsWithProfilerModifiedIL(CLRDATA_ADDRESS mod, out CLRDATA_ADDRESS[] methodDescs)
        {
            /*HRESULT GetMethodsWithProfilerModifiedIL(
            [In] CLRDATA_ADDRESS mod,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CLRDATA_ADDRESS[] methodDescs,
            [In] int cMethodDescs,
            [Out] out int pcMethodDescs);*/
            methodDescs = null;
            int cMethodDescs = 0;
            int pcMethodDescs;
            HRESULT hr = Raw7.GetMethodsWithProfilerModifiedIL(mod, null, cMethodDescs, out pcMethodDescs);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cMethodDescs = pcMethodDescs;
            methodDescs = new CLRDATA_ADDRESS[cMethodDescs];
            hr = Raw7.GetMethodsWithProfilerModifiedIL(mod, methodDescs, cMethodDescs, out pcMethodDescs);
            fail:
            return hr;
        }

        #endregion
        #endregion
        #region ISOSDacInterface8

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface8 Raw8 => (ISOSDacInterface8) Raw;

        #region NumberGenerations

        public int NumberGenerations
        {
            get
            {
                int pGenerations;
                TryGetNumberGenerations(out pGenerations).ThrowOnNotOK();

                return pGenerations;
            }
        }

        public HRESULT TryGetNumberGenerations(out int pGenerations)
        {
            /*HRESULT GetNumberGenerations(
            [Out] out int pGenerations);*/
            return Raw8.GetNumberGenerations(out pGenerations);
        }

        #endregion
        #region GenerationTable

        public DacpGenerationData[] GenerationTable
        {
            get
            {
                DacpGenerationData[] pGenerationData;
                TryGetGenerationTable(out pGenerationData).ThrowOnNotOK();

                return pGenerationData;
            }
        }

        public HRESULT TryGetGenerationTable(out DacpGenerationData[] pGenerationData)
        {
            /*HRESULT GetGenerationTable(
            [In] int cGenerations,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DacpGenerationData[] pGenerationData,
            [Out] out int pNeeded);*/
            int cGenerations = 0;
            pGenerationData = null;
            int pNeeded;
            HRESULT hr = Raw8.GetGenerationTable(cGenerations, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cGenerations = pNeeded;
            pGenerationData = new DacpGenerationData[cGenerations];
            hr = Raw8.GetGenerationTable(cGenerations, pGenerationData, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region FinalizationFillPointers

        public CLRDATA_ADDRESS[] FinalizationFillPointers
        {
            get
            {
                CLRDATA_ADDRESS[] pFinalizationFillPointers;
                TryGetFinalizationFillPointers(out pFinalizationFillPointers).ThrowOnNotOK();

                return pFinalizationFillPointers;
            }
        }

        public HRESULT TryGetFinalizationFillPointers(out CLRDATA_ADDRESS[] pFinalizationFillPointers)
        {
            /*HRESULT GetFinalizationFillPointers(
            [In] int cFillPointers,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] CLRDATA_ADDRESS[] pFinalizationFillPointers,
            [Out] out int pNeeded);*/
            int cFillPointers = 0;
            pFinalizationFillPointers = null;
            int pNeeded;
            HRESULT hr = Raw8.GetFinalizationFillPointers(cFillPointers, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cFillPointers = pNeeded;
            pFinalizationFillPointers = new CLRDATA_ADDRESS[cFillPointers];
            hr = Raw8.GetFinalizationFillPointers(cFillPointers, pFinalizationFillPointers, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region GetGenerationTableSvr

        public DacpGenerationData[] GetGenerationTableSvr(CLRDATA_ADDRESS heapAddr)
        {
            DacpGenerationData[] pGenerationData;
            TryGetGenerationTableSvr(heapAddr, out pGenerationData).ThrowOnNotOK();

            return pGenerationData;
        }

        public HRESULT TryGetGenerationTableSvr(CLRDATA_ADDRESS heapAddr, out DacpGenerationData[] pGenerationData)
        {
            /*HRESULT GetGenerationTableSvr(
            [In] CLRDATA_ADDRESS heapAddr,
            [In] int cGenerations,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DacpGenerationData[] pGenerationData,
            [Out] out int pNeeded);*/
            int cGenerations = 0;
            pGenerationData = null;
            int pNeeded;
            HRESULT hr = Raw8.GetGenerationTableSvr(heapAddr, cGenerations, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cGenerations = pNeeded;
            pGenerationData = new DacpGenerationData[cGenerations];
            hr = Raw8.GetGenerationTableSvr(heapAddr, cGenerations, pGenerationData, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region GetFinalizationFillPointersSvr

        public CLRDATA_ADDRESS[] GetFinalizationFillPointersSvr(CLRDATA_ADDRESS heapAddr)
        {
            CLRDATA_ADDRESS[] pFinalizationFillPointers;
            TryGetFinalizationFillPointersSvr(heapAddr, out pFinalizationFillPointers).ThrowOnNotOK();

            return pFinalizationFillPointers;
        }

        public HRESULT TryGetFinalizationFillPointersSvr(CLRDATA_ADDRESS heapAddr, out CLRDATA_ADDRESS[] pFinalizationFillPointers)
        {
            /*HRESULT GetFinalizationFillPointersSvr(
            [In] CLRDATA_ADDRESS heapAddr,
            [In] int cFillPointers,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] pFinalizationFillPointers,
            [Out] out int pNeeded);*/
            int cFillPointers = 0;
            pFinalizationFillPointers = null;
            int pNeeded;
            HRESULT hr = Raw8.GetFinalizationFillPointersSvr(heapAddr, cFillPointers, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cFillPointers = pNeeded;
            pFinalizationFillPointers = new CLRDATA_ADDRESS[cFillPointers];
            hr = Raw8.GetFinalizationFillPointersSvr(heapAddr, cFillPointers, pFinalizationFillPointers, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region GetAssemblyLoadContext

        public CLRDATA_ADDRESS GetAssemblyLoadContext(CLRDATA_ADDRESS methodTable)
        {
            CLRDATA_ADDRESS assemblyLoadContext;
            TryGetAssemblyLoadContext(methodTable, out assemblyLoadContext).ThrowOnNotOK();

            return assemblyLoadContext;
        }

        public HRESULT TryGetAssemblyLoadContext(CLRDATA_ADDRESS methodTable, out CLRDATA_ADDRESS assemblyLoadContext)
        {
            /*HRESULT GetAssemblyLoadContext(
            [In] CLRDATA_ADDRESS methodTable,
            [Out] out CLRDATA_ADDRESS assemblyLoadContext);*/
            return Raw8.GetAssemblyLoadContext(methodTable, out assemblyLoadContext);
        }

        #endregion
        #endregion
        #region ISOSDacInterface9

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface9 Raw9 => (ISOSDacInterface9) Raw;

        #region BreakingChangeVersion

        public int BreakingChangeVersion
        {
            get
            {
                int pVersion;
                TryGetBreakingChangeVersion(out pVersion).ThrowOnNotOK();

                return pVersion;
            }
        }

        public HRESULT TryGetBreakingChangeVersion(out int pVersion)
        {
            /*HRESULT GetBreakingChangeVersion(
            [Out] out int pVersion);*/
            return Raw9.GetBreakingChangeVersion(out pVersion);
        }

        #endregion
        #endregion
        #region ISOSDacInterface10

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface10 Raw10 => (ISOSDacInterface10) Raw;

        #region GetObjectComWrappersData

        public GetObjectComWrappersDataResult GetObjectComWrappersData(CLRDATA_ADDRESS objAddr)
        {
            GetObjectComWrappersDataResult result;
            TryGetObjectComWrappersData(objAddr, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetObjectComWrappersData(CLRDATA_ADDRESS objAddr, out GetObjectComWrappersDataResult result)
        {
            /*HRESULT GetObjectComWrappersData(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out CLRDATA_ADDRESS rcw,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CLRDATA_ADDRESS[] mowList,
            [Out] out int pNeeded);*/
            CLRDATA_ADDRESS rcw;
            int count = 0;
            CLRDATA_ADDRESS[] mowList;
            int pNeeded;
            HRESULT hr = Raw10.GetObjectComWrappersData(objAddr, out rcw, count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            mowList = new CLRDATA_ADDRESS[count];
            hr = Raw10.GetObjectComWrappersData(objAddr, out rcw, count, mowList, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                result = new GetObjectComWrappersDataResult(rcw, mowList);

                return hr;
            }

            fail:
            result = default(GetObjectComWrappersDataResult);

            return hr;
        }

        #endregion
        #region IsComWrappersCCW

        public bool IsComWrappersCCW(CLRDATA_ADDRESS ccw)
        {
            bool isComWrappersCCW;
            TryIsComWrappersCCW(ccw, out isComWrappersCCW).ThrowOnNotOK();

            return isComWrappersCCW;
        }

        public HRESULT TryIsComWrappersCCW(CLRDATA_ADDRESS ccw, out bool isComWrappersCCW)
        {
            /*HRESULT IsComWrappersCCW(
            [In] CLRDATA_ADDRESS ccw,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isComWrappersCCW);*/
            return Raw10.IsComWrappersCCW(ccw, out isComWrappersCCW);
        }

        #endregion
        #region GetComWrappersCCWData

        public GetComWrappersCCWDataResult GetComWrappersCCWData(CLRDATA_ADDRESS ccw)
        {
            GetComWrappersCCWDataResult result;
            TryGetComWrappersCCWData(ccw, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetComWrappersCCWData(CLRDATA_ADDRESS ccw, out GetComWrappersCCWDataResult result)
        {
            /*HRESULT GetComWrappersCCWData(
            [In] CLRDATA_ADDRESS ccw,
            [Out] out CLRDATA_ADDRESS managedObject,
            [Out] out int refCount);*/
            CLRDATA_ADDRESS managedObject;
            int refCount;
            HRESULT hr = Raw10.GetComWrappersCCWData(ccw, out managedObject, out refCount);

            if (hr == HRESULT.S_OK)
                result = new GetComWrappersCCWDataResult(managedObject, refCount);
            else
                result = default(GetComWrappersCCWDataResult);

            return hr;
        }

        #endregion
        #region IsComWrappersRCW

        public bool IsComWrappersRCW(CLRDATA_ADDRESS rcw)
        {
            bool isComWrappersRCW;
            TryIsComWrappersRCW(rcw, out isComWrappersRCW).ThrowOnNotOK();

            return isComWrappersRCW;
        }

        public HRESULT TryIsComWrappersRCW(CLRDATA_ADDRESS rcw, out bool isComWrappersRCW)
        {
            /*HRESULT IsComWrappersRCW(
            [In] CLRDATA_ADDRESS rcw,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isComWrappersRCW);*/
            return Raw10.IsComWrappersRCW(rcw, out isComWrappersRCW);
        }

        #endregion
        #region GetComWrappersRCWData

        public CLRDATA_ADDRESS GetComWrappersRCWData(CLRDATA_ADDRESS rcw)
        {
            CLRDATA_ADDRESS identity;
            TryGetComWrappersRCWData(rcw, out identity).ThrowOnNotOK();

            return identity;
        }

        public HRESULT TryGetComWrappersRCWData(CLRDATA_ADDRESS rcw, out CLRDATA_ADDRESS identity)
        {
            /*HRESULT GetComWrappersRCWData(
            [In] CLRDATA_ADDRESS rcw,
            [Out] out CLRDATA_ADDRESS identity);*/
            return Raw10.GetComWrappersRCWData(rcw, out identity);
        }

        #endregion
        #endregion
        #region ISOSDacInterface11

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface11 Raw11 => (ISOSDacInterface11) Raw;

        #region IsTrackedType

        public IsTrackedTypeResult IsTrackedType(CLRDATA_ADDRESS objAddr)
        {
            IsTrackedTypeResult result;
            TryIsTrackedType(objAddr, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryIsTrackedType(CLRDATA_ADDRESS objAddr, out IsTrackedTypeResult result)
        {
            /*HRESULT IsTrackedType(
            [In] CLRDATA_ADDRESS objAddr,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isTrackedType,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool hasTaggedMemory);*/
            bool isTrackedType;
            bool hasTaggedMemory;
            HRESULT hr = Raw11.IsTrackedType(objAddr, out isTrackedType, out hasTaggedMemory);

            if (hr == HRESULT.S_OK)
                result = new IsTrackedTypeResult(isTrackedType, hasTaggedMemory);
            else
                result = default(IsTrackedTypeResult);

            return hr;
        }

        #endregion
        #region GetTaggedMemory

        public GetTaggedMemoryResult GetTaggedMemory(CLRDATA_ADDRESS objAddr)
        {
            GetTaggedMemoryResult result;
            TryGetTaggedMemory(objAddr, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetTaggedMemory(CLRDATA_ADDRESS objAddr, out GetTaggedMemoryResult result)
        {
            /*HRESULT GetTaggedMemory(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out CLRDATA_ADDRESS taggedMemory,
            [Out] out long taggedMemorySizeInBytes);*/
            CLRDATA_ADDRESS taggedMemory;
            long taggedMemorySizeInBytes;
            HRESULT hr = Raw11.GetTaggedMemory(objAddr, out taggedMemory, out taggedMemorySizeInBytes);

            if (hr == HRESULT.S_OK)
                result = new GetTaggedMemoryResult(taggedMemory, taggedMemorySizeInBytes);
            else
                result = default(GetTaggedMemoryResult);

            return hr;
        }

        #endregion
        #endregion
        #region ISOSDacInterface12

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface12 Raw12 => (ISOSDacInterface12) Raw;

        #region GlobalAllocationContext

        public GetGlobalAllocationContextResult GlobalAllocationContext
        {
            get
            {
                GetGlobalAllocationContextResult result;
                TryGetGlobalAllocationContext(out result).ThrowOnNotOK();

                return result;
            }
        }

        public HRESULT TryGetGlobalAllocationContext(out GetGlobalAllocationContextResult result)
        {
            /*HRESULT GetGlobalAllocationContext(
            [Out] out CLRDATA_ADDRESS allocPtr,
            [Out] out CLRDATA_ADDRESS allocLimit);*/
            CLRDATA_ADDRESS allocPtr;
            CLRDATA_ADDRESS allocLimit;
            HRESULT hr = Raw12.GetGlobalAllocationContext(out allocPtr, out allocLimit);

            if (hr == HRESULT.S_OK)
                result = new GetGlobalAllocationContextResult(allocPtr, allocLimit);
            else
                result = default(GetGlobalAllocationContextResult);

            return hr;
        }

        #endregion
        #endregion
        #region ISOSDacInterface13

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISOSDacInterface13 Raw13 => (ISOSDacInterface13) Raw;

        #region LoaderAllocatorHeapNames

        public string[] LoaderAllocatorHeapNames
        {
            get
            {
                string[] ppNames;
                TryGetLoaderAllocatorHeapNames(out ppNames).ThrowOnNotOK();

                return ppNames;
            }
        }

        public HRESULT TryGetLoaderAllocatorHeapNames(out string[] ppNames)
        {
            /*HRESULT GetLoaderAllocatorHeapNames(
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 0)] string[] ppNames,
            [Out] out int pNeeded);*/
            int count = 0;
            ppNames = null;
            int pNeeded;
            HRESULT hr = Raw13.GetLoaderAllocatorHeapNames(count, null, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            ppNames = new string[count];
            hr = Raw13.GetLoaderAllocatorHeapNames(count, ppNames, out pNeeded);
            fail:
            return hr;
        }

        #endregion
        #region HandleTableMemoryRegions

        public SOSMemoryEnum HandleTableMemoryRegions
        {
            get
            {
                SOSMemoryEnum ppEnumResult;
                TryGetHandleTableMemoryRegions(out ppEnumResult).ThrowOnNotOK();

                return ppEnumResult;
            }
        }

        public HRESULT TryGetHandleTableMemoryRegions(out SOSMemoryEnum ppEnumResult)
        {
            /*HRESULT GetHandleTableMemoryRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSMemoryEnum ppEnum);*/
            ISOSMemoryEnum ppEnum;
            HRESULT hr = Raw13.GetHandleTableMemoryRegions(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new SOSMemoryEnum(ppEnum);
            else
                ppEnumResult = default(SOSMemoryEnum);

            return hr;
        }

        #endregion
        #region GCBookkeepingMemoryRegions

        public SOSMemoryEnum GCBookkeepingMemoryRegions
        {
            get
            {
                SOSMemoryEnum ppEnumResult;
                TryGetGCBookkeepingMemoryRegions(out ppEnumResult).ThrowOnNotOK();

                return ppEnumResult;
            }
        }

        public HRESULT TryGetGCBookkeepingMemoryRegions(out SOSMemoryEnum ppEnumResult)
        {
            /*HRESULT GetGCBookkeepingMemoryRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSMemoryEnum ppEnum);*/
            ISOSMemoryEnum ppEnum;
            HRESULT hr = Raw13.GetGCBookkeepingMemoryRegions(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new SOSMemoryEnum(ppEnum);
            else
                ppEnumResult = default(SOSMemoryEnum);

            return hr;
        }

        #endregion
        #region GCFreeRegions

        public SOSMemoryEnum GCFreeRegions
        {
            get
            {
                SOSMemoryEnum ppEnumResult;
                TryGetGCFreeRegions(out ppEnumResult).ThrowOnNotOK();

                return ppEnumResult;
            }
        }

        public HRESULT TryGetGCFreeRegions(out SOSMemoryEnum ppEnumResult)
        {
            /*HRESULT GetGCFreeRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSMemoryEnum ppEnum);*/
            ISOSMemoryEnum ppEnum;
            HRESULT hr = Raw13.GetGCFreeRegions(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new SOSMemoryEnum(ppEnum);
            else
                ppEnumResult = default(SOSMemoryEnum);

            return hr;
        }

        #endregion
        #region TraverseLoaderHeap

        public void TraverseLoaderHeap(CLRDATA_ADDRESS loaderHeapAddr, LoaderHeapKind kind, VISITHEAP pCallback)
        {
            TryTraverseLoaderHeap(loaderHeapAddr, kind, pCallback).ThrowOnNotOK();
        }

        public HRESULT TryTraverseLoaderHeap(CLRDATA_ADDRESS loaderHeapAddr, LoaderHeapKind kind, VISITHEAP pCallback)
        {
            /*HRESULT TraverseLoaderHeap(
            [In] CLRDATA_ADDRESS loaderHeapAddr,
            [In] LoaderHeapKind kind,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITHEAP pCallback);*/
            return Raw13.TraverseLoaderHeap(loaderHeapAddr, kind, pCallback);
        }

        #endregion
        #region GetDomainLoaderAllocator

        public CLRDATA_ADDRESS GetDomainLoaderAllocator(CLRDATA_ADDRESS domainAddress)
        {
            CLRDATA_ADDRESS pLoaderAllocator;
            TryGetDomainLoaderAllocator(domainAddress, out pLoaderAllocator).ThrowOnNotOK();

            return pLoaderAllocator;
        }

        public HRESULT TryGetDomainLoaderAllocator(CLRDATA_ADDRESS domainAddress, out CLRDATA_ADDRESS pLoaderAllocator)
        {
            /*HRESULT GetDomainLoaderAllocator(
            [In] CLRDATA_ADDRESS domainAddress,
            [Out] out CLRDATA_ADDRESS pLoaderAllocator);*/
            return Raw13.GetDomainLoaderAllocator(domainAddress, out pLoaderAllocator);
        }

        #endregion
        #region GetLoaderAllocatorHeaps

        public GetLoaderAllocatorHeapsResult GetLoaderAllocatorHeaps(CLRDATA_ADDRESS loaderAllocator)
        {
            GetLoaderAllocatorHeapsResult result;
            TryGetLoaderAllocatorHeaps(loaderAllocator, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetLoaderAllocatorHeaps(CLRDATA_ADDRESS loaderAllocator, out GetLoaderAllocatorHeapsResult result)
        {
            /*HRESULT GetLoaderAllocatorHeaps(
            [In] CLRDATA_ADDRESS loaderAllocator,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] pLoaderHeaps,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] LoaderHeapKind[] pKinds,
            [Out] int pNeeded);*/
            int count = 0;
            CLRDATA_ADDRESS[] pLoaderHeaps;
            LoaderHeapKind[] pKinds;
            int pNeeded = default(int);
            HRESULT hr = Raw13.GetLoaderAllocatorHeaps(loaderAllocator, count, null, null, pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            pLoaderHeaps = new CLRDATA_ADDRESS[count];
            pKinds = new LoaderHeapKind[count];
            hr = Raw13.GetLoaderAllocatorHeaps(loaderAllocator, count, pLoaderHeaps, pKinds, pNeeded);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLoaderAllocatorHeapsResult(pLoaderHeaps, pKinds);

                return hr;
            }

            fail:
            result = default(GetLoaderAllocatorHeapsResult);

            return hr;
        }

        #endregion
        #region LockedFlush

        public void LockedFlush()
        {
            TryLockedFlush().ThrowOnNotOK();
        }

        public HRESULT TryLockedFlush()
        {
            /*HRESULT LockedFlush();*/
            return Raw13.LockedFlush();
        }

        #endregion
        #endregion
    }
}
