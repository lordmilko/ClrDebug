using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BC6823E0-6E29-4474-9A9B-7728844E90A2")]
    [ComImport]
    public interface IClrDacDbiAndSosProvider : IClrDacAndSosProvider
    {
        /// <summary>
        /// Determines if an image/module is a CLR image and if it can provide (retrieve/download/etc.) the CLR DAC and SOS for it.
        /// </summary>
        [PreserveSig]
        new HRESULT IsClrImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule module,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsClrImage,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrDac,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrSos);

        /// <summary>
        /// Retrieves/downloads/etc. the CLR DAC.
        /// </summary>
        [PreserveSig]
        new HRESULT ProvideClrDac(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDacPath);

        /// <summary>
        /// Retrieves/downloads/etc. the CLR SOS.
        /// </summary>
        [PreserveSig]
        new HRESULT ProvideClrSos(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pSosPath);

        /// <summary>
        /// Determines if an image/module is a CLR image and if it can provide (retrieve/download/etc.) the CLR DAC, DBI, and SOS for it.
        /// </summary>
        [PreserveSig]
        HRESULT IsClrImageEx(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule module,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsClrImage,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrDac,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrDbi,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrSos);

        /// <summary>
        /// Retrieves/downloads/etc. the CLR DBI.
        /// </summary>
        [PreserveSig]
        HRESULT ProvideClrDbi(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDbiPath);
    }
}
