namespace ManagedCorDebug
{
    /// <summary>
    /// Contains flag values for the treatment of local references.
    /// </summary>
    public enum CorLocalRefPreservation
    {
        /// <summary>
        /// Preserve no local references.
        /// </summary>
        MDPreserveLocalRefsNone = 0x00000000,

        /// <summary>
        /// Preserve local type references.
        /// </summary>
        MDPreserveLocalTypeRef = 0x00000001,

        /// <summary>
        /// Preserve local member references.
        /// </summary>
        MDPreserveLocalMemberRef = 0x00000002
    }
}