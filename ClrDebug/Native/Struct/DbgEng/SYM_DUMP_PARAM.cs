using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    public delegate int PSYM_DUMP_FIELD_CALLBACK(FIELD_INFO pField, IntPtr UserContext);

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct SYM_DUMP_PARAM
    {
        //In

        public int size;              // size of this struct

        public IntPtr sName;           // type name
        public DBG_DUMP Options;       // Dump options
        public long addr;             // Address to take data for type
        public IntPtr listLink;        // fName here would be used to do list dump   // PFIELD_INFO

        public IntPtr BufferOrContext;

        public IntPtr CallbackRoutine; // Routine called back
        public int nFields;           // # elements in Fields

        public IntPtr Fields;          // Used to return information about field // PFIELD_INFO

        //Out

        public long ModBase;          // OUT Module base address containing type
        public int TypeId;            // OUT Type index of the symbol
        public int TypeSize;          // OUT Size of type
        public int BufferSize;        // IN size of buffer (used with DBG_DUMP_COPY_TYPE_DATA)

        //In C++ bit fields are used, however we can't do that so we wrap all 32 remaining bits up in a singular
        //Flags field
        public BitVector32 Flags; //OUT
      /*public uint fPointer:2;        // OUT set to 1 for pointers, 3 for 64bit pointers
        public uint fArray:1;          // OUT set to 1 for array types
        public uint fStruct:1;         // OUT set to 1 for struct/class tyoes
        public uint fConstant:1;       // OUT set to 1 for constant types (unused)
        public uint Reserved:27;       // unused*/
    }
}
