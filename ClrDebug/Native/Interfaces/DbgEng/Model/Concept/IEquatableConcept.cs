using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Supports the ability to compare this object to another (of arbitrary type) for equality.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C52D5D3D-609D-4D5D-8A82-46B0ACDEC4F4")]
    [ComImport]
    public interface IEquatableConcept
    {
        /// <summary>
        /// Compares this object to another (of arbitrary type) for equality. If the comparison cannot be performed, E_NOT_SET should be returned.<see cref="IEquatableConcept"/> is typically implemented by the object creators.<para/>
        /// To compare objects consider using <see cref="IModelObject"/>::IsEqualTo or <see cref="IModelObject"/>::Compare.
        /// </summary>
        /// <param name="contextObject">The object being compared.</param>
        /// <param name="otherObject">The other object (of arbitrary type) that contextObject is being compared to.</param>
        /// <param name="isEqual">Returned Boolean indicating if the two objects are equal.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Generally speaking, you will implement (but not necessarily consume) <see cref="IEquatableConcept"/>. It can be
        /// easier to call <see cref="IModelObject"/>::IsEqualTo or <see cref="IModelObject"/>::Compare and let those methods
        /// manage the concept fetch.
        /// </remarks>
        [PreserveSig]
        HRESULT AreObjectsEqual(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject otherObject,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isEqual);
    }
}
