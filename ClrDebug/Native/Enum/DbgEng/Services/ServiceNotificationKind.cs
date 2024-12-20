namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Indicates the kind of notification which is occurring.
    /// </summary>
    public enum ServiceNotificationKind : uint
    {
        /// <summary>
        /// Indicates that this notification is a direct notification from the service manager to the top of the service stack for a given service.
        /// </summary>
        ServiceManagerNotification,

        /// <summary>
        /// Indicates that this notification is being passed down the service stack from a higher level component in the stack for a given service.
        /// </summary>
        LayeredNotification
    }
}
