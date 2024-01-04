using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5742B585-5542-4A5B-93E1-A05A6D9B6B89")]
    [ComImport]
    public interface ISvcSymbolSetTypeDerivations
    {
        [PreserveSig]
        HRESULT CreateArrayType(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbolType baseType,
            [In] long dimensions,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] long[] dimensionSizes,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] long[] lowerBounds,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolType arrayType);
    }
}
