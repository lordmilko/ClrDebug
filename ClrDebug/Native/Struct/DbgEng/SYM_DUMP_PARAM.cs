using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    //This callback stops when a non-zero value is returned. 
    public delegate int PSYM_DUMP_FIELD_CALLBACK(IntPtr pField, IntPtr UserContext);

    [DebuggerDisplay("size = {size}, sName = {sName.ToString(),nq}, Options = {Options.ToString(),nq}, addr = {addr}, listLink = {listLink.ToString(),nq}, BufferOrContext = {BufferOrContext.ToString(),nq}, CallbackRoutine = {CallbackRoutine.ToString(),nq}, nFields = {nFields}, Fields = {Fields.ToString(),nq}, ModBase = {ModBase}, TypeId = {TypeId}, TypeSize = {TypeSize}, BufferSize = {BufferSize}, Flags = {Flags.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SYM_DUMP_PARAM
    {
        //In

        public int size;              // size of this struct

        public IntPtr sName;           // type name
        public DBG_DUMP Options;       // Dump options

        //If addr is specified, SymFromAddr will be performed
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
