using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Receives callbacks from the DIA symbol locating procedure, allowing restrictions to be imposed on the locating process.
    /// </summary>
    /// <remarks>
    /// The client application implements this interface and provides a reference to it in the call to the IDiaDataSource
    /// method. Remember to implement all of the methods in the IDiaLoadCallback interface as well.
    /// </remarks>
    [Guid("4688A074-5A4D-4486-AEA8-7B90711D9F7C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IDiaLoadCallback2 : IDiaLoadCallback
    {
        /// <summary>
        /// Called when a debug directory was found in the .exe file.
        /// </summary>
        /// <param name="fExecutable">[in] TRUE if the debug directory is read from an executable (rather than a .dbg file).</param>
        /// <param name="cbData">[in] Count of bytes of data in the debug directory.</param>
        /// <param name="pbData">[in] An array that is filled in with the debug directory.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The return code is typically ignored.</returns>
        /// <remarks>
        /// The IDiaDataSource method invokes this callback when it finds a debug directory while processing the executable
        /// file. This method removes the need for the client to reverse engineer the executable and/or debug file to support
        /// debug information other than that found in the .pdb file. With this data, the client can recognize the type of
        /// debug information available and whether it resides in the executable file or the .dbg file. Most clients will not
        /// need this callback because the IDiaDataSource::loadDataForExe method transparently opens both .pdb and .dbg files
        /// when necessary to serve symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT NotifyDebugDir(
            [In] bool fExecutable,
            [In] int cbData,
            [In] IntPtr pbData); //According to the DIA2Dump sample, this value is in fact an IMAGE_DEBUG_DIRECTORY*

        /// <summary>
        /// Called when a candidate .dbg file has been opened.
        /// </summary>
        /// <param name="dbgPath">[in] The full path of the .dbg file.</param>
        /// <param name="resultCode">[in] Code that indicates the success (S_OK) or failure of the load as applied to this file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The return code is typically ignored.</returns>
        [PreserveSig]
        new HRESULT NotifyOpenDBG(
            [MarshalAs(UnmanagedType.LPWStr), In] string dbgPath,
            [In] HRESULT resultCode);

        /// <summary>
        /// Called when a candidate .pdb file is opened.
        /// </summary>
        /// <param name="pdbPath">[in] The full path of the .pdb file.</param>
        /// <param name="resultCode">[in] Code that indicates the success (S_OK) or failure of the load as applied to this file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The return code is typically ignored.</returns>
        [PreserveSig]
        new HRESULT NotifyOpenPDB(
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
        new HRESULT RestrictRegistryAccess();

        /// <summary>
        /// Determines if access is allowed to a symbol server to resolve symbols.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Any return code other than S_OK prevents use of a symbol server to resolve symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT RestrictSymbolServerAccess();

        /// <summary>
        /// Determines if it is okay to look for a .pdb file in the original debug directory.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Any return code other than S_OK prevents looking for a .pdb file in the original debug directory. The original
        /// debug directory is the path to the symbol file compiled into the executable when debugging is turned on. This path
        /// is not necessarily the same as the path where the executable exists.
        /// </remarks>
        [PreserveSig]
        HRESULT RestrictOriginalPathAccess();

        /// <summary>
        /// Determines if looking for a .pdb file is allowed in the path where the .exe file is located.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Any return code other than S_OK to prevent looking for a .pdb file in the path where the .exe file is located.
        /// </remarks>
        [PreserveSig]
        HRESULT RestrictReferencePathAccess();

        /// <summary>
        /// Determines if looking for debug information is allowed from .dbg files.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Any return value other than S_OK to prevent looking for debug information from .dbg files.
        /// </remarks>
        [PreserveSig]
        HRESULT RestrictDBGAccess();

        /// <summary>
        /// Determines if searching for .pdb files is allowed in the system root directory.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Any return code other than S_OK prevents searching the system root for .pdb files.
        /// </remarks>
        [PreserveSig]
        HRESULT RestrictSystemRootAccess();
    }
}
