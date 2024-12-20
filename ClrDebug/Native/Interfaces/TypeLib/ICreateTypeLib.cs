using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Provides the methods for creating and managing the component or file that contains type information. Type libraries are created from type descriptions using the MIDL compiler.<para/>
    /// These type libraries are accessed through the ITypeLib interface.
    /// </summary>
    [Guid("00020406-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICreateTypeLib
    {
        /// <summary>
        /// Creates a new type description instance within the type library.
        /// </summary>
        /// <param name="szName">[in] The name of the new type.</param>
        /// <param name="tkind">[in] TYPEKIND of the type description to be created.</param>
        /// <param name="ppCTInfo">[out] The type description.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// Use <see cref="ICreateTypeLib"/> to create a new type description instance within the library. An error is returned
        /// if the specified name already appears in the library. Valid tkind values are described in TYPEKIND. To get the
        /// type information of the type description that is being created, call IUnknown::QueryInterface(IID_ITypeInfo, ...)
        /// on the returned ICreateTypeLib. This type information can be used by other type descriptions that reference it
        /// by using <see cref="ICreateTypeInfo.AddRefTypeInfo"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateTypeInfo(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] TYPEKIND tkind,
            [Out] out ICreateTypeInfo ppCTInfo);

        /// <summary>
        /// Sets the name of the type library.
        /// </summary>
        /// <param name="szName">[in] The name to be assigned to the library.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName);

        /// <summary>
        /// Sets the major and minor version numbers of the type library.
        /// </summary>
        /// <param name="wMajorVerNum">[in] The major version number for the library.</param>
        /// <param name="wMinorVerNum">[in] The minor version number for the library.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetVersion(
            [In] short wMajorVerNum,
            [In] short wMinorVerNum);

        /// <summary>
        /// Sets the universal unique identifier (UUID) associated with the type library (Also known as the globally unique identifier (GUID)).
        /// </summary>
        /// <param name="guid">[in] The globally unique identifier to be assigned to the library.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetGuid(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid guid);

        /// <summary>
        /// Sets the documentation string associated with the library.
        /// </summary>
        /// <param name="szDoc">[in] A brief description of the type library.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// The documentation string is a brief description of the library intended for use by type information browsing tools.
        /// </remarks>
        [PreserveSig]
        HRESULT SetDocString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szDoc);

        /// <summary>
        /// Sets the name of the Help file.
        /// </summary>
        /// <param name="szHelpFileName">[in] The name of the Help file for the library.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// Each type library can reference a single Help file. The GetDocumentation method of the created ITypeLib returns
        /// a fully qualified path for the Help file, which is formed by appending the name passed into szHelpFileName to the
        /// registered Help directory for the type library. The Help directory is registered under: \TYPELIB&amp;lt;guid of
        /// library&amp;lt;Major.Minor version \HELPDIR
        /// </remarks>
        [PreserveSig]
        HRESULT SetHelpFileName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szHelpFileName);

        /// <summary>
        /// Sets the Help context ID for retrieving general Help information for the type library.
        /// </summary>
        /// <param name="dwHelpContext">[in] The Help context ID.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// Calling SetHelpContext with a Help context of zero is equivalent to not calling it at all, because zero indicates
        /// a null Help context.
        /// </remarks>
        [PreserveSig]
        HRESULT SetHelpContext(
            [In] int dwHelpContext);

        /// <summary>
        /// Sets the binary Microsoft national language ID associated with the library.
        /// </summary>
        /// <param name="lcid">[in] The locale ID for the type library.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// For more information on national language IDs, see Supporting Multiple National Languages and the National Language
        /// Support (NLS) API.
        /// </remarks>
        [PreserveSig]
        HRESULT SetLcid(
            [In] int lcid);

        /// <summary>
        /// Sets library flags.
        /// </summary>
        /// <param name="uLibFlags">[in] The flags to set.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// Valid uLibFlags values are listed in LIBFLAGS.
        /// </remarks>
        [PreserveSig]
        HRESULT SetLibFlags(
            [In] LIBFLAGS uLibFlags);

        /// <summary>
        /// Saves the <see cref="ICreateTypeLib"/> instance following the layout of type information.
        /// </summary>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// You should not call any other <see cref="ICreateTypeLib"/> methods after calling SaveAllChanges.
        /// </remarks>
        [PreserveSig]
        HRESULT SaveAllChanges();
    }
}
