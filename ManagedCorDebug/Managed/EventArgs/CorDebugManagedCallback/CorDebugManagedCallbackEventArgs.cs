using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents an event that occurred from one of the methods in the <see cref="ICorDebugManagedCallback"/> interface or its derivatives.
    /// </summary>
    public abstract class CorDebugManagedCallbackEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public abstract CorDebugManagedCallbackKind Kind { get; }
    }
}