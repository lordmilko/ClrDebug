using System;
using System.Diagnostics;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for querying information about a loaded module.
    /// </summary>
    /// <remarks>
    /// This interface lives inside the runtime and is not exposed through any headers or library files. However, it's
    /// a COM interface that derives from IUnknown with GUID 88E32849-0A0A-4cb0-9022-7CD2E9E139E2 that can be obtained
    /// through the usual COM mechanisms.
    /// </remarks>
    public class XCLRDataModule : ComObject<IXCLRDataModule>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataModule"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataModule(IXCLRDataModule raw) : base(raw)
        {
        }

        #region IXCLRDataModule
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
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] name);*/
            int bufLen = 260;
            int nameLen;
            char[] name = new char[bufLen];
            HRESULT hr = Raw.GetFileName(bufLen, out nameLen, name);

            if (hr == HRESULT.S_OK)
            {
                nameResult = CreateString(name, nameLen);

                return hr;
            }

            nameResult = default(string);

            return hr;
        }

        #endregion
        #region Flags

        public CLRDataModuleFlag Flags
        {
            get
            {
                CLRDataModuleFlag flags;
                TryGetFlags(out flags).ThrowOnNotOK();

                return flags;
            }
        }

        public HRESULT TryGetFlags(out CLRDataModuleFlag flags)
        {
            /*HRESULT GetFlags(
            [Out] out CLRDataModuleFlag flags);*/
            return Raw.GetFlags(out flags);
        }

        #endregion
        #region VersionId

        /// <summary>
        /// Gets the module's version identifier.
        /// </summary>
        public Guid VersionId
        {
            get
            {
                Guid vid;
                TryGetVersionId(out vid).ThrowOnNotOK();

                return vid;
            }
        }

        /// <summary>
        /// Gets the module's version identifier.
        /// </summary>
        /// <param name="vid">[out] The module's version identifier.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataModule interface and corresponds to the 41st slot of the virtual method
        /// table.
        /// </remarks>
        public HRESULT TryGetVersionId(out Guid vid)
        {
            /*HRESULT GetVersionId(
            [Out] out Guid vid);*/
            return Raw.GetVersionId(out vid);
        }

        #endregion
        #region StartEnumAssemblies

        public IntPtr StartEnumAssemblies()
        {
            IntPtr handle;
            TryStartEnumAssemblies(out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumAssemblies(out IntPtr handle)
        {
            /*HRESULT StartEnumAssemblies(
            [Out] out IntPtr handle);*/
            return Raw.StartEnumAssemblies(out handle);
        }

        #endregion
        #region EnumAssembly

        public XCLRDataAssembly EnumAssembly(ref IntPtr handle)
        {
            XCLRDataAssembly assemblyResult;
            TryEnumAssembly(ref handle, out assemblyResult).ThrowOnNotOK();

            return assemblyResult;
        }

        public HRESULT TryEnumAssembly(ref IntPtr handle, out XCLRDataAssembly assemblyResult)
        {
            /*HRESULT EnumAssembly(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataAssembly assembly);*/
            IXCLRDataAssembly assembly;
            HRESULT hr = Raw.EnumAssembly(ref handle, out assembly);

            if (hr == HRESULT.S_OK)
                assemblyResult = assembly == null ? null : new XCLRDataAssembly(assembly);
            else
                assemblyResult = default(XCLRDataAssembly);

            return hr;
        }

        #endregion
        #region EndEnumAssemblies

        public void EndEnumAssemblies(IntPtr handle)
        {
            TryEndEnumAssemblies(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumAssemblies(IntPtr handle)
        {
            /*HRESULT EndEnumAssemblies(
            [In] IntPtr handle);*/
            return Raw.EndEnumAssemblies(handle);
        }

        #endregion
        #region StartEnumTypeDefinitions

        public IntPtr StartEnumTypeDefinitions()
        {
            IntPtr handle;
            TryStartEnumTypeDefinitions(out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumTypeDefinitions(out IntPtr handle)
        {
            /*HRESULT StartEnumTypeDefinitions(
            [Out] out IntPtr handle);*/
            return Raw.StartEnumTypeDefinitions(out handle);
        }

        #endregion
        #region EnumTypeDefinition

        public XCLRDataTypeDefinition EnumTypeDefinition(ref IntPtr handle)
        {
            XCLRDataTypeDefinition typeDefinitionResult;
            TryEnumTypeDefinition(ref handle, out typeDefinitionResult).ThrowOnNotOK();

            return typeDefinitionResult;
        }

        public HRESULT TryEnumTypeDefinition(ref IntPtr handle, out XCLRDataTypeDefinition typeDefinitionResult)
        {
            /*HRESULT EnumTypeDefinition(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeDefinition typeDefinition);*/
            IXCLRDataTypeDefinition typeDefinition;
            HRESULT hr = Raw.EnumTypeDefinition(ref handle, out typeDefinition);

            if (hr == HRESULT.S_OK)
                typeDefinitionResult = typeDefinition == null ? null : new XCLRDataTypeDefinition(typeDefinition);
            else
                typeDefinitionResult = default(XCLRDataTypeDefinition);

            return hr;
        }

        #endregion
        #region EndEnumTypeDefinitions

        public void EndEnumTypeDefinitions(IntPtr handle)
        {
            TryEndEnumTypeDefinitions(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumTypeDefinitions(IntPtr handle)
        {
            /*HRESULT EndEnumTypeDefinitions(
            [In] IntPtr handle);*/
            return Raw.EndEnumTypeDefinitions(handle);
        }

        #endregion
        #region StartEnumTypeInstances

        public IntPtr StartEnumTypeInstances(IXCLRDataAppDomain appDomain)
        {
            IntPtr handle;
            TryStartEnumTypeInstances(appDomain, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumTypeInstances(IXCLRDataAppDomain appDomain, out IntPtr handle)
        {
            /*HRESULT StartEnumTypeInstances(
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumTypeInstances(appDomain, out handle);
        }

        #endregion
        #region EnumTypeInstance

        public XCLRDataTypeInstance EnumTypeInstance(ref IntPtr handle)
        {
            XCLRDataTypeInstance typeInstanceResult;
            TryEnumTypeInstance(ref handle, out typeInstanceResult).ThrowOnNotOK();

            return typeInstanceResult;
        }

        public HRESULT TryEnumTypeInstance(ref IntPtr handle, out XCLRDataTypeInstance typeInstanceResult)
        {
            /*HRESULT EnumTypeInstance(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeInstance typeInstance);*/
            IXCLRDataTypeInstance typeInstance;
            HRESULT hr = Raw.EnumTypeInstance(ref handle, out typeInstance);

            if (hr == HRESULT.S_OK)
                typeInstanceResult = typeInstance == null ? null : new XCLRDataTypeInstance(typeInstance);
            else
                typeInstanceResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region EndEnumTypeInstances

        public void EndEnumTypeInstances(IntPtr handle)
        {
            TryEndEnumTypeInstances(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumTypeInstances(IntPtr handle)
        {
            /*HRESULT EndEnumTypeInstances(
            [In] IntPtr handle);*/
            return Raw.EndEnumTypeInstances(handle);
        }

        #endregion
        #region StartEnumTypeDefinitionsByName

        public IntPtr StartEnumTypeDefinitionsByName(string name, CLRDataByNameFlag flags)
        {
            IntPtr handle;
            TryStartEnumTypeDefinitionsByName(name, flags, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumTypeDefinitionsByName(string name, CLRDataByNameFlag flags, out IntPtr handle)
        {
            /*HRESULT StartEnumTypeDefinitionsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumTypeDefinitionsByName(name, flags, out handle);
        }

        #endregion
        #region EnumTypeDefinitionByName

        public XCLRDataTypeDefinition EnumTypeDefinitionByName(ref IntPtr handle)
        {
            XCLRDataTypeDefinition typeResult;
            TryEnumTypeDefinitionByName(ref handle, out typeResult).ThrowOnNotOK();

            return typeResult;
        }

        public HRESULT TryEnumTypeDefinitionByName(ref IntPtr handle, out XCLRDataTypeDefinition typeResult)
        {
            /*HRESULT EnumTypeDefinitionByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeDefinition type);*/
            IXCLRDataTypeDefinition type;
            HRESULT hr = Raw.EnumTypeDefinitionByName(ref handle, out type);

            if (hr == HRESULT.S_OK)
                typeResult = type == null ? null : new XCLRDataTypeDefinition(type);
            else
                typeResult = default(XCLRDataTypeDefinition);

            return hr;
        }

        #endregion
        #region EndEnumTypeDefinitionsByName

        public void EndEnumTypeDefinitionsByName(IntPtr handle)
        {
            TryEndEnumTypeDefinitionsByName(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumTypeDefinitionsByName(IntPtr handle)
        {
            /*HRESULT EndEnumTypeDefinitionsByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumTypeDefinitionsByName(handle);
        }

        #endregion
        #region StartEnumTypeInstancesByName

        public IntPtr StartEnumTypeInstancesByName(string name, CLRDataByNameFlag flags, IXCLRDataAppDomain appDomain)
        {
            IntPtr handle;
            TryStartEnumTypeInstancesByName(name, flags, appDomain, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumTypeInstancesByName(string name, CLRDataByNameFlag flags, IXCLRDataAppDomain appDomain, out IntPtr handle)
        {
            /*HRESULT StartEnumTypeInstancesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumTypeInstancesByName(name, flags, appDomain, out handle);
        }

        #endregion
        #region EnumTypeInstanceByName

        public XCLRDataTypeInstance EnumTypeInstanceByName(ref IntPtr handle)
        {
            XCLRDataTypeInstance typeResult;
            TryEnumTypeInstanceByName(ref handle, out typeResult).ThrowOnNotOK();

            return typeResult;
        }

        public HRESULT TryEnumTypeInstanceByName(ref IntPtr handle, out XCLRDataTypeInstance typeResult)
        {
            /*HRESULT EnumTypeInstanceByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTypeInstance type);*/
            IXCLRDataTypeInstance type;
            HRESULT hr = Raw.EnumTypeInstanceByName(ref handle, out type);

            if (hr == HRESULT.S_OK)
                typeResult = type == null ? null : new XCLRDataTypeInstance(type);
            else
                typeResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region EndEnumTypeInstancesByName

        public void EndEnumTypeInstancesByName(IntPtr handle)
        {
            TryEndEnumTypeInstancesByName(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumTypeInstancesByName(IntPtr handle)
        {
            /*HRESULT EndEnumTypeInstancesByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumTypeInstancesByName(handle);
        }

        #endregion
        #region GetTypeDefinitionByToken

        public XCLRDataTypeDefinition GetTypeDefinitionByToken(mdTypeDef token)
        {
            XCLRDataTypeDefinition typeDefinitionResult;
            TryGetTypeDefinitionByToken(token, out typeDefinitionResult).ThrowOnNotOK();

            return typeDefinitionResult;
        }

        public HRESULT TryGetTypeDefinitionByToken(mdTypeDef token, out XCLRDataTypeDefinition typeDefinitionResult)
        {
            /*HRESULT GetTypeDefinitionByToken(
            [In] mdTypeDef token,
            [Out] out IXCLRDataTypeDefinition typeDefinition);*/
            IXCLRDataTypeDefinition typeDefinition;
            HRESULT hr = Raw.GetTypeDefinitionByToken(token, out typeDefinition);

            if (hr == HRESULT.S_OK)
                typeDefinitionResult = typeDefinition == null ? null : new XCLRDataTypeDefinition(typeDefinition);
            else
                typeDefinitionResult = default(XCLRDataTypeDefinition);

            return hr;
        }

        #endregion
        #region StartEnumMethodDefinitionsByName

        public IntPtr StartEnumMethodDefinitionsByName(string name, CLRDataByNameFlag flags)
        {
            IntPtr handle;
            TryStartEnumMethodDefinitionsByName(name, flags, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumMethodDefinitionsByName(string name, CLRDataByNameFlag flags, out IntPtr handle)
        {
            /*HRESULT StartEnumMethodDefinitionsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodDefinitionsByName(name, flags, out handle);
        }

        #endregion
        #region EnumMethodDefinitionByName

        public XCLRDataMethodDefinition EnumMethodDefinitionByName(ref IntPtr handle)
        {
            XCLRDataMethodDefinition methodResult;
            TryEnumMethodDefinitionByName(ref handle, out methodResult).ThrowOnNotOK();

            return methodResult;
        }

        public HRESULT TryEnumMethodDefinitionByName(ref IntPtr handle, out XCLRDataMethodDefinition methodResult)
        {
            /*HRESULT EnumMethodDefinitionByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodDefinition method);*/
            IXCLRDataMethodDefinition method;
            HRESULT hr = Raw.EnumMethodDefinitionByName(ref handle, out method);

            if (hr == HRESULT.S_OK)
                methodResult = method == null ? null : new XCLRDataMethodDefinition(method);
            else
                methodResult = default(XCLRDataMethodDefinition);

            return hr;
        }

        #endregion
        #region EndEnumMethodDefinitionsByName

        public void EndEnumMethodDefinitionsByName(IntPtr handle)
        {
            TryEndEnumMethodDefinitionsByName(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumMethodDefinitionsByName(IntPtr handle)
        {
            /*HRESULT EndEnumMethodDefinitionsByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodDefinitionsByName(handle);
        }

        #endregion
        #region StartEnumMethodInstancesByName

        public IntPtr StartEnumMethodInstancesByName(string name, CLRDataByNameFlag flags, IXCLRDataAppDomain appDomain)
        {
            IntPtr handle;
            TryStartEnumMethodInstancesByName(name, flags, appDomain, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumMethodInstancesByName(string name, CLRDataByNameFlag flags, IXCLRDataAppDomain appDomain, out IntPtr handle)
        {
            /*HRESULT StartEnumMethodInstancesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodInstancesByName(name, flags, appDomain, out handle);
        }

        #endregion
        #region EnumMethodInstanceByName

        public XCLRDataMethodInstance EnumMethodInstanceByName(ref IntPtr handle)
        {
            XCLRDataMethodInstance methodResult;
            TryEnumMethodInstanceByName(ref handle, out methodResult).ThrowOnNotOK();

            return methodResult;
        }

        public HRESULT TryEnumMethodInstanceByName(ref IntPtr handle, out XCLRDataMethodInstance methodResult)
        {
            /*HRESULT EnumMethodInstanceByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance method);*/
            IXCLRDataMethodInstance method;
            HRESULT hr = Raw.EnumMethodInstanceByName(ref handle, out method);

            if (hr == HRESULT.S_OK)
                methodResult = method == null ? null : new XCLRDataMethodInstance(method);
            else
                methodResult = default(XCLRDataMethodInstance);

            return hr;
        }

        #endregion
        #region EndEnumMethodInstancesByName

        public void EndEnumMethodInstancesByName(IntPtr handle)
        {
            TryEndEnumMethodInstancesByName(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumMethodInstancesByName(IntPtr handle)
        {
            /*HRESULT EndEnumMethodInstancesByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodInstancesByName(handle);
        }

        #endregion
        #region GetMethodDefinitionByToken

        /// <summary>
        /// Gets the method definition corresponding to a given metadata token.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <returns>[out] The method definition.</returns>
        /// <remarks>
        /// The provided method is part of the IXCLRDataModule interface and corresponds to the 26th slot of the virtual method
        /// table.
        /// </remarks>
        public XCLRDataMethodDefinition GetMethodDefinitionByToken(mdMethodDef token)
        {
            XCLRDataMethodDefinition methodDefinitionResult;
            TryGetMethodDefinitionByToken(token, out methodDefinitionResult).ThrowOnNotOK();

            return methodDefinitionResult;
        }

        /// <summary>
        /// Gets the method definition corresponding to a given metadata token.
        /// </summary>
        /// <param name="token">[in] The method token.</param>
        /// <param name="methodDefinitionResult">[out] The method definition.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataModule interface and corresponds to the 26th slot of the virtual method
        /// table.
        /// </remarks>
        public HRESULT TryGetMethodDefinitionByToken(mdMethodDef token, out XCLRDataMethodDefinition methodDefinitionResult)
        {
            /*HRESULT GetMethodDefinitionByToken(
            [In] mdMethodDef token,
            [Out] out IXCLRDataMethodDefinition methodDefinition);*/
            IXCLRDataMethodDefinition methodDefinition;
            HRESULT hr = Raw.GetMethodDefinitionByToken(token, out methodDefinition);

            if (hr == HRESULT.S_OK)
                methodDefinitionResult = methodDefinition == null ? null : new XCLRDataMethodDefinition(methodDefinition);
            else
                methodDefinitionResult = default(XCLRDataMethodDefinition);

            return hr;
        }

        #endregion
        #region StartEnumDataByName

        public IntPtr StartEnumDataByName(string name, CLRDataByNameFlag flags, IXCLRDataAppDomain appDomain, IXCLRDataTask tlsTask)
        {
            IntPtr handle;
            TryStartEnumDataByName(name, flags, appDomain, tlsTask, out handle).ThrowOnNotOK();

            return handle;
        }

        public HRESULT TryStartEnumDataByName(string name, CLRDataByNameFlag flags, IXCLRDataAppDomain appDomain, IXCLRDataTask tlsTask, out IntPtr handle)
        {
            /*HRESULT StartEnumDataByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] CLRDataByNameFlag flags,
            [In] IXCLRDataAppDomain appDomain,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumDataByName(name, flags, appDomain, tlsTask, out handle);
        }

        #endregion
        #region EnumDataByName

        public XCLRDataValue EnumDataByName(ref IntPtr handle)
        {
            XCLRDataValue valueResult;
            TryEnumDataByName(ref handle, out valueResult).ThrowOnNotOK();

            return valueResult;
        }

        public HRESULT TryEnumDataByName(ref IntPtr handle, out XCLRDataValue valueResult)
        {
            /*HRESULT EnumDataByName(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataValue value);*/
            IXCLRDataValue value;
            HRESULT hr = Raw.EnumDataByName(ref handle, out value);

            if (hr == HRESULT.S_OK)
                valueResult = value == null ? null : new XCLRDataValue(value);
            else
                valueResult = default(XCLRDataValue);

            return hr;
        }

        #endregion
        #region EndEnumDataByName

        public void EndEnumDataByName(IntPtr handle)
        {
            TryEndEnumDataByName(handle).ThrowOnNotOK();
        }

        public HRESULT TryEndEnumDataByName(IntPtr handle)
        {
            /*HRESULT EndEnumDataByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumDataByName(handle);
        }

        #endregion
        #region IsSameObject

        public bool IsSameObject(IXCLRDataModule mod)
        {
            HRESULT hr = TryIsSameObject(mod);
            hr.ThrowOnFailed();

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsSameObject(IXCLRDataModule mod)
        {
            /*HRESULT IsSameObject(
            [In] IXCLRDataModule mod);*/
            return Raw.IsSameObject(mod);
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

        public CLRDATA_MODULE_EXTENT EnumExtent(ref IntPtr handle)
        {
            CLRDATA_MODULE_EXTENT extent;
            TryEnumExtent(ref handle, out extent).ThrowOnNotOK();

            return extent;
        }

        public HRESULT TryEnumExtent(ref IntPtr handle, out CLRDATA_MODULE_EXTENT extent)
        {
            /*HRESULT EnumExtent(
            [In, Out] ref IntPtr handle,
            [Out] out CLRDATA_MODULE_EXTENT extent);*/
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

        /// <summary>
        /// Requests to populate the buffer given with the module's data.
        /// </summary>
        /// <param name="reqCode">[in] Request type to be sent.</param>
        /// <param name="inBufferSize">[in] size of the input buffer to be passed in.</param>
        /// <param name="inBuffer">[in, size_is(inBufferSize)] Buffer pointer for the raw data to be sent in the request.</param>
        /// <param name="outBufferSize">[in] Size of the output buffer.</param>
        /// <param name="outBuffer">[out, size_is(outBufferSize)] Buffer pointer to used to store the request response.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataModule interface and corresponds to the 37th slot of the virtual method
        /// table.
        /// </remarks>
        public void Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, IntPtr outBuffer)
        {
            TryRequest(reqCode, inBufferSize, inBuffer, outBufferSize, outBuffer).ThrowOnNotOK();
        }

        /// <summary>
        /// Requests to populate the buffer given with the module's data.
        /// </summary>
        /// <param name="reqCode">[in] Request type to be sent.</param>
        /// <param name="inBufferSize">[in] size of the input buffer to be passed in.</param>
        /// <param name="inBuffer">[in, size_is(inBufferSize)] Buffer pointer for the raw data to be sent in the request.</param>
        /// <param name="outBufferSize">[in] Size of the output buffer.</param>
        /// <param name="outBuffer">[out, size_is(outBufferSize)] Buffer pointer to used to store the request response.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataModule interface and corresponds to the 37th slot of the virtual method
        /// table.
        /// </remarks>
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
                appDomainResult = appDomain == null ? null : new XCLRDataAppDomain(appDomain);
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
        #region IXCLRDataModule2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IXCLRDataModule2 Raw2 => (IXCLRDataModule2) Raw;

        #region SetJITCompilerFlags

        public void SetJITCompilerFlags(CorDebugJITCompilerFlags dwFlags)
        {
            TrySetJITCompilerFlags(dwFlags).ThrowOnNotOK();
        }

        public HRESULT TrySetJITCompilerFlags(CorDebugJITCompilerFlags dwFlags)
        {
            /*HRESULT SetJITCompilerFlags(
            [In] CorDebugJITCompilerFlags dwFlags);*/
            return Raw2.SetJITCompilerFlags(dwFlags);
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
