using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugProcess : CorDebugController
    {
        public CorDebugProcess(ICorDebugProcess raw) : base(raw)
        {
        }

        #region ICorDebugProcess

        public new ICorDebugProcess Raw => (ICorDebugProcess) base.Raw;

        #region GetID

        public uint Id
        {
            get
            {
                HRESULT hr;
                uint pdwProcessId;

                if ((hr = TryGetID(out pdwProcessId)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwProcessId;
            }
        }

        public HRESULT TryGetID(out uint pdwProcessId)
        {
            /*HRESULT GetID(out uint pdwProcessId);*/
            return Raw.GetID(out pdwProcessId);
        }

        #endregion
        #region GetHandle

        public IntPtr Handle
        {
            get
            {
                HRESULT hr;
                IntPtr phProcessHandle;

                if ((hr = TryGetHandle(out phProcessHandle)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return phProcessHandle;
            }
        }

        public HRESULT TryGetHandle(out IntPtr phProcessHandle)
        {
            /*HRESULT GetHandle(out IntPtr phProcessHandle);*/
            return Raw.GetHandle(out phProcessHandle);
        }

        #endregion
        #region GetObject

        public CorDebugValue Object
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppObjectResult;

                if ((hr = TryGetObject(out ppObjectResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppObjectResult;
            }
        }

        public HRESULT TryGetObject(out CorDebugValue ppObjectResult)
        {
            /*HRESULT GetObject([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);*/
            ICorDebugValue ppObject;
            HRESULT hr = Raw.GetObject(out ppObject);

            if (hr == HRESULT.S_OK)
                ppObjectResult = CorDebugValue.New(ppObject);
            else
                ppObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetHelperThreadID

        public uint HelperThreadID
        {
            get
            {
                HRESULT hr;
                uint pThreadID;

                if ((hr = TryGetHelperThreadID(out pThreadID)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pThreadID;
            }
        }

        public HRESULT TryGetHelperThreadID(out uint pThreadID)
        {
            /*HRESULT GetHelperThreadID(out uint pThreadID);*/
            return Raw.GetHelperThreadID(out pThreadID);
        }

        #endregion
        #region GetThread

        public CorDebugThread GetThread(uint dwThreadId)
        {
            HRESULT hr;
            CorDebugThread ppThreadResult;

            if ((hr = TryGetThread(dwThreadId, out ppThreadResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppThreadResult;
        }

        public HRESULT TryGetThread(uint dwThreadId, out CorDebugThread ppThreadResult)
        {
            /*HRESULT GetThread([In] uint dwThreadId, [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);*/
            ICorDebugThread ppThread;
            HRESULT hr = Raw.GetThread(dwThreadId, out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = new CorDebugThread(ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #region EnumerateObjects

        public CorDebugObjectEnum EnumerateObjects()
        {
            HRESULT hr;
            CorDebugObjectEnum ppObjectsResult;

            if ((hr = TryEnumerateObjects(out ppObjectsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppObjectsResult;
        }

        public HRESULT TryEnumerateObjects(out CorDebugObjectEnum ppObjectsResult)
        {
            /*HRESULT EnumerateObjects([MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectEnum ppObjects);*/
            ICorDebugObjectEnum ppObjects;
            HRESULT hr = Raw.EnumerateObjects(out ppObjects);

            if (hr == HRESULT.S_OK)
                ppObjectsResult = new CorDebugObjectEnum(ppObjects);
            else
                ppObjectsResult = default(CorDebugObjectEnum);

            return hr;
        }

        #endregion
        #region IsTransitionStub

        public int IsTransitionStub(CORDB_ADDRESS address)
        {
            HRESULT hr;
            int pbTransitionStub;

            if ((hr = TryIsTransitionStub(address, out pbTransitionStub)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbTransitionStub;
        }

        public HRESULT TryIsTransitionStub(CORDB_ADDRESS address, out int pbTransitionStub)
        {
            /*HRESULT IsTransitionStub([In] CORDB_ADDRESS address, out int pbTransitionStub);*/
            return Raw.IsTransitionStub(address, out pbTransitionStub);
        }

        #endregion
        #region IsOSSuspended

        public int IsOSSuspended(uint threadID)
        {
            HRESULT hr;
            int pbSuspended;

            if ((hr = TryIsOSSuspended(threadID, out pbSuspended)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbSuspended;
        }

        public HRESULT TryIsOSSuspended(uint threadID, out int pbSuspended)
        {
            /*HRESULT IsOSSuspended([In] uint threadID, out int pbSuspended);*/
            return Raw.IsOSSuspended(threadID, out pbSuspended);
        }

        #endregion
        #region GetThreadContext

        public byte[] GetThreadContext(uint threadID, uint contextSize)
        {
            HRESULT hr;
            byte[] context = default(byte[]);

            if ((hr = TryGetThreadContext(threadID, contextSize, ref context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return context;
        }

        public HRESULT TryGetThreadContext(uint threadID, uint contextSize, ref byte[] context)
        {
            /*HRESULT GetThreadContext([In] uint threadID, [In] uint contextSize, [In, Out] ref byte[] context);*/
            return Raw.GetThreadContext(threadID, contextSize, ref context);
        }

        #endregion
        #region SetThreadContext

        public void SetThreadContext(uint threadID, uint contextSize, byte[] context)
        {
            HRESULT hr;

            if ((hr = TrySetThreadContext(threadID, contextSize, context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetThreadContext(uint threadID, uint contextSize, byte[] context)
        {
            /*HRESULT SetThreadContext([In] uint threadID, [In] uint contextSize, [In] byte[] context);*/
            return Raw.SetThreadContext(threadID, contextSize, context);
        }

        #endregion
        #region ReadMemory

        public ReadMemoryResult ReadMemory(CORDB_ADDRESS address, uint size)
        {
            HRESULT hr;
            ReadMemoryResult result;

            if ((hr = TryReadMemory(address, size, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryReadMemory(CORDB_ADDRESS address, uint size, out ReadMemoryResult result)
        {
            /*HRESULT ReadMemory([In] CORDB_ADDRESS address, [In] uint size, [Out] byte[] buffer, out ulong read);*/
            byte[] buffer = default(byte[]);
            ulong read;
            HRESULT hr = Raw.ReadMemory(address, size, buffer, out read);

            if (hr == HRESULT.S_OK)
                result = new ReadMemoryResult(buffer, read);
            else
                result = default(ReadMemoryResult);

            return hr;
        }

        #endregion
        #region WriteMemory

        public ulong WriteMemory(CORDB_ADDRESS address, uint size, IntPtr buffer)
        {
            HRESULT hr;
            ulong written;

            if ((hr = TryWriteMemory(address, size, buffer, out written)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return written;
        }

        public HRESULT TryWriteMemory(CORDB_ADDRESS address, uint size, IntPtr buffer, out ulong written)
        {
            /*HRESULT WriteMemory([In] CORDB_ADDRESS address, [In] uint size, [In] IntPtr buffer,
            out ulong written);*/
            return Raw.WriteMemory(address, size, buffer, out written);
        }

        #endregion
        #region ClearCurrentException

        public void ClearCurrentException(uint threadID)
        {
            HRESULT hr;

            if ((hr = TryClearCurrentException(threadID)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryClearCurrentException(uint threadID)
        {
            /*HRESULT ClearCurrentException([In] uint threadID);*/
            return Raw.ClearCurrentException(threadID);
        }

        #endregion
        #region EnableLogMessages

        public void EnableLogMessages(int fOnOff)
        {
            HRESULT hr;

            if ((hr = TryEnableLogMessages(fOnOff)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEnableLogMessages(int fOnOff)
        {
            /*HRESULT EnableLogMessages([In] int fOnOff);*/
            return Raw.EnableLogMessages(fOnOff);
        }

        #endregion
        #region ModifyLogSwitch

        public void ModifyLogSwitch(string pLogSwitchName, int lLevel)
        {
            HRESULT hr;

            if ((hr = TryModifyLogSwitch(pLogSwitchName, lLevel)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryModifyLogSwitch(string pLogSwitchName, int lLevel)
        {
            /*HRESULT ModifyLogSwitch([In] string pLogSwitchName, [In] int lLevel);*/
            return Raw.ModifyLogSwitch(pLogSwitchName, lLevel);
        }

        #endregion
        #region EnumerateAppDomains

        public CorDebugAppDomainEnum EnumerateAppDomains()
        {
            HRESULT hr;
            CorDebugAppDomainEnum ppAppDomainsResult;

            if ((hr = TryEnumerateAppDomains(out ppAppDomainsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppAppDomainsResult;
        }

        public HRESULT TryEnumerateAppDomains(out CorDebugAppDomainEnum ppAppDomainsResult)
        {
            /*HRESULT EnumerateAppDomains([MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomainEnum ppAppDomains);*/
            ICorDebugAppDomainEnum ppAppDomains;
            HRESULT hr = Raw.EnumerateAppDomains(out ppAppDomains);

            if (hr == HRESULT.S_OK)
                ppAppDomainsResult = new CorDebugAppDomainEnum(ppAppDomains);
            else
                ppAppDomainsResult = default(CorDebugAppDomainEnum);

            return hr;
        }

        #endregion
        #region ThreadForFiberCookie

        public CorDebugThread ThreadForFiberCookie(uint fiberCookie)
        {
            HRESULT hr;
            CorDebugThread ppThreadResult;

            if ((hr = TryThreadForFiberCookie(fiberCookie, out ppThreadResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppThreadResult;
        }

        public HRESULT TryThreadForFiberCookie(uint fiberCookie, out CorDebugThread ppThreadResult)
        {
            /*HRESULT ThreadForFiberCookie([In] uint fiberCookie,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);*/
            ICorDebugThread ppThread;
            HRESULT hr = Raw.ThreadForFiberCookie(fiberCookie, out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = new CorDebugThread(ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugProcess2

        public ICorDebugProcess2 Raw2 => (ICorDebugProcess2) Raw;

        #region GetVersion

        public COR_VERSION Version
        {
            get
            {
                HRESULT hr;
                COR_VERSION version;

                if ((hr = TryGetVersion(out version)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return version;
            }
        }

        public HRESULT TryGetVersion(out COR_VERSION version)
        {
            /*HRESULT GetVersion(out COR_VERSION version);*/
            return Raw2.GetVersion(out version);
        }

        #endregion
        #region GetDesiredNGENCompilerFlags

        public uint DesiredNGENCompilerFlags
        {
            get
            {
                HRESULT hr;
                uint pdwFlags;

                if ((hr = TryGetDesiredNGENCompilerFlags(out pdwFlags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwFlags;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetDesiredNGENCompilerFlags(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetDesiredNGENCompilerFlags(out uint pdwFlags)
        {
            /*HRESULT GetDesiredNGENCompilerFlags(out uint pdwFlags);*/
            return Raw2.GetDesiredNGENCompilerFlags(out pdwFlags);
        }

        public HRESULT TrySetDesiredNGENCompilerFlags(uint pdwFlags)
        {
            /*HRESULT SetDesiredNGENCompilerFlags([In] uint pdwFlags);*/
            return Raw2.SetDesiredNGENCompilerFlags(pdwFlags);
        }

        #endregion
        #region GetThreadForTaskID

        public CorDebugThread GetThreadForTaskID(ulong taskid)
        {
            HRESULT hr;
            CorDebugThread ppThreadResult;

            if ((hr = TryGetThreadForTaskID(taskid, out ppThreadResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppThreadResult;
        }

        public HRESULT TryGetThreadForTaskID(ulong taskid, out CorDebugThread ppThreadResult)
        {
            /*HRESULT GetThreadForTaskID([In] ulong taskid, [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread2 ppThread);*/
            ICorDebugThread2 ppThread;
            HRESULT hr = Raw2.GetThreadForTaskID(taskid, out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = new CorDebugThread((ICorDebugThread) ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #region SetUnmanagedBreakpoint

        public SetUnmanagedBreakpointResult SetUnmanagedBreakpoint(CORDB_ADDRESS address, uint bufsize)
        {
            HRESULT hr;
            SetUnmanagedBreakpointResult result;

            if ((hr = TrySetUnmanagedBreakpoint(address, bufsize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TrySetUnmanagedBreakpoint(CORDB_ADDRESS address, uint bufsize, out SetUnmanagedBreakpointResult result)
        {
            /*HRESULT SetUnmanagedBreakpoint(
            [In] CORDB_ADDRESS address,
            [In] uint bufsize,
            [Out] byte[] buffer,
            out uint bufLen);*/
            byte[] buffer = default(byte[]);
            uint bufLen;
            HRESULT hr = Raw2.SetUnmanagedBreakpoint(address, bufsize, buffer, out bufLen);

            if (hr == HRESULT.S_OK)
                result = new SetUnmanagedBreakpointResult(buffer, bufLen);
            else
                result = default(SetUnmanagedBreakpointResult);

            return hr;
        }

        #endregion
        #region ClearUnmanagedBreakpoint

        public void ClearUnmanagedBreakpoint(CORDB_ADDRESS address)
        {
            HRESULT hr;

            if ((hr = TryClearUnmanagedBreakpoint(address)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryClearUnmanagedBreakpoint(CORDB_ADDRESS address)
        {
            /*HRESULT ClearUnmanagedBreakpoint([In] CORDB_ADDRESS address);*/
            return Raw2.ClearUnmanagedBreakpoint(address);
        }

        #endregion
        #region GetReferenceValueFromGCHandle

        public CorDebugReferenceValue GetReferenceValueFromGCHandle(IntPtr handle)
        {
            HRESULT hr;
            CorDebugReferenceValue pOutValueResult;

            if ((hr = TryGetReferenceValueFromGCHandle(handle, out pOutValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pOutValueResult;
        }

        public HRESULT TryGetReferenceValueFromGCHandle(IntPtr handle, out CorDebugReferenceValue pOutValueResult)
        {
            /*HRESULT GetReferenceValueFromGCHandle([In] IntPtr handle, [MarshalAs(UnmanagedType.Interface)] out ICorDebugReferenceValue pOutValue);*/
            ICorDebugReferenceValue pOutValue;
            HRESULT hr = Raw2.GetReferenceValueFromGCHandle(handle, out pOutValue);

            if (hr == HRESULT.S_OK)
                pOutValueResult = CorDebugReferenceValue.New(pOutValue);
            else
                pOutValueResult = default(CorDebugReferenceValue);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugProcess3

        public ICorDebugProcess3 Raw3 => (ICorDebugProcess3) Raw;

        #region SetEnableCustomNotification

        public void SetEnableCustomNotification(ICorDebugClass pClass, int fEnable)
        {
            HRESULT hr;

            if ((hr = TrySetEnableCustomNotification(pClass, fEnable)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetEnableCustomNotification(ICorDebugClass pClass, int fEnable)
        {
            /*HRESULT SetEnableCustomNotification([MarshalAs(UnmanagedType.Interface)] ICorDebugClass pClass, int fEnable);*/
            return Raw3.SetEnableCustomNotification(pClass, fEnable);
        }

        #endregion
        #endregion
        #region ICorDebugProcess5

        public ICorDebugProcess5 Raw5 => (ICorDebugProcess5) Raw;

        #region GetGCHeapInformation

        public COR_HEAPINFO GCHeapInformation
        {
            get
            {
                HRESULT hr;
                COR_HEAPINFO pHeapInfo;

                if ((hr = TryGetGCHeapInformation(out pHeapInfo)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pHeapInfo;
            }
        }

        public HRESULT TryGetGCHeapInformation(out COR_HEAPINFO pHeapInfo)
        {
            /*HRESULT GetGCHeapInformation(out COR_HEAPINFO pHeapInfo);*/
            return Raw5.GetGCHeapInformation(out pHeapInfo);
        }

        #endregion
        #region EnumerateHeap

        public CorDebugHeapEnum EnumerateHeap()
        {
            HRESULT hr;
            CorDebugHeapEnum ppObjectsResult;

            if ((hr = TryEnumerateHeap(out ppObjectsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppObjectsResult;
        }

        public HRESULT TryEnumerateHeap(out CorDebugHeapEnum ppObjectsResult)
        {
            /*HRESULT EnumerateHeap([MarshalAs(UnmanagedType.Interface)] out ICorDebugHeapEnum ppObjects);*/
            ICorDebugHeapEnum ppObjects;
            HRESULT hr = Raw5.EnumerateHeap(out ppObjects);

            if (hr == HRESULT.S_OK)
                ppObjectsResult = new CorDebugHeapEnum(ppObjects);
            else
                ppObjectsResult = default(CorDebugHeapEnum);

            return hr;
        }

        #endregion
        #region EnumerateHeapRegions

        public CorDebugHeapSegmentEnum EnumerateHeapRegions()
        {
            HRESULT hr;
            CorDebugHeapSegmentEnum ppRegionsResult;

            if ((hr = TryEnumerateHeapRegions(out ppRegionsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppRegionsResult;
        }

        public HRESULT TryEnumerateHeapRegions(out CorDebugHeapSegmentEnum ppRegionsResult)
        {
            /*HRESULT EnumerateHeapRegions([MarshalAs(UnmanagedType.Interface)] out ICorDebugHeapSegmentEnum ppRegions);*/
            ICorDebugHeapSegmentEnum ppRegions;
            HRESULT hr = Raw5.EnumerateHeapRegions(out ppRegions);

            if (hr == HRESULT.S_OK)
                ppRegionsResult = new CorDebugHeapSegmentEnum(ppRegions);
            else
                ppRegionsResult = default(CorDebugHeapSegmentEnum);

            return hr;
        }

        #endregion
        #region GetObject

        public CorDebugObjectValue GetObject(ulong addr)
        {
            HRESULT hr;
            CorDebugObjectValue pObjectResult;

            if ((hr = TryGetObject(addr, out pObjectResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pObjectResult;
        }

        public HRESULT TryGetObject(ulong addr, out CorDebugObjectValue pObjectResult)
        {
            /*HRESULT GetObject([In] ulong addr, [MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectValue pObject);*/
            ICorDebugObjectValue pObject;
            HRESULT hr = Raw5.GetObject(addr, out pObject);

            if (hr == HRESULT.S_OK)
                pObjectResult = CorDebugObjectValue.New(pObject);
            else
                pObjectResult = default(CorDebugObjectValue);

            return hr;
        }

        #endregion
        #region EnumerateGCReferences

        public CorDebugGCReferenceEnum EnumerateGCReferences(int enumerateWeakReferences)
        {
            HRESULT hr;
            CorDebugGCReferenceEnum ppEnumResult;

            if ((hr = TryEnumerateGCReferences(enumerateWeakReferences, out ppEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEnumResult;
        }

        public HRESULT TryEnumerateGCReferences(int enumerateWeakReferences, out CorDebugGCReferenceEnum ppEnumResult)
        {
            /*HRESULT EnumerateGCReferences([In] int enumerateWeakReferences,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugGCReferenceEnum ppEnum);*/
            ICorDebugGCReferenceEnum ppEnum;
            HRESULT hr = Raw5.EnumerateGCReferences(enumerateWeakReferences, out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = new CorDebugGCReferenceEnum(ppEnum);
            else
                ppEnumResult = default(CorDebugGCReferenceEnum);

            return hr;
        }

        #endregion
        #region EnumerateHandles

        public CorDebugGCReferenceEnum EnumerateHandles(CorGCReferenceType types)
        {
            HRESULT hr;
            CorDebugGCReferenceEnum ppEnumResult;

            if ((hr = TryEnumerateHandles(types, out ppEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEnumResult;
        }

        public HRESULT TryEnumerateHandles(CorGCReferenceType types, out CorDebugGCReferenceEnum ppEnumResult)
        {
            /*HRESULT EnumerateHandles([In] CorGCReferenceType types,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugGCReferenceEnum ppEnum);*/
            ICorDebugGCReferenceEnum ppEnum;
            HRESULT hr = Raw5.EnumerateHandles(types, out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = new CorDebugGCReferenceEnum(ppEnum);
            else
                ppEnumResult = default(CorDebugGCReferenceEnum);

            return hr;
        }

        #endregion
        #region GetTypeID

        public COR_TYPEID GetTypeID(ulong obj)
        {
            HRESULT hr;
            COR_TYPEID pId;

            if ((hr = TryGetTypeID(obj, out pId)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pId;
        }

        public HRESULT TryGetTypeID(ulong obj, out COR_TYPEID pId)
        {
            /*HRESULT GetTypeID([In] ulong obj, out COR_TYPEID pId);*/
            return Raw5.GetTypeID(obj, out pId);
        }

        #endregion
        #region GetTypeForTypeID

        public CorDebugType GetTypeForTypeID(COR_TYPEID id)
        {
            HRESULT hr;
            CorDebugType ppTypeResult;

            if ((hr = TryGetTypeForTypeID(id, out ppTypeResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppTypeResult;
        }

        public HRESULT TryGetTypeForTypeID(COR_TYPEID id, out CorDebugType ppTypeResult)
        {
            /*HRESULT GetTypeForTypeID([In] COR_TYPEID id, [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
            ICorDebugType ppType;
            HRESULT hr = Raw5.GetTypeForTypeID(id, out ppType);

            if (hr == HRESULT.S_OK)
                ppTypeResult = new CorDebugType(ppType);
            else
                ppTypeResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #region GetArrayLayout

        public COR_ARRAY_LAYOUT GetArrayLayout(COR_TYPEID id)
        {
            HRESULT hr;
            COR_ARRAY_LAYOUT pLayout;

            if ((hr = TryGetArrayLayout(id, out pLayout)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pLayout;
        }

        public HRESULT TryGetArrayLayout(COR_TYPEID id, out COR_ARRAY_LAYOUT pLayout)
        {
            /*HRESULT GetArrayLayout([In] COR_TYPEID id, out COR_ARRAY_LAYOUT pLayout);*/
            return Raw5.GetArrayLayout(id, out pLayout);
        }

        #endregion
        #region GetTypeLayout

        public COR_TYPE_LAYOUT GetTypeLayout(COR_TYPEID id)
        {
            HRESULT hr;
            COR_TYPE_LAYOUT pLayout;

            if ((hr = TryGetTypeLayout(id, out pLayout)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pLayout;
        }

        public HRESULT TryGetTypeLayout(COR_TYPEID id, out COR_TYPE_LAYOUT pLayout)
        {
            /*HRESULT GetTypeLayout([In] COR_TYPEID id, out COR_TYPE_LAYOUT pLayout);*/
            return Raw5.GetTypeLayout(id, out pLayout);
        }

        #endregion
        #region GetTypeFields

        public GetTypeFieldsResult GetTypeFields(COR_TYPEID id, uint celt)
        {
            HRESULT hr;
            GetTypeFieldsResult result;

            if ((hr = TryGetTypeFields(id, celt, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetTypeFields(COR_TYPEID id, uint celt, out GetTypeFieldsResult result)
        {
            /*HRESULT GetTypeFields([In] COR_TYPEID id, uint celt, ref COR_FIELD fields, ref uint pceltNeeded);*/
            COR_FIELD fields = default(COR_FIELD);
            uint pceltNeeded = default(uint);
            HRESULT hr = Raw5.GetTypeFields(id, celt, ref fields, ref pceltNeeded);

            if (hr == HRESULT.S_OK)
                result = new GetTypeFieldsResult(fields, pceltNeeded);
            else
                result = default(GetTypeFieldsResult);

            return hr;
        }

        #endregion
        #region EnableNGENPolicy

        public void EnableNGENPolicy(CorDebugNGenPolicy ePolicy)
        {
            HRESULT hr;

            if ((hr = TryEnableNGENPolicy(ePolicy)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEnableNGENPolicy(CorDebugNGenPolicy ePolicy)
        {
            /*HRESULT EnableNGENPolicy([In] CorDebugNGenPolicy ePolicy);*/
            return Raw5.EnableNGENPolicy(ePolicy);
        }

        #endregion
        #endregion
        #region ICorDebugProcess6

        public ICorDebugProcess6 Raw6 => (ICorDebugProcess6) Raw;

        #region DecodeEvent

        public CorDebugDebugEvent DecodeEvent(byte[] pRecord, uint countBytes, CorDebugRecordFormat format, uint dwFlags, uint dwThreadId)
        {
            HRESULT hr;
            CorDebugDebugEvent ppEventResult;

            if ((hr = TryDecodeEvent(pRecord, countBytes, format, dwFlags, dwThreadId, out ppEventResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEventResult;
        }

        public HRESULT TryDecodeEvent(byte[] pRecord, uint countBytes, CorDebugRecordFormat format, uint dwFlags, uint dwThreadId, out CorDebugDebugEvent ppEventResult)
        {
            /*HRESULT DecodeEvent(
            [In] byte[] pRecord,
            [In] uint countBytes,
            [In] CorDebugRecordFormat format,
            [In] uint dwFlags,
            [In] uint dwThreadId,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugDebugEvent ppEvent);*/
            ICorDebugDebugEvent ppEvent;
            HRESULT hr = Raw6.DecodeEvent(pRecord, countBytes, format, dwFlags, dwThreadId, out ppEvent);

            if (hr == HRESULT.S_OK)
                ppEventResult = CorDebugDebugEvent.New(ppEvent);
            else
                ppEventResult = default(CorDebugDebugEvent);

            return hr;
        }

        #endregion
        #region ProcessStateChanged

        public void ProcessStateChanged(CorDebugStateChange change)
        {
            HRESULT hr;

            if ((hr = TryProcessStateChanged(change)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryProcessStateChanged(CorDebugStateChange change)
        {
            /*HRESULT ProcessStateChanged([In] CorDebugStateChange change);*/
            return Raw6.ProcessStateChanged(change);
        }

        #endregion
        #region GetCode

        public CorDebugCode GetCode(CORDB_ADDRESS codeAddress)
        {
            HRESULT hr;
            CorDebugCode ppCodeResult;

            if ((hr = TryGetCode(codeAddress, out ppCodeResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppCodeResult;
        }

        public HRESULT TryGetCode(CORDB_ADDRESS codeAddress, out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetCode([In] CORDB_ADDRESS codeAddress, [MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw6.GetCode(codeAddress, out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #region EnableVirtualModuleSplitting

        public void EnableVirtualModuleSplitting(int enableSplitting)
        {
            HRESULT hr;

            if ((hr = TryEnableVirtualModuleSplitting(enableSplitting)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEnableVirtualModuleSplitting(int enableSplitting)
        {
            /*HRESULT EnableVirtualModuleSplitting(int enableSplitting);*/
            return Raw6.EnableVirtualModuleSplitting(enableSplitting);
        }

        #endregion
        #region MarkDebuggerAttached

        public void MarkDebuggerAttached(int fIsAttached)
        {
            HRESULT hr;

            if ((hr = TryMarkDebuggerAttached(fIsAttached)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryMarkDebuggerAttached(int fIsAttached)
        {
            /*HRESULT MarkDebuggerAttached(int fIsAttached);*/
            return Raw6.MarkDebuggerAttached(fIsAttached);
        }

        #endregion
        #region GetExportStepInfo

        public GetExportStepInfoResult GetExportStepInfo(string pszExportName)
        {
            HRESULT hr;
            GetExportStepInfoResult result;

            if ((hr = TryGetExportStepInfo(pszExportName, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetExportStepInfo(string pszExportName, out GetExportStepInfoResult result)
        {
            /*HRESULT GetExportStepInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string pszExportName,
            out CorDebugCodeInvokeKind pInvokeKind,
            out CorDebugCodeInvokePurpose pInvokePurpose);*/
            CorDebugCodeInvokeKind pInvokeKind;
            CorDebugCodeInvokePurpose pInvokePurpose;
            HRESULT hr = Raw6.GetExportStepInfo(pszExportName, out pInvokeKind, out pInvokePurpose);

            if (hr == HRESULT.S_OK)
                result = new GetExportStepInfoResult(pInvokeKind, pInvokePurpose);
            else
                result = default(GetExportStepInfoResult);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugProcess7

        public ICorDebugProcess7 Raw7 => (ICorDebugProcess7) Raw;

        #region SetWriteableMetadataUpdateMode

        public void SetWriteableMetadataUpdateMode(WriteableMetadataUpdateMode flags)
        {
            HRESULT hr;

            if ((hr = TrySetWriteableMetadataUpdateMode(flags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetWriteableMetadataUpdateMode(WriteableMetadataUpdateMode flags)
        {
            /*HRESULT SetWriteableMetadataUpdateMode(WriteableMetadataUpdateMode flags);*/
            return Raw7.SetWriteableMetadataUpdateMode(flags);
        }

        #endregion
        #endregion
        #region ICorDebugProcess8

        public ICorDebugProcess8 Raw8 => (ICorDebugProcess8) Raw;

        #region EnableExceptionCallbacksOutsideOfMyCode

        public void EnableExceptionCallbacksOutsideOfMyCode(int enableExceptionsOutsideOfJMC)
        {
            HRESULT hr;

            if ((hr = TryEnableExceptionCallbacksOutsideOfMyCode(enableExceptionsOutsideOfJMC)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEnableExceptionCallbacksOutsideOfMyCode(int enableExceptionsOutsideOfJMC)
        {
            /*HRESULT EnableExceptionCallbacksOutsideOfMyCode([In] int enableExceptionsOutsideOfJMC);*/
            return Raw8.EnableExceptionCallbacksOutsideOfMyCode(enableExceptionsOutsideOfJMC);
        }

        #endregion
        #endregion
    }
}