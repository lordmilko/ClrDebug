using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The IDebugOutputCallbacks2 interface allows clients to receive full debugger markup language (DML) content for presentation.<para/>
    /// This interface extends the <see cref="IDebugOutputCallbacks"/> interface, not the <see cref="IDebugOutputCallbacksWide"/> interface.<para/>
    /// Therefore, it can be passed in to the existing <see cref="IDebugClient.SetOutputCallbacks"/> method. The engine performs a QueryInterface for IDebugOutputCallbacks2 to see which interface the incoming output callback object supports.<para/>
    /// If the object supports IDebugOutputCallbacks2, all output will be sent through the extended IDebugOutputCallbacks2 methods.<para/>
    /// An output object can register for both text and DML content, if it can handle them both. During output processing of the callback the engine will pick the format that reduces conversions, thus supporting both may reduce conversions in the engine.<para/>
    /// It is not necessary, though, and supporting only one format is the expected mode of operation. The basic <see cref="IDebugOutputCallbacks.Output"/> method is not used.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("67721fe9-56d2-4a44-a325-2b65513ce6eb")]
    [ComImport]
    public interface IDebugOutputCallbacks2 : IDebugOutputCallbacks
    {
        #region IDebugOutputCallbacks

        /// <summary>
        /// The Output callback method is called by the engine to send output from the client to the IDebugOutputCallbacks object that is registered with the client.
        /// </summary>
        /// <param name="mask">[in] Specifies the DEBUG_OUTPUT_XXX bit flags that indicate the nature of the output.</param>
        /// <param name="text">[in] Specifies the output that is being sent.</param>
        /// <returns>The return value is ignored by the engine unless it indicates a remote procedure call error; in this case the client, with which this IDebugEventCallbacks object is registered, is disabled.</returns>
        /// <remarks>
        /// The engine calls this method only if the supplied value of Mask is allowed by the client's output control. For
        /// more information about debugger engine output, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT Output(
            [In] DEBUG_OUTPUT mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string text);

        #endregion
        #region IDebugOutputCallbacks2

        /// <summary>
        /// Allows the callback object to describe which kinds of output notifications it wants to receive.
        /// </summary>
        /// <param name="mask">The type of output notification to receive.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT GetInterestMask(
            [Out] out DEBUG_OUTCBI mask);

        /// <summary>
        /// Returns notifications for the <see cref="IDebugOutputCallbacks2"/> interface.
        /// </summary>
        /// <param name="which">[in] The kind of DEBUG_OUTCB_XXX notification that is coming in. The DEBUG_OUTCB_XXX notifications are defined in the dbgeng.h header using #defines.<para/>
        /// For more information, see DEBUG_OUTCB_XXX.</param>
        /// <param name="flags">[in] Flags that are part of the notification payload.</param>
        /// <param name="arg">[in] Arguments that are part of the notification payload. This is typically a <see cref="DEBUG_OUTPUT"/> value.</param>
        /// <param name="text">[in, optional] A pointer to text that is part of the notification payload.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT Output2(
            [In] DEBUG_OUTCB which,
            [In] DEBUG_OUTCBF flags,
            [In] long arg,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text);

        #endregion
    }
}
