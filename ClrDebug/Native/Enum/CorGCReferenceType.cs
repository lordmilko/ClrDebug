using System;

namespace ClrDebug
{
    /// <summary>
    /// Identifies the source of an object to be garbage-collected.
    /// </summary>
    /// <remarks>
    /// The <see cref="CorGCReferenceType"/> enumeration is used as follows:
    /// </remarks>
    [Flags]
    public enum CorGCReferenceType
    {
        /// <summary>
        /// A reference from the managed stack.
        /// </summary>
        CorReferenceStack = -2147483647,

        /// <summary>
        /// A handle to a strong reference from the object handle table.
        /// </summary>
        CorHandleStrong = 1,

        /// <summary>
        /// A handle to a pinned strong reference from the object handle table.
        /// </summary>
        CorHandleStrongPinning = 2,

        /// <summary>
        /// A handle to a weak reference from the object handle table.
        /// </summary>
        CorHandleWeakShort = 4,
        CorHandleWeakLong = 8,

        /// <summary>
        /// A handle to a weak reference-counted object from the object handle table.
        /// </summary>
        CorHandleWeakRefCount = 16,

        /// <summary>
        /// A handle to a reference-counted object from the object handle table.
        /// </summary>
        CorHandleStrongRefCount = 32,

        /// <summary>
        /// A handle to a dependent object from the object handle table.
        /// </summary>
        CorHandleStrongDependent = 64,

        /// <summary>
        /// An asynchronous pinned object from the object handle table.
        /// </summary>
        CorHandleStrongAsyncPinned = 128,

        /// <summary>
        /// A strong handle that keeps an approximate size of the collective closure of all objects and object roots at garbage collection time.
        /// </summary>
        CorHandleStrongSizedByref = 256,

        /// <summary>
        /// Return only strong references from the handle table. This value is used by the <see cref="ICorDebugProcess5.EnumerateHandles"/> method only.
        /// </summary>
        CorHandleStrongOnly = 483,
        CorHandleWeakWinRT = 512,

        /// <summary>
        /// Return only weak references from the handle table. This value is used by the <see cref="ICorDebugProcess5.EnumerateHandles"/> method only.
        /// </summary>
        CorHandleWeakOnly = 540,

        /// <summary>
        /// A reference from the finalizer queue.
        /// </summary>
        CorReferenceFinalizer = 80000002,

        /// <summary>
        /// Return all references from the handle table. This value is used by the <see cref="ICorDebugProcess5.EnumerateHandles"/> method only.
        /// </summary>
        CorHandleAll = 2147483647
    }
}