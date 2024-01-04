using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BC6823E0-6E29-4474-9A9B-7728844E90A2")]
    [ComImport]
    public interface IClrDacDbiAndSosProvider : IClrDacAndSosProvider
    {
        [PreserveSig]
        new HRESULT IsClrImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule module,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsClrImage,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrDac,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrSos);
        
        [PreserveSig]
        new HRESULT ProvideClrDac(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDacPath);
        
        [PreserveSig]
        new HRESULT ProvideClrSos(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pSosPath);
        
        [PreserveSig]
        HRESULT IsClrImageEx(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule module,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsClrImage,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrDac,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrDbi,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrSos);
        
        [PreserveSig]
        HRESULT ProvideClrDbi(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDbiPath);
    }
}
