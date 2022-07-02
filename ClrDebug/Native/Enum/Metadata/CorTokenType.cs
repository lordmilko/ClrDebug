namespace ClrDebug
{
    /// <summary>
    /// Indicates the type of a metadata token.
    /// </summary>
    /// <remarks>
    /// Each value is equal to the value of the top byte in the corresponding metadata token.
    /// </remarks>
    public enum CorTokenType
    {
        /// <summary>
        /// An <see cref="mdModule"/> token.
        /// </summary>
        mdtModule               = 0x00000000,       //

        /// <summary>
        /// An <see cref="mdTypeRef"/> token.
        /// </summary>
        mdtTypeRef              = 0x01000000,       //

        /// <summary>
        /// An <see cref="mdTypeDef"/> token.
        /// </summary>
        mdtTypeDef              = 0x02000000,       //

        /// <summary>
        /// An <see cref="mdFieldDef"/> token.
        /// </summary>
        mdtFieldDef             = 0x04000000,       //

        /// <summary>
        /// An <see cref="mdMethodDef"/> token.
        /// </summary>
        mdtMethodDef            = 0x06000000,       //

        /// <summary>
        /// An <see cref="mdParamDef"/> token.
        /// </summary>
        mdtParamDef             = 0x08000000,       //

        /// <summary>
        /// An <see cref="mdInterfaceImpl"/> token.
        /// </summary>
        mdtInterfaceImpl        = 0x09000000,       //

        /// <summary>
        /// An <see cref="mdMemberRef"/> token.
        /// </summary>
        mdtMemberRef            = 0x0a000000,       //

        /// <summary>
        /// An <see cref="mdCustomAttribute"/> token.
        /// </summary>
        mdtCustomAttribute      = 0x0c000000,       //

        /// <summary>
        /// An <see cref="mdPermission"/> token.
        /// </summary>
        mdtPermission           = 0x0e000000,       //

        /// <summary>
        /// An <see cref="mdSignature"/> token.
        /// </summary>
        mdtSignature            = 0x11000000,       //

        /// <summary>
        /// An <see cref="mdEvent"/> token.
        /// </summary>
        mdtEvent                = 0x14000000,       //

        /// <summary>
        /// An <see cref="mdProperty"/> token.
        /// </summary>
        mdtProperty             = 0x17000000,       //
        mdtMethodImpl           = 0x19000000,       //

        /// <summary>
        /// An <see cref="mdModuleRef"/> token.
        /// </summary>
        mdtModuleRef            = 0x1a000000,       //

        /// <summary>
        /// An <see cref="mdTypeSpec"/> token.
        /// </summary>
        mdtTypeSpec             = 0x1b000000,       //

        /// <summary>
        /// An <see cref="mdAssembly"/> token.
        /// </summary>
        mdtAssembly             = 0x20000000,       //

        /// <summary>
        /// An <see cref="mdAssemblyRef"/> token.
        /// </summary>
        mdtAssemblyRef          = 0x23000000,       //

        /// <summary>
        /// An <see cref="mdFile"/> token.
        /// </summary>
        mdtFile                 = 0x26000000,       //

        /// <summary>
        /// An <see cref="mdExportedType"/> token.
        /// </summary>
        mdtExportedType         = 0x27000000,       //

        /// <summary>
        /// An <see cref="mdManifestResource"/> token.
        /// </summary>
        mdtManifestResource     = 0x28000000,       //

        /// <summary>
        /// An <see cref="mdGenericParam"/> token.
        /// </summary>
        mdtGenericParam         = 0x2a000000,       //

        /// <summary>
        /// An <see cref="mdMethodSpec"/> token.
        /// </summary>
        mdtMethodSpec           = 0x2b000000,       //

        /// <summary>
        /// An <see cref="mdGenericParamConstraint"/> token.
        /// </summary>
        mdtGenericParamConstraint = 0x2c000000,

        /// <summary>
        /// An <see cref="mdString"/> token.
        /// </summary>
        mdtString               = 0x70000000,       //

        /// <summary>
        /// An mdName token.
        /// </summary>
        mdtName                 = 0x71000000,       //

        /// <summary>
        /// Not used.
        /// </summary>
        mdtBaseType             = 0x72000000,       // Leave this on the high end value. This does not correspond to metadata table
    }
}
