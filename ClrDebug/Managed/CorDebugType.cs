using System;
using System.Diagnostics;
using System.Linq;

namespace ClrDebug
{
    /// <summary>
    /// Represents a type, either basic or complex (that is, user-defined). If the type is generic, <see cref="ICorDebugType"/> represents the instantiated generic type.
    /// </summary>
    /// <remarks>
    /// If the type is generic, <see cref="ICorDebugClass"/> represents the uninstantiated type. The <see cref="ICorDebugType"/> interface represents
    /// an instantiated generic type. For example, Hashtable&lt;K, V&gt; would be represented by <see cref="ICorDebugClass"/>, whereas
    /// Hashtable&lt;Int32, String&gt; would be represented by <see cref="ICorDebugType"/>. Non-generic types are represented by both
    /// <see cref="ICorDebugClass"/> and <see cref="ICorDebugType"/>. The latter interface was introduced in the .NET Framework version 2.0 to deal
    /// with type instantiation.
    /// </remarks>
    public class CorDebugType : ComObject<ICorDebugType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugType"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugType(ICorDebugType raw) : base(raw)
        {
        }

        #region ICorDebugType
        #region Type

        /// <summary>
        /// Gets a <see cref="CorElementType"/> value that describes the native type of the common language runtime (CLR) <see cref="Type"/> represented by this <see cref="ICorDebugType"/>.
        /// </summary>
        public CorElementType Type
        {
            get
            {
                CorElementType ty;
                TryGetType(out ty).ThrowOnNotOK();

                return ty;
            }
        }

        /// <summary>
        /// Gets a <see cref="CorElementType"/> value that describes the native type of the common language runtime (CLR) <see cref="Type"/> represented by this <see cref="ICorDebugType"/>.
        /// </summary>
        /// <param name="ty">[out] A pointer to a value of the <see cref="CorElementType"/> enumeration that indicates the CLR <see cref="Type"/> that this <see cref="ICorDebugType"/> represents.</param>
        /// <remarks>
        /// If the value of ty is either ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE, the <see cref="Class"/> property may
        /// be called to get the uninstantiated type for a generic type; otherwise, do not call ICorDebugType::GetClass.
        /// </remarks>
        public HRESULT TryGetType(out CorElementType ty)
        {
            /*HRESULT GetType(
            [Out] out CorElementType ty);*/
            return Raw.GetType(out ty);
        }

        #endregion
        #region Class

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugClass"/> that represents the uninstantiated generic type.
        /// </summary>
        public CorDebugClass Class
        {
            get
            {
                CorDebugClass ppClassResult;
                TryGetClass(out ppClassResult).ThrowOnNotOK();

                return ppClassResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugClass"/> that represents the uninstantiated generic type.
        /// </summary>
        /// <param name="ppClassResult">[out] A pointer to the address of an <see cref="ICorDebugClass"/> interface that represents the uninstantiated generic type.</param>
        /// <remarks>
        /// GetClass can be called only under certain conditions. Call <see cref="Type"/> before calling GetClass. If ICorDebugType::GetType
        /// returns a <see cref="CorElementType"/> value that is ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE, GetClass can be called to
        /// get the uninstantiated type for a generic type.
        /// </remarks>
        public HRESULT TryGetClass(out CorDebugClass ppClassResult)
        {
            /*HRESULT GetClass(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);*/
            ICorDebugClass ppClass;
            HRESULT hr = Raw.GetClass(out ppClass);

            if (hr == HRESULT.S_OK)
                ppClassResult = new CorDebugClass(ppClass);
            else
                ppClassResult = default(CorDebugClass);

            return hr;
        }

        #endregion
        #region FirstTypeParameter

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugType"/> that represents the first <see cref="Type"/> parameter of the type represented by this <see cref="ICorDebugType"/>.
        /// </summary>
        public CorDebugType FirstTypeParameter
        {
            get
            {
                CorDebugType valueResult;
                TryGetFirstTypeParameter(out valueResult).ThrowOnNotOK();

                return valueResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugType"/> that represents the first <see cref="Type"/> parameter of the type represented by this <see cref="ICorDebugType"/>.
        /// </summary>
        /// <param name="valueResult">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the first parameter.</param>
        /// <remarks>
        /// GetFirstTypeParameter can be called in cases where the additional information about the type involves, at most,
        /// one type parameter. In particular, it can be used if the type is an ELEMENT_TYPE_ARRAY, ELEMENT_TYPE_SZARRAY, ELEMENT_TYPE_BYREF,
        /// or ELEMENT_TYPE_PTR, as indicated by the <see cref="Type"/> property.
        /// </remarks>
        public HRESULT TryGetFirstTypeParameter(out CorDebugType valueResult)
        {
            /*HRESULT GetFirstTypeParameter(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType value);*/
            ICorDebugType value;
            HRESULT hr = Raw.GetFirstTypeParameter(out value);

            if (hr == HRESULT.S_OK)
                valueResult = new CorDebugType(value);
            else
                valueResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #region Base

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugType"/> that represents the base type, if one exists, of the type represented by this <see cref="ICorDebugType"/>.
        /// </summary>
        public CorDebugType Base
        {
            get
            {
                CorDebugType pBaseResult;
                TryGetBase(out pBaseResult).ThrowOnNotOK();

                return pBaseResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugType"/> that represents the base type, if one exists, of the type represented by this <see cref="ICorDebugType"/>.
        /// </summary>
        /// <param name="pBaseResult">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the base type.</param>
        /// <remarks>
        /// Looking up the base type for a type is useful to implement common debugger functionality, such as printing out
        /// all the fields of an object or its parent classes.
        /// </remarks>
        public HRESULT TryGetBase(out CorDebugType pBaseResult)
        {
            /*HRESULT GetBase(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType pBase);*/
            ICorDebugType pBase;
            HRESULT hr = Raw.GetBase(out pBase);

            if (hr == HRESULT.S_OK)
                pBaseResult = new CorDebugType(pBase);
            else
                pBaseResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #region Rank

        /// <summary>
        /// Gets the number of dimensions in an array type.
        /// </summary>
        public int Rank
        {
            get
            {
                int pnRank;
                TryGetRank(out pnRank).ThrowOnNotOK();

                return pnRank;
            }
        }

        /// <summary>
        /// Gets the number of dimensions in an array type.
        /// </summary>
        /// <param name="pnRank">[out] A pointer to the number of dimensions.</param>
        public HRESULT TryGetRank(out int pnRank)
        {
            /*HRESULT GetRank(
            [Out] out int pnRank);*/
            return Raw.GetRank(out pnRank);
        }

        #endregion
        #region EnumerateTypeParameters

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugTypeEnum"/> that contains the <see cref="Type"/> parameters of the class referenced by this <see cref="ICorDebugType"/>.
        /// </summary>
        public CorDebugType[] TypeParameters => EnumerateTypeParameters().ToArray();

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugTypeEnum"/> that contains the <see cref="Type"/> parameters of the class referenced by this <see cref="ICorDebugType"/>.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugTypeEnum"/> that contains the parameters of the type.</returns>
        /// <remarks>
        /// You can use EnumerateTypeParameters if the <see cref="CorElementType"/> value returned by <see cref="Type"/> is ELEMENT_TYPE_CLASS,
        /// ELEMENT_TYPE_VALUETYPE, ELEMENT_TYPE_ARRAY, ELEMENT_TYPE_SZARRAY, ELEMENT_TYPE_BYREF, ELEMENT_TYPE_PTR, or ELEMENT_TYPE_FNPTR.
        /// The number of parameters and their order depends on the type:
        /// </remarks>
        public CorDebugTypeEnum EnumerateTypeParameters()
        {
            CorDebugTypeEnum ppTyParEnumResult;
            TryEnumerateTypeParameters(out ppTyParEnumResult).ThrowOnNotOK();

            return ppTyParEnumResult;
        }

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugTypeEnum"/> that contains the <see cref="Type"/> parameters of the class referenced by this <see cref="ICorDebugType"/>.
        /// </summary>
        /// <param name="ppTyParEnumResult">[out] A pointer to the address of an <see cref="ICorDebugTypeEnum"/> that contains the parameters of the type.</param>
        /// <remarks>
        /// You can use EnumerateTypeParameters if the <see cref="CorElementType"/> value returned by <see cref="Type"/> is ELEMENT_TYPE_CLASS,
        /// ELEMENT_TYPE_VALUETYPE, ELEMENT_TYPE_ARRAY, ELEMENT_TYPE_SZARRAY, ELEMENT_TYPE_BYREF, ELEMENT_TYPE_PTR, or ELEMENT_TYPE_FNPTR.
        /// The number of parameters and their order depends on the type:
        /// </remarks>
        public HRESULT TryEnumerateTypeParameters(out CorDebugTypeEnum ppTyParEnumResult)
        {
            /*HRESULT EnumerateTypeParameters(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTyParEnum);*/
            ICorDebugTypeEnum ppTyParEnum;
            HRESULT hr = Raw.EnumerateTypeParameters(out ppTyParEnum);

            if (hr == HRESULT.S_OK)
                ppTyParEnumResult = new CorDebugTypeEnum(ppTyParEnum);
            else
                ppTyParEnumResult = default(CorDebugTypeEnum);

            return hr;
        }

        #endregion
        #region GetStaticFieldValue

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that contains the value of the static field referenced by the specified field token in the specified stack frame.
        /// </summary>
        /// <param name="fieldDef">[in] An <see cref="mdFieldDef"/> token that specifies the static field.</param>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> that represents the stack frame.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValue"/> that contains the value of the static field.</returns>
        /// <remarks>
        /// The GetStaticFieldValue method may be used only if the type is ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE, as
        /// indicated by the <see cref="Type"/> property. For non-generic types, the operation performed by GetStaticFieldValue
        /// is identical to calling <see cref="CorDebugClass.GetStaticFieldValue"/> on the <see cref="ICorDebugClass"/> object that is returned
        /// by <see cref="Class"/>. For generic types, a static field value will be relative to a particular instantiation.
        /// Also, if the static field could possibly be relative to a thread, a context, or an application domain, then the
        /// stack frame will help the debugger determine the proper value. GetStaticFieldValue can be used only when a call
        /// to <see cref="Type"/> returns a value of ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE.
        /// </remarks>
        public CorDebugValue GetStaticFieldValue(mdFieldDef fieldDef, ICorDebugFrame pFrame)
        {
            CorDebugValue ppValueResult;
            TryGetStaticFieldValue(fieldDef, pFrame, out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that contains the value of the static field referenced by the specified field token in the specified stack frame.
        /// </summary>
        /// <param name="fieldDef">[in] An <see cref="mdFieldDef"/> token that specifies the static field.</param>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> that represents the stack frame.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> that contains the value of the static field.</param>
        /// <remarks>
        /// The GetStaticFieldValue method may be used only if the type is ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE, as
        /// indicated by the <see cref="Type"/> property. For non-generic types, the operation performed by GetStaticFieldValue
        /// is identical to calling <see cref="CorDebugClass.GetStaticFieldValue"/> on the <see cref="ICorDebugClass"/> object that is returned
        /// by <see cref="Class"/>. For generic types, a static field value will be relative to a particular instantiation.
        /// Also, if the static field could possibly be relative to a thread, a context, or an application domain, then the
        /// stack frame will help the debugger determine the proper value. GetStaticFieldValue can be used only when a call
        /// to <see cref="Type"/> returns a value of ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE.
        /// </remarks>
        public HRESULT TryGetStaticFieldValue(mdFieldDef fieldDef, ICorDebugFrame pFrame, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetStaticFieldValue(
            [In] mdFieldDef fieldDef,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugFrame pFrame,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetStaticFieldValue(fieldDef, pFrame, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugType2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugType2 Raw2 => (ICorDebugType2) Raw;

        #region TypeID

        /// <summary>
        /// Gets a <see cref="COR_TYPEID"/> for this type.
        /// </summary>
        public COR_TYPEID TypeID
        {
            get
            {
                COR_TYPEID id;
                TryGetTypeID(out id).ThrowOnNotOK();

                return id;
            }
        }

        /// <summary>
        /// Gets a <see cref="COR_TYPEID"/> for this type.
        /// </summary>
        /// <param name="id">[out] A pointer to the <see cref="COR_TYPEID"/> for this <see cref="ICorDebugType"/>.</param>
        /// <returns>
        /// The return value is S_OK on success, or a failure HRESULT code on failure. The HRESULT codes include the following:
        /// 
        /// | Return code               | Description                                                                  |
        /// | ------------------------- | ---------------------------------------------------------------------------- |
        /// | S_OK                      | Method succeeded. The method has retrieved a valid <see cref="COR_TYPEID"/>. |
        /// | CORDBG_E_CLASS_NOT_LOADED | The type has not been loaded.                                                |
        /// | CORDBG_E_UNSUPPORTED      | The type is not supported.                                                   |
        /// </returns>
        /// <remarks>
        /// This method provides a mapping from the <see cref="ICorDebugType"/>, which represents a type that may or may not have been loaded
        /// into the runtime, to a <see cref="COR_TYPEID"/>, which serves as an opaque handle that identifies a type loaded
        /// into the runtime. When the type that the <see cref="ICorDebugType"/> represents has not yet been loaded, this method returns
        /// CORDBG_E_CLASS_NOT_LOADED. If the type is not supported, it returns CORDBG_E_UNSUPPORTED.
        /// </remarks>
        public HRESULT TryGetTypeID(out COR_TYPEID id)
        {
            /*HRESULT GetTypeID(
            [Out] out COR_TYPEID id);*/
            return Raw2.GetTypeID(out id);
        }

        #endregion
        #endregion
    }
}
