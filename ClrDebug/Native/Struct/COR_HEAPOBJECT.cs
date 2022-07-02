using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides information about an object on the managed heap.
    /// </summary>
    /// <remarks>
    /// <see cref="COR_HEAPOBJECT"/> instances can be retrieved by enumerating an <see cref="ICorDebugHeapEnum"/> interface object that
    /// is populated by calling the <see cref="ICorDebugProcess5.EnumerateHeap"/> method. A <see cref="COR_HEAPOBJECT"/> instance provides
    /// information either about a live object on the managed heap, or about an object that is not rooted by any object
    /// but has not yet been collected by the garbage collector. For better performance, the <see cref="address"/> field
    /// is a <see cref="CORDB_ADDRESS"/> value rather than the <see cref="ICorDebugValue"/> interface value used in much of the debugging API. To obtain
    /// an <see cref="ICorDebugValue"/> object for a given object address, you can pass the <see cref="CORDB_ADDRESS"/> value to the <see cref="ICorDebugProcess5.GetObject"/>
    /// method. For better performance, the <see cref="type"/> field is a <see cref="COR_TYPEID"/> value rather than the <see cref="ICorDebugType"/>
    /// interface value used in much of the debugging API. To obtain an <see cref="ICorDebugType"/> object for a given type ID, you can
    /// pass the <see cref="COR_TYPEID"/> value to the <see cref="ICorDebugProcess5.GetTypeForTypeID"/> method. The <see cref="COR_HEAPOBJECT"/> structure
    /// includes a reference-counted COM interface. If you retrieve a <see cref="COR_HEAPOBJECT"/> instance from the enumerator by calling
    /// the <see cref="ICorDebugHeapEnum.Next"/> method, you must subsequently release the reference.
    /// </remarks>
    [DebuggerDisplay("address = {address.ToString(),nq}, size = {size}, type = {type.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_HEAPOBJECT
    {
        /// <summary>
        /// The address of the object in memory.
        /// </summary>
        public CORDB_ADDRESS address;

        /// <summary>
        /// The total size of the object, in bytes.
        /// </summary>
        public long size;

        /// <summary>
        /// A <see cref="COR_TYPEID"/> token that represents the type of the object.
        /// </summary>
        public COR_TYPEID type;
    }
}
