﻿using System;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for querying information about a method instance.
    /// </summary>
    /// <remarks>
    /// This interface lives inside the runtime and is not exposed through any headers or library files. However, it's
    /// a COM interface that derives from IUnknown with GUID ECD73800-22CA-4b0d-AB55-E9BA7E6318A5 that can be obtained
    /// through the usual COM mechanisms.
    /// </remarks>
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
                XCLRDataTypeInstance typeInstanceResult;
                TryGetTypeInstance(out typeInstanceResult).ThrowOnNotOK();

                return typeInstanceResult;
            }
        }

        public HRESULT TryGetTypeInstance(out XCLRDataTypeInstance typeInstanceResult)
        {
            /*HRESULT GetTypeInstance(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance typeInstance);*/
            IXCLRDataTypeInstance typeInstance;
            HRESULT hr = Raw.GetTypeInstance(out typeInstance);

            if (hr == HRESULT.S_OK)
                typeInstanceResult = typeInstance == null ? null : new XCLRDataTypeInstance(typeInstance);
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
                XCLRDataMethodDefinition methodDefinitionResult;
                TryGetDefinition(out methodDefinitionResult).ThrowOnNotOK();

                return methodDefinitionResult;
            }
        }

        public HRESULT TryGetDefinition(out XCLRDataMethodDefinition methodDefinitionResult)
        {
            /*HRESULT GetDefinition(
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataMethodDefinition methodDefinition);*/
            IXCLRDataMethodDefinition methodDefinition;
            HRESULT hr = Raw.GetDefinition(out methodDefinition);

            if (hr == HRESULT.S_OK)
                methodDefinitionResult = methodDefinition == null ? null : new XCLRDataMethodDefinition(methodDefinition);
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
                GetTokenAndScopeResult result;
                TryGetTokenAndScope(out result).ThrowOnNotOK();

                return result;
            }
        }

        public HRESULT TryGetTokenAndScope(out GetTokenAndScopeResult result)
        {
            /*HRESULT GetTokenAndScope(
            [Out] out mdMethodDef token,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataModule mod);*/
            mdMethodDef token;
            IXCLRDataModule mod;
            HRESULT hr = Raw.GetTokenAndScope(out token, out mod);

            if (hr == HRESULT.S_OK)
                result = new GetTokenAndScopeResult(token, mod == null ? null : new XCLRDataModule(mod));
            else
                result = default(GetTokenAndScopeResult);

            return hr;
        }

        #endregion
        #region Flags

        public CLRDataMethodFlag Flags
        {
            get
            {
                CLRDataMethodFlag flags;
                TryGetFlags(out flags).ThrowOnNotOK();

                return flags;
            }
        }

        public HRESULT TryGetFlags(out CLRDataMethodFlag flags)
        {
            /*HRESULT GetFlags(
            [Out] out CLRDataMethodFlag flags);*/
            return Raw.GetFlags(out flags);
        }

        #endregion
        #region EnCVersion

        public int EnCVersion
        {
            get
            {
                int version;
                TryGetEnCVersion(out version).ThrowOnNotOK();

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
                int numTypeArgs;
                TryGetNumTypeArguments(out numTypeArgs).ThrowOnNotOK();

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
        #region ILAddressMap

        /// <summary>
        /// Gets the IL to address mapping information.
        /// </summary>
        public CLRDATA_IL_ADDRESS_MAP[] ILAddressMap
        {
            get
            {
                CLRDATA_IL_ADDRESS_MAP[] maps;
                TryGetILAddressMap(out maps).ThrowOnNotOK();

                return maps;
            }
        }

        /// <summary>
        /// Gets the IL to address mapping information.
        /// </summary>
        /// <param name="maps">[out, size_is(mapLen)] The array for storing the map entries.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataMethodInstance interface and corresponds to the 15th slot of the virtual
        /// method table.
        /// </remarks>
        public HRESULT TryGetILAddressMap(out CLRDATA_IL_ADDRESS_MAP[] maps)
        {
            /*HRESULT GetILAddressMap(
            [In] int mapLen,
            [Out] out int mapNeeded,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] CLRDATA_IL_ADDRESS_MAP[] maps);*/
            int mapLen = 0;
            int mapNeeded;
            maps = null;
            HRESULT hr = Raw.GetILAddressMap(mapLen, out mapNeeded, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            mapLen = mapNeeded;
            maps = new CLRDATA_IL_ADDRESS_MAP[mapLen];
            hr = Raw.GetILAddressMap(mapLen, out mapNeeded, maps);
            fail:
            return hr;
        }

        #endregion
        #region RepresentativeEntryAddress

        /// <summary>
        /// Gets the most representative entry point address for the native compilation of all the possible entry points for a method.
        /// </summary>
        public CLRDATA_ADDRESS RepresentativeEntryAddress
        {
            get
            {
                CLRDATA_ADDRESS addr;
                TryGetRepresentativeEntryAddress(out addr).ThrowOnNotOK();

                return addr;
            }
        }

        /// <summary>
        /// Gets the most representative entry point address for the native compilation of all the possible entry points for a method.
        /// </summary>
        /// <param name="addr">[out] The address of the most representative native entry point for the method.</param>
        /// <remarks>
        /// The provided method is part of the <see cref="IXCLRDataMethodInstance"/> interface and corresponds to the 20th slot of the
        /// virtual method table.
        /// </remarks>
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
            string nameBufResult;
            TryGetName(flags, out nameBufResult).ThrowOnNotOK();

            return nameBufResult;
        }

        public HRESULT TryGetName(int flags, out string nameBufResult)
        {
            /*HRESULT GetName(
            [In] int flags, //Unused, must be 0
            [In] int bufLen,
            [Out] out int nameLen,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] nameBuf);*/
            int bufLen = 0;
            int nameLen;
            char[] nameBuf;
            HRESULT hr = Raw.GetName(flags, bufLen, out nameLen, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufLen = nameLen;
            nameBuf = new char[bufLen];
            hr = Raw.GetName(flags, bufLen, out nameLen, nameBuf);

            if (hr == HRESULT.S_OK)
            {
                nameBufResult = CreateString(nameBuf, nameLen);

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
            HRESULT hr = TryIsSameObject(method);
            hr.ThrowOnFailed();

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataMethodInstance method)
        {
            /*HRESULT IsSameObject(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataMethodInstance method);*/
            return Raw.IsSameObject(method);
        }

        #endregion
        #region GetTypeArgumentByIndex

        public XCLRDataTypeInstance GetTypeArgumentByIndex(int index)
        {
            XCLRDataTypeInstance typeArgResult;
            TryGetTypeArgumentByIndex(index, out typeArgResult).ThrowOnNotOK();

            return typeArgResult;
        }

        public HRESULT TryGetTypeArgumentByIndex(int index, out XCLRDataTypeInstance typeArgResult)
        {
            /*HRESULT GetTypeArgumentByIndex(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IXCLRDataTypeInstance typeArg);*/
            IXCLRDataTypeInstance typeArg;
            HRESULT hr = Raw.GetTypeArgumentByIndex(index, out typeArg);

            if (hr == HRESULT.S_OK)
                typeArgResult = typeArg == null ? null : new XCLRDataTypeInstance(typeArg);
            else
                typeArgResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region GetILOffsetsByAddress

        public GetILOffsetsByAddressResult GetILOffsetsByAddress(CLRDATA_ADDRESS address, int offsetsLen)
        {
            GetILOffsetsByAddressResult result;
            TryGetILOffsetsByAddress(address, offsetsLen, out result).ThrowOnNotOK();

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
            GetAddressRangesByILOffsetResult result;
            TryGetAddressRangesByILOffset(ilOffset, rangesLen, out result).ThrowOnNotOK();

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

        public CLRDATA_ADDRESS_RANGE EnumExtent(ref IntPtr handle)
        {
            CLRDATA_ADDRESS_RANGE extent;
            TryEnumExtent(ref handle, out extent).ThrowOnNotOK();

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
            [In] uint reqCode, //Requests can be across a variety of enums
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
