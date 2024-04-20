using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines stack source information.
    /// </summary>
    public struct STACK_SRC_INFO
    {
        /// <summary>
        /// An image path.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ImagePath;

        /// <summary>
        /// A module name.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ModuleName;

        /// <summary>
        /// A function.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Function;

        /// <summary>
        /// A displacement value.
        /// </summary>
        public int Displacement;

        /// <summary>
        /// A row number.
        /// </summary>
        public int Row;

        /// <summary>
        /// A column number.
        /// </summary>
        public int Column;
    }
}
