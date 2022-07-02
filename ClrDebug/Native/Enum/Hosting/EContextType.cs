namespace ClrDebug
{
    /// <summary>
    /// Describes the security context of the currently executing thread.
    /// </summary>
    /// <remarks>
    /// The CLR supplies one of the <see cref="EContextType"/> values as a parameter value in calls to the IHostSecurityManager::GetSecurityContext
    /// and <see cref="IHostSecurityManager.SetSecurityContext"/> methods.
    /// </remarks>
    public enum EContextType
    {
        /// <summary>
        /// Indicates the context on the current thread at the time the common language runtime (CLR) calls the <see cref="IHostSecurityManager.GetSecurityContext"/> method, or the context requested by the CLR in a call to the <see cref="IHostSecurityManager.SetSecurityContext"/> method.
        /// </summary>
        eCurrentContext = 0,

        /// <summary>
        /// Indicates a context over which the host has lower privileges, such as the garbage collector, or class or module constructors.
        /// </summary>
        eRestrictedContext = 0x1
    }
}