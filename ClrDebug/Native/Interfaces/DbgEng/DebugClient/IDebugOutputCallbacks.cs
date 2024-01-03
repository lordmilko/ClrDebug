using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4bf58045-d654-4c40-b0af-683090f356dc")]
    [ComImport]
    public interface IDebugOutputCallbacks
    {
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
        HRESULT Output(
            [In] DEBUG_OUTPUT mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string text);
    }
}
