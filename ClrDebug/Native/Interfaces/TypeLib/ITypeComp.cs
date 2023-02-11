using System.Runtime.InteropServices;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Provides the managed definition of the ITypeComp interface.
    /// </summary>
    [Guid("00020403-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ITypeComp
    {
        /// <summary>
        /// Maps a name to a member of a type, or binds global variables and functions contained in a type library.
        /// </summary>
        /// <param name="szName">The name to bind.</param>
        /// <param name="lHashVal">A hash value for szName computed by LHashValOfNameSys.</param>
        /// <param name="wFlags">A flags word containing one or more of the invoke flags defined in the INVOKEKIND enumeration.</param>
        /// <param name="ppTInfo">When this method returns, contains a reference to the type description that contains the item to which it is bound, if a FUNCDESC or VARDESC was returned. This parameter is passed uninitialized.</param>
        /// <param name="pDescKind">When this method returns, contains a reference to a DESCKIND enumerator that indicates whether the name bound-to is a VARDESC, FUNCDESC, or TYPECOMP. This parameter is passed uninitialized.</param>
        /// <param name="pBindPtr">When this method returns, contains a reference to the bound-to VARDESC, FUNCDESC, or ITypeComp interface. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT Bind(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] int lHashVal,
            [In] short wFlags,
            [Out] out ITypeInfo ppTInfo,
            [Out] out DESCKIND pDescKind,
            [Out] out BINDPTR pBindPtr);

        /// <summary>
        /// Binds to the type descriptions contained within a type library.
        /// </summary>
        /// <param name="szName">The name to bind.</param>
        /// <param name="lHashVal">A hash value for szName determined by LHashValOfNameSys.</param>
        /// <param name="ppTInfo">When this method returns, contains a reference to an ITypeInfo of the type to which szName was bound. This parameter is passed uninitialized.</param>
        /// <param name="ppTComp">When this method returns, contains a reference to an ITypeComp variable. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT BindType(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] int lHashVal,
            [Out] out ITypeInfo ppTInfo,
            [Out] out ITypeComp ppTComp);
    }
}
