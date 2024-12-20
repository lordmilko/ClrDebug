using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F3E0DAE9-6385-41BE-9EA6-75BCFBF5B727")]
    [ComImport]
    public interface ISvcSearchPaths
    {
        /// <summary>
        /// Provides a semicolon separated list of paths to the provider in which to search for the appropriate images/symbols.<para/>
        /// Note that this accepts symbol server syntax.
        /// </summary>
        [PreserveSig]
        HRESULT SetAllPaths(
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPaths);

        /// <summary>
        /// Provides a semicolon separated list of paths from which the provider will search for the appropriate images/symbols.<para/>
        /// Note that this will return symbol server syntax.
        /// </summary>
        [PreserveSig]
        HRESULT GetAllPaths(
            [Out, MarshalAs(UnmanagedType.BStr)] out string searchPaths);
    }
}
