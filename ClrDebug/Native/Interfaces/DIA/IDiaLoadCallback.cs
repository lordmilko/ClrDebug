using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Receives callbacks from the DIA symbol locating procedure, thus enabling a user interface to report on the progress of the location attempt.
    /// </summary>
    /// <remarks>
    /// The client application implements this interface and provides a reference to it in the call to the <see cref="IDiaDataSource.loadDataForExe"/>
    /// method. For additional restrictions that can be imposed on a load process, see the <see cref="IDiaLoadCallback2"/>
    /// interface.
    /// </remarks>
    [Guid("C32ADB82-73F4-421B-95D5-A4706EDF5DBE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaLoadCallback
    {
        /// <summary>
        /// Called when a debug directory was found in the .exe file.
        /// </summary>
        /// <param name="fExecutable">[in] TRUE if the debug directory is read from an executable (rather than a .dbg file).</param>
        /// <param name="cbData">[in] Count of bytes of data in the debug directory.</param>
        /// <param name="pbData">[in] An array that is filled in with the debug directory.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The return code is typically ignored.</returns>
        /// <remarks>
        /// The <see cref="IDiaDataSource.loadDataForExe"/> method invokes this callback when it finds a debug directory while
        /// processing the executable file. This method removes the need for the client to reverse engineer the executable
        /// and/or debug file to support debug information other than that found in the .pdb file. With this data, the client
        /// can recognize the type of debug information available and whether it resides in the executable file or the .dbg
        /// file. Most clients will not need this callback because the IDiaDataSource::loadDataForExe method transparently
        /// opens both .pdb and .dbg files when necessary to serve symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT NotifyDebugDir(
            [In, MarshalAs(UnmanagedType.Bool)] bool fExecutable,
            [In] int cbData,
            [In] IntPtr pbData); //According to the DIA2Dump sample, this value is in fact an IMAGE_DEBUG_DIRECTORY*

        /// <summary>
        /// Called when a candidate .dbg file has been opened.
        /// </summary>
        /// <param name="dbgPath">[in] The full path of the .dbg file.</param>
        /// <param name="resultCode">[in] Code that indicates the success (S_OK) or failure of the load as applied to this file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The return code is typically ignored.</returns>
        [PreserveSig]
        HRESULT NotifyOpenDBG(
            [MarshalAs(UnmanagedType.LPWStr), In] string dbgPath,
            [In] HRESULT resultCode);

        /// <summary>
        /// Called when a candidate .pdb file is opened.
        /// </summary>
        /// <param name="pdbPath">[in] The full path of the .pdb file.</param>
        /// <param name="resultCode">[in] Code that indicates the success (S_OK) or failure of the load as applied to this file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The return code is typically ignored.</returns>
        [PreserveSig]
        HRESULT NotifyOpenPDB(
            [MarshalAs(UnmanagedType.LPWStr), In] string pdbPath,
            [In] HRESULT resultCode);

        /// <summary>
        /// Determines if registry queries can be used to locate symbol search paths.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Any return code other than S_OK prevents querying the registry for symbol search paths.
        /// </remarks>
        [PreserveSig]
        HRESULT RestrictRegistryAccess();

        /// <summary>
        /// Determines if access is allowed to a symbol server to resolve symbols.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Any return code other than S_OK prevents use of a symbol server to resolve symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT RestrictSymbolServerAccess();
    }
}
