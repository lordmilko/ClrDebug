namespace ManagedCorDebug
{
    /// <summary>
    /// Contains information that is used to link native code.
    /// </summary>
    public struct COR_NATIVE_LINK
    {
        /// <summary>
        /// The type to be linked in native code. This value is one of the <see cref="CorNativeLinkType"/> values.
        /// </summary>
        public CorNativeLinkType m_linkType;

        /// <summary>
        /// Flags used by the linker when linking native code. This value is one of the <see cref="CorNativeLinkFlags"/> values.
        /// </summary>
        public CorNativeLinkFlags m_flags;

        /// <summary>
        /// The MemberRef metadata token that represents the entry point. The format is lib:entrypoint.
        /// </summary>
        public mdMemberRef m_entryPoint;
    }
}