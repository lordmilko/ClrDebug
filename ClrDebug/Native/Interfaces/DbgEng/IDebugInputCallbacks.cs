using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9f50e42c-f136-499e-9a97-73036c94ed2d")]
    [ComImport]
    public interface IDebugInputCallbacks
    {
        /// <summary>
        /// The StartInput callback method is called by the engine to indicate that it is waiting for a line of input.
        /// </summary>
        /// <param name="bufferSize">[in] Specifies the number of characters requested. Any input longer than this size will be truncated.</param>
        /// <returns>The return value is ignored by the engine unless it indicates a remote procedure call error; in this case the client, with which this IDebugEventCallbacks object is registered, is disabled.</returns>
        /// <remarks>
        /// This method indicates that the engine is waiting for a line of input from any client. This can occur if, for example,
        /// the <see cref="IDebugControl.Input"/> method was called on a client. After calling this method, the engine waits
        /// until it receives some input. When it does receive input, it calls <see cref="EndInput"/> to inform all the IDebugInputCallbacks
        /// objects that are registered with clients that it is no longer waiting for input. The IDebugInputCallbacks object
        /// can provide the engine with a line of input by calling either the <see cref="IDebugControl.ReturnInput"/> or ReturnInputWide
        /// methods. For more information about debugger engine input, see Input and Output.
        /// </remarks>
        [PreserveSig]
        HRESULT StartInput(
            [In] int bufferSize);

        /// <summary>
        /// The EndInput callback method is called by the engine to indicate that it is no longer waiting for input.
        /// </summary>
        /// <returns>This method's return value is ignored by the engine.</returns>
        /// <remarks>
        /// Even if the engine has not called <see cref="StartInput"/> for this <see cref="IDebugInputCallbacks"/> object,
        /// the engine will call EndInput if another IDebugInputCallbacks object returned an error from the IDebugInputCallbacks::StartInput
        /// method. For more information about debugger engine input, see Input and Output.
        /// </remarks>
        [PreserveSig]
        HRESULT EndInput();
    }
}
