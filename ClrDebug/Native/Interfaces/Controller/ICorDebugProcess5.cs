using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugProcess"/> interface to support access to the managed heap, to provide information about garbage collection of managed objects, and to determine whether a debugger loads images from the application local native image cache.
    /// </summary>
    /// <remarks>
    /// This interface logically extends the <see cref="ICorDebugProcess"/>, <see cref="ICorDebugProcess2"/>, and <see cref="ICorDebugProcess3"/> interfaces.
    /// </remarks>
    [Guid("21E9D9C0-FCB8-11DF-8CFF-0800200C9A66")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugProcess5
    {
        /// <summary>
        /// Provides general information about the garbage collection heap, including whether it is currently enumerable.
        /// </summary>
        /// <param name="pHeapInfo">[out] A pointer to a <see cref="COR_HEAPINFO"/> value that provides general information about the garbage collection heap.</param>
        /// <remarks>
        /// The <see cref="GetGCHeapInformation"/> method must be called before enumerating the heap or individual heap
        /// regions to ensure that the garbage collection structures in the process are currently valid. The garbage collection
        /// heap cannot be walked while a collection is in progress. Otherwise, the enumeration may capture garbage collection
        /// structures that are invalid.
        /// </remarks>
        [PreserveSig]
        HRESULT GetGCHeapInformation(
            [Out] out COR_HEAPINFO pHeapInfo);

        /// <summary>
        /// Gets an enumerator for the objects on the managed heap.
        /// </summary>
        /// <param name="ppObjects">[out] A pointer to the address of an <see cref="ICorDebugHeapEnum"/> interface object that is an enumerator for the objects that reside on the managed heap.</param>
        /// <remarks>
        /// Before calling the <see cref="EnumerateHeap"/> method, you should call the <see cref="GetGCHeapInformation"/>
        /// method and examine the value of the areGCStructuresValid field of the returned <see cref="COR_HEAPINFO"/> object
        /// to ensure that the garbage collection heap in its current state is enumerable. In addition, the ICorDebugProcess5::EnumerateHeap
        /// returns E_FAIL if you attach too early in the lifetime of the process, before memory for the managed heap is allocated.
        /// The <see cref="ICorDebugHeapEnum"/> interface object is a standard enumerator derived from the <see cref="ICorDebugEnum"/> interface
        /// that allows you to enumerate <see cref="COR_HEAPOBJECT"/> objects. This method populates the <see cref="ICorDebugHeapEnum"/>
        /// collection object with <see cref="COR_HEAPOBJECT"/> instances that provide information about all objects. The collection
        /// may also include <see cref="COR_HEAPOBJECT"/> instances that provide information about objects that are not rooted
        /// by any object but have not yet been collected by the garbage collector.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumerateHeap(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugHeapEnum ppObjects);

        /// <summary>
        /// Gets an enumerator for the memory ranges of the managed heap.
        /// </summary>
        /// <param name="ppRegions">[out] A pointer to the address of an <see cref="ICorDebugHeapSegmentEnum"/> interface object that is an enumerator for the ranges of memory in which objects reside in the managed heap.</param>
        /// <remarks>
        /// Before calling the <see cref="EnumerateHeapRegions"/> method, you should call the <see cref="GetGCHeapInformation"/>
        /// method and examine the value of the areGCStructuresValid field of the returned <see cref="COR_HEAPINFO"/> object
        /// to ensure that the garbage collection heap in its current state is enumerable. In addition, the ICorDebugProcess5::EnumerateHeapRegions
        /// method returns E_FAIL if you attach too early in the lifetime of the process, before memory regions are created.
        /// This method is guaranteed to enumerate all memory regions that may contain managed objects, but it does not guarantee
        /// that managed objects actually reside in those regions. The <see cref="ICorDebugHeapSegmentEnum"/> collection object
        /// may include empty or reserved memory regions. The <see cref="ICorDebugHeapSegmentEnum"/> interface object is a
        /// standard enumerator derived from the <see cref="ICorDebugEnum"/> interface that allows you to enumerate <see cref="COR_SEGMENT"/>
        /// objects. Each <see cref="COR_SEGMENT"/> object provides information about the memory range of a particular segment,
        /// along with the generation of the objects in that segment.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumerateHeapRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugHeapSegmentEnum ppRegions);

        /// <summary>
        /// Converts an object address to an "ICorDebugObjectValue" object.
        /// </summary>
        /// <param name="addr">[in] The object address.</param>
        /// <param name="pObject">[out] A pointer to the address of an "ICorDebugObjectValue" object.</param>
        /// <remarks>
        /// If addr does not point to a valid managed object, the GetObject method returns E_FAIL.
        /// </remarks>
        [PreserveSig]
        HRESULT GetObject(
            [In] CORDB_ADDRESS addr,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectValue pObject);

        /// <summary>
        /// Gets an enumerator for all objects that are to be garbage-collected in a process.
        /// </summary>
        /// <param name="enumerateWeakReferences">[in] A Boolean value that indicates whether weak references are also to be enumerated. If enumerateWeakReferences is true, the ppEnum enumerator includes both strong references and weak references.<para/>
        /// If enumerateWeakReferences is false, the enumerator includes only strong references.</param>
        /// <param name="ppEnum">[out] A pointer to the address of an <see cref="ICorDebugGCReferenceEnum"/> that is an enumerator for the objects to be garbage-collected.</param>
        /// <remarks>
        /// This method provides a way to determine the full rooting chain for any managed object in a process and can be used
        /// to determine why an object is still alive.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumerateGCReferences(
            [In] int enumerateWeakReferences,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugGCReferenceEnum ppEnum);

        /// <summary>
        /// Gets an enumerator for object handles in a process.
        /// </summary>
        /// <param name="types">[in] A bitwise combination of <see cref="CorGCReferenceType"/> values that specifies the type of handles to include in the collection.</param>
        /// <param name="ppEnum">[out] A pointer to the address of an <see cref="ICorDebugGCReferenceEnum"/> that is an enumerator for the objects to be garbage-collected.</param>
        /// <remarks>
        /// EnumerateHandles is a helper function that supports inspection of the handle table. It is similar to the <see cref="EnumerateGCReferences"/>
        /// method, except that rather than populating an <see cref="ICorDebugGCReferenceEnum"/> collection with all objects
        /// to be garbage-collected, it includes only objects that have handles from the handle table. The types parameter
        /// specifies the handle types to include in the collection. types can be any of the following three members of the
        /// <see cref="CorGCReferenceType"/> enumeration:
        /// </remarks>
        [PreserveSig]
        HRESULT EnumerateHandles(
            [In] CorGCReferenceType types,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugGCReferenceEnum ppEnum);

        /// <summary>
        /// Converts an object address to a <see cref="COR_TYPEID"/> identifier.
        /// </summary>
        /// <param name="obj">[in] The object address.</param>
        /// <param name="pId">A pointer to the <see cref="COR_TYPEID"/> value that identifies the object.</param>
        [PreserveSig]
        HRESULT GetTypeID(
            [In] CORDB_ADDRESS obj,
            [Out] out COR_TYPEID pId);

        /// <summary>
        /// Converts a type identifier to an <see cref="ICorDebugType"/> value.
        /// </summary>
        /// <param name="id">[in] The type identifier.</param>
        /// <param name="ppType">[out] A pointer to the address of an <see cref="ICorDebugType"/> object.</param>
        /// <remarks>
        /// In some cases, methods that return a type identifier may return a null <see cref="COR_TYPEID"/> value. If this value is passed
        /// as the id argument, the GetTypeForTypeID method will fail and return E_FAIL.
        /// </remarks>
        [PreserveSig]
        HRESULT GetTypeForTypeID(
            [In] COR_TYPEID id,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);

        /// <summary>
        /// Provides information about the layout of array types.
        /// </summary>
        /// <param name="id">[in] A <see cref="COR_TYPEID"/> token that specifies the array whose layout is desired.</param>
        /// <param name="pLayout">[out] A pointer to a <see cref="COR_ARRAY_LAYOUT"/> structure that contains information about the layout of the array in memory.</param>
        [PreserveSig]
        HRESULT GetArrayLayout(
            [In] COR_TYPEID id,
            [Out] out COR_ARRAY_LAYOUT pLayout);

        /// <summary>
        /// Gets information about the layout of an object in memory based on its type identifier.
        /// </summary>
        /// <param name="id">[in] A <see cref="COR_TYPEID"/> token that specifies the type whose layout is desired.</param>
        /// <param name="pLayout">[out] A pointer to a <see cref="COR_TYPE_LAYOUT"/> structure that contains information about the layout of the object in memory.</param>
        /// <remarks>
        /// The <see cref="GetTypeLayout"/> method provides information about an object based on its <see cref="COR_TYPEID"/>,
        /// which is returned by a number of other <see cref="ICorDebugProcess5"/> methods. The information is provided by
        /// a <see cref="COR_TYPE_LAYOUT"/> structure that is populated by the method.
        /// </remarks>
        [PreserveSig]
        HRESULT GetTypeLayout(
            [In] COR_TYPEID id,
            [Out] out COR_TYPE_LAYOUT pLayout);

        /// <summary>
        /// Provides information about the fields that belong to a type.
        /// </summary>
        /// <param name="id">[in] The identifier of the type whose field information is retrieved.</param>
        /// <param name="celt">[in] The number of <see cref="COR_FIELD"/> objects whose field information is to be retrieved.</param>
        /// <param name="fields">[out] An array of <see cref="COR_FIELD"/> objects that provide information about the fields that belong to the type.</param>
        /// <param name="pceltNeeded">[out] A pointer to the number of <see cref="COR_FIELD"/> objects included in fields.</param>
        /// <remarks>
        /// The celt parameter, which specifies the number of fields whose field information the method uses to populate fields,
        /// should correspond to the value of the <see cref="COR_TYPE_LAYOUT.numFields"/> field.
        /// </remarks>
        [PreserveSig]
        HRESULT GetTypeFields(
            [In] COR_TYPEID id,
            [In] int celt,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] COR_FIELD[] fields,
            [Out] out int pceltNeeded);

        /// <summary>
        /// Sets a value that determines how an application loads native images while running under a managed debugger.
        /// </summary>
        /// <param name="ePolicy">[in] A <see cref="CorDebugNGenPolicy"/> constant that determines how an application loads native images while running under a managed debugger.</param>
        /// <remarks>
        /// If the policy is set successfully, the method returns S_OK. If ePolicy is outside the range of the enumerated values
        /// defined by <see cref="CorDebugNGenPolicy"/>, the method returns E_INVALIDARG and the method call has no effect.
        /// If the policy of the Native Image Generator (Ngen.exe) cannot be updated, the method returns E_FAIL. The ICorDebugProcess5::EnableNGenPolicy
        /// method can be called at any time during the lifetime of the process. The policy is in effect for any modules that
        /// are loaded after the policy is set.
        /// </remarks>
        [PreserveSig]
        HRESULT EnableNGENPolicy(
            [In] CorDebugNGenPolicy ePolicy);
    }
}
