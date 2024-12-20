using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("58AC3F3F-0886-4AA0-A074-9635CC0DDE95")]
    [ComImport]
    public interface ISvcSymbolType
    {
        /// <summary>
        /// Gets the kind of type symbol that this is (e.g.: base type, struct, array, etc...).
        /// </summary>
        [PreserveSig]
        HRESULT GetTypeKind(
            [Out] out SvcSymbolTypeKind kind);

        /// <summary>
        /// Gets the overall size of the type as laid out in memory.
        /// </summary>
        [PreserveSig]
        HRESULT GetSize(
            [Out] out long size);

        /// <summary>
        /// If the type is a derivation of another single type (e.g.: as "MyStruct *" is derived from "MyStruct"), this returns the base type of the derivation.<para/>
        /// For pointers, this would return the type pointed to. For arrays, this would return what the array is an array of.<para/>
        /// If the type is not such a derivative type, an error is returned. Note that this method has nothing to do with C++ base classes.<para/>
        /// Such are symbols which can be enumerated from the derived class.
        /// </summary>
        [PreserveSig]
        HRESULT GetBaseType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol baseType);

        /// <summary>
        /// If the type is a qualified form (const/volatile/etc...) of another type, this returns a type symbol with all qualifiers stripped.
        /// </summary>
        [PreserveSig]
        HRESULT GetUnmodifiedType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol unmodifiedType);

        /// <summary>
        /// If the type kind as reported by GetTypeKind is an intrinsic, this returns more information about the particular kind of intrinsic.
        /// </summary>
        [PreserveSig]
        HRESULT GetIntrinsicType(
            [Out] out SvcSymbolIntrinsicKind kind,
            [Out] out int packingSize);

        /// <summary>
        /// Returns what kind of pointer the type is (e.g.: a standard pointer, a pointer to member, a reference, an r-value reference, etc...
        /// </summary>
        [PreserveSig]
        HRESULT GetPointerKind(
            [Out] out SvcSymbolPointerKind kind);

        /// <summary>
        /// If the pointer is a pointer-to-class-member, this returns the type of such class.
        /// </summary>
        [PreserveSig]
        HRESULT GetMemberType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolType memberType);

        /// <summary>
        /// Returns the dimensionality of the array. There is no guarantee that every array type representable by these interfaces is a standard zero-based one dimensional array as is standard in C.
        /// </summary>
        [PreserveSig]
        HRESULT GetArrayDimensionality(
            [Out] out long arrayDimensionality);

        /// <summary>
        /// Fills in information about each dimension of the array including its lower bound, length, and stride.
        /// </summary>
        [PreserveSig]
        HRESULT GetArrayDimensions(
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SvcSymbolArrayDimension[] pDimensions);

        /// <summary>
        /// Gets the size of any header of the array (this is the offset of the first element of the array as described by the dimensions).<para/>
        /// This should *ALWAYS* return 0 for a C style array.
        /// </summary>
        [PreserveSig]
        HRESULT GetArrayHeaderSize(
            [Out] out long arrayHeaderSize);

        /// <summary>
        /// Returns the return type of a function. Even non-value returning functions (e.g.: void) should return a type representing this.
        /// </summary>
        [PreserveSig]
        HRESULT GetFunctionReturnType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol returnType);

        /// <summary>
        /// Returns the number of parameters that the function takes.
        /// </summary>
        [PreserveSig]
        HRESULT GetFunctionParameterTypeCount(
            [Out] out long count);

        /// <summary>
        /// Returns the type of the "i"-th argument to the function as a new ISvcSymbol.
        /// </summary>
        [PreserveSig]
        HRESULT GetFunctionParameterTypeAt(
            [In] long i,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol parameterType);
    }
}
