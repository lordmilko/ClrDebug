using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface to a breakpoint on the script. The script provider implements this interface to expose the notion of and control of a particular breakpoint within the script.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6BB27B35-02E6-47CB-90A0-5371244032DE")]
    [ComImport]
    public interface IDataModelScriptDebugBreakpoint
    {
        /// <summary>
        /// The GetId method returns the unique identifier assigned by the script provider's debug engine to the breakpoint.<para/>
        /// This identifier must be unique within the context of the containing script. The breakpoint identifier may be unique to the provider; however, that is not required.
        /// </summary>
        /// <returns>This method returns ULONG64. The value is the unique identifier assigned to the breakpoint.</returns>
        [PreserveSig]
        long GetId();

        /// <summary>
        /// The IsEnabled method returns whether or not the breakpoint is enabled. A disabled breakpoint still exists and is still in the list of breakpoints for the script, it is merely "turned off" temporarily.<para/>
        /// All breakpoints should be created in the enabled state.
        /// </summary>
        /// <returns>This method returns bool. The value is an indication of whether the breakpoint is enabled or not.</returns>
        [return: MarshalAs(UnmanagedType.U1)]
        bool IsEnabled();

        /// <summary>
        /// The Enable method enables the breakpoint. If the breakpoint was disabled, "hitting the breakpoint" after calling this method will cause a break into the debugger.
        /// </summary>
        [PreserveSig]
        void Enable();

        /// <summary>
        /// The Disable method disables the breakpoint. After this call, "hitting the breakpoint" after calling this method will not break into the debugger.<para/>
        /// The breakpoint, while still present, is considered "turned off".
        /// </summary>
        [PreserveSig]
        void Disable();

        /// <summary>
        /// The Remove method removes the breakpoint from its containing list. The breakpoint no longer semantically exists after this method returns.<para/>
        /// The <see cref="IDataModelScriptDebugBreakpoint"/> interface which represented the breakpoint is considered orphaned after the call.<para/>
        /// Nothing else can (legally) be done with it after this call other than releasing it.
        /// </summary>
        [PreserveSig]
        void Remove();

        /// <summary>
        /// The GetPosition method returns the position of the breakpoint within the script. The script debugger must return the line and column within source code where the breakpoint is located.<para/>
        /// If it is capable of doing so, it can also return a span of source represented by the breakpoint by filling out an end position as defined by the positionSpanEnd argument.<para/>
        /// If the debugger is not capable of producing this span and the caller requests it, the Line and Column fields of the span's ending position should be filled in as zero indicating that the values cannot be provided.<para/>
        /// The debugger may also return the text of the line (or span) of source code where breakpoint exists in the lineText argument.<para/>
        /// While it is strongly recommended that debuggers return this value, it is not required. Only the line and column position within source are required return values.<para/>
        /// Should the debugger not be capable of producing the source text, nullptr may be returned in the lineText argument.
        /// </summary>
        /// <param name="position">The line and column position of the breakpoint within the script's source code must be returned here.</param>
        /// <param name="positionSpanEnd">If the debugger is capable of producing the span of source represented by the breakpoint, it can return the line and column positions of the end of the span here.<para/>
        /// If not, the Line and Column values of the structure should be set to zero indicating that the values cannot be provided..</param>
        /// <param name="lineText">If the debugger can produce the line (or span) of source code represented by the breakpoint, it returns such here as a string allocated via the SysAllocString function.<para/>
        /// The caller is responsible for freeing the returned string via SysFreeString. If the debugger is not capable of returning this source text, nullptr should be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetPosition(
            [Out] out ScriptDebugPosition position,
            [Out] out ScriptDebugPosition positionSpanEnd,
            [Out, MarshalAs(UnmanagedType.BStr)] out string lineText);
    }
}
