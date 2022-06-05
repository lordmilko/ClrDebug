namespace ManagedCorDebug
{
    /// <summary>
    /// Specifies the metadata tokens that will be checked for duplicates.
    /// </summary>
    public enum CorCheckDuplicatesFor : uint
    {
        /// <summary>
        /// Check all metadata tokens for duplicates.
        /// </summary>
        MDDupAll = 0xffffffff,

        /// <summary>
        /// Not used.
        /// </summary>
        MDDupENC = MDDupAll,

        /// <summary>
        /// Do not check metadata tokens for duplicates.
        /// </summary>
        MDNoDupChecks = 0x00000000,

        /// <summary>
        /// Check for duplicates of mdTypeDef tokens.
        /// </summary>
        MDDupTypeDef = 0x00000001,

        /// <summary>
        /// Check for duplicates of mdInterfaceImpl tokens.
        /// </summary>
        MDDupInterfaceImpl = 0x00000002,

        /// <summary>
        /// Check for duplicates of mdMethodDef tokens.
        /// </summary>
        MDDupMethodDef = 0x00000004,

        /// <summary>
        /// Check for duplicates of mdTypeRef tokens.
        /// </summary>
        MDDupTypeRef = 0x00000008,

        /// <summary>
        /// Check for duplicates of mdMemberRef tokens.
        /// </summary>
        MDDupMemberRef = 0x00000010,

        /// <summary>
        /// Check for duplicates of mdCustomAttribute tokens.
        /// </summary>
        MDDupCustomAttribute = 0x00000020,

        /// <summary>
        /// Check for duplicates of mdParamDef tokens.
        /// </summary>
        MDDupParamDef = 0x00000040,

        /// <summary>
        /// Check for duplicates of mdPermission tokens.
        /// </summary>
        MDDupPermission = 0x00000080,

        /// <summary>
        /// Check for duplicates of mdProperty tokens.
        /// </summary>
        MDDupProperty = 0x00000100,

        /// <summary>
        /// Check for duplicates of mdEvent tokens.
        /// </summary>
        MDDupEvent = 0x00000200,

        /// <summary>
        /// Check for duplicates of mdFieldDef tokens.
        /// </summary>
        MDDupFieldDef = 0x00000400,

        /// <summary>
        /// Check for duplicates of mdSignature tokens.
        /// </summary>
        MDDupSignature = 0x00000800,

        /// <summary>
        /// Check for duplicates of mdModuleRef tokens.
        /// </summary>
        MDDupModuleRef = 0x00001000,

        /// <summary>
        /// Check for duplicates of mdTypeSpec tokens.
        /// </summary>
        MDDupTypeSpec = 0x00002000,

        /// <summary>
        /// Check for duplicates of mdImplMap tokens.
        /// </summary>
        MDDupImplMap = 0x00004000,

        /// <summary>
        /// Check for duplicates of mdAssemblyRef tokens.
        /// </summary>
        MDDupAssemblyRef = 0x00008000,

        /// <summary>
        /// Check for duplicates of mdFile tokens.
        /// </summary>
        MDDupFile = 0x00010000,

        /// <summary>
        /// Check for duplicates of mdExportedType tokens.
        /// </summary>
        MDDupExportedType = 0x00020000,

        /// <summary>
        /// Check for duplicates of mdManifestResource tokens.
        /// </summary>
        MDDupManifestResource = 0x00040000,

        /// <summary>
        /// Check for duplicates of mdGenericParam tokens.
        /// </summary>
        MDDupGenericParam = 0x00080000,

        /// <summary>
        /// Check for duplicates of mdMethodSpec tokens.
        /// </summary>
        MDDupMethodSpec = 0x00100000,

        /// <summary>
        /// Check for duplicates of mdGenericParamConstraint tokens.
        /// </summary>
        MDDupGenericParamConstraint = 0x00200000,

        /// <summary>
        /// Check for duplicates of mdAssembly tokens.
        /// </summary>
        MDDupAssembly = 0x10000000,

        /// <summary>
        /// Check for duplicates of mdMemberRef, mdTypeRef, mdSignature, mdTypeSpec, and mdMethodSpec tokens.
        /// </summary>
        MDDupDefault = MDNoDupChecks | MDDupTypeRef | MDDupMemberRef | MDDupSignature | MDDupTypeSpec | MDDupMethodSpec,
    }
}