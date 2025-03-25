using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum SSRVOPT : uint
    {
        //https://learn.microsoft.com/en-us/previous-versions/ff797954(v=vs.85)

        /// <summary>
        /// Resets default options.
        /// </summary>
        SSRVOPT_RESET = 0xFFFFFFFF,

        /// <summary>
        /// Callback function. The data parameter contains a pointer to the callback function. If data is NULL, any previously-set callback function is ignored.
        /// </summary>
        SSRVOPT_CALLBACK = 0x00000001,
        SSRVOPT_DWORD = 0x00000002,
        SSRVOPT_DWORDPTR = 0x00000004,
        SSRVOPT_GUIDPTR = 0x00000008,
        SSRVOPT_OLDGUIDPTR = 0x00000010,

        /// <summary>
        /// If data is TRUE, SymSrv will not display dialog boxes or pop-ups. If data is FALSE, SymSrv will display these graphical features when making connections.
        /// </summary>
        SSRVOPT_UNATTENDED = 0x00000020,

        /// <summary>
        /// If data is TRUE, SymSrv will not verify that the path parameter passed by the SymbolServer function actually exists. In this case, SymbolServer will always return TRUE.
        /// </summary>
        SSRVOPT_NOCOPY = 0x00000040,

        SSRVOPT_GETPATH = 0x00000040,

        /// <summary>
        /// The data parameter is an HWND value that specifies the handle to the parent window that should be used for all dialog boxes and pop-ups. If data is NULL, SymSrv will use the desktop window as the parent (this is the default).
        /// </summary>
        SSRVOPT_PARENTWIN = 0x00000080,

        /// <summary>
        /// Data type of the id parameter passed to the SymbolServer function.
        ///
        /// The data parameter is of type UINT_PTR and can be one of the following values:
        ///
        /// - SSRVOPT_DWORD (default)
        /// - SSRVOPT_DWORDPTR
        /// - SSRVOPT_GUIDPTR
        /// </summary>
        SSRVOPT_PARAMTYPE = 0x00000100,

        /// <summary>
        /// If data is TRUE, SymSrv will not use the downstream store specified in _NT_SYMBOL_PATH.
        /// </summary>
        SSRVOPT_SECURE = 0x00000200,

        /// <summary>
        /// 	SymSrv will provide debug trace information.
        /// </summary>
        SSRVOPT_TRACE = 0x00000400,

        /// <summary>
        /// The data parameter specifies the value passed to the SymbolServerCallback function in the context parameter.
        /// </summary>
        SSRVOPT_SETCONTEXT = 0x00000800,

        /// <summary>
        /// If data is NULL, the default proxy server is used. Otherwise, data is a null-terminated string that specifies the name and port
        /// number of the proxy server. The name and port number are separated by a colon (:). For more information, see Symbol Servers and Internet Firewalls.
        /// </summary>
        SSRVOPT_PROXY = 0x00001000,

        /// <summary>
        /// The data parameter contains a string that specifies the downstream store path. For more information, see Using SymSrv.
        /// </summary>
        SSRVOPT_DOWNSTREAM_STORE = 0x00002000,

        /// <summary>
        /// If data is TRUE, SymSrv will overwrite the downlevel store from the symbol store.
        /// </summary>
        SSRVOPT_OVERWRITE = 0x00004000,

        SSRVOPT_RESETTOU = 0x00008000,
        SSRVOPT_CALLBACKW = 0x00010000,

        /// <summary>
        /// If data is TRUE, SymSrv uses the default downstream store as a flat directory.
        /// </summary>
        SSRVOPT_FLAT_DEFAULT_STORE = 0x00020000,

        SSRVOPT_PROXYW = 0x00040000,
        SSRVOPT_MESSAGE = 0x00080000,
        SSRVOPT_SERVICE = 0x00100000,   // deprecated

        /// <summary>
        /// If data is TRUE, SymSrv uses symbols that do not have an address. By default, SymSrv filters out symbols that do not have an address.
        /// </summary>
        SSRVOPT_FAVOR_COMPRESSED = 0x00200000,

        SSRVOPT_STRING = 0x00400000,
        SSRVOPT_WINHTTP = 0x00800000,
        SSRVOPT_WININET = 0x01000000,
        SSRVOPT_DONT_UNCOMPRESS = 0x02000000,
        SSRVOPT_DISABLE_PING_HOST = 0x04000000,
        SSRVOPT_DISABLE_TIMEOUT = 0x08000000,
        SSRVOPT_ENABLE_COMM_MSG = 0x10000000,
        SSRVOPT_URI_FILTER = 0x20000000,
        SSRVOPT_URI_TIERS = 0x40000000,
        SSRVOPT_RETRY_APP_HANG = 0x80000000
    }
}
