using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    [Guid("75DA9E4C-BD33-43C8-8F5C-96E8A5241F57")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataExceptionState
    {
        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataExceptionStateFlag flags);

        [PreserveSig]
        HRESULT GetPrevious(
            [Out] out IXCLRDataExceptionState exState);

        [PreserveSig]
        HRESULT GetManagedObject(
            [Out] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT GetBaseType(
            [Out] out CLRDataBaseExceptionType type);

        [PreserveSig]
        HRESULT GetCode(
            [Out] out int code);

        [PreserveSig]
        HRESULT GetString(
            [In] int bufLen,
            [Out] out int strLen,
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 0)] StringBuilder str);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode, //Requests can be across a variety of enums
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT IsSameState(
            [In] ref EXCEPTION_RECORD64 exRecord,
            [In] int contextSize,
            [In] IntPtr cxRecord);

        [PreserveSig]
        HRESULT IsSameState2(
            [In] CLRDataExceptionSameFlag flags,
            [In] ref EXCEPTION_RECORD64 exRecord,
            [In] int contextSize,
            [In] IntPtr cxRecord);

        [PreserveSig]
        HRESULT GetTask(
            [Out] out IXCLRDataTask task);
    }
}
