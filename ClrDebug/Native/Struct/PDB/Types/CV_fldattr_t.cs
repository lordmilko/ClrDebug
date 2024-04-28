using System.Diagnostics;
using ClrDebug.DIA;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// class field attribute
    /// </summary>
    [DebuggerDisplay("access = {access.ToString(),nq}, pseudo = {pseudo}, noinherit = {noinherit}, noconstruct = {noconstruct}, compgenx = {compgenx}, @sealed = {@sealed}, unused = {unused}, data = {data}")]
    public struct CV_fldattr_t
    {
        /// <summary>
        /// access protection CV_access_t
        /// </summary>
        public CV_access_e access
        {
            get => (CV_access_e) GetBits(data, 0, 2); //0-1
            set => SetBits(ref data, 0, 2, (short) value);
        }

        /// <summary>
        /// method properties CV_methodprop_t
        /// </summary>
        public CV_methodprop_e mprop
        {
            get => (CV_methodprop_e) GetBits(data, 2, 3); //2-4
            set => SetBits(ref data, 2, 3, (short) value);
        }

        /// <summary>
        /// compiler generated fcn and does not exist
        /// </summary>
        public bool pseudo
        {
            get => GetBitFlag(data, 5);
            set => SetBitFlag(ref data, 5, value);
        }

        /// <summary>
        /// true if class cannot be inherited
        /// </summary>
        public bool noinherit
        {
            get => GetBitFlag(data, 6);
            set => SetBitFlag(ref data, 6, value);
        }

        /// <summary>
        /// true if class cannot be constructed
        /// </summary>
        public bool noconstruct
        {
            get => GetBitFlag(data, 7);
            set => SetBitFlag(ref data, 7, value);
        }

        /// <summary>
        /// compiler generated fcn and does exist
        /// </summary>
        public bool compgenx
        {
            get => GetBitFlag(data, 8);
            set => SetBitFlag(ref data, 8, value);
        }

        /// <summary>
        /// true if method cannot be overridden
        /// </summary>
        public bool @sealed
        {
            get => GetBitFlag(data, 9);
            set => SetBitFlag(ref data, 9, value);
        }

        /// <summary>
        /// unused
        /// </summary>
        public short unused
        {
            get => GetBits(data, 10, 6); //10-15
            set => SetBits(ref data, 10, 6, value);
        }

        public short data;
    }
}
