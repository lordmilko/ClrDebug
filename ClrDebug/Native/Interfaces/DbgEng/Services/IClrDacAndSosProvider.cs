using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("498CBE80-B1F4-4F55-91E1-477C507A1D9F")]
    [ComImport]
    public interface IClrDacAndSosProvider
    {
        /// <summary>
        /// Determines if an image/module is a CLR image and if it can provide (retrieve/download/etc.) the CLR DAC and SOS for it.
        /// </summary>
        [PreserveSig]
        HRESULT IsClrImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule module,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsClrImage,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrDac,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pbCanProvideClrSos);

        /// <summary>
        /// Retrieves/downloads/etc. the CLR DAC.
        /// </summary>
        [PreserveSig]
        HRESULT ProvideClrDac(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDacPath);

        /// <summary>
        /// Retrieves/downloads/etc. the CLR SOS.
        /// </summary>
        [PreserveSig]
        HRESULT ProvideClrSos(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string forcePath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pSosPath);
    }
}
