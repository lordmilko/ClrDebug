using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
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
        #region Previous

        public XCLRDataExceptionState Previous
        {
            get
            {
                HRESULT hr;
                XCLRDataExceptionState exStateResult;

                if ((hr = TryGetPrevious(out exStateResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
        #region BaseType

        public CLRDataBaseExceptionType BaseType
        {
            get
            {
                HRESULT hr;
                CLRDataBaseExceptionType type;

                if ((hr = TryGetBaseType(out type)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
                HRESULT hr;
                int code;

                if ((hr = TryGetCode(out code)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
                HRESULT hr;
                string strResult;

                if ((hr = TryGetString(out strResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
                HRESULT hr;
                XCLRDataTask taskResult;

                if ((hr = TryGetTask(out taskResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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

        public IntPtr Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize)
        {
            HRESULT hr;
            IntPtr outBuffer;

            if ((hr = TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, out outBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return outBuffer;
        }

        public HRESULT TryRequest(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, out IntPtr outBuffer)
        {
            /*HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] out IntPtr outBuffer);*/
            return Raw.Request(reqCode, inBufferSize, inBuffer, outBufferSize, out outBuffer);
        }

        #endregion
        #region IsSameState

        public bool IsSameState(EXCEPTION_RECORD64 exRecord, int contextSize, IntPtr cxRecord)
        {
            HRESULT hr;

            if ((hr = TryIsSameState(exRecord, contextSize, cxRecord)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            HRESULT hr;

            if ((hr = TryIsSameState2(flags, exRecord, contextSize, cxRecord)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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