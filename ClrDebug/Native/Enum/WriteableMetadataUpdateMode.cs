namespace ClrDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Provides values that specify whether in-memory updates to metadata are visible to a debugger.
    /// </summary>
    /// <remarks>
    /// A member of the <see cref="WriteableMetadataUpdateMode"/> enumeration can be passed to the <see cref="ICorDebugProcess7.SetWriteableMetadataUpdateMode"/>
    /// method to control whether in-memory updates to metadata in the target process are visible to the debugger. The
    /// LegacyCompatPolicy option enforces the same behavior as in versions of the .NET Framework before 4.5.2. This often
    /// means that metadata from updates is not visible. However, calls to a number of debugging methods implicitly coerce
    /// the debugger to make updates visible. For example, if the debugger passes <see cref="ICorDebugILFrame.GetLocalVariable"/>
    /// the index of a variable not found in the method's original metadata, all metadata for the module is updated to
    /// a snapshot matching the current state of the process. In other words, with the LegacyCompatPolicy option, the debugger
    /// might see none, some, or all of the available metadata updates, depending on how it uses other parts of the unmanaged
    /// debugging API.
    /// </remarks>
    public enum WriteableMetadataUpdateMode
    {
        /// <summary>
        /// Maintain compatibility with previous versions of the .NET Framework when making in-memory updates to metadata visible.<para/>
        /// See the Remarks section for more information.
        /// </summary>
        LegacyCompatPolicy,

        /// <summary>
        /// Make in-memory updates to metadata visible to the debugger.
        /// </summary>
        AlwaysShowUpdates
    }
}