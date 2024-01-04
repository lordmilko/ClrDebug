using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("31A3942E-E145-4112-9014-88DC7593028E")]
    [ComImport]
    public interface ISvcMappingInformation
    {
        [PreserveSig]
        SvcMappingForm GetMappingForm();
    }
}
