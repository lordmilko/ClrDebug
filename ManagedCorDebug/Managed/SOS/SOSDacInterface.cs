using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
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
                HRESULT hr;
                DacpThreadStoreData data;

                if ((hr = TryGetThreadStoreData(out data)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return data;
            }
        }

        public HRESULT TryGetThreadStoreData(out DacpThreadStoreData data)
        {
            /*HRESULT GetThreadStoreData(
            out DacpThreadStoreData data);*/
            return Raw.GetThreadStoreData(out data);
        }

        #endregion
        #region AppDomainStoreData

        public DacpAppDomainStoreData AppDomainStoreData
        {
            get
            {
                HRESULT hr;
                DacpAppDomainStoreData data;

                if ((hr = TryGetAppDomainStoreData(out data)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return data;
            }
        }

        public HRESULT TryGetAppDomainStoreData(out DacpAppDomainStoreData data)
        {
            /*HRESULT GetAppDomainStoreData(
            out DacpAppDomainStoreData data);*/
            return Raw.GetAppDomainStoreData(out data);
        }

        #endregion
        #region AppDomainList

        public CLRDATA_ADDRESS[] AppDomainList
        {
            get
            {
                HRESULT hr;
                CLRDATA_ADDRESS[] valuesResult;

                if ((hr = TryGetAppDomainList(out valuesResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return valuesResult;
            }
        }

        public HRESULT TryGetAppDomainList(out CLRDATA_ADDRESS[] valuesResult)
        {
            /*HRESULT GetAppDomainList(
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] values,
            out int pNeeded);*/
            int count = 0;
            CLRDATA_ADDRESS[] values = null;
            int pNeeded;
            HRESULT hr = Raw.GetAppDomainList(count, values, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            values = new CLRDATA_ADDRESS[pNeeded];
            hr = Raw.GetAppDomainList(count, values, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                valuesResult = values;

                return hr;
            }

            fail:
            valuesResult = default(CLRDATA_ADDRESS[]);

            return hr;
        }

        #endregion
        #region JitManagerList

        public DacpJitManagerInfo[] JitManagerList
        {
            get
            {
                HRESULT hr;
                DacpJitManagerInfo[] managersResult;

                if ((hr = TryGetJitManagerList(out managersResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return managersResult;
            }
        }

        public HRESULT TryGetJitManagerList(out DacpJitManagerInfo[] managersResult)
        {
            /*HRESULT GetJitManagerList(
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpJitManagerInfo[] managers,
            out int pNeeded);*/
            int count = 0;
            DacpJitManagerInfo[] managers = null;
            int pNeeded;
            HRESULT hr = Raw.GetJitManagerList(count, managers, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            managers = new DacpJitManagerInfo[pNeeded];
            hr = Raw.GetJitManagerList(count, managers, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                managersResult = managers;

                return hr;
            }

            fail:
            managersResult = default(DacpJitManagerInfo[]);

            return hr;
        }

        #endregion
        #region ThreadpoolData

        public DacpThreadpoolData ThreadpoolData
        {
            get
            {
                HRESULT hr;
                DacpThreadpoolData data;

                if ((hr = TryGetThreadpoolData(out data)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return data;
            }
        }

        public HRESULT TryGetThreadpoolData(out DacpThreadpoolData data)
        {
            /*HRESULT GetThreadpoolData(
            out DacpThreadpoolData data);*/
            return Raw.GetThreadpoolData(out data);
        }

        #endregion
        #region GCHeapData

        public DacpGcHeapData GCHeapData
        {
            get
            {
                HRESULT hr;
                DacpGcHeapData data;

                if ((hr = TryGetGCHeapData(out data)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return data;
            }
        }

        public HRESULT TryGetGCHeapData(out DacpGcHeapData data)
        {
            /*HRESULT GetGCHeapData(
            out DacpGcHeapData data);*/
            return Raw.GetGCHeapData(out data);
        }

        #endregion
        #region GCHeapList

        public CLRDATA_ADDRESS[] GCHeapList
        {
            get
            {
                HRESULT hr;
                CLRDATA_ADDRESS[] heapsResult;

                if ((hr = TryGetGCHeapList(out heapsResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return heapsResult;
            }
        }

        public HRESULT TryGetGCHeapList(out CLRDATA_ADDRESS[] heapsResult)
        {
            /*HRESULT GetGCHeapList(
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] heaps,
            out int pNeeded);*/
            int count = 0;
            CLRDATA_ADDRESS[] heaps = null;
            int pNeeded;
            HRESULT hr = Raw.GetGCHeapList(count, heaps, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            heaps = new CLRDATA_ADDRESS[pNeeded];
            hr = Raw.GetGCHeapList(count, heaps, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                heapsResult = heaps;

                return hr;
            }

            fail:
            heapsResult = default(CLRDATA_ADDRESS[]);

            return hr;
        }

        #endregion
        #region GCHeapStaticData

        public DacpGcHeapDetails GCHeapStaticData
        {
            get
            {
                HRESULT hr;
                DacpGcHeapDetails data;

                if ((hr = TryGetGCHeapStaticData(out data)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return data;
            }
        }

        public HRESULT TryGetGCHeapStaticData(out DacpGcHeapDetails data)
        {
            /*HRESULT GetGCHeapStaticData(
            out DacpGcHeapDetails data);*/
            return Raw.GetGCHeapStaticData(out data);
        }

        #endregion
        #region OOMStaticData

        public DacpOomData OOMStaticData
        {
            get
            {
                HRESULT hr;
                DacpOomData data;

                if ((hr = TryGetOOMStaticData(out data)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return data;
            }
        }

        public HRESULT TryGetOOMStaticData(out DacpOomData data)
        {
            /*HRESULT GetOOMStaticData(
            out DacpOomData data);*/
            return Raw.GetOOMStaticData(out data);
        }

        #endregion
        #region HeapAnalyzeStaticData

        public DacpGcHeapAnalyzeData HeapAnalyzeStaticData
        {
            get
            {
                HRESULT hr;
                DacpGcHeapAnalyzeData data;

                if ((hr = TryGetHeapAnalyzeStaticData(out data)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return data;
            }
        }

        public HRESULT TryGetHeapAnalyzeStaticData(out DacpGcHeapAnalyzeData data)
        {
            /*HRESULT GetHeapAnalyzeStaticData(
            out DacpGcHeapAnalyzeData data);*/
            return Raw.GetHeapAnalyzeStaticData(out data);
        }

        #endregion
        #region HandleEnum

        public SOSHandleEnum HandleEnum
        {
            get
            {
                HRESULT hr;
                SOSHandleEnum ppHandleEnumResult;

                if ((hr = TryGetHandleEnum(out ppHandleEnumResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppHandleEnumResult;
            }
        }

        public HRESULT TryGetHandleEnum(out SOSHandleEnum ppHandleEnumResult)
        {
            /*HRESULT GetHandleEnum(
            out ISOSHandleEnum ppHandleEnum);*/
            ISOSHandleEnum ppHandleEnum;
            HRESULT hr = Raw.GetHandleEnum(out ppHandleEnum);

            if (hr == HRESULT.S_OK)
                ppHandleEnumResult = new SOSHandleEnum(ppHandleEnum);
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
                HRESULT hr;
                CLRDATA_ADDRESS stressLog;

                if ((hr = TryGetStressLogAddress(out stressLog)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return stressLog;
            }
        }

        public HRESULT TryGetStressLogAddress(out CLRDATA_ADDRESS stressLog)
        {
            /*HRESULT GetStressLogAddress(
            out CLRDATA_ADDRESS stressLog);*/
            return Raw.GetStressLogAddress(out stressLog);
        }

        #endregion
        #region UsefulGlobals

        public DacpUsefulGlobalsData UsefulGlobals
        {
            get
            {
                HRESULT hr;
                DacpUsefulGlobalsData data;

                if ((hr = TryGetUsefulGlobals(out data)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return data;
            }
        }

        public HRESULT TryGetUsefulGlobals(out DacpUsefulGlobalsData data)
        {
            /*HRESULT GetUsefulGlobals(
            out DacpUsefulGlobalsData data);*/
            return Raw.GetUsefulGlobals(out data);
        }

        #endregion
        #region TLSIndex

        public int TLSIndex
        {
            get
            {
                HRESULT hr;
                int pIndex;

                if ((hr = TryGetTLSIndex(out pIndex)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pIndex;
            }
        }

        public HRESULT TryGetTLSIndex(out int pIndex)
        {
            /*HRESULT GetTLSIndex(
            out int pIndex);*/
            return Raw.GetTLSIndex(out pIndex);
        }

        #endregion
        #region DacModuleHandle

        public long DacModuleHandle
        {
            get
            {
                HRESULT hr;
                long phModule;

                if ((hr = TryGetDacModuleHandle(out phModule)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return phModule;
            }
        }

        public HRESULT TryGetDacModuleHandle(out long phModule)
        {
            /*HRESULT GetDacModuleHandle(
            out long phModule);*/
            return Raw.GetDacModuleHandle(out phModule);
        }

        #endregion
        #region GetAppDomainData

        public DacpAppDomainData GetAppDomainData(CLRDATA_ADDRESS addr)
        {
            HRESULT hr;
            DacpAppDomainData data;

            if ((hr = TryGetAppDomainData(addr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetAppDomainData(CLRDATA_ADDRESS addr, out DacpAppDomainData data)
        {
            /*HRESULT GetAppDomainData(
            CLRDATA_ADDRESS addr,
            out DacpAppDomainData data);*/
            return Raw.GetAppDomainData(addr, out data);
        }

        #endregion
        #region GetAppDomainName

        public string GetAppDomainName(CLRDATA_ADDRESS addr)
        {
            HRESULT hr;
            string nameResult;

            if ((hr = TryGetAppDomainName(addr, out nameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return nameResult;
        }

        public HRESULT TryGetAppDomainName(CLRDATA_ADDRESS addr, out string nameResult)
        {
            /*HRESULT GetAppDomainName(
            CLRDATA_ADDRESS addr,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            out int pNeeded);*/
            int count = 0;
            StringBuilder name = null;
            int pNeeded;
            HRESULT hr = Raw.GetAppDomainName(addr, count, name, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            name = new StringBuilder(pNeeded);
            hr = Raw.GetAppDomainName(addr, count, name, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                nameResult = name.ToString();

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
            HRESULT hr;
            CLRDATA_ADDRESS domain;

            if ((hr = TryGetDomainFromContext(context, out domain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return domain;
        }

        public HRESULT TryGetDomainFromContext(CLRDATA_ADDRESS context, out CLRDATA_ADDRESS domain)
        {
            /*HRESULT GetDomainFromContext(
            CLRDATA_ADDRESS context,
            out CLRDATA_ADDRESS domain);*/
            return Raw.GetDomainFromContext(context, out domain);
        }

        #endregion
        #region GetAssemblyList

        public CLRDATA_ADDRESS[] GetAssemblyList(CLRDATA_ADDRESS appDomain)
        {
            HRESULT hr;
            CLRDATA_ADDRESS[] valuesResult;

            if ((hr = TryGetAssemblyList(appDomain, out valuesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return valuesResult;
        }

        public HRESULT TryGetAssemblyList(CLRDATA_ADDRESS appDomain, out CLRDATA_ADDRESS[] valuesResult)
        {
            /*HRESULT GetAssemblyList(
            CLRDATA_ADDRESS appDomain,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] values,
            [Out] out int pNeeded);*/
            int count = 0;
            CLRDATA_ADDRESS[] values = null;
            int pNeeded;
            HRESULT hr = Raw.GetAssemblyList(appDomain, count, values, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            values = new CLRDATA_ADDRESS[pNeeded];
            hr = Raw.GetAssemblyList(appDomain, count, values, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                valuesResult = values;

                return hr;
            }

            fail:
            valuesResult = default(CLRDATA_ADDRESS[]);

            return hr;
        }

        #endregion
        #region GetAssemblyData

        public DacpAssemblyData GetAssemblyData(CLRDATA_ADDRESS baseDomainPtr, CLRDATA_ADDRESS assembly)
        {
            HRESULT hr;
            DacpAssemblyData data;

            if ((hr = TryGetAssemblyData(baseDomainPtr, assembly, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetAssemblyData(CLRDATA_ADDRESS baseDomainPtr, CLRDATA_ADDRESS assembly, out DacpAssemblyData data)
        {
            /*HRESULT GetAssemblyData(
            CLRDATA_ADDRESS baseDomainPtr,
            CLRDATA_ADDRESS assembly,
            out DacpAssemblyData data);*/
            return Raw.GetAssemblyData(baseDomainPtr, assembly, out data);
        }

        #endregion
        #region GetAssemblyName

        public string GetAssemblyName(CLRDATA_ADDRESS assembly)
        {
            HRESULT hr;
            string nameResult;

            if ((hr = TryGetAssemblyName(assembly, out nameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return nameResult;
        }

        public HRESULT TryGetAssemblyName(CLRDATA_ADDRESS assembly, out string nameResult)
        {
            /*HRESULT GetAssemblyName(
            CLRDATA_ADDRESS assembly,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            out int pNeeded);*/
            int count = 0;
            StringBuilder name = null;
            int pNeeded;
            HRESULT hr = Raw.GetAssemblyName(assembly, count, name, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            name = new StringBuilder(pNeeded);
            hr = Raw.GetAssemblyName(assembly, count, name, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                nameResult = name.ToString();

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
            HRESULT hr;
            XCLRDataModule modResult;

            if ((hr = TryGetModule(addr, out modResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return modResult;
        }

        public HRESULT TryGetModule(CLRDATA_ADDRESS addr, out XCLRDataModule modResult)
        {
            /*HRESULT GetModule(
            CLRDATA_ADDRESS addr,
            out IXCLRDataModule mod);*/
            IXCLRDataModule mod;
            HRESULT hr = Raw.GetModule(addr, out mod);

            if (hr == HRESULT.S_OK)
                modResult = new XCLRDataModule(mod);
            else
                modResult = default(XCLRDataModule);

            return hr;
        }

        #endregion
        #region GetModuleData

        public DacpModuleData GetModuleData(CLRDATA_ADDRESS moduleAddr)
        {
            HRESULT hr;
            DacpModuleData data;

            if ((hr = TryGetModuleData(moduleAddr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetModuleData(CLRDATA_ADDRESS moduleAddr, out DacpModuleData data)
        {
            /*HRESULT GetModuleData(
            CLRDATA_ADDRESS moduleAddr,
            out DacpModuleData data);*/
            return Raw.GetModuleData(moduleAddr, out data);
        }

        #endregion
        #region TraverseModuleMap

        public void TraverseModuleMap(ModuleMapType mmt, CLRDATA_ADDRESS moduleAddr, MODULEMAPTRAVERSE pCallback, IntPtr token)
        {
            HRESULT hr;

            if ((hr = TryTraverseModuleMap(mmt, moduleAddr, pCallback, token)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryTraverseModuleMap(ModuleMapType mmt, CLRDATA_ADDRESS moduleAddr, MODULEMAPTRAVERSE pCallback, IntPtr token)
        {
            /*HRESULT TraverseModuleMap(
            ModuleMapType mmt,
            CLRDATA_ADDRESS moduleAddr,
            [MarshalAs(UnmanagedType.FunctionPtr)] MODULEMAPTRAVERSE pCallback,
            IntPtr token);*/
            return Raw.TraverseModuleMap(mmt, moduleAddr, pCallback, token);
        }

        #endregion
        #region GetAssemblyModuleList

        public CLRDATA_ADDRESS[] GetAssemblyModuleList(CLRDATA_ADDRESS assembly)
        {
            HRESULT hr;
            CLRDATA_ADDRESS[] modulesResult;

            if ((hr = TryGetAssemblyModuleList(assembly, out modulesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return modulesResult;
        }

        public HRESULT TryGetAssemblyModuleList(CLRDATA_ADDRESS assembly, out CLRDATA_ADDRESS[] modulesResult)
        {
            /*HRESULT GetAssemblyModuleList(
            CLRDATA_ADDRESS assembly,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] modules,
            out int pNeeded);*/
            int count = 0;
            CLRDATA_ADDRESS[] modules = null;
            int pNeeded;
            HRESULT hr = Raw.GetAssemblyModuleList(assembly, count, modules, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            modules = new CLRDATA_ADDRESS[pNeeded];
            hr = Raw.GetAssemblyModuleList(assembly, count, modules, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                modulesResult = modules;

                return hr;
            }

            fail:
            modulesResult = default(CLRDATA_ADDRESS[]);

            return hr;
        }

        #endregion
        #region GetILForModule

        public CLRDATA_ADDRESS GetILForModule(CLRDATA_ADDRESS moduleAddr, int rva)
        {
            HRESULT hr;
            CLRDATA_ADDRESS il;

            if ((hr = TryGetILForModule(moduleAddr, rva, out il)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return il;
        }

        public HRESULT TryGetILForModule(CLRDATA_ADDRESS moduleAddr, int rva, out CLRDATA_ADDRESS il)
        {
            /*HRESULT GetILForModule(
            CLRDATA_ADDRESS moduleAddr,
            int rva,
            out CLRDATA_ADDRESS il);*/
            return Raw.GetILForModule(moduleAddr, rva, out il);
        }

        #endregion
        #region GetThreadData

        public DacpThreadData GetThreadData(CLRDATA_ADDRESS thread)
        {
            HRESULT hr;
            DacpThreadData data;

            if ((hr = TryGetThreadData(thread, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetThreadData(CLRDATA_ADDRESS thread, out DacpThreadData data)
        {
            /*HRESULT GetThreadData(
            CLRDATA_ADDRESS thread,
            out DacpThreadData data);*/
            return Raw.GetThreadData(thread, out data);
        }

        #endregion
        #region GetThreadFromThinlockID

        public CLRDATA_ADDRESS GetThreadFromThinlockID(int thinLockId)
        {
            HRESULT hr;
            CLRDATA_ADDRESS pThread;

            if ((hr = TryGetThreadFromThinlockID(thinLockId, out pThread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pThread;
        }

        public HRESULT TryGetThreadFromThinlockID(int thinLockId, out CLRDATA_ADDRESS pThread)
        {
            /*HRESULT GetThreadFromThinlockID(
            int thinLockId,
            out CLRDATA_ADDRESS pThread);*/
            return Raw.GetThreadFromThinlockID(thinLockId, out pThread);
        }

        #endregion
        #region GetStackLimits

        public GetStackLimitsResult GetStackLimits(CLRDATA_ADDRESS threadPtr)
        {
            HRESULT hr;
            GetStackLimitsResult result;

            if ((hr = TryGetStackLimits(threadPtr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetStackLimits(CLRDATA_ADDRESS threadPtr, out GetStackLimitsResult result)
        {
            /*HRESULT GetStackLimits(
            CLRDATA_ADDRESS threadPtr,
            out CLRDATA_ADDRESS lower,
            out CLRDATA_ADDRESS upper,
            out CLRDATA_ADDRESS fp);*/
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

        public GetMethodDescDataResult GetMethodDescData(CLRDATA_ADDRESS methodDesc, CLRDATA_ADDRESS ip)
        {
            HRESULT hr;
            GetMethodDescDataResult result;

            if ((hr = TryGetMethodDescData(methodDesc, ip, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMethodDescData(CLRDATA_ADDRESS methodDesc, CLRDATA_ADDRESS ip, out GetMethodDescDataResult result)
        {
            /*HRESULT GetMethodDescData(
            CLRDATA_ADDRESS methodDesc,
            CLRDATA_ADDRESS ip,
            out DacpMethodDescData data,
            int cRevertedRejitVersions,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpReJitData[] rgRevertedRejitData,
            out int pcNeededRevertedRejitData);*/
            DacpMethodDescData data;
            int cRevertedRejitVersions = 0;
            DacpReJitData[] rgRevertedRejitData = null;
            int pcNeededRevertedRejitData;
            HRESULT hr = Raw.GetMethodDescData(methodDesc, ip, out data, cRevertedRejitVersions, rgRevertedRejitData, out pcNeededRevertedRejitData);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cRevertedRejitVersions = pcNeededRevertedRejitData;
            rgRevertedRejitData = new DacpReJitData[pcNeededRevertedRejitData];
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

        public CLRDATA_ADDRESS GetMethodDescPtrFromIP(CLRDATA_ADDRESS ip)
        {
            HRESULT hr;
            CLRDATA_ADDRESS ppMD;

            if ((hr = TryGetMethodDescPtrFromIP(ip, out ppMD)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppMD;
        }

        public HRESULT TryGetMethodDescPtrFromIP(CLRDATA_ADDRESS ip, out CLRDATA_ADDRESS ppMD)
        {
            /*HRESULT GetMethodDescPtrFromIP(
            CLRDATA_ADDRESS ip,
            out CLRDATA_ADDRESS ppMD);*/
            return Raw.GetMethodDescPtrFromIP(ip, out ppMD);
        }

        #endregion
        #region GetMethodDescName

        public string GetMethodDescName(CLRDATA_ADDRESS methodDesc)
        {
            HRESULT hr;
            string nameResult;

            if ((hr = TryGetMethodDescName(methodDesc, out nameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return nameResult;
        }

        public HRESULT TryGetMethodDescName(CLRDATA_ADDRESS methodDesc, out string nameResult)
        {
            /*HRESULT GetMethodDescName(
            CLRDATA_ADDRESS methodDesc,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            out int pNeeded);*/
            int count = 0;
            StringBuilder name = null;
            int pNeeded;
            HRESULT hr = Raw.GetMethodDescName(methodDesc, count, name, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            name = new StringBuilder(pNeeded);
            hr = Raw.GetMethodDescName(methodDesc, count, name, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                nameResult = name.ToString();

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
            HRESULT hr;
            CLRDATA_ADDRESS ppMD;

            if ((hr = TryGetMethodDescPtrFromFrame(frameAddr, out ppMD)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppMD;
        }

        public HRESULT TryGetMethodDescPtrFromFrame(CLRDATA_ADDRESS frameAddr, out CLRDATA_ADDRESS ppMD)
        {
            /*HRESULT GetMethodDescPtrFromFrame(
            CLRDATA_ADDRESS frameAddr,
            out CLRDATA_ADDRESS ppMD);*/
            return Raw.GetMethodDescPtrFromFrame(frameAddr, out ppMD);
        }

        #endregion
        #region GetMethodDescFromToken

        public CLRDATA_ADDRESS GetMethodDescFromToken(CLRDATA_ADDRESS moduleAddr, mdToken token)
        {
            HRESULT hr;
            CLRDATA_ADDRESS methodDesc;

            if ((hr = TryGetMethodDescFromToken(moduleAddr, token, out methodDesc)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return methodDesc;
        }

        public HRESULT TryGetMethodDescFromToken(CLRDATA_ADDRESS moduleAddr, mdToken token, out CLRDATA_ADDRESS methodDesc)
        {
            /*HRESULT GetMethodDescFromToken(
            CLRDATA_ADDRESS moduleAddr,
            mdToken token,
            out CLRDATA_ADDRESS methodDesc);*/
            return Raw.GetMethodDescFromToken(moduleAddr, token, out methodDesc);
        }

        #endregion
        #region GetMethodDescTransparencyData

        public DacpMethodDescTransparencyData GetMethodDescTransparencyData(CLRDATA_ADDRESS methodDesc)
        {
            HRESULT hr;
            DacpMethodDescTransparencyData data;

            if ((hr = TryGetMethodDescTransparencyData(methodDesc, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetMethodDescTransparencyData(CLRDATA_ADDRESS methodDesc, out DacpMethodDescTransparencyData data)
        {
            /*HRESULT GetMethodDescTransparencyData(
            CLRDATA_ADDRESS methodDesc,
            out DacpMethodDescTransparencyData data);*/
            return Raw.GetMethodDescTransparencyData(methodDesc, out data);
        }

        #endregion
        #region GetCodeHeaderData

        public DacpCodeHeaderData GetCodeHeaderData(CLRDATA_ADDRESS ip)
        {
            HRESULT hr;
            DacpCodeHeaderData data;

            if ((hr = TryGetCodeHeaderData(ip, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetCodeHeaderData(CLRDATA_ADDRESS ip, out DacpCodeHeaderData data)
        {
            /*HRESULT GetCodeHeaderData(
            CLRDATA_ADDRESS ip,
            out DacpCodeHeaderData data);*/
            return Raw.GetCodeHeaderData(ip, out data);
        }

        #endregion
        #region GetJitHelperFunctionName

        public string GetJitHelperFunctionName(CLRDATA_ADDRESS ip)
        {
            HRESULT hr;
            string nameResult;

            if ((hr = TryGetJitHelperFunctionName(ip, out nameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return nameResult;
        }

        public HRESULT TryGetJitHelperFunctionName(CLRDATA_ADDRESS ip, out string nameResult)
        {
            /*HRESULT GetJitHelperFunctionName(
            CLRDATA_ADDRESS ip,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            out int pNeeded);*/
            int count = 0;
            StringBuilder name = null;
            int pNeeded;
            HRESULT hr = Raw.GetJitHelperFunctionName(ip, count, name, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            name = new StringBuilder(pNeeded);
            hr = Raw.GetJitHelperFunctionName(ip, count, name, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                nameResult = name.ToString();

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
            HRESULT hr;
            GetJumpThunkTargetResult result;

            if ((hr = TryGetJumpThunkTarget(ctx, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetJumpThunkTarget(IntPtr ctx, out GetJumpThunkTargetResult result)
        {
            /*HRESULT GetJumpThunkTarget(
            IntPtr ctx,
            out CLRDATA_ADDRESS targetIP,
            out CLRDATA_ADDRESS targetMD);*/
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
            HRESULT hr;
            DacpWorkRequestData data;

            if ((hr = TryGetWorkRequestData(addrWorkRequest, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetWorkRequestData(CLRDATA_ADDRESS addrWorkRequest, out DacpWorkRequestData data)
        {
            /*HRESULT GetWorkRequestData(
            CLRDATA_ADDRESS addrWorkRequest,
            out DacpWorkRequestData data);*/
            return Raw.GetWorkRequestData(addrWorkRequest, out data);
        }

        #endregion
        #region GetHillClimbingLogEntry

        public DacpHillClimbingLogEntry GetHillClimbingLogEntry(CLRDATA_ADDRESS addr)
        {
            HRESULT hr;
            DacpHillClimbingLogEntry data;

            if ((hr = TryGetHillClimbingLogEntry(addr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetHillClimbingLogEntry(CLRDATA_ADDRESS addr, out DacpHillClimbingLogEntry data)
        {
            /*HRESULT GetHillClimbingLogEntry(
            CLRDATA_ADDRESS addr,
            out DacpHillClimbingLogEntry data);*/
            return Raw.GetHillClimbingLogEntry(addr, out data);
        }

        #endregion
        #region GetObjectData

        public DacpObjectData GetObjectData(CLRDATA_ADDRESS objAddr)
        {
            HRESULT hr;
            DacpObjectData data;

            if ((hr = TryGetObjectData(objAddr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetObjectData(CLRDATA_ADDRESS objAddr, out DacpObjectData data)
        {
            /*HRESULT GetObjectData(
            CLRDATA_ADDRESS objAddr,
            out DacpObjectData data);*/
            return Raw.GetObjectData(objAddr, out data);
        }

        #endregion
        #region GetObjectStringData

        public string GetObjectStringData(CLRDATA_ADDRESS obj)
        {
            HRESULT hr;
            string stringDataResult;

            if ((hr = TryGetObjectStringData(obj, out stringDataResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return stringDataResult;
        }

        public HRESULT TryGetObjectStringData(CLRDATA_ADDRESS obj, out string stringDataResult)
        {
            /*HRESULT GetObjectStringData(
            CLRDATA_ADDRESS obj,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder stringData,
            out int pNeeded);*/
            int count = 0;
            StringBuilder stringData = null;
            int pNeeded;
            HRESULT hr = Raw.GetObjectStringData(obj, count, stringData, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            stringData = new StringBuilder(pNeeded);
            hr = Raw.GetObjectStringData(obj, count, stringData, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                stringDataResult = stringData.ToString();

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
            HRESULT hr;
            string classNameResult;

            if ((hr = TryGetObjectClassName(obj, out classNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return classNameResult;
        }

        public HRESULT TryGetObjectClassName(CLRDATA_ADDRESS obj, out string classNameResult)
        {
            /*HRESULT GetObjectClassName(
            CLRDATA_ADDRESS obj,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder className,
            out int pNeeded);*/
            int count = 0;
            StringBuilder className = null;
            int pNeeded;
            HRESULT hr = Raw.GetObjectClassName(obj, count, className, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            className = new StringBuilder(pNeeded);
            hr = Raw.GetObjectClassName(obj, count, className, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                classNameResult = className.ToString();

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
            HRESULT hr;
            string mtNameResult;

            if ((hr = TryGetMethodTableName(mt, out mtNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return mtNameResult;
        }

        public HRESULT TryGetMethodTableName(CLRDATA_ADDRESS mt, out string mtNameResult)
        {
            /*HRESULT GetMethodTableName(
            CLRDATA_ADDRESS mt,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder mtName,
            out int pNeeded);*/
            int count = 0;
            StringBuilder mtName = null;
            int pNeeded;
            HRESULT hr = Raw.GetMethodTableName(mt, count, mtName, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            mtName = new StringBuilder(pNeeded);
            hr = Raw.GetMethodTableName(mt, count, mtName, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                mtNameResult = mtName.ToString();

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
            HRESULT hr;
            DacpMethodTableData data;

            if ((hr = TryGetMethodTableData(mt, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetMethodTableData(CLRDATA_ADDRESS mt, out DacpMethodTableData data)
        {
            /*HRESULT GetMethodTableData(
            CLRDATA_ADDRESS mt,
            out DacpMethodTableData data);*/
            return Raw.GetMethodTableData(mt, out data);
        }

        #endregion
        #region GetMethodTableSlot

        public CLRDATA_ADDRESS GetMethodTableSlot(CLRDATA_ADDRESS mt, int slot)
        {
            HRESULT hr;
            CLRDATA_ADDRESS value;

            if ((hr = TryGetMethodTableSlot(mt, slot, out value)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return value;
        }

        public HRESULT TryGetMethodTableSlot(CLRDATA_ADDRESS mt, int slot, out CLRDATA_ADDRESS value)
        {
            /*HRESULT GetMethodTableSlot(
            CLRDATA_ADDRESS mt,
            int slot,
            out CLRDATA_ADDRESS value);*/
            return Raw.GetMethodTableSlot(mt, slot, out value);
        }

        #endregion
        #region GetMethodTableFieldData

        public DacpMethodTableFieldData GetMethodTableFieldData(CLRDATA_ADDRESS mt)
        {
            HRESULT hr;
            DacpMethodTableFieldData data;

            if ((hr = TryGetMethodTableFieldData(mt, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetMethodTableFieldData(CLRDATA_ADDRESS mt, out DacpMethodTableFieldData data)
        {
            /*HRESULT GetMethodTableFieldData(
            CLRDATA_ADDRESS mt,
            out DacpMethodTableFieldData data);*/
            return Raw.GetMethodTableFieldData(mt, out data);
        }

        #endregion
        #region GetMethodTableTransparencyData

        public DacpMethodTableTransparencyData GetMethodTableTransparencyData(CLRDATA_ADDRESS mt)
        {
            HRESULT hr;
            DacpMethodTableTransparencyData data;

            if ((hr = TryGetMethodTableTransparencyData(mt, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetMethodTableTransparencyData(CLRDATA_ADDRESS mt, out DacpMethodTableTransparencyData data)
        {
            /*HRESULT GetMethodTableTransparencyData(
            CLRDATA_ADDRESS mt,
            out DacpMethodTableTransparencyData data);*/
            return Raw.GetMethodTableTransparencyData(mt, out data);
        }

        #endregion
        #region GetMethodTableForEEClass

        public CLRDATA_ADDRESS GetMethodTableForEEClass(CLRDATA_ADDRESS eeClass)
        {
            HRESULT hr;
            CLRDATA_ADDRESS value;

            if ((hr = TryGetMethodTableForEEClass(eeClass, out value)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return value;
        }

        public HRESULT TryGetMethodTableForEEClass(CLRDATA_ADDRESS eeClass, out CLRDATA_ADDRESS value)
        {
            /*HRESULT GetMethodTableForEEClass(
            CLRDATA_ADDRESS eeClass,
            out CLRDATA_ADDRESS value);*/
            return Raw.GetMethodTableForEEClass(eeClass, out value);
        }

        #endregion
        #region GetFieldDescData

        public DacpFieldDescData GetFieldDescData(CLRDATA_ADDRESS fieldDesc)
        {
            HRESULT hr;
            DacpFieldDescData data;

            if ((hr = TryGetFieldDescData(fieldDesc, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetFieldDescData(CLRDATA_ADDRESS fieldDesc, out DacpFieldDescData data)
        {
            /*HRESULT GetFieldDescData(
            CLRDATA_ADDRESS fieldDesc,
            out DacpFieldDescData data);*/
            return Raw.GetFieldDescData(fieldDesc, out data);
        }

        #endregion
        #region GetFrameName

        public string GetFrameName(CLRDATA_ADDRESS vtable)
        {
            HRESULT hr;
            string frameNameResult;

            if ((hr = TryGetFrameName(vtable, out frameNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return frameNameResult;
        }

        public HRESULT TryGetFrameName(CLRDATA_ADDRESS vtable, out string frameNameResult)
        {
            /*HRESULT GetFrameName(
            CLRDATA_ADDRESS vtable,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder frameName,
            out int pNeeded);*/
            int count = 0;
            StringBuilder frameName = null;
            int pNeeded;
            HRESULT hr = Raw.GetFrameName(vtable, count, frameName, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            frameName = new StringBuilder(pNeeded);
            hr = Raw.GetFrameName(vtable, count, frameName, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                frameNameResult = frameName.ToString();

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
            HRESULT hr;
            CLRDATA_ADDRESS _base;

            if ((hr = TryGetPEFileBase(addr, out _base)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return _base;
        }

        public HRESULT TryGetPEFileBase(CLRDATA_ADDRESS addr, out CLRDATA_ADDRESS _base)
        {
            /*HRESULT GetPEFileBase(
            CLRDATA_ADDRESS addr,
            out CLRDATA_ADDRESS _base);*/
            return Raw.GetPEFileBase(addr, out _base);
        }

        #endregion
        #region GetPEFileName

        public string GetPEFileName(CLRDATA_ADDRESS addr)
        {
            HRESULT hr;
            string fileNameResult;

            if ((hr = TryGetPEFileName(addr, out fileNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return fileNameResult;
        }

        public HRESULT TryGetPEFileName(CLRDATA_ADDRESS addr, out string fileNameResult)
        {
            /*HRESULT GetPEFileName(
            CLRDATA_ADDRESS addr,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder fileName,
            out int pNeeded);*/
            int count = 0;
            StringBuilder fileName = null;
            int pNeeded;
            HRESULT hr = Raw.GetPEFileName(addr, count, fileName, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            fileName = new StringBuilder(pNeeded);
            hr = Raw.GetPEFileName(addr, count, fileName, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                fileNameResult = fileName.ToString();

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
            HRESULT hr;
            DacpGcHeapDetails details;

            if ((hr = TryGetGCHeapDetails(heap, out details)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return details;
        }

        public HRESULT TryGetGCHeapDetails(CLRDATA_ADDRESS heap, out DacpGcHeapDetails details)
        {
            /*HRESULT GetGCHeapDetails(
            CLRDATA_ADDRESS heap,
            out DacpGcHeapDetails details);*/
            return Raw.GetGCHeapDetails(heap, out details);
        }

        #endregion
        #region GetHeapSegmentData

        public DacpHeapSegmentData GetHeapSegmentData(CLRDATA_ADDRESS seg)
        {
            HRESULT hr;
            DacpHeapSegmentData data;

            if ((hr = TryGetHeapSegmentData(seg, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetHeapSegmentData(CLRDATA_ADDRESS seg, out DacpHeapSegmentData data)
        {
            /*HRESULT GetHeapSegmentData(
            CLRDATA_ADDRESS seg,
            out DacpHeapSegmentData data);*/
            return Raw.GetHeapSegmentData(seg, out data);
        }

        #endregion
        #region GetOOMData

        public DacpOomData GetOOMData(CLRDATA_ADDRESS oomAddr)
        {
            HRESULT hr;
            DacpOomData data;

            if ((hr = TryGetOOMData(oomAddr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetOOMData(CLRDATA_ADDRESS oomAddr, out DacpOomData data)
        {
            /*HRESULT GetOOMData(
            CLRDATA_ADDRESS oomAddr,
            out DacpOomData data);*/
            return Raw.GetOOMData(oomAddr, out data);
        }

        #endregion
        #region GetHeapAnalyzeData

        public DacpGcHeapAnalyzeData GetHeapAnalyzeData(CLRDATA_ADDRESS addr)
        {
            HRESULT hr;
            DacpGcHeapAnalyzeData data;

            if ((hr = TryGetHeapAnalyzeData(addr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetHeapAnalyzeData(CLRDATA_ADDRESS addr, out DacpGcHeapAnalyzeData data)
        {
            /*HRESULT GetHeapAnalyzeData(
            CLRDATA_ADDRESS addr,
            out DacpGcHeapAnalyzeData data);*/
            return Raw.GetHeapAnalyzeData(addr, out data);
        }

        #endregion
        #region GetDomainLocalModuleData

        public DacpDomainLocalModuleData GetDomainLocalModuleData(CLRDATA_ADDRESS addr)
        {
            HRESULT hr;
            DacpDomainLocalModuleData data;

            if ((hr = TryGetDomainLocalModuleData(addr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetDomainLocalModuleData(CLRDATA_ADDRESS addr, out DacpDomainLocalModuleData data)
        {
            /*HRESULT GetDomainLocalModuleData(
            CLRDATA_ADDRESS addr,
            out DacpDomainLocalModuleData data);*/
            return Raw.GetDomainLocalModuleData(addr, out data);
        }

        #endregion
        #region GetDomainLocalModuleDataFromAppDomain

        public DacpDomainLocalModuleData GetDomainLocalModuleDataFromAppDomain(CLRDATA_ADDRESS appDomainAddr, int moduleID)
        {
            HRESULT hr;
            DacpDomainLocalModuleData data;

            if ((hr = TryGetDomainLocalModuleDataFromAppDomain(appDomainAddr, moduleID, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetDomainLocalModuleDataFromAppDomain(CLRDATA_ADDRESS appDomainAddr, int moduleID, out DacpDomainLocalModuleData data)
        {
            /*HRESULT GetDomainLocalModuleDataFromAppDomain(
            CLRDATA_ADDRESS appDomainAddr,
            int moduleID,
            out DacpDomainLocalModuleData data);*/
            return Raw.GetDomainLocalModuleDataFromAppDomain(appDomainAddr, moduleID, out data);
        }

        #endregion
        #region GetDomainLocalModuleDataFromModule

        public DacpDomainLocalModuleData GetDomainLocalModuleDataFromModule(CLRDATA_ADDRESS moduleAddr)
        {
            HRESULT hr;
            DacpDomainLocalModuleData data;

            if ((hr = TryGetDomainLocalModuleDataFromModule(moduleAddr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetDomainLocalModuleDataFromModule(CLRDATA_ADDRESS moduleAddr, out DacpDomainLocalModuleData data)
        {
            /*HRESULT GetDomainLocalModuleDataFromModule(
            CLRDATA_ADDRESS moduleAddr,
            out DacpDomainLocalModuleData data);*/
            return Raw.GetDomainLocalModuleDataFromModule(moduleAddr, out data);
        }

        #endregion
        #region GetThreadLocalModuleData

        public DacpThreadLocalModuleData GetThreadLocalModuleData(CLRDATA_ADDRESS thread, int index)
        {
            HRESULT hr;
            DacpThreadLocalModuleData data;

            if ((hr = TryGetThreadLocalModuleData(thread, index, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetThreadLocalModuleData(CLRDATA_ADDRESS thread, int index, out DacpThreadLocalModuleData data)
        {
            /*HRESULT GetThreadLocalModuleData(
            CLRDATA_ADDRESS thread,
            int index,
            out DacpThreadLocalModuleData data);*/
            return Raw.GetThreadLocalModuleData(thread, index, out data);
        }

        #endregion
        #region GetSyncBlockData

        public DacpSyncBlockData GetSyncBlockData(int number)
        {
            HRESULT hr;
            DacpSyncBlockData data;

            if ((hr = TryGetSyncBlockData(number, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetSyncBlockData(int number, out DacpSyncBlockData data)
        {
            /*HRESULT GetSyncBlockData(
            int number,
            out DacpSyncBlockData data);*/
            return Raw.GetSyncBlockData(number, out data);
        }

        #endregion
        #region GetSyncBlockCleanupData

        public DacpSyncBlockCleanupData GetSyncBlockCleanupData(CLRDATA_ADDRESS addr)
        {
            HRESULT hr;
            DacpSyncBlockCleanupData data;

            if ((hr = TryGetSyncBlockCleanupData(addr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetSyncBlockCleanupData(CLRDATA_ADDRESS addr, out DacpSyncBlockCleanupData data)
        {
            /*HRESULT GetSyncBlockCleanupData(
            CLRDATA_ADDRESS addr,
            out DacpSyncBlockCleanupData data);*/
            return Raw.GetSyncBlockCleanupData(addr, out data);
        }

        #endregion
        #region GetHandleEnumForTypes

        public SOSHandleEnum GetHandleEnumForTypes(int[] types, int count)
        {
            HRESULT hr;
            SOSHandleEnum ppHandleEnumResult;

            if ((hr = TryGetHandleEnumForTypes(types, count, out ppHandleEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppHandleEnumResult;
        }

        public HRESULT TryGetHandleEnumForTypes(int[] types, int count, out SOSHandleEnum ppHandleEnumResult)
        {
            /*HRESULT GetHandleEnumForTypes(
            [In, MarshalAs(UnmanagedType.LPArray)] int[] types,
            int count,
            out ISOSHandleEnum ppHandleEnum);*/
            ISOSHandleEnum ppHandleEnum;
            HRESULT hr = Raw.GetHandleEnumForTypes(types, count, out ppHandleEnum);

            if (hr == HRESULT.S_OK)
                ppHandleEnumResult = new SOSHandleEnum(ppHandleEnum);
            else
                ppHandleEnumResult = default(SOSHandleEnum);

            return hr;
        }

        #endregion
        #region GetHandleEnumForGC

        public SOSHandleEnum GetHandleEnumForGC(int gen)
        {
            HRESULT hr;
            SOSHandleEnum ppHandleEnumResult;

            if ((hr = TryGetHandleEnumForGC(gen, out ppHandleEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppHandleEnumResult;
        }

        public HRESULT TryGetHandleEnumForGC(int gen, out SOSHandleEnum ppHandleEnumResult)
        {
            /*HRESULT GetHandleEnumForGC(
            int gen,
            out ISOSHandleEnum ppHandleEnum);*/
            ISOSHandleEnum ppHandleEnum;
            HRESULT hr = Raw.GetHandleEnumForGC(gen, out ppHandleEnum);

            if (hr == HRESULT.S_OK)
                ppHandleEnumResult = new SOSHandleEnum(ppHandleEnum);
            else
                ppHandleEnumResult = default(SOSHandleEnum);

            return hr;
        }

        #endregion
        #region TraverseEHInfo

        public void TraverseEHInfo(CLRDATA_ADDRESS ip, DUMPEHINFO pCallback, IntPtr token)
        {
            HRESULT hr;

            if ((hr = TryTraverseEHInfo(ip, pCallback, token)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryTraverseEHInfo(CLRDATA_ADDRESS ip, DUMPEHINFO pCallback, IntPtr token)
        {
            /*HRESULT TraverseEHInfo(
            CLRDATA_ADDRESS ip,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] DUMPEHINFO pCallback,
            IntPtr token);*/
            return Raw.TraverseEHInfo(ip, pCallback, token);
        }

        #endregion
        #region GetNestedExceptionData

        public GetNestedExceptionDataResult GetNestedExceptionData(CLRDATA_ADDRESS exception)
        {
            HRESULT hr;
            GetNestedExceptionDataResult result;

            if ((hr = TryGetNestedExceptionData(exception, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetNestedExceptionData(CLRDATA_ADDRESS exception, out GetNestedExceptionDataResult result)
        {
            /*HRESULT GetNestedExceptionData(
            CLRDATA_ADDRESS exception,
            out CLRDATA_ADDRESS exceptionObject,
            out CLRDATA_ADDRESS nextNestedException);*/
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
            HRESULT hr;

            if ((hr = TryTraverseLoaderHeap(loaderHeapAddr, pCallback)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryTraverseLoaderHeap(CLRDATA_ADDRESS loaderHeapAddr, VISITHEAP pCallback)
        {
            /*HRESULT TraverseLoaderHeap(
            CLRDATA_ADDRESS loaderHeapAddr,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITHEAP pCallback);*/
            return Raw.TraverseLoaderHeap(loaderHeapAddr, pCallback);
        }

        #endregion
        #region GetCodeHeapList

        public DacpJitCodeHeapInfo[] GetCodeHeapList(CLRDATA_ADDRESS jitManager)
        {
            HRESULT hr;
            DacpJitCodeHeapInfo[] codeHeapsResult;

            if ((hr = TryGetCodeHeapList(jitManager, out codeHeapsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return codeHeapsResult;
        }

        public HRESULT TryGetCodeHeapList(CLRDATA_ADDRESS jitManager, out DacpJitCodeHeapInfo[] codeHeapsResult)
        {
            /*HRESULT GetCodeHeapList(
            CLRDATA_ADDRESS jitManager,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpJitCodeHeapInfo[] codeHeaps,
            out int pNeeded);*/
            int count = 0;
            DacpJitCodeHeapInfo[] codeHeaps = null;
            int pNeeded;
            HRESULT hr = Raw.GetCodeHeapList(jitManager, count, codeHeaps, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            codeHeaps = new DacpJitCodeHeapInfo[pNeeded];
            hr = Raw.GetCodeHeapList(jitManager, count, codeHeaps, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                codeHeapsResult = codeHeaps;

                return hr;
            }

            fail:
            codeHeapsResult = default(DacpJitCodeHeapInfo[]);

            return hr;
        }

        #endregion
        #region TraverseVirtCallStubHeap

        public void TraverseVirtCallStubHeap(CLRDATA_ADDRESS pAppDomain, VCSHeapType heaptype, VISITHEAP pCallback)
        {
            HRESULT hr;

            if ((hr = TryTraverseVirtCallStubHeap(pAppDomain, heaptype, pCallback)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryTraverseVirtCallStubHeap(CLRDATA_ADDRESS pAppDomain, VCSHeapType heaptype, VISITHEAP pCallback)
        {
            /*HRESULT TraverseVirtCallStubHeap(
            CLRDATA_ADDRESS pAppDomain,
            VCSHeapType heaptype,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITHEAP pCallback);*/
            return Raw.TraverseVirtCallStubHeap(pAppDomain, heaptype, pCallback);
        }

        #endregion
        #region GetClrWatsonBuckets

        public void GetClrWatsonBuckets(CLRDATA_ADDRESS thread, IntPtr pGenericModeBlock)
        {
            HRESULT hr;

            if ((hr = TryGetClrWatsonBuckets(thread, pGenericModeBlock)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryGetClrWatsonBuckets(CLRDATA_ADDRESS thread, IntPtr pGenericModeBlock)
        {
            /*HRESULT GetClrWatsonBuckets(
            CLRDATA_ADDRESS thread,
            IntPtr pGenericModeBlock);*/
            return Raw.GetClrWatsonBuckets(thread, pGenericModeBlock);
        }

        #endregion
        #region GetRCWData

        public DacpRCWData GetRCWData(CLRDATA_ADDRESS addr)
        {
            HRESULT hr;
            DacpRCWData data;

            if ((hr = TryGetRCWData(addr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetRCWData(CLRDATA_ADDRESS addr, out DacpRCWData data)
        {
            /*HRESULT GetRCWData(
            CLRDATA_ADDRESS addr,
            out DacpRCWData data);*/
            return Raw.GetRCWData(addr, out data);
        }

        #endregion
        #region GetRCWInterfaces

        public DacpCOMInterfacePointerData[] GetRCWInterfaces(CLRDATA_ADDRESS rcw)
        {
            HRESULT hr;
            DacpCOMInterfacePointerData[] interfacesResult;

            if ((hr = TryGetRCWInterfaces(rcw, out interfacesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return interfacesResult;
        }

        public HRESULT TryGetRCWInterfaces(CLRDATA_ADDRESS rcw, out DacpCOMInterfacePointerData[] interfacesResult)
        {
            /*HRESULT GetRCWInterfaces(
            CLRDATA_ADDRESS rcw,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpCOMInterfacePointerData[] interfaces,
            out int pNeeded);*/
            int count = 0;
            DacpCOMInterfacePointerData[] interfaces = null;
            int pNeeded;
            HRESULT hr = Raw.GetRCWInterfaces(rcw, count, interfaces, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            interfaces = new DacpCOMInterfacePointerData[pNeeded];
            hr = Raw.GetRCWInterfaces(rcw, count, interfaces, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                interfacesResult = interfaces;

                return hr;
            }

            fail:
            interfacesResult = default(DacpCOMInterfacePointerData[]);

            return hr;
        }

        #endregion
        #region GetCCWData

        public DacpCCWData GetCCWData(CLRDATA_ADDRESS ccw)
        {
            HRESULT hr;
            DacpCCWData data;

            if ((hr = TryGetCCWData(ccw, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetCCWData(CLRDATA_ADDRESS ccw, out DacpCCWData data)
        {
            /*HRESULT GetCCWData(
            CLRDATA_ADDRESS ccw,
            out DacpCCWData data);*/
            return Raw.GetCCWData(ccw, out data);
        }

        #endregion
        #region GetCCWInterfaces

        public DacpCOMInterfacePointerData[] GetCCWInterfaces(CLRDATA_ADDRESS ccw)
        {
            HRESULT hr;
            DacpCOMInterfacePointerData[] interfacesResult;

            if ((hr = TryGetCCWInterfaces(ccw, out interfacesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return interfacesResult;
        }

        public HRESULT TryGetCCWInterfaces(CLRDATA_ADDRESS ccw, out DacpCOMInterfacePointerData[] interfacesResult)
        {
            /*HRESULT GetCCWInterfaces(
            CLRDATA_ADDRESS ccw,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpCOMInterfacePointerData[] interfaces,
            out int pNeeded);*/
            int count = 0;
            DacpCOMInterfacePointerData[] interfaces = null;
            int pNeeded;
            HRESULT hr = Raw.GetCCWInterfaces(ccw, count, interfaces, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            interfaces = new DacpCOMInterfacePointerData[pNeeded];
            hr = Raw.GetCCWInterfaces(ccw, count, interfaces, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                interfacesResult = interfaces;

                return hr;
            }

            fail:
            interfacesResult = default(DacpCOMInterfacePointerData[]);

            return hr;
        }

        #endregion
        #region TraverseRCWCleanupList

        public void TraverseRCWCleanupList(CLRDATA_ADDRESS cleanupListPtr, VISITRCWFORCLEANUP pCallback, IntPtr token)
        {
            HRESULT hr;

            if ((hr = TryTraverseRCWCleanupList(cleanupListPtr, pCallback, token)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryTraverseRCWCleanupList(CLRDATA_ADDRESS cleanupListPtr, VISITRCWFORCLEANUP pCallback, IntPtr token)
        {
            /*HRESULT TraverseRCWCleanupList(
            CLRDATA_ADDRESS cleanupListPtr,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] VISITRCWFORCLEANUP pCallback,
            IntPtr token);*/
            return Raw.TraverseRCWCleanupList(cleanupListPtr, pCallback, token);
        }

        #endregion
        #region GetStackReferences

        public SOSStackRefEnum GetStackReferences(int osThreadID)
        {
            HRESULT hr;
            SOSStackRefEnum ppEnumResult;

            if ((hr = TryGetStackReferences(osThreadID, out ppEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEnumResult;
        }

        public HRESULT TryGetStackReferences(int osThreadID, out SOSStackRefEnum ppEnumResult)
        {
            /*HRESULT GetStackReferences(
            [In] int osThreadID,
            [Out] out ISOSStackRefEnum ppEnum);*/
            ISOSStackRefEnum ppEnum;
            HRESULT hr = Raw.GetStackReferences(osThreadID, out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = new SOSStackRefEnum(ppEnum);
            else
                ppEnumResult = default(SOSStackRefEnum);

            return hr;
        }

        #endregion
        #region GetRegisterName

        public string GetRegisterName(int regName)
        {
            HRESULT hr;
            string bufferResult;

            if ((hr = TryGetRegisterName(regName, out bufferResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return bufferResult;
        }

        public HRESULT TryGetRegisterName(int regName, out string bufferResult)
        {
            /*HRESULT GetRegisterName(
            [In] int regName,
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder buffer,
            [Out] out int pNeeded);*/
            int count = 0;
            StringBuilder buffer = null;
            int pNeeded;
            HRESULT hr = Raw.GetRegisterName(regName, count, buffer, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            buffer = new StringBuilder(pNeeded);
            hr = Raw.GetRegisterName(regName, count, buffer, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

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
            HRESULT hr;
            DacpAllocData data;

            if ((hr = TryGetThreadAllocData(thread, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetThreadAllocData(CLRDATA_ADDRESS thread, out DacpAllocData data)
        {
            /*HRESULT GetThreadAllocData(
            CLRDATA_ADDRESS thread,
            out DacpAllocData data);*/
            return Raw.GetThreadAllocData(thread, out data);
        }

        #endregion
        #region GetHeapAllocData

        public GetHeapAllocDataResult GetHeapAllocData(int count)
        {
            HRESULT hr;
            GetHeapAllocDataResult result;

            if ((hr = TryGetHeapAllocData(count, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetHeapAllocData(int count, out GetHeapAllocDataResult result)
        {
            /*HRESULT GetHeapAllocData(
            int count,
            out DacpGenerationAllocData data,
            out int pNeeded);*/
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
            HRESULT hr;
            CLRDATA_ADDRESS[] valuesResult;

            if ((hr = TryGetFailedAssemblyList(appDomain, out valuesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return valuesResult;
        }

        public HRESULT TryGetFailedAssemblyList(CLRDATA_ADDRESS appDomain, out CLRDATA_ADDRESS[] valuesResult)
        {
            /*HRESULT GetFailedAssemblyList(
            CLRDATA_ADDRESS appDomain,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] values,
            out int pNeeded);*/
            int count = 0;
            CLRDATA_ADDRESS[] values = null;
            int pNeeded;
            HRESULT hr = Raw.GetFailedAssemblyList(appDomain, count, values, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            values = new CLRDATA_ADDRESS[pNeeded];
            hr = Raw.GetFailedAssemblyList(appDomain, count, values, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                valuesResult = values;

                return hr;
            }

            fail:
            valuesResult = default(CLRDATA_ADDRESS[]);

            return hr;
        }

        #endregion
        #region GetPrivateBinPaths

        public string GetPrivateBinPaths(CLRDATA_ADDRESS appDomain)
        {
            HRESULT hr;
            string pathsResult;

            if ((hr = TryGetPrivateBinPaths(appDomain, out pathsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pathsResult;
        }

        public HRESULT TryGetPrivateBinPaths(CLRDATA_ADDRESS appDomain, out string pathsResult)
        {
            /*HRESULT GetPrivateBinPaths(
            CLRDATA_ADDRESS appDomain,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder paths,
            out int pNeeded);*/
            int count = 0;
            StringBuilder paths = null;
            int pNeeded;
            HRESULT hr = Raw.GetPrivateBinPaths(appDomain, count, paths, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            paths = new StringBuilder(pNeeded);
            hr = Raw.GetPrivateBinPaths(appDomain, count, paths, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                pathsResult = paths.ToString();

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
            HRESULT hr;
            string locationResult;

            if ((hr = TryGetAssemblyLocation(assembly, out locationResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return locationResult;
        }

        public HRESULT TryGetAssemblyLocation(CLRDATA_ADDRESS assembly, out string locationResult)
        {
            /*HRESULT GetAssemblyLocation(
            CLRDATA_ADDRESS assembly,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder location,
            out int pNeeded);*/
            int count = 0;
            StringBuilder location = null;
            int pNeeded;
            HRESULT hr = Raw.GetAssemblyLocation(assembly, count, location, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            location = new StringBuilder(pNeeded);
            hr = Raw.GetAssemblyLocation(assembly, count, location, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                locationResult = location.ToString();

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
            HRESULT hr;
            string configFileResult;

            if ((hr = TryGetAppDomainConfigFile(appDomain, out configFileResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return configFileResult;
        }

        public HRESULT TryGetAppDomainConfigFile(CLRDATA_ADDRESS appDomain, out string configFileResult)
        {
            /*HRESULT GetAppDomainConfigFile(
            CLRDATA_ADDRESS appDomain,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder configFile,
            out int pNeeded);*/
            int count = 0;
            StringBuilder configFile = null;
            int pNeeded;
            HRESULT hr = Raw.GetAppDomainConfigFile(appDomain, count, configFile, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            configFile = new StringBuilder(pNeeded);
            hr = Raw.GetAppDomainConfigFile(appDomain, count, configFile, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                configFileResult = configFile.ToString();

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
            HRESULT hr;
            string _baseResult;

            if ((hr = TryGetApplicationBase(appDomain, out _baseResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return _baseResult;
        }

        public HRESULT TryGetApplicationBase(CLRDATA_ADDRESS appDomain, out string _baseResult)
        {
            /*HRESULT GetApplicationBase(
            CLRDATA_ADDRESS appDomain,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder _base,
            out int pNeeded);*/
            int count = 0;
            StringBuilder _base = null;
            int pNeeded;
            HRESULT hr = Raw.GetApplicationBase(appDomain, count, _base, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            _base = new StringBuilder(pNeeded);
            hr = Raw.GetApplicationBase(appDomain, count, _base, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                _baseResult = _base.ToString();

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
            HRESULT hr;
            GetFailedAssemblyDataResult result;

            if ((hr = TryGetFailedAssemblyData(assembly, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetFailedAssemblyData(CLRDATA_ADDRESS assembly, out GetFailedAssemblyDataResult result)
        {
            /*HRESULT GetFailedAssemblyData(
            CLRDATA_ADDRESS assembly,
            out int pContext,
            out HRESULT pResult);*/
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
            HRESULT hr;
            string locationResult;

            if ((hr = TryGetFailedAssemblyLocation(assesmbly, out locationResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return locationResult;
        }

        public HRESULT TryGetFailedAssemblyLocation(CLRDATA_ADDRESS assesmbly, out string locationResult)
        {
            /*HRESULT GetFailedAssemblyLocation(
            CLRDATA_ADDRESS assesmbly,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder location,
            out int pNeeded);*/
            int count = 0;
            StringBuilder location = null;
            int pNeeded;
            HRESULT hr = Raw.GetFailedAssemblyLocation(assesmbly, count, location, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            location = new StringBuilder(pNeeded);
            hr = Raw.GetFailedAssemblyLocation(assesmbly, count, location, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                locationResult = location.ToString();

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
            HRESULT hr;
            string nameResult;

            if ((hr = TryGetFailedAssemblyDisplayName(assembly, out nameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return nameResult;
        }

        public HRESULT TryGetFailedAssemblyDisplayName(CLRDATA_ADDRESS assembly, out string nameResult)
        {
            /*HRESULT GetFailedAssemblyDisplayName(
            CLRDATA_ADDRESS assembly,
            int count,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name,
            out int pNeeded);*/
            int count = 0;
            StringBuilder name = null;
            int pNeeded;
            HRESULT hr = Raw.GetFailedAssemblyDisplayName(assembly, count, name, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            name = new StringBuilder(pNeeded);
            hr = Raw.GetFailedAssemblyDisplayName(assembly, count, name, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                nameResult = name.ToString();

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
            HRESULT hr;
            DacpExceptionObjectData data;

            if ((hr = TryGetObjectExceptionData(objAddr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetObjectExceptionData(CLRDATA_ADDRESS objAddr, out DacpExceptionObjectData data)
        {
            /*HRESULT GetObjectExceptionData(
            CLRDATA_ADDRESS objAddr,
            out DacpExceptionObjectData data);*/
            return Raw2.GetObjectExceptionData(objAddr, out data);
        }

        #endregion
        #region IsRCWDCOMProxy

        public int IsRCWDCOMProxy(CLRDATA_ADDRESS rcwAddr)
        {
            HRESULT hr;
            int isDCOMProxy;

            if ((hr = TryIsRCWDCOMProxy(rcwAddr, out isDCOMProxy)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return isDCOMProxy;
        }

        public HRESULT TryIsRCWDCOMProxy(CLRDATA_ADDRESS rcwAddr, out int isDCOMProxy)
        {
            /*HRESULT IsRCWDCOMProxy(
            CLRDATA_ADDRESS rcwAddr,
            out int isDCOMProxy);*/
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
                HRESULT hr;
                DacpGCInterestingInfoData data;

                if ((hr = TryGetGCInterestingInfoStaticData(out data)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return data;
            }
        }

        public HRESULT TryGetGCInterestingInfoStaticData(out DacpGCInterestingInfoData data)
        {
            /*HRESULT GetGCInterestingInfoStaticData(
            out DacpGCInterestingInfoData data);*/
            return Raw3.GetGCInterestingInfoStaticData(out data);
        }

        #endregion
        #region GCGlobalMechanisms

        public long[] GCGlobalMechanisms
        {
            get
            {
                HRESULT hr;
                long[] globalMechanismsResult;

                if ((hr = TryGetGCGlobalMechanisms(out globalMechanismsResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return globalMechanismsResult;
            }
        }

        public HRESULT TryGetGCGlobalMechanisms(out long[] globalMechanismsResult)
        {
            /*HRESULT GetGCGlobalMechanisms(
            [Out, MarshalAs(UnmanagedType.LPArray)] long[] globalMechanisms);*/
            long[] globalMechanisms = null;
            HRESULT hr = Raw3.GetGCGlobalMechanisms(globalMechanisms);

            if (hr == HRESULT.S_OK)
                globalMechanismsResult = globalMechanisms;
            else
                globalMechanismsResult = default(long[]);

            return hr;
        }

        #endregion
        #region GetGCInterestingInfoData

        public DacpGCInterestingInfoData GetGCInterestingInfoData(CLRDATA_ADDRESS interestingInfoAddr)
        {
            HRESULT hr;
            DacpGCInterestingInfoData data;

            if ((hr = TryGetGCInterestingInfoData(interestingInfoAddr, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetGCInterestingInfoData(CLRDATA_ADDRESS interestingInfoAddr, out DacpGCInterestingInfoData data)
        {
            /*HRESULT GetGCInterestingInfoData(
            CLRDATA_ADDRESS interestingInfoAddr,
            out DacpGCInterestingInfoData data);*/
            return Raw3.GetGCInterestingInfoData(interestingInfoAddr, out data);
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
                HRESULT hr;
                CLRDATA_ADDRESS[] argumentsResult;

                if ((hr = TryGetClrNotification(out argumentsResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return argumentsResult;
            }
        }

        public HRESULT TryGetClrNotification(out CLRDATA_ADDRESS[] argumentsResult)
        {
            /*HRESULT GetClrNotification(
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] arguments,
            int count,
            out int pNeeded);*/
            CLRDATA_ADDRESS[] arguments = null;
            int count = 0;
            int pNeeded;
            HRESULT hr = Raw4.GetClrNotification(arguments, count, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            arguments = new CLRDATA_ADDRESS[pNeeded];
            hr = Raw4.GetClrNotification(arguments, count, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                argumentsResult = arguments;

                return hr;
            }

            fail:
            argumentsResult = default(CLRDATA_ADDRESS[]);

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
            HRESULT hr;
            DacpTieredVersionData[] nativeCodeAddrsResult;

            if ((hr = TryGetTieredVersions(methodDesc, rejitId, out nativeCodeAddrsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return nativeCodeAddrsResult;
        }

        public HRESULT TryGetTieredVersions(CLRDATA_ADDRESS methodDesc, int rejitId, out DacpTieredVersionData[] nativeCodeAddrsResult)
        {
            /*HRESULT GetTieredVersions(
            CLRDATA_ADDRESS methodDesc,
            int rejitId,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpTieredVersionData[] nativeCodeAddrs,
            int cNativeCodeAddrs,
            out int pcNativeCodeAddrs);*/
            DacpTieredVersionData[] nativeCodeAddrs = null;
            int cNativeCodeAddrs = 0;
            int pcNativeCodeAddrs;
            HRESULT hr = Raw5.GetTieredVersions(methodDesc, rejitId, nativeCodeAddrs, cNativeCodeAddrs, out pcNativeCodeAddrs);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cNativeCodeAddrs = pcNativeCodeAddrs;
            nativeCodeAddrs = new DacpTieredVersionData[pcNativeCodeAddrs];
            hr = Raw5.GetTieredVersions(methodDesc, rejitId, nativeCodeAddrs, cNativeCodeAddrs, out pcNativeCodeAddrs);

            if (hr == HRESULT.S_OK)
            {
                nativeCodeAddrsResult = nativeCodeAddrs;

                return hr;
            }

            fail:
            nativeCodeAddrsResult = default(DacpTieredVersionData[]);

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
            HRESULT hr;
            DacpMethodTableCollectibleData data;

            if ((hr = TryGetMethodTableCollectibleData(mt, out data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return data;
        }

        public HRESULT TryGetMethodTableCollectibleData(CLRDATA_ADDRESS mt, out DacpMethodTableCollectibleData data)
        {
            /*HRESULT GetMethodTableCollectibleData(
            CLRDATA_ADDRESS mt,
            out DacpMethodTableCollectibleData data);*/
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
            HRESULT hr;
            int pRejitId;

            if ((hr = TryGetPendingReJITID(methodDesc, out pRejitId)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRejitId;
        }

        public HRESULT TryGetPendingReJITID(CLRDATA_ADDRESS methodDesc, out int pRejitId)
        {
            /*HRESULT GetPendingReJITID(
            CLRDATA_ADDRESS methodDesc,
            out int pRejitId);*/
            return Raw7.GetPendingReJITID(methodDesc, out pRejitId);
        }

        #endregion
        #region GetReJITInformation

        public DacpReJitData2 GetReJITInformation(CLRDATA_ADDRESS methodDesc, int rejitId)
        {
            HRESULT hr;
            DacpReJitData2 pRejitData;

            if ((hr = TryGetReJITInformation(methodDesc, rejitId, out pRejitData)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRejitData;
        }

        public HRESULT TryGetReJITInformation(CLRDATA_ADDRESS methodDesc, int rejitId, out DacpReJitData2 pRejitData)
        {
            /*HRESULT GetReJITInformation(
            CLRDATA_ADDRESS methodDesc,
            int rejitId,
            out DacpReJitData2 pRejitData);*/
            return Raw7.GetReJITInformation(methodDesc, rejitId, out pRejitData);
        }

        #endregion
        #region GetProfilerModifiedILInformation

        public DacpProfilerILData GetProfilerModifiedILInformation(CLRDATA_ADDRESS methodDesc)
        {
            HRESULT hr;
            DacpProfilerILData pILData;

            if ((hr = TryGetProfilerModifiedILInformation(methodDesc, out pILData)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pILData;
        }

        public HRESULT TryGetProfilerModifiedILInformation(CLRDATA_ADDRESS methodDesc, out DacpProfilerILData pILData)
        {
            /*HRESULT GetProfilerModifiedILInformation(
            CLRDATA_ADDRESS methodDesc,
            out DacpProfilerILData pILData);*/
            return Raw7.GetProfilerModifiedILInformation(methodDesc, out pILData);
        }

        #endregion
        #region GetMethodsWithProfilerModifiedIL

        public CLRDATA_ADDRESS[] GetMethodsWithProfilerModifiedIL(CLRDATA_ADDRESS mod)
        {
            HRESULT hr;
            CLRDATA_ADDRESS[] methodDescsResult;

            if ((hr = TryGetMethodsWithProfilerModifiedIL(mod, out methodDescsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return methodDescsResult;
        }

        public HRESULT TryGetMethodsWithProfilerModifiedIL(CLRDATA_ADDRESS mod, out CLRDATA_ADDRESS[] methodDescsResult)
        {
            /*HRESULT GetMethodsWithProfilerModifiedIL(
            CLRDATA_ADDRESS mod,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] methodDescs,
            int cMethodDescs,
            out int pcMethodDescs);*/
            CLRDATA_ADDRESS[] methodDescs = null;
            int cMethodDescs = 0;
            int pcMethodDescs;
            HRESULT hr = Raw7.GetMethodsWithProfilerModifiedIL(mod, methodDescs, cMethodDescs, out pcMethodDescs);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cMethodDescs = pcMethodDescs;
            methodDescs = new CLRDATA_ADDRESS[pcMethodDescs];
            hr = Raw7.GetMethodsWithProfilerModifiedIL(mod, methodDescs, cMethodDescs, out pcMethodDescs);

            if (hr == HRESULT.S_OK)
            {
                methodDescsResult = methodDescs;

                return hr;
            }

            fail:
            methodDescsResult = default(CLRDATA_ADDRESS[]);

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
                HRESULT hr;
                int pGenerations;

                if ((hr = TryGetNumberGenerations(out pGenerations)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
                HRESULT hr;
                DacpGenerationData[] pGenerationDataResult;

                if ((hr = TryGetGenerationTable(out pGenerationDataResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pGenerationDataResult;
            }
        }

        public HRESULT TryGetGenerationTable(out DacpGenerationData[] pGenerationDataResult)
        {
            /*HRESULT GetGenerationTable(
            int cGenerations,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpGenerationData[] pGenerationData,
            [Out] out int pNeeded);*/
            int cGenerations = 0;
            DacpGenerationData[] pGenerationData = null;
            int pNeeded;
            HRESULT hr = Raw8.GetGenerationTable(cGenerations, pGenerationData, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cGenerations = pNeeded;
            pGenerationData = new DacpGenerationData[pNeeded];
            hr = Raw8.GetGenerationTable(cGenerations, pGenerationData, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                pGenerationDataResult = pGenerationData;

                return hr;
            }

            fail:
            pGenerationDataResult = default(DacpGenerationData[]);

            return hr;
        }

        #endregion
        #region FinalizationFillPointers

        public CLRDATA_ADDRESS[] FinalizationFillPointers
        {
            get
            {
                HRESULT hr;
                CLRDATA_ADDRESS[] pFinalizationFillPointersResult;

                if ((hr = TryGetFinalizationFillPointers(out pFinalizationFillPointersResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pFinalizationFillPointersResult;
            }
        }

        public HRESULT TryGetFinalizationFillPointers(out CLRDATA_ADDRESS[] pFinalizationFillPointersResult)
        {
            /*HRESULT GetFinalizationFillPointers(
            int cFillPointers,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] pFinalizationFillPointers,
            [Out] out int pNeeded);*/
            int cFillPointers = 0;
            CLRDATA_ADDRESS[] pFinalizationFillPointers = null;
            int pNeeded;
            HRESULT hr = Raw8.GetFinalizationFillPointers(cFillPointers, pFinalizationFillPointers, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cFillPointers = pNeeded;
            pFinalizationFillPointers = new CLRDATA_ADDRESS[pNeeded];
            hr = Raw8.GetFinalizationFillPointers(cFillPointers, pFinalizationFillPointers, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                pFinalizationFillPointersResult = pFinalizationFillPointers;

                return hr;
            }

            fail:
            pFinalizationFillPointersResult = default(CLRDATA_ADDRESS[]);

            return hr;
        }

        #endregion
        #region GetGenerationTableSvr

        public DacpGenerationData[] GetGenerationTableSvr(CLRDATA_ADDRESS heapAddr)
        {
            HRESULT hr;
            DacpGenerationData[] pGenerationDataResult;

            if ((hr = TryGetGenerationTableSvr(heapAddr, out pGenerationDataResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pGenerationDataResult;
        }

        public HRESULT TryGetGenerationTableSvr(CLRDATA_ADDRESS heapAddr, out DacpGenerationData[] pGenerationDataResult)
        {
            /*HRESULT GetGenerationTableSvr(
            CLRDATA_ADDRESS heapAddr,
            int cGenerations,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpGenerationData[] pGenerationData,
            [Out] out int pNeeded);*/
            int cGenerations = 0;
            DacpGenerationData[] pGenerationData = null;
            int pNeeded;
            HRESULT hr = Raw8.GetGenerationTableSvr(heapAddr, cGenerations, pGenerationData, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cGenerations = pNeeded;
            pGenerationData = new DacpGenerationData[pNeeded];
            hr = Raw8.GetGenerationTableSvr(heapAddr, cGenerations, pGenerationData, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                pGenerationDataResult = pGenerationData;

                return hr;
            }

            fail:
            pGenerationDataResult = default(DacpGenerationData[]);

            return hr;
        }

        #endregion
        #region GetFinalizationFillPointersSvr

        public CLRDATA_ADDRESS[] GetFinalizationFillPointersSvr(CLRDATA_ADDRESS heapAddr)
        {
            HRESULT hr;
            CLRDATA_ADDRESS[] pFinalizationFillPointersResult;

            if ((hr = TryGetFinalizationFillPointersSvr(heapAddr, out pFinalizationFillPointersResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pFinalizationFillPointersResult;
        }

        public HRESULT TryGetFinalizationFillPointersSvr(CLRDATA_ADDRESS heapAddr, out CLRDATA_ADDRESS[] pFinalizationFillPointersResult)
        {
            /*HRESULT GetFinalizationFillPointersSvr(
            CLRDATA_ADDRESS heapAddr,
            int cFillPointers,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] pFinalizationFillPointers,
            [Out] out int pNeeded);*/
            int cFillPointers = 0;
            CLRDATA_ADDRESS[] pFinalizationFillPointers = null;
            int pNeeded;
            HRESULT hr = Raw8.GetFinalizationFillPointersSvr(heapAddr, cFillPointers, pFinalizationFillPointers, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cFillPointers = pNeeded;
            pFinalizationFillPointers = new CLRDATA_ADDRESS[pNeeded];
            hr = Raw8.GetFinalizationFillPointersSvr(heapAddr, cFillPointers, pFinalizationFillPointers, out pNeeded);

            if (hr == HRESULT.S_OK)
            {
                pFinalizationFillPointersResult = pFinalizationFillPointers;

                return hr;
            }

            fail:
            pFinalizationFillPointersResult = default(CLRDATA_ADDRESS[]);

            return hr;
        }

        #endregion
        #region GetAssemblyLoadContext

        public CLRDATA_ADDRESS GetAssemblyLoadContext(CLRDATA_ADDRESS methodTable)
        {
            HRESULT hr;
            CLRDATA_ADDRESS assemblyLoadContext;

            if ((hr = TryGetAssemblyLoadContext(methodTable, out assemblyLoadContext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return assemblyLoadContext;
        }

        public HRESULT TryGetAssemblyLoadContext(CLRDATA_ADDRESS methodTable, out CLRDATA_ADDRESS assemblyLoadContext)
        {
            /*HRESULT GetAssemblyLoadContext(
            CLRDATA_ADDRESS methodTable,
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
                HRESULT hr;
                int pVersion;

                if ((hr = TryGetBreakingChangeVersion(out pVersion)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
            HRESULT hr;
            GetObjectComWrappersDataResult result;

            if ((hr = TryGetObjectComWrappersData(objAddr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetObjectComWrappersData(CLRDATA_ADDRESS objAddr, out GetObjectComWrappersDataResult result)
        {
            /*HRESULT GetObjectComWrappersData(
            CLRDATA_ADDRESS objAddr,
            out CLRDATA_ADDRESS rcw,
            int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_ADDRESS[] mowList,
            out int pNeeded);*/
            CLRDATA_ADDRESS rcw;
            int count = 0;
            CLRDATA_ADDRESS[] mowList = null;
            int pNeeded;
            HRESULT hr = Raw10.GetObjectComWrappersData(objAddr, out rcw, count, mowList, out pNeeded);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pNeeded;
            mowList = new CLRDATA_ADDRESS[pNeeded];
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

        public int IsComWrappersCCW(CLRDATA_ADDRESS ccw)
        {
            HRESULT hr;
            int isComWrappersCCW;

            if ((hr = TryIsComWrappersCCW(ccw, out isComWrappersCCW)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return isComWrappersCCW;
        }

        public HRESULT TryIsComWrappersCCW(CLRDATA_ADDRESS ccw, out int isComWrappersCCW)
        {
            /*HRESULT IsComWrappersCCW(
            CLRDATA_ADDRESS ccw,
            out int isComWrappersCCW);*/
            return Raw10.IsComWrappersCCW(ccw, out isComWrappersCCW);
        }

        #endregion
        #region GetComWrappersCCWData

        public GetComWrappersCCWDataResult GetComWrappersCCWData(CLRDATA_ADDRESS ccw)
        {
            HRESULT hr;
            GetComWrappersCCWDataResult result;

            if ((hr = TryGetComWrappersCCWData(ccw, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetComWrappersCCWData(CLRDATA_ADDRESS ccw, out GetComWrappersCCWDataResult result)
        {
            /*HRESULT GetComWrappersCCWData(
            CLRDATA_ADDRESS ccw,
            out CLRDATA_ADDRESS managedObject,
            out int refCount);*/
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

        public int IsComWrappersRCW(CLRDATA_ADDRESS rcw)
        {
            HRESULT hr;
            int isComWrappersRCW;

            if ((hr = TryIsComWrappersRCW(rcw, out isComWrappersRCW)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return isComWrappersRCW;
        }

        public HRESULT TryIsComWrappersRCW(CLRDATA_ADDRESS rcw, out int isComWrappersRCW)
        {
            /*HRESULT IsComWrappersRCW(
            CLRDATA_ADDRESS rcw,
            out int isComWrappersRCW);*/
            return Raw10.IsComWrappersRCW(rcw, out isComWrappersRCW);
        }

        #endregion
        #region GetComWrappersRCWData

        public CLRDATA_ADDRESS GetComWrappersRCWData(CLRDATA_ADDRESS rcw)
        {
            HRESULT hr;
            CLRDATA_ADDRESS identity;

            if ((hr = TryGetComWrappersRCWData(rcw, out identity)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return identity;
        }

        public HRESULT TryGetComWrappersRCWData(CLRDATA_ADDRESS rcw, out CLRDATA_ADDRESS identity)
        {
            /*HRESULT GetComWrappersRCWData(
            CLRDATA_ADDRESS rcw,
            out CLRDATA_ADDRESS identity);*/
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
            HRESULT hr;
            IsTrackedTypeResult result;

            if ((hr = TryIsTrackedType(objAddr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryIsTrackedType(CLRDATA_ADDRESS objAddr, out IsTrackedTypeResult result)
        {
            /*HRESULT IsTrackedType(
            CLRDATA_ADDRESS objAddr,
            out int isTrackedType,
            out int hasTaggedMemory);*/
            int isTrackedType;
            int hasTaggedMemory;
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
            HRESULT hr;
            GetTaggedMemoryResult result;

            if ((hr = TryGetTaggedMemory(objAddr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetTaggedMemory(CLRDATA_ADDRESS objAddr, out GetTaggedMemoryResult result)
        {
            /*HRESULT GetTaggedMemory(
            CLRDATA_ADDRESS objAddr,
            out CLRDATA_ADDRESS taggedMemory,
            out long taggedMemorySizeInBytes);*/
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
    }
}