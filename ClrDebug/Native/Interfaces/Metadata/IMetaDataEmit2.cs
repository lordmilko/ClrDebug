using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="IMetaDataEmit"/> interface primarily to provide the ability to work with generic types.
    /// </summary>
    [Guid("F5DD9950-F693-42e6-830E-7B833E8146A9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IMetaDataEmit2
    {
        /// <summary>
        /// Creates a generic instance of a method, and gets a token to the definition.
        /// </summary>
        /// <param name="tkParent">[in] A token for the method of which to create the generic instance. The token must be of type <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/>.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary COM+ signature of the method.</param>
        /// <param name="cbSigBlob">[in] The size, in bytes, of pvSigBlob.</param>
        /// <param name="pmi">[out] A token to the metadata signature definition of the method.</param>
        [PreserveSig]
        HRESULT DefineMethodSpec(
            [In] mdToken tkParent,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [Out] out mdMethodSpec pmi);

        /// <summary>
        /// Gets a value indicating any change in metadata size that results from the current edit-and-continue session.
        /// </summary>
        /// <param name="fSave">[in] One of the <see cref="CorSaveSize"/> values, indicating the level of precision desired. For the .NET Framework version 2.0, this parameter is ignored.</param>
        /// <param name="pdwSaveSize">[out] The change in the size of the metadata.</param>
        [PreserveSig]
        HRESULT GetDeltaSaveSize(
            [In] CorSaveSize fSave,
            [Out] out int pdwSaveSize);

        /// <summary>
        /// Saves changes from the current edit-and-continue session to the specified file.
        /// </summary>
        /// <param name="szFile">[in] The file name under which to save changes.</param>
        /// <param name="dwSaveFlags">[in] Reserved. Must be zero.</param>
        [PreserveSig]
        HRESULT SaveDelta(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szFile,
            [In] int dwSaveFlags);

        /// <summary>
        /// Saves changes from the current edit-and-continue session to the specified stream.
        /// </summary>
        /// <param name="pIStream">[in] An interface pointer to the writable stream to which to save changes.</param>
        /// <param name="dwSaveFlags">[in] Reserved. This value must be zero.</param>
        [PreserveSig]
        HRESULT SaveDeltaToStream(
            [In, MarshalAs(UnmanagedType.Interface)] IStream pIStream,
            [In] int dwSaveFlags);

        /// <summary>
        /// Saves changes from the current edit-and-continue session to memory.
        /// </summary>
        /// <param name="pbData">[out] The address at which to begin writing the metadata delta.</param>
        /// <param name="cbData">[in] The size of the changes. Use <see cref="GetDeltaSaveSize"/> to determine the size.</param>
        [PreserveSig]
        HRESULT SaveDeltaToMemory(
            [In] IntPtr pbData,
            [In] int cbData);

        /// <summary>
        /// Creates a definition for a generic type parameter, and gets a token to that generic type parameter.
        /// </summary>
        /// <param name="tk">[in] An <see cref="mdTypeDef"/> or <see cref="mdMethodDef"/> token that represents the method or constructor for which to define a generic parameter.</param>
        /// <param name="ulParamSeq">[in] The index of the generic parameter.</param>
        /// <param name="dwParamFlags">[in] A value of the <see cref="CorGenericParamAttr"/> enumeration that describes the type for the generic parameter.</param>
        /// <param name="szName">[in] The name of the parameter.</param>
        /// <param name="reserved">[in] This parameter is reserved for future extensibility.</param>
        /// <param name="rtkConstraints">[in] A zero-terminated array of type constraints. Array members must be an <see cref="mdTypeDef"/>, <see cref="mdTypeRef"/>, or <see cref="mdTypeSpec"/> metadata token.</param>
        /// <param name="pgp">[out] A token that represents the generic parameter.</param>
        [PreserveSig]
        HRESULT DefineGenericParam(
            [In] mdToken tk,
            [In] int ulParamSeq,
            [In] CorGenericParamAttr dwParamFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] int reserved,
            [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkConstraints,
            [Out] out mdGenericParam pgp);

        /// <summary>
        /// Sets property values for the generic parameter definition referenced by the specified token.
        /// </summary>
        /// <param name="gp">[in] The token for the generic parameter definition for which to set values.</param>
        /// <param name="dwParamFlags">[in] A value of the <see cref="CorGenericParamAttr"/> enumeration that describes the type for the generic parameter.</param>
        /// <param name="szName">[in] Optional. The name of the parameter for which to set values.</param>
        /// <param name="reserved">[in] Reserved for future extensibility.</param>
        /// <param name="rtkConstraints">[in] Optional. A zero-terminated array of type constraints. Array members must be an <see cref="mdTypeDef"/>, <see cref="mdTypeRef"/>, or <see cref="mdTypeSpec"/> metadata token.</param>
        [PreserveSig]
        HRESULT SetGenericParamProps(
            [In] mdGenericParam gp,
            [In] CorGenericParamAttr dwParamFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] int reserved,
            [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkConstraints);

        /// <summary>
        /// Resets the edit-and-continue log and starts a new session.
        /// </summary>
        [PreserveSig]
        HRESULT ResetENCLog();
    }
}
