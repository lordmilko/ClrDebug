using System;
using System.Text;

namespace ClrDebug
{
    public class XCLRDataExceptionState : ComObject<IXCLRDataExceptionState>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataExceptionState"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataExceptionState(IXCLRDataExceptionState raw) : base(raw)
        {
        }

        #region IXCLRDataExceptionState
        #region Flags

        public int Flags
        {
            get
            {
                int flags;
                TryGetFlags(out flags).ThrowOnNotOK();

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
        #region Previous

        public XCLRDataExceptionState Previous
        {
            get
            {
                XCLRDataExceptionState exStateResult;
                TryGetPrevious(out exStateResult).ThrowOnNotOK();

                return exStateResult;
            }
        }

        public HRESULT TryGetPrevious(out XCLRDataExceptionState exStateResult)
        {
            /*HRESULT GetPrevious(
            [Out] out IXCLRDataExceptionState exState);*/
            IXCLRDataExceptionState exState;
            HRESULT hr = Raw.GetPrevious(out exState);

            if (hr == HRESULT.S_OK)
                exStateResult = new XCLRDataExceptionState(exState);
            else
                exStateResult = default(XCLRDataExceptionState);

            return hr;
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
        #region BaseType

        public CLRDataBaseExceptionType BaseType
        {
            get
            {
                CLRDataBaseExceptionType type;
                TryGetBaseType(out type).ThrowOnNotOK();

                return type;
            }
        }

        public HRESULT TryGetBaseType(out CLRDataBaseExceptionType type)
        {
            /*HRESULT GetBaseType(
            [Out] out CLRDataBaseExceptionType type);*/
            return Raw.GetBaseType(out type);
        }

        #endregion
        #region Code

        public int Code
        {
            get
            {
                int code;
                TryGetCode(out code).ThrowOnNotOK();

                return code;
            }
        }

        public HRESULT TryGetCode(out int code)
        {
            /*HRESULT GetCode(
            [Out] out int code);*/
            return Raw.GetCode(out code);
        }

        #endregion
        #region String

        public string String
        {
            get
            {
                string strResult;
                TryGetString(out strResult).ThrowOnNotOK();

                return strResult;
            }
        }

        public HRESULT TryGetString(out string strResult)
        {
            /*HRESULT GetString(
            [In] int bufLen,
            [Out] out int strLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder str);*/
            int bufLen = 0;
            int strLen;
            StringBuilder str = null;
            HRESULT hr = Raw.GetString(bufLen, out strLen, str);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = strLen;
            str = new StringBuilder(strLen);
            hr = Raw.GetString(bufLen, out strLen, str);

            if (hr == HRESULT.S_OK)
            {
                strResult = str.ToString();

                return hr;
            }

            fail:
            strResult = default(string);

            return hr;
        }

        #endregion
        #region Task

        public XCLRDataTask Task
        {
            get
            {
                XCLRDataTask taskResult;
                TryGetTask(out taskResult).ThrowOnNotOK();

                return taskResult;
            }
        }

        public HRESULT TryGetTask(out XCLRDataTask taskResult)
        {
            /*HRESULT GetTask(
            [Out] out IXCLRDataTask task);*/
            IXCLRDataTask task;
            HRESULT hr = Raw.GetTask(out task);

            if (hr == HRESULT.S_OK)
                taskResult = new XCLRDataTask(task);
            else
                taskResult = default(XCLRDataTask);

            return hr;
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
        #region IsSameState

        public bool IsSameState(EXCEPTION_RECORD64 exRecord, int contextSize, IntPtr cxRecord)
        {
            HRESULT hr = TryIsSameState(exRecord, contextSize, cxRecord);
            hr.ThrowOnNotOK();

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameState(EXCEPTION_RECORD64 exRecord, int contextSize, IntPtr cxRecord)
        {
            /*HRESULT IsSameState(
            [In] ref EXCEPTION_RECORD64 exRecord,
            [In] int contextSize,
            [In] IntPtr cxRecord);*/
            return Raw.IsSameState(ref exRecord, contextSize, cxRecord);
        }

        #endregion
        #region IsSameState2

        public bool IsSameState2(int flags, EXCEPTION_RECORD64 exRecord, int contextSize, IntPtr cxRecord)
        {
            HRESULT hr = TryIsSameState2(flags, exRecord, contextSize, cxRecord);
            hr.ThrowOnNotOK();

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameState2(int flags, EXCEPTION_RECORD64 exRecord, int contextSize, IntPtr cxRecord)
        {
            /*HRESULT IsSameState2(
            [In] int flags,
            [In] ref EXCEPTION_RECORD64 exRecord,
            [In] int contextSize,
            [In] IntPtr cxRecord);*/
            return Raw.IsSameState2(flags, ref exRecord, contextSize, cxRecord);
        }

        #endregion
        #endregion
    }
}