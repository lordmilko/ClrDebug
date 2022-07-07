using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5bd9d474-5975-423a-b88b-65a8e7110e65")]
    [ComImport]
    public interface IDebugBreakpoint
    {
        [PreserveSig]
        HRESULT GetId(
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetType(
            [Out] out DEBUG_BREAKPOINT_TYPE BreakType,
            [Out] out uint ProcType);

        [PreserveSig]
        HRESULT GetAdder(
            [Out, ComAliasName("IDebugClient")] IntPtr Adder);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out DEBUG_BREAKPOINT_FLAG Flags);

        [PreserveSig]
        HRESULT AddFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        [PreserveSig]
        HRESULT RemoveFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        [PreserveSig]
        HRESULT SetFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        [PreserveSig]
        HRESULT GetOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT SetOffset(
            [In] ulong Offset);

        [PreserveSig]
        HRESULT GetDataParameters(
            [Out] out uint Size,
            [Out] out DEBUG_BREAKPOINT_ACCESS_TYPE AccessType);

        [PreserveSig]
        HRESULT SetDataParameters(
            [In] uint Size,
            [In] DEBUG_BREAKPOINT_ACCESS_TYPE AccessType);

        [PreserveSig]
        HRESULT GetPassCount(
            [Out] out uint Count);

        [PreserveSig]
        HRESULT SetPassCount(
            [In] uint Count);

        [PreserveSig]
        HRESULT GetCurrentPassCount(
            [Out] out uint Count);

        [PreserveSig]
        HRESULT GetMatchThreadId(
            [Out] out uint Id);

        [PreserveSig]
        HRESULT SetMatchThreadId(
            [In] uint Thread);

        [PreserveSig]
        HRESULT GetCommand(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint CommandSize);

        [PreserveSig]
        HRESULT SetCommand(
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);

        [PreserveSig]
        HRESULT GetOffsetExpression(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ExpressionSize);

        [PreserveSig]
        HRESULT SetOffsetExpression(
            [In, MarshalAs(UnmanagedType.LPStr)] string Expression);

        [PreserveSig]
        HRESULT GetParameters(
            [Out] out DEBUG_BREAKPOINT_PARAMETERS Params);
    }
}
