using System;
using System.Diagnostics;
using System.Text;

namespace ClrDebug
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
                CLRDataProcessFlag flags;
                TryGetFlags(out flags).ThrowOnNotOK();

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
                XCLRDataValue valueResult;
                TryGetManagedObject(out valueResult).ThrowOnNotOK();

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
                int state;
                TryGetDesiredExecutionState(out state).ThrowOnNotOK();

                return state;
            }
            set
            {
                TrySetDesiredExecutionState(value).ThrowOnNotOK();
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
                int flags;
                TryGetOtherNotificationFlags(out flags).ThrowOnNotOK();

                return flags;
            }
            set
            {
                TrySetOtherNotificationFlags(value).ThrowOnNotOK();
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
            TryFlush().ThrowOnNotOK();
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
            IntPtr handle;
            TryStartEnumTasks(out handle).ThrowOnNotOK();

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

        public XCLRDataTask EnumTask(ref IntPtr handle)
        {
            XCLRDataTask taskResult;
            TryEnumTask(ref handle, out taskResult).ThrowOnNotOK();

            return taskResult;
        }

        public HRESULT TryEnumTask(ref IntPtr handle, out XCLRDataTask taskResult)
        {
            /*HRESULT EnumTask(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTask task);*/
            IXCLRDataTask task;
            HRESULT hr = Raw.EnumTask(ref handle, out task);

            if (hr == HRESULT.S_OK)
                taskResult = new XCLRDataTask(task);
            else
                taskResult = default(XCLRDataTask);

            return hr;
        }

        #endregion
        #region EndEnumTasks

        public void EndEnumTasks(IntPtr handle)
        {
            TryEndEnumTasks(handle).ThrowOnNotOK();
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
            XCLRDataTask taskResult;
            TryGetTaskByOSThreadID(osThreadID, out taskResult).ThrowOnNotOK();

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
            XCLRDataTask taskResult;
            TryGetTaskByUniqueID(taskID, out taskResult).ThrowOnNotOK();

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
            HRESULT hr = TryIsSameObject(process);
            hr.ThrowOnNotOK();

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
            CLRDataAddressType type;
            TryGetAddressType(address, out type).ThrowOnNotOK();

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
            GetRuntimeNameByAddressResult result;
            TryGetRuntimeNameByAddress(address, flags, out result).ThrowOnNotOK();

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
            IntPtr handle;
            TryStartEnumAppDomains(out handle).ThrowOnNotOK();

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

        public XCLRDataAppDomain EnumAppDomain(ref IntPtr handle)
        {
            XCLRDataAppDomain appDomainResult;
            TryEnumAppDomain(ref handle, out appDomainResult).ThrowOnNotOK();

            return appDomainResult;
        }

        public HRESULT TryEnumAppDomain(ref IntPtr handle, out XCLRDataAppDomain appDomainResult)
        {
            /*HRESULT EnumAppDomain(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataAppDomain appDomain);*/
            IXCLRDataAppDomain appDomain;
            HRESULT hr = Raw.EnumAppDomain(ref handle, out appDomain);

            if (hr == HRESULT.S_OK)
                appDomainResult = new XCLRDataAppDomain(appDomain);
            else
                appDomainResult = default(XCLRDataAppDomain);

            return hr;
        }

        #endregion
        #region EndEnumAppDomains

        public void EndEnumAppDomains(IntPtr handle)
        {
            TryEndEnumAppDomains(handle).ThrowOnNotOK();
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
            XCLRDataAppDomain appDomainResult;
            TryGetAppDomainByUniqueID(id, out appDomainResult).ThrowOnNotOK();

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
            IntPtr handle;
            TryStartEnumAssemblies(out handle).ThrowOnNotOK();

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

        public XCLRDataAssembly EnumAssembly(ref IntPtr handle)
        {
            XCLRDataAssembly assemblyResult;
            TryEnumAssembly(ref handle, out assemblyResult).ThrowOnNotOK();

            return assemblyResult;
        }

        public HRESULT TryEnumAssembly(ref IntPtr handle, out XCLRDataAssembly assemblyResult)
        {
            /*HRESULT EnumAssembly(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataAssembly assembly);*/
            IXCLRDataAssembly assembly;
            HRESULT hr = Raw.EnumAssembly(ref handle, out assembly);

            if (hr == HRESULT.S_OK)
                assemblyResult = new XCLRDataAssembly(assembly);
            else
                assemblyResult = default(XCLRDataAssembly);

            return hr;
        }

        #endregion
        #region EndEnumAssemblies

        public void EndEnumAssemblies(IntPtr handle)
        {
            TryEndEnumAssemblies(handle).ThrowOnNotOK();
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
            IntPtr handle;
            TryStartEnumModules(out handle).ThrowOnNotOK();

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

        public XCLRDataModule EnumModule(ref IntPtr handle)
        {
            XCLRDataModule modResult;
            TryEnumModule(ref handle, out modResult).ThrowOnNotOK();

            return modResult;
        }

        public HRESULT TryEnumModule(ref IntPtr handle, out XCLRDataModule modResult)
        {
            /*HRESULT EnumModule(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataModule mod);*/
            IXCLRDataModule mod;
            HRESULT hr = Raw.EnumModule(ref handle, out mod);

            if (hr == HRESULT.S_OK)
                modResult = new XCLRDataModule(mod);
            else
                modResult = default(XCLRDataModule);

            return hr;
        }

        #endregion
        #region EndEnumModules

        public void EndEnumModules(IntPtr handle)
        {
            TryEndEnumModules(handle).ThrowOnNotOK();
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
            XCLRDataModule modResult;
            TryGetModuleByAddress(address, out modResult).ThrowOnNotOK();

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
            IntPtr handle;
            TryStartEnumMethodInstancesByAddress(address, appDomain, out handle).ThrowOnNotOK();

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
            XCLRDataMethodInstance methodResult;
            TryEnumMethodInstanceByAddress(handle, out methodResult).ThrowOnNotOK();

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
            TryEndEnumMethodInstancesByAddress(handle).ThrowOnNotOK();
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
            GetDataByAddressResult result;
            TryGetDataByAddress(address, flags, appDomain, tlsTask, out result).ThrowOnNotOK();

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
            XCLRDataExceptionState exStateResult;
            TryGetExceptionStateByExceptionRecord(record, out exStateResult).ThrowOnNotOK();

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
            TryTranslateExceptionRecordToNotification(record, notify).ThrowOnNotOK();
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

        public void Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, IntPtr outBuffer)
        {
            TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, outBuffer).ThrowOnNotOK();
        }

        public HRESULT TryRequest(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, IntPtr outBuffer)
        {
            /*HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);*/
            return Raw.Request(reqCode, inBufferSize, inBuffer, outBufferSize, outBuffer);
        }

        #endregion
        #region CreateMemoryValue

        public XCLRDataValue CreateMemoryValue(IXCLRDataAppDomain appDomain, IXCLRDataTask tlsTask, IXCLRDataTypeInstance type, CLRDATA_ADDRESS addr)
        {
            XCLRDataValue valueResult;
            TryCreateMemoryValue(appDomain, tlsTask, type, addr, out valueResult).ThrowOnNotOK();

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
            TrySetAllTypeNotifications(mod, flags).ThrowOnNotOK();
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
            TrySetAllCodeNotifications(mod, flags).ThrowOnNotOK();
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
            int flags;
            TryGetTypeNotifications(numTokens, mods, singleMod, tokens, out flags).ThrowOnNotOK();

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
            TrySetTypeNotifications(numTokens, mods, singleMod, tokens, flags, singleFlags).ThrowOnNotOK();
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
            int flags;
            TryGetCodeNotifications(numTokens, mods, singleMod, tokens, out flags).ThrowOnNotOK();

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
            TrySetCodeNotifications(numTokens, mods, singleMod, tokens, flags, singleFlags).ThrowOnNotOK();
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
            IntPtr handle;
            TryStartEnumMethodDefinitionsByAddress(address, out handle).ThrowOnNotOK();

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
            XCLRDataMethodDefinition methodResult;
            TryEnumMethodDefinitionByAddress(handle, out methodResult).ThrowOnNotOK();

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
            TryEndEnumMethodDefinitionsByAddress(handle).ThrowOnNotOK();
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
            FollowStubResult result;
            TryFollowStub(inFlags, inAddr, inBuffer, out result).ThrowOnNotOK();

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
            FollowStub2Result result;
            TryFollowStub2(task, inFlags, inAddr, inBuffer, out result).ThrowOnNotOK();

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
            TryDumpNativeImage(loadedBase, name, display, libSupport, dis).ThrowOnNotOK();
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
                GcEvtArgs gcEvtArgs;
                TryGetGcNotification(out gcEvtArgs).ThrowOnNotOK();

                return gcEvtArgs;
            }
            set
            {
                TrySetGcNotification(value).ThrowOnNotOK();
            }
        }

        public HRESULT TryGetGcNotification(out GcEvtArgs gcEvtArgs)
        {
            /*HRESULT GetGcNotification(
            [Out] out GcEvtArgs gcEvtArgs);*/
            return Raw2.GetGcNotification(out gcEvtArgs);
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
