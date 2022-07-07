using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1b278d20-79f2-426e-a3f9-c1ddf375d48e")]
    [ComImport]
    public interface IDebugBreakpoint2 : IDebugBreakpoint
    {
        #region IDebugBreakpoint

        [PreserveSig]
        new HRESULT GetId(
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetType(
            [Out] out DEBUG_BREAKPOINT_TYPE BreakType,
            [Out] out uint ProcType);

        [PreserveSig]
        new HRESULT GetAdder(
            [Out] IntPtr Adder);

        [PreserveSig]
        new HRESULT GetFlags(
            [Out] out DEBUG_BREAKPOINT_FLAG Flags);

        [PreserveSig]
        new HRESULT AddFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        [PreserveSig]
        new HRESULT RemoveFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        [PreserveSig]
        new HRESULT SetFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        [PreserveSig]
        new HRESULT GetOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT SetOffset(
            [In] ulong Offset);

        [PreserveSig]
        new HRESULT GetDataParameters(
            [Out] out uint Size,
            [Out] out DEBUG_BREAKPOINT_ACCESS_TYPE AccessType);

        [PreserveSig]
        new HRESULT SetDataParameters(
            [In] uint Size,
            [In] DEBUG_BREAKPOINT_ACCESS_TYPE AccessType);

        [PreserveSig]
        new HRESULT GetPassCount(
            [Out] out uint Count);

        [PreserveSig]
        new HRESULT SetPassCount(
            [In] uint Count);

        [PreserveSig]
        new HRESULT GetCurrentPassCount(
            [Out] out uint Count);

        [PreserveSig]
        new HRESULT GetMatchThreadId(
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT SetMatchThreadId(
            [In] uint Thread);

        [PreserveSig]
        new HRESULT GetCommand(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        [PreserveSig]
        new HRESULT SetCommand(
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);

        [PreserveSig]
        new HRESULT GetOffsetExpression(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ExpressionSize);

        [PreserveSig]
        new HRESULT SetOffsetExpression(
            [In, MarshalAs(UnmanagedType.LPStr)] string Expression);

        [PreserveSig]
        new HRESULT GetParameters(
            [Out] out DEBUG_BREAKPOINT_PARAMETERS Params);

        #endregion
        #region IDebugBreakpoint2

        [PreserveSig]
        HRESULT GetCommandWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        [PreserveSig]
        HRESULT SetCommandWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);

        [PreserveSig]
        HRESULT GetOffsetExpressionWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ExpressionSize);

        [PreserveSig]
        HRESULT SetOffsetExpressionWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);

        #endregion
    }
}
