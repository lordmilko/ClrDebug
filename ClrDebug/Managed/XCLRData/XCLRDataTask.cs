using System;
using static ClrDebug.Extensions;

namespace ClrDebug
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
                XCLRDataProcess processResult;
                TryGetProcess(out processResult).ThrowOnNotOK();

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
                XCLRDataAppDomain appDomainResult;
                TryGetCurrentAppDomain(out appDomainResult).ThrowOnNotOK();

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
                long id;
                TryGetUniqueID(out id).ThrowOnNotOK();

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

        public CLRDataTaskFlag Flags
        {
            get
            {
                CLRDataTaskFlag flags;
                TryGetFlags(out flags).ThrowOnNotOK();

                return flags;
            }
        }

        public HRESULT TryGetFlags(out CLRDataTaskFlag flags)
        {
            /*HRESULT GetFlags(
            [Out] out CLRDataTaskFlag flags);*/
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
        #region OSThreadID

        public int OSThreadID
        {
            get
            {
                int id;
                TryGetOSThreadID(out id).ThrowOnNotOK();

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
                XCLRDataExceptionState exceptionResult;
                TryGetCurrentExceptionState(out exceptionResult).ThrowOnNotOK();

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
                string nameResult;
                TryGetName(out nameResult).ThrowOnNotOK();

                return nameResult;
            }
        }

        public HRESULT TryGetName(out string nameResult)
        {
            /*HRESULT GetName(
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] name);*/
            int bufLen = 0;
            int nameLen;
            char[] name;
            HRESULT hr = Raw.GetName(bufLen, out nameLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            name = new char[bufLen];
            hr = Raw.GetName(bufLen, out nameLen, name);

            if (hr == HRESULT.S_OK)
            {
                nameResult = CreateString(name, nameLen);

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
                XCLRDataExceptionState exceptionResult;
                TryGetLastExceptionState(out exceptionResult).ThrowOnNotOK();

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
            HRESULT hr = TryIsSameObject(task);
            hr.ThrowOnFailed();

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

        public XCLRDataStackWalk CreateStackWalk(CLRDataSimpleFrameType flags)
        {
            XCLRDataStackWalk stackWalkResult;
            TryCreateStackWalk(flags, out stackWalkResult).ThrowOnNotOK();

            return stackWalkResult;
        }

        public HRESULT TryCreateStackWalk(CLRDataSimpleFrameType flags, out XCLRDataStackWalk stackWalkResult)
        {
            /*HRESULT CreateStackWalk(
            [In] CLRDataSimpleFrameType flags,
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

        public int GetContext(ContextFlags contextFlags, int contextBufSize, IntPtr contextBuf)
        {
            int contextSize;
            TryGetContext(contextFlags, contextBufSize, out contextSize, contextBuf).ThrowOnNotOK();

            return contextSize;
        }

        public HRESULT TryGetContext(ContextFlags contextFlags, int contextBufSize, out int contextSize, IntPtr contextBuf)
        {
            /*HRESULT GetContext(
            [In] ContextFlags contextFlags,
            [In] int contextBufSize,
            [Out] out int contextSize,
            [Out] IntPtr contextBuf);*/
            return Raw.GetContext(contextFlags, contextBufSize, out contextSize, contextBuf);
        }

        #endregion
        #region SetContext

        public void SetContext(int contextSize, IntPtr context)
        {
            TrySetContext(contextSize, context).ThrowOnNotOK();
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

        public void Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, IntPtr outBuffer)
        {
            TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, outBuffer).ThrowOnNotOK();
        }

        public HRESULT TryRequest(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, IntPtr outBuffer)
        {
            /*HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);*/
            return Raw.Request(reqCode, inBufferSize, inBuffer, outBufferSize, outBuffer);
        }

        #endregion
        #endregion
        
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
