namespace ClrDebug.TTD
{
    //From LiveRecorder

    /// <summary>
    /// Selectable flags for generating custom events.
    /// </summary>
    public enum CustomEventFlags : uint
    {
        /// <summary>
        /// Keyframe events force the generation of a keyframe at the current position.<para/>
        /// This allows the custom event's position to be more acurately ordered with other
        /// common events, like observations of memory values.<para/>
        /// Note that generating keyframes may cost significant performance when recording, so use with care.
        /// </summary>
        Keyframe = 0x00000001,

        None = 0,
        All  = 0xFFFFFFFF,
    }
}
