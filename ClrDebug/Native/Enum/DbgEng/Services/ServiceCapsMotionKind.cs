namespace ClrDebug.DbgEng
{
    public enum ServiceCapsMotionKind : uint
    {
        /// <summary>
        /// ServiceCapsMotionSingleStep Indicates that the step controller supports single stepping. The data is a boolean value expressed as a single byte of data.<para/>
        /// The default for this capability is 'true'. Any step controller which does not support single stepping is "go" / "break" only.
        /// </summary>
        ServiceCapsMotionSingleStep = 0,

        /// <summary>
        /// ServiceCapsMotionMultiStep Indicates that the step controller supports stepping multiple steps with a single call to the Step method.<para/>
        /// This should only be supported if the fundamental hardware (or virtual hardware) actually supports this notion in a more efficient manner than multiple single steps.<para/>
        /// The data is a boolean value expressed as a single byte of data. The default for this capability is 'false'.
        /// </summary>
        ServiceCapsMotionMultiStep,

        /// <summary>
        /// ServiceCapsMotionReverse Indicates that the step controller supports reverse motion (step and go as indicated by other capabilities).<para/>
        /// The data is a boolean value expressed as a single byte of data. The default for this capability is 'false'.
        /// </summary>
        ServiceCapsMotionReverse
    }
}
