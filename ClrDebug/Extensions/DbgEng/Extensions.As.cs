using System;

namespace ClrDebug.DbgEng
{
    public static partial class DbgEngExtensions
    {
        #region DebugClient

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the dbgeng!DebugClient type.<para/>
        /// Possible conversions include <see cref="DebugAdvanced"/>, <see cref="DebugClient"/>, <see cref="DebugClientInternal"/>,
        /// <see cref="DebugControl"/>, <see cref="DebugDataModelScripting"/>, <see cref="DebugLinkableProcessServer"/>, <see cref="DebugModelQuery"/>,
        /// <see cref="DebugPlmClient"/>, <see cref="DebugRegisters"/>, <see cref="DebugServiceProvider"/>, <see cref="DebugSettings"/>, <see cref="DebugSymbols"/>,
        /// <see cref="DebugSystemObjects"/> and <see cref="HostDataModelAccess"/>, <see cref="DebugTargetCompositionBridge"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces DebugClient supports.</typeparam>
        /// <param name="debugAdvanced">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DebugAdvanced debugAdvanced) =>
            AsDebugClient<T>(debugAdvanced.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugClient">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugClient debugClient) =>
            AsDebugClient<T>(debugClient.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugClientInternal">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugClientInternal debugClientInternal) =>
            AsDebugClient<T>(debugClientInternal.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugControl">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugControl debugControl) =>
            AsDebugClient<T>(debugControl.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugDataModelScripting">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugDataModelScripting debugDataModelScripting) =>
            AsDebugClient<T>(debugDataModelScripting.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugLinkableProcessServer">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugLinkableProcessServer debugLinkableProcessServer) =>
            AsDebugClient<T>(debugLinkableProcessServer.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugModelQuery">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugModelQuery debugModelQuery) =>
            AsDebugClient<T>(debugModelQuery.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugPlmClient">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugPlmClient debugPlmClient) =>
            AsDebugClient<T>(debugPlmClient.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugRegisters">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugRegisters debugRegisters) =>
            AsDebugClient<T>(debugRegisters.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugServiceProvider">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugServiceProvider debugServiceProvider) =>
            AsDebugClient<T>(debugServiceProvider.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugSettings">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugSettings debugSettings) =>
            AsDebugClient<T>(debugSettings.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugSymbols">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugSymbols debugSymbols) =>
            AsDebugClient<T>(debugSymbols.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugSystemObjects">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugSystemObjects debugSystemObjects) =>
            AsDebugClient<T>(debugSystemObjects.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="hostDataModelAccess">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this HostDataModelAccess hostDataModelAccess) =>
            AsDebugClient<T>(hostDataModelAccess.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugTargetCompositionBridge">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugTargetCompositionBridge debugTargetCompositionBridge) =>
            AsDebugClient<T>(debugTargetCompositionBridge.Raw);

        private static T AsDebugClient<T>(object raw)
        {
            var t = typeof(T);

            object result;

            //Note that IDebugTestHook is not in here, I'm pretty sure you have to ask to DebugCreate for it directly

            if (t == typeof(DebugAdvanced))
                result = new DebugAdvanced((IDebugAdvanced) raw);
            else if (t == typeof(DebugClient))
                result = new DebugClient((IDebugClient) raw);
            else if (t == typeof(DebugClientInternal))
                result = new DebugClientInternal((IDebugClientInternal) raw);
            else if (t == typeof(DebugControl))
                result = new DebugControl((IDebugControl) raw);
            else if (t == typeof(DebugDataModelScripting))
                result = new DebugDataModelScripting((IDebugDataModelScripting) raw);
            else if (t == typeof(DebugLinkableProcessServer))
                result = new DebugLinkableProcessServer((IDebugLinkableProcessServer) raw);
            else if (t == typeof(DebugModelQuery))
                result = new DebugModelQuery((IDebugModelQuery) raw);
            else if (t == typeof(DebugPlmClient))
                result = new DebugPlmClient((IDebugPlmClient) raw);
            else if (t == typeof(DebugRegisters))
                result = new DebugRegisters((IDebugRegisters) raw);
            else if (t == typeof(DebugServiceProvider))
                result = new DebugServiceProvider((IDebugServiceProvider) raw);
            else if (t == typeof(DebugSettings))
                result = new DebugSettings((IDebugSettings) raw);
            else if (t == typeof(DebugSymbols))
                result = new DebugSymbols((IDebugSymbols) raw);
            else if (t == typeof(DebugSystemObjects))
                result = new DebugSystemObjects((IDebugSystemObjects) raw);
            else if (t == typeof(HostDataModelAccess))
                result = new HostDataModelAccess((IHostDataModelAccess) raw);
            else if (t == typeof(DebugTargetCompositionBridge))
                result = new DebugTargetCompositionBridge((IDebugTargetCompositionBridge) raw);
            else
                throw Extensions.GetAsNotSupportedException<T, object>();

            return (T) result;
        }

        #endregion
        public static T As<T>(this DebugHostContext debugHostContext)
        {
            var t = typeof(T);
            object result;

            var raw = debugHostContext.Raw;

            if (t == typeof(DebugHostContext))
                result = debugHostContext;
            else if (t == typeof(DebugHostContextTargetComposition))
                result = new DebugHostContextTargetComposition((IDebugHostContextTargetComposition) raw);
            else
                throw new NotImplementedException(); //todo

            return (T) result;
        }
    }
}
