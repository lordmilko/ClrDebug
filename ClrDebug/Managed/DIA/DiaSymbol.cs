using System;
using System.Diagnostics;
using System.Linq;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Describes the properties of a symbol instance.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling one of the following methods:
    /// </remarks>
    public class DiaSymbol : ComObject<IDiaSymbol>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaSymbol"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaSymbol(IDiaSymbol raw) : base(raw)
        {
        }

        #region IDiaSymbol
        #region SymIndexId

        /// <summary>
        /// Retrieves the unique symbol identifier.
        /// </summary>
        public int SymIndexId
        {
            get
            {
                int pRetVal;
                TryGetSymIndexId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the unique symbol identifier.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the symbol ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        public HRESULT TryGetSymIndexId(out int pRetVal)
        {
            /*HRESULT get_symIndexId(
            [Out] out int pRetVal);*/
            return Raw.get_symIndexId(out pRetVal);
        }

        #endregion
        #region SymTag

        /// <summary>
        /// Retrieves the symbol type classifier.
        /// </summary>
        public SymTagEnum SymTag
        {
            get
            {
                SymTagEnum pRetVal;
                TryGetSymTag(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the symbol type classifier.
        /// </summary>
        /// <param name="pRetVal">[out] Returns A value from the SymTagEnum Enumeration enumeration that specifies the symbol type classifier.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetSymTag(out SymTagEnum pRetVal)
        {
            /*HRESULT get_symTag(
            [Out] out SymTagEnum pRetVal);*/
            return Raw.get_symTag(out pRetVal);
        }

        #endregion
        #region Name

        /// <summary>
        /// Retrieves the name of the symbol.
        /// </summary>
        public string Name
        {
            get
            {
                string pRetVal;
                TryGetName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the name of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the name of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetName(out string pRetVal)
        {
            /*HRESULT get_name(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_name(out pRetVal);
        }

        #endregion
        #region LexicalParent

        /// <summary>
        /// Retrieves a reference to the lexical parent of the symbol.
        /// </summary>
        public DiaSymbol LexicalParent
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetLexicalParent(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves a reference to the lexical parent of the symbol.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object that represents the lexical parent of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// The lexical parent of a symbol is the enclosing function or module. For example, the lexical parent of a function
        /// parameter or local variable is the function itself while the lexical parent of the function is the module it is
        /// defined in. The possible symbols that can appear as lexical parents are documented in Lexical Hierarchy of Symbol
        /// Types.
        /// </remarks>
        public HRESULT TryGetLexicalParent(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_lexicalParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_lexicalParent(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region ClassParent

        /// <summary>
        /// Retrieves a reference to the class parent of the symbol.
        /// </summary>
        public DiaSymbol ClassParent
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetClassParent(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves a reference to the class parent of the symbol.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object that represents the class parent of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The types of symbols that can be class parents are documented in Class Hierarchy of Symbol Types.
        /// </remarks>
        public HRESULT TryGetClassParent(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_classParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_classParent(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region Type

        /// <summary>
        /// Retrieves the symbol that represents the type for this symbol.
        /// </summary>
        public DiaSymbol Type
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetType(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the symbol that represents the type for this symbol.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object that represents the type of this symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// To determine the type a symbol has, you must call this method and examine the resulting IDiaSymbol object. Note
        /// that it is possible for a symbol to not have a type. For example, the name of a structure has no type but it might
        /// have children symbols (use the IDiaSymbol method to examine those children).
        /// </remarks>
        public HRESULT TryGetType(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_type(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_type(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region DataKind

        /// <summary>
        /// Retrieves the variable classification of a data symbol.
        /// </summary>
        public DataKind DataKind
        {
            get
            {
                DataKind pRetVal;
                TryGetDataKind(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the variable classification of a data symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the DataKind Enumeration enumeration specifying the kind of data such as global, static, or constant, for example.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetDataKind(out DataKind pRetVal)
        {
            /*HRESULT get_dataKind(
            [Out] out DataKind pRetVal);*/
            return Raw.get_dataKind(out pRetVal);
        }

        #endregion
        #region LocationType

        /// <summary>
        /// Retrieves the location type of a data symbol.
        /// </summary>
        public LocationType LocationType
        {
            get
            {
                LocationType pRetVal;
                TryGetLocationType(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the location type of a data symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the LocationType Enumeration enumeration that specifies the location type of a data symbol, such as static or local.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetLocationType(out LocationType pRetVal)
        {
            /*HRESULT get_locationType(
            [Out] out LocationType pRetVal);*/
            return Raw.get_locationType(out pRetVal);
        }

        #endregion
        #region AddressSection

        /// <summary>
        /// Retrieves the section part of an address location. Use when the LocationType Enumeration is set to LocIsStatic.
        /// </summary>
        public int AddressSection
        {
            get
            {
                int pRetVal;
                TryGetAddressSection(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetAddressSection(out int pRetVal)
        {
            /*HRESULT get_addressSection(
            [Out] out int pRetVal);*/
            return Raw.get_addressSection(out pRetVal);
        }

        #endregion
        #region AddressOffset

        /// <summary>
        /// Retrieves the offset part of an address location. Use when the LocationType Enumeration is set to LocIsStatic.
        /// </summary>
        public int AddressOffset
        {
            get
            {
                int pRetVal;
                TryGetAddressOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetAddressOffset(out int pRetVal)
        {
            /*HRESULT get_addressOffset(
            [Out] out int pRetVal);*/
            return Raw.get_addressOffset(out pRetVal);
        }

        #endregion
        #region RelativeVirtualAddress

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the location. Use when the LocationType Enumeration is set to LocIsStatic.
        /// </summary>
        public int RelativeVirtualAddress
        {
            get
            {
                int pRetVal;
                TryGetRelativeVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the location. Use when the LocationType Enumeration is set to LocIsStatic.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the relative virtual address of the location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetRelativeVirtualAddress(out int pRetVal)
        {
            /*HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);*/
            return Raw.get_relativeVirtualAddress(out pRetVal);
        }

        #endregion
        #region VirtualAddress

        /// <summary>
        /// Retrieves the virtual address (VA) of the location. Use when the LocationType Enumeration is set to LocIsStatic.
        /// </summary>
        public long VirtualAddress
        {
            get
            {
                long pRetVal;
                TryGetVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the virtual address (VA) of the location. Use when the LocationType Enumeration is set to LocIsStatic.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the virtual address of the location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetVirtualAddress(out long pRetVal)
        {
            /*HRESULT get_virtualAddress(
            [Out] out long pRetVal);*/
            return Raw.get_virtualAddress(out pRetVal);
        }

        #endregion
        #region RegisterId

        /// <summary>
        /// Retrieves the register designator of the location when the LocationType Enumeration is set to LocIsEnregistered.
        /// </summary>
        public CV_HREG_e RegisterId
        {
            get
            {
                CV_HREG_e pRetVal;
                TryGetRegisterId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetRegisterId(out CV_HREG_e pRetVal)
        {
            /*HRESULT get_registerId(
            [Out] out CV_HREG_e pRetVal);*/
            return Raw.get_registerId(out pRetVal);
        }

        #endregion
        #region Offset

        /// <summary>
        /// Retrieves the offset of the symbol location. Use when the LocationType Enumeration is LocIsRegRel or LocIsBitField.
        /// </summary>
        public int Offset
        {
            get
            {
                int pRetVal;
                TryGetOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the offset of the symbol location. Use when the LocationType Enumeration is LocIsRegRel or LocIsBitField.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset in bytes of the symbol location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The offset is from some known point previously determined. For example, the offset for a LocIsBitField location
        /// type is typically from the start of the containing class.
        /// </remarks>
        public HRESULT TryGetOffset(out int pRetVal)
        {
            /*HRESULT get_offset(
            [Out] out int pRetVal);*/
            return Raw.get_offset(out pRetVal);
        }

        #endregion
        #region Length

        /// <summary>
        /// Retrieves the number of bits or bytes of memory used by the object represented by this symbol.
        /// </summary>
        public long Length
        {
            get
            {
                long pRetVal;
                TryGetLength(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of bits or bytes of memory used by the object represented by this symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes or bits of memory used by the object represented by this symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// If the LocationType Enumeration of the symbol is LocIsBitField, the length returned by this method is in bits;
        /// otherwise, the length is in bytes for all other location types.
        /// </remarks>
        public HRESULT TryGetLength(out long pRetVal)
        {
            /*HRESULT get_length(
            [Out] out long pRetVal);*/
            return Raw.get_length(out pRetVal);
        }

        #endregion
        #region Slot

        /// <summary>
        /// Retrieves the slot number of the location. Use when the LocationType Enumeration is LocIsSlot.
        /// </summary>
        public int Slot
        {
            get
            {
                int pRetVal;
                TryGetSlot(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the slot number of the location. Use when the LocationType Enumeration is LocIsSlot.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the slot number of the location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetSlot(out int pRetVal)
        {
            /*HRESULT get_slot(
            [Out] out int pRetVal);*/
            return Raw.get_slot(out pRetVal);
        }

        #endregion
        #region VolatileType

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type (UDT) is volatile.
        /// </summary>
        public bool VolatileType
        {
            get
            {
                bool pRetVal;
                TryGetVolatileType(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type (UDT) is volatile.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the UDT is volatile; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// In C++, a UDT can be marked with the volatile keyword, indicating that its contents cannot be assumed to exist
        /// from one access to the next.
        /// </remarks>
        public HRESULT TryGetVolatileType(out bool pRetVal)
        {
            /*HRESULT get_volatileType(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_volatileType(out pRetVal);
        }

        #endregion
        #region ConstType

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is constant.
        /// </summary>
        public bool ConstType
        {
            get
            {
                bool pRetVal;
                TryGetConstType(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is constant.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type is constant; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetConstType(out bool pRetVal)
        {
            /*HRESULT get_constType(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_constType(out pRetVal);
        }

        #endregion
        #region UnalignedType

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is unaligned.
        /// </summary>
        public bool UnalignedType
        {
            get
            {
                bool pRetVal;
                TryGetUnalignedType(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is unaligned.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type is unaligned; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetUnalignedType(out bool pRetVal)
        {
            /*HRESULT get_unalignedType(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_unalignedType(out pRetVal);
        }

        #endregion
        #region Access

        /// <summary>
        /// Retrieves the access modifier of a class member.
        /// </summary>
        public CV_access_e Access
        {
            get
            {
                CV_access_e pRetVal;
                TryGetAccess(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the access modifier of a class member.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the CV_access_e Enumeration enumeration that specifies the access modifier of a class member.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetAccess(out CV_access_e pRetVal)
        {
            /*HRESULT get_access(
            [Out] out CV_access_e pRetVal);*/
            return Raw.get_access(out pRetVal);
        }

        #endregion
        #region LibraryName

        /// <summary>
        /// Retrieves the file name of the library or object file from which the object was loaded.
        /// </summary>
        public string LibraryName
        {
            get
            {
                string pRetVal;
                TryGetLibraryName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the file name of the library or object file from which the object was loaded.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the file name of the library or object file from which the object was loaded.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetLibraryName(out string pRetVal)
        {
            /*HRESULT get_libraryName(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_libraryName(out pRetVal);
        }

        #endregion
        #region Platform

        /// <summary>
        /// Retrieves the platform type for which the compiland was compiled.
        /// </summary>
        public CV_CPU_TYPE_e Platform
        {
            get
            {
                CV_CPU_TYPE_e pRetVal;
                TryGetPlatform(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the platform type for which the compiland was compiled.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the CV_CPU_TYPE_e Enumeration enumeration that specifies the platform type for which the compiland was compiled.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetPlatform(out CV_CPU_TYPE_e pRetVal)
        {
            /*HRESULT get_platform(
            [Out] out CV_CPU_TYPE_e pRetVal);*/
            return Raw.get_platform(out pRetVal);
        }

        #endregion
        #region Language

        /// <summary>
        /// Retrieves the language of the source.
        /// </summary>
        public CV_CFL_LANG Language
        {
            get
            {
                CV_CFL_LANG pRetVal;
                TryGetLanguage(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the language of the source.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the CV_CFL_LANG Enumeration enumeration that specifies the language of the source.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetLanguage(out CV_CFL_LANG pRetVal)
        {
            /*HRESULT get_language(
            [Out] out CV_CFL_LANG pRetVal);*/
            return Raw.get_language(out pRetVal);
        }

        #endregion
        #region EditAndContinueEnabled

        /// <summary>
        /// Retrieves a flag indicating whether the module was compiled with the /Z7, /Zi, /ZI (Debug Information Format) compiler switch.
        /// </summary>
        public bool EditAndContinueEnabled
        {
            get
            {
                bool pRetVal;
                TryGetEditAndContinueEnabled(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag indicating whether the module was compiled with the /Z7, /Zi, /ZI (Debug Information Format) compiler switch.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if edit-and-continue was enabled at compilation; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetEditAndContinueEnabled(out bool pRetVal)
        {
            /*HRESULT get_editAndContinueEnabled(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_editAndContinueEnabled(out pRetVal);
        }

        #endregion
        #region FrontEndMajor

        /// <summary>
        /// Retrieves the front end major version number.
        /// </summary>
        public int FrontEndMajor
        {
            get
            {
                int pRetVal;
                TryGetFrontEndMajor(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetFrontEndMajor(out int pRetVal)
        {
            /*HRESULT get_frontEndMajor(
            [Out] out int pRetVal);*/
            return Raw.get_frontEndMajor(out pRetVal);
        }

        #endregion
        #region FrontEndMinor

        /// <summary>
        /// Retrieves the front end minor version number.
        /// </summary>
        public int FrontEndMinor
        {
            get
            {
                int pRetVal;
                TryGetFrontEndMinor(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetFrontEndMinor(out int pRetVal)
        {
            /*HRESULT get_frontEndMinor(
            [Out] out int pRetVal);*/
            return Raw.get_frontEndMinor(out pRetVal);
        }

        #endregion
        #region FrontEndBuild

        /// <summary>
        /// Retrieves the front end build number.
        /// </summary>
        public int FrontEndBuild
        {
            get
            {
                int pRetVal;
                TryGetFrontEndBuild(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetFrontEndBuild(out int pRetVal)
        {
            /*HRESULT get_frontEndBuild(
            [Out] out int pRetVal);*/
            return Raw.get_frontEndBuild(out pRetVal);
        }

        #endregion
        #region BackEndMajor

        /// <summary>
        /// Retrieves the back-end major version number of the compiler.
        /// </summary>
        public int BackEndMajor
        {
            get
            {
                int pRetVal;
                TryGetBackEndMajor(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetBackEndMajor(out int pRetVal)
        {
            /*HRESULT get_backEndMajor(
            [Out] out int pRetVal);*/
            return Raw.get_backEndMajor(out pRetVal);
        }

        #endregion
        #region BackEndMinor

        /// <summary>
        /// Retrieves the back end minor version number of the compiler.
        /// </summary>
        public int BackEndMinor
        {
            get
            {
                int pRetVal;
                TryGetBackEndMinor(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetBackEndMinor(out int pRetVal)
        {
            /*HRESULT get_backEndMinor(
            [Out] out int pRetVal);*/
            return Raw.get_backEndMinor(out pRetVal);
        }

        #endregion
        #region BackEndBuild

        /// <summary>
        /// Retrieves the back end build number of the compiler.
        /// </summary>
        public int BackEndBuild
        {
            get
            {
                int pRetVal;
                TryGetBackEndBuild(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetBackEndBuild(out int pRetVal)
        {
            /*HRESULT get_backEndBuild(
            [Out] out int pRetVal);*/
            return Raw.get_backEndBuild(out pRetVal);
        }

        #endregion
        #region SourceFileName

        /// <summary>
        /// Retrieves the file name of the compiland source file.
        /// </summary>
        public string SourceFileName
        {
            get
            {
                string pRetVal;
                TryGetSourceFileName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the file name of the compiland source file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the file name of the compiland source file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetSourceFileName(out string pRetVal)
        {
            /*HRESULT get_sourceFileName(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_sourceFileName(out pRetVal);
        }

        #endregion
        #region Unused

        public string Unused
        {
            get
            {
                string pRetVal;
                TryGetUnused(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetUnused(out string pRetVal)
        {
            /*HRESULT get_unused(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_unused(out pRetVal);
        }

        #endregion
        #region ThunkOrdinal

        /// <summary>
        /// Retrieves the thunk type of a function.
        /// </summary>
        public THUNK_ORDINAL ThunkOrdinal
        {
            get
            {
                THUNK_ORDINAL pRetVal;
                TryGetThunkOrdinal(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetThunkOrdinal(out THUNK_ORDINAL pRetVal)
        {
            /*HRESULT get_thunkOrdinal(
            [Out] out THUNK_ORDINAL pRetVal);*/
            return Raw.get_thunkOrdinal(out pRetVal);
        }

        #endregion
        #region ThisAdjust

        /// <summary>
        /// Retrieves the logical this adjustor for the method.
        /// </summary>
        public int ThisAdjust
        {
            get
            {
                int pRetVal;
                TryGetThisAdjust(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the logical this adjustor for the method.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the logical this adjustor for the method.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// In some multiple inheritance cases the method itself must calculate a true this value by adding an offset to this.
        /// </remarks>
        public HRESULT TryGetThisAdjust(out int pRetVal)
        {
            /*HRESULT get_thisAdjust(
            [Out] out int pRetVal);*/
            return Raw.get_thisAdjust(out pRetVal);
        }

        #endregion
        #region VirtualBaseOffset

        /// <summary>
        /// Retrieves the offset in the virtual function table of a virtual function.
        /// </summary>
        public int VirtualBaseOffset
        {
            get
            {
                int pRetVal;
                TryGetVirtualBaseOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the offset in the virtual function table of a virtual function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset in the virtual function table of a virtual function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetVirtualBaseOffset(out int pRetVal)
        {
            /*HRESULT get_virtualBaseOffset(
            [Out] out int pRetVal);*/
            return Raw.get_virtualBaseOffset(out pRetVal);
        }

        #endregion
        #region Virtual

        /// <summary>
        /// Retrieves a flag that specifies whether the function is virtual.
        /// </summary>
        public bool Virtual
        {
            get
            {
                bool pRetVal;
                TryGetVirtual(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function is virtual.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function is virtual; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetVirtual(out bool pRetVal)
        {
            /*HRESULT get_virtual(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_virtual(out pRetVal);
        }

        #endregion
        #region Intro

        /// <summary>
        /// Retrieves a flag that specifies whether the function is an introducing virtual function.
        /// </summary>
        public bool Intro
        {
            get
            {
                bool pRetVal;
                TryGetIntro(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function is an introducing virtual function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function is intro virtual; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetIntro(out bool pRetVal)
        {
            /*HRESULT get_intro(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_intro(out pRetVal);
        }

        #endregion
        #region Pure

        /// <summary>
        /// Retrieves a flag that specifies whether the function is pure virtual.
        /// </summary>
        public bool Pure
        {
            get
            {
                bool pRetVal;
                TryGetPure(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function is pure virtual.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function is pure virtual; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetPure(out bool pRetVal)
        {
            /*HRESULT get_pure(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_pure(out pRetVal);
        }

        #endregion
        #region CallingConvention

        /// <summary>
        /// Returns an indicator of a methods calling convention.
        /// </summary>
        public CV_call_e CallingConvention
        {
            get
            {
                CV_call_e pRetVal;
                TryGetCallingConvention(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Returns an indicator of a methods calling convention.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the CV_call_e Enumeration enumeration that specifies a method's calling convention.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetCallingConvention(out CV_call_e pRetVal)
        {
            /*HRESULT get_callingConvention(
            [Out] out CV_call_e pRetVal);*/
            return Raw.get_callingConvention(out pRetVal);
        }

        #endregion
        #region Value

        /// <summary>
        /// Retrieves the value of a constant.
        /// </summary>
        public object Value
        {
            get
            {
                object pRetVal;
                TryGetValue(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the value of a constant.
        /// </summary>
        /// <param name="pRetVal">[in, out] A VARIANT object that is filled in with the value of a constant.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The supplied VARIANT must be initialized before it is passed to this method. For more information, see the example.
        /// </remarks>
        public HRESULT TryGetValue(out object pRetVal)
        {
            /*HRESULT get_value(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pRetVal);*/
            return Raw.get_value(out pRetVal);
        }

        #endregion
        #region BaseType

        /// <summary>
        /// Retrieves the base type for this symbol.
        /// </summary>
        public BasicType BaseType
        {
            get
            {
                BasicType pRetVal;
                TryGetBaseType(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the base type for this symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the BasicType Enumeration enumeration specifying the base type of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The basic type for a symbol can be determined by first getting the type of the symbol and then interrogating that
        /// returned type for the base type. Note that some symbols may not have a base type—for example, a structure name.
        /// </remarks>
        public HRESULT TryGetBaseType(out BasicType pRetVal)
        {
            /*HRESULT get_baseType(
            [Out] out BasicType pRetVal);*/
            return Raw.get_baseType(out pRetVal);
        }

        #endregion
        #region Token

        /// <summary>
        /// Retrieves the metadata token of a managed function or variable.
        /// </summary>
        public int Token
        {
            get
            {
                int pRetVal;
                TryGetToken(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the metadata token of a managed function or variable.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the metadata token of a managed function or variable.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetToken(out int pRetVal)
        {
            /*HRESULT get_token(
            [Out] out int pRetVal);*/
            return Raw.get_token(out pRetVal);
        }

        #endregion
        #region TimeStamp

        /// <summary>
        /// Retrieves the timestamp of the underlying executable file.
        /// </summary>
        public int TimeStamp
        {
            get
            {
                int pRetVal;
                TryGetTimeStamp(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the timestamp of the underlying executable file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the timestamp of the underlying executable file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetTimeStamp(out int pRetVal)
        {
            /*HRESULT get_timeStamp(
            [Out] out int pRetVal);*/
            return Raw.get_timeStamp(out pRetVal);
        }

        #endregion
        #region Guid

        /// <summary>
        /// Retrieves the symbol's globally unique identifier (GUID).
        /// </summary>
        public Guid Guid
        {
            get
            {
                Guid pRetVal;
                TryGetGuid(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the symbol's globally unique identifier (GUID).
        /// </summary>
        /// <param name="pRetVal">[out] Returns the symbol's GUID.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetGuid(out Guid pRetVal)
        {
            /*HRESULT get_guid(
            [Out] out Guid pRetVal);*/
            return Raw.get_guid(out pRetVal);
        }

        #endregion
        #region SymbolsFileName

        /// <summary>
        /// Retrieves the name of the file from which the symbols were loaded.
        /// </summary>
        public string SymbolsFileName
        {
            get
            {
                string pRetVal;
                TryGetSymbolsFileName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the name of the file from which the symbols were loaded.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the name of the file from which the symbols were loaded.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is valid only for symbols with a SymTagEnum Enumeration value of SymTagExe that also have global
        /// scope.
        /// </remarks>
        public HRESULT TryGetSymbolsFileName(out string pRetVal)
        {
            /*HRESULT get_symbolsFileName(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_symbolsFileName(out pRetVal);
        }

        #endregion
        #region Reference

        /// <summary>
        /// Retrieves a flag that specifies whether a pointer type is a reference.
        /// </summary>
        public bool Reference
        {
            get
            {
                bool pRetVal;
                TryGetReference(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether a pointer type is a reference.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if a pointer type is a reference; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetReference(out bool pRetVal)
        {
            /*HRESULT get_reference(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_reference(out pRetVal);
        }

        #endregion
        #region Count

        /// <summary>
        /// Retrieves the number of items in a list or array.
        /// </summary>
        public int Count
        {
            get
            {
                int pRetVal;
                TryGetCount(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of items in a list or array.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of items in a list or array.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetCount(out int pRetVal)
        {
            /*HRESULT get_count(
            [Out] out int pRetVal);*/
            return Raw.get_count(out pRetVal);
        }

        #endregion
        #region BitPosition

        /// <summary>
        /// Retrieves the bit position of location. Used when the LocationType Enumeration is LocIsBitField.
        /// </summary>
        public int BitPosition
        {
            get
            {
                int pRetVal;
                TryGetBitPosition(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the bit position of location. Used when the LocationType Enumeration is LocIsBitField.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the bit position of the location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetBitPosition(out int pRetVal)
        {
            /*HRESULT get_bitPosition(
            [Out] out int pRetVal);*/
            return Raw.get_bitPosition(out pRetVal);
        }

        #endregion
        #region ArrayIndexType

        /// <summary>
        /// Retrieves the symbol interface of the array index type of the symbol.
        /// </summary>
        public DiaSymbol ArrayIndexType
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetArrayIndexType(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the symbol interface of the array index type of the symbol.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object that represents the array index type of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// Some languages can specify the type used as an index to an array. The symbol returned from this method specifies
        /// that type.
        /// </remarks>
        public HRESULT TryGetArrayIndexType(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_arrayIndexType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_arrayIndexType(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region Packed

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type (UDT) is packed.
        /// </summary>
        public bool Packed
        {
            get
            {
                bool pRetVal;
                TryGetPacked(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type (UDT) is packed.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the UDT is packed; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// Packed means all the members of the UDT are positioned as close together as possible, with no intervening padding
        /// to align to memory boundaries.
        /// </remarks>
        public HRESULT TryGetPacked(out bool pRetVal)
        {
            /*HRESULT get_packed(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_packed(out pRetVal);
        }

        #endregion
        #region Constructor

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has a constructor or destructor.
        /// </summary>
        public bool Constructor
        {
            get
            {
                bool pRetVal;
                TryGetConstructor(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has a constructor or destructor.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type has a constructor or destructor; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetConstructor(out bool pRetVal)
        {
            /*HRESULT get_constructor(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_constructor(out pRetVal);
        }

        #endregion
        #region OverloadedOperator

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has overloaded operators.
        /// </summary>
        public bool OverloadedOperator
        {
            get
            {
                bool pRetVal;
                TryGetOverloadedOperator(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has overloaded operators.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type has overloaded operators; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetOverloadedOperator(out bool pRetVal)
        {
            /*HRESULT get_overloadedOperator(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_overloadedOperator(out pRetVal);
        }

        #endregion
        #region Nested

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is nested.
        /// </summary>
        public bool Nested
        {
            get
            {
                bool pRetVal;
                TryGetNested(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is nested.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type is nested; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetNested(out bool pRetVal)
        {
            /*HRESULT get_nested(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_nested(out pRetVal);
        }

        #endregion
        #region HasNestedTypes

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has nested type definitions.
        /// </summary>
        public bool HasNestedTypes
        {
            get
            {
                bool pRetVal;
                TryGetHasNestedTypes(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has nested type definitions.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type has nested type definitions; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetHasNestedTypes(out bool pRetVal)
        {
            /*HRESULT get_hasNestedTypes(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasNestedTypes(out pRetVal);
        }

        #endregion
        #region HasAssignmentOperator

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has any assignment operators defined.
        /// </summary>
        public bool HasAssignmentOperator
        {
            get
            {
                bool pRetVal;
                TryGetHasAssignmentOperator(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has any assignment operators defined.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type has any assignment operators defined; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetHasAssignmentOperator(out bool pRetVal)
        {
            /*HRESULT get_hasAssignmentOperator(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasAssignmentOperator(out pRetVal);
        }

        #endregion
        #region HasCastOperator

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has any cast operators defined.
        /// </summary>
        public bool HasCastOperator
        {
            get
            {
                bool pRetVal;
                TryGetHasCastOperator(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type has any cast operators defined.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a TRUE if the user-defined data type has any cast operators defined; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetHasCastOperator(out bool pRetVal)
        {
            /*HRESULT get_hasCastOperator(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasCastOperator(out pRetVal);
        }

        #endregion
        #region Scoped

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type appears in a non-global lexical scope.
        /// </summary>
        public bool Scoped
        {
            get
            {
                bool pRetVal;
                TryGetScoped(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type appears in a non-global lexical scope.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type appears in a non-global lexical scope; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetScoped(out bool pRetVal)
        {
            /*HRESULT get_scoped(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_scoped(out pRetVal);
        }

        #endregion
        #region VirtualBaseClass

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is a virtual base class.
        /// </summary>
        public bool VirtualBaseClass
        {
            get
            {
                bool pRetVal;
                TryGetVirtualBaseClass(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is a virtual base class.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type is a virtual base class; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetVirtualBaseClass(out bool pRetVal)
        {
            /*HRESULT get_virtualBaseClass(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_virtualBaseClass(out pRetVal);
        }

        #endregion
        #region IndirectVirtualBaseClass

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is an indirect virtual base class.
        /// </summary>
        public bool IndirectVirtualBaseClass
        {
            get
            {
                bool pRetVal;
                TryGetIndirectVirtualBaseClass(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined data type is an indirect virtual base class.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the user-defined data type is an indirect virtual base class; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetIndirectVirtualBaseClass(out bool pRetVal)
        {
            /*HRESULT get_indirectVirtualBaseClass(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_indirectVirtualBaseClass(out pRetVal);
        }

        #endregion
        #region VirtualBasePointerOffset

        /// <summary>
        /// Retrieves the offset of the virtual base pointer.
        /// </summary>
        public int VirtualBasePointerOffset
        {
            get
            {
                int pRetVal;
                TryGetVirtualBasePointerOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the offset of the virtual base pointer.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset of the virtual base pointer.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetVirtualBasePointerOffset(out int pRetVal)
        {
            /*HRESULT get_virtualBasePointerOffset(
            [Out] out int pRetVal);*/
            return Raw.get_virtualBasePointerOffset(out pRetVal);
        }

        #endregion
        #region VirtualTableShape

        /// <summary>
        /// Retrieves the symbol interface of the type of the virtual table for a user-defined type.
        /// </summary>
        public DiaSymbol VirtualTableShape
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetVirtualTableShape(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the symbol interface of the type of the virtual table for a user-defined type.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object representing the virtual table for a user-defined type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetVirtualTableShape(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_virtualTableShape(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_virtualTableShape(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region LexicalParentId

        /// <summary>
        /// Retrieves the lexical parent identifier of the symbol.
        /// </summary>
        public int LexicalParentId
        {
            get
            {
                int pRetVal;
                TryGetLexicalParentId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the lexical parent identifier of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the lexical parent ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        public HRESULT TryGetLexicalParentId(out int pRetVal)
        {
            /*HRESULT get_lexicalParentId(
            [Out] out int pRetVal);*/
            return Raw.get_lexicalParentId(out pRetVal);
        }

        #endregion
        #region ClassParentId

        /// <summary>
        /// Retrieves the class parent identifier of the symbol.
        /// </summary>
        public int ClassParentId
        {
            get
            {
                int pRetVal;
                TryGetClassParentId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the class parent identifier of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the class parent ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        public HRESULT TryGetClassParentId(out int pRetVal)
        {
            /*HRESULT get_classParentId(
            [Out] out int pRetVal);*/
            return Raw.get_classParentId(out pRetVal);
        }

        #endregion
        #region TypeId

        /// <summary>
        /// Retrieves the type identifier of the symbol.
        /// </summary>
        public int TypeId
        {
            get
            {
                int pRetVal;
                TryGetTypeId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the type identifier of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the type ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        public HRESULT TryGetTypeId(out int pRetVal)
        {
            /*HRESULT get_typeId(
            [Out] out int pRetVal);*/
            return Raw.get_typeId(out pRetVal);
        }

        #endregion
        #region ArrayIndexTypeId

        /// <summary>
        /// Retrieves the array index type identifier of the symbol.
        /// </summary>
        public int ArrayIndexTypeId
        {
            get
            {
                int pRetVal;
                TryGetArrayIndexTypeId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the array index type identifier of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the array index type ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        public HRESULT TryGetArrayIndexTypeId(out int pRetVal)
        {
            /*HRESULT get_arrayIndexTypeId(
            [Out] out int pRetVal);*/
            return Raw.get_arrayIndexTypeId(out pRetVal);
        }

        #endregion
        #region VirtualTableShapeId

        /// <summary>
        /// Retrieves the virtual table shape symbol identifier of the symbol.
        /// </summary>
        public int VirtualTableShapeId
        {
            get
            {
                int pRetVal;
                TryGetVirtualTableShapeId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the virtual table shape symbol identifier of the symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the virtual table shape symbol ID of the symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        public HRESULT TryGetVirtualTableShapeId(out int pRetVal)
        {
            /*HRESULT get_virtualTableShapeId(
            [Out] out int pRetVal);*/
            return Raw.get_virtualTableShapeId(out pRetVal);
        }

        #endregion
        #region Code

        /// <summary>
        /// Retrieves a flag that specifies whether the symbol refers to a code address.
        /// </summary>
        public bool Code
        {
            get
            {
                bool pRetVal;
                TryGetCode(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the symbol refers to a code address.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the symbol refers to a code address, otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetCode(out bool pRetVal)
        {
            /*HRESULT get_code(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_code(out pRetVal);
        }

        #endregion
        #region Function

        /// <summary>
        /// Retrieves a flag that specifies whether the public symbol refers to a function.
        /// </summary>
        public bool Function
        {
            get
            {
                bool pRetVal;
                TryGetFunction(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the public symbol refers to a function.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a TRUE if the symbol refers to a function; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetFunction(out bool pRetVal)
        {
            /*HRESULT get_function(
            [Out] out bool pRetVal);*/
            return Raw.get_function(out pRetVal);
        }

        #endregion
        #region Managed

        /// <summary>
        /// Retrieves a flag that specifies whether the symbol refers to managed code.
        /// </summary>
        public bool Managed
        {
            get
            {
                bool pRetVal;
                TryGetManaged(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the symbol refers to managed code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the symbol refers to managed code; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetManaged(out bool pRetVal)
        {
            /*HRESULT get_managed(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_managed(out pRetVal);
        }

        #endregion
        #region Msil

        /// <summary>
        /// Retrieves a flag that specifies whether the symbol refers to Microsoft Intermediate Language (MSIL) code.
        /// </summary>
        public bool Msil
        {
            get
            {
                bool pRetVal;
                TryGetMsil(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the symbol refers to Microsoft Intermediate Language (MSIL) code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the symbol refers to MSIL code; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetMsil(out bool pRetVal)
        {
            /*HRESULT get_msil(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_msil(out pRetVal);
        }

        #endregion
        #region VirtualBaseDispIndex

        /// <summary>
        /// Retrieves the index of the symbol in the virtual base displacement table.
        /// </summary>
        public int VirtualBaseDispIndex
        {
            get
            {
                int pRetVal;
                TryGetVirtualBaseDispIndex(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the index of the symbol in the virtual base displacement table.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the index into the virtual base displacement table.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetVirtualBaseDispIndex(out int pRetVal)
        {
            /*HRESULT get_virtualBaseDispIndex(
            [Out] out int pRetVal);*/
            return Raw.get_virtualBaseDispIndex(out pRetVal);
        }

        #endregion
        #region UndecoratedName

        /// <summary>
        /// Retrieves the undecorated name for a C++ decorated, or linkage, name.
        /// </summary>
        public string UndecoratedName
        {
            get
            {
                string pRetVal;
                TryGetUndecoratedName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the undecorated name for a C++ decorated, or linkage, name.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the undecorated name for a C++ decorated name.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetUndecoratedName(out string pRetVal)
        {
            /*HRESULT get_undecoratedName(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_undecoratedName(out pRetVal);
        }

        #endregion
        #region Age

        /// <summary>
        /// Retrieves the age value of a .pdb file.
        /// </summary>
        public int Age
        {
            get
            {
                int pRetVal;
                TryGetAge(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the age value of a .pdb file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the age value of a .pdb file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// The age does not necessarily correspond to any known time value; it is typically used to determine if a .pdb file
        /// is out of sync with a corresponding .exe file.
        /// </remarks>
        public HRESULT TryGetAge(out int pRetVal)
        {
            /*HRESULT get_age(
            [Out] out int pRetVal);*/
            return Raw.get_age(out pRetVal);
        }

        #endregion
        #region Signature

        /// <summary>
        /// Retrieves the symbol's signature value.
        /// </summary>
        public int Signature
        {
            get
            {
                int pRetVal;
                TryGetSignature(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the symbol's signature value.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the symbol's signature value.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetSignature(out int pRetVal)
        {
            /*HRESULT get_signature(
            [Out] out int pRetVal);*/
            return Raw.get_signature(out pRetVal);
        }

        #endregion
        #region CompilerGenerated

        /// <summary>
        /// Retrieves a flag that indicates whether the symbol was generated by the compiler.
        /// </summary>
        public bool CompilerGenerated
        {
            get
            {
                bool pRetVal;
                TryGetCompilerGenerated(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the symbol was generated by the compiler.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the compiler generated the symbol; otherwise, returns FALSE if the symbol was generated from user-written source.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetCompilerGenerated(out bool pRetVal)
        {
            /*HRESULT get_compilerGenerated(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_compilerGenerated(out pRetVal);
        }

        #endregion
        #region AddressTaken

        /// <summary>
        /// Retrieves a flag that indicates whether another symbol references this symbol's address.
        /// </summary>
        public bool AddressTaken
        {
            get
            {
                bool pRetVal;
                TryGetAddressTaken(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether another symbol references this symbol's address.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if another symbol references this address; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetAddressTaken(out bool pRetVal)
        {
            /*HRESULT get_addressTaken(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_addressTaken(out pRetVal);
        }

        #endregion
        #region Rank

        /// <summary>
        /// Retrieves the rank (number of dimensions) of a FORTRAN multi-dimensional array.
        /// </summary>
        public int Rank
        {
            get
            {
                int pRetVal;
                TryGetRank(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetRank(out int pRetVal)
        {
            /*HRESULT get_rank(
            [Out] out int pRetVal);*/
            return Raw.get_rank(out pRetVal);
        }

        #endregion
        #region LowerBound

        /// <summary>
        /// Retrieves the lower bound of a FORTRAN array dimension.
        /// </summary>
        public DiaSymbol LowerBound
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetLowerBound(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the lower bound of a FORTRAN array dimension.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object that represents the lower bound of a FORTRAN array dimension.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetLowerBound(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_lowerBound(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_lowerBound(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region UpperBound

        /// <summary>
        /// Retrieves a symbol representing the upper bound of a FORTRAN array dimension.
        /// </summary>
        public DiaSymbol UpperBound
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetUpperBound(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves a symbol representing the upper bound of a FORTRAN array dimension.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object that represents the upper bound of a FORTRAN array dimension.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetUpperBound(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_upperBound(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_upperBound(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region LowerBoundId

        /// <summary>
        /// Retrieves the symbol identifier of the lower bound of a FORTRAN array dimension.
        /// </summary>
        public int LowerBoundId
        {
            get
            {
                int pRetVal;
                TryGetLowerBoundId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the symbol identifier of the lower bound of a FORTRAN array dimension.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the symbol ID of the symbol that represents the lower bound of a FORTRAN array dimension.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        public HRESULT TryGetLowerBoundId(out int pRetVal)
        {
            /*HRESULT get_lowerBoundId(
            [Out] out int pRetVal);*/
            return Raw.get_lowerBoundId(out pRetVal);
        }

        #endregion
        #region UpperBoundId

        /// <summary>
        /// Retrieves the symbol identifier of the upper bound of a FORTRAN array dimension.
        /// </summary>
        public int UpperBoundId
        {
            get
            {
                int pRetVal;
                TryGetUpperBoundId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the symbol identifier of the upper bound of a FORTRAN array dimension.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique.
        /// </remarks>
        public HRESULT TryGetUpperBoundId(out int pRetVal)
        {
            /*HRESULT get_upperBoundId(
            [Out] out int pRetVal);*/
            return Raw.get_upperBoundId(out pRetVal);
        }

        #endregion
        #region DataBytes

        /// <summary>
        /// Retrieves the data bytes of an OEM symbol.
        /// </summary>
        public byte[] DataBytes
        {
            get
            {
                byte[] data;
                TryGetDataBytes(out data).ThrowOnNotOK();

                return data;
            }
        }

        /// <summary>
        /// Retrieves the data bytes of an OEM symbol.
        /// </summary>
        /// <param name="data">[out] A buffer that is filled in with the data bytes.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetDataBytes(out byte[] data)
        {
            /*HRESULT get_dataBytes(
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] data);*/
            int cbData = 0;
            int pcbData;
            data = null;
            HRESULT hr = Raw.get_dataBytes(cbData, out pcbData, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbData = pcbData;
            data = new byte[cbData];
            hr = Raw.get_dataBytes(cbData, out pcbData, data);
            fail:
            return hr;
        }

        #endregion
        #region TargetSection

        /// <summary>
        /// Retrieves the address section of a thunk target.
        /// </summary>
        public int TargetSection
        {
            get
            {
                int pRetVal;
                TryGetTargetSection(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the address section of a thunk target.
        /// </summary>
        /// <param name="pRetVal">[out] Section part of a thunk target address.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetTargetSection(out int pRetVal)
        {
            /*HRESULT get_targetSection(
            [Out] out int pRetVal);*/
            return Raw.get_targetSection(out pRetVal);
        }

        #endregion
        #region TargetOffset

        /// <summary>
        /// Retrieves the offset section of a thunk target.
        /// </summary>
        public int TargetOffset
        {
            get
            {
                int pRetVal;
                TryGetTargetOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the offset section of a thunk target.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of a thunk target address.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetTargetOffset(out int pRetVal)
        {
            /*HRESULT get_targetOffset(
            [Out] out int pRetVal);*/
            return Raw.get_targetOffset(out pRetVal);
        }

        #endregion
        #region TargetRelativeVirtualAddress

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of a thunk target.
        /// </summary>
        public int TargetRelativeVirtualAddress
        {
            get
            {
                int pRetVal;
                TryGetTargetRelativeVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetTargetRelativeVirtualAddress(out int pRetVal)
        {
            /*HRESULT get_targetRelativeVirtualAddress(
            [Out] out int pRetVal);*/
            return Raw.get_targetRelativeVirtualAddress(out pRetVal);
        }

        #endregion
        #region TargetVirtualAddress

        /// <summary>
        /// Retrieves the virtual address (VA) of a thunk target.
        /// </summary>
        public long TargetVirtualAddress
        {
            get
            {
                long pRetVal;
                TryGetTargetVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

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
        public HRESULT TryGetTargetVirtualAddress(out long pRetVal)
        {
            /*HRESULT get_targetVirtualAddress(
            [Out] out long pRetVal);*/
            return Raw.get_targetVirtualAddress(out pRetVal);
        }

        #endregion
        #region MachineType

        /// <summary>
        /// Retrieves the type of the target CPU.
        /// </summary>
        public IMAGE_FILE_MACHINE MachineType
        {
            get
            {
                IMAGE_FILE_MACHINE pRetVal;
                TryGetMachineType(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the type of the target CPU.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the IMAGE_FILE_MACHINE that specifies the target CPU type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetMachineType(out IMAGE_FILE_MACHINE pRetVal)
        {
            /*HRESULT get_machineType(
            [Out] out IMAGE_FILE_MACHINE pRetVal);*/
            return Raw.get_machineType(out pRetVal);
        }

        #endregion
        #region OemId

        /// <summary>
        /// Retrieves the symbol's original equipment manufacturer (OEM) ID value.
        /// </summary>
        public int OemId
        {
            get
            {
                int pRetVal;
                TryGetOemId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the symbol's original equipment manufacturer (OEM) ID value.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a unique value that identifies an OEM.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property applies only to symbols with a SymTagEnum Enumeration type of SymTagCustomType.
        /// </remarks>
        public HRESULT TryGetOemId(out int pRetVal)
        {
            /*HRESULT get_oemId(
            [Out] out int pRetVal);*/
            return Raw.get_oemId(out pRetVal);
        }

        #endregion
        #region OemSymbolId

        /// <summary>
        /// Retrieves the original equipment manufacturer (OEM) symbol's ID value.
        /// </summary>
        public int OemSymbolId
        {
            get
            {
                int pRetVal;
                TryGetOemSymbolId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the original equipment manufacturer (OEM) symbol's ID value.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an OEM's internally assigned symbol ID.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The identifier is a unique value created by the DIA SDK to mark all symbols as unique. This property applies only
        /// to symbols with a SymTagEnum Enumeration type of SymTagCustomType.
        /// </remarks>
        public HRESULT TryGetOemSymbolId(out int pRetVal)
        {
            /*HRESULT get_oemSymbolId(
            [Out] out int pRetVal);*/
            return Raw.get_oemSymbolId(out pRetVal);
        }

        #endregion
        #region Types

        /// <summary>
        /// Retrieves an array of compiler-specific types for this symbol.
        /// </summary>
        public DiaSymbol[] Types
        {
            get
            {
                DiaSymbol[] pTypesResult;
                TryGetTypes(out pTypesResult).ThrowOnNotOK();

                return pTypesResult;
            }
        }

        /// <summary>
        /// Retrieves an array of compiler-specific types for this symbol.
        /// </summary>
        /// <param name="pTypesResult">[out] An array that is to be filled in with the IDiaSymbol objects that represent all the types for this symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetTypes(out DiaSymbol[] pTypesResult)
        {
            /*HRESULT get_types(
            [In] int cTypes,
            [Out] out int pcTypes,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IDiaSymbol[] pTypes);*/
            int cTypes = 0;
            int pcTypes;
            IDiaSymbol[] pTypes;
            HRESULT hr = Raw.get_types(cTypes, out pcTypes, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cTypes = pcTypes;
            pTypes = new IDiaSymbol[cTypes];
            hr = Raw.get_types(cTypes, out pcTypes, pTypes);

            if (hr == HRESULT.S_OK)
            {
                pTypesResult = pTypes.Select(v => v == null ? null : new DiaSymbol(v)).ToArray();

                return hr;
            }

            fail:
            pTypesResult = default(DiaSymbol[]);

            return hr;
        }

        #endregion
        #region TypeIds

        /// <summary>
        /// Retrieves an array of compiler-specific type identifier values for this symbol.
        /// </summary>
        public int[] TypeIds
        {
            get
            {
                int[] pdwTypeIds;
                TryGetTypeIds(out pdwTypeIds).ThrowOnNotOK();

                return pdwTypeIds;
            }
        }

        /// <summary>
        /// Retrieves an array of compiler-specific type identifier values for this symbol.
        /// </summary>
        /// <param name="pdwTypeIds">[out] An array that is to be filled in with the type identifiers.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetTypeIds(out int[] pdwTypeIds)
        {
            /*HRESULT get_typeIds(
            [In] int cTypeIds,
            [Out] out int pcTypeIds,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] pdwTypeIds);*/
            int cTypeIds = 0;
            int pcTypeIds;
            pdwTypeIds = null;
            HRESULT hr = Raw.get_typeIds(cTypeIds, out pcTypeIds, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cTypeIds = pcTypeIds;
            pdwTypeIds = new int[cTypeIds];
            hr = Raw.get_typeIds(cTypeIds, out pcTypeIds, pdwTypeIds);
            fail:
            return hr;
        }

        #endregion
        #region ObjectPointerType

        /// <summary>
        /// Retrieves the type of the object pointer for a class method.
        /// </summary>
        public DiaSymbol ObjectPointerType
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetObjectPointerType(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the type of the object pointer for a class method.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object that represents the object pointer for a class method.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property applies only to symbols with a SymTagEnum Enumeration type of SymTagFunctionType.
        /// </remarks>
        public HRESULT TryGetObjectPointerType(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_objectPointerType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_objectPointerType(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region UdtKind

        /// <summary>
        /// Retrieves the variety of a user-defined type (UDT).
        /// </summary>
        public UdtKind UdtKind
        {
            get
            {
                UdtKind pRetVal;
                TryGetUdtKind(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the variety of a user-defined type (UDT).
        /// </summary>
        /// <param name="pRetVal">[out] Returns a value from the UdtKind Enumeration enumeration that specifies the kind of a UDT: structure, class, or union.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetUdtKind(out UdtKind pRetVal)
        {
            /*HRESULT get_udtKind(
            [Out] out UdtKind pRetVal);*/
            return Raw.get_udtKind(out pRetVal);
        }

        #endregion
        #region NoReturn

        /// <summary>
        /// Retrieves a flag that specifies whether the function has been marked as never returning with the noreturn attribute.
        /// </summary>
        public bool NoReturn
        {
            get
            {
                bool pRetVal;
                TryGetNoReturn(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function has been marked as never returning with the noreturn attribute.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has been declared as never returning with the noreturn attribute; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetNoReturn(out bool pRetVal)
        {
            /*HRESULT get_noReturn(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_noReturn(out pRetVal);
        }

        #endregion
        #region CustomCallingConvention

        /// <summary>
        /// Retrieves a flag that specifies whether the function has a custom calling convention.
        /// </summary>
        public bool CustomCallingConvention
        {
            get
            {
                bool pRetVal;
                TryGetCustomCallingConvention(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function has a custom calling convention.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has a custom calling convention; otherwise, returns FALSE, the function has a known calling convention.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetCustomCallingConvention(out bool pRetVal)
        {
            /*HRESULT get_customCallingConvention(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_customCallingConvention(out pRetVal);
        }

        #endregion
        #region NoInline

        /// <summary>
        /// Retrieves a flag that specifies whether the function has been marked as being not inline (using the noinline attribute).
        /// </summary>
        public bool NoInline
        {
            get
            {
                bool pRetVal;
                TryGetNoInline(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function has been marked as being not inline (using the noinline attribute).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has the noinline attribute; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetNoInline(out bool pRetVal)
        {
            /*HRESULT get_noInline(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_noInline(out pRetVal);
        }

        #endregion
        #region OptimizedCodeDebugInfo

        /// <summary>
        /// Retrieves a flag that indicates whether the function contains debug information that is specific for optimized code.
        /// </summary>
        public bool OptimizedCodeDebugInfo
        {
            get
            {
                bool pRetVal;
                TryGetOptimizedCodeDebugInfo(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the function contains debug information that is specific for optimized code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the optimized function or label contains debugging information; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetOptimizedCodeDebugInfo(out bool pRetVal)
        {
            /*HRESULT get_optimizedCodeDebugInfo(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_optimizedCodeDebugInfo(out pRetVal);
        }

        #endregion
        #region NotReached

        /// <summary>
        /// Retrieves a flag that specifies whether the function or label is never reached.
        /// </summary>
        public bool NotReached
        {
            get
            {
                bool pRetVal;
                TryGetNotReached(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function or label is never reached.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function or label is never reached; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetNotReached(out bool pRetVal)
        {
            /*HRESULT get_notReached(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_notReached(out pRetVal);
        }

        #endregion
        #region InterruptReturn

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a return from interrupt instruction (for example, the X86 assembly code iret).
        /// </summary>
        public bool InterruptReturn
        {
            get
            {
                bool pRetVal;
                TryGetInterruptReturn(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a return from interrupt instruction (for example, the X86 assembly code iret).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has a return from interrupt instruction; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetInterruptReturn(out bool pRetVal)
        {
            /*HRESULT get_interruptReturn(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_interruptReturn(out pRetVal);
        }

        #endregion
        #region FarReturn

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a far return.
        /// </summary>
        public bool FarReturn
        {
            get
            {
                bool pRetVal;
                TryGetFarReturn(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a far return.
        /// </summary>
        /// <param name="pRetVal">[in] Returns TRUE if the function uses a far return, otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetFarReturn(out bool pRetVal)
        {
            /*HRESULT get_farReturn(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_farReturn(out pRetVal);
        }

        #endregion
        #region IsStatic

        /// <summary>
        /// Retrieves a flag that specifies whether the function or thunk layer has been marked as static.
        /// </summary>
        public bool IsStatic
        {
            get
            {
                bool pRetVal;
                TryGetIsStatic(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function or thunk layer has been marked as static.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function or thunk layer has been marked as static; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsStatic(out bool pRetVal)
        {
            /*HRESULT get_isStatic(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isStatic(out pRetVal);
        }

        #endregion
        #region HasDebugInfo

        /// <summary>
        /// Retrieves a flag that specifies if the Compiland contains debugging information.
        /// </summary>
        public bool HasDebugInfo
        {
            get
            {
                bool pRetVal;
                TryGetHasDebugInfo(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies if the Compiland contains debugging information.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the compiland contains debugging information; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetHasDebugInfo(out bool pRetVal)
        {
            /*HRESULT get_hasDebugInfo(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasDebugInfo(out pRetVal);
        }

        #endregion
        #region IsLTCG

        /// <summary>
        /// Retrieves a flag that specifies whether the Compiland has been linked with the linker switch /LTCG (Link-time Code Generation), which aids in whole program optimization.<para/>
        /// This switch applies only to managed code.
        /// </summary>
        public bool IsLTCG
        {
            get
            {
                bool pRetVal;
                TryGetIsLTCG(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the Compiland has been linked with the linker switch /LTCG (Link-time Code Generation), which aids in whole program optimization.<para/>
        /// This switch applies only to managed code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the compiland was linked with the /LTCG linker switch; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsLTCG(out bool pRetVal)
        {
            /*HRESULT get_isLTCG(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isLTCG(out pRetVal);
        }

        #endregion
        #region IsDataAligned

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined type (UDT) has been aligned to some specific memory boundary.
        /// </summary>
        public bool IsDataAligned
        {
            get
            {
                bool pRetVal;
                TryGetIsDataAligned(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the user-defined type (UDT) has been aligned to some specific memory boundary.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the UDT has been aligned to some memory boundary; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// This property is generally set when the executable is compiled with nondefault data alignment. For example, the
        /// Microsoft C++ compiler can change the data alignment with the command-line option, /Zp#, where # is a byte value.
        /// </remarks>
        public HRESULT TryGetIsDataAligned(out bool pRetVal)
        {
            /*HRESULT get_isDataAligned(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isDataAligned(out pRetVal);
        }

        #endregion
        #region HasSecurityChecks

        /// <summary>
        /// Retrieves a flag that specifies whether the compiland or function has been compiled with buffer-overrun security checks (for example, the /GS (Buffer Security Check) compiler switch).
        /// </summary>
        public bool HasSecurityChecks
        {
            get
            {
                bool pRetVal;
                TryGetHasSecurityChecks(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the compiland or function has been compiled with buffer-overrun security checks (for example, the /GS (Buffer Security Check) compiler switch).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has any security checks; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetHasSecurityChecks(out bool pRetVal)
        {
            /*HRESULT get_hasSecurityChecks(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasSecurityChecks(out pRetVal);
        }

        #endregion
        #region CompilerName

        /// <summary>
        /// Returns the name of the compiler used to generate the Compiland.
        /// </summary>
        public string CompilerName
        {
            get
            {
                string pRetVal;
                TryGetCompilerName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Returns the name of the compiler used to generate the Compiland.
        /// </summary>
        /// <param name="pRetVal">Pointer to a BSTR that will contain the Unicode name of the compiler.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetCompilerName(out string pRetVal)
        {
            /*HRESULT get_compilerName(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_compilerName(out pRetVal);
        }

        #endregion
        #region HasAlloca

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a call to alloca (which is used to allocate memory on the stack).
        /// </summary>
        public bool HasAlloca
        {
            get
            {
                bool pRetVal;
                TryGetHasAlloca(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a call to alloca (which is used to allocate memory on the stack).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function contains a call to alloca; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetHasAlloca(out bool pRetVal)
        {
            /*HRESULT get_hasAlloca(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasAlloca(out pRetVal);
        }

        #endregion
        #region HasSetJump

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a use of the setjmp command (paired with the longjmp command, these form the C-style method of exception handling).
        /// </summary>
        public bool HasSetJump
        {
            get
            {
                bool pRetVal;
                TryGetHasSetJump(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a use of the setjmp command (paired with the longjmp command, these form the C-style method of exception handling).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function contains a setjmp command; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetHasSetJump(out bool pRetVal)
        {
            /*HRESULT get_hasSetJump(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasSetJump(out pRetVal);
        }

        #endregion
        #region HasLongJump

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a use of the longjmp command (paired with a setjmp command, these form the C-style method of exception handling).
        /// </summary>
        public bool HasLongJump
        {
            get
            {
                bool pRetVal;
                TryGetHasLongJump(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains a use of the longjmp command (paired with a setjmp command, these form the C-style method of exception handling).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function contains a longjmp command; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetHasLongJump(out bool pRetVal)
        {
            /*HRESULT get_hasLongJump(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasLongJump(out pRetVal);
        }

        #endregion
        #region HasInlAsm

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains inline assembly.
        /// </summary>
        public bool HasInlAsm
        {
            get
            {
                bool pRetVal;
                TryGetHasInlAsm(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains inline assembly.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has any inline assembly; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetHasInlAsm(out bool pRetVal)
        {
            /*HRESULT get_hasInlAsm(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasInlAsm(out pRetVal);
        }

        #endregion
        #region HasEH

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains any unmanaged C++-style exception handling (for example, a try/catch block).
        /// </summary>
        public bool HasEH
        {
            get
            {
                bool pRetVal;
                TryGetHasEH(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains any unmanaged C++-style exception handling (for example, a try/catch block).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has any C++-style exception handling; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetHasEH(out bool pRetVal)
        {
            /*HRESULT get_hasEH(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasEH(out pRetVal);
        }

        #endregion
        #region HasSEH

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains any Structured Exception Handling (C/C (for example, __try/__except blocks).
        /// </summary>
        public bool HasSEH
        {
            get
            {
                bool pRetVal;
                TryGetHasSEH(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains any Structured Exception Handling (C/C (for example, __try/__except blocks).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has any structured exception handling blocks; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetHasSEH(out bool pRetVal)
        {
            /*HRESULT get_hasSEH(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasSEH(out pRetVal);
        }

        #endregion
        #region HasEHa

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains asynchronous (structured) exception handling.
        /// </summary>
        public bool HasEHa
        {
            get
            {
                bool pRetVal;
                TryGetHasEHa(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function contains asynchronous (structured) exception handling.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has any asynchronous exception handling; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// It is possible to mix asynchronous or structured exception handling with C++-style exception handling, but it requires
        /// a specific compiler switch, /EHa, to enable it.
        /// </remarks>
        public HRESULT TryGetHasEHa(out bool pRetVal)
        {
            /*HRESULT get_hasEHa(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasEHa(out pRetVal);
        }

        #endregion
        #region IsNaked

        /// <summary>
        /// Retrieves a flag that specifies whether the function has the naked attribute (that is, the function has no prolog or epilog code added by the compiler).
        /// </summary>
        public bool IsNaked
        {
            get
            {
                bool pRetVal;
                TryGetIsNaked(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the function has the naked attribute (that is, the function has no prolog or epilog code added by the compiler).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function has the naked attribute; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsNaked(out bool pRetVal)
        {
            /*HRESULT get_isNaked(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isNaked(out pRetVal);
        }

        #endregion
        #region IsAggregated

        /// <summary>
        /// Retrieves a flag that specifies whether the data symbol is part of an aggregate or collection of symbols; the compiler will treat aggregated symbols as separate entities, but they are really part of a single larger symbol.
        /// </summary>
        public bool IsAggregated
        {
            get
            {
                bool pRetVal;
                TryGetIsAggregated(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the data symbol is part of an aggregate or collection of symbols; the compiler will treat aggregated symbols as separate entities, but they are really part of a single larger symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the data is part of an aggregation of symbols split from a parent symbol; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The IDiaSymbol method is TRUE for the symbol that is the parent of the aggregated symbols.
        /// </remarks>
        public HRESULT TryGetIsAggregated(out bool pRetVal)
        {
            /*HRESULT get_isAggregated(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isAggregated(out pRetVal);
        }

        #endregion
        #region IsSplitted

        /// <summary>
        /// Retrieves a flag that specifies whether the data symbol has been split into an aggregation or collection of other symbols; the compiler treats the symbols as separate entities, even though they are really part of a larger symbol.
        /// </summary>
        public bool IsSplitted
        {
            get
            {
                bool pRetVal;
                TryGetIsSplitted(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the data symbol has been split into an aggregation or collection of other symbols; the compiler treats the symbols as separate entities, even though they are really part of a larger symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the symbol has been split into an aggregate of symbols; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// The IDiaSymbol method returns TRUE for all symbols that are part of a split symbol.
        /// </remarks>
        public HRESULT TryGetIsSplitted(out bool pRetVal)
        {
            /*HRESULT get_isSplitted(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isSplitted(out pRetVal);
        }

        #endregion
        #region Container

        /// <summary>
        /// This function retrieves a pointer to a symbol representing the parent/container of this symbol.
        /// </summary>
        public DiaSymbol Container
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetContainer(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// This function retrieves a pointer to a symbol representing the parent/container of this symbol.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns a pointer to an IDiaSymbol containing information about the container of this symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetContainer(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_container(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_container(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region InlSpec

        /// <summary>
        /// This function retrieves a flag indicating whether the function was marked as inline (using one of the inline, attributes).
        /// </summary>
        public bool InlSpec
        {
            get
            {
                bool pRetVal;
                TryGetInlSpec(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// This function retrieves a flag indicating whether the function was marked as inline (using one of the inline, attributes).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the function was marked as inline; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        public HRESULT TryGetInlSpec(out bool pRetVal)
        {
            /*HRESULT get_inlSpec(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_inlSpec(out pRetVal);
        }

        #endregion
        #region NoStackOrdering

        /// <summary>
        /// This function retrieves a flag that indicates whether no stack ordering could be done as part of stack buffer checking (/GS (Buffer Security Check) compiler option).
        /// </summary>
        public bool NoStackOrdering
        {
            get
            {
                bool pRetVal;
                TryGetNoStackOrdering(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// This function retrieves a flag that indicates whether no stack ordering could be done as part of stack buffer checking (/GS (Buffer Security Check) compiler option).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if no stack ordering could be done as part of stack buffer checking; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetNoStackOrdering(out bool pRetVal)
        {
            /*HRESULT get_noStackOrdering(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_noStackOrdering(out pRetVal);
        }

        #endregion
        #region VirtualBaseTableType

        /// <summary>
        /// Retrieves the type of a virtual base table pointer.
        /// </summary>
        public DiaSymbol VirtualBaseTableType
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetVirtualBaseTableType(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the type of a virtual base table pointer.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// A virtual base table pointer (vbtptr) is a hidden pointer in a Visual C++ vtable that handles inheritance from
        /// virtual base classes. A vbtptr can have different sizes depending on the inherited classes. This method returns
        /// an IDiaSymbol object that can be used to determine the size of the vbtptr.
        /// </remarks>
        public HRESULT TryGetVirtualBaseTableType(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_virtualBaseTableType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_virtualBaseTableType(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region HasManagedCode

        /// <summary>
        /// Retrieves a flag indicating whether the module contains managed code.
        /// </summary>
        public bool HasManagedCode
        {
            get
            {
                bool pRetVal;
                TryGetHasManagedCode(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag indicating whether the module contains managed code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the module contains managed code; otherwise, returns FALSE, the code is unmanaged code.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagCompilandDetails symbol type (see CompilandDetails).
        /// </remarks>
        public HRESULT TryGetHasManagedCode(out bool pRetVal)
        {
            /*HRESULT get_hasManagedCode(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasManagedCode(out pRetVal);
        }

        #endregion
        #region IsHotpatchable

        /// <summary>
        /// Retrieves a flag indicating whether the module was compiled with the /hotpatch (Create Hotpatchable Image) compiler switch.
        /// </summary>
        public bool IsHotpatchable
        {
            get
            {
                bool pRetVal;
                TryGetIsHotpatchable(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag indicating whether the module was compiled with the /hotpatch (Create Hotpatchable Image) compiler switch.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the module is hot-patchable; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagCompilandDetails symbol type (see CompilandDetails).
        /// </remarks>
        public HRESULT TryGetIsHotpatchable(out bool pRetVal)
        {
            /*HRESULT get_isHotpatchable(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isHotpatchable(out pRetVal);
        }

        #endregion
        #region IsCVTCIL

        /// <summary>
        /// Retrieves a flag indicating whether the module was converted from a Common Intermediate Language (CIL) module to a native module.
        /// </summary>
        public bool IsCVTCIL
        {
            get
            {
                bool pRetVal;
                TryGetIsCVTCIL(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag indicating whether the module was converted from a Common Intermediate Language (CIL) module to a native module.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the module was converted from CIL to native code; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagCompilandDetails symbol type (see CompilandDetails.
        /// </remarks>
        public HRESULT TryGetIsCVTCIL(out bool pRetVal)
        {
            /*HRESULT get_isCVTCIL(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isCVTCIL(out pRetVal);
        }

        #endregion
        #region IsMSILNetmodule

        /// <summary>
        /// Retrieves a flag indicating whether the module is a .netmodule (a Microsoft Intermediate Language (MSIL) module that contains only metadata and no native symbols).
        /// </summary>
        public bool IsMSILNetmodule
        {
            get
            {
                bool pRetVal;
                TryGetIsMSILNetmodule(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag indicating whether the module is a .netmodule (a Microsoft Intermediate Language (MSIL) module that contains only metadata and no native symbols).
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the module is MSIL; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagCompilandDetails symbol type (see CompilandDetails).
        /// </remarks>
        public HRESULT TryGetIsMSILNetmodule(out bool pRetVal)
        {
            /*HRESULT get_isMSILNetmodule(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isMSILNetmodule(out pRetVal);
        }

        #endregion
        #region IsCTypes

        /// <summary>
        /// Retrieves a flag indicating whether the symbol file contains C types.
        /// </summary>
        public bool IsCTypes
        {
            get
            {
                bool pRetVal;
                TryGetIsCTypes(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag indicating whether the symbol file contains C types.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the symbol file contains C types; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagExe symbol type (see Exe).
        /// </remarks>
        public HRESULT TryGetIsCTypes(out bool pRetVal)
        {
            /*HRESULT get_isCTypes(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isCTypes(out pRetVal);
        }

        #endregion
        #region IsStripped

        /// <summary>
        /// Retrieves flag indicating whether private symbols were stripped from the symbol file.
        /// </summary>
        public bool IsStripped
        {
            get
            {
                bool pRetVal;
                TryGetIsStripped(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves flag indicating whether private symbols were stripped from the symbol file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if private symbols were removed from the symbol file; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This property is available from the SymTagExe symbol type (see Exe).
        /// </remarks>
        public HRESULT TryGetIsStripped(out bool pRetVal)
        {
            /*HRESULT get_isStripped(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isStripped(out pRetVal);
        }

        #endregion
        #region FrontEndQFE

        public int FrontEndQFE
        {
            get
            {
                int pRetVal;
                TryGetFrontEndQFE(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetFrontEndQFE(out int pRetVal)
        {
            /*HRESULT get_frontEndQFE(
            [Out] out int pRetVal);*/
            return Raw.get_frontEndQFE(out pRetVal);
        }

        #endregion
        #region BackEndQFE

        public int BackEndQFE
        {
            get
            {
                int pRetVal;
                TryGetBackEndQFE(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetBackEndQFE(out int pRetVal)
        {
            /*HRESULT get_backEndQFE(
            [Out] out int pRetVal);*/
            return Raw.get_backEndQFE(out pRetVal);
        }

        #endregion
        #region WasInlined

        public bool WasInlined
        {
            get
            {
                bool pRetVal;
                TryGetWasInlined(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetWasInlined(out bool pRetVal)
        {
            /*HRESULT get_wasInlined(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_wasInlined(out pRetVal);
        }

        #endregion
        #region StrictGSCheck

        public bool StrictGSCheck
        {
            get
            {
                bool pRetVal;
                TryGetStrictGSCheck(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetStrictGSCheck(out bool pRetVal)
        {
            /*HRESULT get_strictGSCheck(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_strictGSCheck(out pRetVal);
        }

        #endregion
        #region IsCxxReturnUdt

        public bool IsCxxReturnUdt
        {
            get
            {
                bool pRetVal;
                TryGetIsCxxReturnUdt(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsCxxReturnUdt(out bool pRetVal)
        {
            /*HRESULT get_isCxxReturnUdt(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isCxxReturnUdt(out pRetVal);
        }

        #endregion
        #region IsConstructorVirtualBase

        public bool IsConstructorVirtualBase
        {
            get
            {
                bool pRetVal;
                TryGetIsConstructorVirtualBase(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsConstructorVirtualBase(out bool pRetVal)
        {
            /*HRESULT get_isConstructorVirtualBase(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isConstructorVirtualBase(out pRetVal);
        }

        #endregion
        #region RValueReference

        /// <summary>
        /// Retrieves a flag that specifies whether a pointer type is an rvalue reference. Use when the SymTagEnum Enumeration is set to a pointer type.
        /// </summary>
        public bool RValueReference
        {
            get
            {
                bool pRetVal;
                TryGetRValueReference(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether a pointer type is an rvalue reference. Use when the SymTagEnum Enumeration is set to a pointer type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the pointer is an rvalue reference; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetRValueReference(out bool pRetVal)
        {
            /*HRESULT get_RValueReference(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_RValueReference(out pRetVal);
        }

        #endregion
        #region UnmodifiedType

        /// <summary>
        /// Retrieves the original type for this symbol. Use when the SymTagEnum Enumeration is set to a type.
        /// </summary>
        public DiaSymbol UnmodifiedType
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetUnmodifiedType(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the original type for this symbol. Use when the SymTagEnum Enumeration is set to a type.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object that represents the original type of this symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The current type is a modification of the returned original type. The original type for a symbol can be determined
        /// by first getting the type of the symbol and then interrogating that returned type for the original type. Note that
        /// some symbols may not have a modified type of the original type.
        /// </remarks>
        public HRESULT TryGetUnmodifiedType(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_unmodifiedType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_unmodifiedType(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region FramePointerPresent

        /// <summary>
        /// Retrieves a flag that specifies whether the frame pointer is present. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        public bool FramePointerPresent
        {
            get
            {
                bool pRetVal;
                TryGetFramePointerPresent(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the frame pointer is present. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        /// <param name="pRetVal">[out] ] Returns TRUE if the frame pointer is present; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetFramePointerPresent(out bool pRetVal)
        {
            /*HRESULT get_framePointerPresent(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_framePointerPresent(out pRetVal);
        }

        #endregion
        #region IsSafeBuffers

        /// <summary>
        /// Retrieves a flag that specifies whether the preprocesser directive for a safe buffer is used. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        public bool IsSafeBuffers
        {
            get
            {
                bool pRetVal;
                TryGetIsSafeBuffers(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the preprocesser directive for a safe buffer is used. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the pointer uses a preprocessor directive for a safe buffer; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsSafeBuffers(out bool pRetVal)
        {
            /*HRESULT get_isSafeBuffers(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isSafeBuffers(out pRetVal);
        }

        #endregion
        #region Intrinsic

        /// <summary>
        /// Retrieves a flag that specifies whether a class is an intrinsic type.
        /// </summary>
        public bool Intrinsic
        {
            get
            {
                bool pRetVal;
                TryGetIntrinsic(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether a class is an intrinsic type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the class is an intrinsic type; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIntrinsic(out bool pRetVal)
        {
            /*HRESULT get_intrinsic(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_intrinsic(out pRetVal);
        }

        #endregion
        #region Sealed

        /// <summary>
        /// Retrieves a flag that specifies whether the class or method is sealed.
        /// </summary>
        public bool Sealed
        {
            get
            {
                bool pRetVal;
                TryGetSealed(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether the class or method is sealed.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the class or method is sealed; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// A sealed class cannot be used as a base class. A sealed method cannot be overidden.
        /// </remarks>
        public HRESULT TryGetSealed(out bool pRetVal)
        {
            /*HRESULT get_sealed(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_sealed(out pRetVal);
        }

        #endregion
        #region HfaFloat

        /// <summary>
        /// Retrieves a flag that specifies whether a user-defined type (UDT) contains homogeneous floating-point aggregate (HFA) data of type float.
        /// </summary>
        public bool HfaFloat
        {
            get
            {
                bool pRetVal;
                TryGetHfaFloat(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether a user-defined type (UDT) contains homogeneous floating-point aggregate (HFA) data of type float.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the UDT contains HFA data of type float; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetHfaFloat(out bool pRetVal)
        {
            /*HRESULT get_hfaFloat(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hfaFloat(out pRetVal);
        }

        #endregion
        #region HfaDouble

        /// <summary>
        /// Retrieves a flag that specifies whether a user-defined type (UDT) contains homogeneous floating-point aggregate (HFA) data of type double.
        /// </summary>
        public bool HfaDouble
        {
            get
            {
                bool pRetVal;
                TryGetHfaDouble(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that specifies whether a user-defined type (UDT) contains homogeneous floating-point aggregate (HFA) data of type double.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the UDT contains HFA data of type double; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetHfaDouble(out bool pRetVal)
        {
            /*HRESULT get_hfaDouble(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hfaDouble(out pRetVal);
        }

        #endregion
        #region LiveRangeStartAddressSection

        /// <summary>
        /// Returns the section part of the starting address of the range in which the local symbol is valid.
        /// </summary>
        public int LiveRangeStartAddressSection
        {
            get
            {
                int pRetVal;
                TryGetLiveRangeStartAddressSection(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Returns the section part of the starting address of the range in which the local symbol is valid.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section part of the starting address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The address formed by the section and offset is the beginning of the range in which the symbol is valid. To get
        /// the offset part of the address, use IDiaSymbol.
        /// </remarks>
        public HRESULT TryGetLiveRangeStartAddressSection(out int pRetVal)
        {
            /*HRESULT get_liveRangeStartAddressSection(
            [Out] out int pRetVal);*/
            return Raw.get_liveRangeStartAddressSection(out pRetVal);
        }

        #endregion
        #region LiveRangeStartAddressOffset

        /// <summary>
        /// Returns the offset part of the starting address of the range in which the local symbol is valid.
        /// </summary>
        public int LiveRangeStartAddressOffset
        {
            get
            {
                int pRetVal;
                TryGetLiveRangeStartAddressOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Returns the offset part of the starting address of the range in which the local symbol is valid.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of the starting address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The address formed by the section and offset is the beginning of the range in which the symbol is valid. To get
        /// the section part of the address, use IDiaSymbol.
        /// </remarks>
        public HRESULT TryGetLiveRangeStartAddressOffset(out int pRetVal)
        {
            /*HRESULT get_liveRangeStartAddressOffset(
            [Out] out int pRetVal);*/
            return Raw.get_liveRangeStartAddressOffset(out pRetVal);
        }

        #endregion
        #region LiveRangeStartRelativeVirtualAddress

        /// <summary>
        /// Returns the beginning of the address range in which the local symbol is valid.
        /// </summary>
        public int LiveRangeStartRelativeVirtualAddress
        {
            get
            {
                int pRetVal;
                TryGetLiveRangeStartRelativeVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Returns the beginning of the address range in which the local symbol is valid.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the start of the address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The relative virtual address returned is the beginning of the range in which the symbol is valid.</returns>
        public HRESULT TryGetLiveRangeStartRelativeVirtualAddress(out int pRetVal)
        {
            /*HRESULT get_liveRangeStartRelativeVirtualAddress(
            [Out] out int pRetVal);*/
            return Raw.get_liveRangeStartRelativeVirtualAddress(out pRetVal);
        }

        #endregion
        #region CountLiveRanges

        /// <summary>
        /// Retrieves the number of valid address ranges associated with the local symbol.
        /// </summary>
        public int CountLiveRanges
        {
            get
            {
                int pRetVal;
                TryGetCountLiveRanges(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of valid address ranges associated with the local symbol.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of address ranges.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetCountLiveRanges(out int pRetVal)
        {
            /*HRESULT get_countLiveRanges(
            [Out] out int pRetVal);*/
            return Raw.get_countLiveRanges(out pRetVal);
        }

        #endregion
        #region LiveRangeLength

        /// <summary>
        /// Returns the length of the address range in which the local symbol is valid.
        /// </summary>
        public long LiveRangeLength
        {
            get
            {
                long pRetVal;
                TryGetLiveRangeLength(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Returns the length of the address range in which the local symbol is valid.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the length of the address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetLiveRangeLength(out long pRetVal)
        {
            /*HRESULT get_liveRangeLength(
            [Out] out long pRetVal);*/
            return Raw.get_liveRangeLength(out pRetVal);
        }

        #endregion
        #region OffsetInUdt

        /// <summary>
        /// Retrieves the offset to the beginning of a user-defined type (UDT) of a member in the UDT.
        /// </summary>
        public int OffsetInUdt
        {
            get
            {
                int pRetVal;
                TryGetOffsetInUdt(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the offset to the beginning of a user-defined type (UDT) of a member in the UDT.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset in bytes of the symbol location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This function is used only in local records in an optimized build.
        /// </remarks>
        public HRESULT TryGetOffsetInUdt(out int pRetVal)
        {
            /*HRESULT get_offsetInUdt(
            [Out] out int pRetVal);*/
            return Raw.get_offsetInUdt(out pRetVal);
        }

        #endregion
        #region ParamBasePointerRegisterId

        /// <summary>
        /// Retrieves the ID of the register that holds a base pointer to the parameters. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        public int ParamBasePointerRegisterId
        {
            get
            {
                int pRetVal;
                TryGetParamBasePointerRegisterId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the ID of the register that holds a base pointer to the parameters. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the ID of the register that holds a base pointer to the parameters.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetParamBasePointerRegisterId(out int pRetVal)
        {
            /*HRESULT get_paramBasePointerRegisterId(
            [Out] out int pRetVal);*/
            return Raw.get_paramBasePointerRegisterId(out pRetVal);
        }

        #endregion
        #region LocalBasePointerRegisterId

        /// <summary>
        /// Retrieves the ID of the register that holds a base pointer to local variables on the stack. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        public int LocalBasePointerRegisterId
        {
            get
            {
                int pRetVal;
                TryGetLocalBasePointerRegisterId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the ID of the register that holds a base pointer to local variables on the stack. Use when the SymTagEnum Enumeration is set to SymTagFunction.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the ID of the register that holds a base pointer to local variables on the stack.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetLocalBasePointerRegisterId(out int pRetVal)
        {
            /*HRESULT get_localBasePointerRegisterId(
            [Out] out int pRetVal);*/
            return Raw.get_localBasePointerRegisterId(out pRetVal);
        }

        #endregion
        #region IsLocationControlFlowDependent

        public bool IsLocationControlFlowDependent
        {
            get
            {
                bool pRetVal;
                TryGetIsLocationControlFlowDependent(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsLocationControlFlowDependent(out bool pRetVal)
        {
            /*HRESULT get_isLocationControlFlowDependent(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isLocationControlFlowDependent(out pRetVal);
        }

        #endregion
        #region Stride

        /// <summary>
        /// Retrieves the stride of the matrix or strided array.
        /// </summary>
        public int Stride
        {
            get
            {
                int pRetVal;
                TryGetStride(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the stride of the matrix or strided array.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the stride.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetStride(out int pRetVal)
        {
            /*HRESULT get_stride(
            [Out] out int pRetVal);*/
            return Raw.get_stride(out pRetVal);
        }

        #endregion
        #region NumberOfRows

        /// <summary>
        /// Retrieves the number of rows in the matrix.
        /// </summary>
        public int NumberOfRows
        {
            get
            {
                int pRetVal;
                TryGetNumberOfRows(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of rows in the matrix.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the number of rows in the matrix.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetNumberOfRows(out int pRetVal)
        {
            /*HRESULT get_numberOfRows(
            [Out] out int pRetVal);*/
            return Raw.get_numberOfRows(out pRetVal);
        }

        #endregion
        #region NumberOfColumns

        /// <summary>
        /// Retrieves the number of columns in the matrix.
        /// </summary>
        public int NumberOfColumns
        {
            get
            {
                int pRetVal;
                TryGetNumberOfColumns(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of columns in the matrix.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the number of columns in the matrix.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetNumberOfColumns(out int pRetVal)
        {
            /*HRESULT get_numberOfColumns(
            [Out] out int pRetVal);*/
            return Raw.get_numberOfColumns(out pRetVal);
        }

        #endregion
        #region IsMatrixRowMajor

        /// <summary>
        /// Specifies whether the matrix is row major.
        /// </summary>
        public bool IsMatrixRowMajor
        {
            get
            {
                bool pRetVal;
                TryGetIsMatrixRowMajor(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether the matrix is row major.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the matrix is row major.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsMatrixRowMajor(out bool pRetVal)
        {
            /*HRESULT get_isMatrixRowMajor(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isMatrixRowMajor(out pRetVal);
        }

        #endregion
        #region NumericProperties

        public int[] NumericProperties
        {
            get
            {
                int[] pProperties;
                TryGetNumericProperties(out pProperties).ThrowOnNotOK();

                return pProperties;
            }
        }

        public HRESULT TryGetNumericProperties(out int[] pProperties)
        {
            /*HRESULT get_numericProperties(
            [In] int cnt,
            [Out] out int pcnt,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] pProperties);*/
            int cnt = 0;
            int pcnt;
            pProperties = null;
            HRESULT hr = Raw.get_numericProperties(cnt, out pcnt, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cnt = pcnt;
            pProperties = new int[cnt];
            hr = Raw.get_numericProperties(cnt, out pcnt, pProperties);
            fail:
            return hr;
        }

        #endregion
        #region ModifierValues

        public short[] ModifierValues
        {
            get
            {
                short[] pModifiers;
                TryGetModifierValues(out pModifiers).ThrowOnNotOK();

                return pModifiers;
            }
        }

        public HRESULT TryGetModifierValues(out short[] pModifiers)
        {
            /*HRESULT get_modifierValues(
            [In] int cnt,
            [Out] out int pcnt,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] short[] pModifiers);*/
            int cnt = 0;
            int pcnt;
            pModifiers = null;
            HRESULT hr = Raw.get_modifierValues(cnt, out pcnt, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cnt = pcnt;
            pModifiers = new short[cnt];
            hr = Raw.get_modifierValues(cnt, out pcnt, pModifiers);
            fail:
            return hr;
        }

        #endregion
        #region IsReturnValue

        /// <summary>
        /// Specifies whether the variable carries a return value.
        /// </summary>
        public bool IsReturnValue
        {
            get
            {
                bool pRetVal;
                TryGetIsReturnValue(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether the variable carries a return value.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the variable carries a return value.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsReturnValue(out bool pRetVal)
        {
            /*HRESULT get_isReturnValue(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isReturnValue(out pRetVal);
        }

        #endregion
        #region IsOptimizedAway

        /// <summary>
        /// Specifies whether the variable is optimized away.
        /// </summary>
        public bool IsOptimizedAway
        {
            get
            {
                bool pRetVal;
                TryGetIsOptimizedAway(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether the variable is optimized away.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the variable is optimized away.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsOptimizedAway(out bool pRetVal)
        {
            /*HRESULT get_isOptimizedAway(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isOptimizedAway(out pRetVal);
        }

        #endregion
        #region BuiltInKind

        /// <summary>
        /// Retrieves a built-in kind of the HLSL type.
        /// </summary>
        public int BuiltInKind
        {
            get
            {
                int pRetVal;
                TryGetBuiltInKind(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a built-in kind of the HLSL type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds a built-in kind of the HLSL type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetBuiltInKind(out int pRetVal)
        {
            /*HRESULT get_builtInKind(
            [Out] out int pRetVal);*/
            return Raw.get_builtInKind(out pRetVal);
        }

        #endregion
        #region RegisterType

        /// <summary>
        /// Retrieves the register type.
        /// </summary>
        public int RegisterType
        {
            get
            {
                int pRetVal;
                TryGetRegisterType(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the register type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the register type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetRegisterType(out int pRetVal)
        {
            /*HRESULT get_registerType(
            [Out] out int pRetVal);*/
            return Raw.get_registerType(out pRetVal);
        }

        #endregion
        #region BaseDataSlot

        /// <summary>
        /// Retrieves the base data slot.
        /// </summary>
        public int BaseDataSlot
        {
            get
            {
                int pRetVal;
                TryGetBaseDataSlot(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the base data slot.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the base data slot.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetBaseDataSlot(out int pRetVal)
        {
            /*HRESULT get_baseDataSlot(
            [Out] out int pRetVal);*/
            return Raw.get_baseDataSlot(out pRetVal);
        }

        #endregion
        #region BaseDataOffset

        /// <summary>
        /// Retrieves the base data offset.
        /// </summary>
        public int BaseDataOffset
        {
            get
            {
                int pRetVal;
                TryGetBaseDataOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the base data offset.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the base data offset.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetBaseDataOffset(out int pRetVal)
        {
            /*HRESULT get_baseDataOffset(
            [Out] out int pRetVal);*/
            return Raw.get_baseDataOffset(out pRetVal);
        }

        #endregion
        #region TextureSlot

        /// <summary>
        /// Retrieves the texture slot.
        /// </summary>
        public int TextureSlot
        {
            get
            {
                int pRetVal;
                TryGetTextureSlot(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the texture slot.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the texture slot.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetTextureSlot(out int pRetVal)
        {
            /*HRESULT get_textureSlot(
            [Out] out int pRetVal);*/
            return Raw.get_textureSlot(out pRetVal);
        }

        #endregion
        #region SamplerSlot

        /// <summary>
        /// Retrieves the sampler slot.
        /// </summary>
        public int SamplerSlot
        {
            get
            {
                int pRetVal;
                TryGetSamplerSlot(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the sampler slot.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the sampler slot.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetSamplerSlot(out int pRetVal)
        {
            /*HRESULT get_samplerSlot(
            [Out] out int pRetVal);*/
            return Raw.get_samplerSlot(out pRetVal);
        }

        #endregion
        #region UavSlot

        /// <summary>
        /// Retrieves the uav slot.
        /// </summary>
        public int UavSlot
        {
            get
            {
                int pRetVal;
                TryGetUavSlot(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the uav slot.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the uav slot.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetUavSlot(out int pRetVal)
        {
            /*HRESULT get_uavSlot(
            [Out] out int pRetVal);*/
            return Raw.get_uavSlot(out pRetVal);
        }

        #endregion
        #region SizeInUdt

        /// <summary>
        /// Retrieves the size of a member of a user-defined type.
        /// </summary>
        public int SizeInUdt
        {
            get
            {
                int pRetVal;
                TryGetSizeInUdt(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the size of a member of a user-defined type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that specifies the size of the member.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetSizeInUdt(out int pRetVal)
        {
            /*HRESULT get_sizeInUdt(
            [Out] out int pRetVal);*/
            return Raw.get_sizeInUdt(out pRetVal);
        }

        #endregion
        #region MemorySpaceKind

        /// <summary>
        /// Retrieves the memory space kind.
        /// </summary>
        public int MemorySpaceKind
        {
            get
            {
                int pRetVal;
                TryGetMemorySpaceKind(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the memory space kind.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the memory space kind.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetMemorySpaceKind(out int pRetVal)
        {
            /*HRESULT get_memorySpaceKind(
            [Out] out int pRetVal);*/
            return Raw.get_memorySpaceKind(out pRetVal);
        }

        #endregion
        #region UnmodifiedTypeId

        /// <summary>
        /// Retrieves the ID of the original (unmodified) type.
        /// </summary>
        public int UnmodifiedTypeId
        {
            get
            {
                int pRetVal;
                TryGetUnmodifiedTypeId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the ID of the original (unmodified) type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the ID.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetUnmodifiedTypeId(out int pRetVal)
        {
            /*HRESULT get_unmodifiedTypeId(
            [Out] out int pRetVal);*/
            return Raw.get_unmodifiedTypeId(out pRetVal);
        }

        #endregion
        #region SubTypeId

        /// <summary>
        /// Retrieves the sub type ID.
        /// </summary>
        public int SubTypeId
        {
            get
            {
                int pRetVal;
                TryGetSubTypeId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the sub type ID.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the sub type ID.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetSubTypeId(out int pRetVal)
        {
            /*HRESULT get_subTypeId(
            [Out] out int pRetVal);*/
            return Raw.get_subTypeId(out pRetVal);
        }

        #endregion
        #region SubType

        /// <summary>
        /// Retrieves the sub type.
        /// </summary>
        public DiaSymbol SubType
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetSubType(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the sub type.
        /// </summary>
        /// <param name="pRetValResult">[out] A pointer to the sub type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetSubType(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_subType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_subType(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region NumberOfModifiers

        /// <summary>
        /// Retrieves the number of modifiers that are applied to the original type.
        /// </summary>
        public int NumberOfModifiers
        {
            get
            {
                int pRetVal;
                TryGetNumberOfModifiers(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of modifiers that are applied to the original type.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that specifies the number of modifiers that are applied to the original type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetNumberOfModifiers(out int pRetVal)
        {
            /*HRESULT get_numberOfModifiers(
            [Out] out int pRetVal);*/
            return Raw.get_numberOfModifiers(out pRetVal);
        }

        #endregion
        #region NumberOfRegisterIndices

        /// <summary>
        /// Retrieves the number of register indices.
        /// </summary>
        public int NumberOfRegisterIndices
        {
            get
            {
                int pRetVal;
                TryGetNumberOfRegisterIndices(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of register indices.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the number of register indices.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetNumberOfRegisterIndices(out int pRetVal)
        {
            /*HRESULT get_numberOfRegisterIndices(
            [Out] out int pRetVal);*/
            return Raw.get_numberOfRegisterIndices(out pRetVal);
        }

        #endregion
        #region IsHLSLData

        /// <summary>
        /// Specifies whether this symbol represents High Level Shader Language (HLSL) data.
        /// </summary>
        public bool IsHLSLData
        {
            get
            {
                bool pRetVal;
                TryGetIsHLSLData(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether this symbol represents High Level Shader Language (HLSL) data.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether this symbol represents HLSL data.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsHLSLData(out bool pRetVal)
        {
            /*HRESULT get_isHLSLData(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isHLSLData(out pRetVal);
        }

        #endregion
        #region IsPointerToDataMember

        /// <summary>
        /// Specifies whether this symbol is a pointer to a data member.
        /// </summary>
        public bool IsPointerToDataMember
        {
            get
            {
                bool pRetVal;
                TryGetIsPointerToDataMember(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether this symbol is a pointer to a data member.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether this symbol is a pointer to a data member.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsPointerToDataMember(out bool pRetVal)
        {
            /*HRESULT get_isPointerToDataMember(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isPointerToDataMember(out pRetVal);
        }

        #endregion
        #region IsPointerToMemberFunction

        /// <summary>
        /// Specifies whether this symbol is a pointer to a member function.
        /// </summary>
        public bool IsPointerToMemberFunction
        {
            get
            {
                bool pRetVal;
                TryGetIsPointerToMemberFunction(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether this symbol is a pointer to a member function.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether this symbol is a pointer to a member function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsPointerToMemberFunction(out bool pRetVal)
        {
            /*HRESULT get_isPointerToMemberFunction(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isPointerToMemberFunction(out pRetVal);
        }

        #endregion
        #region IsSingleInheritance

        /// <summary>
        /// Specifies whether the this pointer points to a data member with single inheritance.
        /// </summary>
        public bool IsSingleInheritance
        {
            get
            {
                bool pRetVal;
                TryGetIsSingleInheritance(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether the this pointer points to a data member with single inheritance.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the this pointer points to a data member with single inheritance.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsSingleInheritance(out bool pRetVal)
        {
            /*HRESULT get_isSingleInheritance(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isSingleInheritance(out pRetVal);
        }

        #endregion
        #region IsMultipleInheritance

        /// <summary>
        /// Specifies whether the this pointer points to a data member with multiple inheritance.
        /// </summary>
        public bool IsMultipleInheritance
        {
            get
            {
                bool pRetVal;
                TryGetIsMultipleInheritance(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether the this pointer points to a data member with multiple inheritance.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the this pointer points to a data member with multiple inheritance.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsMultipleInheritance(out bool pRetVal)
        {
            /*HRESULT get_isMultipleInheritance(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isMultipleInheritance(out pRetVal);
        }

        #endregion
        #region IsVirtualInheritance

        /// <summary>
        /// Specifies whether the this pointer points to a data member with virtual inheritance.
        /// </summary>
        public bool IsVirtualInheritance
        {
            get
            {
                bool pRetVal;
                TryGetIsVirtualInheritance(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether the this pointer points to a data member with virtual inheritance.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the this pointer points to a data member with virtual inheritance.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsVirtualInheritance(out bool pRetVal)
        {
            /*HRESULT get_isVirtualInheritance(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isVirtualInheritance(out pRetVal);
        }

        #endregion
        #region RestrictedType

        /// <summary>
        /// Specifies whether the this pointer is flagged as restricted.
        /// </summary>
        public bool RestrictedType
        {
            get
            {
                bool pRetVal;
                TryGetRestrictedType(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether the this pointer is flagged as restricted.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the this pointer is flagged as restricted.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetRestrictedType(out bool pRetVal)
        {
            /*HRESULT get_restrictedType(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_restrictedType(out pRetVal);
        }

        #endregion
        #region IsPointerBasedOnSymbolValue

        /// <summary>
        /// Specifies whether the this pointer is based on a symbol value.
        /// </summary>
        public bool IsPointerBasedOnSymbolValue
        {
            get
            {
                bool pRetVal;
                TryGetIsPointerBasedOnSymbolValue(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether the this pointer is based on a symbol value.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the this pointer is based on a symbol value.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsPointerBasedOnSymbolValue(out bool pRetVal)
        {
            /*HRESULT get_isPointerBasedOnSymbolValue(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isPointerBasedOnSymbolValue(out pRetVal);
        }

        #endregion
        #region BaseSymbol

        /// <summary>
        /// Retrieves the symbol from which the pointer is based.
        /// </summary>
        public DiaSymbol BaseSymbol
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetBaseSymbol(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the symbol from which the pointer is based.
        /// </summary>
        /// <param name="pRetValResult">[out] A pointer to the symbol from which the pointer is based.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetBaseSymbol(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_baseSymbol(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_baseSymbol(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region BaseSymbolId

        /// <summary>
        /// Retrieves the symbol ID from which the pointer is based.
        /// </summary>
        public int BaseSymbolId
        {
            get
            {
                int pRetVal;
                TryGetBaseSymbolId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the symbol ID from which the pointer is based.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the symbol ID from which the pointer is based.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetBaseSymbolId(out int pRetVal)
        {
            /*HRESULT get_baseSymbolId(
            [Out] out int pRetVal);*/
            return Raw.get_baseSymbolId(out pRetVal);
        }

        #endregion
        #region ObjectFileName

        /// <summary>
        /// Retrieves the object file name.
        /// </summary>
        public string ObjectFileName
        {
            get
            {
                string pRetVal;
                TryGetObjectFileName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the object file name.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BSTR that holds the object file name.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetObjectFileName(out string pRetVal)
        {
            /*HRESULT get_objectFileName(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_objectFileName(out pRetVal);
        }

        #endregion
        #region IsAcceleratorGroupSharedLocal

        /// <summary>
        /// Retrieves a flag that indicates whether the symbol corresponds to a group shared local variable in code compiled for a C++ AMP Accelerator.
        /// </summary>
        public bool IsAcceleratorGroupSharedLocal
        {
            get
            {
                bool pRetVal;
                TryGetIsAcceleratorGroupSharedLocal(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the symbol corresponds to a group shared local variable in code compiled for a C++ AMP Accelerator.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that indicates whether the symbol corresponds to a group shared local variable in code compiled for a C++ AMP Accelerator.<para/>
        /// If TRUE, the get_baseDataSlot and get_baseDataOffset methods can be used to get the storage location information for the variable.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsAcceleratorGroupSharedLocal(out bool pRetVal)
        {
            /*HRESULT get_isAcceleratorGroupSharedLocal(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isAcceleratorGroupSharedLocal(out pRetVal);
        }

        #endregion
        #region IsAcceleratorPointerTagLiveRange

        /// <summary>
        /// Retrieves a flag that indicates whether the symbol corresponds to the definition range symbol for the tag component of a pointer variable in code compiled for a C++ AMP Accelerator.<para/>
        /// The definition range symbol is the location of a variable for a span of addresses.
        /// </summary>
        public bool IsAcceleratorPointerTagLiveRange
        {
            get
            {
                bool pRetVal;
                TryGetIsAcceleratorPointerTagLiveRange(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the symbol corresponds to the definition range symbol for the tag component of a pointer variable in code compiled for a C++ AMP Accelerator.<para/>
        /// The definition range symbol is the location of a variable for a span of addresses.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that indicates whether the symbol corresponds to the definition range symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsAcceleratorPointerTagLiveRange(out bool pRetVal)
        {
            /*HRESULT get_isAcceleratorPointerTagLiveRange(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isAcceleratorPointerTagLiveRange(out pRetVal);
        }

        #endregion
        #region IsAcceleratorStubFunction

        /// <summary>
        /// Indicates whether the symbol corresponds to a top-level function symbol for a shader compiled for an accelerator that corresponds to a parallel_for_each call.
        /// </summary>
        public bool IsAcceleratorStubFunction
        {
            get
            {
                bool pRetVal;
                TryGetIsAcceleratorStubFunction(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Indicates whether the symbol corresponds to a top-level function symbol for a shader compiled for an accelerator that corresponds to a parallel_for_each call.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that indicates whether the symbol corresponds to a top-level function symbol for a shader compiled for an accelerator that corresponds to a parallel_for_each call.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsAcceleratorStubFunction(out bool pRetVal)
        {
            /*HRESULT get_isAcceleratorStubFunction(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isAcceleratorStubFunction(out pRetVal);
        }

        #endregion
        #region NumberOfAcceleratorPointerTags

        /// <summary>
        /// Returns the number of accelerator pointer tags in a C++ AMP stub function.
        /// </summary>
        public int NumberOfAcceleratorPointerTags
        {
            get
            {
                int pRetVal;
                TryGetNumberOfAcceleratorPointerTags(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Returns the number of accelerator pointer tags in a C++ AMP stub function.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a DWORD that holds the number of accelerator pointer tags in a C++ AMP stub function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This method is called on an IDiaSymbol interface that corresponds to a C++ AMP accelerator stub function.
        /// </remarks>
        public HRESULT TryGetNumberOfAcceleratorPointerTags(out int pRetVal)
        {
            /*HRESULT get_numberOfAcceleratorPointerTags(
            [Out] out int pRetVal);*/
            return Raw.get_numberOfAcceleratorPointerTags(out pRetVal);
        }

        #endregion
        #region IsSdl

        /// <summary>
        /// Specifies whether the module is compiled with the /SDL option.
        /// </summary>
        public bool IsSdl
        {
            get
            {
                bool pRetVal;
                TryGetIsSdl(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Specifies whether the module is compiled with the /SDL option.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a BOOL that specifies whether the module is compiled with the /SDL option.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetIsSdl(out bool pRetVal)
        {
            /*HRESULT get_isSdl(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isSdl(out pRetVal);
        }

        #endregion
        #region IsWinRTPointer

        public bool IsWinRTPointer
        {
            get
            {
                bool pRetVal;
                TryGetIsWinRTPointer(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsWinRTPointer(out bool pRetVal)
        {
            /*HRESULT get_isWinRTPointer(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isWinRTPointer(out pRetVal);
        }

        #endregion
        #region IsRefUdt

        public bool IsRefUdt
        {
            get
            {
                bool pRetVal;
                TryGetIsRefUdt(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsRefUdt(out bool pRetVal)
        {
            /*HRESULT get_isRefUdt(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isRefUdt(out pRetVal);
        }

        #endregion
        #region IsValueUdt

        public bool IsValueUdt
        {
            get
            {
                bool pRetVal;
                TryGetIsValueUdt(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsValueUdt(out bool pRetVal)
        {
            /*HRESULT get_isValueUdt(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isValueUdt(out pRetVal);
        }

        #endregion
        #region IsInterfaceUdt

        public bool IsInterfaceUdt
        {
            get
            {
                bool pRetVal;
                TryGetIsInterfaceUdt(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsInterfaceUdt(out bool pRetVal)
        {
            /*HRESULT get_isInterfaceUdt(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isInterfaceUdt(out pRetVal);
        }

        #endregion
        #region AcceleratorPointerTags

        /// <summary>
        /// Returns all accelerator pointer tag values that correspond to a C++ AMP accelerator stub function.
        /// </summary>
        public int[] AcceleratorPointerTags
        {
            get
            {
                int[] pPointerTags;
                TryGetAcceleratorPointerTags(out pPointerTags).ThrowOnNotOK();

                return pPointerTags;
            }
        }

        /// <summary>
        /// Returns all accelerator pointer tag values that correspond to a C++ AMP accelerator stub function.
        /// </summary>
        /// <param name="pPointerTags">[out] A DWORD array pointer that is filled with the accelerator pointer tag values in the C++ AMP accelerator stub function.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// This method is called on an IDiaSymbol interface that corresponds to a C++ AMP accelerator stub function.
        /// </remarks>
        public HRESULT TryGetAcceleratorPointerTags(out int[] pPointerTags)
        {
            /*HRESULT get_acceleratorPointerTags(
            [In] int cnt,
            [Out] out int pcnt,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] pPointerTags);*/
            int cnt = 0;
            int pcnt;
            pPointerTags = null;
            HRESULT hr = Raw.get_acceleratorPointerTags(cnt, out pcnt, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cnt = pcnt;
            pPointerTags = new int[cnt];
            hr = Raw.get_acceleratorPointerTags(cnt, out pcnt, pPointerTags);
            fail:
            return hr;
        }

        #endregion
        #region SrcLineOnTypeDefn

        /// <summary>
        /// Retrieves the source file and line number that indicate where a specified user-defined type is defined.
        /// </summary>
        public DiaLineNumber SrcLineOnTypeDefn
        {
            get
            {
                DiaLineNumber ppResultResult;
                TryGetSrcLineOnTypeDefn(out ppResultResult).ThrowOnNotOK();

                return ppResultResult;
            }
        }

        /// <summary>
        /// Retrieves the source file and line number that indicate where a specified user-defined type is defined.
        /// </summary>
        /// <param name="ppResultResult">[out] A IDiaLineNumber object that contains the source file and line number where the user-defined.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryGetSrcLineOnTypeDefn(out DiaLineNumber ppResultResult)
        {
            /*HRESULT getSrcLineOnTypeDefn(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaLineNumber ppResult);*/
            IDiaLineNumber ppResult;
            HRESULT hr = Raw.getSrcLineOnTypeDefn(out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaLineNumber(ppResult);
            else
                ppResultResult = default(DiaLineNumber);

            return hr;
        }

        #endregion
        #region IsPGO

        public bool IsPGO
        {
            get
            {
                bool pRetVal;
                TryGetIsPGO(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsPGO(out bool pRetVal)
        {
            /*HRESULT get_isPGO(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isPGO(out pRetVal);
        }

        #endregion
        #region HasValidPGOCounts

        public bool HasValidPGOCounts
        {
            get
            {
                bool pRetVal;
                TryGetHasValidPGOCounts(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetHasValidPGOCounts(out bool pRetVal)
        {
            /*HRESULT get_hasValidPGOCounts(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasValidPGOCounts(out pRetVal);
        }

        #endregion
        #region IsOptimizedForSpeed

        public bool IsOptimizedForSpeed
        {
            get
            {
                bool pRetVal;
                TryGetIsOptimizedForSpeed(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsOptimizedForSpeed(out bool pRetVal)
        {
            /*HRESULT get_isOptimizedForSpeed(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_isOptimizedForSpeed(out pRetVal);
        }

        #endregion
        #region PGOEntryCount

        public int PGOEntryCount
        {
            get
            {
                int pRetVal;
                TryGetPGOEntryCount(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetPGOEntryCount(out int pRetVal)
        {
            /*HRESULT get_PGOEntryCount(
            [Out] out int pRetVal);*/
            return Raw.get_PGOEntryCount(out pRetVal);
        }

        #endregion
        #region PGOEdgeCount

        public int PGOEdgeCount
        {
            get
            {
                int pRetVal;
                TryGetPGOEdgeCount(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetPGOEdgeCount(out int pRetVal)
        {
            /*HRESULT get_PGOEdgeCount(
            [Out] out int pRetVal);*/
            return Raw.get_PGOEdgeCount(out pRetVal);
        }

        #endregion
        #region PGODynamicInstructionCount

        public long PGODynamicInstructionCount
        {
            get
            {
                long pRetVal;
                TryGetPGODynamicInstructionCount(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetPGODynamicInstructionCount(out long pRetVal)
        {
            /*HRESULT get_PGODynamicInstructionCount(
            [Out] out long pRetVal);*/
            return Raw.get_PGODynamicInstructionCount(out pRetVal);
        }

        #endregion
        #region StaticSize

        public int StaticSize
        {
            get
            {
                int pRetVal;
                TryGetStaticSize(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetStaticSize(out int pRetVal)
        {
            /*HRESULT get_staticSize(
            [Out] out int pRetVal);*/
            return Raw.get_staticSize(out pRetVal);
        }

        #endregion
        #region FinalLiveStaticSize

        public int FinalLiveStaticSize
        {
            get
            {
                int pRetVal;
                TryGetFinalLiveStaticSize(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetFinalLiveStaticSize(out int pRetVal)
        {
            /*HRESULT get_finalLiveStaticSize(
            [Out] out int pRetVal);*/
            return Raw.get_finalLiveStaticSize(out pRetVal);
        }

        #endregion
        #region PhaseName

        public string PhaseName
        {
            get
            {
                string pRetVal;
                TryGetPhaseName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetPhaseName(out string pRetVal)
        {
            /*HRESULT get_phaseName(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_phaseName(out pRetVal);
        }

        #endregion
        #region HasControlFlowCheck

        public bool HasControlFlowCheck
        {
            get
            {
                bool pRetVal;
                TryGetHasControlFlowCheck(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetHasControlFlowCheck(out bool pRetVal)
        {
            /*HRESULT get_hasControlFlowCheck(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_hasControlFlowCheck(out pRetVal);
        }

        #endregion
        #region ConstantExport

        public bool ConstantExport
        {
            get
            {
                bool pRetVal;
                TryGetConstantExport(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetConstantExport(out bool pRetVal)
        {
            /*HRESULT get_constantExport(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_constantExport(out pRetVal);
        }

        #endregion
        #region DataExport

        public bool DataExport
        {
            get
            {
                bool pRetVal;
                TryGetDataExport(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetDataExport(out bool pRetVal)
        {
            /*HRESULT get_dataExport(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_dataExport(out pRetVal);
        }

        #endregion
        #region PrivateExport

        public bool PrivateExport
        {
            get
            {
                bool pRetVal;
                TryGetPrivateExport(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetPrivateExport(out bool pRetVal)
        {
            /*HRESULT get_privateExport(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_privateExport(out pRetVal);
        }

        #endregion
        #region NoNameExport

        public int NoNameExport
        {
            get
            {
                int pRetVal;
                TryGetNoNameExport(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetNoNameExport(out int pRetVal)
        {
            /*HRESULT get_noNameExport(
            [Out] out int pRetVal);*/
            return Raw.get_noNameExport(out pRetVal);
        }

        #endregion
        #region ExportHasExplicitlyAssignedOrdinal

        public bool ExportHasExplicitlyAssignedOrdinal
        {
            get
            {
                bool pRetVal;
                TryGetExportHasExplicitlyAssignedOrdinal(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetExportHasExplicitlyAssignedOrdinal(out bool pRetVal)
        {
            /*HRESULT get_exportHasExplicitlyAssignedOrdinal(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_exportHasExplicitlyAssignedOrdinal(out pRetVal);
        }

        #endregion
        #region ExportIsForwarder

        public bool ExportIsForwarder
        {
            get
            {
                bool pRetVal;
                TryGetExportIsForwarder(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetExportIsForwarder(out bool pRetVal)
        {
            /*HRESULT get_exportIsForwarder(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_exportIsForwarder(out pRetVal);
        }

        #endregion
        #region Ordinal

        public int Ordinal
        {
            get
            {
                int pRetVal;
                TryGetOrdinal(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetOrdinal(out int pRetVal)
        {
            /*HRESULT get_ordinal(
            [Out] out int pRetVal);*/
            return Raw.get_ordinal(out pRetVal);
        }

        #endregion
        #region FrameSize

        public int FrameSize
        {
            get
            {
                int pRetVal;
                TryGetFrameSize(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetFrameSize(out int pRetVal)
        {
            /*HRESULT get_frameSize(
            [Out] out int pRetVal);*/
            return Raw.get_frameSize(out pRetVal);
        }

        #endregion
        #region ExceptionHandlerAddressSection

        public int ExceptionHandlerAddressSection
        {
            get
            {
                int pRetVal;
                TryGetExceptionHandlerAddressSection(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetExceptionHandlerAddressSection(out int pRetVal)
        {
            /*HRESULT get_exceptionHandlerAddressSection(
            [Out] out int pRetVal);*/
            return Raw.get_exceptionHandlerAddressSection(out pRetVal);
        }

        #endregion
        #region ExceptionHandlerAddressOffset

        public int ExceptionHandlerAddressOffset
        {
            get
            {
                int pRetVal;
                TryGetExceptionHandlerAddressOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetExceptionHandlerAddressOffset(out int pRetVal)
        {
            /*HRESULT get_exceptionHandlerAddressOffset(
            [Out] out int pRetVal);*/
            return Raw.get_exceptionHandlerAddressOffset(out pRetVal);
        }

        #endregion
        #region ExceptionHandlerRelativeVirtualAddress

        public int ExceptionHandlerRelativeVirtualAddress
        {
            get
            {
                int pRetVal;
                TryGetExceptionHandlerRelativeVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetExceptionHandlerRelativeVirtualAddress(out int pRetVal)
        {
            /*HRESULT get_exceptionHandlerRelativeVirtualAddress(
            [Out] out int pRetVal);*/
            return Raw.get_exceptionHandlerRelativeVirtualAddress(out pRetVal);
        }

        #endregion
        #region ExceptionHandlerVirtualAddress

        public long ExceptionHandlerVirtualAddress
        {
            get
            {
                long pRetVal;
                TryGetExceptionHandlerVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetExceptionHandlerVirtualAddress(out long pRetVal)
        {
            /*HRESULT get_exceptionHandlerVirtualAddress(
            [Out] out long pRetVal);*/
            return Raw.get_exceptionHandlerVirtualAddress(out pRetVal);
        }

        #endregion
        #region Characteristics

        public int Characteristics
        {
            get
            {
                int pRetVal;
                TryGetCharacteristics(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetCharacteristics(out int pRetVal)
        {
            /*HRESULT get_characteristics(
            [Out] out int pRetVal);*/
            return Raw.get_characteristics(out pRetVal);
        }

        #endregion
        #region CoffGroup

        public DiaSymbol CoffGroup
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetCoffGroup(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        public HRESULT TryGetCoffGroup(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_coffGroup(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_coffGroup(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region BindID

        public int BindID
        {
            get
            {
                int pRetVal;
                TryGetBindID(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetBindID(out int pRetVal)
        {
            /*HRESULT get_bindID(
            [Out] out int pRetVal);*/
            return Raw.get_bindID(out pRetVal);
        }

        #endregion
        #region BindSpace

        public int BindSpace
        {
            get
            {
                int pRetVal;
                TryGetBindSpace(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetBindSpace(out int pRetVal)
        {
            /*HRESULT get_bindSpace(
            [Out] out int pRetVal);*/
            return Raw.get_bindSpace(out pRetVal);
        }

        #endregion
        #region BindSlot

        public int BindSlot
        {
            get
            {
                int pRetVal;
                TryGetBindSlot(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetBindSlot(out int pRetVal)
        {
            /*HRESULT get_bindSlot(
            [Out] out int pRetVal);*/
            return Raw.get_bindSlot(out pRetVal);
        }

        #endregion
        #region FindChildren

        /// <summary>
        /// Retrieves the children of the symbol.
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <returns>[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</returns>
        /// <remarks>
        /// This method is identical to calling the IDiaSession method with this symbol as the first parameter.
        /// </remarks>
        public DiaEnumSymbols FindChildren(SymTagEnum symTag, string name, NameSearchOptions compareFlags)
        {
            DiaEnumSymbols ppResultResult;
            TryFindChildren(symTag, name, compareFlags, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves the children of the symbol.
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="ppResultResult">[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</param>
        /// <returns>Returns S_OK if at least one child of the symbol was found, or returns S_FALSE if no children were found; otherwise returns an error code.</returns>
        /// <remarks>
        /// This method is identical to calling the IDiaSession method with this symbol as the first parameter.
        /// </remarks>
        public HRESULT TryFindChildren(SymTagEnum symTag, string name, NameSearchOptions compareFlags, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findChildren(
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findChildren(symTag, name, compareFlags, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindChildrenEx

        /// <summary>
        /// Retrieves the children of the symbol. The local symbols that are returned include live range information, if the program is compiled with optimization on.
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <returns>[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</returns>
        /// <remarks>
        /// This method is the extended version of IDiaSymbol.
        /// </remarks>
        public DiaEnumSymbols FindChildrenEx(SymTagEnum symTag, string name, NameSearchOptions compareFlags)
        {
            DiaEnumSymbols ppResultResult;
            TryFindChildrenEx(symTag, name, compareFlags, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves the children of the symbol. The local symbols that are returned include live range information, if the program is compiled with optimization on.
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="ppResultResult">[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</param>
        /// <returns>Returns S_OK if at least one child of the symbol was found, or returns S_FALSE if no children were found; otherwise, returns an error code.</returns>
        /// <remarks>
        /// This method is the extended version of IDiaSymbol.
        /// </remarks>
        public HRESULT TryFindChildrenEx(SymTagEnum symTag, string name, NameSearchOptions compareFlags, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findChildrenEx(
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findChildrenEx(symTag, name, compareFlags, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindChildrenExByAddr

        /// <summary>
        /// Retrieves the children of the symbol that are valid at a specified address.
        /// </summary>
        /// <param name="symtag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="address">[in] The address of the symbol.</param>
        /// <returns>[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</returns>
        /// <remarks>
        /// The local symbols that are returned include live range information.
        /// </remarks>
        public DiaEnumSymbols FindChildrenExByAddr(SymTagEnum symtag, string name, NameSearchOptions compareFlags, int address)
        {
            DiaEnumSymbols ppResultResult;
            TryFindChildrenExByAddr(symtag, name, compareFlags, address, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves the children of the symbol that are valid at a specified address.
        /// </summary>
        /// <param name="symtag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="address">[in] The address of the symbol.</param>
        /// <param name="ppResultResult">[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</param>
        /// <returns>Returns S_OK if at least one child of the symbol was found, or returns S_FALSE if no children were found; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The local symbols that are returned include live range information.
        /// </remarks>
        public HRESULT TryFindChildrenExByAddr(SymTagEnum symtag, string name, NameSearchOptions compareFlags, int address, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findChildrenExByAddr(
            [In] SymTagEnum symtag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] int address,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findChildrenExByAddr(symtag, name, compareFlags, address, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindChildrenExByVA

        /// <summary>
        /// Retrieves the children of the symbol that are valid at a specified virtual address.
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="va">[in] Specifies the virtual address.</param>
        /// <returns>[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</returns>
        /// <remarks>
        /// The local symbols that are returned include live range information.
        /// </remarks>
        public DiaEnumSymbols FindChildrenExByVA(SymTagEnum symTag, string name, NameSearchOptions compareFlags, long va)
        {
            DiaEnumSymbols ppResultResult;
            TryFindChildrenExByVA(symTag, name, compareFlags, va, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves the children of the symbol that are valid at a specified virtual address.
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="va">[in] Specifies the virtual address.</param>
        /// <param name="ppResultResult">[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</param>
        /// <returns>Returns S_OK if at least one child of the symbol was found, or returns S_FALSE if no children were found; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The local symbols that are returned include live range information.
        /// </remarks>
        public HRESULT TryFindChildrenExByVA(SymTagEnum symTag, string name, NameSearchOptions compareFlags, long va, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findChildrenExByVA(
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findChildrenExByVA(symTag, name, compareFlags, va, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindChildrenExByRVA

        /// <summary>
        /// Retrieves the children of the symbol that are valid at a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="rva">[in] Specifies the RVA.</param>
        /// <returns>[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</returns>
        /// <remarks>
        /// The local symbols that are returned include live range information.
        /// </remarks>
        public DiaEnumSymbols FindChildrenExByRVA(SymTagEnum symTag, string name, NameSearchOptions compareFlags, int rva)
        {
            DiaEnumSymbols ppResultResult;
            TryFindChildrenExByRVA(symTag, name, compareFlags, rva, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves the children of the symbol that are valid at a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="symTag">[in] Specifies the symbol tags of the children to be retrieved, as defined in the SymTagEnum Enumeration. Set to SymTagNull for all children to be retrieved.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options to be applied to name matching. Values from the NameSearchOptions Enumeration enumeration can be used alone or in combination.</param>
        /// <param name="rva">[in] Specifies the RVA.</param>
        /// <param name="ppResultResult">[out] Returns an IDiaEnumSymbols object that contains a list of the child symbols retrieved.</param>
        /// <returns>Returns S_OK if at least one child of the symbol was found, or returns S_FALSE if no children were found; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The local symbols that are returned include live range information.
        /// </remarks>
        public HRESULT TryFindChildrenExByRVA(SymTagEnum symTag, string name, NameSearchOptions compareFlags, int rva, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findChildrenExByRVA(
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findChildrenExByRVA(symTag, name, compareFlags, rva, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region GetUndecoratedNameEx

        /// <summary>
        /// Retrieves part or all of an undecorated name for a C++ decorated (linkage) name.
        /// </summary>
        /// <param name="undecorateOptions">[in] Specifies a combination of flags that control what is returned. See the Remarks section for the specific values and what they do.</param>
        /// <returns>[out] Returns the undecorated name for a C++ decorated name.</returns>
        /// <remarks>
        /// The undecorateOptions can be a combination of the following flags.
        /// </remarks>
        public string GetUndecoratedNameEx(UNDNAME undecorateOptions)
        {
            string name;
            TryGetUndecoratedNameEx(undecorateOptions, out name).ThrowOnNotOK();

            return name;
        }

        /// <summary>
        /// Retrieves part or all of an undecorated name for a C++ decorated (linkage) name.
        /// </summary>
        /// <param name="undecorateOptions">[in] Specifies a combination of flags that control what is returned. See the Remarks section for the specific values and what they do.</param>
        /// <param name="name">[out] Returns the undecorated name for a C++ decorated name.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The undecorateOptions can be a combination of the following flags.
        /// </remarks>
        public HRESULT TryGetUndecoratedNameEx(UNDNAME undecorateOptions, out string name)
        {
            /*HRESULT get_undecoratedNameEx(
            [In] UNDNAME undecorateOptions,
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string name);*/
            return Raw.get_undecoratedNameEx(undecorateOptions, out name);
        }

        #endregion
        #region FindInlineFramesByAddr

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a given address.
        /// </summary>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <returns>[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</returns>
        public DiaEnumSymbols FindInlineFramesByAddr(int isect, int offset)
        {
            DiaEnumSymbols ppResultResult;
            TryFindInlineFramesByAddr(isect, offset, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a given address.
        /// </summary>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineFramesByAddr(int isect, int offset, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findInlineFramesByAddr(
            [In] int isect,
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findInlineFramesByAddr(isect, offset, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindInlineFramesByRVA

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <returns>[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</returns>
        public DiaEnumSymbols FindInlineFramesByRVA(int rva)
        {
            DiaEnumSymbols ppResultResult;
            TryFindInlineFramesByRVA(rva, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineFramesByRVA(int rva, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findInlineFramesByRVA(
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findInlineFramesByRVA(rva, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindInlineFramesByVA

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified virtual address (VA).
        /// </summary>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <returns>[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</returns>
        public DiaEnumSymbols FindInlineFramesByVA(long va)
        {
            DiaEnumSymbols ppResultResult;
            TryFindInlineFramesByVA(va, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified virtual address (VA).
        /// </summary>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineFramesByVA(long va, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findInlineFramesByVA(
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findInlineFramesByVA(va, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindInlineeLines

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol.
        /// </summary>
        /// <returns>[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</returns>
        public DiaEnumLineNumbers FindInlineeLines()
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindInlineeLines(out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol.
        /// </summary>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineeLines(out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findInlineeLines(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findInlineeLines(out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindInlineeLinesByAddr

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol within the specified address range.
        /// </summary>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <returns>[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</returns>
        public DiaEnumLineNumbers FindInlineeLinesByAddr(int isect, int offset, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindInlineeLinesByAddr(isect, offset, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol within the specified address range.
        /// </summary>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineeLinesByAddr(int isect, int offset, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findInlineeLinesByAddr(
            [In] int isect,
            [In] int offset,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findInlineeLinesByAddr(isect, offset, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindInlineeLinesByRVA

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol within the specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <returns>[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</returns>
        public DiaEnumLineNumbers FindInlineeLinesByRVA(int rva, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindInlineeLinesByRVA(rva, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol within the specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineeLinesByRVA(int rva, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findInlineeLinesByRVA(
            [In] int rva,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findInlineeLinesByRVA(rva, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindInlineeLinesByVA

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol within the specified virtual address (VA).
        /// </summary>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <returns>[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</returns>
        public DiaEnumLineNumbers FindInlineeLinesByVA(long va, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindInlineeLinesByVA(va, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in this symbol within the specified virtual address (VA).
        /// </summary>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineeLinesByVA(long va, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findInlineeLinesByVA(
            [In] long va,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findInlineeLinesByVA(va, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindSymbolsForAcceleratorPointerTag

        /// <summary>
        /// Given a corresponding tag value, this method returns an enumeration of symbols that are contained in this stub function.
        /// </summary>
        /// <param name="tagValue">[in] The pointer tag value for which the pointee symbol records are found.</param>
        /// <returns>[out] A pointer to an IDiaEnumSymbols interface pointer which is initialized with the result.</returns>
        public DiaEnumSymbols FindSymbolsForAcceleratorPointerTag(int tagValue)
        {
            DiaEnumSymbols ppResultResult;
            TryFindSymbolsForAcceleratorPointerTag(tagValue, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Given a corresponding tag value, this method returns an enumeration of symbols that are contained in this stub function.
        /// </summary>
        /// <param name="tagValue">[in] The pointer tag value for which the pointee symbol records are found.</param>
        /// <param name="ppResultResult">[out] A pointer to an IDiaEnumSymbols interface pointer which is initialized with the result.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        public HRESULT TryFindSymbolsForAcceleratorPointerTag(int tagValue, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findSymbolsForAcceleratorPointerTag(
            [In] int tagValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findSymbolsForAcceleratorPointerTag(tagValue, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindSymbolsByRVAForAcceleratorPointerTag

        /// <summary>
        /// Given a corresponding tag value, this method returns an enumeration of symbols that are contained in this stub function at a specified relative virtual address.
        /// </summary>
        /// <param name="tagValue">[in] The pointer tag value for which the pointee symbol records are found.</param>
        /// <param name="rva">[in] The rva that is used to filter the symbols that correspond to the pointee variable with the specified tag value.</param>
        /// <returns>[out] A pointer to an IDiaEnumSymbols interface pointer which is initialized with the result.</returns>
        /// <remarks>
        /// Call this method only on an IDiaSymbol interface that corresponds to an Accelerator stub function.
        /// </remarks>
        public DiaEnumSymbols FindSymbolsByRVAForAcceleratorPointerTag(int tagValue, int rva)
        {
            DiaEnumSymbols ppResultResult;
            TryFindSymbolsByRVAForAcceleratorPointerTag(tagValue, rva, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Given a corresponding tag value, this method returns an enumeration of symbols that are contained in this stub function at a specified relative virtual address.
        /// </summary>
        /// <param name="tagValue">[in] The pointer tag value for which the pointee symbol records are found.</param>
        /// <param name="rva">[in] The rva that is used to filter the symbols that correspond to the pointee variable with the specified tag value.</param>
        /// <param name="ppResultResult">[out] A pointer to an IDiaEnumSymbols interface pointer which is initialized with the result.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// Call this method only on an IDiaSymbol interface that corresponds to an Accelerator stub function.
        /// </remarks>
        public HRESULT TryFindSymbolsByRVAForAcceleratorPointerTag(int tagValue, int rva, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findSymbolsByRVAForAcceleratorPointerTag(
            [In] int tagValue,
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findSymbolsByRVAForAcceleratorPointerTag(tagValue, rva, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindInputAssemblyFile

        public DiaInputAssemblyFile FindInputAssemblyFile()
        {
            DiaInputAssemblyFile ppResultResult;
            TryFindInputAssemblyFile(out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindInputAssemblyFile(out DiaInputAssemblyFile ppResultResult)
        {
            /*HRESULT findInputAssemblyFile(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);*/
            IDiaInputAssemblyFile ppResult;
            HRESULT hr = Raw.findInputAssemblyFile(out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaInputAssemblyFile(ppResult);
            else
                ppResultResult = default(DiaInputAssemblyFile);

            return hr;
        }

        #endregion
        #endregion
        #region IDiaSymbol2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaSymbol2 Raw2 => (IDiaSymbol2) Raw;

        #region IsObjCClass

        public bool IsObjCClass
        {
            get
            {
                bool pRetVal;
                TryGetIsObjCClass(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsObjCClass(out bool pRetVal)
        {
            /*HRESULT get_isObjCClass(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw2.get_isObjCClass(out pRetVal);
        }

        #endregion
        #region IsObjCCategory

        public bool IsObjCCategory
        {
            get
            {
                bool pRetVal;
                TryGetIsObjCCategory(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsObjCCategory(out bool pRetVal)
        {
            /*HRESULT get_isObjCCategory(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw2.get_isObjCCategory(out pRetVal);
        }

        #endregion
        #region IsObjCProtocol

        public bool IsObjCProtocol
        {
            get
            {
                bool pRetVal;
                TryGetIsObjCProtocol(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsObjCProtocol(out bool pRetVal)
        {
            /*HRESULT get_isObjCProtocol(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw2.get_isObjCProtocol(out pRetVal);
        }

        #endregion
        #endregion
        #region IDiaSymbol3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaSymbol3 Raw3 => (IDiaSymbol3) Raw;

        #region Inlinee

        public DiaSymbol Inlinee
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetInlinee(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        public HRESULT TryGetInlinee(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_inlinee(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw3.get_inlinee(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region InlineeId

        public int InlineeId
        {
            get
            {
                int pRetVal;
                TryGetInlineeId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetInlineeId(out int pRetVal)
        {
            /*HRESULT get_inlineeId(
            [Out] out int pRetVal);*/
            return Raw3.get_inlineeId(out pRetVal);
        }

        #endregion
        #endregion
        #region IDiaSymbol4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaSymbol4 Raw4 => (IDiaSymbol4) Raw;

        #region Noexcept

        public bool Noexcept
        {
            get
            {
                bool pRetVal;
                TryGetNoexcept(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetNoexcept(out bool pRetVal)
        {
            /*HRESULT get_noexcept(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw4.get_noexcept(out pRetVal);
        }

        #endregion
        #endregion
        #region IDiaSymbol5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaSymbol5 Raw5 => (IDiaSymbol5) Raw;

        #region HasAbsoluteAddress

        public bool HasAbsoluteAddress
        {
            get
            {
                bool pRetVal;
                TryGetHasAbsoluteAddress(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetHasAbsoluteAddress(out bool pRetVal)
        {
            /*HRESULT get_hasAbsoluteAddress(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw5.get_hasAbsoluteAddress(out pRetVal);
        }

        #endregion
        #endregion
        #region IDiaSymbol6

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaSymbol6 Raw6 => (IDiaSymbol6) Raw;

        #region IsStaticMemberFunc

        public bool IsStaticMemberFunc
        {
            get
            {
                bool pRetVal;
                TryGetIsStaticMemberFunc(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsStaticMemberFunc(out bool pRetVal)
        {
            /*HRESULT get_isStaticMemberFunc(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw6.get_isStaticMemberFunc(out pRetVal);
        }

        #endregion
        #endregion
        #region IDiaSymbol7

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaSymbol7 Raw7 => (IDiaSymbol7) Raw;

        #region IsSignRet

        public bool IsSignRet
        {
            get
            {
                bool pRetVal;
                TryGetIsSignRet(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsSignRet(out bool pRetVal)
        {
            /*HRESULT get_isSignRet(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw7.get_isSignRet(out pRetVal);
        }

        #endregion
        #endregion
        #region IDiaSymbol8

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaSymbol8 Raw8 => (IDiaSymbol8) Raw;

        #region CoroutineKind

        public int CoroutineKind
        {
            get
            {
                int pRetVal;
                TryGetCoroutineKind(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetCoroutineKind(out int pRetVal)
        {
            /*HRESULT get_coroutineKind(
            [Out] out int pRetVal);*/
            return Raw8.get_coroutineKind(out pRetVal);
        }

        #endregion
        #region AssociatedSymbolKind

        public int AssociatedSymbolKind
        {
            get
            {
                int pRetVal;
                TryGetAssociatedSymbolKind(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetAssociatedSymbolKind(out int pRetVal)
        {
            /*HRESULT get_associatedSymbolKind(
            [Out] out int pRetVal);*/
            return Raw8.get_associatedSymbolKind(out pRetVal);
        }

        #endregion
        #region AssociatedSymbolSection

        public int AssociatedSymbolSection
        {
            get
            {
                int pRetVal;
                TryGetAssociatedSymbolSection(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetAssociatedSymbolSection(out int pRetVal)
        {
            /*HRESULT get_associatedSymbolSection(
            [Out] out int pRetVal);*/
            return Raw8.get_associatedSymbolSection(out pRetVal);
        }

        #endregion
        #region AssociatedSymbolOffset

        public int AssociatedSymbolOffset
        {
            get
            {
                int pRetVal;
                TryGetAssociatedSymbolOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetAssociatedSymbolOffset(out int pRetVal)
        {
            /*HRESULT get_associatedSymbolOffset(
            [Out] out int pRetVal);*/
            return Raw8.get_associatedSymbolOffset(out pRetVal);
        }

        #endregion
        #region AssociatedSymbolRva

        public int AssociatedSymbolRva
        {
            get
            {
                int pRetVal;
                TryGetAssociatedSymbolRva(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetAssociatedSymbolRva(out int pRetVal)
        {
            /*HRESULT get_associatedSymbolRva(
            [Out] out int pRetVal);*/
            return Raw8.get_associatedSymbolRva(out pRetVal);
        }

        #endregion
        #region AssociatedSymbolAddr

        public long AssociatedSymbolAddr
        {
            get
            {
                long pRetVal;
                TryGetAssociatedSymbolAddr(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetAssociatedSymbolAddr(out long pRetVal)
        {
            /*HRESULT get_associatedSymbolAddr(
            [Out] out long pRetVal);*/
            return Raw8.get_associatedSymbolAddr(out pRetVal);
        }

        #endregion
        #endregion
        #region IDiaSymbol9

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaSymbol9 Raw9 => (IDiaSymbol9) Raw;

        #region FramePadSize

        public int FramePadSize
        {
            get
            {
                int pRetVal;
                TryGetFramePadSize(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetFramePadSize(out int pRetVal)
        {
            /*HRESULT get_framePadSize(
            [Out] out int pRetVal);*/
            return Raw9.get_framePadSize(out pRetVal);
        }

        #endregion
        #region FramePadOffset

        public int FramePadOffset
        {
            get
            {
                int pRetVal;
                TryGetFramePadOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetFramePadOffset(out int pRetVal)
        {
            /*HRESULT get_framePadOffset(
            [Out] out int pRetVal);*/
            return Raw9.get_framePadOffset(out pRetVal);
        }

        #endregion
        #region IsRTCs

        public bool IsRTCs
        {
            get
            {
                bool pRetVal;
                TryGetIsRTCs(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetIsRTCs(out bool pRetVal)
        {
            /*HRESULT get_isRTCs(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw9.get_isRTCs(out pRetVal);
        }

        #endregion
        #endregion
        #region IDiaSymbol10

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaSymbol10 Raw10 => (IDiaSymbol10) Raw;

        #region SourceLink

        public byte[] SourceLink
        {
            get
            {
                byte[] pb;
                TryGetSourceLink(out pb).ThrowOnNotOK();

                return pb;
            }
        }

        public HRESULT TryGetSourceLink(out byte[] pb)
        {
            /*HRESULT get_sourceLink(
            [In] int cb,
            [Out] out int pcb,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] pb);*/
            int cb = 0;
            int pcb;
            pb = null;
            HRESULT hr = Raw10.get_sourceLink(cb, out pcb, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cb = pcb;
            pb = new byte[cb];
            hr = Raw10.get_sourceLink(cb, out pcb, pb);
            fail:
            return hr;
        }

        #endregion
        #endregion
        #region IDiaSymbol11

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaSymbol11 Raw11 => (IDiaSymbol11) Raw;

        #region DiscriminatedUnionTag

        public GetDiscriminatedUnionTagResult DiscriminatedUnionTag
        {
            get
            {
                GetDiscriminatedUnionTagResult result;
                TryGetDiscriminatedUnionTag(out result).ThrowOnNotOK();

                return result;
            }
        }

        public HRESULT TryGetDiscriminatedUnionTag(out GetDiscriminatedUnionTagResult result)
        {
            /*HRESULT get_discriminatedUnionTag(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppTagType,
            [Out] out int pTagOffset,
            [Out] out DiaTagValue pTagMask);*/
            IDiaSymbol ppTagType;
            int pTagOffset;
            DiaTagValue pTagMask;
            HRESULT hr = Raw11.get_discriminatedUnionTag(out ppTagType, out pTagOffset, out pTagMask);

            if (hr == HRESULT.S_OK)
                result = new GetDiscriminatedUnionTagResult(ppTagType == null ? null : new DiaSymbol(ppTagType), pTagOffset, pTagMask);
            else
                result = default(GetDiscriminatedUnionTagResult);

            return hr;
        }

        #endregion
        #region TagRanges

        public DiaTagValue[] TagRanges
        {
            get
            {
                DiaTagValue[] rangeValues;
                TryGetTagRanges(out rangeValues).ThrowOnNotOK();

                return rangeValues;
            }
        }

        public HRESULT TryGetTagRanges(out DiaTagValue[] rangeValues)
        {
            /*HRESULT get_tagRanges(
            [In] int count,
            [Out] out int pcRangeValues,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DiaTagValue[] rangeValues);*/
            int count = 0;
            int pcRangeValues;
            rangeValues = null;
            HRESULT hr = Raw11.get_tagRanges(count, out pcRangeValues, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = pcRangeValues;
            rangeValues = new DiaTagValue[count];
            hr = Raw11.get_tagRanges(count, out pcRangeValues, rangeValues);
            fail:
            return hr;
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
