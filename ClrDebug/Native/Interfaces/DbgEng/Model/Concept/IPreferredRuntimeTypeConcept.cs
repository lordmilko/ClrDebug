using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Interface which clients can implement if they can provide better dynamic runtime type analysis for a given type than the debugger can acquire through RTTI or v-table analysis.<para/>
    /// The object understands more about types derived from it than the underlying type system is capable of providing and would like to handle its own conversions from static to runtime type.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9D6C1D7B-A76F-4618-8068-5F76BD9A4E8A")]
    [ComImport]
    public interface IPreferredRuntimeTypeConcept
    {
        /// <summary>
        /// The CastToPreferredRuntimeType method is called whenever a client wishes to attempt to convert from a static type instance to the runtime type of that instance.<para/>
        /// If the object in question supports (through one of its attached parent models) the preferred runtime type concept, this method will be called to perform the conversion.<para/>
        /// This method may either return the original object (there is no conversion or it could not be analyzed), return a new instance of the runtime type, fail for non-semantic reasons (e.g.: out of memory), or return E_NOT_SET.<para/>
        /// The E_NOT_SET error code is a very special error code which indicates to the data model that the implementation does not want to override the default behavior and that the data model should fall back to whatever analysis is performed by the debug host (e.g.: RTTI analysis, examination of the shape of the virtual function tables, etc...)
        /// </summary>
        /// <param name="contextObject">The statically typed instance object (this pointer) for which to perform analysis and attempt to downcast to the runtime type.</param>
        /// <param name="object">If a conversion to a runtime type occurred, this is a new instance typed according to the runtime type. If the analysis could not be performed or there was no change in type, this may be the original object.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        [PreserveSig]
        HRESULT CastToPreferredRuntimeType(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object);
    }
}
