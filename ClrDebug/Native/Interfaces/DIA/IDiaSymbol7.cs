using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    [Guid("64CE6CD5-7315-4328-86D6-10E303E010B4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaSymbol7 : IDiaSymbol6
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Retrieves the unique symbol identifier.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the symbol ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_symIndexId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the symbol type classifier.
        /// </summary>
        /// <param name="pRetVal">[out] Returns A value from the SymTagEnum Enumeration enumeration that specifies the symbol type classifier.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_symTag(
            [Out] out SymTagEnum pRetVal);

        /// <summary>
        /// Retrieves the name of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the name of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_name(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        /// <summary>
        /// Retrieves a reference to the lexical parent of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object that represents the lexical parent of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// The lexical parent of a symbol is the enclosing function or module. For example, the lexical parent of a function
        /// parameter or local variable is the function itself while the lexical parent of the function is the module it is
        /// defined in. The possible symbols that can appear as lexical parents are documented in Lexical Hierarchy of Symbol
        /// Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_lexicalParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves a reference to the class parent of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object that represents the class parent of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The types of symbols that can be class parents are documented in Class Hierarchy of Symbol Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_classParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves the symbol that represents the type for this symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object that represents the type of this symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// To determine the type a symbol has, you must call this method and examine the resulting IDiaSymbol object. Note
        /// that it is possible for a symbol to not have a type. For example, the name of a structure has no type but it might
        /// have children symbols (use the IDiaSymbol method to examine those children).
        /// </remarks>
        [PreserveSig]
        new HRESULT get_type(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves the variable classification of a data symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the DataKind Enumeration enumeration specifying the kind of data such as global, static, or constant, for example.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_dataKind(
            [Out] out DataKind pRetVal);

        /// <summary>
        /// Retrieves the location type of a data symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the LocationType Enumeration enumeration that specifies the location type of a data symbol, such as static or local.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_locationType(
            [Out] out LocationType pRetVal);

        /// <summary>
        /// Retrieves the section part of an address location. Use when the LocationType Enumeration is set to LocIsStatic.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section part of an address location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// For static members located in an external DLL, the section returned by this method may be 0 as this method relies
        /// on obtaining the virtual address of the member. Virtual addresses are valid only if the IDiaSession method in the
        /// IDiaSession interface has been called with a nonzero parameter specifying the load address of the DLL. To get the
        /// offset part of an address, call the IDiaSymbol method.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_addressSection(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the offset part of an address location. Use when the LocationType Enumeration is set to LocIsStatic.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of an address location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// For static members located in an external DLL, the offset returned by this method may be 0 as this method relies
        /// on obtaining the virtual address of the member. Virtual addresses are valid only if the IDiaSession method in the
        /// IDiaSession interface has been called with a nonzero parameter specifying the load address of the DLL. To get the
        /// section part of an address, call the IDiaSymbol method.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_addressOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the location. Use when the LocationType Enumeration is set to LocIsStatic.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the relative virtual address of the location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the virtual address (VA) of the location. Use when the LocationType Enumeration is set to LocIsStatic.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the virtual address of the location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_virtualAddress(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the register designator of the location when the LocationType Enumeration is set to LocIsEnregistered.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the register designator of the location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// If the symbol is relative to a register, that is, if the symbol's LocationType Enumeration is set to LocIsRegRel,
        /// use the get_registerId method followed by a call to the IDiaSymbol method to get the offset from the register where
        /// the symbol is located.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_registerId(
            [Out] out CV_HREG_e pRetVal);

        /// <summary>
        /// Retrieves the offset of the symbol location. Use when the LocationType Enumeration is LocIsRegRel or LocIsBitField.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset in bytes of the symbol location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The offset is from some known point previously determined. For example, the offset for a LocIsBitField location
        /// type is typically from the start of the containing class.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_offset(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of bits or bytes of memory used by the object represented by this symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes or bits of memory used by the object represented by this symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// If the LocationType Enumeration of the symbol is LocIsBitField, the length returned by this method is in bits;
        /// otherwise, the length is in bytes for all other location types.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_length(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the slot number of the location. Use when the LocationType Enumeration is LocIsSlot.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the slot number of the location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_slot(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type (UDT) is volatile.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the UDT is volatile; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// In C++, a UDT can be marked with the volatile keyword, indicating that its contents cannot be assumed to exist
        /// from one access to the next.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_volatileType(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is constant.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type is constant; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_constType(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is unaligned.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type is unaligned; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_unalignedType(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the access modifier of a class member.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the CV_access_e Enumeration enumeration that specifies the access modifier of a class member.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_access(
            [Out] out CV_access_e pRetVal);

        /// <summary>
        /// Retrieves the file name of the library or object file from which the object was loaded.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the file name of the library or object file from which the object was loaded.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_libraryName(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        /// <summary>
        /// Retrieves the platform type for which the compiland was compiled.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the CV_CPU_TYPE_e Enumeration enumeration that specifies the platform type for which the compiland was compiled.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_platform(
            [Out] out CV_CPU_TYPE_e pRetVal);

        /// <summary>
        /// Retrieves the language of the source.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the CV_CFL_LANG Enumeration enumeration that specifies the language of the source.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_language(
            [Out] out CV_CFL_LANG pRetVal);

        /// <summary>
        /// Retrieves a flag indicating whether the module was compiled with the /Z7, /Zi, /ZI (Debug Information Format) compiler switch.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if edit-and-continue was enabled at compilation; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_editAndContinueEnabled(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the front end major version number.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the front end major version number. See Remarks.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// A compiler is typically composed of two primary elements: the front end (the parser), which handles parsing the
        /// source code into an intermediate form, and a back end (code generator), which converts the intermediate form into
        /// assembly. It is not uncommon for the front end to have a different version than the back end. A front end or back
        /// end version number is composed of three parts: &lt;major&gt;.&lt;minor&gt;.&lt;build&gt;, where &lt;major&gt; is
        /// the major version number, &lt;minor&gt; is the minor version number, and &lt;build&gt; is the build number. For
        /// example, 13.10.3077.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_frontEndMajor(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the front end minor version number.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the front.end minor version number.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// A compiler is typically composed of two primary elements: the front end (the parser), which handles parsing the
        /// source code into an intermediate form, and a back end (code generator), which converts the intermediate form into
        /// assembly. It is not uncommon for the front end to have a different version than the back end. A front end or back
        /// end version number is composed of three parts: &lt;major&gt;.&lt;minor&gt;.&lt;build&gt;, where &lt;major&gt; is
        /// the major version number, &lt;minor&gt; is the minor version number, and &lt;build&gt; is the build number. For
        /// example, 13.10.3077.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_frontEndMinor(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the front end build number.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the front end build number. See Remarks.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// A compiler is typically composed of two primary elements: the front end (the parser), which handles parsing the
        /// source code into an intermediate form, and a back end (code generator), which converts the intermediate form into
        /// assembly. It is not uncommon for the front end to have a different version than the back end. A front end or back
        /// end version number is composed of three parts: &lt;major&gt;.&lt;minor&gt;.&lt;build&gt;, where &lt;major&gt; is
        /// the major version number, &lt;minor&gt; is the minor version number, and &lt;build&gt; is the build number. For
        /// example, 13.10.3077.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_frontEndBuild(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the back-end major version number of the compiler.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the back-end major version number. See Remarks.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// A compiler is typically composed of two primary elements: the front end (the parser), which handles parsing the
        /// source code into an intermediate form, and a back end (code generator), which converts the intermediate form into
        /// assembly. It is not uncommon for the front end to have a different version than the back end. A front end or back
        /// end version number is composed of three parts: &lt;major&gt;.&lt;minor&gt;.&lt;build&gt;, where &lt;major&gt; is
        /// the major version number, &lt;minor&gt; is the minor version number, and &lt;build&gt; is the build number. For
        /// example, 13.10.3077.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_backEndMajor(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the back end minor version number of the compiler.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the back end minor version number. See Remarks.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// A compiler is typically composed of two primary elements: the front end (the parser), which handles parsing the
        /// source code into an intermediate form, and a back end (code generator), which converts the intermediate form into
        /// assembly. It is not uncommon for the front end to have a different version than the back end. A front end or back
        /// end version number is composed of three parts: &lt;major&gt;.&lt;minor&gt;.&lt;build&gt;, where &lt;major&gt; is
        /// the major version number, &lt;minor&gt; is the minor version number, and &lt;build&gt; is the build number. For
        /// example, 13.10.3077.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_backEndMinor(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the back end build number of the compiler.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the back end build number. See Remarks.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// A compiler is typically composed of two primary elements: the front end (the parser), which handles parsing the
        /// source code into an intermediate form, and a back end (code generator), which converts the intermediate form into
        /// assembly. It is not uncommon for the front end to have a different version than the back end. A front end or back
        /// end version number is composed of three parts: &lt;major&gt;.&lt;minor&gt;.&lt;build&gt;, where &lt;major&gt; is
        /// the major version number, &lt;minor&gt; is the minor version number, and &lt;build&gt; is the build number. For
        /// example, 13.10.3077.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_backEndBuild(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the file name of the compiland source file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the file name of the compiland source file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_sourceFileName(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        [PreserveSig]
        new HRESULT get_unused(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        /// <summary>
        /// Retrieves the thunk type of a function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the THUNK_ORDINAL Enumeration enumeration that specifies the thunk type of a function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is valid only if the symbol as a SymTagEnum Enumeration value of SymTagThunk. A "thunk" is a piece
        /// of code that converts between a 32-bit memory address space (also known as flat address space) and a 16-bit address
        /// space (known as a segmented address space).
        /// </remarks>
        [PreserveSig]
        new HRESULT get_thunkOrdinal(
            [Out] out THUNK_ORDINAL pRetVal);

        /// <summary>
        /// Retrieves the logical this adjustor for the method.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the logical this adjustor for the method.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// In some multiple inheritance cases the method itself must calculate a true this value by adding an offset to this.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_thisAdjust(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the offset in the virtual function table of a virtual function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset in the virtual function table of a virtual function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_virtualBaseOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function is virtual.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function is virtual; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_virtual(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function is an introducing virtual function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function is intro virtual; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_intro(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function is pure virtual.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function is pure virtual; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_pure(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Returns an indicator of a methods calling convention.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the CV_call_e Enumeration enumeration that specifies a method's calling convention.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_callingConvention(
            [Out] out CV_call_e pRetVal);

        /// <summary>
        /// Retrieves the value of a constant.
        /// </summary>
        /// <param name="pRetVal">[in, out] A VARIANT object that is filled in with the value of a constant.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The supplied VARIANT must be initialized before it is passed to this method. For more information, see the example.
        /// </remarks>
        [PreserveSig]
        [Obsolete("DiaVariant objects returned from this method must be manually freed. Consider using the DiaExtensions.get_value(this IDiaSymbol symbol, out object pRetVal) extension method instead.")]
        new HRESULT get_value(
            out DiaVariant pRetVal);

        /// <summary>
        /// Retrieves the base type for this symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the BasicType Enumeration enumeration specifying the base type of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The basic type for a symbol can be determined by first getting the type of the symbol and then interrogating that
        /// returned type for the base type. Note that some symbols may not have a base type—for example, a structure name.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_baseType(
            [Out] out BasicType pRetVal);

        /// <summary>
        /// Retrieves the metadata token of a managed function or variable.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the metadata token of a managed function or variable.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_token(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the timestamp of the underlying executable file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the timestamp of the underlying executable file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_timeStamp(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the symbol's globally unique identifier (GUID).
        /// </summary>
        /// <param name="pRetVal">[out] Returns the symbol's GUID.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_guid(
            [Out]
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(GuidMarshaller))]
#endif
            out Guid pRetVal);

        /// <summary>
        /// Retrieves the name of the file from which the symbols were loaded.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the name of the file from which the symbols were loaded.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is valid only for symbols with a SymTagEnum Enumeration value of SymTagExe that also have global
        /// scope.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_symbolsFileName(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether a pointer type is a reference.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if a pointer type is a reference; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_reference(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the number of items in a list or array.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of items in a list or array.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the bit position of location. Used when the LocationType Enumeration is LocIsBitField.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the bit position of the location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_bitPosition(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the symbol interface of the array index type of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object that represents the array index type of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// Some languages can specify the type used as an index to an array. The symbol returned from this method specifies
        /// that type.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_arrayIndexType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type (UDT) is packed.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the UDT is packed; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// Packed means all the members of the UDT are positioned as close together as possible, with no intervening padding
        /// to align to memory boundaries.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_packed(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has a constructor or destructor.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type has a constructor or destructor; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_constructor(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has overloaded operators.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type has overloaded operators; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_overloadedOperator(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is nested.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type is nested; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_nested(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has nested type definitions.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type has nested type definitions; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_hasNestedTypes(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has any assignment operators defined.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type has any assignment operators defined; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_hasAssignmentOperator(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has any cast operators defined.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a TRUE if the user-defined data type has any cast operators defined; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_hasCastOperator(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type appears in a non-global lexical scope.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type appears in a non-global lexical scope; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_scoped(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is a virtual base class.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type is a virtual base class; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_virtualBaseClass(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is an indirect virtual base class.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type is an indirect virtual base class; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_indirectVirtualBaseClass(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the offset of the virtual base pointer.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset of the virtual base pointer.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_virtualBasePointerOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the symbol interface of the type of the virtual table for a user-defined type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object representing the virtual table for a user-defined type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_virtualTableShape(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves the lexical parent identifier of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the lexical parent ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_lexicalParentId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the class parent identifier of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the class parent ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_classParentId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the type identifier of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the type ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_typeId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the array index type identifier of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the array index type ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_arrayIndexTypeId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the virtual table shape symbol identifier of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the virtual table shape symbol ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_virtualTableShapeId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the symbol refers to a code address.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the symbol refers to a code address, otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_code(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the public symbol refers to a function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a TRUE if the symbol refers to a function; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_function(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the symbol refers to managed code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the symbol refers to managed code; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_managed(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the symbol refers to Microsoft Intermediate Language (MSIL) code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the symbol refers to MSIL code; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_msil(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the index of the symbol in the virtual base displacement table.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the index into the virtual base displacement table.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_virtualBaseDispIndex(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the undecorated name for a C++ decorated, or linkage, name.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the undecorated name for a C++ decorated name.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_undecoratedName(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        /// <summary>
        /// Retrieves the age value of a .pdb file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the age value of a .pdb file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// The age does not necessarily correspond to any known time value; it is typically used to determine if a .pdb file
        /// is out of sync with a corresponding .exe file.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_age(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the symbol's signature value.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the symbol's signature value.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_signature(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the symbol was generated by the compiler.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the compiler generated the symbol; otherwise, returns FALSE if the symbol was generated from user-written source.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_compilerGenerated(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether another symbol references this symbol's address.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if another symbol references this address; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_addressTaken(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the rank (number of dimensions) of a FORTRAN multi-dimensional array.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of dimensions in a FORTRAN multi-dimensional array.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// Rank refers to the number of dimensions in an array where the array is declared as myarray[1,2,3]. This example
        /// has a rank of 3 and 3 dimensions. Rank does not apply to C++ which uses the concept of an array of arrays for each
        /// dimension (that is, myarray[1][2][3]).
        /// </remarks>
        [PreserveSig]
        new HRESULT get_rank(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the lower bound of a FORTRAN array dimension.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object that represents the lower bound of a FORTRAN array dimension.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_lowerBound(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves a symbol representing the upper bound of a FORTRAN array dimension.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object that represents the upper bound of a FORTRAN array dimension.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_upperBound(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves the symbol identifier of the lower bound of a FORTRAN array dimension.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the symbol ID of the symbol that represents the lower bound of a FORTRAN array dimension.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_lowerBoundId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the symbol identifier of the upper bound of a FORTRAN array dimension.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_upperBoundId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the data bytes of an OEM symbol.
        /// </summary>
        /// <param name="cbData">[in] Size of the buffer to hold the data.</param>
        /// <param name="pcbData">[out] Returns the number of bytes written, or, if the data parameter is NULL, returns the number of bytes available.</param>
        /// <param name="data">[out] A buffer that is filled in with the data bytes.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_dataBytes(
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] data);

        /// <summary>
        /// Retrieves the children of the symbol.
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="ppResult">[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</param>
        /// <returns>Returns S_OK if at least one child of the symbol was found, or returns S_FALSE if no children were found; otherwise returns an error code.</returns>
        /// <remarks>
        /// This method is identical to calling the IDiaSession method with this symbol as the first parameter.
        /// </remarks>
        [PreserveSig]
        new HRESULT findChildren(
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves the children of the symbol. The local symbols that are returned include live range information, if the program is compiled with optimization on.
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="ppResult">[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</param>
        /// <returns>Returns S_OK if at least one child of the symbol was found, or returns S_FALSE if no children were found; otherwise, returns an error code.</returns>
        /// <remarks>
        /// This method is the extended version of IDiaSymbol.
        /// </remarks>
        [PreserveSig]
        new HRESULT findChildrenEx(
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves the children of the symbol that are valid at a specified address.
        /// </summary>
        /// <param name="symtag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="address">[in] The address of the symbol.</param>
        /// <param name="ppResult">[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</param>
        /// <returns>Returns S_OK if at least one child of the symbol was found, or returns S_FALSE if no children were found; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The local symbols that are returned include live range information.
        /// </remarks>
        [PreserveSig]
        new HRESULT findChildrenExByAddr(
            [In] SymTagEnum symtag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] int address,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves the children of the symbol that are valid at a specified virtual address.
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="va">[in] Specifies the virtual address.</param>
        /// <param name="ppResult">[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</param>
        /// <returns>Returns S_OK if at least one child of the symbol was found, or returns S_FALSE if no children were found; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The local symbols that are returned include live range information.
        /// </remarks>
        [PreserveSig]
        new HRESULT findChildrenExByVA(
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves the children of the symbol that are valid at a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="rva">[in] Specifies the RVA.</param>
        /// <param name="ppResult">[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</param>
        /// <returns>Returns S_OK if at least one child of the symbol was found, or returns S_FALSE if no children were found; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The local symbols that are returned include live range information.
        /// </remarks>
        [PreserveSig]
        new HRESULT findChildrenExByRVA(
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves the address section of a thunk target.
        /// </summary>
        /// <param name="pRetVal">[out] Section part of a thunk target address.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_targetSection(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the offset section of a thunk target.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of a thunk target address.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_targetOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of a thunk target.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the RVA of a thunk target.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is valid only if the symbol as a SymTagEnum Enumeration value of SymTagThunk. A "thunk" is a piece
        /// of code that converts between a 32-bit memory address space (also known as flat address space) and a 16-bit address
        /// space (known as a segmented address space).
        /// </remarks>
        [PreserveSig]
        new HRESULT get_targetRelativeVirtualAddress(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the virtual address (VA) of a thunk target.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the VA of a thunk target.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is valid only if the symbol as a SymTagEnum Enumeration value of SymTagThunk. A "thunk" is a piece
        /// of code that converts between a 32-bit memory address space (also known as flat address space) and a 16-bit address
        /// space (known as a segmented address space).
        /// </remarks>
        [PreserveSig]
        new HRESULT get_targetVirtualAddress(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the type of the target CPU.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the IMAGE_FILE_MACHINE that specifies the target CPU type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_machineType(
            [Out] out IMAGE_FILE_MACHINE pRetVal);

        /// <summary>
        /// Retrieves the symbol's original equipment manufacturer (OEM) ID value.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a unique value that identifies an OEM.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property applies only to symbols with a SymTagEnum Enumeration type of SymTagCustomType.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_oemId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the original equipment manufacturer (OEM) symbol's ID value.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an OEM's internally assigned symbol ID.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique. This property applies only
        /// to symbols with a SymTagEnum Enumeration type of SymTagCustomType.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_oemSymbolId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves an array of compiler-specific types for this symbol.
        /// </summary>
        /// <param name="cTypes">[in] Size of the buffer to hold the data.</param>
        /// <param name="pcTypes">[out] Returns the number of types written, or, if the types parameter is NULL, then the total number of types available.</param>
        /// <param name="pTypes">[out] An array that is to be filled in with the IDiaSymbol objects that represent all the types for this symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_types(
            [In] int cTypes,
            [Out] out int pcTypes,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IDiaSymbol[] pTypes);

        /// <summary>
        /// Retrieves an array of compiler-specific type identifier values for this symbol.
        /// </summary>
        /// <param name="cTypeIds">[in] Size of the buffer to hold the data.</param>
        /// <param name="pcTypeIds">[out] Returns the number of typeIds written, or, if typeIds is NULL, then the total number of type identifiers available.</param>
        /// <param name="pdwTypeIds">[out] An array that is to be filled in with the type identifiers.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_typeIds(
            [In] int cTypeIds,
            [Out] out int pcTypeIds,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] pdwTypeIds);

        /// <summary>
        /// Retrieves the type of the object pointer for a class method.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object that represents the object pointer for a class method.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property applies only to symbols with a SymTagEnum Enumeration type of SymTagFunctionType.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_objectPointerType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves the variety of a user-defined type (UDT).
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the UdtKind Enumeration enumeration that specifies the kind of a UDT: structure, class, or union.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_udtKind(
            [Out] out UdtKind pRetVal);

        /// <summary>
        /// Retrieves part or all of an undecorated name for a C++ decorated (linkage) name.
        /// </summary>
        /// <param name="undecorateOptions">[in] Specifies a combination of flags that control what is returned. See the Remarks section for the specific values and what they do.</param>
        /// <param name="name">[out] Returns the undecorated name for a C++ decorated name.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The undecorateOptions can be a combination of the following flags.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_undecoratedNameEx(
            [In] UNDNAME undecorateOptions,
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string name);

        /// <summary>
        /// Retrieves a flag that specifies whether the function has been marked as never returning with the noreturn attribute.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has been declared as never returning with the noreturn attribute; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_noReturn(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function has a custom calling convention.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has a custom calling convention; otherwise, returns FALSE, the function has a known calling convention.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_customCallingConvention(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function has been marked as being not inline (using the noinline attribute).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has the noinline attribute; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_noInline(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the function contains debug information that is specific for optimized code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the optimized function or label contains debugging information; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_optimizedCodeDebugInfo(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function or label is never reached.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function or label is never reached; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_notReached(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a return from interrupt instruction (for example, the X86 assembly code iret).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has a return from interrupt instruction; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_interruptReturn(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a far return.
        /// </summary>
        /// <param name="pRetVal">[in] Returns TRUE if the function uses a far return, otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_farReturn(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function or thunk layer has been marked as static.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function or thunk layer has been marked as static; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isStatic(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies if the Compiland contains debugging information.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the compiland contains debugging information; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_hasDebugInfo(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the Compiland has been linked with the linker switch /LTCG (Link-time Code Generation), which aids in whole program optimization.<para/>
        /// This switch applies only to managed code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the compiland was linked with the /LTCG linker switch; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isLTCG(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined type (UDT) has been aligned to some specific memory boundary.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the UDT has been aligned to some memory boundary; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// This property is generally set when the executable is compiled with nondefault data alignment. For example, the
        /// Microsoft C++ compiler can change the data alignment with the command-line option, /Zp#, where # is a byte value.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_isDataAligned(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the compiland or function has been compiled with buffer-overrun security checks (for example, the /GS (Buffer Security Check) compiler switch).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has any security checks; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_hasSecurityChecks(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Returns the name of the compiler used to generate the Compiland.
        /// </summary>
        /// <param name="pRetVal">Pointer to a BSTR that will contain the Unicode name of the compiler.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_compilerName(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a call to alloca (which is used to allocate memory on the stack).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function contains a call to alloca; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_hasAlloca(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a use of the setjmp command (paired with the longjmp command, these form the C-style method of exception handling).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function contains a setjmp command; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_hasSetJump(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a use of the longjmp command (paired with a setjmp command, these form the C-style method of exception handling).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function contains a longjmp command; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_hasLongJump(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains inline assembly.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has any inline assembly; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_hasInlAsm(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains any unmanaged C++-style exception handling (for example, a try/catch block).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has any C++-style exception handling; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_hasEH(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains any Structured Exception Handling (C/C (for example, __try/__except blocks).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has any structured exception handling blocks; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_hasSEH(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains asynchronous (structured) exception handling.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has any asynchronous exception handling; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// It is possible to mix asynchronous or structured exception handling with C++-style exception handling, but it requires
        /// a specific compiler switch, /EHa, to enable it.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_hasEHa(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the function has the naked attribute (that is, the function has no prolog or epilog code added by the compiler).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has the naked attribute; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isNaked(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the data symbol is part of an aggregate or collection of symbols; the compiler will treat aggregated symbols as separate entities, but they are really part of a single larger symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the data is part of an aggregation of symbols split from a parent symbol; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The IDiaSymbol method is TRUE for the symbol that is the parent of the aggregated symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_isAggregated(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the data symbol has been split into an aggregation or collection of other symbols; the compiler treats the symbols as separate entities, even though they are really part of a larger symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the symbol has been split into an aggregate of symbols; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// The IDiaSymbol method returns TRUE for all symbols that are part of a split symbol.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_isSplitted(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// This function retrieves a pointer to a symbol representing the parent/container of this symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a pointer to an IDiaSymbol containing information about the container of this symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_container(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// This function retrieves a flag indicating whether the function was marked as inline (using one of the inline, attributes).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function was marked as inline; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        [PreserveSig]
        new HRESULT get_inlSpec(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// This function retrieves a flag that indicates whether no stack ordering could be done as part of stack buffer checking (/GS (Buffer Security Check) compiler option).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if no stack ordering could be done as part of stack buffer checking; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_noStackOrdering(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the type of a virtual base table pointer.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// A virtual base table pointer (vbtptr) is a hidden pointer in a Visual C++ vtable that handles inheritance from
        /// virtual base classes. A vbtptr can have different sizes depending on the inherited classes. This method returns
        /// an IDiaSymbol object that can be used to determine the size of the vbtptr.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_virtualBaseTableType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves a flag indicating whether the module contains managed code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the module contains managed code; otherwise, returns FALSE, the code is unmanaged code.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagCompilandDetails symbol type (see CompilandDetails).
        /// </remarks>
        [PreserveSig]
        new HRESULT get_hasManagedCode(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag indicating whether the module was compiled with the /hotpatch (Create Hotpatchable Image) compiler switch.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the module is hot-patchable; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagCompilandDetails symbol type (see CompilandDetails).
        /// </remarks>
        [PreserveSig]
        new HRESULT get_isHotpatchable(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag indicating whether the module was converted from a Common Intermediate Language (CIL) module to a native module.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the module was converted from CIL to native code; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagCompilandDetails symbol type (see CompilandDetails.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_isCVTCIL(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag indicating whether the module is a .netmodule (a Microsoft Intermediate Language (MSIL) module that contains only metadata and no native symbols).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the module is MSIL; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagCompilandDetails symbol type (see CompilandDetails).
        /// </remarks>
        [PreserveSig]
        new HRESULT get_isMSILNetmodule(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag indicating whether the symbol file contains C types.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the symbol file contains C types; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagExe symbol type (see Exe).
        /// </remarks>
        [PreserveSig]
        new HRESULT get_isCTypes(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves flag indicating whether private symbols were stripped from the symbol file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if private symbols were removed from the symbol file; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagExe symbol type (see Exe).
        /// </remarks>
        [PreserveSig]
        new HRESULT get_isStripped(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_frontEndQFE(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_backEndQFE(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_wasInlined(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_strictGSCheck(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_isCxxReturnUdt(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_isConstructorVirtualBase(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether a pointer type is an rvalue reference. Use when the SymTagEnum Enumeration is set to a pointer type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the pointer is an rvalue reference; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_RValueReference(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the original type for this symbol. Use when the SymTagEnum Enumeration is set to a type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object that represents the original type of this symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The current type is a modification of the returned original type. The original type for a symbol can be determined
        /// by first getting the type of the symbol and then interrogating that returned type for the original type. Note that
        /// some symbols may not have a modified type of the original type.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_unmodifiedType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the frame pointer is present. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        /// <param name="pRetVal">[out] ] Returns TRUE if the frame pointer is present; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_framePointerPresent(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the preprocesser directive for a safe buffer is used. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the pointer uses a preprocessor directive for a safe buffer; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isSafeBuffers(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether a class is an intrinsic type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the class is an intrinsic type; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_intrinsic(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether the class or method is sealed.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the class or method is sealed; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// A sealed class cannot be used as a base class. A sealed method cannot be overidden.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_sealed(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether a user-defined type (UDT) contains homogeneous floating-point aggregate (HFA) data of type float.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the UDT contains HFA data of type float; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_hfaFloat(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that specifies whether a user-defined type (UDT) contains homogeneous floating-point aggregate (HFA) data of type double.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the UDT contains HFA data of type double; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_hfaDouble(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Returns the section part of the starting address of the range in which the local symbol is valid.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section part of the starting address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The address formed by the section and offset is the beginning of the range in which the symbol is valid. To get
        /// the offset part of the address, use IDiaSymbol.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_liveRangeStartAddressSection(
            [Out] out int pRetVal);

        /// <summary>
        /// Returns the offset part of the starting address of the range in which the local symbol is valid.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of the starting address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The address formed by the section and offset is the beginning of the range in which the symbol is valid. To get
        /// the section part of the address, use IDiaSymbol.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_liveRangeStartAddressOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Returns the beginning of the address range in which the local symbol is valid.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the start of the address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The relative virtual address returned is the beginning of the range in which the symbol is valid.</returns>
        [PreserveSig]
        new HRESULT get_liveRangeStartRelativeVirtualAddress(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of valid address ranges associated with the local symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of address ranges.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT get_countLiveRanges(
            [Out] out int pRetVal);

        /// <summary>
        /// Returns the length of the address range in which the local symbol is valid.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the length of the address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT get_liveRangeLength(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the offset to the beginning of a user-defined type (UDT) of a member in the UDT.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset in bytes of the symbol location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This function is used only in local records in an optimized build.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_offsetInUdt(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the ID of the register that holds a base pointer to the parameters. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the ID of the register that holds a base pointer to the parameters.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_paramBasePointerRegisterId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the ID of the register that holds a base pointer to local variables on the stack. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the ID of the register that holds a base pointer to local variables on the stack.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_localBasePointerRegisterId(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_isLocationControlFlowDependent(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the stride of the matrix or strided array.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the stride.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_stride(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of rows in the matrix.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the number of rows in the matrix.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_numberOfRows(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of columns in the matrix.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the number of columns in the matrix.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_numberOfColumns(
            [Out] out int pRetVal);

        /// <summary>
        /// Specifies whether the matrix is row major.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the matrix is row major.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isMatrixRowMajor(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_numericProperties(
            [In] int cnt,
            [Out] out int pcnt,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] pProperties);

        [PreserveSig]
        new HRESULT get_modifierValues(
            [In] int cnt,
            [Out] out int pcnt,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] short[] pModifiers);

        /// <summary>
        /// Specifies whether the variable carries a return value.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the variable carries a return value.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isReturnValue(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Specifies whether the variable is optimized away.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the variable is optimized away.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isOptimizedAway(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a built-in kind of the HLSL type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds a built-in kind of the HLSL type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_builtInKind(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the register type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the register type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_registerType(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the base data slot.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the base data slot.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_baseDataSlot(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the base data offset.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the base data offset.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_baseDataOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the texture slot.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the texture slot.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_textureSlot(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the sampler slot.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the sampler slot.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_samplerSlot(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the uav slot.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the uav slot.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_uavSlot(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the size of a member of a user-defined type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that specifies the size of the member.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_sizeInUdt(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the memory space kind.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the memory space kind.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_memorySpaceKind(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the ID of the original (unmodified) type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the ID.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_unmodifiedTypeId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the sub type ID.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the sub type ID.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_subTypeId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the sub type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to the sub type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_subType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves the number of modifiers that are applied to the original type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that specifies the number of modifiers that are applied to the original type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_numberOfModifiers(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of register indices.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the number of register indices.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_numberOfRegisterIndices(
            [Out] out int pRetVal);

        /// <summary>
        /// Specifies whether this symbol represents High Level Shader Language (HLSL) data.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether this symbol represents HLSL data.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isHLSLData(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Specifies whether this symbol is a pointer to a data member.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether this symbol is a pointer to a data member.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isPointerToDataMember(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Specifies whether this symbol is a pointer to a member function.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether this symbol is a pointer to a member function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isPointerToMemberFunction(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Specifies whether the this pointer points to a data member with single inheritance.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the this pointer points to a data member with single inheritance.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isSingleInheritance(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Specifies whether the this pointer points to a data member with multiple inheritance.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the this pointer points to a data member with multiple inheritance.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isMultipleInheritance(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Specifies whether the this pointer points to a data member with virtual inheritance.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the this pointer points to a data member with virtual inheritance.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isVirtualInheritance(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Specifies whether the this pointer is flagged as restricted.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the this pointer is flagged as restricted.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_restrictedType(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Specifies whether the this pointer is based on a symbol value.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the this pointer is based on a symbol value.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isPointerBasedOnSymbolValue(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the symbol from which the pointer is based.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to the symbol from which the pointer is based.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_baseSymbol(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves the symbol ID from which the pointer is based.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the symbol ID from which the pointer is based.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_baseSymbolId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the object file name.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BSTR that holds the object file name.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_objectFileName(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the symbol corresponds to a group shared local variable in code compiled for a C++ AMP Accelerator.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that indicates whether the symbol corresponds to a group shared local variable in code compiled for a C++ AMP Accelerator.<para/>
        /// If TRUE, the get_baseDataSlot and get_baseDataOffset methods can be used to get the storage location information for the variable.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isAcceleratorGroupSharedLocal(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the symbol corresponds to the definition range symbol for the tag component of a pointer variable in code compiled for a C++ AMP Accelerator.<para/>
        /// The definition range symbol is the location of a variable for a span of addresses.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that indicates whether the symbol corresponds to the definition range symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isAcceleratorPointerTagLiveRange(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Indicates whether the symbol corresponds to a top-level function symbol for a shader compiled for an accelerator that corresponds to a parallel_for_each call.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that indicates whether the symbol corresponds to a top-level function symbol for a shader compiled for an accelerator that corresponds to a parallel_for_each call.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isAcceleratorStubFunction(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Returns the number of accelerator pointer tags in a C++ AMP stub function.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the number of accelerator pointer tags in a C++ AMP stub function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This method is called on an IDiaSymbol interface that corresponds to a C++ AMP accelerator stub function.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_numberOfAcceleratorPointerTags(
            [Out] out int pRetVal);

        /// <summary>
        /// Specifies whether the module is compiled with the /SDL option.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the module is compiled with the /SDL option.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT get_isSdl(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_isWinRTPointer(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_isRefUdt(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_isValueUdt(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_isInterfaceUdt(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a given address.
        /// </summary>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT findInlineFramesByAddr(
            [In] int isect,
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT findInlineFramesByRVA(
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified virtual address (VA).
        /// </summary>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT findInlineFramesByVA(
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol.
        /// </summary>
        /// <param name="ppResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT findInlineeLines(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol within the specified address range.
        /// </summary>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT findInlineeLinesByAddr(
            [In] int isect,
            [In] int offset,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol within the specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT findInlineeLinesByRVA(
            [In] int rva,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol within the specified virtual address (VA).
        /// </summary>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT findInlineeLinesByVA(
            [In] long va,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);

        /// <summary>
        /// Given a corresponding tag value, this method returns an enumeration of symbols that are contained in this stub function.
        /// </summary>
        /// <param name="tagValue">[in] The pointer tag value for which the pointee symbol records are found.</param>
        /// <param name="ppResult">[out] A pointer to an IDiaEnumSymbols interface pointer which is initialized with the result.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT findSymbolsForAcceleratorPointerTag(
            [In] int tagValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Given a corresponding tag value, this method returns an enumeration of symbols that are contained in this stub function at a specified relative virtual address.
        /// </summary>
        /// <param name="tagValue">[in] The pointer tag value for which the pointee symbol records are found.</param>
        /// <param name="rva">[in] The rva that is used to filter the symbols that correspond to the pointee variable with the specified tag value.</param>
        /// <param name="ppResult">[out] A pointer to an IDiaEnumSymbols interface pointer which is initialized with the result.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// Call this method only on an IDiaSymbol interface that corresponds to an Accelerator stub function.
        /// </remarks>
        [PreserveSig]
        new HRESULT findSymbolsByRVAForAcceleratorPointerTag(
            [In] int tagValue,
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);

        /// <summary>
        /// Returns all accelerator pointer tag values that correspond to a C++ AMP accelerator stub function.
        /// </summary>
        /// <param name="cnt">[in] The size of the output array pPointerTags.</param>
        /// <param name="pcnt">[out] The count of accelerator pointer tags in the C++ AMP accelerator stub function.</param>
        /// <param name="pPointerTags">[out] A DWORD array pointer that is filled with the accelerator pointer tag values in the C++ AMP accelerator stub function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This method is called on an IDiaSymbol interface that corresponds to a C++ AMP accelerator stub function.
        /// </remarks>
        [PreserveSig]
        new HRESULT get_acceleratorPointerTags(
            [In] int cnt,
            [Out] out int pcnt,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] pPointerTags);

        /// <summary>
        /// Retrieves the source file and line number that indicate where a specified user-defined type is defined.
        /// </summary>
        /// <param name="ppResult">[out] A IDiaLineNumber object that contains the source file and line number where the user-defined.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        [PreserveSig]
        new HRESULT getSrcLineOnTypeDefn(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaLineNumber ppResult);

        [PreserveSig]
        new HRESULT get_isPGO(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_hasValidPGOCounts(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_isOptimizedForSpeed(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_PGOEntryCount(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_PGOEdgeCount(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_PGODynamicInstructionCount(
            [Out] out long pRetVal);

        [PreserveSig]
        new HRESULT get_staticSize(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_finalLiveStaticSize(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_phaseName(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        [PreserveSig]
        new HRESULT get_hasControlFlowCheck(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_constantExport(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_dataExport(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_privateExport(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_noNameExport(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_exportHasExplicitlyAssignedOrdinal(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_exportIsForwarder(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_ordinal(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_frameSize(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_exceptionHandlerAddressSection(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_exceptionHandlerAddressOffset(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_exceptionHandlerRelativeVirtualAddress(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_exceptionHandlerVirtualAddress(
            [Out] out long pRetVal);

        [PreserveSig]
        new HRESULT findInputAssemblyFile(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);

        [PreserveSig]
        new HRESULT get_characteristics(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_coffGroup(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        [PreserveSig]
        new HRESULT get_bindID(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_bindSpace(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_bindSlot(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_isObjCClass(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_isObjCCategory(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_isObjCProtocol(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_inlinee(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        [PreserveSig]
        new HRESULT get_inlineeId(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT get_noexcept(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_hasAbsoluteAddress(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        new HRESULT get_isStaticMemberFunc(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);
#endif

        [PreserveSig]
        HRESULT get_isSignRet(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);
    }
}
