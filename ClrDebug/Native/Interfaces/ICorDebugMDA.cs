using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents a managed debugging assistant (MDA) message.
    /// </summary>
    [Guid("CC726F2F-1DB7-459B-B0EC-05F01D841B42")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugMDA
    {
        /// <summary>
        /// Gets a string containing the name of the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        /// <param name="cchName">[in] The size of the szName array.</param>
        /// <param name="pcchName">[out] A pointer to the length of the name.</param>
        /// <param name="szName">[out] An array in which to store the name.</param>
        /// <remarks>
        /// MDA names are unique values. The GetName method is a convenient performance alternative to getting the XML stream
        /// and extracting the name from the stream based on the schema.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);

        /// <summary>
        /// Gets a string containing the description of the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        /// <param name="cchName">[in] The size of the string buffer that will store the description.</param>
        /// <param name="pcchName">[out] A pointer to the number of bytes returned in the string buffer.</param>
        /// <param name="szName">[out] A string buffer containing the description of the MDA.</param>
        /// <remarks>
        /// The string can be zero in length.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDescription(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);

        /// <summary>
        /// Gets the full XML stream associated with the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        /// <param name="cchName">[in] The size of the szName array.</param>
        /// <param name="pcchName">[out] A pointer to the length of the XML stream.</param>
        /// <param name="szName">[out] An array in which to store the XML stream. The array may be empty.</param>
        /// <remarks>
        /// The GetXML method can potentially affect performance, depending on the size of the associated XML stream.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetXML(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);

        /// <summary>
        /// Gets the flags associated with the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/>.
        /// </summary>
        /// <param name="pFlags">[in] A bitwise combination of the <see cref="CorDebugMDAFlags"/> enumeration values that specify the settings of the flags for this MDA.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFlags(
            [In] ref CorDebugMDAFlags pFlags);

        /// <summary>
        /// Gets the operating system (OS) thread identifier upon which the managed debugging assistant (MDA) represented by <see cref="ICorDebugMDA"/> is executing.
        /// </summary>
        /// <param name="pOsTid">[out] A pointer to the OS thread identifier.</param>
        /// <remarks>
        /// The OS thread is used instead of an <see cref="ICorDebugThread"/> to allow for situations in which an MDA is fired either on
        /// a native thread or on a managed thread that has not yet entered managed code.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetOSThreadId(
            [Out] out int pOsTid);
    }
}
