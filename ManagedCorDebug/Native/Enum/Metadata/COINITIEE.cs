using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Specifies constants used by CoInitializeEE when initializing the common language runtime.
    /// </summary>
    public enum COINITIEE
    {
        /// <summary>
        /// Default initialization mode. This initializes the runtime and creates the default <see cref="AppDomain"/>.
        /// </summary>
        COINITEE_DEFAULT = 0x0,          // Default initialization mode. 

        /// <summary>
        /// Initializes to run a managed DLL.
        /// </summary>
        COINITEE_DLL = 0x1,          // Initialization mode for loading DLL. 

        /// <summary>
        /// Initializes to run a managed EXE. This initializes the runtime but does not create the default <see cref="AppDomain"/>, which is created after entering the main routine of the EXE.
        /// </summary>
        COINITEE_MAIN = 0x2           // Initialize prior to entering the main routine 
    }
}