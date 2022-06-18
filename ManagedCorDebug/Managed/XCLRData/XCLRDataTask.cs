using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class XCLRDataTask : ComObject<IXCLRDataTask>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataTask"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataTask(IXCLRDataTask raw) : base(raw)
        {
        }

        #region IXCLRDataTask
        #region Process

        public XCLRDataProcess Process
        {
            get
            {
                HRESULT hr;
                XCLRDataProcess processResult;

                if ((hr = TryGetProcess(out processResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return processResult;
            }
        }

        public HRESULT TryGetProcess(out XCLRDataProcess processResult)
        {
            /*HRESULT GetProcess(
            [Out] out IXCLRDataProcess process);*/
            IXCLRDataProcess process;
            HRESULT hr = Raw.GetProcess(out process);

            if (hr == HRESULT.S_OK)
                processResult = new XCLRDataProcess(process);
            else
                processResult = default(XCLRDataProcess);

            return hr;
        }

        #endregion
        #region CurrentAppDomain

        public XCLRDataAppDomain CurrentAppDomain
        {
            get
            {
                HRESULT hr;
                XCLRDataAppDomain appDomainResult;

                if ((hr = TryGetCurrentAppDomain(out appDomainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return appDomainResult;
            }
        }

        public HRESULT TryGetCurrentAppDomain(out XCLRDataAppDomain appDomainResult)
        {
            /*HRESULT GetCurrentAppDomain(
            [Out] out IXCLRDataAppDomain appDomain);*/
            IXCLRDataAppDomain appDomain;
            HRESULT hr = Raw.GetCurrentAppDomain(out appDomain);

            if (hr == HRESULT.S_OK)
                appDomainResult = new XCLRDataAppDomain(appDomain);
            else
                appDomainResult = default(XCLRDataAppDomain);

            return hr;
        }

        #endregion
        #region UniqueID

        public long UniqueID
        {
            get
            {
                HRESULT hr;
                long id;

                if ((hr = TryGetUniqueID(out id)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return id;
            }
        }

        public HRESULT TryGetUniqueID(out long id)
        {
            /*HRESULT GetUniqueID(
            [Out] out long id);*/
            return Raw.GetUniqueID(out id);
        }

        #endregion
        #region Flags

        public int Flags
        {
            get
            {
                HRESULT hr;
                int flags;

                if ((hr = TryGetFlags(out flags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return flags;
            }
        }

        public HRESULT TryGetFlags(out int flags)
        {
            /*HRESULT GetFlags(
            [Out] out int flags);*/
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
        #region OSThreadID

        public int OSThreadID
        {
            get
            {
                HRESULT hr;
                int id;

                if ((hr = TryGetOSThreadID(out id)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return id;
            }
        }

        public HRESULT TryGetOSThreadID(out int id)
        {
            /*HRESULT GetOSThreadID(
            [Out] out int id);*/
            return Raw.GetOSThreadID(out id);
        }

        #endregion
        #region CurrentExceptionState

        public XCLRDataExceptionState CurrentExceptionState
        {
            get
            {
                HRESULT hr;
                XCLRDataExceptionState exceptionResult;

                if ((hr = TryGetCurrentExceptionState(out exceptionResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return exceptionResult;
            }
        }

        public HRESULT TryGetCurrentExceptionState(out XCLRDataExceptionState exceptionResult)
        {
            /*HRESULT GetCurrentExceptionState(
            [Out] out IXCLRDataExceptionState exception);*/
            IXCLRDataExceptionState exception;
            HRESULT hr = Raw.GetCurrentExceptionState(out exception);

            if (hr == HRESULT.S_OK)
                exceptionResult = new XCLRDataExceptionState(exception);
            else
                exceptionResult = default(XCLRDataExceptionState);

            return hr;
        }

        #endregion
        #region Name

        public string Name
        {
            get
            {
                HRESULT hr;
                string nameResult;

                if ((hr = TryGetName(out nameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return nameResult;
            }
        }

        public HRESULT TryGetName(out string nameResult)
        {
            /*HRESULT GetName(
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);*/
            int bufLen = 0;
            int nameLen;
            StringBuilder name = null;
            HRESULT hr = Raw.GetName(bufLen, out nameLen, name);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            name = new StringBuilder(nameLen);
            hr = Raw.GetName(bufLen, out nameLen, name);

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
        #region LastExceptionState

        public XCLRDataExceptionState LastExceptionState
        {
            get
            {
                HRESULT hr;
                XCLRDataExceptionState exceptionResult;

                if ((hr = TryGetLastExceptionState(out exceptionResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return exceptionResult;
            }
        }

        public HRESULT TryGetLastExceptionState(out XCLRDataExceptionState exceptionResult)
        {
            /*HRESULT GetLastExceptionState(
            [Out] out IXCLRDataExceptionState exception);*/
            IXCLRDataExceptionState exception;
            HRESULT hr = Raw.GetLastExceptionState(out exception);

            if (hr == HRESULT.S_OK)
                exceptionResult = new XCLRDataExceptionState(exception);
            else
                exceptionResult = default(XCLRDataExceptionState);

            return hr;
        }

        #endregion
        #region IsSameObject

        public bool IsSameObject(IXCLRDataTask task)
        {
            HRESULT hr;

            if ((hr = TryIsSameObject(task)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataTask task)
        {
            /*HRESULT IsSameObject(
            [In] IXCLRDataTask task);*/
            return Raw.IsSameObject(task);
        }

        #endregion
        #region CreateStackWalk

        public XCLRDataStackWalk CreateStackWalk(int flags)
        {
            HRESULT hr;
            XCLRDataStackWalk stackWalkResult;

            if ((hr = TryCreateStackWalk(flags, out stackWalkResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return stackWalkResult;
        }

        public HRESULT TryCreateStackWalk(int flags, out XCLRDataStackWalk stackWalkResult)
        {
            /*HRESULT CreateStackWalk(
            [In] int flags,
            [Out] out IXCLRDataStackWalk stackWalk);*/
            IXCLRDataStackWalk stackWalk;
            HRESULT hr = Raw.CreateStackWalk(flags, out stackWalk);

            if (hr == HRESULT.S_OK)
                stackWalkResult = new XCLRDataStackWalk(stackWalk);
            else
                stackWalkResult = default(XCLRDataStackWalk);

            return hr;
        }

        #endregion
        #region GetContext

        public GetContextResult GetContext(int contextFlags, int contextBufSize)
        {
            HRESULT hr;
            GetContextResult result;

            if ((hr = TryGetContext(contextFlags, contextBufSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetContext(int contextFlags, int contextBufSize, out GetContextResult result)
        {
            /*HRESULT GetContext(
            [In] int contextFlags,
            [In] int contextBufSize,
            [Out] out int contextSize,
            [In, Out] ref IntPtr contextBuf);*/
            int contextSize;
            IntPtr contextBuf = default(IntPtr);
            HRESULT hr = Raw.GetContext(contextFlags, contextBufSize, out contextSize, ref contextBuf);

            if (hr == HRESULT.S_OK)
                result = new GetContextResult(contextSize, contextBuf);
            else
                result = default(GetContextResult);

            return hr;
        }

        #endregion
        #region SetContext

        public void SetContext(int contextSize, IntPtr context)
        {
            HRESULT hr;

            if ((hr = TrySetContext(contextSize, context)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetContext(int contextSize, IntPtr context)
        {
            /*HRESULT SetContext(
            [In] int contextSize,
            [In] IntPtr context);*/
            return Raw.SetContext(contextSize, context);
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
        #endregion
    }
}