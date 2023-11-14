using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0000000D-0000-0000-C000-000000000046")]
    [ComImport]
    public interface IEnumSTATSTG
    {
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out] out STATSTG rgelt,
            [Out] out int pceltFetched);

        [PreserveSig]
        HRESULT Skip(
            [In] int celt);

        [PreserveSig]
        HRESULT Reset();

        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumSTATSTG ppenum);
    }
}
