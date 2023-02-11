using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("{ToString(),nq}")]
    [StructLayout(LayoutKind.Explicit, Size = 8, Pack = 8)]
    public struct FunctionIDOrClientID
    {
        [FieldOffset(0)]
        public FunctionID functionId;
        [FieldOffset(0)]
        public IntPtr clientID;

        public static implicit operator FunctionIDOrClientID(FunctionID functionId)
        {
            return new FunctionIDOrClientID {functionId = functionId};
        }

        public static implicit operator FunctionIDOrClientID(IntPtr clientID)
        {
            return new FunctionIDOrClientID {clientID = clientID};
        }

        public static implicit operator FunctionID(FunctionIDOrClientID value)
        {
            return value.functionId;
        }

        public static implicit operator IntPtr(FunctionIDOrClientID value)
        {
            return value.clientID;
        }

        public override string ToString()
        {
            return functionId.ToString();
        }
    }
}
