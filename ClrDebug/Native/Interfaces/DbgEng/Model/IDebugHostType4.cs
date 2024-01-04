using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("77D3CDC6-BD55-42BF-A4FD-D9AA60E3C1E1")]
    [ComImport]
    public interface IDebugHostType4 : IDebugHostType3
    {
        /// <summary>
        /// The GetContext method returns the context where the symbol is valid. While this will represent things such as the debug target and process/address space in which the symbol exists, it may not be as specific as a context retrieved from other means (e.g.: from an <see cref="IModelObject"/>).
        /// </summary>
        /// <param name="context">The host context in which the symbol is located will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);

        /// <summary>
        /// The EnumerateChildren method returns an enumerator which will enumerate all children of a given symbol. For a C++ type, for example, the base classes, fields, member functions, and the like are all considered children of the type symbol.
        /// </summary>
        /// <param name="kind">Indicates what kinds of child symbols the caller wishes to enumerate. If the flat value Symbol is passed, all kinds of child symbols will be enumerated.</param>
        /// <param name="name">If specified, only child symbols with a name as given in this argument will be enumerated.</param>
        /// <param name="ppEnum">An enumerator which enumerates child symbols of the specified kind and name will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT EnumerateChildren(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator ppEnum);

        /// <summary>
        /// Gets the kind of symbol that this is (e.g.: a field, a base class, a type, etc...).
        /// </summary>
        /// <param name="kind">The kind of symbol (e.g.: a type, field, base class, etc…) will be returned here. For more information, see <see cref="SymbolKind"/>.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetSymbolKind(
            [Out] out SymbolKind kind);

        /// <summary>
        /// Returns the name of the symbol if the symbol has a name. If the symbol does not have a name, an error is returned.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolName);

        /// <summary>
        /// Returns the type (e.g.: "int *") of the symbol if the symbol has a type. If the symbol does not have a type, an error is returned.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);

        /// <summary>
        /// Returns the module which contains this symbol if the symbol has a containing module. If the symbol does not have a containing module, an error is returned.
        /// </summary>
        /// <param name="containingModule">The module which contains the symbol will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetContainingModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule containingModule);

        /// <summary>
        /// The GetTypeKind method returns what kind of type (pointer, array, intrinsic, etc...) the symbol refers to. See the <see cref="TypeKind"/> for more information.
        /// </summary>
        /// <param name="kind">The kind of type the symbol refers to will be returned here (as a member of the TypeKind enumeration).</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetTypeKind(
            [Out] out TypeKind kind);

        /// <summary>
        /// The GetSize method returns the size of the type (as if one had done sizeof(type) in C++).
        /// </summary>
        /// <param name="size">The size of the type will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetSize(
            [Out] out long size);

        /// <summary>
        /// If the type is a derivative of another single type (e.g.: as MyStruct * is derived from MyStruct'), the GetBaseType method returns the base type of the derivation.<para/>
        /// For pointers, this returns the type pointed to. For arrays, this returns what the array is an array of. If the type is not such a derivative type, an error is returned.<para/>
        /// Note that this method has nothing to do with C++ (or other linguistic) base classes. Such are symbols (<see cref="IDebugHostBaseClass"/>) which can be enumerated from the derived class via a call to the EnumerateChildren method.
        /// </summary>
        /// <param name="baseType">The type that this type is derived from is returned here. This is the type pointed to, the type an array contains, etc...</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType baseType);

        /// <summary>
        /// The GetHashCode method returns a 32-bit hash code for the type. With the exception of a global match (e.g.: a type signature equivalent to * which matches everything if permitted by the host), any type instance which can match a particular type signature must return the same hash code.<para/>
        /// This method is used in conjunction with type signatures in order to match type signatures to type instances.
        /// </summary>
        /// <param name="hashCode">A 32-bit hash code for the type instance. Every type which is capable of matching another type via a non-global match type signature will return the same hash code here.<para/>
        /// The debug host must guarantee such synchronization between its type signature methods and this method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetHashCode(
            [Out] out int hashCode);

        /// <summary>
        /// The GetIntrinsicType method returns information about what kind of intrinsic the type is. Two values are returned out of this method: The combination of the two values provides the full set of information about the intrinsic.
        /// </summary>
        /// <param name="intrinsicKind">The kind of intrinsic will be returned here. This will indicate the overall type of the intrinsic -- whether it is an integer, unsigned, floating point, etc...<para/>
        /// It will not indicate the size of the intrinsic. 8, 16, 32, and 64 bit integers will be reported as signed integers -- nothing more.</param>
        /// <param name="carrierType">A VT_* constant indicating how the intrinsic will pack into a VARIANT structure is returned here. This, combined with the value returned in the intrinsicKind argument gives the full information necessary to understand the nature of the intrinsic.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetIntrinsicType(
            [Out] out IntrinsicKind intrinsicKind,
            [Out] out VARENUM carrierType);

        /// <summary>
        /// If a given member of a data structure is a bitfield (e.g.: ULONG MyBits:8), the type information for the field carries with it information about the bitfield placement.<para/>
        /// The GetBitField method can be used to retrieve that information. This method will fail on any type which is not a bitfield.<para/>
        /// This is the only reason the method will fail. Simply calling this method and looking at success/failure is sufficient to distinguish a bit field from a non-bit field.<para/>
        /// If a given type does happen to be a bitfield, the field positions are defined by the half open set (lsbOfField + lengthOfField : lsbOfField]
        /// </summary>
        /// <param name="lsbOfField">Indicates the least significant bit of the field (where 0 is defined to be the least significant bit of the containing type).<para/>
        /// The bit field is defined to utilize bits from this point towards the most significant bit of the containing type according to the length specified by the lengthOfField argument.</param>
        /// <param name="lengthOfField">The number of bits in the field. This will be at least one and no more than the number of bits in the containing type.<para/>
        /// The bit field occupies from the bit specified in the lsbOfField argument upwards towards the most significant bit of the containing value according to the number of bits returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetBitField(
            [Out] out int lsbOfField,
            [Out] out int lengthOfField);

        /// <summary>
        /// For types which are pointers, the GetPointerKind method returns the kind of pointer. This is defined by the PointerKind enumeration and is one of the following values:
        /// </summary>
        /// <param name="pointerKind">The kind of pointer will be returned here (as a value from the PointerKind enumeration.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetPointerKind(
            [Out] out PointerKind pointerKind);

        /// <summary>
        /// For types which are pointer-to-member (as indicated by a type kind of TypeMemberPointer), the GetMemberType method returns the class the pointer is a pointer-to-member of.
        /// </summary>
        /// <param name="memberType">The class that the pointer is a pointer-to-member of will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetMemberType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType memberType);

        /// <summary>
        /// For any given type, this returns a new <see cref="IDebugHostType"/> which is a pointer to this type.The kind of pointer is supplied by the "kind" argument.
        /// </summary>
        /// <param name="kind">The kind of pointer to create (e.g.: a standard pointer, a C++ reference, a C++ rvalue reference, etc…)</param>
        /// <param name="newType">The newly created pointer type will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT CreatePointerTo(
            [In] PointerKind kind,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType newType);

        /// <summary>
        /// The GetArrayDimensionality method returns the number of dimensions that the array is indexed in. For C style arrays, the value returned here will always be 1.
        /// </summary>
        /// <param name="arrayDimensionality">The number of dimensions that the array is indexed in will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetArrayDimensionality(
            [Out] out long arrayDimensionality);

        /// <summary>
        /// The GetArrayDimensions method returns a set of descriptors, one for each dimension of the array as indicated by the GetArrayDimensionality method.<para/>
        /// Each descriptor is an ArrayDimension structure which describes the starting index, length, and forward stride of each array dimension.<para/>
        /// This allows descriptions of significantly more powerful array constructs than are allowed in the C type system.<para/>
        /// For C-style arrays, a single array dimension is returned here with values which are always:
        /// </summary>
        /// <param name="dimensions">Indicates the number of dimension descriptors to fetch. This must be the value acquired from a call to GetArrayDimensionality.A buffer of dimensions ArrayDimension structures which will be filled in to fully describe the layout of the array in memory.</param>
        /// <param name="pDimensions">A buffer of dimensions ArrayDimension structures which will be filled in to fully describe the layout of the array in memory.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetArrayDimensions(
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ArrayDimension[] pDimensions);

        /// <summary>
        /// For any given type, this returns a new <see cref="IDebugHostType"/> which is an array of this type.The dimensions of the array must be supplied via the "dimensions" and "pDimensions" arguments.
        /// </summary>
        /// <param name="dimensions">The number of dimensions of the array type to create.</param>
        /// <param name="pDimensions">A pointer to an array of ArrayDimension structures describing the structure of each dimension of the array type to create.</param>
        /// <param name="newType">The newly created array type will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT CreateArrayOf(
            [In] long dimensions,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ArrayDimension[] pDimensions,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType newType);

        /// <summary>
        /// The GetFunctionCallingConvention method returns the calling convention of the function. Such is returned as a member of the CallingConventionKind enumeration.
        /// </summary>
        /// <param name="conventionKind">The calling convention of the function is returned here as a member of the CallingConventionKind enumeration.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetFunctionCallingConvention(
            [Out] out CallingConventionKind conventionKind);

        /// <summary>
        /// The GetFunctionReturnType method returns the return type of the function.
        /// </summary>
        /// <param name="returnType">A type symbol indicating the return type of the function is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetFunctionReturnType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType returnType);

        /// <summary>
        /// The GetFunctionParameterTypeCount method returns the number of arguments that the function takes. Note that the C/C++ ellipsis based variable argument marker is not considered in this count.<para/>
        /// The presence of such must be detected via the GetFunctionVarArgsKind method. This will only include arguments before the ellipsis.
        /// </summary>
        /// <param name="count">The number of arguments to the function (ignoring the variable argument ellipsis) will be returned here. The types of each individual argument may be acquired via the GetFunctionParameterTypeAt method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetFunctionParameterTypeCount(
            [Out] out long count);

        /// <summary>
        /// The GetFunctionParameterTypeAt method returns the type of the i-th argument to the function.
        /// </summary>
        /// <param name="i">A zero based index into the function argument list for which to retrieve the argument type.</param>
        /// <param name="parameterType">The type of the i-th argument to the function will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetFunctionParameterTypeAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType parameterType);

        /// <summary>
        /// Returns whether the type is a generic or template.
        /// </summary>
        /// <param name="isGeneric">An indication of whether the type is a generic or template type is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT IsGeneric(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isGeneric);

        /// <summary>
        /// Returns the number of arguments to the generic/template. The returned value must be greater than zero.
        /// </summary>
        /// <param name="argCount">The number of generic arguments (e.g.: template arguments) to the type will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetGenericArgumentCount(
            [Out] out long argCount);

        /// <summary>
        /// For the "i"-th generic argument to the generic/template, this returns a new <see cref="IDebugHostSymbol"/> which represents that argument.<para/>
        /// For templates, this is most often an <see cref="IDebugHostType"/>; however -- it may be an <see cref="IDebugHostConstant"/> for non-template type arguments.<para/>
        /// Note that it is possible for some compiler generated generics and templates that this method will fail.
        /// </summary>
        /// <param name="i">The zero based index of the generic argument to returned.</param>
        /// <param name="argument">The i’th generic argument of the type will be returned here</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetGenericArgumentAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol argument);

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
        [PreserveSig]
        new HRESULT IsTypedef(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isTypedef);

        /// <summary>
        /// The GetTypedefBaseType method will return what the immediate definition of the typedef. In this examples: this method will return MYSTRUCT * for PMYSTRUCT and PMYSTRUCT for PTRMYSTRUCT.<para/>
        /// For more information, see <see cref="IsTypedef"/>.
        /// </summary>
        /// <param name="baseType">Returns the immediate (first level) type that the typedef is a definition for. If the typedef is a definition of another typedef, this will return that typedef and not the final unwind of the definition chain.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetTypedefBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType2 baseType);

        /// <summary>
        /// The GetTypedefFinalBaseType method will return the final type that the typedef is a definition for. If the typedef is a definition of another typedef, this will continue to follow the definition chain until it reaches a type which is not a typedef and that type will be returned.<para/>
        /// In this example: this method will return MYSTRUCT * when called on either PMYSTRUCT or PTRMYSTRUCT. For more information, see <see cref="IsTypedef"/>.
        /// </summary>
        /// <param name="finalBaseType">Returns the final type that the typedef is a definition for. If the typedef is a definition of another typedef, this will continue to follow the definition chain until it reaches a type which is not a typedef.<para/>
        /// Such type will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetTypedefFinalBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType2 finalBaseType);

        /// <summary>
        /// The GetFunctionVarArgsKind method returns whether a given function utilizes a variable argument list, and if so, what style of variable arguments it utilizes.<para/>
        /// Such is defined by a member of the VarArgsKind enumeration defined as follows:
        /// </summary>
        /// <param name="varArgsKind">A value of the VarArgsKind enumeration indicating whether the function is a varargs function and, if so, what style of variable arguments it utilizes.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. This method will not fail on a non varargs function.</returns>
        [PreserveSig]
        new HRESULT GetFunctionVarArgsKind(
            [Out] out VarArgsKind varArgsKind);

        /// <summary>
        /// Indicates what the type of the instance ("this") pointer passed to the function is. This method will failif the function is not an instance method on a class.
        /// </summary>
        /// <param name="instancePointerType">The instance pointer type.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetFunctionInstancePointerType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType2 instancePointerType);
        
        [PreserveSig]
        new HRESULT GetContainingType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType3 containingParentType);

        /// <summary>
        /// Compares two symbols for equality. A host is under no obligation to ensure that there is interface pointer equality for two identical symbols.<para/>
        /// This can be used to check for equality. Note that presently, "comparisonFlags" is reserved.
        /// </summary>
        /// <param name="pComparisonSymbol">The symbol to compare against.</param>
        /// <param name="comparisonFlags">Reserved. Must be set to 0.</param>
        /// <param name="pMatches">An indication of whether the symbols are equal will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT CompareAgainst(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pComparisonSymbol,
            [In] int comparisonFlags,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pMatches);
        
        [PreserveSig]
        HRESULT GetExtendedArrayHeaderSize(
            [Out] out long headerSize);
        
        [PreserveSig]
        HRESULT GetExtendedArrayDimensions(
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ExtendedArrayDimension[] pDimensions);
        
        [PreserveSig]
        HRESULT GetUDTKind(
            [Out] out UDTKind udtKind);
    }
}
