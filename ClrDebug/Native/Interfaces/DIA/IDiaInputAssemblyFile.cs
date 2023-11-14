using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3BFE56B0-390C-4863-9430-1F3D083B7684")]
    [ComImport]
    public interface IDiaInputAssemblyFile
    {
        [PreserveSig]
        HRESULT get_uniqueId(
            [Out] out int pRetVal);

        [PreserveSig]
        HRESULT get_index(
            [Out] out int pRetVal);

        [PreserveSig]
        HRESULT get_timeStamp(
            [Out] out int pRetVal);

        [PreserveSig]
        HRESULT get_pdbAvailableAtILMerge(
            [Out] out bool pRetVal);

        [PreserveSig]
        HRESULT get_fileName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRetVal);

        [PreserveSig]
        HRESULT get_version(
            [In] int cbData,
            [Out] out int pcbData,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pbData);
    }
}
