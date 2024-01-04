using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5DDDE86F-9560-4A23-9592-8E69B92CDF4D")]
    [ComImport]
    public interface IDebugService
    {
    }
}
