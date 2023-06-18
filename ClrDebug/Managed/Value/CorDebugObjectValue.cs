using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// A subclass of "ICorDebugValue" that represents a value that contains an object.
    /// </summary>
    /// <remarks>
    /// An <see cref="ICorDebugObjectValue"/> remains valid until the process being debugged is continued.
    /// </remarks>
    public abstract class CorDebugObjectValue : CorDebugValue
    {
        public static CorDebugObjectValue New(ICorDebugObjectValue value)
        {
            if (value is ICorDebugContext)
                return new CorDebugContext((ICorDebugContext) value);

            throw new NotImplementedException("Encountered an 'ICorDebugObjectValue' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugObjectValue"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected CorDebugObjectValue(ICorDebugObjectValue raw) : base(raw)
        {
        }

        #region ICorDebugObjectValue

        public new ICorDebugObjectValue Raw => (ICorDebugObjectValue) base.Raw;

        #region Class

        /// <summary>
        /// Gets the class of this object value.
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
        /// Gets the class of this object value.
        /// </summary>
        /// <param name="ppClassResult">[out] A pointer to the address of an "ICorDebugClass" object that represents the class of the object value represented by this "ICorDebugObjectValue" object.</param>
        /// <remarks>
        /// The GetClass and <see cref="CorDebugValue.Type"/> propertys each return information about
        /// the type of a value; they are both superseded by the generics-aware <see cref="CorDebugValue.ExactType"/>.
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
        #region Context

        /// <summary>
        /// GetContext is not implemented in this version of the .NET Framework.
        /// </summary>
        public CorDebugContext Context
        {
            get
            {
                CorDebugContext ppContextResult;
                TryGetContext(out ppContextResult).ThrowOnNotOK();

                return ppContextResult;
            }
        }

        /// <summary>
        /// GetContext is not implemented in this version of the .NET Framework.
        /// </summary>
        public HRESULT TryGetContext(out CorDebugContext ppContextResult)
        {
            /*HRESULT GetContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugContext ppContext);*/
            ICorDebugContext ppContext;
            HRESULT hr = Raw.GetContext(out ppContext);

            if (hr == HRESULT.S_OK)
                ppContextResult = new CorDebugContext(ppContext);
            else
                ppContextResult = default(CorDebugContext);

            return hr;
        }

        #endregion
        #region IsValueClass

        /// <summary>
        /// Gets a value that indicates whether this object value is a value type.
        /// </summary>
        public bool IsValueClass
        {
            get
            {
                bool pbIsValueClass;
                TryIsValueClass(out pbIsValueClass).ThrowOnNotOK();

                return pbIsValueClass;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this object value is a value type.
        /// </summary>
        /// <param name="pbIsValueClass">[out] A pointer to a Boolean value that is true if the object value, represented by this "ICorDebugObjectValue", is a value type rather than a reference type; otherwise, pbIsValueClass is false.</param>
        public HRESULT TryIsValueClass(out bool pbIsValueClass)
        {
            /*HRESULT IsValueClass(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbIsValueClass);*/
            return Raw.IsValueClass(out pbIsValueClass);
        }

        #endregion
        #region ManagedCopy

        /// <summary>
        /// GetManagedCopy is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public object ManagedCopy
        {
            get
            {
                object ppObject;
                TryGetManagedCopy(out ppObject).ThrowOnNotOK();

                return ppObject;
            }
        }

        /// <summary>
        /// GetManagedCopy is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryGetManagedCopy(out object ppObject)
        {
            /*HRESULT GetManagedCopy(
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppObject);*/
            return Raw.GetManagedCopy(out ppObject);
        }

        #endregion
        #region GetFieldValue

        /// <summary>
        /// Gets the value of the specified field of the specified class for this object value.
        /// </summary>
        /// <param name="pClass">[in] A pointer to an "ICorDebugClass" object that represents the class for which to get the field value.</param>
        /// <param name="fieldDef">[in] An <see cref="mdFieldDef"/> token that references the metadata describing the field.</param>
        /// <returns>[out] A pointer to an "ICorDebugValue" object that represents the value of the specified field.</returns>
        /// <remarks>
        /// The class, specified in the pClass parameter, must be in the hierarchy of the object value's class, and the field
        /// must be a field of that class. The GetFieldValue method will still succeed for generic objects and generic classes.
        /// For example, if MyDictionary&lt;V&gt; inherits from Dictionary&lt;string,V&gt;, and the object value is of type
        /// MyDictionary&lt;int32&gt;, passing the <see cref="ICorDebugClass"/> object for Dictionary&lt;K,V&gt; will successfully get a
        /// field of Dictionary&lt;string,int32&gt;.
        /// </remarks>
        public CorDebugValue GetFieldValue(ICorDebugClass pClass, mdFieldDef fieldDef)
        {
            CorDebugValue ppValueResult;
            TryGetFieldValue(pClass, fieldDef, out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of the specified field of the specified class for this object value.
        /// </summary>
        /// <param name="pClass">[in] A pointer to an "ICorDebugClass" object that represents the class for which to get the field value.</param>
        /// <param name="fieldDef">[in] An <see cref="mdFieldDef"/> token that references the metadata describing the field.</param>
        /// <param name="ppValueResult">[out] A pointer to an "ICorDebugValue" object that represents the value of the specified field.</param>
        /// <remarks>
        /// The class, specified in the pClass parameter, must be in the hierarchy of the object value's class, and the field
        /// must be a field of that class. The GetFieldValue method will still succeed for generic objects and generic classes.
        /// For example, if MyDictionary&lt;V&gt; inherits from Dictionary&lt;string,V&gt;, and the object value is of type
        /// MyDictionary&lt;int32&gt;, passing the <see cref="ICorDebugClass"/> object for Dictionary&lt;K,V&gt; will successfully get a
        /// field of Dictionary&lt;string,int32&gt;.
        /// </remarks>
        public HRESULT TryGetFieldValue(ICorDebugClass pClass, mdFieldDef fieldDef, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetFieldValue(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugClass pClass,
            [In] mdFieldDef fieldDef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetFieldValue(pClass, fieldDef, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetVirtualMethod

        /// <summary>
        /// GetVirtualMethod is not implemented in this version of the .NET Framework.
        /// </summary>
        public CorDebugFunction GetVirtualMethod(int memberRef)
        {
            CorDebugFunction ppFunctionResult;
            TryGetVirtualMethod(memberRef, out ppFunctionResult).ThrowOnNotOK();

            return ppFunctionResult;
        }

        /// <summary>
        /// GetVirtualMethod is not implemented in this version of the .NET Framework.
        /// </summary>
        public HRESULT TryGetVirtualMethod(int memberRef, out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetVirtualMethod(
            [In] int memberRef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
            ICorDebugFunction ppFunction;
            HRESULT hr = Raw.GetVirtualMethod(memberRef, out ppFunction);

            if (hr == HRESULT.S_OK)
                ppFunctionResult = new CorDebugFunction(ppFunction);
            else
                ppFunctionResult = default(CorDebugFunction);

            return hr;
        }

        #endregion
        #region SetFromManagedCopy

        /// <summary>
        /// SetFromManagedCopy is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public void SetFromManagedCopy(object pObject)
        {
            TrySetFromManagedCopy(pObject).ThrowOnNotOK();
        }

        /// <summary>
        /// SetFromManagedCopy is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TrySetFromManagedCopy(object pObject)
        {
            /*HRESULT SetFromManagedCopy(
            [MarshalAs(UnmanagedType.IUnknown), In] object pObject);*/
            return Raw.SetFromManagedCopy(pObject);
        }

        #endregion
        #endregion
        #region ICorDebugObjectValue2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public new ICorDebugObjectValue2 Raw2 => (ICorDebugObjectValue2) Raw;

        #region GetVirtualMethodAndType

        /// <summary>
        /// This method is not yet implemented.
        /// </summary>
        /// <remarks>
        /// Gets interface pointers to the "ICorDebugFunction" and "ICorDebugType" instances that represent the most derived
        /// method and type for the specified member reference.
        /// </remarks>
        public GetVirtualMethodAndTypeResult GetVirtualMethodAndType(int memberRef)
        {
            GetVirtualMethodAndTypeResult result;
            TryGetVirtualMethodAndType(memberRef, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// This method is not yet implemented.
        /// </summary>
        /// <remarks>
        /// Gets interface pointers to the "ICorDebugFunction" and "ICorDebugType" instances that represent the most derived
        /// method and type for the specified member reference.
        /// </remarks>
        public HRESULT TryGetVirtualMethodAndType(int memberRef, out GetVirtualMethodAndTypeResult result)
        {
            /*HRESULT GetVirtualMethodAndType(
            [In] int memberRef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
            ICorDebugFunction ppFunction;
            ICorDebugType ppType;
            HRESULT hr = Raw2.GetVirtualMethodAndType(memberRef, out ppFunction, out ppType);

            if (hr == HRESULT.S_OK)
                result = new GetVirtualMethodAndTypeResult(new CorDebugFunction(ppFunction), new CorDebugType(ppType));
            else
                result = default(GetVirtualMethodAndTypeResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
