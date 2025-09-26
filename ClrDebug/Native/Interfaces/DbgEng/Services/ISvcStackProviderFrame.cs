using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a single frame from a stack provider. The base interface only provides detection of the frame kind. Other interfaces may be required depending on the frame type.<para/>
    /// Some interfaces are optional for any type of stack frame.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2F79D431-71BF-4F40-B959-96361E92AD04")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcStackProviderFrame
    {
        /// <summary>
        /// Gets the kind of stack frame that this ISvcStackProviderFrame represents.
        /// </summary>
        [PreserveSig]
        StackProviderFrameKind GetFrameKind();
    }
}
