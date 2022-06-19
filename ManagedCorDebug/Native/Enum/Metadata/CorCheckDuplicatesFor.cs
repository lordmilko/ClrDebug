using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Specifies the metadata tokens that will be checked for duplicates.
    /// </summary>
    [Flags]
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
        /// Check for duplicates of <see cref="mdTypeDef"/> tokens.
        /// </summary>
        MDDupTypeDef = 0x00000001,

        /// <summary>
        /// Check for duplicates of <see cref="mdInterfaceImpl"/> tokens.
        /// </summary>
        MDDupInterfaceImpl = 0x00000002,

        /// <summary>
        /// Check for duplicates of <see cref="mdMethodDef"/> tokens.
        /// </summary>
        MDDupMethodDef = 0x00000004,

        /// <summary>
        /// Check for duplicates of <see cref="mdTypeRef"/> tokens.
        /// </summary>
        MDDupTypeRef = 0x00000008,

        /// <summary>
        /// Check for duplicates of <see cref="mdMemberRef"/> tokens.
        /// </summary>
        MDDupMemberRef = 0x00000010,

        /// <summary>
        /// Check for duplicates of <see cref="mdCustomAttribute"/> tokens.
        /// </summary>
        MDDupCustomAttribute = 0x00000020,

        /// <summary>
        /// Check for duplicates of <see cref="mdParamDef"/> tokens.
        /// </summary>
        MDDupParamDef = 0x00000040,

        /// <summary>
        /// Check for duplicates of <see cref="mdPermission"/> tokens.
        /// </summary>
        MDDupPermission = 0x00000080,

        /// <summary>
        /// Check for duplicates of <see cref="mdProperty"/> tokens.
        /// </summary>
        MDDupProperty = 0x00000100,

        /// <summary>
        /// Check for duplicates of <see cref="mdEvent"/> tokens.
        /// </summary>
        MDDupEvent = 0x00000200,

        /// <summary>
        /// Check for duplicates of <see cref="mdFieldDef"/> tokens.
        /// </summary>
        MDDupFieldDef = 0x00000400,

        /// <summary>
        /// Check for duplicates of <see cref="mdSignature"/> tokens.
        /// </summary>
        MDDupSignature = 0x00000800,

        /// <summary>
        /// Check for duplicates of <see cref="mdModuleRef"/> tokens.
        /// </summary>
        MDDupModuleRef = 0x00001000,

        /// <summary>
        /// Check for duplicates of <see cref="mdTypeSpec"/> tokens.
        /// </summary>
        MDDupTypeSpec = 0x00002000,

        /// <summary>
        /// Check for duplicates of mdImplMap tokens.
        /// </summary>
        MDDupImplMap = 0x00004000,

        /// <summary>
        /// Check for duplicates of <see cref="mdAssemblyRef"/> tokens.
        /// </summary>
        MDDupAssemblyRef = 0x00008000,

        /// <summary>
        /// Check for duplicates of <see cref="mdFile"/> tokens.
        /// </summary>
        MDDupFile = 0x00010000,

        /// <summary>
        /// Check for duplicates of <see cref="mdExportedType"/> tokens.
        /// </summary>
        MDDupExportedType = 0x00020000,

        /// <summary>
        /// Check for duplicates of <see cref="mdManifestResource"/> tokens.
        /// </summary>
        MDDupManifestResource = 0x00040000,

        /// <summary>
        /// Check for duplicates of <see cref="mdGenericParam"/> tokens.
        /// </summary>
        MDDupGenericParam = 0x00080000,

        /// <summary>
        /// Check for duplicates of <see cref="mdMethodSpec"/> tokens.
        /// </summary>
        MDDupMethodSpec = 0x00100000,

        /// <summary>
        /// Check for duplicates of <see cref="mdGenericParamConstraint"/> tokens.
        /// </summary>
        MDDupGenericParamConstraint = 0x00200000,

        /// <summary>
        /// Check for duplicates of <see cref="mdAssembly"/> tokens.
        /// </summary>
        MDDupAssembly = 0x10000000,

        /// <summary>
        /// Check for duplicates of <see cref="mdMemberRef"/>, <see cref="mdTypeRef"/>, <see cref="mdSignature"/>, <see cref="mdTypeSpec"/>, and <see cref="mdMethodSpec"/> tokens.
        /// </summary>
        MDDupDefault = MDNoDupChecks | MDDupTypeRef | MDDupMemberRef | MDDupSignature | MDDupTypeSpec | MDDupMethodSpec,
    }
}