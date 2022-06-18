using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class XCLRDataMethodDefinition : ComObject<IXCLRDataMethodDefinition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataMethodDefinition"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataMethodDefinition(IXCLRDataMethodDefinition raw) : base(raw)
        {
        }

        #region IXCLRDataMethodDefinition
        #region TypeDefinition

        public XCLRDataTypeDefinition TypeDefinition
        {
            get
            {
                HRESULT hr;
                XCLRDataTypeDefinition typeDefinitionResult;

                if ((hr = TryGetTypeDefinition(out typeDefinitionResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return typeDefinitionResult;
            }
        }

        public HRESULT TryGetTypeDefinition(out XCLRDataTypeDefinition typeDefinitionResult)
        {
            /*HRESULT GetTypeDefinition(
            [Out] out IXCLRDataTypeDefinition typeDefinition);*/
            IXCLRDataTypeDefinition typeDefinition;
            HRESULT hr = Raw.GetTypeDefinition(out typeDefinition);

            if (hr == HRESULT.S_OK)
                typeDefinitionResult = new XCLRDataTypeDefinition(typeDefinition);
            else
                typeDefinitionResult = default(XCLRDataTypeDefinition);

            return hr;
        }

        #endregion
        #region TokenAndScope

        public GetTokenAndScopeResult TokenAndScope
        {
            get
            {
                HRESULT hr;
                GetTokenAndScopeResult result;

                if ((hr = TryGetTokenAndScope(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryGetTokenAndScope(out GetTokenAndScopeResult result)
        {
            /*HRESULT GetTokenAndScope(
            [Out] out mdMethodDef token,
            [Out] out IXCLRDataModule mod);*/
            mdMethodDef token;
            IXCLRDataModule mod;
            HRESULT hr = Raw.GetTokenAndScope(out token, out mod);

            if (hr == HRESULT.S_OK)
                result = new GetTokenAndScopeResult(token, new XCLRDataModule(mod));
            else
                result = default(GetTokenAndScopeResult);

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
        #region LatestEnCVersion

        public int LatestEnCVersion
        {
            get
            {
                HRESULT hr;
                int version;

                if ((hr = TryGetLatestEnCVersion(out version)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return version;
            }
        }

        public HRESULT TryGetLatestEnCVersion(out int version)
        {
            /*HRESULT GetLatestEnCVersion(
            [Out] out int version);*/
            return Raw.GetLatestEnCVersion(out version);
        }

        #endregion
        #region CodeNotification

        public int CodeNotification
        {
            get
            {
                HRESULT hr;
                int flags;

                if ((hr = TryGetCodeNotification(out flags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return flags;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetCodeNotification(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetCodeNotification(out int flags)
        {
            /*HRESULT GetCodeNotification(
            [Out] out int flags);*/
            return Raw.GetCodeNotification(out flags);
        }

        public HRESULT TrySetCodeNotification(int flags)
        {
            /*HRESULT SetCodeNotification(
            [In] int flags);*/
            return Raw.SetCodeNotification(flags);
        }

        #endregion
        #region RepresentativeEntryAddress

        public CLRDATA_ADDRESS RepresentativeEntryAddress
        {
            get
            {
                HRESULT hr;
                CLRDATA_ADDRESS addr;

                if ((hr = TryGetRepresentativeEntryAddress(out addr)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return addr;
            }
        }

        public HRESULT TryGetRepresentativeEntryAddress(out CLRDATA_ADDRESS addr)
        {
            /*HRESULT GetRepresentativeEntryAddress(
            [Out] out CLRDATA_ADDRESS addr);*/
            return Raw.GetRepresentativeEntryAddress(out addr);
        }

        #endregion
        #region StartEnumInstances

        public IntPtr StartEnumInstances(IXCLRDataAppDomain appDomain)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumInstances(appDomain, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumInstances(IXCLRDataAppDomain appDomain, out IntPtr handle)
        {
            /*HRESULT StartEnumInstances(
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumInstances(appDomain, out handle);
        }

        #endregion
        #region EnumInstance

        public XCLRDataMethodInstance EnumInstance(ref IntPtr handle)
        {
            HRESULT hr;
            XCLRDataMethodInstance instanceResult;

            if ((hr = TryEnumInstance(ref handle, out instanceResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return instanceResult;
        }

        public HRESULT TryEnumInstance(ref IntPtr handle, out XCLRDataMethodInstance instanceResult)
        {
            /*HRESULT EnumInstance(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance instance);*/
            IXCLRDataMethodInstance instance;
            HRESULT hr = Raw.EnumInstance(ref handle, out instance);

            if (hr == HRESULT.S_OK)
                instanceResult = new XCLRDataMethodInstance(instance);
            else
                instanceResult = default(XCLRDataMethodInstance);

            return hr;
        }

        #endregion
        #region EndEnumInstances

        public void EndEnumInstances(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumInstances(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumInstances(IntPtr handle)
        {
            /*HRESULT EndEnumInstances(
            [In] IntPtr handle);*/
            return Raw.EndEnumInstances(handle);
        }

        #endregion
        #region GetName

        public string GetName(int flags)
        {
            HRESULT hr;
            string nameResult;

            if ((hr = TryGetName(flags, out nameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return nameResult;
        }

        public HRESULT TryGetName(int flags, out string nameResult)
        {
            /*HRESULT GetName(
            [In] int flags,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name);*/
            int bufLen = 0;
            int nameLen;
            StringBuilder name = null;
            HRESULT hr = Raw.GetName(flags, bufLen, out nameLen, name);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            name = new StringBuilder(nameLen);
            hr = Raw.GetName(flags, bufLen, out nameLen, name);

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
        #region IsSameObject

        public bool IsSameObject(IXCLRDataMethodDefinition method)
        {
            HRESULT hr;

            if ((hr = TryIsSameObject(method)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataMethodDefinition method)
        {
            /*HRESULT IsSameObject(
            [In] IXCLRDataMethodDefinition method);*/
            return Raw.IsSameObject(method);
        }

        #endregion
        #region StartEnumExtents

        public IntPtr StartEnumExtents()
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumExtents(out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumExtents(out IntPtr handle)
        {
            /*HRESULT StartEnumExtents(
            [Out] out IntPtr handle);*/
            return Raw.StartEnumExtents(out handle);
        }

        #endregion
        #region EnumExtent

        public CLRDATA_METHDEF_EXTENT EnumExtent(ref IntPtr handle)
        {
            HRESULT hr;
            CLRDATA_METHDEF_EXTENT extent;

            if ((hr = TryEnumExtent(ref handle, out extent)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return extent;
        }

        public HRESULT TryEnumExtent(ref IntPtr handle, out CLRDATA_METHDEF_EXTENT extent)
        {
            /*HRESULT EnumExtent(
            [In, Out] ref IntPtr handle,
            [Out] out CLRDATA_METHDEF_EXTENT extent);*/
            return Raw.EnumExtent(ref handle, out extent);
        }

        #endregion
        #region EndEnumExtents

        public void EndEnumExtents(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumExtents(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumExtents(IntPtr handle)
        {
            /*HRESULT EndEnumExtents(
            [In] IntPtr handle);*/
            return Raw.EndEnumExtents(handle);
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
        #region HasClassOrMethodInstantiation

        public int HasClassOrMethodInstantiation()
        {
            HRESULT hr;
            int bGeneric;

            if ((hr = TryHasClassOrMethodInstantiation(out bGeneric)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return bGeneric;
        }

        public HRESULT TryHasClassOrMethodInstantiation(out int bGeneric)
        {
            /*HRESULT HasClassOrMethodInstantiation(
            [Out] out int bGeneric);*/
            return Raw.HasClassOrMethodInstantiation(out bGeneric);
        }

        #endregion
        #endregion
    }
}