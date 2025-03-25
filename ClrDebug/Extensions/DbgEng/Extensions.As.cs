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
        /// <see cref="DebugSystemObjects"/>, <see cref="DebugTestHook"/> and <see cref="HostDataModelAccess"/>, <see cref="DebugTargetCompositionBridge"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces DebugClient supports.</typeparam>
        /// <param name="debugAdvanced">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this DebugAdvanced debugAdvanced) =>
            AsDebugClient<T, IDebugAdvanced>(debugAdvanced.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugClient">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugClient debugClient) =>
            AsDebugClient<T, IDebugClient>(debugClient.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugClientInternal">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugClientInternal debugClientInternal) =>
            AsDebugClient<T, IDebugClientInternal>(debugClientInternal.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugControl">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugControl debugControl) =>
            AsDebugClient<T, IDebugControl>(debugControl.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugDataModelScripting">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugDataModelScripting debugDataModelScripting) =>
            AsDebugClient<T, IDebugDataModelScripting>(debugDataModelScripting.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugLinkableProcessServer">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugLinkableProcessServer debugLinkableProcessServer) =>
            AsDebugClient<T, IDebugLinkableProcessServer>(debugLinkableProcessServer.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugModelQuery">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugModelQuery debugModelQuery) =>
            AsDebugClient<T, IDebugModelQuery>(debugModelQuery.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugPlmClient">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugPlmClient debugPlmClient) =>
            AsDebugClient<T, IDebugPlmClient>(debugPlmClient.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugRegisters">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugRegisters debugRegisters) =>
            AsDebugClient<T, IDebugRegisters>(debugRegisters.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugServiceProvider">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugServiceProvider debugServiceProvider) =>
            AsDebugClient<T, IDebugServiceProvider>(debugServiceProvider.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugSettings">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugSettings debugSettings) =>
            AsDebugClient<T, IDebugSettings>(debugSettings.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugSymbols">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugSymbols debugSymbols) =>
            AsDebugClient<T, IDebugSymbols>(debugSymbols.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugSystemObjects">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugSystemObjects debugSystemObjects) =>
            AsDebugClient<T, IDebugSystemObjects>(debugSystemObjects.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugTestHook">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugTestHook debugTestHook) =>
            AsDebugClient<T, IDebugTestHook>(debugTestHook.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="hostDataModelAccess">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this HostDataModelAccess hostDataModelAccess) =>
            AsDebugClient<T, IHostDataModelAccess>(hostDataModelAccess.Raw);

        /// <inheritdoc cref="As{T}(DebugAdvanced)"/>
        /// <param name="debugTargetCompositionBridge">The existing wrapper to create the new wrapper from.</param>
        public static T As<T>(this DebugTargetCompositionBridge debugTargetCompositionBridge) =>
            AsDebugClient<T, IDebugTargetCompositionBridge>(debugTargetCompositionBridge.Raw);

        private static TResult AsDebugClient<TResult, TRaw>(TRaw raw) =>
            AsDebugClient<TResult, TRaw>(Extensions.GetIUnknownForObject(raw));

        private static TResult AsDebugClient<TResult, TRaw>(IntPtr raw)
        {
            var t = typeof(TResult);
            object result;
            
            if (t == typeof(DebugAdvanced))
                result = new DebugAdvanced(raw);
            else if (t == typeof(DebugClient))
                result = new DebugClient(raw);
            else if (t == typeof(DebugClientInternal))
                result = new DebugClientInternal(raw);
            else if (t == typeof(DebugControl))
                result = new DebugControl(raw);
            else if (t == typeof(DebugDataModelScripting))
                result = new DebugDataModelScripting(raw);
            else if (t == typeof(DebugLinkableProcessServer))
                result = new DebugLinkableProcessServer(raw);
            else if (t == typeof(DebugModelQuery))
                result = new DebugModelQuery(raw);
            else if (t == typeof(DebugPlmClient))
                result = new DebugPlmClient(raw);
            else if (t == typeof(DebugRegisters))
                result = new DebugRegisters(raw);
            else if (t == typeof(DebugServiceProvider))
                result = new DebugServiceProvider(raw);
            else if (t == typeof(DebugSettings))
                result = new DebugSettings(raw);
            else if (t == typeof(DebugSymbols))
                result = new DebugSymbols(raw);
            else if (t == typeof(DebugSystemObjects))
                result = new DebugSystemObjects(raw);
            else if (t == typeof(DebugTestHook))
                result = new DebugTestHook(Extensions.GetObjectForIUnknown<IDebugTestHook>(raw));
            else if (t == typeof(HostDataModelAccess))
                result = new HostDataModelAccess(Extensions.GetObjectForIUnknown<IHostDataModelAccess>(raw));
            else if (t == typeof(DebugTargetCompositionBridge))
                result = new DebugTargetCompositionBridge(Extensions.GetObjectForIUnknown<IDebugTargetCompositionBridge>(raw));
            else
                throw Extensions.GetAsNotSupportedException<TResult, TRaw>();

            return (TResult) result;
        }

        #endregion
    }
}
