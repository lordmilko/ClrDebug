using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    //todo: need debugger displays for all the new structs i added
    [DebuggerDisplay("Small = {Small.ToString(),nq}, Fat = {Fat.ToString(),nq}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_COR_ILMETHOD_SECT_EH
    {
        [FieldOffset(0)]
        public IMAGE_COR_ILMETHOD_SECT_EH_SMALL Small;

        [FieldOffset(0)]
        public IMAGE_COR_ILMETHOD_SECT_EH_FAT Fat;
    }
}
