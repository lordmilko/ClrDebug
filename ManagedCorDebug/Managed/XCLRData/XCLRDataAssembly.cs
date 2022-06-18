using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
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
        #region FileName

        public string FileName
        {
            get
            {
                HRESULT hr;
                string nameResult;

                if ((hr = TryGetFileName(out nameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
        #region DisplayName

        public string DisplayName
        {
            get
            {
                HRESULT hr;
                string nameResult;

                if ((hr = TryGetDisplayName(out nameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
        #region IsSameObject

        public bool IsSameObject(IXCLRDataAssembly assembly)
        {
            HRESULT hr;

            if ((hr = TryIsSameObject(assembly)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
        #endregion
    }
}