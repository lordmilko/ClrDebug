namespace ClrDebug
{
    public enum ShowWindow : ushort
    {
        Hide = 0,
        ShowNormal = 1,
        Normal = ShowNormal,
        ShowMinimized = 2,
        ShowMaximized = 3,
        Maximize = ShowMaximized,
        ShowNoActivate = 4,
        Show = 5,
        Minimized = 6,
        ShowMinNoActive = 7,
        ShowNa = 8,
        ShowRestore = 9,

        /// <summary>
        /// This flag is not supported when used in conjunction with <see cref="STARTUPINFOW"/>.
        /// </summary>
        ShowDefault = 10,
        ForceMinimize = 11
    }
}