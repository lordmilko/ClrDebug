using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes an abstract stack provider. Semantically, this is a layer above a stack unwinder which returns physical frames on a stack and register contexts.<para/>
    /// Frames from a stack provider can be physical frames provided by a stack unwinder... or they can be inline frames on top of those physical frames...<para/>
    /// or they can be entirely synthetic constructs that represent some logical form of call chain.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C11A8084-0BC4-45F8-AF3C-821FBC835312")]
    [ComImport]
    public interface ISvcStackProvider
    {
        /// <summary>
        /// Starts a stack walk for the execution unit given by the unwind context and returns a frame set enumerator representing the frames within that stack walk.
        /// </summary>
        [PreserveSig]
        HRESULT StartStackWalk(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext unwindContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrameSetEnumerator frameEnum);

        /// <summary>
        /// Starts a stack walk given an alternate starting register context. Other than assuming a different initial register context than StartStackWalk, the method operates identically.<para/>
        /// Stack providers which deal in physical frames *SHOULD* implement this method. Stack providers which do not may legally E_NOTIMPL this method.
        /// </summary>
        [PreserveSig]
        HRESULT StartStackWalkForAlternateContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext unwindContext,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext registerContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrameSetEnumerator frameEnum);
    }
}
