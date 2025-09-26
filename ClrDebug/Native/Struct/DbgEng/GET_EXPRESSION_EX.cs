using System;

namespace ClrDebug.DbgEng
{
    public struct GET_EXPRESSION_EX
    {
        public IntPtr Expression; //String
        public IntPtr Remainder; //String
        public long Value;
    }
}
