using System;

namespace ClrDebug.DbgEng
{
    public static partial class DbgEngExtensions
    {
        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the dbgeng!DebugClient type.<para/>
        /// Possible conversions include <see cref="DebugClient"/>, <see cref="DebugAdvanced"/>,
        /// <see cref="DebugControl"/>, <see cref="DebugRegisters"/>, <see cref="DebugSymbols"/>
        /// and <see cref="DebugSystemObjects"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces DebugClient supports.</typeparam>
        /// <param name="debugClient">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DebugClient debugClient) =>
            AsDebugClient<T, IDebugClient>(debugClient.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the dbgeng!DebugClient type.<para/>
        /// Possible conversions include <see cref="DebugClient"/>, <see cref="DebugAdvanced"/>,
        /// <see cref="DebugControl"/>, <see cref="DebugRegisters"/>, <see cref="DebugSymbols"/>
        /// and <see cref="DebugSystemObjects"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces DebugClient supports.</typeparam>
        /// <param name="debugAdvanced">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DebugAdvanced debugAdvanced) =>
            AsDebugClient<T, IDebugAdvanced>(debugAdvanced.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the dbgeng!DebugClient type.<para/>
        /// Possible conversions include <see cref="DebugClient"/>, <see cref="DebugAdvanced"/>,
        /// <see cref="DebugControl"/>, <see cref="DebugRegisters"/>, <see cref="DebugSymbols"/>
        /// and <see cref="DebugSystemObjects"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces DebugClient supports.</typeparam>
        /// <param name="debugControl">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DebugControl debugControl) =>
            AsDebugClient<T, IDebugControl>(debugControl.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the dbgeng!DebugClient type.<para/>
        /// Possible conversions include <see cref="DebugClient"/>, <see cref="DebugAdvanced"/>,
        /// <see cref="DebugControl"/>, <see cref="DebugRegisters"/>, <see cref="DebugSymbols"/>
        /// and <see cref="DebugSystemObjects"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces DebugClient supports.</typeparam>
        /// <param name="debugRegisters">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DebugRegisters debugRegisters) =>
            AsDebugClient<T, IDebugRegisters>(debugRegisters.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the dbgeng!DebugClient type.<para/>
        /// Possible conversions include <see cref="DebugClient"/>, <see cref="DebugAdvanced"/>,
        /// <see cref="DebugControl"/>, <see cref="DebugRegisters"/>, <see cref="DebugSymbols"/>
        /// and <see cref="DebugSystemObjects"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces DebugClient supports.</typeparam>
        /// <param name="debugSymbols">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DebugSymbols debugSymbols) =>
            AsDebugClient<T, IDebugSymbols>(debugSymbols.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the dbgeng!DebugClient type.<para/>
        /// Possible conversions include <see cref="DebugClient"/>, <see cref="DebugAdvanced"/>,
        /// <see cref="DebugControl"/>, <see cref="DebugRegisters"/>, <see cref="DebugSymbols"/>
        /// and <see cref="DebugSystemObjects"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces DebugClient supports.</typeparam>
        /// <param name="debugSystemObjects">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DebugSystemObjects debugSystemObjects) =>
            AsDebugClient<T, IDebugSystemObjects>(debugSystemObjects.Raw);

        private static TResult AsDebugClient<TResult, TRaw>(IntPtr raw)
        {
            var t = typeof(TResult);
            object result;

            if (t == typeof(DebugClient))
                result = new DebugClient(raw);
            else if (t == typeof(DebugAdvanced))
                result = new DebugAdvanced(raw);
            else if (t == typeof(DebugControl))
                result = new DebugControl(raw);
            else if (t == typeof(DebugRegisters))
                result = new DebugRegisters(raw);
            else if (t == typeof(DebugSymbols))
                result = new DebugSymbols(raw);
            else if (t == typeof(DebugSystemObjects))
                result = new DebugSystemObjects(raw);
            else
                throw Extensions.GetAsNotSupportedException<TResult, TRaw>();

            return (TResult) result;
        }
    }
}
