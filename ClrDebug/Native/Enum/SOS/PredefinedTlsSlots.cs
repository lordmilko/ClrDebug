namespace ClrDebug
{
    /// <summary>
    /// The historic location of ThreadType slot kept for compatibility with SOS
    /// </summary>
    public enum PredefinedTlsSlots
    {
        TlsIdx_ThreadType = 11 // bit flags to indicate special thread's type
    };
}
