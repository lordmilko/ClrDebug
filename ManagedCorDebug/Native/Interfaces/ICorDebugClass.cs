using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a type, which can be either basic or complex (that is, user-defined). If the type is generic, ICorDebugClass represents the uninstantiated generic type.
    /// </summary>
    /// <remarks>
    /// The ICorDebugClass interface represents an uninstantiated generic type. The ICorDebugType interface represents
    /// an instantiated generic type. For example, Hashtable&lt;K, V&gt; would be represented by ICorDebugClass, whereas
    /// Hashtable&lt;Int32, String&gt; would be represented by ICorDebugType. Non-generic types are represented by both
    /// ICorDebugClass and ICorDebugType. The latter interface was introduced in the .NET Framework version 2.0 to deal
    /// with type instantiation.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCAF5-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugClass
    {
        /// <summary>
        /// Gets the module that defines this class.
        /// </summary>
        /// <param name="pModule">[out] A pointer to the address of an ICorDebugModule object that represents the module in which this class is defined.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule pModule);

        /// <summary>
        /// Gets the TypeDef metadata token that references the definition of this class.
        /// </summary>
        /// <param name="pTypeDef">[out] A pointer to an mdTypeDef token that references the definition of this class.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetToken(out uint pTypeDef);

        /// <summary>
        /// Gets the value of the specified static field.
        /// </summary>
        /// <param name="fieldDef">[in] A field Def token that references the field to be retrieved.</param>
        /// <param name="pFrame">[in] A pointer to an ICorDebugFrame object that represents the frame to be used to disambiguate among thread, context, or application domain statics.<para/>
        /// If the static field is relative to a thread, a context, or an application domain, the frame will determine the proper value.</param>
        /// <param name="ppValue">[out] A pointer to the address of an ICorDebugValue object that represents the value of the static field.</param>
        /// <remarks>
        /// For parameterized types, the value of a static field is relative to the particular instantiation. Therefore, if
        /// the class constructor takes parameters of type <see cref="Type"/>, call <see cref="ICorDebugType.GetStaticFieldValue"/>
        /// instead of ICorDebugClass::GetStaticFieldValue.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStaticFieldValue([In] uint fieldDef, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}