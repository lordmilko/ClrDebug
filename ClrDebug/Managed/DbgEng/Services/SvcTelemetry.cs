namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_TELEMETRY.
    /// </summary>
    public class SvcTelemetry : ComObject<ISvcTelemetry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcTelemetry"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcTelemetry(ISvcTelemetry raw) : base(raw)
        {
        }

        #region ISvcTelemetry
        #region NotifyUsage

        /// <summary>
        /// Notify usage of a particular feature (with an optional "action" and "parameter").
        /// </summary>
        public void NotifyUsage(string product, string feature, string action)
        {
            TryNotifyUsage(product, feature, action).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Notify usage of a particular feature (with an optional "action" and "parameter").
        /// </summary>
        public HRESULT TryNotifyUsage(string product, string feature, string action)
        {
            /*HRESULT NotifyUsage(
            [In, MarshalAs(UnmanagedType.LPWStr)] string product,
            [In, MarshalAs(UnmanagedType.LPWStr)] string feature,
            [In, MarshalAs(UnmanagedType.LPWStr)] string action);*/
            return Raw.NotifyUsage(product, feature, action);
        }

        #endregion
        #endregion
    }
}
