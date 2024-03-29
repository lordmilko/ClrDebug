﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("Message = {Message.ToString(),nq}, InnerException = {InnerException.ToString(),nq}, StackTrace = {StackTrace.ToString(),nq}, WatsonBuckets = {WatsonBuckets.ToString(),nq}, StackTraceString = {StackTraceString.ToString(),nq}, RemoteStackTraceString = {RemoteStackTraceString.ToString(),nq}, HResult = {HResult}, XCode = {XCode}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpExceptionObjectData
    {
        public CLRDATA_ADDRESS Message;
        public CLRDATA_ADDRESS InnerException;
        public CLRDATA_ADDRESS StackTrace;
        public CLRDATA_ADDRESS WatsonBuckets;
        public CLRDATA_ADDRESS StackTraceString;
        public CLRDATA_ADDRESS RemoteStackTraceString;
        public int HResult;
        public int XCode;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            var psos2 = sos as ISOSDacInterface2;

            if (psos2 == null)
                return HRESULT.E_NOINTERFACE;

            return psos2.GetObjectExceptionData(addr, out this);
        }
    }
}
