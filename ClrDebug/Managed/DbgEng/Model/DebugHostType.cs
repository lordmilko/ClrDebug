using System.Diagnostics;
using ClrDebug.TypeLib;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An (<see cref="IDebugHostSymbol"/> derived) interface to a particular type. A given language/native type is described by the <see cref="IDebugHostType2"/> or IDebugHostType interfaces.<para/>
    /// Note that some of the methods on these interfaces only apply for specific kinds of types.
    /// </summary>
    public class DebugHostType : DebugHostSymbol
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostType"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostType(IDebugHostType raw) : base(raw)
        {
        }

        #region IDebugHostType

        public new IDebugHostType Raw => (IDebugHostType) base.Raw;

        #region TypeKind

        /// <summary>
        /// The GetTypeKind method returns what kind of type (pointer, array, intrinsic, etc...) the symbol refers to. See the <see cref="TypeKind"/> for more information.
        /// </summary>
        public TypeKind TypeKind
        {
            get
            {
                TypeKind kind;
                TryGetTypeKind(out kind).ThrowDbgEngNotOK();

                return kind;
            }
        }

        /// <summary>
        /// The GetTypeKind method returns what kind of type (pointer, array, intrinsic, etc...) the symbol refers to. See the <see cref="TypeKind"/> for more information.
        /// </summary>
        /// <param name="kind">The kind of type the symbol refers to will be returned here (as a member of the TypeKind enumeration).</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetTypeKind(out TypeKind kind)
        {
            /*HRESULT GetTypeKind(
            [Out] out TypeKind kind);*/
            return Raw.GetTypeKind(out kind);
        }

        #endregion
        #region Size

        /// <summary>
        /// The GetSize method returns the size of the type (as if one had done sizeof(type) in C++).
        /// </summary>
        public long Size
        {
            get
            {
                long size;
                TryGetSize(out size).ThrowDbgEngNotOK();

                return size;
            }
        }

        /// <summary>
        /// The GetSize method returns the size of the type (as if one had done sizeof(type) in C++).
        /// </summary>
        /// <param name="size">The size of the type will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetSize(out long size)
        {
            /*HRESULT GetSize(
            [Out] out long size);*/
            return Raw.GetSize(out size);
        }

        #endregion
        #region BaseType

        /// <summary>
        /// If the type is a derivative of another single type (e.g.: as MyStruct * is derived from MyStruct'), the GetBaseType method returns the base type of the derivation.<para/>
        /// For pointers, this returns the type pointed to. For arrays, this returns what the array is an array of. If the type is not such a derivative type, an error is returned.<para/>
        /// Note that this method has nothing to do with C++ (or other linguistic) base classes. Such are symbols (<see cref="IDebugHostBaseClass"/>) which can be enumerated from the derived class via a call to the EnumerateChildren method.
        /// </summary>
        public DebugHostType BaseType
        {
            get
            {
                DebugHostType baseTypeResult;
                TryGetBaseType(out baseTypeResult).ThrowDbgEngNotOK();

                return baseTypeResult;
            }
        }

        /// <summary>
        /// If the type is a derivative of another single type (e.g.: as MyStruct * is derived from MyStruct'), the GetBaseType method returns the base type of the derivation.<para/>
        /// For pointers, this returns the type pointed to. For arrays, this returns what the array is an array of. If the type is not such a derivative type, an error is returned.<para/>
        /// Note that this method has nothing to do with C++ (or other linguistic) base classes. Such are symbols (<see cref="IDebugHostBaseClass"/>) which can be enumerated from the derived class via a call to the EnumerateChildren method.
        /// </summary>
        /// <param name="baseTypeResult">The type that this type is derived from is returned here. This is the type pointed to, the type an array contains, etc...</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetBaseType(out DebugHostType baseTypeResult)
        {
            /*HRESULT GetBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType baseType);*/
            IDebugHostType baseType;
            HRESULT hr = Raw.GetBaseType(out baseType);

            if (hr == HRESULT.S_OK)
                baseTypeResult = baseType == null ? null : new DebugHostType(baseType);
            else
                baseTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region HashCode

        /// <summary>
        /// The GetHashCode method returns a 32-bit hash code for the type. With the exception of a global match (e.g.: a type signature equivalent to * which matches everything if permitted by the host), any type instance which can match a particular type signature must return the same hash code.<para/>
        /// This method is used in conjunction with type signatures in order to match type signatures to type instances.
        /// </summary>
        public int HashCode
        {
            get
            {
                int hashCode;
                TryGetHashCode(out hashCode).ThrowDbgEngNotOK();

                return hashCode;
            }
        }

        /// <summary>
        /// The GetHashCode method returns a 32-bit hash code for the type. With the exception of a global match (e.g.: a type signature equivalent to * which matches everything if permitted by the host), any type instance which can match a particular type signature must return the same hash code.<para/>
        /// This method is used in conjunction with type signatures in order to match type signatures to type instances.
        /// </summary>
        /// <param name="hashCode">A 32-bit hash code for the type instance. Every type which is capable of matching another type via a non-global match type signature will return the same hash code here.<para/>
        /// The debug host must guarantee such synchronization between its type signature methods and this method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetHashCode(out int hashCode)
        {
            /*HRESULT GetHashCode(
            [Out] out int hashCode);*/
            return Raw.GetHashCode(out hashCode);
        }

        #endregion
        #region IntrinsicType

        /// <summary>
        /// The GetIntrinsicType method returns information about what kind of intrinsic the type is. Two values are returned out of this method: The combination of the two values provides the full set of information about the intrinsic.
        /// </summary>
        public DebugHostType_GetIntrinsicTypeResult IntrinsicType
        {
            get
            {
                DebugHostType_GetIntrinsicTypeResult result;
                TryGetIntrinsicType(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetIntrinsicType method returns information about what kind of intrinsic the type is. Two values are returned out of this method: The combination of the two values provides the full set of information about the intrinsic.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetIntrinsicType(out DebugHostType_GetIntrinsicTypeResult result)
        {
            /*HRESULT GetIntrinsicType(
            [Out] out IntrinsicKind intrinsicKind,
            [Out] out VARENUM carrierType);*/
            IntrinsicKind intrinsicKind;
            VARENUM carrierType;
            HRESULT hr = Raw.GetIntrinsicType(out intrinsicKind, out carrierType);

            if (hr == HRESULT.S_OK)
                result = new DebugHostType_GetIntrinsicTypeResult(intrinsicKind, carrierType);
            else
                result = default(DebugHostType_GetIntrinsicTypeResult);

            return hr;
        }

        #endregion
        #region BitField

        /// <summary>
        /// If a given member of a data structure is a bitfield (e.g.: ULONG MyBits:8), the type information for the field carries with it information about the bitfield placement.<para/>
        /// The GetBitField method can be used to retrieve that information. This method will fail on any type which is not a bitfield.<para/>
        /// This is the only reason the method will fail. Simply calling this method and looking at success/failure is sufficient to distinguish a bit field from a non-bit field.<para/>
        /// If a given type does happen to be a bitfield, the field positions are defined by the half open set (lsbOfField + lengthOfField : lsbOfField]
        /// </summary>
        public GetBitFieldResult BitField
        {
            get
            {
                GetBitFieldResult result;
                TryGetBitField(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// If a given member of a data structure is a bitfield (e.g.: ULONG MyBits:8), the type information for the field carries with it information about the bitfield placement.<para/>
        /// The GetBitField method can be used to retrieve that information. This method will fail on any type which is not a bitfield.<para/>
        /// This is the only reason the method will fail. Simply calling this method and looking at success/failure is sufficient to distinguish a bit field from a non-bit field.<para/>
        /// If a given type does happen to be a bitfield, the field positions are defined by the half open set (lsbOfField + lengthOfField : lsbOfField]
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetBitField(out GetBitFieldResult result)
        {
            /*HRESULT GetBitField(
            [Out] out int lsbOfField,
            [Out] out int lengthOfField);*/
            int lsbOfField;
            int lengthOfField;
            HRESULT hr = Raw.GetBitField(out lsbOfField, out lengthOfField);

            if (hr == HRESULT.S_OK)
                result = new GetBitFieldResult(lsbOfField, lengthOfField);
            else
                result = default(GetBitFieldResult);

            return hr;
        }

        #endregion
        #region PointerKind

        /// <summary>
        /// For types which are pointers, the GetPointerKind method returns the kind of pointer. This is defined by the PointerKind enumeration and is one of the following values:
        /// </summary>
        public PointerKind PointerKind
        {
            get
            {
                PointerKind pointerKind;
                TryGetPointerKind(out pointerKind).ThrowDbgEngNotOK();

                return pointerKind;
            }
        }

        /// <summary>
        /// For types which are pointers, the GetPointerKind method returns the kind of pointer. This is defined by the PointerKind enumeration and is one of the following values:
        /// </summary>
        /// <param name="pointerKind">The kind of pointer will be returned here (as a value from the PointerKind enumeration.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetPointerKind(out PointerKind pointerKind)
        {
            /*HRESULT GetPointerKind(
            [Out] out PointerKind pointerKind);*/
            return Raw.GetPointerKind(out pointerKind);
        }

        #endregion
        #region MemberType

        /// <summary>
        /// For types which are pointer-to-member (as indicated by a type kind of TypeMemberPointer), the GetMemberType method returns the class the pointer is a pointer-to-member of.
        /// </summary>
        public DebugHostType MemberType
        {
            get
            {
                DebugHostType memberTypeResult;
                TryGetMemberType(out memberTypeResult).ThrowDbgEngNotOK();

                return memberTypeResult;
            }
        }

        /// <summary>
        /// For types which are pointer-to-member (as indicated by a type kind of TypeMemberPointer), the GetMemberType method returns the class the pointer is a pointer-to-member of.
        /// </summary>
        /// <param name="memberTypeResult">The class that the pointer is a pointer-to-member of will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetMemberType(out DebugHostType memberTypeResult)
        {
            /*HRESULT GetMemberType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType memberType);*/
            IDebugHostType memberType;
            HRESULT hr = Raw.GetMemberType(out memberType);

            if (hr == HRESULT.S_OK)
                memberTypeResult = memberType == null ? null : new DebugHostType(memberType);
            else
                memberTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region ArrayDimensionality

        /// <summary>
        /// The GetArrayDimensionality method returns the number of dimensions that the array is indexed in. For C style arrays, the value returned here will always be 1.
        /// </summary>
        public long ArrayDimensionality
        {
            get
            {
                long arrayDimensionality;
                TryGetArrayDimensionality(out arrayDimensionality).ThrowDbgEngNotOK();

                return arrayDimensionality;
            }
        }

        /// <summary>
        /// The GetArrayDimensionality method returns the number of dimensions that the array is indexed in. For C style arrays, the value returned here will always be 1.
        /// </summary>
        /// <param name="arrayDimensionality">The number of dimensions that the array is indexed in will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetArrayDimensionality(out long arrayDimensionality)
        {
            /*HRESULT GetArrayDimensionality(
            [Out] out long arrayDimensionality);*/
            return Raw.GetArrayDimensionality(out arrayDimensionality);
        }

        #endregion
        #region FunctionCallingConvention

        /// <summary>
        /// The GetFunctionCallingConvention method returns the calling convention of the function. Such is returned as a member of the CallingConventionKind enumeration.
        /// </summary>
        public CallingConventionKind FunctionCallingConvention
        {
            get
            {
                CallingConventionKind conventionKind;
                TryGetFunctionCallingConvention(out conventionKind).ThrowDbgEngNotOK();

                return conventionKind;
            }
        }

        /// <summary>
        /// The GetFunctionCallingConvention method returns the calling convention of the function. Such is returned as a member of the CallingConventionKind enumeration.
        /// </summary>
        /// <param name="conventionKind">The calling convention of the function is returned here as a member of the CallingConventionKind enumeration.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetFunctionCallingConvention(out CallingConventionKind conventionKind)
        {
            /*HRESULT GetFunctionCallingConvention(
            [Out] out CallingConventionKind conventionKind);*/
            return Raw.GetFunctionCallingConvention(out conventionKind);
        }

        #endregion
        #region FunctionReturnType

        /// <summary>
        /// The GetFunctionReturnType method returns the return type of the function.
        /// </summary>
        public DebugHostType FunctionReturnType
        {
            get
            {
                DebugHostType returnTypeResult;
                TryGetFunctionReturnType(out returnTypeResult).ThrowDbgEngNotOK();

                return returnTypeResult;
            }
        }

        /// <summary>
        /// The GetFunctionReturnType method returns the return type of the function.
        /// </summary>
        /// <param name="returnTypeResult">A type symbol indicating the return type of the function is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetFunctionReturnType(out DebugHostType returnTypeResult)
        {
            /*HRESULT GetFunctionReturnType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType returnType);*/
            IDebugHostType returnType;
            HRESULT hr = Raw.GetFunctionReturnType(out returnType);

            if (hr == HRESULT.S_OK)
                returnTypeResult = returnType == null ? null : new DebugHostType(returnType);
            else
                returnTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region FunctionParameterTypeCount

        /// <summary>
        /// The GetFunctionParameterTypeCount method returns the number of arguments that the function takes. Note that the C/C++ ellipsis based variable argument marker is not considered in this count.<para/>
        /// The presence of such must be detected via the GetFunctionVarArgsKind method. This will only include arguments before the ellipsis.
        /// </summary>
        public long FunctionParameterTypeCount
        {
            get
            {
                long count;
                TryGetFunctionParameterTypeCount(out count).ThrowDbgEngNotOK();

                return count;
            }
        }

        /// <summary>
        /// The GetFunctionParameterTypeCount method returns the number of arguments that the function takes. Note that the C/C++ ellipsis based variable argument marker is not considered in this count.<para/>
        /// The presence of such must be detected via the GetFunctionVarArgsKind method. This will only include arguments before the ellipsis.
        /// </summary>
        /// <param name="count">The number of arguments to the function (ignoring the variable argument ellipsis) will be returned here. The types of each individual argument may be acquired via the GetFunctionParameterTypeAt method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetFunctionParameterTypeCount(out long count)
        {
            /*HRESULT GetFunctionParameterTypeCount(
            [Out] out long count);*/
            return Raw.GetFunctionParameterTypeCount(out count);
        }

        #endregion
        #region IsGeneric

        /// <summary>
        /// Returns whether the type is a generic or template.
        /// </summary>
        public bool IsGeneric
        {
            get
            {
                bool isGeneric;
                TryIsGeneric(out isGeneric).ThrowDbgEngNotOK();

                return isGeneric;
            }
        }

        /// <summary>
        /// Returns whether the type is a generic or template.
        /// </summary>
        /// <param name="isGeneric">An indication of whether the type is a generic or template type is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryIsGeneric(out bool isGeneric)
        {
            /*HRESULT IsGeneric(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isGeneric);*/
            return Raw.IsGeneric(out isGeneric);
        }

        #endregion
        #region GenericArgumentCount

        /// <summary>
        /// Returns the number of arguments to the generic/template. The returned value must be greater than zero.
        /// </summary>
        public long GenericArgumentCount
        {
            get
            {
                long argCount;
                TryGetGenericArgumentCount(out argCount).ThrowDbgEngNotOK();

                return argCount;
            }
        }

        /// <summary>
        /// Returns the number of arguments to the generic/template. The returned value must be greater than zero.
        /// </summary>
        /// <param name="argCount">The number of generic arguments (e.g.: template arguments) to the type will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetGenericArgumentCount(out long argCount)
        {
            /*HRESULT GetGenericArgumentCount(
            [Out] out long argCount);*/
            return Raw.GetGenericArgumentCount(out argCount);
        }

        #endregion
        #region CreatePointerTo

        /// <summary>
        /// For any given type, this returns a new <see cref="IDebugHostType"/> which is a pointer to this type.The kind of pointer is supplied by the "kind" argument.
        /// </summary>
        /// <param name="kind">The kind of pointer to create (e.g.: a standard pointer, a C++ reference, a C++ rvalue reference, etc…)</param>
        /// <returns>The newly created pointer type will be returned here.</returns>
        public DebugHostType CreatePointerTo(PointerKind kind)
        {
            DebugHostType newTypeResult;
            TryCreatePointerTo(kind, out newTypeResult).ThrowDbgEngNotOK();

            return newTypeResult;
        }

        /// <summary>
        /// For any given type, this returns a new <see cref="IDebugHostType"/> which is a pointer to this type.The kind of pointer is supplied by the "kind" argument.
        /// </summary>
        /// <param name="kind">The kind of pointer to create (e.g.: a standard pointer, a C++ reference, a C++ rvalue reference, etc…)</param>
        /// <param name="newTypeResult">The newly created pointer type will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreatePointerTo(PointerKind kind, out DebugHostType newTypeResult)
        {
            /*HRESULT CreatePointerTo(
            [In] PointerKind kind,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType newType);*/
            IDebugHostType newType;
            HRESULT hr = Raw.CreatePointerTo(kind, out newType);

            if (hr == HRESULT.S_OK)
                newTypeResult = newType == null ? null : new DebugHostType(newType);
            else
                newTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region GetArrayDimensions

        /// <summary>
        /// The GetArrayDimensions method returns a set of descriptors, one for each dimension of the array as indicated by the GetArrayDimensionality method.<para/>
        /// Each descriptor is an ArrayDimension structure which describes the starting index, length, and forward stride of each array dimension.<para/>
        /// This allows descriptions of significantly more powerful array constructs than are allowed in the C type system.<para/>
        /// For C-style arrays, a single array dimension is returned here with values which are always:
        /// </summary>
        /// <param name="dimensions">Indicates the number of dimension descriptors to fetch. This must be the value acquired from a call to GetArrayDimensionality.A buffer of dimensions ArrayDimension structures which will be filled in to fully describe the layout of the array in memory.</param>
        /// <returns>A buffer of dimensions ArrayDimension structures which will be filled in to fully describe the layout of the array in memory.</returns>
        public ArrayDimension[] GetArrayDimensions(long dimensions)
        {
            ArrayDimension[] pDimensions;
            TryGetArrayDimensions(dimensions, out pDimensions).ThrowDbgEngNotOK();

            return pDimensions;
        }

        /// <summary>
        /// The GetArrayDimensions method returns a set of descriptors, one for each dimension of the array as indicated by the GetArrayDimensionality method.<para/>
        /// Each descriptor is an ArrayDimension structure which describes the starting index, length, and forward stride of each array dimension.<para/>
        /// This allows descriptions of significantly more powerful array constructs than are allowed in the C type system.<para/>
        /// For C-style arrays, a single array dimension is returned here with values which are always:
        /// </summary>
        /// <param name="dimensions">Indicates the number of dimension descriptors to fetch. This must be the value acquired from a call to GetArrayDimensionality.A buffer of dimensions ArrayDimension structures which will be filled in to fully describe the layout of the array in memory.</param>
        /// <param name="pDimensions">A buffer of dimensions ArrayDimension structures which will be filled in to fully describe the layout of the array in memory.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetArrayDimensions(long dimensions, out ArrayDimension[] pDimensions)
        {
            /*HRESULT GetArrayDimensions(
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ArrayDimension[] pDimensions);*/
            pDimensions = new ArrayDimension[(int) dimensions];
            HRESULT hr = Raw.GetArrayDimensions(dimensions, pDimensions);

            return hr;
        }

        #endregion
        #region CreateArrayOf

        /// <summary>
        /// For any given type, this returns a new <see cref="IDebugHostType"/> which is an array of this type.The dimensions of the array must be supplied via the "dimensions" and "pDimensions" arguments.
        /// </summary>
        /// <param name="dimensions">The number of dimensions of the array type to create.</param>
        /// <param name="pDimensions">A pointer to an array of ArrayDimension structures describing the structure of each dimension of the array type to create.</param>
        /// <returns>The newly created array type will be returned here.</returns>
        public DebugHostType CreateArrayOf(long dimensions, ArrayDimension[] pDimensions)
        {
            DebugHostType newTypeResult;
            TryCreateArrayOf(dimensions, pDimensions, out newTypeResult).ThrowDbgEngNotOK();

            return newTypeResult;
        }

        /// <summary>
        /// For any given type, this returns a new <see cref="IDebugHostType"/> which is an array of this type.The dimensions of the array must be supplied via the "dimensions" and "pDimensions" arguments.
        /// </summary>
        /// <param name="dimensions">The number of dimensions of the array type to create.</param>
        /// <param name="pDimensions">A pointer to an array of ArrayDimension structures describing the structure of each dimension of the array type to create.</param>
        /// <param name="newTypeResult">The newly created array type will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateArrayOf(long dimensions, ArrayDimension[] pDimensions, out DebugHostType newTypeResult)
        {
            /*HRESULT CreateArrayOf(
            [In] long dimensions,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ArrayDimension[] pDimensions,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType newType);*/
            IDebugHostType newType;
            HRESULT hr = Raw.CreateArrayOf(dimensions, pDimensions, out newType);

            if (hr == HRESULT.S_OK)
                newTypeResult = newType == null ? null : new DebugHostType(newType);
            else
                newTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region GetFunctionParameterTypeAt

        /// <summary>
        /// The GetFunctionParameterTypeAt method returns the type of the i-th argument to the function.
        /// </summary>
        /// <param name="i">A zero based index into the function argument list for which to retrieve the argument type.</param>
        /// <returns>The type of the i-th argument to the function will be returned here.</returns>
        public DebugHostType GetFunctionParameterTypeAt(long i)
        {
            DebugHostType parameterTypeResult;
            TryGetFunctionParameterTypeAt(i, out parameterTypeResult).ThrowDbgEngNotOK();

            return parameterTypeResult;
        }

        /// <summary>
        /// The GetFunctionParameterTypeAt method returns the type of the i-th argument to the function.
        /// </summary>
        /// <param name="i">A zero based index into the function argument list for which to retrieve the argument type.</param>
        /// <param name="parameterTypeResult">The type of the i-th argument to the function will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetFunctionParameterTypeAt(long i, out DebugHostType parameterTypeResult)
        {
            /*HRESULT GetFunctionParameterTypeAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType parameterType);*/
            IDebugHostType parameterType;
            HRESULT hr = Raw.GetFunctionParameterTypeAt(i, out parameterType);

            if (hr == HRESULT.S_OK)
                parameterTypeResult = parameterType == null ? null : new DebugHostType(parameterType);
            else
                parameterTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region GetGenericArgumentAt

        /// <summary>
        /// For the "i"-th generic argument to the generic/template, this returns a new <see cref="IDebugHostSymbol"/> which represents that argument.<para/>
        /// For templates, this is most often an <see cref="IDebugHostType"/>; however -- it may be an <see cref="IDebugHostConstant"/> for non-template type arguments.<para/>
        /// Note that it is possible for some compiler generated generics and templates that this method will fail.
        /// </summary>
        /// <param name="i">The zero based index of the generic argument to returned.</param>
        /// <returns>The i’th generic argument of the type will be returned here</returns>
        public DebugHostSymbol GetGenericArgumentAt(long i)
        {
            DebugHostSymbol argumentResult;
            TryGetGenericArgumentAt(i, out argumentResult).ThrowDbgEngNotOK();

            return argumentResult;
        }

        /// <summary>
        /// For the "i"-th generic argument to the generic/template, this returns a new <see cref="IDebugHostSymbol"/> which represents that argument.<para/>
        /// For templates, this is most often an <see cref="IDebugHostType"/>; however -- it may be an <see cref="IDebugHostConstant"/> for non-template type arguments.<para/>
        /// Note that it is possible for some compiler generated generics and templates that this method will fail.
        /// </summary>
        /// <param name="i">The zero based index of the generic argument to returned.</param>
        /// <param name="argumentResult">The i’th generic argument of the type will be returned here</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetGenericArgumentAt(long i, out DebugHostSymbol argumentResult)
        {
            /*HRESULT GetGenericArgumentAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol argument);*/
            IDebugHostSymbol argument;
            HRESULT hr = Raw.GetGenericArgumentAt(i, out argument);

            if (hr == HRESULT.S_OK)
                argumentResult = DebugHostSymbol.New(argument);
            else
                argumentResult = default(DebugHostSymbol);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostType2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public new IDebugHostType2 Raw2 => (IDebugHostType2) Raw;

        #region IsTypedef

        /// <summary>
        /// The IsTypedef method is the only method capable of seeing whether a type is a typedef. The GetTypeKind method will behave as if called on the underlying type.
        /// </summary>
        public bool IsTypedef
        {
            get
            {
                bool isTypedef;
                TryIsTypedef(out isTypedef).ThrowDbgEngNotOK();

                return isTypedef;
            }
        }

        /// <summary>
        /// The IsTypedef method is the only method capable of seeing whether a type is a typedef. The GetTypeKind method will behave as if called on the underlying type.
        /// </summary>
        /// <param name="isTypedef">Will return true if the type symbol is a typedef and false if it is not.</param>
        /// <returns>This method returns HRESULT.</returns>
        /// <remarks>
        /// Any type which is a typedef will behave as if the type is the final type underlying the typedef. This means that
        /// methods such as GetTypeKind will not indicate that the type is a typedef. Likewise, GetBaseType will not return
        /// the type the definition refers to. They will instead indicate behave as if they were called on the final definition
        /// underlying the typedef. As an example: An <see cref="IDebugHostType"/> for 'either PMYSTRUCT or PTRMYSTRUCT will
        /// report the following information: The only difference here is how the typedef specific methods on <see cref="IDebugHostType2"/>
        /// behave. Those methods are: In this example:
        /// </remarks>
        public HRESULT TryIsTypedef(out bool isTypedef)
        {
            /*HRESULT IsTypedef(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isTypedef);*/
            return Raw2.IsTypedef(out isTypedef);
        }

        #endregion
        #region TypedefBaseType

        /// <summary>
        /// The GetTypedefBaseType method will return what the immediate definition of the typedef. In this examples: this method will return MYSTRUCT * for PMYSTRUCT and PMYSTRUCT for PTRMYSTRUCT.<para/>
        /// For more information, see <see cref="IsTypedef"/>.
        /// </summary>
        public DebugHostType TypedefBaseType
        {
            get
            {
                DebugHostType baseTypeResult;
                TryGetTypedefBaseType(out baseTypeResult).ThrowDbgEngNotOK();

                return baseTypeResult;
            }
        }

        /// <summary>
        /// The GetTypedefBaseType method will return what the immediate definition of the typedef. In this examples: this method will return MYSTRUCT * for PMYSTRUCT and PMYSTRUCT for PTRMYSTRUCT.<para/>
        /// For more information, see <see cref="IsTypedef"/>.
        /// </summary>
        /// <param name="baseTypeResult">Returns the immediate (first level) type that the typedef is a definition for. If the typedef is a definition of another typedef, this will return that typedef and not the final unwind of the definition chain.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetTypedefBaseType(out DebugHostType baseTypeResult)
        {
            /*HRESULT GetTypedefBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType2 baseType);*/
            IDebugHostType2 baseType;
            HRESULT hr = Raw2.GetTypedefBaseType(out baseType);

            if (hr == HRESULT.S_OK)
                baseTypeResult = baseType == null ? null : new DebugHostType(baseType);
            else
                baseTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region TypedefFinalBaseType

        /// <summary>
        /// The GetTypedefFinalBaseType method will return the final type that the typedef is a definition for. If the typedef is a definition of another typedef, this will continue to follow the definition chain until it reaches a type which is not a typedef and that type will be returned.<para/>
        /// In this example: this method will return MYSTRUCT * when called on either PMYSTRUCT or PTRMYSTRUCT. For more information, see <see cref="IsTypedef"/>.
        /// </summary>
        public DebugHostType TypedefFinalBaseType
        {
            get
            {
                DebugHostType finalBaseTypeResult;
                TryGetTypedefFinalBaseType(out finalBaseTypeResult).ThrowDbgEngNotOK();

                return finalBaseTypeResult;
            }
        }

        /// <summary>
        /// The GetTypedefFinalBaseType method will return the final type that the typedef is a definition for. If the typedef is a definition of another typedef, this will continue to follow the definition chain until it reaches a type which is not a typedef and that type will be returned.<para/>
        /// In this example: this method will return MYSTRUCT * when called on either PMYSTRUCT or PTRMYSTRUCT. For more information, see <see cref="IsTypedef"/>.
        /// </summary>
        /// <param name="finalBaseTypeResult">Returns the final type that the typedef is a definition for. If the typedef is a definition of another typedef, this will continue to follow the definition chain until it reaches a type which is not a typedef.<para/>
        /// Such type will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetTypedefFinalBaseType(out DebugHostType finalBaseTypeResult)
        {
            /*HRESULT GetTypedefFinalBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType2 finalBaseType);*/
            IDebugHostType2 finalBaseType;
            HRESULT hr = Raw2.GetTypedefFinalBaseType(out finalBaseType);

            if (hr == HRESULT.S_OK)
                finalBaseTypeResult = finalBaseType == null ? null : new DebugHostType(finalBaseType);
            else
                finalBaseTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region FunctionVarArgsKind

        /// <summary>
        /// The GetFunctionVarArgsKind method returns whether a given function utilizes a variable argument list, and if so, what style of variable arguments it utilizes.<para/>
        /// Such is defined by a member of the VarArgsKind enumeration defined as follows:
        /// </summary>
        public VarArgsKind FunctionVarArgsKind
        {
            get
            {
                VarArgsKind varArgsKind;
                TryGetFunctionVarArgsKind(out varArgsKind).ThrowDbgEngNotOK();

                return varArgsKind;
            }
        }

        /// <summary>
        /// The GetFunctionVarArgsKind method returns whether a given function utilizes a variable argument list, and if so, what style of variable arguments it utilizes.<para/>
        /// Such is defined by a member of the VarArgsKind enumeration defined as follows:
        /// </summary>
        /// <param name="varArgsKind">A value of the VarArgsKind enumeration indicating whether the function is a varargs function and, if so, what style of variable arguments it utilizes.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. This method will not fail on a non varargs function.</returns>
        public HRESULT TryGetFunctionVarArgsKind(out VarArgsKind varArgsKind)
        {
            /*HRESULT GetFunctionVarArgsKind(
            [Out] out VarArgsKind varArgsKind);*/
            return Raw2.GetFunctionVarArgsKind(out varArgsKind);
        }

        #endregion
        #region FunctionInstancePointerType

        /// <summary>
        /// Indicates what the type of the instance ("this") pointer passed to the function is. This method will failif the function is not an instance method on a class.
        /// </summary>
        public DebugHostType FunctionInstancePointerType
        {
            get
            {
                DebugHostType instancePointerTypeResult;
                TryGetFunctionInstancePointerType(out instancePointerTypeResult).ThrowDbgEngNotOK();

                return instancePointerTypeResult;
            }
        }

        /// <summary>
        /// Indicates what the type of the instance ("this") pointer passed to the function is. This method will failif the function is not an instance method on a class.
        /// </summary>
        /// <param name="instancePointerTypeResult">The instance pointer type.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetFunctionInstancePointerType(out DebugHostType instancePointerTypeResult)
        {
            /*HRESULT GetFunctionInstancePointerType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType2 instancePointerType);*/
            IDebugHostType2 instancePointerType;
            HRESULT hr = Raw2.GetFunctionInstancePointerType(out instancePointerType);

            if (hr == HRESULT.S_OK)
                instancePointerTypeResult = instancePointerType == null ? null : new DebugHostType(instancePointerType);
            else
                instancePointerTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostType3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public new IDebugHostType3 Raw3 => (IDebugHostType3) Raw;

        #region ContainingType

        public DebugHostType ContainingType
        {
            get
            {
                DebugHostType containingParentTypeResult;
                TryGetContainingType(out containingParentTypeResult).ThrowDbgEngNotOK();

                return containingParentTypeResult;
            }
        }

        public HRESULT TryGetContainingType(out DebugHostType containingParentTypeResult)
        {
            /*HRESULT GetContainingType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType3 containingParentType);*/
            IDebugHostType3 containingParentType;
            HRESULT hr = Raw3.GetContainingType(out containingParentType);

            if (hr == HRESULT.S_OK)
                containingParentTypeResult = containingParentType == null ? null : new DebugHostType(containingParentType);
            else
                containingParentTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostType4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostType4 Raw4 => (IDebugHostType4) Raw;

        #region ExtendedArrayHeaderSize

        public long ExtendedArrayHeaderSize
        {
            get
            {
                long headerSize;
                TryGetExtendedArrayHeaderSize(out headerSize).ThrowDbgEngNotOK();

                return headerSize;
            }
        }

        public HRESULT TryGetExtendedArrayHeaderSize(out long headerSize)
        {
            /*HRESULT GetExtendedArrayHeaderSize(
            [Out] out long headerSize);*/
            return Raw4.GetExtendedArrayHeaderSize(out headerSize);
        }

        #endregion
        #region UDTKind

        public UDTKind UDTKind
        {
            get
            {
                UDTKind udtKind;
                TryGetUDTKind(out udtKind).ThrowDbgEngNotOK();

                return udtKind;
            }
        }

        public HRESULT TryGetUDTKind(out UDTKind udtKind)
        {
            /*HRESULT GetUDTKind(
            [Out] out UDTKind udtKind);*/
            return Raw4.GetUDTKind(out udtKind);
        }

        #endregion
        #region GetExtendedArrayDimensions

        public ExtendedArrayDimension[] GetExtendedArrayDimensions(long dimensions)
        {
            ExtendedArrayDimension[] pDimensions;
            TryGetExtendedArrayDimensions(dimensions, out pDimensions).ThrowDbgEngNotOK();

            return pDimensions;
        }

        public HRESULT TryGetExtendedArrayDimensions(long dimensions, out ExtendedArrayDimension[] pDimensions)
        {
            /*HRESULT GetExtendedArrayDimensions(
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ExtendedArrayDimension[] pDimensions);*/
            pDimensions = new ExtendedArrayDimension[(int) dimensions];
            HRESULT hr = Raw4.GetExtendedArrayDimensions(dimensions, pDimensions);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostType5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostType5 Raw5 => (IDebugHostType5) Raw;

        #region IsBaseTypeOf

        public bool IsBaseTypeOf(IDebugHostType pOtherType)
        {
            bool pIsBase;
            TryIsBaseTypeOf(pOtherType, out pIsBase).ThrowDbgEngNotOK();

            return pIsBase;
        }

        public HRESULT TryIsBaseTypeOf(IDebugHostType pOtherType, out bool pIsBase)
        {
            /*HRESULT IsBaseTypeOf(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType pOtherType,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsBase);*/
            return Raw5.IsBaseTypeOf(pOtherType, out pIsBase);
        }

        #endregion
        #endregion
        #region IDebugHostType6

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostType6 Raw6 => (IDebugHostType6) Raw;

        #region TaggedUnionTag

        public GetTaggedUnionTagResult TaggedUnionTag
        {
            get
            {
                GetTaggedUnionTagResult result;
                TryGetTaggedUnionTag(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetTaggedUnionTag(out GetTaggedUnionTagResult result)
        {
            /*HRESULT GetTaggedUnionTag(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType pTagType,
            [Out] out int pTagOffset,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pTagMask);*/
            IDebugHostType pTagType;
            int pTagOffset;
            object pTagMask;
            HRESULT hr = Raw6.GetTaggedUnionTag(out pTagType, out pTagOffset, out pTagMask);

            if (hr == HRESULT.S_OK)
                result = new GetTaggedUnionTagResult(pTagType == null ? null : new DebugHostType(pTagType), pTagOffset, pTagMask);
            else
                result = default(GetTaggedUnionTagResult);

            return hr;
        }

        #endregion
        #region TaggedUnionTagRanges

        public DebugHostTaggedUnionRangeEnumerator TaggedUnionTagRanges
        {
            get
            {
                DebugHostTaggedUnionRangeEnumerator pTagRangeEnumeratorResult;
                TryGetTaggedUnionTagRanges(out pTagRangeEnumeratorResult).ThrowDbgEngNotOK();

                return pTagRangeEnumeratorResult;
            }
        }

        public HRESULT TryGetTaggedUnionTagRanges(out DebugHostTaggedUnionRangeEnumerator pTagRangeEnumeratorResult)
        {
            /*HRESULT GetTaggedUnionTagRanges(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTaggedUnionRangeEnumerator pTagRangeEnumerator);*/
            IDebugHostTaggedUnionRangeEnumerator pTagRangeEnumerator;
            HRESULT hr = Raw6.GetTaggedUnionTagRanges(out pTagRangeEnumerator);

            if (hr == HRESULT.S_OK)
                pTagRangeEnumeratorResult = pTagRangeEnumerator == null ? null : new DebugHostTaggedUnionRangeEnumerator(pTagRangeEnumerator);
            else
                pTagRangeEnumeratorResult = default(DebugHostTaggedUnionRangeEnumerator);

            return hr;
        }

        #endregion
        #region UpcastToTaggedUnionType

        public DebugHostType UpcastToTaggedUnionType(IDebugHostType pTaggedUnionType)
        {
            DebugHostType pUpcastedCaseTypeResult;
            TryUpcastToTaggedUnionType(pTaggedUnionType, out pUpcastedCaseTypeResult).ThrowDbgEngNotOK();

            return pUpcastedCaseTypeResult;
        }

        public HRESULT TryUpcastToTaggedUnionType(IDebugHostType pTaggedUnionType, out DebugHostType pUpcastedCaseTypeResult)
        {
            /*HRESULT UpcastToTaggedUnionType(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType pTaggedUnionType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType pUpcastedCaseType);*/
            IDebugHostType pUpcastedCaseType;
            HRESULT hr = Raw6.UpcastToTaggedUnionType(pTaggedUnionType, out pUpcastedCaseType);

            if (hr == HRESULT.S_OK)
                pUpcastedCaseTypeResult = pUpcastedCaseType == null ? null : new DebugHostType(pUpcastedCaseType);
            else
                pUpcastedCaseTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #endregion
    }
}
