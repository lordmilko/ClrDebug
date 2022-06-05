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
        /// Notify when mdTypeRef, mdMethodDef, mdMemberRef, or mdFieldDef tokens move.
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
        /// Notify when an mdMethodDef token moves.
        /// </summary>
        MDNotifyMethodDef = 0x00000001,

        /// <summary>
        /// Notify when an mdMemberRef token moves.
        /// </summary>
        MDNotifyMemberRef = 0x00000002,

        /// <summary>
        /// Notify when an mdFieldDef token moves.
        /// </summary>
        MDNotifyFieldDef = 0x00000004,

        /// <summary>
        /// Notify when an mdTypeRef token moves.
        /// </summary>
        MDNotifyTypeRef = 0x00000008,

        /// <summary>
        /// Notify when an mdTypeDef token moves.
        /// </summary>
        MDNotifyTypeDef = 0x00000010,

        /// <summary>
        /// Notify when an mdParamDef token moves.
        /// </summary>
        MDNotifyParamDef = 0x00000020,

        /// <summary>
        /// Notify when an mdInterfaceImpl token moves.
        /// </summary>
        MDNotifyInterfaceImpl = 0x00000040,

        /// <summary>
        /// Notify when an mdProperty token moves.
        /// </summary>
        MDNotifyProperty = 0x00000080,

        /// <summary>
        /// Notify when an mdEvent token moves.
        /// </summary>
        MDNotifyEvent = 0x00000100,

        /// <summary>
        /// Notify when an mdSignature token moves.
        /// </summary>
        MDNotifySignature = 0x00000200,

        /// <summary>
        /// Notify when an mdTypeSpec token moves.
        /// </summary>
        MDNotifyTypeSpec = 0x00000400,

        /// <summary>
        /// Notify when an mdCustomAttribute token moves.
        /// </summary>
        MDNotifyCustomAttribute = 0x00000800,

        /// <summary>
        /// Notify when an mdSecurityValue token moves.
        /// </summary>
        MDNotifySecurityValue = 0x00001000,

        /// <summary>
        /// Notify when an mdPermission token moves.
        /// </summary>
        MDNotifyPermission = 0x00002000,

        /// <summary>
        /// Notify when an mdModuleRef token moves.
        /// </summary>
        MDNotifyModuleRef = 0x00004000,

        /// <summary>
        /// Notify when an mdNameSpace token moves.
        /// </summary>
        MDNotifyNameSpace = 0x00008000,

        /// <summary>
        /// Notify when an mdAssemblyRef token moves.
        /// </summary>
        MDNotifyAssemblyRef = 0x01000000,

        /// <summary>
        /// Notify when an mdFile token moves.
        /// </summary>
        MDNotifyFile = 0x02000000,

        /// <summary>
        /// Notify when an mdExportedType token moves.
        /// </summary>
        MDNotifyExportedType = 0x04000000,

        /// <summary>
        /// Notify when an mdManifestResource token moves.
        /// </summary>
        MDNotifyResource = 0x08000000,
    }
}