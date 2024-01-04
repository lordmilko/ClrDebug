using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a module signature -- a definition which will match a set of modules by name and/or version.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("31E53A5A-01EE-4BBB-B899-4B46AE7D595C")]
    [ComImport]
    public interface IDebugHostModuleSignature
    {
        /// <summary>
        /// The IsMatch method compares a particular module (as given by an <see cref="IDebugHostModule"/> symbol) against a signature, comparing the module name and version to the name and version range indicated in the signature.<para/>
        /// An indication of whether the given module symbol matches the signature is returned.
        /// </summary>
        /// <param name="pModule">The module symbol to compare against the module signature.</param>
        /// <param name="isMatch">An indication of whether the given module symbol matches the module signature is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT IsMatch(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostModule pModule,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isMatch);
    }
}
