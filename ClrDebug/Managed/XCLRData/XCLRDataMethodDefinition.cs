using System;
using System.Text;

namespace ClrDebug
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
                XCLRDataTypeDefinition typeDefinitionResult;
                TryGetTypeDefinition(out typeDefinitionResult).ThrowOnNotOK();

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
                GetTokenAndScopeResult result;
                TryGetTokenAndScope(out result).ThrowOnNotOK();

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
        #region LatestEnCVersion

        public int LatestEnCVersion
        {
            get
            {
                int version;
                TryGetLatestEnCVersion(out version).ThrowOnNotOK();

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
                int flags;
                TryGetCodeNotification(out flags).ThrowOnNotOK();

                return flags;
            }
            set
            {
                TrySetCodeNotification(value).ThrowOnNotOK();
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
                CLRDATA_ADDRESS addr;
                TryGetRepresentativeEntryAddress(out addr).ThrowOnNotOK();

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
            IntPtr handle;
            TryStartEnumInstances(appDomain, out handle).ThrowOnNotOK();

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
            XCLRDataMethodInstance instanceResult;
            TryEnumInstance(ref handle, out instanceResult).ThrowOnNotOK();

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
            TryEndEnumInstances(handle).ThrowOnNotOK();
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
            string nameResult;
            TryGetName(flags, out nameResult).ThrowOnNotOK();

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
            HRESULT hr = TryIsSameObject(method);
            hr.ThrowOnNotOK();

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
            IntPtr handle;
            TryStartEnumExtents(out handle).ThrowOnNotOK();

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
            CLRDATA_METHDEF_EXTENT extent;
            TryEnumExtent(ref handle, out extent).ThrowOnNotOK();

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
            TryEndEnumExtents(handle).ThrowOnNotOK();
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
        #region HasClassOrMethodInstantiation

        public bool HasClassOrMethodInstantiation()
        {
            bool bGeneric;
            TryHasClassOrMethodInstantiation(out bGeneric).ThrowOnNotOK();

            return bGeneric;
        }

        public HRESULT TryHasClassOrMethodInstantiation(out bool bGeneric)
        {
            /*HRESULT HasClassOrMethodInstantiation(
            [Out] out bool bGeneric);*/
            return Raw.HasClassOrMethodInstantiation(out bGeneric);
        }

        #endregion
        #endregion
    }
}