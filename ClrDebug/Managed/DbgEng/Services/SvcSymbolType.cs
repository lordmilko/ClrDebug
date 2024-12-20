namespace ClrDebug.DbgEng
{
    public class SvcSymbolType : ComObject<ISvcSymbolType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolType"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolType(ISvcSymbolType raw) : base(raw)
        {
        }

        #region ISvcSymbolType
        #region TypeKind

        /// <summary>
        /// Gets the kind of type symbol that this is (e.g.: base type, struct, array, etc...).
        /// </summary>
        public SvcSymbolTypeKind TypeKind
        {
            get
            {
                SvcSymbolTypeKind kind;
                TryGetTypeKind(out kind).ThrowDbgEngNotOK();

                return kind;
            }
        }

        /// <summary>
        /// Gets the kind of type symbol that this is (e.g.: base type, struct, array, etc...).
        /// </summary>
        public HRESULT TryGetTypeKind(out SvcSymbolTypeKind kind)
        {
            /*HRESULT GetTypeKind(
            [Out] out SvcSymbolTypeKind kind);*/
            return Raw.GetTypeKind(out kind);
        }

        #endregion
        #region Size

        /// <summary>
        /// Gets the overall size of the type as laid out in memory.
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
        /// Gets the overall size of the type as laid out in memory.
        /// </summary>
        public HRESULT TryGetSize(out long size)
        {
            /*HRESULT GetSize(
            [Out] out long size);*/
            return Raw.GetSize(out size);
        }

        #endregion
        #region BaseType

        /// <summary>
        /// If the type is a derivation of another single type (e.g.: as "MyStruct *" is derived from "MyStruct"), this returns the base type of the derivation.<para/>
        /// For pointers, this would return the type pointed to. For arrays, this would return what the array is an array of.<para/>
        /// If the type is not such a derivative type, an error is returned. Note that this method has nothing to do with C++ base classes.<para/>
        /// Such are symbols which can be enumerated from the derived class.
        /// </summary>
        public SvcSymbol BaseType
        {
            get
            {
                SvcSymbol baseTypeResult;
                TryGetBaseType(out baseTypeResult).ThrowDbgEngNotOK();

                return baseTypeResult;
            }
        }

        /// <summary>
        /// If the type is a derivation of another single type (e.g.: as "MyStruct *" is derived from "MyStruct"), this returns the base type of the derivation.<para/>
        /// For pointers, this would return the type pointed to. For arrays, this would return what the array is an array of.<para/>
        /// If the type is not such a derivative type, an error is returned. Note that this method has nothing to do with C++ base classes.<para/>
        /// Such are symbols which can be enumerated from the derived class.
        /// </summary>
        public HRESULT TryGetBaseType(out SvcSymbol baseTypeResult)
        {
            /*HRESULT GetBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol baseType);*/
            ISvcSymbol baseType;
            HRESULT hr = Raw.GetBaseType(out baseType);

            if (hr == HRESULT.S_OK)
                baseTypeResult = baseType == null ? null : new SvcSymbol(baseType);
            else
                baseTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region UnmodifiedType

        /// <summary>
        /// If the type is a qualified form (const/volatile/etc...) of another type, this returns a type symbol with all qualifiers stripped.
        /// </summary>
        public SvcSymbol UnmodifiedType
        {
            get
            {
                SvcSymbol unmodifiedTypeResult;
                TryGetUnmodifiedType(out unmodifiedTypeResult).ThrowDbgEngNotOK();

                return unmodifiedTypeResult;
            }
        }

        /// <summary>
        /// If the type is a qualified form (const/volatile/etc...) of another type, this returns a type symbol with all qualifiers stripped.
        /// </summary>
        public HRESULT TryGetUnmodifiedType(out SvcSymbol unmodifiedTypeResult)
        {
            /*HRESULT GetUnmodifiedType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol unmodifiedType);*/
            ISvcSymbol unmodifiedType;
            HRESULT hr = Raw.GetUnmodifiedType(out unmodifiedType);

            if (hr == HRESULT.S_OK)
                unmodifiedTypeResult = unmodifiedType == null ? null : new SvcSymbol(unmodifiedType);
            else
                unmodifiedTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region IntrinsicType

        /// <summary>
        /// If the type kind as reported by GetTypeKind is an intrinsic, this returns more information about the particular kind of intrinsic.
        /// </summary>
        public SvcSymbolType_GetIntrinsicTypeResult IntrinsicType
        {
            get
            {
                SvcSymbolType_GetIntrinsicTypeResult result;
                TryGetIntrinsicType(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// If the type kind as reported by GetTypeKind is an intrinsic, this returns more information about the particular kind of intrinsic.
        /// </summary>
        public HRESULT TryGetIntrinsicType(out SvcSymbolType_GetIntrinsicTypeResult result)
        {
            /*HRESULT GetIntrinsicType(
            [Out] out SvcSymbolIntrinsicKind kind,
            [Out] out int packingSize);*/
            SvcSymbolIntrinsicKind kind;
            int packingSize;
            HRESULT hr = Raw.GetIntrinsicType(out kind, out packingSize);

            if (hr == HRESULT.S_OK)
                result = new SvcSymbolType_GetIntrinsicTypeResult(kind, packingSize);
            else
                result = default(SvcSymbolType_GetIntrinsicTypeResult);

            return hr;
        }

        #endregion
        #region PointerKind

        /// <summary>
        /// Returns what kind of pointer the type is (e.g.: a standard pointer, a pointer to member, a reference, an r-value reference, etc...
        /// </summary>
        public SvcSymbolPointerKind PointerKind
        {
            get
            {
                SvcSymbolPointerKind kind;
                TryGetPointerKind(out kind).ThrowDbgEngNotOK();

                return kind;
            }
        }

        /// <summary>
        /// Returns what kind of pointer the type is (e.g.: a standard pointer, a pointer to member, a reference, an r-value reference, etc...
        /// </summary>
        public HRESULT TryGetPointerKind(out SvcSymbolPointerKind kind)
        {
            /*HRESULT GetPointerKind(
            [Out] out SvcSymbolPointerKind kind);*/
            return Raw.GetPointerKind(out kind);
        }

        #endregion
        #region MemberType

        /// <summary>
        /// If the pointer is a pointer-to-class-member, this returns the type of such class.
        /// </summary>
        public SvcSymbolType MemberType
        {
            get
            {
                SvcSymbolType memberTypeResult;
                TryGetMemberType(out memberTypeResult).ThrowDbgEngNotOK();

                return memberTypeResult;
            }
        }

        /// <summary>
        /// If the pointer is a pointer-to-class-member, this returns the type of such class.
        /// </summary>
        public HRESULT TryGetMemberType(out SvcSymbolType memberTypeResult)
        {
            /*HRESULT GetMemberType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolType memberType);*/
            ISvcSymbolType memberType;
            HRESULT hr = Raw.GetMemberType(out memberType);

            if (hr == HRESULT.S_OK)
                memberTypeResult = memberType == null ? null : new SvcSymbolType(memberType);
            else
                memberTypeResult = default(SvcSymbolType);

            return hr;
        }

        #endregion
        #region ArrayDimensionality

        /// <summary>
        /// Returns the dimensionality of the array. There is no guarantee that every array type representable by these interfaces is a standard zero-based one dimensional array as is standard in C.
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
        /// Returns the dimensionality of the array. There is no guarantee that every array type representable by these interfaces is a standard zero-based one dimensional array as is standard in C.
        /// </summary>
        public HRESULT TryGetArrayDimensionality(out long arrayDimensionality)
        {
            /*HRESULT GetArrayDimensionality(
            [Out] out long arrayDimensionality);*/
            return Raw.GetArrayDimensionality(out arrayDimensionality);
        }

        #endregion
        #region ArrayHeaderSize

        /// <summary>
        /// Gets the size of any header of the array (this is the offset of the first element of the array as described by the dimensions).<para/>
        /// This should *ALWAYS* return 0 for a C style array.
        /// </summary>
        public long ArrayHeaderSize
        {
            get
            {
                long arrayHeaderSize;
                TryGetArrayHeaderSize(out arrayHeaderSize).ThrowDbgEngNotOK();

                return arrayHeaderSize;
            }
        }

        /// <summary>
        /// Gets the size of any header of the array (this is the offset of the first element of the array as described by the dimensions).<para/>
        /// This should *ALWAYS* return 0 for a C style array.
        /// </summary>
        public HRESULT TryGetArrayHeaderSize(out long arrayHeaderSize)
        {
            /*HRESULT GetArrayHeaderSize(
            [Out] out long arrayHeaderSize);*/
            return Raw.GetArrayHeaderSize(out arrayHeaderSize);
        }

        #endregion
        #region FunctionReturnType

        /// <summary>
        /// Returns the return type of a function. Even non-value returning functions (e.g.: void) should return a type representing this.
        /// </summary>
        public SvcSymbol FunctionReturnType
        {
            get
            {
                SvcSymbol returnTypeResult;
                TryGetFunctionReturnType(out returnTypeResult).ThrowDbgEngNotOK();

                return returnTypeResult;
            }
        }

        /// <summary>
        /// Returns the return type of a function. Even non-value returning functions (e.g.: void) should return a type representing this.
        /// </summary>
        public HRESULT TryGetFunctionReturnType(out SvcSymbol returnTypeResult)
        {
            /*HRESULT GetFunctionReturnType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol returnType);*/
            ISvcSymbol returnType;
            HRESULT hr = Raw.GetFunctionReturnType(out returnType);

            if (hr == HRESULT.S_OK)
                returnTypeResult = returnType == null ? null : new SvcSymbol(returnType);
            else
                returnTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region FunctionParameterTypeCount

        /// <summary>
        /// Returns the number of parameters that the function takes.
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
        /// Returns the number of parameters that the function takes.
        /// </summary>
        public HRESULT TryGetFunctionParameterTypeCount(out long count)
        {
            /*HRESULT GetFunctionParameterTypeCount(
            [Out] out long count);*/
            return Raw.GetFunctionParameterTypeCount(out count);
        }

        #endregion
        #region GetArrayDimensions

        /// <summary>
        /// Fills in information about each dimension of the array including its lower bound, length, and stride.
        /// </summary>
        public SvcSymbolArrayDimension[] GetArrayDimensions(long dimensions)
        {
            SvcSymbolArrayDimension[] pDimensions;
            TryGetArrayDimensions(dimensions, out pDimensions).ThrowDbgEngNotOK();

            return pDimensions;
        }

        /// <summary>
        /// Fills in information about each dimension of the array including its lower bound, length, and stride.
        /// </summary>
        public HRESULT TryGetArrayDimensions(long dimensions, out SvcSymbolArrayDimension[] pDimensions)
        {
            /*HRESULT GetArrayDimensions(
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SvcSymbolArrayDimension[] pDimensions);*/
            pDimensions = new SvcSymbolArrayDimension[(int) dimensions];
            HRESULT hr = Raw.GetArrayDimensions(dimensions, pDimensions);

            return hr;
        }

        #endregion
        #region GetFunctionParameterTypeAt

        /// <summary>
        /// Returns the type of the "i"-th argument to the function as a new ISvcSymbol.
        /// </summary>
        public SvcSymbol GetFunctionParameterTypeAt(long i)
        {
            SvcSymbol parameterTypeResult;
            TryGetFunctionParameterTypeAt(i, out parameterTypeResult).ThrowDbgEngNotOK();

            return parameterTypeResult;
        }

        /// <summary>
        /// Returns the type of the "i"-th argument to the function as a new ISvcSymbol.
        /// </summary>
        public HRESULT TryGetFunctionParameterTypeAt(long i, out SvcSymbol parameterTypeResult)
        {
            /*HRESULT GetFunctionParameterTypeAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol parameterType);*/
            ISvcSymbol parameterType;
            HRESULT hr = Raw.GetFunctionParameterTypeAt(i, out parameterType);

            if (hr == HRESULT.S_OK)
                parameterTypeResult = parameterType == null ? null : new SvcSymbol(parameterType);
            else
                parameterTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #endregion
    }
}
