using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("fName = {fName.ToString(),nq}, printName = {printName.ToString(),nq}, size = {size}, fOptions = {fOptions.ToString(),nq}, address = {address}, fieldCallbackOrBuffer = {fieldCallbackOrBuffer.ToString(),nq}, TypeId = {TypeId}, FieldOffset = {FieldOffset}, BufferSize = {BufferSize}, BitField = {BitField}, Flags = {Flags.ToString(),nq}, IsPointer = {IsPointer}, IsPointer64 = {IsPointer64}, IsArray = {IsArray}, IsStruct = {IsStruct}, IsConstant = {IsConstant}, IsStatic = {IsStatic}")]
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

        public bool IsPointer => (Flags.Data & 0x0001) != 0;
        public bool IsPointer64 => (Flags.Data & 0x0002) != 0;
        public bool IsArray => (Flags.Data & 0x0004) != 0;
        public bool IsStruct => (Flags.Data & 0x0008) != 0;
        public bool IsConstant => (Flags.Data & 0x0010) != 0;
        public bool IsStatic => (Flags.Data & 0x0020) != 0;
      /*public uint Flags;
        public uint fPointer:2;  // OUT set to 1 for pointers, 3 for 64bit pointers
        public uint fArray:1;    // OUT set to 1 for array types
        public uint fStruct:1;   // OUT set to 1 for struct/class tyoes
        public uint fConstant:1; // OUT set to 1 for constants (enumerate as fields)
        public uint fStatic:1;   // OUT set to 1 for statics (class/struct static members)
        public uint Reserved:26; // unused*/
    }
}
