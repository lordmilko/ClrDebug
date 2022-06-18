using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
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
        #region VersionId

        public Guid VersionId
        {
            get
            {
                HRESULT hr;
                Guid vid;

                if ((hr = TryGetVersionId(out vid)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return vid;
            }
        }

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
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumAssemblies(out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            HRESULT hr;
            XCLRDataAssembly assemblyResult;

            if ((hr = TryEnumAssembly(ref handle, out assemblyResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
                assemblyResult = new XCLRDataAssembly(assembly);
            else
                assemblyResult = default(XCLRDataAssembly);

            return hr;
        }

        #endregion
        #region EndEnumAssemblies

        public void EndEnumAssemblies(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumAssemblies(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumTypeDefinitions(out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            HRESULT hr;
            XCLRDataTypeDefinition typeDefinitionResult;

            if ((hr = TryEnumTypeDefinition(ref handle, out typeDefinitionResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
                typeDefinitionResult = new XCLRDataTypeDefinition(typeDefinition);
            else
                typeDefinitionResult = default(XCLRDataTypeDefinition);

            return hr;
        }

        #endregion
        #region EndEnumTypeDefinitions

        public void EndEnumTypeDefinitions(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumTypeDefinitions(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumTypeInstances(appDomain, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            HRESULT hr;
            XCLRDataTypeInstance typeInstanceResult;

            if ((hr = TryEnumTypeInstance(ref handle, out typeInstanceResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
                typeInstanceResult = new XCLRDataTypeInstance(typeInstance);
            else
                typeInstanceResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region EndEnumTypeInstances

        public void EndEnumTypeInstances(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumTypeInstances(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumTypeInstances(IntPtr handle)
        {
            /*HRESULT EndEnumTypeInstances(
            [In] IntPtr handle);*/
            return Raw.EndEnumTypeInstances(handle);
        }

        #endregion
        #region StartEnumTypeDefinitionsByName

        public IntPtr StartEnumTypeDefinitionsByName(string name, int flags)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumTypeDefinitionsByName(name, flags, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumTypeDefinitionsByName(string name, int flags, out IntPtr handle)
        {
            /*HRESULT StartEnumTypeDefinitionsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumTypeDefinitionsByName(name, flags, out handle);
        }

        #endregion
        #region EnumTypeDefinitionByName

        public XCLRDataTypeDefinition EnumTypeDefinitionByName(ref IntPtr handle)
        {
            HRESULT hr;
            XCLRDataTypeDefinition typeResult;

            if ((hr = TryEnumTypeDefinitionByName(ref handle, out typeResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
                typeResult = new XCLRDataTypeDefinition(type);
            else
                typeResult = default(XCLRDataTypeDefinition);

            return hr;
        }

        #endregion
        #region EndEnumTypeDefinitionsByName

        public void EndEnumTypeDefinitionsByName(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumTypeDefinitionsByName(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumTypeDefinitionsByName(IntPtr handle)
        {
            /*HRESULT EndEnumTypeDefinitionsByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumTypeDefinitionsByName(handle);
        }

        #endregion
        #region StartEnumTypeInstancesByName

        public IntPtr StartEnumTypeInstancesByName(string name, int flags, IXCLRDataAppDomain appDomain)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumTypeInstancesByName(name, flags, appDomain, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumTypeInstancesByName(string name, int flags, IXCLRDataAppDomain appDomain, out IntPtr handle)
        {
            /*HRESULT StartEnumTypeInstancesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumTypeInstancesByName(name, flags, appDomain, out handle);
        }

        #endregion
        #region EnumTypeInstanceByName

        public XCLRDataTypeInstance EnumTypeInstanceByName(ref IntPtr handle)
        {
            HRESULT hr;
            XCLRDataTypeInstance typeResult;

            if ((hr = TryEnumTypeInstanceByName(ref handle, out typeResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
                typeResult = new XCLRDataTypeInstance(type);
            else
                typeResult = default(XCLRDataTypeInstance);

            return hr;
        }

        #endregion
        #region EndEnumTypeInstancesByName

        public void EndEnumTypeInstancesByName(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumTypeInstancesByName(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;
            XCLRDataTypeDefinition typeDefinitionResult;

            if ((hr = TryGetTypeDefinitionByToken(token, out typeDefinitionResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
                typeDefinitionResult = new XCLRDataTypeDefinition(typeDefinition);
            else
                typeDefinitionResult = default(XCLRDataTypeDefinition);

            return hr;
        }

        #endregion
        #region StartEnumMethodDefinitionsByName

        public IntPtr StartEnumMethodDefinitionsByName(string name, int flags)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumMethodDefinitionsByName(name, flags, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumMethodDefinitionsByName(string name, int flags, out IntPtr handle)
        {
            /*HRESULT StartEnumMethodDefinitionsByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodDefinitionsByName(name, flags, out handle);
        }

        #endregion
        #region EnumMethodDefinitionByName

        public XCLRDataMethodDefinition EnumMethodDefinitionByName(ref IntPtr handle)
        {
            HRESULT hr;
            XCLRDataMethodDefinition methodResult;

            if ((hr = TryEnumMethodDefinitionByName(ref handle, out methodResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
                methodResult = new XCLRDataMethodDefinition(method);
            else
                methodResult = default(XCLRDataMethodDefinition);

            return hr;
        }

        #endregion
        #region EndEnumMethodDefinitionsByName

        public void EndEnumMethodDefinitionsByName(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumMethodDefinitionsByName(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumMethodDefinitionsByName(IntPtr handle)
        {
            /*HRESULT EndEnumMethodDefinitionsByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodDefinitionsByName(handle);
        }

        #endregion
        #region StartEnumMethodInstancesByName

        public IntPtr StartEnumMethodInstancesByName(string name, int flags, IXCLRDataAppDomain appDomain)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumMethodInstancesByName(name, flags, appDomain, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumMethodInstancesByName(string name, int flags, IXCLRDataAppDomain appDomain, out IntPtr handle)
        {
            /*HRESULT StartEnumMethodInstancesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumMethodInstancesByName(name, flags, appDomain, out handle);
        }

        #endregion
        #region EnumMethodInstanceByName

        public XCLRDataMethodInstance EnumMethodInstanceByName(ref IntPtr handle)
        {
            HRESULT hr;
            XCLRDataMethodInstance methodResult;

            if ((hr = TryEnumMethodInstanceByName(ref handle, out methodResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
                methodResult = new XCLRDataMethodInstance(method);
            else
                methodResult = default(XCLRDataMethodInstance);

            return hr;
        }

        #endregion
        #region EndEnumMethodInstancesByName

        public void EndEnumMethodInstancesByName(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumMethodInstancesByName(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndEnumMethodInstancesByName(IntPtr handle)
        {
            /*HRESULT EndEnumMethodInstancesByName(
            [In] IntPtr handle);*/
            return Raw.EndEnumMethodInstancesByName(handle);
        }

        #endregion
        #region GetMethodDefinitionByToken

        public XCLRDataMethodDefinition GetMethodDefinitionByToken(mdMethodDef token)
        {
            HRESULT hr;
            XCLRDataMethodDefinition methodDefinitionResult;

            if ((hr = TryGetMethodDefinitionByToken(token, out methodDefinitionResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return methodDefinitionResult;
        }

        public HRESULT TryGetMethodDefinitionByToken(mdMethodDef token, out XCLRDataMethodDefinition methodDefinitionResult)
        {
            /*HRESULT GetMethodDefinitionByToken(
            [In] mdMethodDef token,
            [Out] out IXCLRDataMethodDefinition methodDefinition);*/
            IXCLRDataMethodDefinition methodDefinition;
            HRESULT hr = Raw.GetMethodDefinitionByToken(token, out methodDefinition);

            if (hr == HRESULT.S_OK)
                methodDefinitionResult = new XCLRDataMethodDefinition(methodDefinition);
            else
                methodDefinitionResult = default(XCLRDataMethodDefinition);

            return hr;
        }

        #endregion
        #region StartEnumDataByName

        public IntPtr StartEnumDataByName(string name, int flags, IXCLRDataAppDomain appDomain, IXCLRDataTask tlsTask)
        {
            HRESULT hr;
            IntPtr handle;

            if ((hr = TryStartEnumDataByName(name, flags, appDomain, tlsTask, out handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return handle;
        }

        public HRESULT TryStartEnumDataByName(string name, int flags, IXCLRDataAppDomain appDomain, IXCLRDataTask tlsTask, out IntPtr handle)
        {
            /*HRESULT StartEnumDataByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int flags,
            [In] IXCLRDataAppDomain appDomain,
            [In] IXCLRDataTask tlsTask,
            [Out] out IntPtr handle);*/
            return Raw.StartEnumDataByName(name, flags, appDomain, tlsTask, out handle);
        }

        #endregion
        #region EnumDataByName

        public XCLRDataValue EnumDataByName(ref IntPtr handle)
        {
            HRESULT hr;
            XCLRDataValue valueResult;

            if ((hr = TryEnumDataByName(ref handle, out valueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
                valueResult = new XCLRDataValue(value);
            else
                valueResult = default(XCLRDataValue);

            return hr;
        }

        #endregion
        #region EndEnumDataByName

        public void EndEnumDataByName(IntPtr handle)
        {
            HRESULT hr;

            if ((hr = TryEndEnumDataByName(handle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryIsSameObject(mod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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

        public CLRDATA_MODULE_EXTENT EnumExtent(ref IntPtr handle)
        {
            HRESULT hr;
            CLRDATA_MODULE_EXTENT extent;

            if ((hr = TryEnumExtent(ref handle, out extent)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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

        public XCLRDataAppDomain EnumAppDomain(ref IntPtr handle)
        {
            HRESULT hr;
            XCLRDataAppDomain appDomainResult;

            if ((hr = TryEnumAppDomain(ref handle, out appDomainResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
        #region IXCLRDataModule2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IXCLRDataModule2 Raw2 => (IXCLRDataModule2) Raw;

        #region SetJITCompilerFlags

        public void SetJITCompilerFlags(int dwFlags)
        {
            HRESULT hr;

            if ((hr = TrySetJITCompilerFlags(dwFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetJITCompilerFlags(int dwFlags)
        {
            /*HRESULT SetJITCompilerFlags(
            [In] int dwFlags);*/
            return Raw2.SetJITCompilerFlags(dwFlags);
        }

        #endregion
        #endregion
    }
}