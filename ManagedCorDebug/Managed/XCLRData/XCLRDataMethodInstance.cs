using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class XCLRDataMethodInstance : ComObject<IXCLRDataMethodInstance>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataMethodInstance"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataMethodInstance(IXCLRDataMethodInstance raw) : base(raw)
        {
        }

        #region IXCLRDataMethodInstance
        #region TypeInstance

        public XCLRDataTypeInstance TypeInstance
        {
            get
            {
                HRESULT hr;
                XCLRDataTypeInstance typeInstanceResult;

                if ((hr = TryGetTypeInstance(out typeInstanceResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return typeInstanceResult;
            }
        }

        public HRESULT TryGetTypeInstance(out XCLRDataTypeInstance typeInstanceResult)
        {
            /*HRESULT GetTypeInstance(
            [Out] out IXCLRDataTypeInstance typeInstance);*/
            IXCLRDataTypeInstance typeInstance;
            HRESULT hr = Raw.GetTypeInstance(out typeInstance);

            if (hr == HRESULT.S_OK)
                typeInstanceResult = new XCLRDataTypeInstance(typeInstance);
            else
                typeInstanceResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region Definition

        public XCLRDataMethodDefinition Definition
        {
            get
            {
                HRESULT hr;
                XCLRDataMethodDefinition methodDefinitionResult;

                if ((hr = TryGetDefinition(out methodDefinitionResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return methodDefinitionResult;
            }
        }

        public HRESULT TryGetDefinition(out XCLRDataMethodDefinition methodDefinitionResult)
        {
            /*HRESULT GetDefinition(
            [Out] out IXCLRDataMethodDefinition methodDefinition);*/
            IXCLRDataMethodDefinition methodDefinition;
            HRESULT hr = Raw.GetDefinition(out methodDefinition);

            if (hr == HRESULT.S_OK)
                methodDefinitionResult = new XCLRDataMethodDefinition(methodDefinition);
            else
                methodDefinitionResult = default(XCLRDataMethodDefinition);

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
        #region EnCVersion

        public int EnCVersion
        {
            get
            {
                HRESULT hr;
                int version;

                if ((hr = TryGetEnCVersion(out version)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return version;
            }
        }

        public HRESULT TryGetEnCVersion(out int version)
        {
            /*HRESULT GetEnCVersion(
            [Out] out int version);*/
            return Raw.GetEnCVersion(out version);
        }

        #endregion
        #region NumTypeArguments

        public int NumTypeArguments
        {
            get
            {
                HRESULT hr;
                int numTypeArgs;

                if ((hr = TryGetNumTypeArguments(out numTypeArgs)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return numTypeArgs;
            }
        }

        public HRESULT TryGetNumTypeArguments(out int numTypeArgs)
        {
            /*HRESULT GetNumTypeArguments(
            [Out] out int numTypeArgs);*/
            return Raw.GetNumTypeArguments(out numTypeArgs);
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
        #region GetName

        public string GetName(int flags)
        {
            HRESULT hr;
            string nameBufResult;

            if ((hr = TryGetName(flags, out nameBufResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return nameBufResult;
        }

        public HRESULT TryGetName(int flags, out string nameBufResult)
        {
            /*HRESULT GetName(
            [In] int flags,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf);*/
            int bufLen = 0;
            int nameLen;
            StringBuilder nameBuf = null;
            HRESULT hr = Raw.GetName(flags, bufLen, out nameLen, nameBuf);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new StringBuilder(nameLen);
            hr = Raw.GetName(flags, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                nameBufResult = nameBuf.ToString();

                return hr;
            }

            fail:
            nameBufResult = default(string);

            return hr;
        }

        #endregion
        #region IsSameObject

        public bool IsSameObject(IXCLRDataMethodInstance method)
        {
            HRESULT hr;

            if ((hr = TryIsSameObject(method)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataMethodInstance method)
        {
            /*HRESULT IsSameObject(
            [In] IXCLRDataMethodInstance method);*/
            return Raw.IsSameObject(method);
        }

        #endregion
        #region GetTypeArgumentByIndex

        public XCLRDataTypeInstance GetTypeArgumentByIndex(int index)
        {
            HRESULT hr;
            XCLRDataTypeInstance typeArgResult;

            if ((hr = TryGetTypeArgumentByIndex(index, out typeArgResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return typeArgResult;
        }

        public HRESULT TryGetTypeArgumentByIndex(int index, out XCLRDataTypeInstance typeArgResult)
        {
            /*HRESULT GetTypeArgumentByIndex(
            [In] int index,
            [Out] out IXCLRDataTypeInstance typeArg);*/
            IXCLRDataTypeInstance typeArg;
            HRESULT hr = Raw.GetTypeArgumentByIndex(index, out typeArg);

            if (hr == HRESULT.S_OK)
                typeArgResult = new XCLRDataTypeInstance(typeArg);
            else
                typeArgResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region GetILOffsetsByAddress

        public GetILOffsetsByAddressResult GetILOffsetsByAddress(CLRDATA_ADDRESS address, int offsetsLen)
        {
            HRESULT hr;
            GetILOffsetsByAddressResult result;

            if ((hr = TryGetILOffsetsByAddress(address, offsetsLen, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetILOffsetsByAddress(CLRDATA_ADDRESS address, int offsetsLen, out GetILOffsetsByAddressResult result)
        {
            /*HRESULT GetILOffsetsByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] int offsetsLen,
            [Out] out int offsetsNeeded,
            [Out] out int ilOffsets);*/
            int offsetsNeeded;
            int ilOffsets;
            HRESULT hr = Raw.GetILOffsetsByAddress(address, offsetsLen, out offsetsNeeded, out ilOffsets);

            if (hr == HRESULT.S_OK)
                result = new GetILOffsetsByAddressResult(offsetsNeeded, ilOffsets);
            else
                result = default(GetILOffsetsByAddressResult);

            return hr;
        }

        #endregion
        #region GetAddressRangesByILOffset

        public GetAddressRangesByILOffsetResult GetAddressRangesByILOffset(int ilOffset, int rangesLen)
        {
            HRESULT hr;
            GetAddressRangesByILOffsetResult result;

            if ((hr = TryGetAddressRangesByILOffset(ilOffset, rangesLen, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetAddressRangesByILOffset(int ilOffset, int rangesLen, out GetAddressRangesByILOffsetResult result)
        {
            /*HRESULT GetAddressRangesByILOffset(
            [In] int ilOffset,
            [In] int rangesLen,
            [Out] out int rangesNeeded,
            [Out] out CLRDATA_ADDRESS_RANGE addressRanges);*/
            int rangesNeeded;
            CLRDATA_ADDRESS_RANGE addressRanges;
            HRESULT hr = Raw.GetAddressRangesByILOffset(ilOffset, rangesLen, out rangesNeeded, out addressRanges);

            if (hr == HRESULT.S_OK)
                result = new GetAddressRangesByILOffsetResult(rangesNeeded, addressRanges);
            else
                result = default(GetAddressRangesByILOffsetResult);

            return hr;
        }

        #endregion
        #region GetILAddressMap

        public GetILAddressMapResult GetILAddressMap(int mapLen)
        {
            HRESULT hr;
            GetILAddressMapResult result;

            if ((hr = TryGetILAddressMap(mapLen, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetILAddressMap(int mapLen, out GetILAddressMapResult result)
        {
            /*HRESULT GetILAddressMap(
            [In] int mapLen,
            [Out] out int mapNeeded,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDATA_IL_ADDRESS_MAP[] maps);*/
            int mapNeeded;
            CLRDATA_IL_ADDRESS_MAP[] maps = null;
            HRESULT hr = Raw.GetILAddressMap(mapLen, out mapNeeded, maps);

            if (hr == HRESULT.S_OK)
                result = new GetILAddressMapResult(mapNeeded, maps);
            else
                result = default(GetILAddressMapResult);

            return hr;
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

        public CLRDATA_ADDRESS_RANGE EnumExtent(ref IntPtr handle)
        {
            HRESULT hr;
            CLRDATA_ADDRESS_RANGE extent;

            if ((hr = TryEnumExtent(ref handle, out extent)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return extent;
        }

        public HRESULT TryEnumExtent(ref IntPtr handle, out CLRDATA_ADDRESS_RANGE extent)
        {
            /*HRESULT EnumExtent(
            [In, Out] ref IntPtr handle,
            [Out] out CLRDATA_ADDRESS_RANGE extent);*/
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
        #endregion
    }
}