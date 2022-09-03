using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Contains attributes of a <see cref="ITypeInfo"/>.
    /// </summary>
    [DebuggerDisplay("guid = {guid.ToString(),nq}, lcid = {lcid}, dwReserved = {dwReserved}, memidConstructor = {memidConstructor}, memidDestructor = {memidDestructor}, lpstrSchema = {lpstrSchema.ToString(),nq}, cbSizeInstance = {cbSizeInstance}, typekind = {typekind.ToString(),nq}, cFuncs = {cFuncs}, cVars = {cVars}, cImplTypes = {cImplTypes}, cbSizeVft = {cbSizeVft}, cbAlignment = {cbAlignment}, wTypeFlags = {wTypeFlags.ToString(),nq}, wMajorVerNum = {wMajorVerNum}, wMinorVerNum = {wMinorVerNum}, tdescAlias = {tdescAlias.ToString(),nq}, idldescType = {idldescType.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TYPEATTR
    {
        /// <summary>
        /// A constant used with the <see cref="memidConstructor"/> and <see cref="memidDestructor"/> fields.
        /// </summary>
        public const int MEMBER_ID_NIL = -1;

        /// <summary>
        /// The GUID of the type information.
        /// </summary>
        public Guid guid;

        /// <summary>
        /// Locale of member names and documentation strings.
        /// </summary>
        public int lcid;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public int dwReserved;

        /// <summary>
        /// ID of constructor, or <see cref="MEMBER_ID_NIL"/> if none.
        /// </summary>
        public int memidConstructor;

        /// <summary>
        /// ID of destructor, or <see cref="MEMBER_ID_NIL"/> if none.
        /// </summary>
        public int memidDestructor;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public IntPtr lpstrSchema;

        /// <summary>
        /// The size of an instance of this type.
        /// </summary>
        public int cbSizeInstance;

        /// <summary>
        /// A <see cref="TYPEKIND"/> value describing the type this information describes.
        /// </summary>
        public TYPEKIND typekind;

        /// <summary>
        /// Indicates the number of functions on the interface this structure describes.
        /// </summary>
        public short cFuncs;

        /// <summary>
        /// Indicates the number of variables and data fields on the interface described by this structure.
        /// </summary>
        public short cVars;

        /// <summary>
        /// Indicates the number of implemented interfaces on the interface this structure describes.
        /// </summary>
        public short cImplTypes;

        /// <summary>
        /// The size of this type's virtual method table (VTBL).
        /// </summary>
        public short cbSizeVft;

        /// <summary>
        /// Specifies the byte alignment for an instance of this type.
        /// </summary>
        public short cbAlignment;

        /// <summary>
        /// A <see cref="TYPEFLAGS"/> value describing this information.
        /// </summary>
        public TYPEFLAGS wTypeFlags;

        /// <summary>
        /// Major version number.
        /// </summary>
        public short wMajorVerNum;

        /// <summary>
        /// Minor version number.
        /// </summary>
        public short wMinorVerNum;

        /// <summary>
        /// If <see cref="typekind"/> == <see cref="TYPEKIND.TKIND_ALIAS"/>, specifies the type for which this type is an alias.
        /// </summary>
        public TYPEDESC tdescAlias;

        /// <summary>
        /// IDL attributes of the described type.
        /// </summary>
        public IDLDESC idldescType;
    }
}
