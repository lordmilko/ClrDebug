using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class XCLRDataProcess : ComObject<IXCLRDataProcess>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataProcess"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataProcess(IXCLRDataProcess raw) : base(raw)
        {
        }

        #region IXCLRDataProcess
        #region Flags

        public CLRDataProcessFlag Flags
        {
            get
            {
                HRESULT hr;
                CLRDataProcessFlag flags;

                if ((hr = TryGetFlags(out flags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return flags;
            }
        }

        public HRESULT TryGetFlags(out CLRDataProcessFlag flags)
        {
            /*HRESULT GetFlags(
            [Out] out CLRDataProcessFlag flags);*/
            return Raw.GetFlags(out flags);
        }

        #endregion
        #region ManagedObject

        public XCLRDataValue ManagedObject
        {
            get
            {
                HRESULT hr;
                XCLRDataValue valueResult;

                if ((hr = TryGetManagedObject(out valueResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return valueResult;
            }
        }

        public HRESULT TryGetManagedObject(out XCLRDataValue valueResult)
        {
            /*HRESULT GetManagedObject(
            [Out] out IXCLRDataValue value);*/
            IXCLRDataValue value;
            HRESULT hr = Raw.GetManagedObject(out value);

            if (hr == HRESULT.S_OK)
                valueResult = new XCLRDataValue(value);
            else
                valueResult = default(XCLRDataValue);

            return hr;
        }

        #endregion
        #region DesiredExecutionState

        public int DesiredExecutionState
        {
            get
            {
                HRESULT hr;
                int state;

                if ((hr = TryGetDesiredExecutionState(out state)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return state;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetDesiredExecutionState(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetDesiredExecutionState(out int state)
        {
            /*HRESULT GetDesiredExecutionState(
            [Out] out int state);*/
            return Raw.GetDesiredExecutionState(out state);
        }

        public HRESULT TrySetDesiredExecutionState(int state)
        {
            /*HRESULT SetDesiredExecutionState(
            [In] int state);*/
            return Raw.SetDesiredExecutionState(state);
        }

        #endregion
        #region OtherNotificationFlags

        public int OtherNotificationFlags
        {
            get
            {
                HRESULT hr;
                int flags;

                if ((hr = TryGetOtherNotificationFlags(out flags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return flags;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetOtherNotificationFlags(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetOtherNotificationFlags(out int flags)
        {
            /*HRESULT GetOtherNotificationFlags(
            [Out] out int flags);*/
            return Raw.GetOtherNotificationFlags(out flags);
        }

        public HRESULT TrySetOtherNotificationFlags(int flags)
        {
            /*HRESULT SetOtherNotificationFlags(
            [In] int flags);*/
            return Raw.SetOtherNotificationFlags(flags);
        }

        #endregion
        #region Flush

        public void Flush()
        {
            HRESULT hr;

            if ((hr = TryFlush()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryFlush()
        {
            /*HRESULT Flush();*/
            return Raw.Flush();
        }

        #endregion
        #region StartEnumTasks

        public IntPtr StartEnumTasks()
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumTasks(out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumTasks(out IntPtr handle)
        {
            /*HRESULT StartEnumTasks(
            [Out] out IntPtr handle);*/
            return Raw.StartEnumTasks(out handle);
        }

        #endregion
        #region EnumTask

        public EnumTaskResult EnumTask()
        {
            HRESULT hr;
            EnumTaskResult result;

            if ((hr = TryEnumTask(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumTask(out EnumTaskResult result)
        {
            /*HRESULT EnumTask(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTask task);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataTask task;
            HRESULT hr = Raw.EnumTask(ref handle, out task);

            if (hr == HRESULT.S_OK)
                result = new EnumTaskResult(handle, new XCLRDataTask(task));
            else
                result = default(EnumTaskResult);

            return hr;
        }

        #endregion
        #region EndEnumTasks

        public void EndEnumTasks(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumTasks(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumTasks(IntPtr handle)
        {
            /*HRESULT EndEnumTasks(
            [In] IntPtr handle);*/
            return Raw.EndEnumTasks(handle);
        }

        #endregion
        #region GetTaskByOSThreadID

        public XCLRDataTask GetTaskByOSThreadID(int osThreadID)
        {
            HRESULT hr;
            XCLRDataTask taskResult;

            if ((hr = TryGetTaskByOSThreadID(osThreadID, out taskResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return taskResult;
        }

        public HRESULT TryGetTaskByOSThreadID(int osThreadID, out XCLRDataTask taskResult)
        {
            /*HRESULT GetTaskByOSThreadID(
            [In] int osThreadID,
            [Out] out IXCLRDataTask task);*/
            IXCLRDataTask task;
            HRESULT hr = Raw.GetTaskByOSThreadID(osThreadID, out task);

            if (hr == HRESULT.S_OK)
                taskResult = new XCLRDataTask(task);
            else
                taskResult = default(XCLRDataTask);

            return hr;
        }

        #endregion
        #region GetTaskByUniqueID

        public XCLRDataTask GetTaskByUniqueID(long taskID)
        {
            HRESULT hr;
            XCLRDataTask taskResult;

            if ((hr = TryGetTaskByUniqueID(taskID, out taskResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return taskResult;
        }

        public HRESULT TryGetTaskByUniqueID(long taskID, out XCLRDataTask taskResult)
        {
            /*HRESULT GetTaskByUniqueID(
            [In] long taskID,
            [Out] out IXCLRDataTask task);*/
            IXCLRDataTask task;
            HRESULT hr = Raw.GetTaskByUniqueID(taskID, out task);

            if (hr == HRESULT.S_OK)
                taskResult = new XCLRDataTask(task);
            else
                taskResult = default(XCLRDataTask);

            return hr;
        }

        #endregion
        #region IsSameObject

        public bool IsSameObject(IXCLRDataProcess process)
        {
            HRESULT hr;

            if ((hr = TryIsSameObject(process)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataProcess process)
        {
            /*HRESULT IsSameObject(
            [In] IXCLRDataProcess process);*/
            return Raw.IsSameObject(process);
        }

        #endregion
        #region GetAddressType

        public CLRDataAddressType GetAddressType(CLRDATA_ADDRESS address)
        {
            HRESULT hr;
            CLRDataAddressType type;

            if ((hr = TryGetAddressType(address, out type)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return type;
        }

        public HRESULT TryGetAddressType(CLRDATA_ADDRESS address, out CLRDataAddressType type)
        {
            /*HRESULT GetAddressType(
            [In] CLRDATA_ADDRESS address,
            [Out] out CLRDataAddressType type);*/
            return Raw.GetAddressType(address, out type);
        }

        #endregion
        #region GetRuntimeNameByAddress

        public GetRuntimeNameByAddressResult GetRuntimeNameByAddress(CLRDATA_ADDRESS address, int flags)
        {
            HRESULT hr;
            GetRuntimeNameByAddressResult result;

            if ((hr = TryGetRuntimeNameByAddress(address, flags, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetRuntimeNameByAddress(CLRDATA_ADDRESS address, int flags, out GetRuntimeNameByAddressResult result)
        {
            /*HRESULT GetRuntimeNameByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] int flags,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out CLRDATA_ADDRESS displacement);*/
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            CLRDATA_ADDRESS displacement;
            HRESULT hr = Raw.GetRuntimeNameByAddress(address, flags, bufLen, out nameLen, nameBuf, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetRuntimeNameByAddress(address, flags, bufLen, out nameLen, nameBuf, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetRuntimeNameByAddressResult(nameBuf.ToString(), displacement);

                return hr;
            }

            fail:
            result = default(GetRuntimeNameByAddressResult);

            return hr;
        }

        #endregion
        #region StartEnumAppDomains

        public IntPtr StartEnumAppDomains()
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumAppDomains(out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumAppDomains(out IntPtr handle)
        {
            /*HRESULT StartEnumAppDomains(
            [Out] out IntPtr handle);*/
            return Raw.StartEnumAppDomains(out handle);
        }

        #endregion
        #region EnumAppDomain

        public EnumAppDomainResult EnumAppDomain()
        {
            HRESULT hr;
            EnumAppDomainResult result;

            if ((hr = TryEnumAppDomain(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumAppDomain(out EnumAppDomainResult result)
        {
            /*HRESULT EnumAppDomain(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataAppDomain appDomain);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataAppDomain appDomain;
            HRESULT hr = Raw.EnumAppDomain(ref handle, out appDomain);

            if (hr == HRESULT.S_OK)
                result = new EnumAppDomainResult(handle, new XCLRDataAppDomain(appDomain));
            else
                result = default(EnumAppDomainResult);

            return hr;
        }

        #endregion
        #region EndEnumAppDomains

        public void EndEnumAppDomains(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumAppDomains(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumAppDomains(IntPtr handle)
        {
            /*HRESULT EndEnumAppDomains(
            [In] IntPtr handle);*/
            return Raw.EndEnumAppDomains(handle);
        }

        #endregion
        #region GetAppDomainByUniqueID

        public XCLRDataAppDomain GetAppDomainByUniqueID(long id)
        {
            HRESULT hr;
            XCLRDataAppDomain appDomainResult;

            if ((hr = TryGetAppDomainByUniqueID(id, out appDomainResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return appDomainResult;
        }

        public HRESULT TryGetAppDomainByUniqueID(long id, out XCLRDataAppDomain appDomainResult)
        {
            /*HRESULT GetAppDomainByUniqueID(
            [In] long id,
            [Out] out IXCLRDataAppDomain appDomain);*/
            IXCLRDataAppDomain appDomain;
            HRESULT hr = Raw.GetAppDomainByUniqueID(id, out appDomain);

            if (hr == HRESULT.S_OK)
                appDomainResult = new XCLRDataAppDomain(appDomain);
            else
                appDomainResult = default(XCLRDataAppDomain);

            return hr;
        }

        #endregion
        #region StartEnumAssemblies

        public IntPtr StartEnumAssemblies()
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumAssemblies(out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumAssemblies(out IntPtr handle)
        {
            /*HRESULT StartEnumAssemblies(
            [Out] out IntPtr handle);*/
            return Raw.StartEnumAssemblies(out handle);
        }

        #endregion
        #region EnumAssembly

        public EnumAssemblyResult EnumAssembly()
        {
            HRESULT hr;
            EnumAssemblyResult result;

            if ((hr = TryEnumAssembly(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumAssembly(out EnumAssemblyResult result)
        {
            /*HRESULT EnumAssembly(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataAssembly assembly);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataAssembly assembly;
            HRESULT hr = Raw.EnumAssembly(ref handle, out assembly);

            if (hr == HRESULT.S_OK)
                result = new EnumAssemblyResult(handle, new XCLRDataAssembly(assembly));
            else
                result = default(EnumAssemblyResult);

            return hr;
        }

        #endregion
        #region EndEnumAssemblies

        public void EndEnumAssemblies(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumAssemblies(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumAssemblies(IntPtr handle)
        {
            /*HRESULT EndEnumAssemblies(
            [In] IntPtr handle);*/
            return Raw.EndEnumAssemblies(handle);
        }

        #endregion
        #region StartEnumModules

        public IntPtr StartEnumModules()
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumModules(out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumModules(out IntPtr handle)
        {
            /*HRESULT StartEnumModules(
            [Out] out IntPtr handle);*/
            return Raw.StartEnumModules(out handle);
        }

        #endregion
        #region EnumModule

        public EnumModuleResult EnumModule()
        {
            HRESULT hr;
            EnumModuleResult result;

            if ((hr = TryEnumModule(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumModule(out EnumModuleResult result)
        {
            /*HRESULT EnumModule(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataModule mod);*/
            IntPtr handle = default(IntPtr);
            IXCLRDataModule mod;
            HRESULT hr = Raw.EnumModule(ref handle, out mod);

            if (hr == HRESULT.S_OK)
                result = new EnumModuleResult(handle, new XCLRDataModule(mod));
            else
                result = default(EnumModuleResult);

            return hr;
        }

        #endregion
        #region EndEnumModules

        public void EndEnumModules(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumModules(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumModules(IntPtr handle)
        {
            /*HRESULT EndEnumModules(
            [In] IntPtr handle);*/
            return Raw.EndEnumModules(handle);
        }

        #endregion
        #region GetModuleByAddress

        public XCLRDataModule GetModuleByAddress(CLRDATA_ADDRESS address)
        {
            HRESULT hr;
            XCLRDataModule modResult;

            if ((hr = TryGetModuleByAddress(address, out modResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return modResult;
        }

        public HRESULT TryGetModuleByAddress(CLRDATA_ADDRESS address, out XCLRDataModule modResult)
        {
            /*HRESULT GetModuleByAddress(
            [In] CLRDATA_ADDRESS address,
            [Out] out IXCLRDataModule mod);*/
            IXCLRDataModule mod;
            HRESULT hr = Raw.GetModuleByAddress(address, out mod);

            if (hr == HRESULT.S_OK)
                modResult = new XCLRDataModule(mod);
            else
                modResult = default(XCLRDataModule);

            return hr;
        }

        #endregion
        #region StartEnumMethodInstancesByAddress

        public IntPtr StartEnumMethodInstancesByAddress(CLRDATA_ADDRESS address, IXCLRDataAppDomain appDomain)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumMethodInstancesByAddress(address, appDomain, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumMethodInstancesByAddress(CLRDATA_ADDRESS address, IXCLRDataAppDomain appDomain, out IntPtr handle)
        {
            /*HRESULT StartEnumMethodInstancesByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodInstancesByAddress(address, appDomain, out handle);
        }

        #endregion
        #region EnumMethodInstanceByAddress

        public XCLRDataMethodInstance EnumMethodInstanceByAddress(IntPtr handle)
        {
            HRESULT hr;
            XCLRDataMethodInstance methodResult;

            if ((hr = TryEnumMethodInstanceByAddress(handle, out methodResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return methodResult;
        }

        public HRESULT TryEnumMethodInstanceByAddress(IntPtr handle, out XCLRDataMethodInstance methodResult)
        {
            /*HRESULT EnumMethodInstanceByAddress(
            [In] IntPtr handle,
            [Out] out IXCLRDataMethodInstance method);*/
            IXCLRDataMethodInstance method;
            HRESULT hr = Raw.EnumMethodInstanceByAddress(handle, out method);

            if (hr == HRESULT.S_OK)
                methodResult = new XCLRDataMethodInstance(method);
            else
                methodResult = default(XCLRDataMethodInstance);

            return hr;
        }

        #endregion
        #region EndEnumMethodInstancesByAddress

        public void EndEnumMethodInstancesByAddress(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumMethodInstancesByAddress(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumMethodInstancesByAddress(IntPtr handle)
        {
            /*HRESULT EndEnumMethodInstancesByAddress(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodInstancesByAddress(handle);
        }

        #endregion
        #region GetDataByAddress

        public GetDataByAddressResult GetDataByAddress(CLRDATA_ADDRESS address, int flags, IXCLRDataAppDomain appDomain, IXCLRDataTask tlsTask)
        {
            HRESULT hr;
            GetDataByAddressResult result;

            if ((hr = TryGetDataByAddress(address, flags, appDomain, tlsTask, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetDataByAddress(CLRDATA_ADDRESS address, int flags, IXCLRDataAppDomain appDomain, IXCLRDataTask tlsTask, out GetDataByAddressResult result)
        {
            /*HRESULT GetDataByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] int flags,
            [In] IXCLRDataAppDomain appDomain,
            [In] IXCLRDataTask tlsTask,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataValue value,
            [Out] out CLRDATA_ADDRESS displacement);*/
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            IXCLRDataValue value;
            CLRDATA_ADDRESS displacement;
            HRESULT hr = Raw.GetDataByAddress(address, flags, appDomain, tlsTask, bufLen, out nameLen, nameBuf, out value, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetDataByAddress(address, flags, appDomain, tlsTask, bufLen, out nameLen, nameBuf, out value, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetDataByAddressResult(nameBuf.ToString(), new XCLRDataValue(value), displacement);

                return hr;
            }

            fail:
            result = default(GetDataByAddressResult);

            return hr;
        }

        #endregion
        #region GetExceptionStateByExceptionRecord

        public XCLRDataExceptionState GetExceptionStateByExceptionRecord(EXCEPTION_RECORD64 record)
        {
            HRESULT hr;
            XCLRDataExceptionState exStateResult;

            if ((hr = TryGetExceptionStateByExceptionRecord(record, out exStateResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return exStateResult;
        }

        public HRESULT TryGetExceptionStateByExceptionRecord(EXCEPTION_RECORD64 record, out XCLRDataExceptionState exStateResult)
        {
            /*HRESULT GetExceptionStateByExceptionRecord(
            [In] EXCEPTION_RECORD64 record,
            [Out] out IXCLRDataExceptionState exState);*/
            IXCLRDataExceptionState exState;
            HRESULT hr = Raw.GetExceptionStateByExceptionRecord(record, out exState);

            if (hr == HRESULT.S_OK)
                exStateResult = new XCLRDataExceptionState(exState);
            else
                exStateResult = default(XCLRDataExceptionState);

            return hr;
        }

        #endregion
        #region TranslateExceptionRecordToNotification

        public void TranslateExceptionRecordToNotification(EXCEPTION_RECORD64 record, IXCLRDataExceptionNotification notify)
        {
            HRESULT hr;

            if ((hr = TryTranslateExceptionRecordToNotification(record, notify)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryTranslateExceptionRecordToNotification(EXCEPTION_RECORD64 record, IXCLRDataExceptionNotification notify)
        {
            /*HRESULT TranslateExceptionRecordToNotification(
            [In] ref EXCEPTION_RECORD64 record,
            [In] IXCLRDataExceptionNotification notify);*/
            return Raw.TranslateExceptionRecordToNotification(ref record, notify);
        }

        #endregion
        #region Request

        public IntPtr Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize)
        {
            HRESULT hr;
            IntPtr outBuffer = default(IntPtr);

            if ((hr = TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, ref outBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return outBuffer;
        }

        public HRESULT TryRequest(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, ref IntPtr outBuffer)
        {
            /*HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [In, Out] ref IntPtr outBuffer);*/
            return Raw.Request(reqCode, inBufferSize, inBuffer, outBufferSize, ref outBuffer);
        }

        #endregion
        #region CreateMemoryValue

        public XCLRDataValue CreateMemoryValue(IXCLRDataAppDomain appDomain, IXCLRDataTask tlsTask, IXCLRDataTypeInstance type, CLRDATA_ADDRESS addr)
        {
            HRESULT hr;
            XCLRDataValue valueResult;

            if ((hr = TryCreateMemoryValue(appDomain, tlsTask, type, addr, out valueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return valueResult;
        }

        public HRESULT TryCreateMemoryValue(IXCLRDataAppDomain appDomain, IXCLRDataTask tlsTask, IXCLRDataTypeInstance type, CLRDATA_ADDRESS addr, out XCLRDataValue valueResult)
        {
            /*HRESULT CreateMemoryValue(
            [In] IXCLRDataAppDomain appDomain,
            [In] IXCLRDataTask tlsTask,
            [In] IXCLRDataTypeInstance type,
            [In] CLRDATA_ADDRESS addr,
            [Out] out IXCLRDataValue value);*/
            IXCLRDataValue value;
            HRESULT hr = Raw.CreateMemoryValue(appDomain, tlsTask, type, addr, out value);

            if (hr == HRESULT.S_OK)
                valueResult = new XCLRDataValue(value);
            else
                valueResult = default(XCLRDataValue);

            return hr;
        }

        #endregion
        #region SetAllTypeNotifications

        public void SetAllTypeNotifications(IXCLRDataModule mod, int flags)
        {
            HRESULT hr;

            if ((hr = TrySetAllTypeNotifications(mod, flags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetAllTypeNotifications(IXCLRDataModule mod, int flags)
        {
            /*HRESULT SetAllTypeNotifications(
            [In] IXCLRDataModule mod,
            [In] int flags);*/
            return Raw.SetAllTypeNotifications(mod, flags);
        }

        #endregion
        #region SetAllCodeNotifications

        public void SetAllCodeNotifications(IXCLRDataModule mod, int flags)
        {
            HRESULT hr;

            if ((hr = TrySetAllCodeNotifications(mod, flags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetAllCodeNotifications(IXCLRDataModule mod, int flags)
        {
            /*HRESULT SetAllCodeNotifications(
            [In] IXCLRDataModule mod,
            [In] int flags);*/
            return Raw.SetAllCodeNotifications(mod, flags);
        }

        #endregion
        #region GetTypeNotifications

        public int GetTypeNotifications(int numTokens, IXCLRDataModule[] mods, IXCLRDataModule singleMod, mdTypeDef tokens)
        {
            HRESULT hr;
            int flags;

            if ((hr = TryGetTypeNotifications(numTokens, mods, singleMod, tokens, out flags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return flags;
        }

        public HRESULT TryGetTypeNotifications(int numTokens, IXCLRDataModule[] mods, IXCLRDataModule singleMod, mdTypeDef tokens, out int flags)
        {
            /*HRESULT GetTypeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In] mdTypeDef tokens,
            [Out] out int flags);*/
            return Raw.GetTypeNotifications(numTokens, mods, singleMod, tokens, out flags);
        }

        #endregion
        #region SetTypeNotifications

        public void SetTypeNotifications(int numTokens, IXCLRDataModule[] mods, IXCLRDataModule singleMod, mdTypeDef tokens, int flags, int singleFlags)
        {
            HRESULT hr;

            if ((hr = TrySetTypeNotifications(numTokens, mods, singleMod, tokens, flags, singleFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetTypeNotifications(int numTokens, IXCLRDataModule[] mods, IXCLRDataModule singleMod, mdTypeDef tokens, int flags, int singleFlags)
        {
            /*HRESULT SetTypeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In] mdTypeDef tokens,
            [In] int flags,
            [In] int singleFlags);*/
            return Raw.SetTypeNotifications(numTokens, mods, singleMod, tokens, flags, singleFlags);
        }

        #endregion
        #region GetCodeNotifications

        public int GetCodeNotifications(int numTokens, IXCLRDataModule[] mods, IXCLRDataModule singleMod, mdMethodDef tokens)
        {
            HRESULT hr;
            int flags;

            if ((hr = TryGetCodeNotifications(numTokens, mods, singleMod, tokens, out flags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return flags;
        }

        public HRESULT TryGetCodeNotifications(int numTokens, IXCLRDataModule[] mods, IXCLRDataModule singleMod, mdMethodDef tokens, out int flags)
        {
            /*HRESULT GetCodeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In] mdMethodDef tokens,
            [Out] out int flags);*/
            return Raw.GetCodeNotifications(numTokens, mods, singleMod, tokens, out flags);
        }

        #endregion
        #region SetCodeNotifications

        public void SetCodeNotifications(int numTokens, IXCLRDataModule[] mods, IXCLRDataModule singleMod, mdMethodDef tokens, int flags, int singleFlags)
        {
            HRESULT hr;

            if ((hr = TrySetCodeNotifications(numTokens, mods, singleMod, tokens, flags, singleFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetCodeNotifications(int numTokens, IXCLRDataModule[] mods, IXCLRDataModule singleMod, mdMethodDef tokens, int flags, int singleFlags)
        {
            /*HRESULT SetCodeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In] mdMethodDef tokens,
            [In] int flags,
            [In] int singleFlags);*/
            return Raw.SetCodeNotifications(numTokens, mods, singleMod, tokens, flags, singleFlags);
        }

        #endregion
        #region StartEnumMethodDefinitionsByAddress

        public IntPtr StartEnumMethodDefinitionsByAddress(CLRDATA_ADDRESS address)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumMethodDefinitionsByAddress(address, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumMethodDefinitionsByAddress(CLRDATA_ADDRESS address, out IntPtr handle)
        {
            /*HRESULT StartEnumMethodDefinitionsByAddress(
            [In] CLRDATA_ADDRESS address,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodDefinitionsByAddress(address, out handle);
        }

        #endregion
        #region EnumMethodDefinitionByAddress

        public XCLRDataMethodDefinition EnumMethodDefinitionByAddress(IntPtr handle)
        {
            HRESULT hr;
            XCLRDataMethodDefinition methodResult;

            if ((hr = TryEnumMethodDefinitionByAddress(handle, out methodResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return methodResult;
        }

        public HRESULT TryEnumMethodDefinitionByAddress(IntPtr handle, out XCLRDataMethodDefinition methodResult)
        {
            /*HRESULT EnumMethodDefinitionByAddress(
            [In] IntPtr handle,
            [Out] out IXCLRDataMethodDefinition method);*/
            IXCLRDataMethodDefinition method;
            HRESULT hr = Raw.EnumMethodDefinitionByAddress(handle, out method);

            if (hr == HRESULT.S_OK)
                methodResult = new XCLRDataMethodDefinition(method);
            else
                methodResult = default(XCLRDataMethodDefinition);

            return hr;
        }

        #endregion
        #region EndEnumMethodDefinitionsByAddress

        public void EndEnumMethodDefinitionsByAddress(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumMethodDefinitionsByAddress(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumMethodDefinitionsByAddress(IntPtr handle)
        {
            /*HRESULT EndEnumMethodDefinitionsByAddress([In] IntPtr handle);*/
            return Raw.EndEnumMethodDefinitionsByAddress(handle);
        }

        #endregion
        #region FollowStub

        public FollowStubResult FollowStub(int inFlags, CLRDATA_ADDRESS inAddr, CLRDATA_FOLLOW_STUB_BUFFER inBuffer)
        {
            HRESULT hr;
            FollowStubResult result;

            if ((hr = TryFollowStub(inFlags, inAddr, inBuffer, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryFollowStub(int inFlags, CLRDATA_ADDRESS inAddr, CLRDATA_FOLLOW_STUB_BUFFER inBuffer, out FollowStubResult result)
        {
            /*HRESULT FollowStub(
            [In] int inFlags,
            [In] CLRDATA_ADDRESS inAddr,
            [In] ref CLRDATA_FOLLOW_STUB_BUFFER inBuffer,
            [Out] out CLRDATA_ADDRESS outAddr,
            [Out] out CLRDATA_FOLLOW_STUB_BUFFER outBuffer,
            [Out] out int outFlags);*/
            CLRDATA_ADDRESS outAddr;
            CLRDATA_FOLLOW_STUB_BUFFER outBuffer;
            int outFlags;
            HRESULT hr = Raw.FollowStub(inFlags, inAddr, ref inBuffer, out outAddr, out outBuffer, out outFlags);

            if (hr == HRESULT.S_OK)
                result = new FollowStubResult(outAddr, outBuffer, outFlags);
            else
                result = default(FollowStubResult);

            return hr;
        }

        #endregion
        #region FollowStub2

        public FollowStub2Result FollowStub2(IXCLRDataTask task, int inFlags, CLRDATA_ADDRESS inAddr, CLRDATA_FOLLOW_STUB_BUFFER inBuffer)
        {
            HRESULT hr;
            FollowStub2Result result;

            if ((hr = TryFollowStub2(task, inFlags, inAddr, inBuffer, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryFollowStub2(IXCLRDataTask task, int inFlags, CLRDATA_ADDRESS inAddr, CLRDATA_FOLLOW_STUB_BUFFER inBuffer, out FollowStub2Result result)
        {
            /*HRESULT FollowStub2(
            [In] IXCLRDataTask task,
            [In] int inFlags,
            [In] CLRDATA_ADDRESS inAddr,
            [In] ref CLRDATA_FOLLOW_STUB_BUFFER inBuffer,
            [Out] out CLRDATA_ADDRESS outAddr,
            [Out] out CLRDATA_FOLLOW_STUB_BUFFER outBuffer,
            [Out] out int outFlags);*/
            CLRDATA_ADDRESS outAddr;
            CLRDATA_FOLLOW_STUB_BUFFER outBuffer;
            int outFlags;
            HRESULT hr = Raw.FollowStub2(task, inFlags, inAddr, ref inBuffer, out outAddr, out outBuffer, out outFlags);

            if (hr == HRESULT.S_OK)
                result = new FollowStub2Result(outAddr, outBuffer, outFlags);
            else
                result = default(FollowStub2Result);

            return hr;
        }

        #endregion
        #region DumpNativeImage

        public void DumpNativeImage(CLRDATA_ADDRESS loadedBase, string name, IXCLRDataDisplay display, IXCLRLibrarySupport libSupport, IXCLRDisassemblySupport dis)
        {
            HRESULT hr;

            if ((hr = TryDumpNativeImage(loadedBase, name, display, libSupport, dis)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDumpNativeImage(CLRDATA_ADDRESS loadedBase, string name, IXCLRDataDisplay display, IXCLRLibrarySupport libSupport, IXCLRDisassemblySupport dis)
        {
            /*HRESULT DumpNativeImage([In] CLRDATA_ADDRESS loadedBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] IXCLRDataDisplay display,
            [In] IXCLRLibrarySupport libSupport,
            [In] IXCLRDisassemblySupport dis);*/
            return Raw.DumpNativeImage(loadedBase, name, display, libSupport, dis);
        }

        #endregion
        #endregion
        #region IXCLRDataProcess2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IXCLRDataProcess2 Raw2 => (IXCLRDataProcess2) Raw;

        #region GcNotification

        public GcEvtArgs GcNotification
        {
            get
            {
                HRESULT hr;
                GcEvtArgs gcEvtArgs = default(GcEvtArgs);

                if ((hr = TryGetGcNotification(ref gcEvtArgs)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return gcEvtArgs;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetGcNotification(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetGcNotification(ref GcEvtArgs gcEvtArgs)
        {
            /*HRESULT GetGcNotification(
            [In, Out] ref GcEvtArgs gcEvtArgs);*/
            return Raw2.GetGcNotification(ref gcEvtArgs);
        }

        public HRESULT TrySetGcNotification(GcEvtArgs gcEvtArgs)
        {
            /*HRESULT SetGcNotification(
            [In] GcEvtArgs gcEvtArgs);*/
            return Raw2.SetGcNotification(gcEvtArgs);
        }

        #endregion
        #endregion
    }
}