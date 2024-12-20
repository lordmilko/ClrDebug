using System;

namespace ClrDebug.TypeLib
{
    public static partial class TypeLibExtensions
    {
        #region TypeLib

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the oleaut32!CTypeLib2 type.<para/>
        /// Possible conversions include <see cref="ComTypeLib"/>, <see cref="CreateTypeLib"/> and <see cref="TypeComp"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces CTypeLib2 supports.</typeparam>
        /// <param name="typeLib">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this ComTypeLib typeLib) =>
            AsTypeLib<T, ITypeLib>(typeLib.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the oleaut32!CTypeLib2 type.<para/>
        /// Possible conversions include <see cref="ComTypeLib"/>, <see cref="CreateTypeLib"/> and <see cref="TypeComp"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces CTypeLib2 supports.</typeparam>
        /// <param name="createTypeLib">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this CreateTypeLib createTypeLib) =>
            AsTypeLib<T, ICreateTypeLib>(createTypeLib.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by either the oleaut32!CTypeLib2 type or the oleaut32!CTypeInfo2 type.<para/>
        /// Possible conversions include <see cref="ComTypeLib"/>, <see cref="CreateTypeLib"/>, <see cref="TypeComp"/>,
        /// <see cref="TypeInfo"/> and <see cref="CreateTypeInfo"/>. The actual conversions that are possible will depend on whether
        /// <paramref name="typeComp"/> represents a CTypeLib2 or a CTypeInfo2 object.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces CTypeLib2 supports.</typeparam>
        /// <param name="typeComp">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this TypeComp typeComp)
        {
            if (TryAsTypeInfo<T, ITypeComp>(typeComp.Raw, out var result))
                return result;

            return AsTypeLib<T, ITypeComp>(typeComp.Raw);
        }

        #endregion
        #region TypeInfo

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the oleaut32!CTypeInfo2 type.<para/>
        /// Possible conversions include <see cref="TypeInfo"/>, <see cref="CreateTypeInfo"/> and <see cref="TypeComp"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces CTypeLib2 supports.</typeparam>
        /// <param name="typeInfo">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this TypeInfo typeInfo) =>
            AsTypeInfo<T, ITypeInfo>(typeInfo.Raw);

        /// <summary>
        /// Creates a <see cref="ComObject{T}"/> around an interface supported by the oleaut32!CTypeInfo2 type.<para/>
        /// Possible conversions include <see cref="TypeInfo"/>, <see cref="CreateTypeInfo"/> and <see cref="TypeComp"/>.
        /// </summary>
        /// <typeparam name="T">A type that wraps one of the interfaces CTypeLib2 supports.</typeparam>
        /// <param name="createTypeInfo">The existing wrapper to create the new wrapper from.</param>
        /// <returns>A wrapper of type <typeparamref name="T"/>.</returns>
        /// <exception cref="NotSupportedException">A type is specified that is not known to this function.</exception>
        public static T As<T>(this CreateTypeInfo createTypeInfo) =>
            AsTypeInfo<T, ICreateTypeInfo>(createTypeInfo.Raw);

        #endregion

        private static TResult AsTypeLib<TResult, TRaw>(TRaw raw)
        {
            var t = typeof(TResult);
            object result;

            if (t == typeof(ComTypeLib))
                result = new ComTypeLib((ITypeLib) raw);
            else if (t == typeof(CreateTypeLib))
                result = new CreateTypeLib((ICreateTypeLib) raw);
            else if (t == typeof(TypeComp))
                result = new TypeComp((ITypeComp) raw);
            else
                throw Extensions.GetAsNotSupportedException<TResult, TRaw>();

            return (TResult) result;
        }

        private static TResult AsTypeInfo<TResult, TRaw>(TRaw raw)
        {
            if (TryAsTypeInfo<TResult, TRaw>(raw, out var result))
                return result;

            throw Extensions.GetAsNotSupportedException<TResult, TRaw>();
        }

        private static bool TryAsTypeInfo<TResult, TRaw>(TRaw raw, out TResult result)
        {
            var t = typeof(TResult);
            object rawResult;

            if (t == typeof(TypeInfo))
                rawResult = new TypeInfo((ITypeInfo) raw);
            else if (t == typeof(CreateTypeInfo))
                rawResult = new CreateTypeInfo((ICreateTypeInfo) raw);
            else if (t == typeof(TypeComp))
                rawResult = new TypeComp((ITypeComp) raw);
            else
            {
                result = default;
                return false;
            }

            result = (TResult) rawResult;
            return true;
        }
    }
}
