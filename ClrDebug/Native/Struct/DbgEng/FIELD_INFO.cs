using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("{fName,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct FIELD_INFO
    {
        public IntPtr fName;     // Name of the field

        public IntPtr printName; // Name to be printed at dump

        public int size;        // Size of the field
        public DBG_DUMP_FIELD fOptions;    // Dump Options for the field
        public long address;    // address of the field

        public IntPtr fieldCallbackOrBuffer;

        public int TypeId;      // OUT Type index of the field
        public int FieldOffset; // OUT Offset of field inside struct
        public int BufferSize;  // size of buffer used with DBG_DUMP_FIELD_COPY_FIELD_DATA
        public int BitField;

        public BitVector32 Flags;
      /*public uint Flags;
        public uint fPointer:2;  // OUT set to 1 for pointers, 3 for 64bit pointers
        public uint fArray:1;    // OUT set to 1 for array types
        public uint fStruct:1;   // OUT set to 1 for struct/class tyoes
        public uint fConstant:1; // OUT set to 1 for constants (enumerate as fields)
        public uint fStatic:1;   // OUT set to 1 for statics (class/struct static members)
        public uint Reserved:26; // unused*/
    }
}
