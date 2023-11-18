using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Execute and ExecuteCommandFile flags.<para/>
    /// These flags only apply to the command text itself; output from the executed
    /// command is controlled by the output control parameter.
    /// </summary>
    [Flags]
    public enum DEBUG_EXECUTE : uint
    {
        /// <summary>
        /// Default execution. Command is logged but not output.
        /// </summary>
        DEFAULT = 0x00000000,

        /// <summary>
        /// Echo commands during execution. In ExecuteCommandFile also echoes the prompt
        /// for each line of the file.
        /// </summary>
        ECHO = 0x00000001,

        /// <summary>
        /// Do not log or output commands during execution. Overridden by DEBUG_EXECUTE_ECHO.
        /// </summary>
        NOT_LOGGED = 0x00000002,

        /// <summary>
        /// If this flag is not set an empty string to Execute will repeat the last Execute string.
        /// </summary>
        NO_REPEAT = 0x00000004,

        /// <summary>
        /// If this flag is set, the source of command execution is user typing from remote session.
        /// </summary>
        USER_TYPED = 0x00000008,

        /// <summary>
        /// If this flag is set, the source of command execution is user clicking from remote session.
        /// </summary>
        USER_CLICKED = 0x00000010,

        /// <summary>
        /// If this flag is set, the source of command execution is debugger extension.
        /// </summary>
        EXTENSION = 0x00000020,

        /// <summary>
        /// If this flag is set, the source of command execution is internal command like debugger setup.
        /// </summary>
        INTERNAL = 0x00000040,

        /// <summary>
        /// If this flag is set, the source of command execution is debugger script.
        /// </summary>
        SCRIPT = 0x00000080,

        /// <summary>
        /// If this flag is set, the source of command execution is a toolbar button.
        /// </summary>
        TOOLBAR = 0x00000100,

        /// <summary>
        /// If this flag is set, the source of command execution is a menu item.
        /// </summary>
        MENU = 0x00000200,

        /// <summary>
        /// If this flag is set, the source of command execution is a keyboard shortcut or hotkey.
        /// </summary>
        HOTKEY = 0x00000400,

        /// <summary>
        /// If this flag is set, the source of command execution is a command registered on an event.
        /// </summary>
        EVENT = 0x00000800
    }
}
