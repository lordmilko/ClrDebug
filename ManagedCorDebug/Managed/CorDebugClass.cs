using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a type, which can be either basic or complex (that is, user-defined). If the type is generic, <see cref="ICorDebugClass"/> represents the uninstantiated generic type.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugClass"/> interface represents an uninstantiated generic type. The <see cref="ICorDebugType"/> interface represents
    /// an instantiated generic type. For example, Hashtable&lt;K, V&gt; would be represented by <see cref="ICorDebugClass"/>, whereas
    /// Hashtable&lt;Int32, String&gt; would be represented by <see cref="ICorDebugType"/>. Non-generic types are represented by both
    /// <see cref="ICorDebugClass"/> and <see cref="ICorDebugType"/>. The latter interface was introduced in the .NET Framework version 2.0 to deal
    /// with type instantiation.
    /// </remarks>
    public class CorDebugClass : ComObject<ICorDebugClass>
    {
        public CorDebugClass(ICorDebugClass raw) : base(raw)
        {
        }

        #region ICorDebugClass
        #region Module

        /// <summary>
        /// Gets the module that defines this class.
        /// </summary>
        public CorDebugModule Module
        {
            get
            {
                HRESULT hr;
                CorDebugModule pModuleResult;

                if ((hr = TryGetModule(out pModuleResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pModuleResult;
            }
        }

        /// <summary>
        /// Gets the module that defines this class.
        /// </summary>
        /// <param name="pModuleResult">[out] A pointer to the address of an <see cref="ICorDebugModule"/> object that represents the module in which this class is defined.</param>
        public HRESULT TryGetModule(out CorDebugModule pModuleResult)
        {
            /*HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule pModule);*/
            ICorDebugModule pModule;
            HRESULT hr = Raw.GetModule(out pModule);

            if (hr == HRESULT.S_OK)
                pModuleResult = new CorDebugModule(pModule);
            else
                pModuleResult = default(CorDebugModule);

            return hr;
        }

        #endregion
        #region Token

        /// <summary>
        /// Gets the TypeDef metadata token that references the definition of this class.
        /// </summary>
        public mdTypeDef Token
        {
            get
            {
                HRESULT hr;
                mdTypeDef pTypeDef;

                if ((hr = TryGetToken(out pTypeDef)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pTypeDef;
            }
        }

        /// <summary>
        /// Gets the TypeDef metadata token that references the definition of this class.
        /// </summary>
        /// <param name="pTypeDef">[out] A pointer to an <see cref="mdTypeDef"/> token that references the definition of this class.</param>
        public HRESULT TryGetToken(out mdTypeDef pTypeDef)
        {
            /*HRESULT GetToken(out mdTypeDef pTypeDef);*/
            return Raw.GetToken(out pTypeDef);
        }

        #endregion
        #region GetStaticFieldValue

        /// <summary>
        /// Gets the value of the specified static field.
        /// </summary>
        /// <param name="fieldDef">[in] A field Def token that references the field to be retrieved.</param>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> object that represents the frame to be used to disambiguate among thread, context, or application domain statics.<para/>
        /// If the static field is relative to a thread, a context, or an application domain, the frame will determine the proper value.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the static field.</returns>
        /// <remarks>
        /// For parameterized types, the value of a static field is relative to the particular instantiation. Therefore, if
        /// the class constructor takes parameters of type <see cref="Type"/>, call <see cref="CorDebugType.GetStaticFieldValue"/>
        /// instead of ICorDebugClass::GetStaticFieldValue.
        /// </remarks>
        public CorDebugValue GetStaticFieldValue(int fieldDef, ICorDebugFrame pFrame)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetStaticFieldValue(fieldDef, pFrame, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of the specified static field.
        /// </summary>
        /// <param name="fieldDef">[in] A field Def token that references the field to be retrieved.</param>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> object that represents the frame to be used to disambiguate among thread, context, or application domain statics.<para/>
        /// If the static field is relative to a thread, a context, or an application domain, the frame will determine the proper value.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the static field.</param>
        /// <remarks>
        /// For parameterized types, the value of a static field is relative to the particular instantiation. Therefore, if
        /// the class constructor takes parameters of type <see cref="Type"/>, call <see cref="CorDebugType.GetStaticFieldValue"/>
        /// instead of ICorDebugClass::GetStaticFieldValue.
        /// </remarks>
        public HRESULT TryGetStaticFieldValue(int fieldDef, ICorDebugFrame pFrame, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetStaticFieldValue([In] int fieldDef, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
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
        #region ICorDebugClass2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugClass2 Raw2 => (ICorDebugClass2) Raw;

        #region GetParameterizedType

        /// <summary>
        /// Gets the type declaration for this class.
        /// </summary>
        /// <param name="elementType">[in] A value of the <see cref="CorElementType"/> enumeration that specifies the element type for this class: Set this value to ELEMENT_TYPE_VALUETYPE if this <see cref="ICorDebugClass2"/> represents a value type.<para/>
        /// Set this value to ELEMENT_TYPE_CLASS if this <see cref="ICorDebugClass2"/> represents a complex type.</param>
        /// <param name="nTypeArgs">[in] The number of type parameters, if the type is generic. The number of type parameters (if any) must match the number required by the class.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a type parameter. If the class is non-generic, this value is null.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the type declaration. This object is equivalent to a <see cref="Type"/> object in managed code.</returns>
        /// <remarks>
        /// If the class is non-generic, that is, if it has no type parameters, GetParameterizedType simply gets the runtime
        /// type object corresponding to the class. The elementType parameter should be set to the correct element type for
        /// the class: ELEMENT_TYPE_VALUETYPE if the class is a value type; otherwise, ELEMENT_TYPE_CLASS. If the class accepts
        /// type parameters (for example, ArrayList&lt;T&gt;), you can use GetParameterizedType to construct a type object
        /// for an instantiated type such as ArrayList&lt;int&gt;.
        /// </remarks>
        public CorDebugType GetParameterizedType(CorElementType elementType, int nTypeArgs, ICorDebugType ppTypeArgs)
        {
            HRESULT hr;
            CorDebugType ppTypeResult;

            if ((hr = TryGetParameterizedType(elementType, nTypeArgs, ppTypeArgs, out ppTypeResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppTypeResult;
        }

        /// <summary>
        /// Gets the type declaration for this class.
        /// </summary>
        /// <param name="elementType">[in] A value of the <see cref="CorElementType"/> enumeration that specifies the element type for this class: Set this value to ELEMENT_TYPE_VALUETYPE if this <see cref="ICorDebugClass2"/> represents a value type.<para/>
        /// Set this value to ELEMENT_TYPE_CLASS if this <see cref="ICorDebugClass2"/> represents a complex type.</param>
        /// <param name="nTypeArgs">[in] The number of type parameters, if the type is generic. The number of type parameters (if any) must match the number required by the class.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a type parameter. If the class is non-generic, this value is null.</param>
        /// <param name="ppTypeResult">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the type declaration. This object is equivalent to a <see cref="Type"/> object in managed code.</param>
        /// <remarks>
        /// If the class is non-generic, that is, if it has no type parameters, GetParameterizedType simply gets the runtime
        /// type object corresponding to the class. The elementType parameter should be set to the correct element type for
        /// the class: ELEMENT_TYPE_VALUETYPE if the class is a value type; otherwise, ELEMENT_TYPE_CLASS. If the class accepts
        /// type parameters (for example, ArrayList&lt;T&gt;), you can use GetParameterizedType to construct a type object
        /// for an instantiated type such as ArrayList&lt;int&gt;.
        /// </remarks>
        public HRESULT TryGetParameterizedType(CorElementType elementType, int nTypeArgs, ICorDebugType ppTypeArgs, out CorDebugType ppTypeResult)
        {
            /*HRESULT GetParameterizedType(
            [In] CorElementType elementType,
            [In] int nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
            ICorDebugType ppType;
            HRESULT hr = Raw2.GetParameterizedType(elementType, nTypeArgs, ref ppTypeArgs, out ppType);

            if (hr == HRESULT.S_OK)
                ppTypeResult = new CorDebugType(ppType);
            else
                ppTypeResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #region SetJMCStatus

        /// <summary>
        /// For each method of the class, sets a value that indicates whether the method is user-defined code.
        /// </summary>
        /// <param name="bIsJustMyCode">[in] Set to true to indicate that the method is user-defined code; otherwise, set to false.</param>
        /// <remarks>
        /// A just-my-code (JMC) stepper will skip non-user-defined code. User-defined code must be a subset of debuggable
        /// code. SetJMCStatus returns an <see cref="HRESULT"/> value of S_FALSE if it fails to set the value for any method, even if it
        /// successfully sets the value for all other methods.
        /// </remarks>
        public void SetJMCStatus(int bIsJustMyCode)
        {
            HRESULT hr;

            if ((hr = TrySetJMCStatus(bIsJustMyCode)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// For each method of the class, sets a value that indicates whether the method is user-defined code.
        /// </summary>
        /// <param name="bIsJustMyCode">[in] Set to true to indicate that the method is user-defined code; otherwise, set to false.</param>
        /// <remarks>
        /// A just-my-code (JMC) stepper will skip non-user-defined code. User-defined code must be a subset of debuggable
        /// code. SetJMCStatus returns an <see cref="HRESULT"/> value of S_FALSE if it fails to set the value for any method, even if it
        /// successfully sets the value for all other methods.
        /// </remarks>
        public HRESULT TrySetJMCStatus(int bIsJustMyCode)
        {
            /*HRESULT SetJMCStatus([In] int bIsJustMyCode);*/
            return Raw2.SetJMCStatus(bIsJustMyCode);
        }

        #endregion
        #endregion
    }
}