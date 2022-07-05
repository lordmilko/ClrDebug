using System;
using System.Text;

namespace ClrDebug
{
    public class XCLRDataAssembly : ComObject<IXCLRDataAssembly>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataAssembly"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataAssembly(IXCLRDataAssembly raw) : base(raw)
        {
        }

        #region IXCLRDataAssembly
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
        #region FileName

        public string FileName
        {
            get
            {
                string nameResult;
                TryGetFileName(out nameResult).ThrowOnNotOK();

                return nameResult;
            }
        }

        public HRESULT TryGetFileName(out string nameResult)
        {
            /*HRESULT GetFileName(
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);*/
            int bufLen = 0;
            int nameLen;
            StringBuilder name = null;
            HRESULT hr = Raw.GetFileName(bufLen, out nameLen, name);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            name = new StringBuilder(nameLen);
            hr = Raw.GetFileName(bufLen, out nameLen, name);

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
        #region Flags

        public CLRDataAssemblyFlag Flags
        {
            get
            {
                CLRDataAssemblyFlag flags;
                TryGetFlags(out flags).ThrowOnNotOK();

                return flags;
            }
        }

        public HRESULT TryGetFlags(out CLRDataAssemblyFlag flags)
        {
            /*HRESULT GetFlags(
            [Out] out CLRDataAssemblyFlag flags);*/
            return Raw.GetFlags(out flags);
        }

        #endregion
        #region DisplayName

        public string DisplayName
        {
            get
            {
                string nameResult;
                TryGetDisplayName(out nameResult).ThrowOnNotOK();

                return nameResult;
            }
        }

        public HRESULT TryGetDisplayName(out string nameResult)
        {
            /*HRESULT GetDisplayName(
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);*/
            int bufLen = 0;
            int nameLen;
            StringBuilder name = null;
            HRESULT hr = Raw.GetDisplayName(bufLen, out nameLen, name);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            name = new StringBuilder(nameLen);
            hr = Raw.GetDisplayName(bufLen, out nameLen, name);

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
        #region IsSameObject

        public bool IsSameObject(IXCLRDataAssembly assembly)
        {
            HRESULT hr = TryIsSameObject(assembly);
            hr.ThrowOnNotOK();

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataAssembly assembly)
        {
            /*HRESULT IsSameObject(
            [In] IXCLRDataAssembly assembly);*/
            return Raw.IsSameObject(assembly);
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
