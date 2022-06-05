using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides information about an object on the managed heap.
    /// </summary>
    /// <remarks>
    /// COR_HEAPOBJECT instances can be retrieved by enumerating an <see cref="ICorDebugHeapEnum"/> interface object that
    /// is populated by calling the <see cref="ICorDebugProcess5.EnumerateHeap"/> method. A COR_HEAPOBJECT instance provides
    /// information either about a live object on the managed heap, or about an object that is not rooted by any object
    /// but has not yet been collected by the garbage collector. For better performance, the COR_HEAPOBJECT.address field
    /// is a CORDB_ADDRESS value rather than the ICorDebugValue interface value used in much of the debugging API. To obtain
    /// an ICorDebugValue object for a given object address, you can pass the CORDB_ADDRESS value to the <see cref="ICorDebugProcess5.GetObject"/>
    /// method. For better performance, the COR_HEAPOBJECT.type field is a COR_TYPEID value rather than the ICorDebugType
    /// interface value used in much of the debugging API. To obtain an ICorDebugType object for a given type ID, you can
    /// pass the COR_TYPEID value to the <see cref="ICorDebugProcess5.GetTypeForTypeID"/> method. The COR_HEAPOBJECT structure
    /// includes a reference-counted COM interface. If you retrieve a COR_HEAPOBJECT instance from the enumerator by calling
    /// the <see cref="ICorDebugHeapEnum.Next"/> method, you must subsequently release the reference.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_HEAPOBJECT
    {
        /// <summary>
        /// The address of the object in memory.
        /// </summary>
        public ulong address;

        /// <summary>
        /// The total size of the object, in bytes.
        /// </summary>
        public ulong size;

        /// <summary>
        /// A <see cref="COR_TYPEID"/> token that represents the type of the object.
        /// </summary>
        public COR_TYPEID type;
    }
}