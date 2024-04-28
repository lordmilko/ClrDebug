using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Compares this object to another (of arbitrary type). If the comparison cannot be performed, E_NOT_SET should be returned.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A7830646-9F0C-4A31-BA19-503F33E6C8A3")]
    [ComImport]
    public interface IComparableConcept
    {
        /// <summary>
        /// Compares this object to another (of arbitrary type). If the comparison cannot be performed, E_NOT_SET should be returned.<para/>
        /// The return value passed in comparison result has the following meaning:
        /// </summary>
        /// <param name="contextObject">The object which is being compared. This should be the same object from which the comparable concept was acquired.</param>
        /// <param name="otherObject">The object to compare to.</param>
        /// <param name="comparisonResult">The result of the comparison will be returned here. If the returned value is less than 0, contextObject is less than otherObject.<para/>
        /// If the returned value is zero, they are equal. If the returned value is greater than zero, contextObject is greater than otherObject.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT CompareObjects(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject otherObject,
            [Out] out int comparisonResult);
    }
}
