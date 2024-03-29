﻿using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Contains information that is used to link native code.
    /// </summary>
    [DebuggerDisplay("m_linkType = {m_linkType.ToString(),nq}, m_flags = {m_flags.ToString(),nq}, m_entryPoint = {m_entryPoint.ToString(),nq}")]
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
