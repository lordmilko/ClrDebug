namespace ManagedCorDebug
{
    /// <summary>
    /// Specifies the notifications that will be sent to the metadata API client when a token remap occurs.
    /// </summary>
    /// <remarks>
    /// A token may be re-mapped (that is, moved) during a metadata merge.
    /// </remarks>
    public enum CorNotificationForTokenMovement : uint
    {
        /// <summary>
        /// Notify when <see cref="mdTypeRef"/>, <see cref="mdMethodDef"/>, <see cref="mdMemberRef"/>, or <see cref="mdFieldDef"/> tokens move.
        /// </summary>
        MDNotifyDefault = 0x0000000f,

        /// <summary>
        /// Notify when any token moves.
        /// </summary>
        MDNotifyAll = 0xffffffff,

        /// <summary>
        /// Do not notify when tokens move.
        /// </summary>
        MDNotifyNone = 0x00000000,

        /// <summary>
        /// Notify when an <see cref="mdMethodDef"/> token moves.
        /// </summary>
        MDNotifyMethodDef = 0x00000001,

        /// <summary>
        /// Notify when an <see cref="mdMemberRef"/> token moves.
        /// </summary>
        MDNotifyMemberRef = 0x00000002,

        /// <summary>
        /// Notify when an <see cref="mdFieldDef"/> token moves.
        /// </summary>
        MDNotifyFieldDef = 0x00000004,

        /// <summary>
        /// Notify when an <see cref="mdTypeRef"/> token moves.
        /// </summary>
        MDNotifyTypeRef = 0x00000008,

        /// <summary>
        /// Notify when an <see cref="mdTypeDef"/> token moves.
        /// </summary>
        MDNotifyTypeDef = 0x00000010,

        /// <summary>
        /// Notify when an <see cref="mdParamDef"/> token moves.
        /// </summary>
        MDNotifyParamDef = 0x00000020,

        /// <summary>
        /// Notify when an <see cref="mdInterfaceImpl"/> token moves.
        /// </summary>
        MDNotifyInterfaceImpl = 0x00000040,

        /// <summary>
        /// Notify when an <see cref="mdProperty"/> token moves.
        /// </summary>
        MDNotifyProperty = 0x00000080,

        /// <summary>
        /// Notify when an <see cref="mdEvent"/> token moves.
        /// </summary>
        MDNotifyEvent = 0x00000100,

        /// <summary>
        /// Notify when an <see cref="mdSignature"/> token moves.
        /// </summary>
        MDNotifySignature = 0x00000200,

        /// <summary>
        /// Notify when an <see cref="mdTypeSpec"/> token moves.
        /// </summary>
        MDNotifyTypeSpec = 0x00000400,

        /// <summary>
        /// Notify when an <see cref="mdCustomAttribute"/> token moves.
        /// </summary>
        MDNotifyCustomAttribute = 0x00000800,

        /// <summary>
        /// Notify when an mdSecurityValue token moves.
        /// </summary>
        MDNotifySecurityValue = 0x00001000,

        /// <summary>
        /// Notify when an <see cref="mdPermission"/> token moves.
        /// </summary>
        MDNotifyPermission = 0x00002000,

        /// <summary>
        /// Notify when an <see cref="mdModuleRef"/> token moves.
        /// </summary>
        MDNotifyModuleRef = 0x00004000,

        /// <summary>
        /// Notify when an mdNameSpace token moves.
        /// </summary>
        MDNotifyNameSpace = 0x00008000,

        /// <summary>
        /// Notify when an <see cref="mdAssemblyRef"/> token moves.
        /// </summary>
        MDNotifyAssemblyRef = 0x01000000,

        /// <summary>
        /// Notify when an <see cref="mdFile"/> token moves.
        /// </summary>
        MDNotifyFile = 0x02000000,

        /// <summary>
        /// Notify when an <see cref="mdExportedType"/> token moves.
        /// </summary>
        MDNotifyExportedType = 0x04000000,

        /// <summary>
        /// Notify when an <see cref="mdManifestResource"/> token moves.
        /// </summary>
        MDNotifyResource = 0x08000000,
    }
}