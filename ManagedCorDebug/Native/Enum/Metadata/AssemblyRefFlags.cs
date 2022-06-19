using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that describe features of an assembly reference.
    /// </summary>
    [Flags]
    public enum AssemblyRefFlags
    {
        /// <summary>
        /// Specifies that the assembly reference contains full, unhashed information about the publisher of the assembly.
        /// </summary>
        arfFullOriginator = 0x0001
    }
}