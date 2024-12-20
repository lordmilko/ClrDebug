using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a way to create type representations which do not exist in the symbols (e.g.: arrays of things that are in symbols, etc...).<para/>
    /// Such can act as an aide to a higher level expression evaluator, etc...
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5742B585-5542-4A5B-93E1-A05A6D9B6B89")]
    [ComImport]
    public interface ISvcSymbolSetTypeDerivations
    {
        /// <summary>
        /// Returns an ISvcSymbolType representing an array from a partial description of what that array may look like at a linguistic level.<para/>
        /// The only mandatory piece of information to this method is the number of dimensions of the array. Languages for which array types are otherwise dynamic (e.g.: C#) require only this bit of information.<para/>
        /// Other languages may require an explicit specification of the sizes and/or lower bounds of dimensions. There is no guarantee that this method will succeed.
        /// </summary>
        [PreserveSig]
        HRESULT CreateArrayType(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbolType baseType,
            [In] long dimensions,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] long[] dimensionSizes,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] long[] lowerBounds,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolType arrayType);
    }
}
