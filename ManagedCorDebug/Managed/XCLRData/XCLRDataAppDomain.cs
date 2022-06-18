using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class XCLRDataAppDomain : ComObject<IXCLRDataAppDomain>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataAppDomain"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataAppDomain(IXCLRDataAppDomain raw) : base(raw)
        {
        }

        #region IXCLRDataAppDomain
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
        #region IsSameObject

        public bool IsSameObject(IXCLRDataAppDomain appDomain)
        {
            HRESULT hr;

            if ((hr = TryIsSameObject(appDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataAppDomain appDomain)
        {
            /*HRESULT IsSameObject(
            [In] IXCLRDataAppDomain appDomain);*/
            return Raw.IsSameObject(appDomain);
        }

        #endregion
        #region Request

        public void Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, IntPtr outBuffer)
        {
            HRESULT hr;

            if ((hr = TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, outBuffer)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
        #endregion
    }
}